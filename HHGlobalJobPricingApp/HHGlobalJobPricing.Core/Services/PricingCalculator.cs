using HHGlobalJobPricing.Core.Extensions;
using HHGlobalJobPricing.Core.Interfaces;
using HHGlobalJobPricing.Core.Models;

namespace HHGlobalJobPricing.Core.Services
{
    public class PricingCalculator : IPricingCalculator
    {
        private const decimal BaseMargin = 0.11m;
        private const decimal ExtraMargin = 0.05m;
        private const decimal SalesTaxRate = 0.07m;

        public JobOutput CalculateTotalPrice(JobInput job)
        {
            var jobResult = new JobOutput
            {
                Items = new List<ItemOutput>()
            };

            foreach (var item in job.Items)
            {
                decimal itemPrice = CalculateItemPrice(item);
                decimal margin = CalculateMargin(item.Cost, job.HasExtraMargin);

                jobResult.Items.Add(new ItemOutput
                {
                    Name = item.Name,
                    Cost = itemPrice.RoundToNearestCent()
                });

                jobResult.TotalPrice += itemPrice + margin;
            }

            jobResult.TotalPrice = jobResult.TotalPrice.RoundToNearestEvenCent();
            return jobResult;
        }

        private decimal CalculateItemPrice(ItemInput item)
        {
            decimal itemPrice = item.Cost;
            decimal salesTax = item.IsTaxExempt ? 0 : itemPrice * SalesTaxRate;
            return itemPrice + salesTax;
        }

        private decimal CalculateMargin(decimal cost, bool hasExtraMargin)
        {
            decimal margin = hasExtraMargin ? BaseMargin + ExtraMargin : BaseMargin;
            return cost * margin;
        }
    }
}
