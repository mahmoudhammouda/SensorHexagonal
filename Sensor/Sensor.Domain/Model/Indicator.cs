using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Sensor.Domain.Enum;
using Sensor.Domain.Services;

namespace Sensor.Domain.Model
{
    public class Indicator : Model
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Category { get; private set; }
        public ValueTypeEnum ValueType { get; private set; }


        public Indicator(int id,string name, string description, string category, ValueTypeEnum valueType):base(id)
        {
            SetAndValidateName(name);
            SetAndValidateDescription(description);
            SetAndValidateCategory(category);
            SetAndValidateValueType(valueType);
        }

        public void SetAndValidateName(string val)
        {
            // validation rules
            if (string.IsNullOrWhiteSpace(val))
                throw new ArgumentException("the Name can not be null or empty.");

            Name = val;
        }
        public void SetAndValidateDescription(string val) 
        {
            // validation rules
            if (string.IsNullOrWhiteSpace(val))
                throw new ArgumentException("the Description can not be null or empty.");

            Description = val;
        }

        public void SetAndValidateCategory(string val)
        {
            // validation rules
            if (string.IsNullOrWhiteSpace(val))
                throw new ArgumentException("the Category can not be null or empty.");

            Category = val;
        }

        public void SetAndValidateValueType(ValueTypeEnum val) 
        {
            // validation rules
            ValueType = val;
        }

        public void SetAndValidateWith(Indicator val) 
        {
            if(val == null)
                throw new ArgumentNullException(nameof(val));

            this.SetAndValidateName(val.Name);
            this.SetAndValidateDescription(val.Description);
            this.SetAndValidateCategory(val.Category);
            this.SetAndValidateValueType(val.ValueType);
        
        }

    }
}
