using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Domain.Model
{
    public class State
    {
        string key { get; set; }
    }

    public class TemperatureState : State
    {
        public int SourceId { get; set; }
        public int IndicatorId { get; set; }
        public string Value { get; set; }


    }
}
