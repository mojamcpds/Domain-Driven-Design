using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace DMS.SharedKernel.Infrastructure.Domain
{
    public class Guard
    {
        public static void ForLessEqualZero(int value, string parameterName)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(parameterName);
            }
        }

        
        public static void ForInteger(string value, string parameterName)
        {
            int number;
            if (!int.TryParse(value, out number))
            {
                throw new InvalidDataException(parameterName);
            }
        }

        public static void ForDecimal(string value, string parameterName)
        {
            decimal number;
            if (!decimal.TryParse(value, out number))
            {
                throw new InvalidDataException(parameterName);
            }
        }
        public static void ForLessEqualZeroDecimal(decimal value, string parameterName)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(parameterName);
            }
        }
        public static void ForPrecedesDate(DateTime value, DateTime dateToPrecede, string parameterName)
        {
            if (value >= dateToPrecede)
            {
                throw new ArgumentOutOfRangeException(parameterName);
            }
        }

        public static void ForNullOrEmpty(string value, string parameterName)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(parameterName);
            }
        }
    }
}
