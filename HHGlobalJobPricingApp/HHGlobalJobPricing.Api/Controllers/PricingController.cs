using Microsoft.AspNetCore.Mvc;
using HHGlobalJobPricing.Core.Interfaces;
using HHGlobalJobPricing.Core.Models;

namespace HHGlobalJobPricing.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PricingController : ControllerBase
    {
        private readonly IPricingCalculator _pricingCalculator;

        public PricingController(IPricingCalculator pricingCalculator)
        {
            _pricingCalculator = pricingCalculator;
        }

        [HttpPost("calculate")]
        public IActionResult CalculateTotalCharge(Job job)
        {
            var jobResult = _pricingCalculator.CalculateTotalPrice(job);

            // Return the result in JSON format
            return Ok(jobResult);
        }
    }
}