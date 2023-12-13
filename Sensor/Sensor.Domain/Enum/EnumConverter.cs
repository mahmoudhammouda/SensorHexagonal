using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Domain.Enum
{
    public static class EnumConverter<T> where T : struct
    {
        public static T ConvertFromString(string value)
        {
            if (System.Enum.TryParse(value, out T result))
            {
                return result;
            }

            throw new ArgumentException($"Not able to convert enum {typeof(T).Name}: {value}");
        }

        public static string ConvertToString<T>(T enumValue) 
        {
            return enumValue.ToString();
        }


    }
}
