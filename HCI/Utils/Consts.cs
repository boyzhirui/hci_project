using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCI.Utils
{
    public class Consts
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
            public static readonly string Thusday = "Thu";
            public static readonly string Friday = "Fri";
            public static readonly string Saturday = "Sat";
            public static readonly string Sunday = "Sun";
        }
    }

    public enum YesNo
    {
        No = 0,
        Yes = 1
    }
}