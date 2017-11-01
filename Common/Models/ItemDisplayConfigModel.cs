namespace PrintManagement.Common.Models
{
    public class ItemDisplayConfigModel
    {
        public int ItemDisplayConfigId { get; set; }
        public int ProductItemId { get; set; }
        public bool PaperGSM { get; set; }
        public bool PaperColour { get; set; }
        public bool PaperSize { get; set; }
        public bool PaperQuality { get; set; }
        public bool PaperSides { get; set; }
        public bool LedgerFalio { get; set; }
        public bool AdditionalPaperCount { get; set; }
        public bool AdditionalPaperSize { get; set; }
        public bool AdditonalPaperGSM { get; set; }
        public bool PerBookBillCount { get; set; }

    }
}
