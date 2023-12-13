using Sensor.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Domain.Test
{
    [TestFixture]
    public class ThresholdTests
    {
        [Test]
        public void Constructor_ValidData_ShouldCreateThreshold()
        {
            // Arrange
            var id = 1;
            var sourceId = 10;
            var indicatorId = 20;
            var minValue = 5;
            var maxValue = 15;

            // Act
            var threshold = new Threshold(id, sourceId, indicatorId, minValue, maxValue);

            // Assert
            Assert.AreEqual(sourceId, threshold.SourceId);
            Assert.AreEqual(indicatorId, threshold.IndicatorId);
            Assert.AreEqual(minValue, threshold.MinValue);
            Assert.AreEqual(maxValue, threshold.MaxValue);
        }

        [Test]
        public void SetAndValidateSourceId_NegativeValue_ThrowsArgumentException()
        {
            // Arrange
            var threshold = new Threshold(1, 10, 20, 5, 15);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => threshold.SetAndValidateSourceId(-1));
        }

        [Test]
        public void SetAndValidateIndicatorId_NegativeValue_ThrowsArgumentException()
        {
            // Arrange
            var threshold = new Threshold(1, 10, 20, 5, 15);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => threshold.SetAndValidateIndicatorId(-1));
        }

        [Test]
        public void SetAndValidateValues_MaxValueLessThanMinValue_ThrowsArgumentException()
        {
            // Arrange
            var threshold = new Threshold(1, 10, 20, 5, 15);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => threshold.SetAndValidateValues(10, 5));
        }
    }
}
