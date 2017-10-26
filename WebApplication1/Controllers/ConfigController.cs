using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PrintManagement.Common.Repository;
using PrintManagement.Common.Interfaces;
using System.Web.Mvc;
using PrintManagementApp.Models;
using System.Threading.Tasks;

namespace PrintManagementApp.Controllers
{
    #region

    #endregion
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
            var irepo = new Repository();

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

        public async Task<ActionResult> AddConfig()
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
    }
}