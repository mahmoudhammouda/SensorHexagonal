using Sensor.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Domain.Model
{
    public class Threshold : Model
    {
        public int SourceId { get; private set; }
        public int IndicatorId { get; private set; }
        public int MinValue { get; private set; }
        public int MaxValue { get; private set; }

        public Threshold(int id, int sourceId, int indicatorId, int minValue, int maxValue):base(id)
        {
            SetAndValidateSourceId(sourceId);
            SetAndValidateIndicatorId(indicatorId);
            SetAndValidateValues(minValue, maxValue);
        }

        public void SetAndValidateSourceId(int val)
        {
            if (val < 0)
                throw new ArgumentException("ID of the source can not be negative.");

            SourceId = val;
        }

        public void SetAndValidateIndicatorId(int val)
        {
            if (val < 0)
                throw new ArgumentException("ID of the indicator can not be negative.");

            IndicatorId = val;
        }

        public void SetAndValidateValues(int minValue, int maxValue)
        {
           
            if (maxValue < minValue)
                throw new ArgumentException(" Max value should be greater than Min value.");

            MinValue = minValue;
            MaxValue = maxValue;
        }

        public void SetAndValidateWith(Threshold val) 
        {
            SetAndValidateSourceId(val.SourceId);
            SetAndValidateIndicatorId(val.IndicatorId);
            SetAndValidateValues(val.MinValue, val.MaxValue);
        } 
    }
}
