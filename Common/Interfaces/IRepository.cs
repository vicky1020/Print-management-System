using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrintManagement.Common.Models;

namespace PrintManagement.Common.Interfaces
{
  public interface IRepository
    {
        #region Orders
        Task<List<OrderItemModel>> GetAllOrder();
        Task<List<OrderItemModel>> GetOrderById(int orderId);
        Task<bool> AddOrder(List<OrderItemModel> OrderItem);
        Task<bool> UpdateOrder(List<OrderItemModel> OrderItem, int OrderId);

        Task<bool> deleteOrder(int OrderId);
        #endregion

        #region UserModel
        Task<List<UserModel>> GetAllUser();
        Task<bool> AddUser(List<UserModel> User);
        Task<bool> UpdateUser(List<UserModel> User,int UserId);
        Task<bool> deleteUser(int UserId);
        #endregion
        #region UserRolesModel
        Task<List<UserSecurityQuestionModel>> GetSecurityQuestion();
        Task<List<UserRoleModel>> GetAllUserRoles();
        Task<List<UserRoleModel>> GetUserRoleById(int UserRoleId);
        #endregion
        #region ConfigurationModel
        Task<List<ConfigurationModel>> GetAllConfiguration();
        Task<bool> UpdateConfiguration(ConfigurationModel config,int ConfigurationId);
        Task<bool> Add(ConfigurationModel model);

        Task<bool> DeleteConfiguration(int ConfigurationId);
        #endregion
        Task<List<ConfigurationTypeModel>> GetAllConfigurationType();
        Task<List<ItemDisplayConfigModel>> GetAllItemConfig();
        Task<List<JobProcessTypeModel>> GetAllJobProcessType();
        Task<List<LedgerFalioModel>> GetAllLedgerFolio();
        Task<List<OrderConfigurationModel>> GetAllOrderConfiguration();
        Task<List<PaperGSMModel>> GetAllPaperGSM();
        Task<List<PaperQualityModel>> GetAllPaperQuality();
        Task<List<PaperSideModel>> GetAllPaperSides();
        Task<List<PaperSizeModel>> GetAllPaperSize();
        Task<List<PrintingColourModel>> GetAllPrintingColor();
        Task<List<ProductItemModel>> GetAllProduction();
        
      }

}
