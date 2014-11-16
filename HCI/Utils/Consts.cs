using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCI.Utils
{
    public static class Consts
    {
        public static class IntervalType
        {
            public static readonly string Day = "Day";
            public static readonly string Month = "Month";
            public static readonly string Week = "Week";
        }

        public static class Days
        {
            public static readonly string Monday = "Mon";
            public static readonly string Tuesday = "Tue";
            public static readonly string Wednesday = "Wed";
            public static readonly string Thursday = "Thu";
            public static readonly string Friday = "Fri";
            public static readonly string Saturday = "Sat";
            public static readonly string Sunday = "Sun";
        }

        public static IDictionary<string, DayOfWeek> DayOfWeek = new Dictionary<string, DayOfWeek>(7);

        static Consts()
        {
            DayOfWeek.Add(Days.Sunday, System.DayOfWeek.Sunday);
            DayOfWeek.Add(Days.Monday, System.DayOfWeek.Monday);
            DayOfWeek.Add(Days.Tuesday, System.DayOfWeek.Tuesday);
            DayOfWeek.Add(Days.Wednesday, System.DayOfWeek.Wednesday);
            DayOfWeek.Add(Days.Thursday, System.DayOfWeek.Thursday);
            DayOfWeek.Add(Days.Friday, System.DayOfWeek.Friday);
            DayOfWeek.Add(Days.Saturday, System.DayOfWeek.Saturday);
        }
    }

    public enum YesNo
    {
        No = 0,
        Yes = 1
    }
}