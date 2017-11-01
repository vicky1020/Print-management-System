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
