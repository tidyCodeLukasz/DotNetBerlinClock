using System;
using System.Text.RegularExpressions;

namespace BerlinClock
{
    public static class DateTimeExtensions
    {
        public static bool IsValidTimeFormat(this string time)
        {
            Regex checktime = new Regex(@"^((?:0?[0-9]|1[0-9]|2[0-3]):[0-5][0-9]:[0-5][0-9])|24:00:00$");

            return checktime.IsMatch(time);
        }
    }
}
