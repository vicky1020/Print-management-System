using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
   public class OrderItemModel
    {
        public int OrderId { get; set; }
        public int ProductItemId { get; set; }
        public Nullable<int> PaperGSM { get; set; }
        public string PaperColor { get; set; }
        public string PaperSize { get; set; }
        public string PaperQuality { get; set; }
        public string PaperSides { get; set; }
        public Nullable<int> LedgerFalio { get; set; }
        public Nullable<int> AdditionalPaperCount { get; set; }
        public string AdditionalPaperSize { get; set; }
        public string AdditonalPaperGSM { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string JobStatus { get; set; }
        public bool Active { get; set; }

    }
}
