using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF;
using PrintManagement.Common.Models;

namespace PrintManagement.Common.Mapping
{
    public static class Mapper
    {
        #region Entity To Model Mapping
        
       
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
            return new OrderItemModel
            {
                OrderId = item.OrderId,
                Active = item.Active,
                AdditionalPaperCount = item.AdditionalPaperCount,
                AdditionalPaperSize = item.AdditionalPaperSize,
                AdditonalPaperGSM = item.AdditonalPaperGSM,
                Amount=item.Amount,
                CreatedBy=item.CreatedBy,
                CreatedDate=item.CreatedDate,
               JobStatus=item.JobStatus,
               LedgerFalio=item.LedgerFalio,
               PaperColor=item.PaperColor,
               PaperGSM=item.PaperGSM,
               PaperQuality=item.PaperQuality,
               PaperSides=item.PaperSides,
               PaperSize=item.PaperSize,
               ProductItemId=item.ProductItemId,
              Quantity=item.Quantity  
            };
        }
        #endregion

        #region Model to Entity Mapping


        #endregion

        #region Private Methods

        #endregion
    }
}
