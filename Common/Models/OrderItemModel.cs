﻿using System;

namespace PrintManagement.Common.Models
{
    public class OrderItemModel
    {
        public int OrderId { get; set; }
        public string ProductItem { get; set; }
        public Nullable<int> PaperGSM { get; set; }
        public string PaperColour { get; set; }
        public string PaperSize { get; set; }
        public string PaperQuality { get; set; }
        public string PaperSides { get; set; }
        public Nullable<int> LedgerFalio { get; set; }
        public Nullable<int> AdditionalPaperCount { get; set; }
        public string AdditionalPaperSize { get; set; }
        public string AdditonalPaperGSM { get; set; }
        public Nullable<int> PerBookBillCount { get; set; }
        public string JobTitle { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public decimal CGST { get; set; }
        public decimal SGST { get; set; }
        public decimal TotalTaxes { get; set; }
        public decimal TotalAmount { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public string JobProcessType { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string WorkedBy { get; set; }
        public System.DateTime WorkedOn{ get; set; }
    }
}
