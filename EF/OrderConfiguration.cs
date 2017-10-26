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
        public int ProductItemId { get; set; }
        public Nullable<int> PaperGSMId { get; set; }
        public Nullable<int> PaperColorId { get; set; }
        public Nullable<int> PaperSizeId { get; set; }
        public Nullable<int> PaperQualityId { get; set; }
        public Nullable<int> PaperSidesId { get; set; }
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
    
        public virtual ProductItem ProductItem { get; set; }
    }
}
