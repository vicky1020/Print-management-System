using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrintManagement.Common.Repositories;
using System.Threading.Tasks;

namespace PMSRepoTest
{
    [TestClass]
    public class RepoTestCase
    {

        //Test Case for all GET Methods
        [TestMethod]
        public async Task GetAllPaperQualityTest()
        {
            var irepo = new Repository();
            var result = (await irepo.GetAllPaperQuality());

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result[2].PaperQualityId);
            Assert.AreEqual("Ledger", result[9].QualityName);
        }

        [TestMethod]
        public async Task GetAllConfigurationTypeTest()
        {
            var irepo = new Repository();
            var result = (await irepo.GetAllConfigurationType());

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result[0].ConfigurationTypeId);
            Assert.AreEqual("Taxes", result[0].ConfigurationName);
        }

        [TestMethod]
        public async Task GetAllConfigurationTest()
        {
            var irepo = new Repository();
            var result = (await irepo.GetAllConfiguration());

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(3, result[0].ConfigurationId);
            Assert.AreEqual(3, result[0].ConfigurationTypeId);
            Assert.AreEqual("CGST", result[0].ConfigurationName);
            Assert.AreEqual("8", result[0].ConfigurationValue);
        }

        [TestMethod]
        public async Task LoginTest()
        {
            var irepo = new Repository();
            String EmailTest = "admin@gmail.com";
            var result = (await irepo.Login(EmailTest));

            Assert.IsNotNull(result);
            Assert.AreEqual("Admin", result.FirstName);
            Assert.AreEqual("Admin", result.LastName);
            Assert.AreEqual(1, result.UserId);
            Assert.AreEqual(1, result.RoleId);
            Assert.AreEqual("admin@gmail.com", result.EmailId);
        }

        [TestMethod]
        public async Task GetConfigurationByNameTest()
        {
            var irepo = new Repository();
            String ConfigNameTest = "SGST";
            var result = (await irepo.GetConfigurationByName(ConfigNameTest));

            Assert.IsNotNull(result);
            Assert.AreEqual(10, result.ConfigurationId);
            Assert.AreEqual(3, result.ConfigurationTypeId);
            Assert.AreEqual("SGST", result.ConfigurationName);
            Assert.AreEqual("8", result.ConfigurationValue);
        }

        [TestMethod]
        public async Task GetAllItemDisplayConfigTest()
        {
            var irepo = new Repository();
            var result = (await irepo.GetAllItemDisplayConfig());

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetAllItemDisplayConfigByProductItemIdTest()
        {
            var irepo = new Repository();
            int ProductItemIdTest = 1;
            var result = (await irepo.GetAllItemDisplayConfigByProductItemId(ProductItemIdTest));

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetAllJobProcessTypeTest()
        {
            var irepo = new Repository();
            var result = (await irepo.GetAllJobProcessType());

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetJobProcessTypeByIdTest()
        {
            var irepo = new Repository();
            int ProductProcessIdTest = 1;
            var result = (await irepo.GetJobProcessTypeById(ProductProcessIdTest));

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetAllLedgerFalioTest()
        {
            var irepo = new Repository();
            var result = (await irepo.GetAllLedgerFalio());

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetLedgerFalioByIdTest()
        {
            var irepo = new Repository();
            int LedgerFalioIdTest = 1;
            var result = (await irepo.GetLedgerFalioById(LedgerFalioIdTest));

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetAllPaperGSMTest()
        {
            var irepo = new Repository();
            var result = (await irepo.GetAllPaperGSM());

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetPaperGSMByIdTest()
        {
            var irepo = new Repository();
            int PaperGSMId = 1;
            var result = (await irepo.GetPaperGSMById(PaperGSMId));

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetPaperQualityByIdTest()
        {
            var irepo = new Repository();
            int PaperQtyId = 1;
            var result = (await irepo.GetPaperQualityById(PaperQtyId));

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetAllPaperSideTest()
        {
            var irepo = new Repository();
            var result = (await irepo.GetAllPaperSide());

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetPaperSideByIdTest()
        {
            var irepo = new Repository();
            int PaperSideId = 1;
            var result = (await irepo.GetPaperSideById(PaperSideId));

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetUserSecurityQuestionByIdTest()
        {
            var irepo = new Repository();
            int SecurityQuestionId = 1;
            var result = (await irepo.GetUserSecurityQuestionById(SecurityQuestionId));

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetAllUserSecurityQuestionTest()
        {
            var irepo = new Repository();
            var result = (await irepo.GetAllUserSecurityQuestion());

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetUserRoleByIdTest()
        {
            var irepo = new Repository();
            int UserRoleId = 1;
            var result = (await irepo.GetUserRoleById(UserRoleId));

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetAllUserRoleTest()
        {
            var irepo = new Repository();
            var result = (await irepo.GetAllUserRole());

            Assert.IsNotNull(result);
        }
         

           [TestMethod]
        public async Task GetProductItemByIdTest()
        {
            var irepo = new Repository();
            int ProductItemId = 1;
            var result = (await irepo.GetUserRoleById(ProductItemId));

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetAllProductItemTest()
        {
            var irepo = new Repository();
            var result = (await irepo.GetAllProductItem());

            Assert.IsNotNull(result);
        }
         

               [TestMethod]
        public async Task GetPrintingColourByIdTest()
        {
            var irepo = new Repository();
            int PrintingColourId = 1;
            var result = (await irepo.GetPrintingColourById(PrintingColourId));

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetAllPrintingColourTest()
        {
            var irepo = new Repository();
            var result = (await irepo.GetAllPrintingColour());

            Assert.IsNotNull(result);
        }

         

                  [TestMethod]
        public async Task GetPaperSizeByIdTest()
        {
            var irepo = new Repository();
            int PaperSizeId = 1;
            var result = (await irepo.GetPaperSizeById(PaperSizeId));

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetAllPaperSizeTest()
        {
            var irepo = new Repository();
            var result = (await irepo.GetAllPaperSize());

            Assert.IsNotNull(result);
        }









    }
}
