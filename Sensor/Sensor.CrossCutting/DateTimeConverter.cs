using System;
using System.Globalization;
namespace Sensor.CrossCutting 
{
    public static class DateTimeConverter
    {

        public static string ConvertDateTimeUtcToString(DateTime dateTimeUtc)
        {
            return dateTimeUtc.ToString("o"); 
        }

        public static DateTime ConvertToDateTimeUtc(string dateTimeString)
        {
            if (DateTime.TryParse(dateTimeString, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out DateTime dateTime))
            {
                // Vérifier si la valeur est déjà en UTC
                if (dateTime.Kind == DateTimeKind.Utc)
                {
                    return dateTime;
                }
                else
                {
                    // Convertir en UTC si ce n'est pas déjà le cas
                    return dateTime.ToUniversalTime();
                }
            }
            else
            {
                // Retourner null si la conversion échoue
                throw new ArgumentException($"Not able to convert {dateTimeString} to datate time Utc");
            }
        }
    }

}
