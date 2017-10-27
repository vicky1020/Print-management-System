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

namespace PrintManagementApp.Controllers
{
    #region

    #endregion
    [SessionExpireFilter]
    public class ConfigController : Controller
    {

        #region
        private readonly Repository irepo;
        #endregion
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController" /> class.
        /// </summary>
        /// <param name="IRepository">The tenants repository.</param>
        public ConfigController()
        {
             irepo = new Repository();
        }
        #endregion

        public async Task<ActionResult> Index()
        {
            try
            {
                var OrderConfigModel = await irepo.GetAllOrderConfiguration();
                return View(OrderConfigModel);
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }

        public async Task<ActionResult> AddConfig()
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
                ViewBag.BtnName = "ADD";
                return View();
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }

        public async Task<ActionResult> UpdateConfig()
        {
            try
            {
                ViewBag.AllProductItem = await irepo.GetAllProductItem();
                ViewBag.OrderConfiguration = await irepo.GetAllOrderConfiguration();
                ViewBag.PrintingColor = await irepo.GetAllPrintingColour();
                ViewBag.Papersize = await irepo.GetAllPaperSize();
                ViewBag.PaperGSM = await irepo.GetAllPaperGSM();
                ViewBag.PaperSide = await irepo.GetAllPaperSide();
                ViewBag.LedgerFolio = await irepo.GetAllLedgerFalio();
                ViewBag.Customers = await irepo.GetAllCustomer();
                ViewBag.paperQuality = await irepo.GetAllPaperQuality();
                ViewBag.BtnName = "UPDATE";
                return View("AddConfig");
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }

        [HttpPost]
        public void InsertConfig(PrintManagement.Common.Models.OrderConfigurationModel obj)
        {
            var orderConfig = irepo.AddOrderConfiguration(obj);
        }
    }
}