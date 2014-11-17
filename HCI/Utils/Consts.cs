﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCI.Utils
{
    public static class Consts
    {
        public static class IntervalType
        {
            public static readonly string OneDay = "OneDay";
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
        public static IList<SelectableTime> MeetingTimeOptions = new List<SelectableTime>();
        public static IDictionary<int, string> MeetingTimeOptionsDic = new Dictionary<int, string>();
        static Consts()
        {
            DayOfWeek.Add(Days.Sunday, System.DayOfWeek.Sunday);
            DayOfWeek.Add(Days.Monday, System.DayOfWeek.Monday);
            DayOfWeek.Add(Days.Tuesday, System.DayOfWeek.Tuesday);
            DayOfWeek.Add(Days.Wednesday, System.DayOfWeek.Wednesday);
            DayOfWeek.Add(Days.Thursday, System.DayOfWeek.Thursday);
            DayOfWeek.Add(Days.Friday, System.DayOfWeek.Friday);
            DayOfWeek.Add(Days.Saturday, System.DayOfWeek.Saturday);

            
            int index = 0;
            string hourText = string.Empty;
            for (int hour = 0; hour < 24; hour++)
            {
                hourText = hour.ToString();
                if (hour < 10)
                {
                    hourText = "0" + hour;
                }

                MeetingTimeOptions.Add(new SelectableTime { Index = index++, Text = hourText + ":00:00" });
                MeetingTimeOptions.Add(new SelectableTime { Index = index++, Text = hourText + ":30:00" });
            }

            foreach(var item in MeetingTimeOptions)
            {
                MeetingTimeOptionsDic.Add(item.Index, item.Text);
            }

        }
    }

    public class SelectableTime
    {
        public int Index { get; set; }
        public string Text { get; set; }
    }
    public enum YesNo
    {
        No = 0,
        Yes = 1
    }
}