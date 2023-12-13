using Sensor.Domain.Enum;
using Sensor.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Domain.Test
{
    [TestFixture]
    public class MeasureTests
    {
        private Indicator _validIndicator;
        private Source _validSource;
        private MeasureValue _validMeasureValue;
        private DateTime _validDateTimeUtc;

        [SetUp]
        public void Setup()
        {
            _validIndicator = new Indicator(1, "Temperature", "Measures temperature", "Environmental", ValueTypeEnum.Numeric);
            _validSource = new Source(1, "Sensor1", SourceTypeEnum.Sensor);
            _validMeasureValue = new MeasureValue("1", "25.5");
            _validDateTimeUtc = DateTime.UtcNow;
        }

        [Test]
        public void Constructor_ValidData_ShouldCreateMeasure()
        {
 
            var measure = new Measure(1, _validIndicator, _validSource, _validMeasureValue, _validDateTimeUtc);

            Assert.AreEqual(_validIndicator, measure.Indicator);
            Assert.AreEqual(_validSource, measure.Source);
            Assert.AreEqual(_validMeasureValue, measure.Value);
            Assert.AreEqual(_validDateTimeUtc, measure.ObservationTime);
        }

        [Test]
        public void SetAndValidateIndicator_Null_ThrowsArgumentNullException()
        {
            var measure = new Measure(1, _validIndicator, _validSource, _validMeasureValue, _validDateTimeUtc);

            Assert.Throws<ArgumentNullException>(() => measure.SetAndValidateIndicator(null));
        }

        [Test]
        public void SetAndValidateObservationTime_NonUtc_ThrowsArgumentException()
        {
            var measure = new Measure(1, _validIndicator, _validSource, _validMeasureValue, _validDateTimeUtc);
            var nonUtcDateTime = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Local);

            Assert.Throws<ArgumentException>(() => measure.SetAndValidateObservationTime(nonUtcDateTime));
        }
    }
}
