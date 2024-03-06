using HHGlobalJobPricing.Core.Interfaces;
using HHGlobalJobPricing.Core.Models;
using HHGlobalJobPricing.Core.Services;

namespace HHGlobalJobPricing.Tests
{
    public class PricingCalculatorTests
    {
        private IPricingCalculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new PricingCalculator();
        }

        [Test]
        public void CalculateTotalPrice_Job0_ReturnsCorrectTotalPrice()
        {
            // Arrange
            var job = new JobInput
            {
                HasExtraMargin = false, // Job does not have extra margin
                Items = new List<ItemInput>
                {
                    new ItemInput { Name = "item", Cost = 100.00m, IsTaxExempt = false }
                }
            };

            // Act
            var result = _calculator.CalculateTotalPrice(job);

            // Assert
            Assert.That(result.Items[0].Cost, Is.EqualTo(107.00m)); // Cost with sales tax
            Assert.That(result.TotalPrice, Is.EqualTo(118.00m)); // Total price with margin
        }

        [Test]
        public void CalculateTotalPrice_Job1_ReturnsCorrectTotalPrice()
        {
            // Arrange
            var job = new JobInput
            {
                HasExtraMargin = true,
                Items = new List<ItemInput>
                {
                    new ItemInput { Name = "envelopes", Cost = 520.00m, IsTaxExempt = false },
                    new ItemInput { Name = "letterhead", Cost = 1983.37m, IsTaxExempt = true }
                }
            };

            // Act
            var result = _calculator.CalculateTotalPrice(job);

            // Assert
            Assert.That(result.Items[0].Cost, Is.EqualTo(556.40m));
            Assert.That(result.Items[1].Cost, Is.EqualTo(1983.37m));
            Assert.That(result.TotalPrice, Is.EqualTo(2940.30m));
        }

        [Test]
        public void CalculateTotalPrice_Job2_ReturnsCorrectTotalPrice()
        {
            // Arrange
            var job = new JobInput
            {
                HasExtraMargin = false,
                Items = new List<ItemInput>
                {
                    new ItemInput { Name = "t-shirts", Cost = 294.04m, IsTaxExempt = false }
                }
            };

            // Act
            var result = _calculator.CalculateTotalPrice(job);

            // Assert
            Assert.That(result.Items[0].Cost, Is.EqualTo(314.62m));
            Assert.That(result.TotalPrice, Is.EqualTo(346.96m));
        }

        [Test]
        public void CalculateTotalPrice_Job3_ReturnsCorrectTotalPrice()
        {
            // Arrange
            var job = new JobInput
            {
                HasExtraMargin = true,
                Items = new List<ItemInput>
                {
                    new ItemInput { Name = "frisbees", Cost = 19385.38m, IsTaxExempt = true },
                    new ItemInput { Name = "yo-yos", Cost = 1829.00m, IsTaxExempt = true }
                }
            };

            // Act
            var result = _calculator.CalculateTotalPrice(job);

            // Assert
            Assert.That(result.Items[0].Cost, Is.EqualTo(19385.38m));
            Assert.That(result.Items[1].Cost, Is.EqualTo(1829.00m));
            Assert.That(result.TotalPrice, Is.EqualTo(24608.68m));
        }

    }
}
