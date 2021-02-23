using System;
using System.Collections.Generic;
using System.Text;

namespace Bloom.BLL.Utils
{
    public class DateTimeUtil
    {
        public static DateTime UtcToBrasilia()
        {
            var brasilia = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, brasilia);
        }
        public static bool IsValidDate(int year, int month, int day)
        {
            if (year < DateTime.MinValue.Year || year > DateTime.MaxValue.Year)
                return false;

            if (month < 1 || month > 12)
                return false;

            return day > 0 && day <= DateTime.DaysInMonth(year, month);
        }
    }
}
