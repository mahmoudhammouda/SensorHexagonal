using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Infrastructure.Bus.Model
{
    public class SensorMessage
    {
        public string SensorName { get; set; }
        public double Temperature { get; set; }
        public DateTime ObservationTime { get; set; }

        public SensorMessage(string sensorName, double temperature, DateTime observationTime)
        {
            SensorName = sensorName;
            Temperature = temperature;
            ObservationTime = observationTime;
        }
    }
}
