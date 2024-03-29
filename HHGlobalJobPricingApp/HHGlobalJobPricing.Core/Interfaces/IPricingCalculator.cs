﻿using HHGlobalJobPricing.Core.Models;

namespace HHGlobalJobPricing.Core.Interfaces
{
    // Interface for calculating job pricing
    public interface IPricingCalculator
    {
        JobOutput CalculateTotalPrice(JobInput job);
    }
}
