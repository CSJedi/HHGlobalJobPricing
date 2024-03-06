namespace HHGlobalJobPricing.Core.Models
{
    public class JobResult
    {
        public List<PrintItemResult> Items { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
