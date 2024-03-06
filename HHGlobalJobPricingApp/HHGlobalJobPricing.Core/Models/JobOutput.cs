namespace HHGlobalJobPricing.Core.Models
{
    // Output model for a job, which includes the calculated total price and individual item results
    public class JobOutput
    {
        public List<ItemOutput> Items { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
