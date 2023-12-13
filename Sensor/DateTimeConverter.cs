using System;
using System.Globalization;

public static class DateTimeHelper
{
    public static DateTime? ConvertToDateTimeUtc(string dateTimeString)
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
            return null;
        }
    }
}