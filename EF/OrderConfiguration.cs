//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderConfiguration
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
