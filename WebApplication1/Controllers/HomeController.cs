using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PrintManagement.Common.Repository;
using PrintManagement.Common.Interfaces;
using System.Web.Mvc;
using PrintManagementApp.Models;
using System.Threading.Tasks;
using WebApplication1.Controllers;
using PrintManagement.Common.Models;

namespace PrintManagementApp.Controllers
{
    #region

    #endregion

    [SessionExpireFilter]
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
             irepo =  new Repository();
        }
        #endregion

        public async Task<ActionResult> Index()
        {
            try
            {
                ViewBag.OrderItem = await irepo.GetAllOrderItem();
                ViewBag.AllProductItem = await irepo.GetAllProductItem();
                ViewBag.OrderConfiguration = await irepo.GetAllOrderConfiguration();
                ViewBag.PrintingColor = await irepo.GetAllPrintingColour();
                ViewBag.Papersize = await irepo.GetAllPaperSize();
                ViewBag.PaperGSM = await irepo.GetAllPaperGSM();
                ViewBag.PaperSide = await irepo.GetAllPaperSide();
                ViewBag.LedgerFolio = await irepo.GetAllLedgerFalio();
                ViewBag.Customers = await irepo.GetAllCustomer();
                ViewBag.paperQuality = await irepo.GetAllPaperQuality();
                return View();
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }

        public async Task<ActionResult> Report()
        {
            try
            {
                var OrderItemModel = await irepo.GetAllOrderItem();
                return View(OrderItemModel);
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }

        public void SaveOrder(OrderItemModel obj)
        {
            var OrderItemModel = irepo.AddOrderItem(obj);
        }

    }
}