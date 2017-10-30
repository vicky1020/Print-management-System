using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using PrintManagementApp.Models;
using PrintManagement.Common.Repositories;
using PrintManagement.Common.Models;
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
                var result = SignInStatus.Failure;
                var checkCred = new Repository();
                var loginResult = await checkCred.Login(model.Email);
                if (loginResult != null)
                {
                    if (loginResult.EmailId == model.Email && loginResult.Password == model.Password)
                        result = SignInStatus.Success;
                    ViewBag.Roles = loginResult.UserName;
                    ViewBag.AccountName = loginResult.FirstName;
                    Session["AccountName"] = loginResult.FirstName.ToString();
                    Session["Roles"] = loginResult.UserName.ToString();

                }
                else
                {
                    result = SignInStatus.Failure;
                }
                switch (result)
                {
                    case SignInStatus.Success:
                        return RedirectToLocal(returnUrl);
                    case SignInStatus.LockedOut:
                        return View("Lockout");
                    case SignInStatus.Failure:
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