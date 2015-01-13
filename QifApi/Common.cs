using System;
using System.Globalization;

namespace QifApi
{
    internal static class Common
    {
        internal static bool GetBoolean(string value)
        {
            bool result = false;

            if ((bool.TryParse(value, out result) == false) && (value.Length > 0))
            {
                throw new InvalidCastException(Resources.InvalidBooleanFormat);
            }

            return result;

        }

        private static string GetRealDateString(string qifDateString)
        {
            // Find the apostraphe
            int i = qifDateString.IndexOf("'", StringComparison.Ordinal);

            // Prepare the return string
            string sRet = "";

            // If the apostraphe is present
            if (i != -1)
            {
                // Extract everything but the apostraphe
                sRet = qifDateString.Substring(0, i) + "/" + qifDateString.Substring(i + 1);

                // Replace spaces with zeros
                sRet = sRet.Replace(" ", "0");

                // Return the new string
                return sRet;
            }
            else
            {
                // Otherwise, just return the raw value
                return qifDateString;
            }
        }

        internal static decimal GetDecimal(string value)
        {
            decimal result = 0;

            if (decimal.TryParse(value, out result) == false)
            {
                throw new InvalidCastException(Resources.InvalidDecimalFormat);
            }

            return result;
        }

        internal static DateTime GetDateTime(string value)
        {
            // Prepare the return value
            DateTime result = new DateTime();

            // If parsing the date string fails
            if (DateTime.TryParse(GetRealDateString(value), CultureInfo.CurrentCulture, DateTimeStyles.None, out result) == false)
            {
                // Identify that the value couldn't be formatted
                throw new InvalidCastException(Resources.InvalidDateFormat);
            }

            // Return the date value
            return result;
        }
    }
}
