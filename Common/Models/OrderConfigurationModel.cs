using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintManagement.Common.Models
{
   public class OrderConfigurationModel
    {
        public int OrderConfigurationId { get; set; }
        public string ProductItem { get; set; }
        public string PaperGSM { get; set; }
        public string PaperColour { get; set; }
        public string PaperSize { get; set; }
        public string PaperQuality { get; set; }
        public string PaperSides { get; set; }
        public string LedgerFalio { get; set; }
        public Nullable<int> AdditionalPaperCount { get; set; }
        public string AdditionalPaperSize { get; set; }
        public string AdditonalPaperGSM { get; set; }
        public Nullable<int> MinRange { get; set; }
        public Nullable<int> MaxRange { get; set; }
        public decimal Amount { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }

    }
}
