using System.Web.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrintManagementApp.Controllers;
using PrintManagement.Common.Models;

namespace PrintManagement.Tests
{
    [TestClass]
    public class ConfigControllerTest
    {
        [TestMethod]
        public async Task IndexViewTest()
        {
            var controller = new ConfigController();
            var result = await controller.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public async Task AddConfigTest()
        {
            var controller = new ConfigController();
            var result = await controller.AddConfig() as ViewResult;
            Assert.AreEqual("AddConfig", result.ViewName);
        }

        [TestMethod]
        public async Task UpdateConfigTest()
        {
            var controller = new ConfigController();
            var result = await controller.UpdateConfig() as ViewResult;
            Assert.AreEqual("AddConfig", result.ViewName);
        }
    }
}
