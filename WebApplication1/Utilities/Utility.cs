using System;
using System.Linq;
using System.Threading.Tasks;
using PrintManagement.Common.Models;
using PrintManagement.Common.Repositories;

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
            t.GrossBillAmount = t.Amount + t.CGSTAmt + t.SGSTAmt;
            return t;
        }

        public async Task<TaxViewModel> GetAmountFromConfig(OrderItemModel obj)
        {
            TaxViewModel t = new TaxViewModel();
            if (obj.ProductItem != null)
            {
                var productDetails = (await irepo.GetAllProductItem()).Where(x => x.ItemName.Equals(obj.ProductItem)).FirstOrDefault();
                if (productDetails != null)
                {
                    var itemDisplay = (await irepo.GetAllItemDisplayConfig()).Where(x => x.ProductItemId == productDetails.ProductId).FirstOrDefault();
                    if (itemDisplay != null)
                    {
                        var query = from data in (await irepo.GetAllOrderConfiguration())
                                    where data.ProductItem == obj.ProductItem && obj.Quantity > data.MinRange && obj.Quantity <= data.MaxRange
                                    select data;

                        if (itemDisplay.PaperGSM)
                            query = query.Where(p => p.PaperGSM!=null && p.PaperGSM.Trim().Equals(Convert.ToString(obj.PaperGSM).Trim()));

                        if (itemDisplay.PaperSize)
                            query = query.Where(p => p.PaperSize != null && p.PaperSize.Trim().Equals(Convert.ToString(obj.PaperSize).Trim()));

                        if (itemDisplay.PaperSides)
                            query = query.Where(p => p.PaperSides != null && p.PaperSides.Trim().Equals(Convert.ToString(obj.PaperSides).Trim()));

                        if (itemDisplay.PaperQuality)
                            query = query.Where(p => p.PaperQuality != null && p.PaperQuality.Trim().Equals(Convert.ToString(obj.PaperQuality).Trim()));

                        if (itemDisplay.PaperColour)
                            query = query.Where(p => p.PaperColour != null && p.PaperColour.Trim().Equals(Convert.ToString(obj.PaperColour).Trim()));

                        if (itemDisplay.LedgerFalio)
                            query = query.Where(p => p.LedgerFalio != null && p.LedgerFalio.Trim().Equals(Convert.ToString(obj.LedgerFalio).Trim()));

                        if (itemDisplay.AdditionalPaperCount)
                            query = query.Where(p => p.AdditionalPaperCount.Value == obj.AdditionalPaperCount);

                        if (itemDisplay.AdditionalPaperSize)
                            query = query.Where(p => p.AdditionalPaperSize != null && p.AdditionalPaperSize.Trim().Equals(Convert.ToString(obj.AdditionalPaperSize).Trim()));

                        if (itemDisplay.AdditonalPaperGSM)
                            query = query.Where(p => p.AdditonalPaperGSM != null && p.AdditonalPaperGSM.Trim().Equals(Convert.ToString(obj.AdditonalPaperGSM).Trim()));

                        if (itemDisplay.PerBookBillCount)
                            query = query.Where(p => p.PerBookBillCount == obj.PerBookBillCount);

                        var datas = query.ToList();
                        if (datas.Count > 0)
                            t = await CalculateTax(datas.FirstOrDefault().Amount);
                    }
                }
            }
            return t;
        }
        public async Task<OrderConfigurationModel> getdata(OrderConfigurationModel obj)
        {
            OrderConfigurationModel o = new OrderConfigurationModel();

            var query = from data in (await irepo.GetAllOrderConfiguration())
                        where data.ProductItem == obj.ProductItem &&
                        data.AdditionalPaperCount==obj.AdditionalPaperCount &&
                        data.AdditionalPaperSize==obj.AdditionalPaperSize &&
                        data.AdditonalPaperGSM==obj.AdditonalPaperGSM &&
                        data.LedgerFalio==obj.LedgerFalio &&
                        data.PaperColour==obj.PaperColour &&
                        data.PaperGSM==obj.PaperGSM &&
                        data.PaperQuality==obj.PaperQuality &&
                        data.PaperSides==obj.PaperSides &&
                        data.PaperSize==obj.PaperSize
                        select data;
            var datau = query.ToList();
            if (datau.Count > 0)
            {
                if (obj.MaxRange  <= datau.FirstOrDefault().MaxRange&& obj.MinRange >= datau.FirstOrDefault().MinRange )
                {
                    o.OrderConfigurationId = 1;
                    return o;
                }
                else
                {
                    o.OrderConfigurationId = 0;
                    return o;
                }
            }
            else
            {
                o.OrderConfigurationId = 0;
                return o;
            }
        }
    }
}