using Sensor.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Domain.Model
{
    public class Source : Model
    {
        public string Name { get; private set; }
        public SourceTypeEnum SourceType { get; private set; }

        public Source(int id, string name, SourceTypeEnum type) : base(id)
        {
            SetAndValidateName(name);
            SetAndValidateSourceType(type);
        }

        public void SetAndValidateName(string val)
        {
            // validation rules
            if (string.IsNullOrWhiteSpace(val))
                throw new ArgumentException("the name can not be null or empty.");

            this.Name = val;
        }

        public void SetAndValidateSourceType(SourceTypeEnum val)
        {
            // validation rules
            SourceType = val;
        }

        public void SetAndValidateWith(Source val) 
        {
            SetAndValidateName(val.Name);
            SetAndValidateSourceType(val.SourceType);

        }





    }
}
