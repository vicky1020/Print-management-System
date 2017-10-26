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
        Task<OrderItemModel> GetOrderById(int orderId);
        Task<bool> AddOrder(OrderItemModel OrderItem);
        Task<bool> UpdateOrder(OrderItemModel OrderItem, int OrderId);

        Task<bool> deleteOrder(int OrderId);
        #endregion

        #region UserModel
        Task<List<UserModel>> GetAllUser();
        Task<bool> AddUser(UserModel User);
        Task<bool> UpdateUser(List<UserModel> User,int UserId);
        Task<bool> deleteUser(int UserId);
        #endregion
        #region UserRolesModel
        Task<List<UserSecurityQuestionModel>> GetSecurityQuestion();
        Task<List<UserRoleModel>> GetAllUserRole();
        Task<UserRoleModel> GetUserRoleById(int UserRoleId);
        #endregion
        #region ConfigurationModel
        Task<List<ConfigurationModel>> GetAllConfiguration();
        Task<bool> UpdateConfiguration(ConfigurationModel config,int ConfigurationId);
        Task<bool> AddConfiguration(OrderConfigurationModel model);

        Task<bool> DeleteConfiguration(int ConfigurationId);
        #endregion
        Task<List<ConfigurationTypeModel>> GetAllConfigurationType();
        Task<List<ItemDisplayConfigModel>> GetAllItemConfig(); 
        Task<List<JobProcessTypeModel>> GetAllJobProcessType();
        Task<List<LedgerFalioModel>> GetAllLedgerFolio();
        Task<List<OrderConfigurationModel>> GetAllOrderConfiguration();
        Task<List<PaperGSMModel>> GetAllPaperGSM(); 
        Task<List<PaperQualityModel>> GetAllPaperQuality();
        Task<List<PaperSideModel>> GetAllPaperSides();//not defined in mapper class
        Task<List<PaperSizeModel>> GetAllPaperSize();
        Task<List<PrintingColourModel>> GetAllPrintingColor();
        Task<List<ProductItemModel>> GetAllProductItem();//not defined in mapper class
        
      }

}
