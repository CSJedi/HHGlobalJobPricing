using HHGlobalJobPricing.Core.Interfaces;
using HHGlobalJobPricing.Core.Models;

namespace HHGlobalJobPricing.Core.Services
{
    public class PricingCalculator : IPricingCalculator
    {
        private const decimal BaseMargin = 0.11m;
        private const decimal ExtraMargin = 0.05m;

        public JobResult CalculateTotalPrice(Job job)
        {
            var jobResult = new JobResult
            {
                Items = new List<PrintItemResult>()
            };

            foreach (var item in job.Items)
            {
                decimal itemPrice = CalculateItemPrice(item);
                decimal margin = CalculateMargin(item.Cost, job.HasExtraMargin);
                jobResult.Items.Add(new PrintItemResult
                {
                    Name = item.Name,
                    Cost = RoundToNearestCent(itemPrice)
                });
                itemPrice += margin;
                jobResult.TotalPrice += itemPrice;
            }
            jobResult.TotalPrice = RoundToNearestEvenCent(jobResult.TotalPrice);
            return jobResult;
        }

        private decimal CalculateItemPrice(PrintItem item)
        {
            decimal itemPrice = item.Cost;
            decimal salesTax = CalculateSalesTax(itemPrice, item.IsTaxExempt);
          
            itemPrice += salesTax;

            return itemPrice;
        }

        private decimal CalculateSalesTax(decimal cost, bool isTaxExempt)
        {
            if (isTaxExempt)
            {
                return 0;
            }
            else
            {
                return cost * 0.07m; // 7% sales tax
            }
        }

        private decimal CalculateMargin(decimal cost, bool hasExtraMargin)
        {
            decimal margin = hasExtraMargin ? BaseMargin + ExtraMargin: BaseMargin;
            return cost * margin;
        }

        private decimal RoundToNearestCent(decimal value)
        {
            return Math.Round(value, 2, MidpointRounding.AwayFromZero);
        }

        private decimal RoundToNearestEvenCent(decimal value)
        {
            return Math.Round(value * 2, MidpointRounding.ToEven) / 2;
        }
    }
}
