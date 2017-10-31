using System;
using PrintManagement.Common.Repositories;
using System.Web.Mvc;
using System.Threading.Tasks;
using PrintManagement.Common.Models;
using PrintManagementApp.Filters;
using PrintManagementApp.Utilities;

namespace PrintManagementApp.Controllers
{
    #region

    #endregion

    [SessionExpireFilter]
    public class JobController : Controller
    {

        #region
        private readonly Repository irepo;
        private readonly Utility util;
        #endregion
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="JobController" /> class.
        /// </summary>
        /// <param name="IRepository">The tenants repository.</param>
        public JobController()
        {
            irepo = new Repository();
            util = new Utility();
        }
        #endregion

        public async Task<ActionResult> Index()
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


        public async Task<ActionResult> Orders()
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
            obj.CreatedBy = Convert.ToString(Session["AccountName"]);
            obj.CreatedDate = DateTime.Now;
            var OrderItemModel = irepo.AddOrderItem(obj);
        }
        public void customer(CustomerModel obj)
        {
            var CustomerAdd = irepo.AddCustomer(obj);
        }

        public async Task<JsonResult> CalculateTaxes(OrderItemModel obj)
        {
            TaxViewModel t = new TaxViewModel();
            t = await util.GetTaxAmt(obj);
            t.CGSTAmt = t.CGSTAmt + t.SGSTAmt;
            return Json(t, JsonRequestBehavior.AllowGet);
        }
    }
}