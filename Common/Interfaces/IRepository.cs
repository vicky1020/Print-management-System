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
        #region MasterTable
        Task<List<ConfigurationModel>> GetAllConfiguration();
        Task<ConfigurationModel> GetConfigurationByName(string name);
        Task<List<ConfigurationTypeModel>> GetAllConfigurationType();
        Task<List<ItemDisplayConfigModel>> GetAllItemDisplayConfig();
        Task<ItemDisplayConfigModel> GetAllItemDisplayConfigByProductItemId(int productItemId);
        Task<List<JobProcessTypeModel>> GetAllJobProcessType();
        Task<JobProcessTypeModel> GetJobProcessTypeById(int id);
        Task<List<LedgerFalioModel>> GetAllLedgerFalio();
        Task<LedgerFalioModel> GetLedgerFalioById(int id);
        Task<List<PaperGSMModel>> GetAllPaperGSM();
        Task<PaperGSMModel> GetPaperGSMById(int id);
        Task<List<PaperQualityModel>> GetAllPaperQuality();
        Task<PaperQualityModel> GetPaperQualityById(int id);
        Task<List<PaperSideModel>> GetAllPaperSide();
        Task<PaperSideModel> GetPaperSideById(int id);
        Task<List<PaperSizeModel>> GetAllPaperSize();
        Task<PaperSizeModel> GetPaperSizeById(int id);
        Task<List<PrintingColourModel>> GetAllPrintingColour();
        Task<PrintingColourModel> GetPrintingColourById(int id);
        Task<List<ProductItemModel>> GetAllProductItem();
        Task<ProductItemModel> GetProductItemById(int id);
        Task<List<UserRoleModel>> GetAllUserRole();
        Task<UserRoleModel> GetUserRoleById(int id);
        Task<List<UserSecurityQuestionModel>> GetAllUserSecurityQuestion();
        Task<UserSecurityQuestionModel> GetUserSecurityQuestionById(int id);
        #endregion

        #region ItemOrder
        Task<List<OrderItemModel>> GetAllOrderItem();
        Task<OrderItemModel> GetOrderItemById(int orderId);
        Task<bool> AddOrderItem(OrderItemModel OrderItem);
        Task<bool> UpdateOrderItem(OrderItemModel OrderItem, int OrderId);
        Task<bool> DeleteOrderItem(int OrderId);
        #endregion

        #region UserModel
        Task<UserModel> Login(string email);
        Task<List<UserModel>> GetAllUser();
        Task<UserModel> GetUserById(int userId);
        Task<bool> AddUser(UserModel User);
        Task<bool> UpdateUser(UserModel User,int UserId);
        Task<bool> DeleteUser(int UserId);
        #endregion

        #region CustomerModel
        Task<List<CustomerModel>> GetAllCustomer();
        Task<CustomerModel> GetCustomerById(int customerId);
        Task<bool> AddCustomer(CustomerModel cust);
        Task<bool> UpdateCustomer(CustomerModel User, int UserId);
        Task<bool> DeleteCustomer(int UserId);
        #endregion

        #region OrderConfiguration
        Task<List<OrderConfigurationModel>> GetAllOrderConfiguration();
        Task<OrderConfigurationModel> GetOrderConfigurationById(int orderId);
        Task<bool> AddOrderConfiguration(OrderConfigurationModel OrderItem);
        Task<bool> UpdateOrderConfiguration(OrderConfigurationModel OrderItem, int OrderId);
        Task<bool> DeleteOrderConfiguration(int OrderId);
        #endregion
    }
}