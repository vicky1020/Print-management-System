using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PrintManagement.Common.Models;
using PrintManagement.Common.Repositories;
using Newtonsoft.Json;
using System.Threading.Tasks;
using PrintManagementApp.Models;


namespace PrintManagementApp.Utilities
{
    public class Utility
    {
        private readonly Repository irepo;
        public Utility()
        {
            irepo = new Repository();
        }
        public async Task<TaxViewModel> GetTaxAmt(OrderItemModel obj)
        {
            if (obj.Amount != 0)
            {
                return await CalculateTax(obj.Amount);
            }
            else
            {
                return await GetAmountFromConfig(obj);
            }
        }

        public async Task<TaxViewModel> CalculateTax(decimal amt)
        {
            TaxViewModel t = new TaxViewModel();
            var CGSTVal = Convert.ToDecimal((await irepo.GetConfigurationByName("CGST")).ConfigurationValue);
            var SGSTVal = Convert.ToDecimal((await irepo.GetConfigurationByName("SGST")).ConfigurationValue);
            t.Amount = amt;
            t.CGSTAmt = ((amt * CGSTVal) / 100);
            t.SGSTAmt = ((amt * SGSTVal) / 100);
            t.GrossBillAmount = t.Amount + t.CGSTAmt + t.CGSTAmt;
            return t;
        }

        public async Task<TaxViewModel> GetAmountFromConfig(OrderItemModel obj)
        {
            TaxViewModel t = new TaxViewModel();
            if (obj.ProductItem != null)
            {
                var productDetails = (await irepo.GetAllProductItem()).Where(x=>x.ItemName.Equals(obj.ProductItem)).FirstOrDefault();
                if (productDetails != null)
                {
                    var itemDisplay = (await irepo.GetAllItemDisplayConfig()).Where(x => x.ProductItemId == productDetails.ProductId).FirstOrDefault();
                    if (itemDisplay != null)
                    {
                        var query = from data in (await irepo.GetAllOrderConfiguration())
                                    where data.ProductItem == obj.ProductItem && obj.Quantity > data.MinRange && obj.Quantity <= data.MaxRange
                                    select data;

                        if (itemDisplay.PaperGSM)
                            query = query.Where(p => p.PaperGSM.Equals(obj.PaperGSM));

                        if (itemDisplay.PaperSize)
                            query = query.Where(p => p.PaperSize.Equals(obj.PaperSize));

                        if (itemDisplay.PaperSides)
                            query = query.Where(p => p.PaperSize.Equals(obj.PaperSides));

                        if (itemDisplay.PaperQuality)
                            query = query.Where(p => p.PaperSize.Equals(obj.PaperQuality));

                        if (itemDisplay.PaperColor)
                            query = query.Where(p => p.PaperSize.Equals(obj.PaperColour));

                        if (itemDisplay.LedgerFalio)
                            query = query.Where(p => p.PaperSize.Equals(obj.LedgerFalio));

                        var datas = query.ToList();
                        t = await CalculateTax(datas.FirstOrDefault().Amount);
                    }
                }
            }
            return t;
        }
    }
}