using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PrintManagement.Common.Models;
using PrintManagement.Common.Repositories;
using Newtonsoft.Json;

namespace PrintManagementApp.Utilities
{
    public class ConfigViewDisplay
    {
        public List<OrderConfigurationValueModel> getConfigValues(List<OrderConfigurationModel> obj)
        {
            List<OrderConfigurationValueModel> configModel = new List<OrderConfigurationValueModel>();
            var irepo = new Repository();

            foreach (var item in obj)
            {
                OrderConfigurationValueModel configObj = new OrderConfigurationValueModel();
                configObj.OrderConfigurationId = item.OrderConfigurationId;
                configObj.ProductItemId = irepo.GetProductItemById(item.ProductItemId).Result.ItemName;
                configObj.PaperGSMId = item.PaperGSMId;
                configObj.PaperColourId = irepo.GetPrintingColourById(Convert.ToInt32(item.PaperColourId)).Result.PrintColourName;
                configObj.PaperSizeId = item.PaperSizeId;
                configObj.PaperQualityId = irepo.GetPaperQualityById(Convert.ToInt32(item.PaperQualityId)).Result.QualityName;
                configObj.PaperSidesId = irepo.GetPaperSideById(Convert.ToInt32(item.PaperSidesId)).Result.PaperSideName;
                configObj.LedgerFalioId = item.LedgerFalioId;
                configObj.AdditionalPaperCount = item.AdditionalPaperCount;
                configObj.AdditionalPaperSizeId = item.AdditionalPaperSizeId;
                configObj.AdditonalPaperGSMId = item.AdditonalPaperGSMId;
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