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

namespace PrintManagement.Common.Repositories
{
    public class Repository : IRepository
    {

        private readonly PrintManagementSystemEntities _entities;
        public Repository()
        {
            _entities = new PrintManagementSystemEntities();
        }

        #region MasterTable
        public async Task<List<ConfigurationModel>> GetAllConfiguration()
        {
            var config = await _entities.Configuration.ToListAsync();
            if (config.Count > 0)
                return config.Select(item => item.ToConfigurationModel()).ToList();
            return null;
        }
        public async Task<UserModel> Login(string email)
        {
            var config = await _entities.User.Where(i => i.EmailId == email).FirstOrDefaultAsync();
            return config?.ToUserModel();
        }

        public async Task<ConfigurationModel> GetConfigurationByName(string name)
        {
            var config = await _entities.Configuration.Where(i => i.ConfigurationName == name).FirstOrDefaultAsync();
            return config?.ToConfigurationModel();
        }

        public async Task<List<ConfigurationTypeModel>> GetAllConfigurationType()
        {
            var configType = await _entities.ConfigurationType.ToListAsync();
            if (configType.Count > 0)
                return configType.Select(item => item.ToConfigurationTypeModel()).ToList();
            return null;
        }

        public async Task<List<ItemDisplayConfigModel>> GetAllItemDisplayConfig()
        {
            var itemDisplayConfig = await _entities.ItemDisplayConfig.ToListAsync();
            if (itemDisplayConfig.Count > 0)
                return itemDisplayConfig.Select(item => item.ToItemDisplayConfigTypeModel()).ToList();
            return null;
        }

        public async Task<ItemDisplayConfigModel> GetAllItemDisplayConfigByProductItemId(int productItemId)
        {
            var itemDisplayConfig = await _entities.ItemDisplayConfig.Where(i => i.ProductItemId == productItemId).FirstOrDefaultAsync();
            return itemDisplayConfig?.ToItemDisplayConfigTypeModel();
        }

        public async Task<List<JobProcessTypeModel>> GetAllJobProcessType()
        {
            var jobProcess = await _entities.JobProcessType.ToListAsync();
            if (jobProcess.Count > 0)
                return jobProcess.Select(item => item.ToJobProcessTypeModel()).ToList();
            return null;
        }

        public async Task<JobProcessTypeModel> GetJobProcessTypeById(int id)
        {
            var jobProcess = await _entities.JobProcessType.Where(i => i.JobProcessTypeId == id).FirstOrDefaultAsync();
            return jobProcess?.ToJobProcessTypeModel();
        }

        public async Task<List<LedgerFalioModel>> GetAllLedgerFalio()
        {
            var ledgerFalio = await _entities.LedgerFalio.ToListAsync();
            if (ledgerFalio.Count > 0)
                return ledgerFalio.Select(item => item.ToLedgerFalioModel()).ToList();
            return null;
        }

        public async Task<LedgerFalioModel> GetLedgerFalioById(int id)
        {
            var ledgerFalio = await _entities.LedgerFalio.Where(i => i.LedgerFalioId == id).FirstOrDefaultAsync();
            return ledgerFalio?.ToLedgerFalioModel();
        }

        public async Task<List<PaperGSMModel>> GetAllPaperGSM()
        {
            var paperGSM = await _entities.PaperGSM.ToListAsync();
            if (paperGSM.Count > 0)
                return paperGSM.Select(item => item.ToPaperGSMModel()).ToList();
            return null;
        }

        public async Task<PaperGSMModel> GetPaperGSMById(int id)
        {
            var paperGSM = await _entities.PaperGSM.Where(i => i.PaperGSMId == id).FirstOrDefaultAsync();
            return paperGSM?.ToPaperGSMModel();
        }

        public async Task<List<PaperQualityModel>> GetAllPaperQuality()
        {
            var paperQuality = await _entities.PaperQuality.ToListAsync();
            if (paperQuality.Count > 0)
                return paperQuality.Select(item => item.ToPaperQualityModel()).ToList();
            return null;
        }

        public async Task<PaperQualityModel> GetPaperQualityById(int id)
        {
            var paperQuality = await _entities.PaperQuality.Where(i => i.PaperQualityId == id).FirstOrDefaultAsync();
            return paperQuality?.ToPaperQualityModel();
        }

        public async Task<List<PaperSideModel>> GetAllPaperSide()
        {
            var paperSide = await _entities.PaperSide.ToListAsync();
            if (paperSide.Count > 0)
                return paperSide.Select(item => item.ToPaperSideModel()).ToList();
            return null;
        }

