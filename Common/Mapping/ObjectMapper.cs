using System;
using AutoMapper;
using EF;
using PrintManagement.Common.Models;

namespace PrintManagement.Common.Mapping
{
    public static class ObjectMapper
    {
        static ObjectMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Configuration, ConfigurationModel>();
                cfg.CreateMap<ConfigurationType, ConfigurationTypeModel>();
                cfg.CreateMap<Customer, CustomerModel>();
                cfg.CreateMap<ItemDisplayConfig, ItemDisplayConfigModel>();
                cfg.CreateMap<JobProcessType, JobProcessTypeModel>();
                cfg.CreateMap<LedgerFalio, LedgerFalioModel>();
                cfg.CreateMap<OrderItem, OrderItemModel>();
                cfg.CreateMap<OrderConfiguration, OrderConfigurationModel>();
                cfg.CreateMap<OrderItem, OrderItemModel>();
                cfg.CreateMap<PaperGSM, PaperGSMModel>();
                cfg.CreateMap<PaperQuality, PaperQualityModel>();
                cfg.CreateMap<PaperSize, PaperSizeModel>();
                cfg.CreateMap<PaperSide, PaperSideModel>();
                cfg.CreateMap<ProductItem, ProductItemModel>();
                cfg.CreateMap<PrintingColour, PrintingColourModel>();
                cfg.CreateMap<UserRole, UserRoleModel>();
                cfg.CreateMap<UserSecurityQuestion, UserSecurityQuestionModel>();
                cfg.CreateMap<User, UserModel>();
                cfg.CreateMap<ConfigurationModel, Configuration>();
                cfg.CreateMap<ConfigurationTypeModel, ConfigurationType>();
                cfg.CreateMap<CustomerModel, Customer>();
                cfg.CreateMap<ItemDisplayConfigModel, ItemDisplayConfig>();
                cfg.CreateMap<JobProcessTypeModel, JobProcessType>();
                cfg.CreateMap<LedgerFalioModel, LedgerFalio>();
                cfg.CreateMap<OrderItemModel, OrderItem>();
                cfg.CreateMap<OrderConfigurationModel, OrderConfiguration>();
                cfg.CreateMap<OrderItemModel, OrderItem>();
                cfg.CreateMap<PaperGSMModel, PaperGSM>();
                cfg.CreateMap<PaperQualityModel, PaperQuality>();
                cfg.CreateMap<PaperSizeModel, PaperSize>();
                cfg.CreateMap<PrintingColourModel, PrintingColour>();
                cfg.CreateMap<UserRoleModel, UserRole>();
                cfg.CreateMap<UserSecurityQuestionModel, UserSecurityQuestion>();
                cfg.CreateMap<UserModel, User>();
                cfg.CreateMap<PaperSideModel, PaperSide>();
                cfg.CreateMap<ProductItemModel, ProductItem>();
            });
        }
        #region Entity To Model Mapping
        public static ProductItemModel ToProductItemModel(this ProductItem product)
        {
            ProductItemModel productItem = Mapper.Map<ProductItem, ProductItemModel>(product);
            return productItem;
        }
        public static PaperSideModel ToPaperSideModel(this PaperSide PaperSide)
        {
            PaperSideModel PaperS = Mapper.Map<PaperSide, PaperSideModel>(PaperSide);
            return PaperS;
        }
        public static ConfigurationModel ToConfigurationModel(this Configuration item)
        {
            ConfigurationModel config = Mapper.Map<Configuration, ConfigurationModel>(item);
            return config;
        }

        public static ConfigurationTypeModel ToConfigurationTypeModel(this ConfigurationType item)
        {
            ConfigurationTypeModel configType = Mapper.Map<ConfigurationType, ConfigurationTypeModel>(item);
            return configType;
        }

        public static CustomerModel ToCustomerModel(this Customer item)
        {
            CustomerModel customer = Mapper.Map<Customer, CustomerModel>(item);
            return customer;
        }

        public static ItemDisplayConfigModel ToItemDisplayConfigTypeModel(this ItemDisplayConfig item)
        {
            ItemDisplayConfigModel itemDisplayConfig = Mapper.Map<ItemDisplayConfig, ItemDisplayConfigModel>(item);
            return itemDisplayConfig;
        }

        public static JobProcessTypeModel ToJobProcessTypeModel(this JobProcessType item)
        {
            JobProcessTypeModel jobDisplayType = Mapper.Map<JobProcessType, JobProcessTypeModel>(item);
            return jobDisplayType;
        }

        public static LedgerFalioModel ToLedgerFalioModel(this LedgerFalio item)
        {
            LedgerFalioModel ledgerFalio = Mapper.Map<LedgerFalio, LedgerFalioModel>(item);
            return ledgerFalio;
        }

        public static OrderConfigurationModel ToOrderConfigurationModel(this OrderConfiguration item)
        {
            OrderConfigurationModel orderConfiguration = Mapper.Map<OrderConfiguration, OrderConfigurationModel>(item);
            orderConfiguration.Amount = decimal.Round(orderConfiguration.Amount, 2, MidpointRounding.AwayFromZero);
            return orderConfiguration;
        }

        public static OrderItemModel ToOrderItemModel(this OrderItem item)
        {
            OrderItemModel orderItem = Mapper.Map<OrderItem, OrderItemModel>(item);
            orderItem.Amount = decimal.Round(orderItem.Amount, 2, MidpointRounding.AwayFromZero);
            return orderItem;
        }

        public static PaperGSMModel ToPaperGSMModel(this PaperGSM item)
        {
            PaperGSMModel paperGSM = Mapper.Map<PaperGSM, PaperGSMModel>(item);
            return paperGSM;
        }
        public static PaperQualityModel ToPaperQualityModel(this PaperQuality item)
        {
            PaperQualityModel paperQuality = Mapper.Map<PaperQuality, PaperQualityModel>(item);
            return paperQuality;
        }
        public static PaperSizeModel ToPaperSizeModel(this PaperSize item)
        {
            PaperSizeModel paperSize = Mapper.Map<PaperSize, PaperSizeModel>(item);
            return paperSize;
        }
        public static PrintingColourModel ToPrintingColorModel(this PrintingColour item)
        {
            PrintingColourModel printColor = Mapper.Map<PrintingColour, PrintingColourModel>(item);
            return printColor;
        }

        public static UserRoleModel ToUserRoleModel(this UserRole item)
        {
            UserRoleModel userRole = Mapper.Map<UserRole, UserRoleModel>(item);
            return userRole;
        }

        public static UserSecurityQuestionModel ToUserSecurityQuestionModel(this UserSecurityQuestion item)
        {
            UserSecurityQuestionModel userSecurityQuestion = Mapper.Map<UserSecurityQuestion, UserSecurityQuestionModel>(item);
            return userSecurityQuestion;
        }

        public static UserModel ToUserModel(this User item)
        {
            UserModel user = Mapper.Map<User, UserModel>(item);
            return user;
        }
        #endregion
        #region Model to Entity Mapping
        public static Configuration ToConfigurationEntity(this ConfigurationModel item)
        {
            Configuration config = Mapper.Map<ConfigurationModel, Configuration>(item);
            return config;
        }

        public static ConfigurationType ToConfigurationTypeEntity(this ConfigurationTypeModel item)
        {
            ConfigurationType configType = Mapper.Map<ConfigurationTypeModel, ConfigurationType>(item);
            return configType;
        }

        public static Customer ToCustomerEntity(this CustomerModel item)
        {
            Customer customer = Mapper.Map<CustomerModel, Customer>(item);
            customer.CreatedDate = DateTime.Now;
            return customer;
        }

        public static ItemDisplayConfig ToItemDisplayConfigTypeEntity(this ItemDisplayConfigModel item)
        {
            ItemDisplayConfig itemDisplayConfig = Mapper.Map<ItemDisplayConfigModel, ItemDisplayConfig>(item);
            return itemDisplayConfig;
        }

        public static JobProcessType ToJobProcessTypeEntity(this JobProcessTypeModel item)
        {
            JobProcessType jobDisplayType = Mapper.Map<JobProcessTypeModel, JobProcessType>(item);
            return jobDisplayType;
        }

        public static LedgerFalio ToLedgerFalioEntity(this LedgerFalioModel item)
        {
            LedgerFalio ledgerFalio = Mapper.Map<LedgerFalioModel, LedgerFalio>(item);
            return ledgerFalio;
        }

        public static OrderConfiguration ToOrderConfigurationEntity(this OrderConfigurationModel item)
        {
            OrderConfiguration orderConfiguration = Mapper.Map<OrderConfigurationModel, OrderConfiguration>(item);
            return orderConfiguration;
        }

        public static OrderItem ToOrderItemEntity(this OrderItemModel item)
        {
            OrderItem orderItem = Mapper.Map<OrderItemModel, OrderItem>(item);
            return orderItem;
        }

        public static OrderItem ToOrderItemEntityForUpdate(this OrderItemModel item)
        {
            OrderItem orderItem = Mapper.Map<OrderItemModel, OrderItem>(item);
            return orderItem;
        }

        public static PaperGSM ToPaperGSMEntity(this PaperGSMModel item)
        {
            PaperGSM paperGSM = Mapper.Map<PaperGSMModel, PaperGSM>(item);
            return paperGSM;
        }
        public static PaperQuality ToPaperQualityEntity(this PaperQualityModel item)
        {
            PaperQuality paperQuality = Mapper.Map<PaperQualityModel, PaperQuality>(item);
            return paperQuality;
        }
        public static PaperSize ToPaperSizeEntity(this PaperSizeModel item)
        {
            PaperSize paperSize = Mapper.Map<PaperSizeModel, PaperSize>(item);
            return paperSize;
        }
        public static PrintingColour ToPrintingColorEntity(this PrintingColourModel item)
        {
            PrintingColour printColor = Mapper.Map<PrintingColourModel, PrintingColour>(item);
            return printColor;
        }

        public static UserRole ToUserRoleEntity(this UserRoleModel item)
        {
            UserRole userRole = Mapper.Map<UserRoleModel, UserRole>(item);
            return userRole;
        }

        public static UserSecurityQuestion UserSecurityQuestionEntity(this UserSecurityQuestionModel item)
        {
            UserSecurityQuestion userSecurityQuestion = Mapper.Map<UserSecurityQuestionModel, UserSecurityQuestion>(item);
            return userSecurityQuestion;
        }

        public static User ToUserEntity(this UserModel item)
        {
            User user = Mapper.Map<UserModel, User>(item);
            return user;
        }
        public static ProductItem ToProductItemEntity(this ProductItemModel product)
        {
            ProductItem productItem = Mapper.Map<ProductItemModel, ProductItem>(product);
            return productItem;
        }
        public static PaperSide ToPaperSideEntity(this PaperSideModel PaperSide)
        {
            PaperSide PaperS = Mapper.Map<PaperSideModel, PaperSide>(PaperSide);
            return PaperS;
        }
        #endregion
    }
}
