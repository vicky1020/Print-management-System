using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintManagement.Common.Models
{
    public class OrderConfigurationValueModel
    {
        public int OrderConfigurationId { get; set; }
        public string ProductItemId { get; set; }
        public Nullable<int> PaperGSMId { get; set; }
        public string PaperColourId { get; set; }
        public Nullable<int> PaperSizeId { get; set; }
        public string PaperQualityId { get; set; }
        public string PaperSidesId { get; set; }
        public Nullable<int> LedgerFalioId { get; set; }
        public Nullable<int> AdditionalPaperCount { get; set; }
        public Nullable<int> AdditionalPaperSizeId { get; set; }
        public Nullable<int> AdditonalPaperGSMId { get; set; }
        public Nullable<int> MinRange { get; set; }
        public Nullable<int> MaxRange { get; set; }
        public decimal Amount { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }

    }
}