        public async Task<PaperSideModel> GetPaperSideById(int id)
        {
            var paperSide = await _entities.PaperSide.Where(i => i.PaperSideId == id).FirstOrDefaultAsync();
            return paperSide?.ToPaperSideModel();
        }

        public async Task<List<PaperSizeModel>> GetAllPaperSize()
        {
            var paperSize = await _entities.PaperSize.ToListAsync();
            if (paperSize.Count > 0)
                return paperSize.Select(item => item.ToPaperSizeModel()).ToList();
            return null;
        }

        public async Task<PaperSizeModel> GetPaperSizeById(int id)
        {
            var paperSize = await _entities.PaperSize.Where(i => i.PaperSizeId == id).FirstOrDefaultAsync();
            return paperSize?.ToPaperSizeModel();
        }

        public async Task<List<PrintingColourModel>> GetAllPrintingColour()
        {
            var printColour = await _entities.PrintingColour.ToListAsync();
            if (printColour.Count > 0)
                return printColour.Select(item => item.ToPrintingColorModel()).ToList();
            return null;
        }

        public async Task<PrintingColourModel> GetPrintingColourById(int id)
        {
            var printColour = await _entities.PrintingColour.Where(i => i.PrintingColourId == id).FirstOrDefaultAsync();
            return printColour?.ToPrintingColorModel();
        }

        public async Task<List<ProductItemModel>> GetAllProductItem()
        {
            var productItem = await _entities.ProductItem.ToListAsync();
            if (productItem.Count > 0)
                return productItem.Select(item => item.ToProductItemModel()).ToList();
            return null;
        }

        public async Task<ProductItemModel> GetProductItemById(int id)
        {
            var productItem = await _entities.ProductItem.Where(i => i.ProductId == id).FirstOrDefaultAsync();
            return productItem?.ToProductItemModel();
        }

        public async Task<List<UserRoleModel>> GetAllUserRole()
        {
            var userRole = await _entities.UserRole.ToListAsync();
            if (userRole.Count > 0)
                return userRole.Select(item => item.ToUserRoleModel()).ToList();
            return null;
        }

        public async Task<UserRoleModel> GetUserRoleById(int id)
        {
            var userRole = await _entities.UserRole.Where(i => i.UserRolesId == id).FirstOrDefaultAsync();
            return userRole?.ToUserRoleModel();
        }

        public async Task<List<UserSecurityQuestionModel>> GetAllUserSecurityQuestion()
        {
            var securityQuestion = await _entities.UserSecurityQuestion.ToListAsync();
            if (securityQuestion.Count > 0)
                return securityQuestion.Select(item => item.ToUserSecurityQuestionModel()).ToList();
            return null;
        }

        public async Task<UserSecurityQuestionModel> GetUserSecurityQuestionById(int id)
        {
            var securityQuestion = await _entities.UserSecurityQuestion.Where(i => i.UserSecurityQuestionId == id).FirstOrDefaultAsync();
            return securityQuestion?.ToUserSecurityQuestionModel();
        }
        #endregion


