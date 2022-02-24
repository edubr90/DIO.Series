using System;
using System.Linq;

namespace DIO.Series.Shared.Extensions
{
    public static class NumberExtensions
    {
        public static bool IsNumber(this string value)
        {
            return value.Any(_ => Char.IsDigit(_));
        }
        public static int OnlyNumbers(this string value)
        {
            var valueFiltered = new String(value.Where(_ => Char.IsDigit(_)).ToArray());
            return Convert.ToInt32(valueFiltered);
        }
    }
}