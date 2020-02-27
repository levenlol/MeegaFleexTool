using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MeegaFleeexTool
{
    public static class Utils
    {
        public static int StringToMinutes(string s)
        {
            string[] ss = s.Split(':');
            int hours, mins;

            try
            {
                Int32.TryParse(ss[0], out hours);
                Int32.TryParse(ss[1], out mins);
            }
            catch
            {
                return 0;
            }

            return hours * 60 + mins;
        }

        public static string MinutesToString(int o)
        {
            int ora = o / 60;
            int minuti = o - ora * 60;

            bool bNegative = ora < 0 || minuti < 0;

            ora = Math.Abs(ora);
            minuti = Math.Abs(minuti);

            string hourstring = ora.ToString("D2") + ":" + minuti.ToString("D2");

            if(bNegative)
            {
                hourstring = "-" + hourstring;
            }

            return hourstring;
        }

        public static int GetFirstDayOfWeek(DateTime dayTime)
        {
            int day = dayTime.Day;
            int currentDay = (int)dayTime.DayOfWeek;

            return day - currentDay;
        }

        // sunday is consider the first day
        public static int GetFirstWorkingDayOfWeek(DateTime dayTime)
        {
            return getFirstWorkingDayOfWeekAsDate(dayTime).Day;
        }

        public static DateTime getFirstWorkingDayOfWeekAsDate(DateTime dayTime)
        {
            // sunday is consider the first day
            return dayTime.AddDays(1- (int)dayTime.DayOfWeek);
        }
    }
}