        #region ItemOrder
        public async Task<List<OrderItemModel>> GetAllOrderItem()
        {
            var allOrders = await _entities.OrderItem.ToListAsync();
            if (allOrders.Count > 0)
                return allOrders.Select(item => item.ToOrderItemModel()).ToList();
            return new List<OrderItemModel>();
        }
        public async Task<OrderItemModel> GetOrderItemById(int OrderId)
        {
            var order = await _entities.OrderItem.Where(i => i.OrderId == OrderId).FirstOrDefaultAsync();
            return order?.ToOrderItemModel();
        }
        public async Task<bool> AddOrderItem(OrderItemModel orderItem)
        {
            var a = _entities.OrderItem.Add(orderItem.ToOrderItemEntity());
            await _entities.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateOrderItem(OrderItemModel orderItem, int orderId)
        {
            OrderItem orderItems = _entities.OrderItem.Where(x => x.OrderId == orderId).FirstOrDefault();
            if (orderItems != null)
            {
                orderItem.ToOrderItemEntity();
                orderItem.OrderId = orderId;
                _entities.Entry(orderItem).State = EntityState.Modified;
                await _entities.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> DeleteOrderItem(int orderId)
        {
            var order = _entities.OrderItem.Where(x => x.OrderId == orderId).FirstOrDefault();
            if (order != null)
            {
                _entities.OrderItem.Remove(order);
                _entities.Entry(order).State = EntityState.Deleted;
                await _entities.SaveChangesAsync();
            }
            return true;
        }
        #endregion

        #region UserModel
        public async Task<List<UserModel>> GetAllUser()
        {
            var allUsers = await _entities.User.ToListAsync();
            if (allUsers.Count > 0)
                return allUsers.Select(item => item.ToUserModel()).ToList();
            return null;
        }
        public async Task<UserModel> GetUserById(int userId)
        {
            var user = await _entities.User.Where(i => i.UserId == userId).FirstOrDefaultAsync();
            return user?.ToUserModel();
        }
        public async Task<bool> AddUser(UserModel user)
        {
            var a = _entities.User.Add(user.ToUserEntity());
            await _entities.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateUser(UserModel user, int userId)
        {
            User users = _entities.User.Where(x => x.UserId == userId).FirstOrDefault();
            if (users != null)
            {
                user.ToUserEntity();
                user.UserId = userId;
                _entities.Entry(user).State = EntityState.Modified;
                await _entities.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> DeleteUser(int userId)
        {
            var user = _entities.User.Where(x => x.UserId == userId).FirstOrDefault();
            if (user != null)
            {
                _entities.User.Remove(user);
                _entities.Entry(user).State = EntityState.Deleted;
                await _entities.SaveChangesAsync();
            }
            return true;
        }
        #endregion

        #region CustomerModel
        public async Task<List<CustomerModel>> GetAllCustomer()
        {
            var allCustomer = await _entities.Customer.ToListAsync();
            if (allCustomer.Count > 0)
                return allCustomer.Select(item => item.ToCustomerModel()).ToList();
            return null;
        }
        public async Task<CustomerModel> GetCustomerById(int customerId)
        {
            var customer = await _entities.Customer.Where(i => i.CustomerId == customerId).FirstOrDefaultAsync();
            return customer?.ToCustomerModel();
        }
        public async Task<bool> AddCustomer(CustomerModel cust)
        {
            var customer = _entities.Customer.Add(cust.ToCustomerEntity());
            await _entities.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateCustomer(CustomerModel cust, int customerId)
        {
            Customer customer = _entities.Customer.Where(x => x.CustomerId == customerId).FirstOrDefault();
            if (customer != null)
            {
                cust.ToCustomerEntity();
                cust.CustomerId = customerId;
                _entities.Entry(cust).State = EntityState.Modified;
                await _entities.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> DeleteCustomer(int customerId)
        {
            Customer customer = _entities.Customer.Where(x => x.CustomerId == customerId).FirstOrDefault();
            if (customer != null)
            {
                _entities.Customer.Remove(customer);
                _entities.Entry(customer).State = EntityState.Deleted;
                await _entities.SaveChangesAsync();
            }
            return true;
        }
        #endregion

        #region OrderConfiguration
        public async Task<List<OrderConfigurationModel>> GetAllOrderConfiguration()
        {
            var allOrderConfig = await _entities.OrderConfiguration.ToListAsync();
            if (allOrderConfig.Count > 0)
                return allOrderConfig.Select(item => item.ToOrderConfigurationModel()).ToList();
            return new List<OrderConfigurationModel>();
        }
        public async Task<OrderConfigurationModel> GetOrderConfigurationById(int orderCofigId)
        {
            var orderConfig = await _entities.OrderConfiguration.Where(i => i.OrderConfigurationId == orderCofigId).FirstOrDefaultAsync();
            return orderConfig?.ToOrderConfigurationModel();
        }
        public async Task<bool> AddOrderConfiguration(OrderConfigurationModel orderConfig)
        {
            var orderConfiguration = _entities.OrderConfiguration.Add(orderConfig.ToOrderConfigurationEntity());
            await _entities.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateOrderConfiguration(OrderConfigurationModel orderConfig, int orderCofigId)
        {
            OrderConfiguration orderConfiguration = _entities.OrderConfiguration.Where(x => x.OrderConfigurationId == orderCofigId).FirstOrDefault();
            if (orderConfiguration != null)
            {
                orderConfig.ToOrderConfigurationEntity();
                orderConfig.OrderConfigurationId = orderCofigId;
                _entities.Entry(orderConfig).State = EntityState.Modified;
                await _entities.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> DeleteOrderConfiguration(int orderCofigId)
        {
            OrderConfiguration orderConfiguration = _entities.OrderConfiguration.Where(x => x.OrderConfigurationId == orderCofigId).FirstOrDefault();
            if (orderConfiguration != null)
            {
                _entities.OrderConfiguration.Remove(orderConfiguration);
                _entities.Entry(orderConfiguration).State = EntityState.Deleted;
                await _entities.SaveChangesAsync();
            }
            return true;
        }
        #endregion
    }
}
