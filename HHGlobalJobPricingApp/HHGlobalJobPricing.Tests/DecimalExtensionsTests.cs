using HHGlobalJobPricing.Core.Extensions;
using NUnit.Framework;

namespace HHGlobalJobPricing.Tests
{
    public class DecimalExtensionsTests
    {
        [Test]
        public void RoundToNearestCent_RoundsUp_WhenValueIsMidpoint()
        {
            // Arrange
            decimal value = 1.255m;

            // Act
            var result = value.RoundToNearestCent();

            // Assert
            Assert.That(result, Is.EqualTo(1.26m));
        }

        [Test]
        public void RoundToNearestCent_RoundsDown_WhenValueIsMidpoint()
        {
            // Arrange
            decimal value = 1.245m;

            // Act
            var result = value.RoundToNearestCent();

            // Assert
            Assert.That(result, Is.EqualTo(1.24m));
        }

        [Test]
        public void RoundToNearestEvenCent_RoundsUp_WhenValueIsMidpoint()
        {
            // Arrange
            decimal value = 1.2092m;

            // Act
            var result = value.RoundToNearestEvenCent();

            // Assert
            Assert.That(result, Is.EqualTo(1.20m));
        }

        [Test]
        public void RoundToNearestEvenCent_RoundsDown_WhenValueIsMidpoint()
        {
            // Arrange
            decimal value = 1.245m;

            // Act
            var result = value.RoundToNearestEvenCent();

            // Assert
            Assert.That(result, Is.EqualTo(1.24m));
        }
    }
}
