using System;
using System.IO;
using System.Text;

namespace Cargowire.Extensions
{
    /// <summary>Extension methods for the string class</summary>
    public static class StringExtensions
    {
        /// <summary>Writes a string to a memorysteam</summary>
        /// <param name="string">string to write to stream</param>
        /// <returns>An open stream with the string contents in it</returns>
        public static Stream ToStream(this string @string, Encoding encoding)
        {
            MemoryStream ms = new MemoryStream();
            StreamWriter writer = new StreamWriter(ms, encoding);
            writer.Write(@string);
            writer.Flush();
            ms.Position = 0;
            
            return ms;
        }

        /// <summary>Casts a string as an integer</summary>
        /// <param name="string">string to cast</param>
        /// <param name="defaultValue">default value if cast fails</param>
        /// <returns>Casted integer or default if unable to cast</returns>
        public static int ToInt(this string @string, int defaultValue)
        {
            int value;
            return int.TryParse(@string, out value) ? value : defaultValue;
        }

        /// <summary>Casts a string as a nullable integer</summary>
        /// <param name="string">string to cast</param>
        /// <param name="defaultValue">default value if cast fails</param>
        /// <returns>Casted integer or default if unable to cast</returns>
        public static int? ToNullableInt(this string @string, int? defaultValue)
        {
            int value;
            return int.TryParse(@string, out value) ? value : defaultValue;
        }

        /// <summary>Casts a string as an double</summary>
        /// <param name="string">string to cast</param>
        /// <param name="defaultValue">default value if cast fails</param>
        /// <returns>Casted double or default if unable to cast</returns>
        public static double ToDouble(this string @string, double defaultValue)
        {
            double value;
            return double.TryParse(@string, out value) ? value : defaultValue;
        }

        /// <summary>Casts a string as a nullable double</summary>
        /// <param name="string">string to cast</param>
        /// <param name="defaultValue">default value if cast fails</param>
        /// <returns>Casted double or default if unable to cast</returns>
        public static double? ToNullableDouble(this string @string, double? defaultValue)
        {
            double value;
            return double.TryParse(@string, out value) ? value : defaultValue;
        }

        /// <summary>Casts a string as an decimal</summary>
        /// <param name="string">string to cast</param>
        /// <param name="defaultValue">default value if cast fails</param>
        /// <returns>Casted decimal or default if unable to cast</returns>
        public static decimal ToDecimal(this string @string, decimal defaultValue)
        {
            decimal value;
            return decimal.TryParse(@string, out value) ? value : defaultValue;
        }

        /// <summary>Casts a string as a nullable decimal</summary>
        /// <param name="string">string to cast</param>
        /// <param name="defaultValue">default value if cast fails</param>
        /// <returns>Casted decimal or default if unable to cast</returns>
        public static decimal? ToNullableDecimal(this string @string, decimal? defaultValue)
        {
            decimal value;
            return decimal.TryParse(@string, out value) ? value : defaultValue;
        }

        /// <summary>Casts a string as an datetime. default(DateTime) used if cast fails</summary>
        /// <param name="string">string to cast</param>
        /// <returns>Casted datetime or default if unable to cast</returns>
        public static DateTime ToDateTime(this string @string)
        {
            return ToDateTime(@string, default(DateTime));
        }

        /// <summary>Casts a string as an datetime</summary>
        /// <param name="string">string to cast</param>
        /// <param name="defaultValue">default value if cast fails</param>
        /// <returns>Casted datetime or default if unable to cast</returns>
        public static DateTime ToDateTime(this string @string, DateTime defaultValue)
        {
            DateTime value;
            return DateTime.TryParse(@string, out value) ? value : defaultValue;
        }

        /// <summary>Casts a string as a nullable datetime</summary>
        /// <param name="string">string to cast</param>
        /// <param name="defaultValue">default value if cast fails</param>
        /// <returns>Casted datetime or default if unable to cast</returns>
        public static DateTime? ToNullableDateTime(this string @string, DateTime? defaultValue)
        {
            DateTime value;
            return DateTime.TryParse(@string, out value) ? value : defaultValue;
        }

        /// <summary>Casts a string as an boolean</summary>
        /// <param name="string">string to cast</param>
        /// <param name="defaultValue">default value if cast fails</param>
        /// <returns>Casted boolean or default if unable to cast</returns>
        public static bool ToBoolean(this string @string, bool defaultValue)
        {
            bool value;
            return Boolean.TryParse(@string, out value) ? value : defaultValue;
        }

        /// <summary>Casts a string as a nullable boolean</summary>
        /// <param name="string">string to cast</param>
        /// <param name="defaultValue">default value if cast fails</param>
        /// <returns>Casted boolean or default if unable to cast</returns>
        public static bool? ToNullableBoolean(this string @string, bool? defaultValue)
        {
            Boolean value;
            return Boolean.TryParse(@string, out value) ? value : defaultValue;
        }

        /// <summary>Casts a string as an enum type</summary>
        /// <typeparam name="T">The enum type that is to be parsed</typeparam>
        /// <param name="string">string to cast</param>
        /// <param name="enumeration">default value if cast fails</param>
        /// <returns>Casted enum or default if unable to cast</returns>
        public static T ToEnum<T>(this string @string, T defaultValue)
        {
            if (!typeof(T).IsSubclassOf(typeof(Enum)))
                throw new ArgumentException("Generic type for 'ToEnum' must be a subclass of abstract type Enum.","T");

            try
            {
                return (T)Enum.Parse(typeof(T), @string, true);
            }
            catch (ArgumentException) { return defaultValue; }
            catch (OverflowException) { return defaultValue; }
        }
    }
}
