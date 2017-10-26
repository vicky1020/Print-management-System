using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common.Repository;
using Common.Interfaces;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    #region
   
    #endregion
    public class HomeController : Controller
    {

        #region
      private readonly Repository irepo;
        #endregion
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController" /> class.
        /// </summary>
        /// <param name="IRepository">The tenants repository.</param>
        public HomeController()
        {
            var irepo =  new Repository();

        }
        #endregion
       
        public async Task<ActionResult> Index()
        {

            var irepo = new Repository();
            try
            {
                var OrderItemModel = await irepo.GetAllOrder();
                return View(OrderItemModel);
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }

        public async Task<ActionResult> Report()
        {
            var irepo = new Repository();
            try
            {
                var OrderItemModel = await irepo.GetAllOrder();
                return View(OrderItemModel);
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
       
    }
}