using System.Threading.Tasks;
using System.Web.Mvc;
using PrintManagementApp.Models;
using PrintManagement.Common.Repositories;
using Rework;

namespace PrintManagementApp.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly Repository irepo;
        public AccountController()
        {
            var irepo = new Repository();
        }
        
        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            Session.Clear();
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            Session.Clear();
            if (ModelState.IsValid)
            {
                var result = false;
                var checkCred = new Repository();
                var loginResult = await checkCred.Login(model.Email);
                if (loginResult != null)
                {
                    var hashedPassword = model.Password.ToSHA(Crypto.SHA_Type.SHA256);
                    if (loginResult.EmailId == model.Email && loginResult.Password == hashedPassword)
                        result = true;
                    ViewBag.Roles = loginResult.UserName;
                    ViewBag.AccountName = loginResult.FirstName;
                    Session["AccountName"] = loginResult.FirstName.ToString();
                    Session["Roles"] = loginResult.UserName.ToString();

                }
                else
                    result = false;

                switch (result)
                {
                    case true:
                        return RedirectToLocal(returnUrl);
                    default:
                        ModelState.AddModelError("", "Invalid login attempt.");
                        return View(model);
                }
               
            }
            return View(ViewBag);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
            base.Dispose(disposing);
        }

        #region Helpers
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Orders", "Job");
        }
        #endregion
    }
}