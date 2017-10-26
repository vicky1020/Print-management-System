using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF;
using PrintManagement.Common.Models;
using AutoMapper;

namespace PrintManagement.Common.Mapping
{
    public static class Mapping
    {
        #region Entity To Model Mapping
        static Mapping()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<OrderItem, OrderItemModel>();

            });
        }
       
        public static UsersModel ToUserModel(this User user)
        {
            return new UsersModel
            {
                UserName = user.UserName,
                Password = user.Password
            };
        }
        public static OrderItemModel ToOrderModel(this OrderItem item)
        {
            OrderItemModel customerViewItem =
              Mapper.Map<OrderItem, OrderItemModel>(item);
            return customerViewItem;
        }
        #endregion

        #region Model to Entity Mapping


        #endregion
    }
}
