using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtratoMedico.Helper.Extensions
{
    public static class DateTimeExtension
    {
        public static DateTime ConverterTimeZoneBrasilia(this DateTime date)
        {
            return TimeZoneInfo.ConvertTime(date, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
        }
    }
}
