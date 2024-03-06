namespace HHGlobalJobPricing.Core.Models
{
    // Model for a job, which is a collection of print items
    public class Job
    {
        public List<PrintItem> Items { get; set; }
        public bool HasExtraMargin { get; set; }
    }
}
