using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PrintManagement.Common.Models;
using PrintManagement.Common.Repositories;
using PrintManagementApp.Models;
using System.Threading.Tasks;

namespace PrintManagementApp.Utilities
{
    public class ConfigViewDisplay
    {
        public async Task<List<OrderConfigurationValueModel>> getConfigValues(List<OrderConfigurationModel> obj)
        {
            List<OrderConfigurationValueModel> configModel = new List<OrderConfigurationValueModel>();
            var irepo = new Repository();

            foreach (var item in obj)
            {
                OrderConfigurationValueModel configObj = new OrderConfigurationValueModel();
                configObj.OrderConfigurationId = item.OrderConfigurationId;

                var pIdVal = (await irepo.GetProductItemById(Convert.ToInt32(item.ProductItemId)));
                configObj.ProductItemId = (pIdVal != null) ? pIdVal.ItemName : null;

                var GSMIdVal = (await irepo.GetPaperGSMById(Convert.ToInt32(item.PaperGSMId)));
                configObj.PaperGSMId = (GSMIdVal != null) ? GSMIdVal.PaperGSMVal : 0;

                var clrIdVal = (await irepo.GetPrintingColourById(Convert.ToInt32(item.PaperColourId)));
                configObj.PaperColourId = (clrIdVal != null) ? clrIdVal.PrintColourName : null;

                var sizeIdVal = (await irepo.GetPaperSizeById(Convert.ToInt32(item.PaperSizeId)));
                configObj.PaperSizeId = (sizeIdVal != null) ? sizeIdVal.PaperSize1 : null;

                var qlyIdVal = (await irepo.GetPaperQualityById(Convert.ToInt32(item.PaperQualityId)));
                configObj.PaperQualityId = (qlyIdVal != null) ? qlyIdVal.QualityName : null;

                var sideIdVal = (await irepo.GetPaperSideById(Convert.ToInt32(item.PaperSidesId)));
                configObj.PaperSidesId = (sideIdVal != null) ? sideIdVal.PaperSideName : null;

                var lfIdVal = (await irepo.GetLedgerFalioById(Convert.ToInt32(item.LedgerFalioId)));
                configObj.LedgerFalioId = (lfIdVal != null) ? lfIdVal.LedgerFalioValue : 0;

                configObj.AdditionalPaperCount = item.AdditionalPaperCount;

                var adSizeIdVal = (await irepo.GetPaperSizeById(Convert.ToInt32(item.AdditionalPaperSizeId)));
                configObj.AdditionalPaperSizeId = (adSizeIdVal != null) ? adSizeIdVal.PaperSize1 : null;

                var adGSMIdVal = (await irepo.GetPaperGSMById(Convert.ToInt32(item.AdditonalPaperGSMId)));
                configObj.AdditonalPaperGSMId = (adGSMIdVal != null) ? adGSMIdVal.PaperGSMVal : 0;
                
                configObj.MinRange = item.MinRange;
                configObj.MaxRange = item.MaxRange;
                configObj.Amount = item.Amount;
                configObj.CreatedBy = item.CreatedBy;
                configObj.CreatedDate = item.CreatedDate;
                configModel.Add(configObj);
            }
            return configModel.ToList();
        }
    }
}