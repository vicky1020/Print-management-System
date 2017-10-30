using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PrintManagement.Common.Repositories;
using PrintManagement.Common.Interfaces;
using System.Web.Mvc;
using PrintManagementApp.Models;
using System.Threading.Tasks;
using PrintManagementApp.Controllers;
using PrintManagementApp.Filters;
using PrintManagement.Common.Models;
using PrintManagementApp.Utilities;

namespace PrintManagementApp.Controllers
{
    #region

    #endregion
    [SessionExpireFilter]
    public class ConfigController : Controller
    {

        #region
        private readonly Repository irepo;
        private ConfigViewDisplay util;
        #endregion
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController" /> class.
        /// </summary>
        /// <param name="IRepository">The tenants repository.</param>
        public ConfigController()
        {
             irepo = new Repository();
             util = new ConfigViewDisplay();
        }
        #endregion

        public async Task<ActionResult> Index()
        {
            try
            {
                var OrderConfigModel = await irepo.GetAllOrderConfiguration();
                var OrderConfigValueModel =  await util.getConfigValues(OrderConfigModel);

                return View(OrderConfigValueModel);
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
        public void InsertConfig(OrderConfigurationModel obj)
        {
            var orderConfig = irepo.AddOrderConfiguration(obj);
        }
        
    }
}