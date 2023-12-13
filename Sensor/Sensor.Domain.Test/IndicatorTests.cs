using Sensor.Domain.Enum;
using Sensor.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Domain.Test
{
    [TestFixture(Category = "Domain")]
    public class IndicatorTests
    {
        [Test]
        public void Constructor_WhenCalled_SetsProperties()
        {

            var indicator = new Indicator(1, "Temperature", "Room Temp", "Environment", ValueTypeEnum.Numeric);

            Assert.AreEqual(1, indicator.Id);
            Assert.AreEqual("Temperature", indicator.Name);
            Assert.AreEqual("Room Temp", indicator.Description);
            Assert.AreEqual("Environment", indicator.Category);
            Assert.AreEqual(ValueTypeEnum.Numeric, indicator.ValueType);
        }

        [Test]
        public void SetAndValidateName_WithNullOrWhiteSpace_ThrowsArgumentException()
        {

            var indicator = new Indicator(1, "Name", "Description", "Category", ValueTypeEnum.Numeric);

            Assert.Throws<ArgumentException>(() => indicator.SetAndValidateName(null));
            Assert.Throws<ArgumentException>(() => indicator.SetAndValidateName(""));
            Assert.Throws<ArgumentException>(() => indicator.SetAndValidateName(" "));
        }


        [Test]
        public void SetAndValidateWith_NullIndicator_ThrowsArgumentNullException()
        {

            var indicator = new Indicator(1, "Temperature", "Temperature description", "Chaleur", ValueTypeEnum.Numeric);


            Assert.Throws<ArgumentNullException>(() => indicator.SetAndValidateWith(null));
        }

        [Test]
        public void SetAndValidateWith_ValidIndicator_UpdatesProperties()
        {

            var indicator = new Indicator(1, "Temperature", "Temperature description", "Chaleur", ValueTypeEnum.Numeric);
            var newIndicator = new Indicator(2, "Humidite", "Humidite de l'air", "Chaleur", ValueTypeEnum.Percent);


            indicator.SetAndValidateWith(newIndicator);

   
            Assert.AreEqual("Humidite", indicator.Name);
            Assert.AreEqual("Humidite de l'air", indicator.Description);
            Assert.AreEqual("Chaleur", indicator.Category);
            Assert.AreEqual(ValueTypeEnum.Percent, indicator.ValueType);
        }
    }
}
