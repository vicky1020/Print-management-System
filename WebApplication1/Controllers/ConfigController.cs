using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using PrintManagement.Common.Models;
using PrintManagement.Common.Repositories;
using PrintManagementApp.Filters;
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
        private readonly Utility util;
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController" /> class.
        /// </summary>
        /// <param name="IRepository">The tenants repository.</param>
        public ConfigController()
        {
            irepo = new Repository();
            util = new Utility();
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
                ViewBag.PrintingColor = await irepo.GetAllPrintingColour();
                ViewBag.Papersize = await irepo.GetAllPaperSize();
                ViewBag.PaperGSM = await irepo.GetAllPaperGSM();
                ViewBag.PaperSide = await irepo.GetAllPaperSide();
                ViewBag.LedgerFolio = await irepo.GetAllLedgerFalio();
                ViewBag.Customers = await irepo.GetAllCustomer();
                ViewBag.paperQuality = await irepo.GetAllPaperQuality();
                ViewBag.ItemDisplayConfig = await irepo.GetAllItemDisplayConfig();
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

        
        public async Task<int> InsertConfig(OrderConfigurationModel obj)
        {
            obj.CreatedBy = Convert.ToString(Session["AccountName"]);
            obj.CreatedDate = DateTime.Now;
            var i =await util.getdata(obj);
            if (i.OrderConfigurationId == 1)
            {
                return 1;
            }
            else if(i.OrderConfigurationId==0)
            {
                var orderConfig = irepo.AddOrderConfiguration(obj);
                return 0;
            }
            return 1;
        }

    }
}