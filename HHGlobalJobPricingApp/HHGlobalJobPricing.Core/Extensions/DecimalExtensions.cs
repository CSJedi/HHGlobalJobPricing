namespace HHGlobalJobPricing.Core.Extensions
{
    public static class DecimalExtensions
    {
        private const int digitCount = 2;

        public static decimal RoundToNearestCent(this decimal value)
        {
            return Math.Round(value, digitCount);
        }

        public static decimal RoundToNearestEvenCent(this decimal value)
        {
            return Math.Round(value, digitCount, MidpointRounding.ToZero);
        }
    }
}
