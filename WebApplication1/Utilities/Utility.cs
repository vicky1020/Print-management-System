using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PrintManagement.Common.Models;
using PrintManagement.Common.Repositories;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace PrintManagementApp.Utilities
{
    public class Utility
    {
        private readonly Repository irepo;
        public Utility()
        {
            irepo = new Repository();
        }
        public TaxViewModel GetTaxAmt(OrderItemModel obj)
        {
            TaxViewModel t = new TaxViewModel();
            if (obj.Amount != 0)
            {
                t = CalculateTax(obj.Amount);
            }
            else
            {
                t = CalculateTax(5);
            }
            return t;
        }

        public TaxViewModel CalculateTax(decimal amt)
        {
            TaxViewModel t = new TaxViewModel();
            var CGSTVal = Convert.ToDecimal(irepo.GetConfigurationByName("CGST").Result.ConfigurationValue);
            var SGSTVal = Convert.ToDecimal(irepo.GetConfigurationByName("SGST").Result.ConfigurationValue);
            t.Amount = amt;
            t.CGSTAmt = ((amt * CGSTVal) / 100);
            t.CGSTAmt = ((amt * SGSTVal) / 100);
            t.GrossBillAmount = t.Amount + t.CGSTAmt + t.CGSTAmt;
            return t;
        }
    }
}