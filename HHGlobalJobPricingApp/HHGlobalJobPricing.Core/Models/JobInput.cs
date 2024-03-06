namespace HHGlobalJobPricing.Core.Models
{
    // Input model for a job, which is a collection of print items
    public class JobInput
    {
        public List<ItemInput> Items { get; set; }
        public bool HasExtraMargin { get; set; }
    }
}
