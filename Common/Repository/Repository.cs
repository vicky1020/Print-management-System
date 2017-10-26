using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrintManagement.Common.Models;
using EF;
using System.Data.Entity;
using PrintManagement.Common.Mapping;
using PrintManagement.Common.Interfaces;

namespace PrintManagement.Common.Repository
{
    public class Repository : IRepository
    {

        private readonly PrintManagementSystemEntities PMSE;
        public Repository()
        {
            PMSE = new PrintManagementSystemEntities();
        }

        #region Orders
        public async Task<List<OrderItemModel>> GetAllOrder()
        {
            var AllOrderList = await PMSE.OrderItems.ToListAsync();
            if (AllOrderList.Count > 0)
            {
                return AllOrderList.Select(item => item.ToOrderItemModel()).ToList();
            }
            return null;
        }
        public async Task<OrderItemModel> GetOrderById(int OrderId)
        {
            var AllOrderList = await PMSE.OrderItems.ToListAsync();

            var AllOrderList1 = await PMSE.OrderItems.Where(i => i.OrderId == OrderId).FirstOrDefaultAsync();
            return AllOrderList1?.ToOrderItemModel();
        }
        public async Task<bool> AddOrder(OrderItemModel orderItem)
        {
            var a = PMSE.OrderItems.Add(orderItem.ToOrderItemEntity());
            await PMSE.SaveChangesAsync();

            return true;
        }
        public async Task<bool> UpdateOrder(OrderItemModel orderItem, int OrderId)
        {
            var a = (from s in PMSE.OrderItems
                     where s.OrderId == OrderId
                     select s).FirstOrDefaultAsync();
            var aa = PMSE.OrderItems.Select(x => x.OrderId == OrderId).FirstOrDefaultAsync();
            
            
            await PMSE.SaveChangesAsync();
            return true;
        }


        #endregion
        #region Configurations
    
        public async Task<List<OrderConfigurationModel>> GetAllOrderConfiguration()
        {

            var AllOrderConfiguration = await PMSE.OrderConfigurations.ToListAsync();
            if (AllOrderConfiguration.Count > 0)
            {
                return AllOrderConfiguration.Select(item => item.ToOrderConfigurationModel()).ToList();
            }
            return null;
        }

        #endregion
        public async Task<List<ItemDisplayConfigModel>> GetAllItemConfig()
        {

            var AllItemConfig = await PMSE.ItemDisplayConfigs.ToListAsync();
            if (AllItemConfig.Count > 0)
            {
                return AllItemConfig.Select(item => item.ToItemDisplayConfigTypeModel()).ToList();
            }
            return null;
        }

        public async Task<List<UserSecurityQuestionModel>> GetSecurityQuestion()
        {

            var SecurityQuestion = await PMSE.UserSecurityQuestions.ToListAsync();
            if (SecurityQuestion.Count > 0)
            {
                return SecurityQuestion.Select(item => item.UserSecurityQuestionModelModel()).ToList();
            }
            return null;
        }
        public async Task<List<UserRoleModel>> GetAllUserRoles()
        {

            var UserRoles = await PMSE.UserRoles.ToListAsync();
            if (UserRoles.Count > 0)
            {
                return UserRoles.Select(item => item.ToUserRoleModel()).ToList();
            }
            return null;
        }
    
