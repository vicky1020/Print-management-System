using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintManagement.Common.Models
{
    public class TaxViewModel
    {
        public decimal Amount { get; set; }
        public decimal CGSTAmt { get; set; }
        public decimal SGSTAmt { get; set; }
        public decimal GrossBillAmount { get; set; }
    }
}
