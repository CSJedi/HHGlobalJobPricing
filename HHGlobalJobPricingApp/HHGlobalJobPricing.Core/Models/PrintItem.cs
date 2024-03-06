namespace HHGlobalJobPricing.Core.Models
{
    // Model for a single print item
    public class PrintItem
    {
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public bool IsTaxExempt { get; set; }
    }
}