    public async Task<UserRoleModel> GetUserRoleById(int UserRoleId)
    {   var AllOrderList1 = await PMSE.UserRoles.Where(i => i.UserRolesId == UserRoleId).FirstOrDefaultAsync();
        return AllOrderList1?.ToUserRoleModel();

    }
        public async Task<List<ConfigurationTypeModel>> GetAllConfigurationType()
        {
            var AllConfigurationType = await PMSE.ConfigurationTypes.ToListAsync();
            if (AllConfigurationType.Count > 0)
            {
                return AllConfigurationType.Select(item => item.ToConfigurationTypeModel()).ToList();
            }
            return null;
        }
        public async Task<List<JobProcessTypeModel>> GetAllJobProcessType()
        {
            var AllJobProcess = await PMSE.JobProcessTypes.ToListAsync();
            if (AllJobProcess.Count > 0)
            {
                return AllJobProcess.Select(item => item.ToJobProcessTypeModel()).ToList();
            }
            return null;
        }
        public async Task<List<LedgerFalioModel>> GetAllLedgerFolio()
        {
            var GetAllLedgerFolio = await PMSE.LedgerFalios.ToListAsync();
            if (GetAllLedgerFolio.Count > 0)
            {
                return GetAllLedgerFolio.Select(item => item.ToLedgerFalioModel()).ToList();
            }
            return null;
        }
        public async Task<List<PaperQualityModel>> GetAllPaperQuality()
        {
            var PaperQuality = await PMSE.PaperQualities.ToListAsync();
            if (PaperQuality.Count > 0)
            {
                return PaperQuality.Select(item => item.ToPaperQualityModel()).ToList();
            }
            return null;
        }

        public async Task<List<PaperGSMModel>> GetAllPaperGSM()
        {
            var PaperGSM = await PMSE.PaperGSMs.ToListAsync();
            if (PaperGSM.Count > 0)
            {
                return PaperGSM.Select(item => item.ToPaperGSMModel()).ToList();
            }
            return null;
        }
        public async Task<List<PaperSizeModel>> GetAllPaperSize()
        {
            var PaperSizes = await PMSE.PaperSizes.ToListAsync();
            if (PaperSizes.Count > 0)
            {
                return PaperSizes.Select(item => item.ToPaperSizeModel()).ToList();
            }
            return null;
        }
        public async Task<List<PrintingColourModel>> GetAllPrintingColor()
        {
            var printerColor = await PMSE.PrintingColours.ToListAsync();
            if (printerColor.Count > 0)
            {
                return printerColor.Select(item => item.ToPrintingColorModel()).ToList();
            }
            return null;
        }
        public async Task<List<ProductItemModel>> GetAllProduction()
        {
            var Production = await PMSE.ProductItems.ToListAsync();
            if (Production.Count > 0)
            {
                return Production.Select(item => item.ToProductItemModel()).ToList();
            }
            return null;
        }
        public async Task<List<PaperSideModel>> GetAllPaperSides()
        {
            var PaperSide = await PMSE.PaperSides.ToListAsync();
            if (PaperSide.Count > 0)
            {
                return PaperSide.Select(item => item.ToPaperSideModel()).ToList();
            }
            return null;
        }
        public async Task<List<UserModel>> GetAllUser()
        {
            var PaperSide = await PMSE.Users.ToListAsync();
            if (PaperSide.Count > 0)
            {
                return PaperSide.Select(item => item.ToUserModel()).ToList();
            }
            return null;
        }
        public async Task<List<ConfigurationModel>> GetAllConfiguration()
        {
            var config = await PMSE.Configurations.ToListAsync();
            if (config.Count > 0)
            {
                return config.Select(item => item.ToConfigurationModel()).ToList();
            }
            return null;
        }
        public async Task<bool> AddConfiguration(OrderConfigurationModel model)
        {
            var a = PMSE.OrderConfigurations.Add(model.ToOrderConfigurationEntity());
            await PMSE.SaveChangesAsync();
            return true;
        }
        public async Task<bool> AddUser(UserModel User)
        {
            var a = PMSE.Users.Add(User.ToUserEntity());
            await PMSE.SaveChangesAsync();
            return true;
        }

        public Task<bool> deleteOrder(int OrderId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUser(List<UserModel> User, int UserId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> deleteUser(int UserId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateConfiguration(ConfigurationModel config, int ConfigurationId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteConfiguration(int ConfigurationId)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserRoleModel>> GetAllUserRole()
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductItemModel>> GetAllProductItem()
        {
            throw new NotImplementedException();
        }
    }
}
