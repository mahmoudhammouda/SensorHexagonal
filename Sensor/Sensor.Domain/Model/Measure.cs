using Sensor.Domain.Enum;
using Sensor.Domain.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Sensor.Domain.Model
{
    public class Measure :Model
    {
        public Indicator Indicator { get; private set; }
        public Source Source { get; private set; }
        public MeasureValue Value { get; private set; }
        public DateTime ObservationTime { get; private set; }

        public Measure(int id, Indicator indicator, Source source, MeasureValue value, DateTime observationTime) :base(id)
        {
            SetAndValidateIndicator(indicator);
            SetAndValidateSource(source);
            SetAndValidateMeasureValue(value);
            SetAndValidateObservationTime(observationTime);
        }

        public void SetAndValidateIndicator(Indicator val) 
        {
            // validation rules
            if(val == null)
                throw new ArgumentNullException(nameof(val));

            if (Indicator != null)
                this.Indicator.SetAndValidateWith(val);
            else
                Indicator = val;
        }

        public void SetAndValidateMeasureValue(MeasureValue val)
        {
            // validation rules
            this.Value = val;
        }

        public void SetAndValidateObservationTime(DateTime val)
        {
            // validation rules
            if(val.Kind != DateTimeKind.Utc)
                throw new ArgumentException($"Observation dateTime {val} not in Utc ");

            this.ObservationTime = val;
        }



        public void SetAndValidateSource(Source val)
        {
            // validation rules
            if (val == null)
                throw new ArgumentNullException(nameof(val));
            
            if(this.Source!=null)
                this.Source.SetAndValidateWith(val);
            else
                this.Source = val;
        }




        public void SetAndValidateWithh(Measure val)
        {
            if (val == null)
                throw new ArgumentNullException(nameof(val));

            this.SetAndValidateIndicator(val.Indicator);
            this.SetAndValidateSource(val.Source);
            this.SetAndValidateMeasureValue(this.Value);
            this.SetAndValidateObservationTime(val.ObservationTime);

        }




    }

}
