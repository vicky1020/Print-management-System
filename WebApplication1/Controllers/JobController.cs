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
                ViewBag.ItemDisplayConfig = await irepo.GetAllItemDisplayConfig();
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

        public async Task<int> saveCustomer(OrderItemModel obj)
        {
            if (obj.OrderId != 0)
            {
                Console.WriteLine(obj.OrderId + "" + "is the order id");
                obj.UpdatedBy = Convert.ToString(Session["AccountName"]);
                obj.UpdatedDate = DateTime.Now;
                if (obj.JobProcessType == "Order Confirm")
                {
                    if (obj.CustomerId == null)
                    {
                        CustomerModel c = new CustomerModel();

                        c.CreatedBy = Convert.ToString(Session["AccountName"]);
                        c.FirstName = obj.FirstName;
                        c.LastName = obj.LastName;
                        c.PhoneNumber = obj.PhoneNumber;
                        c.CreatedDate = obj.CreatedDate;
                        c.Email = obj.Email;
                        var a = await irepo.AddCustomer(c);
                        obj.CustomerId = a;
                    }
                }
                var OrderItemModel = irepo.UpdateOrderItem(obj, obj.OrderId);
                return 1;
            }
            else
            {
                Console.WriteLine("no orderid" + "" + "so creating new");
                obj.CreatedBy = Convert.ToString(Session["AccountName"]);
                obj.CreatedDate = DateTime.Now;
                if (obj.JobProcessType == "Order Confirm")
                {
                    if (obj.CustomerId == null)
                    {
                        CustomerModel c = new CustomerModel();

                        c.CreatedBy = Convert.ToString(Session["AccountName"]);
                        c.FirstName = obj.FirstName;
                        c.LastName = obj.LastName;
                        c.PhoneNumber = obj.PhoneNumber;
                        c.CreatedDate = obj.CreatedDate;
                        c.Email = obj.Email;
                        var a = await irepo.AddCustomer(c);
                        obj.CustomerId = a;
                    }
                }
                var OrderItemModel = irepo.AddOrderItem(obj);
                return 1;
            }

        }

        public void customer(CustomerModel obj)
        {
            var CustomerAdd = irepo.AddCustomer(obj);
        }

        public async Task<JsonResult> CalculateTaxes(OrderItemModel obj)
        {
            TaxViewModel t = new TaxViewModel();
            t = await util.GetTaxAmt(obj);
            return Json(t, JsonRequestBehavior.AllowGet);
        }
    }
}