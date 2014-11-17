using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HCI.Models.Database;
using HCI.Utils;

namespace HCI.Models
{
    public class UserEventListModel : ModelBase
    {

        public UserEventListModel()
        {

        }

        public UserEventListModel(HciDb ctx)
            : base(ctx)
        {
        }

        public IList<UserEvent> Events
        {
            get;
            set;
        }
        public void InitList(string userName, DateTime start, DateTime end)
        {
            List<UserEvent> events = new List<UserEvent>();
            Events = events;

            User user = Context.Users
                                .Include("Schedule.Events")
                                .Include("GroupMemberships.Group.Meetings.Location")
                                .Where(x => x.name == userName).First();


            if (user.Schedule != null)
            {
                foreach (var e in user.Schedule.Events)
                {
                    events.AddRange(GetEvent(e, start, end));
                }
            }

            if (user.GroupMemberships != null)
            {
                foreach (var e in user.GroupMemberships.Select(x => x.Group).SelectMany(x => x.Meetings))
                {
                    events.AddRange(GetEvent(e, start, end));
                }
            }
        }

        private IList<DateTime> GetDatesFromDayOfWeek(DateTime start, DateTime end, DayOfWeek day)
        {
            List<DateTime> dates = new List<DateTime>();

            int diff = day - start.DayOfWeek;
            if (diff < 0)
                diff += 7;

            DateTime date = start + TimeSpan.FromDays(diff);

            while(date <= end)
            {
                dates.Add(date);
                date = date.AddDays(7);
            }

            return dates;
        }

        private IList<DateTime> GetDatesFromEveryDay(DateTime start, DateTime end)
        {
            List<DateTime> dates = new List<DateTime>();

            DateTime date = start;

            while (date <= end)
            {
                dates.Add(date);
                date = date.AddDays(1);
            }

            return dates;
        }

        private IList<DateTime> GetDatesFromEveryMonth(DateTime start, DateTime end, int day)
        {
            List<DateTime> dates = new List<DateTime>();

            DateTime date = new DateTime(start.Year, start.Month, day);

            if (date>=start && date <= end)
            {
                dates.Add(date);
            }
            
            date = date.AddMonths(1);

            while (date <= end)
            {
                dates.Add(date);
                date = date.AddMonths(1);
            }

            return dates;
        }

        private IList<UserEvent> GenerateUserEvents(IList<DateTime> dateTimes, TimeSpan startTime, TimeSpan endTime, string title, int eventID,bool isMeeting = false, string address  = "")
        {
            List<UserEvent> events = new List<UserEvent>();
            foreach(var dt in dateTimes)
            {
                events.Add(new UserEvent { IsMeeting = isMeeting, Title = title, Start = (dt + startTime).ToString("o"), End = (dt + endTime).ToString("o"), Location = address,EventID=eventID });
            }

            return events;
        }
        private IList<UserEvent> GetEvent(Event evt, DateTime start, DateTime end)
        {
            List<UserEvent> events = new List<UserEvent>();

            if (end >= evt.start_date && start <= evt.end_date)
            {

                DateTime actualStart = start > evt.start_date ? start : evt.start_date;
                DateTime actualEnd = end > evt.end_date ? evt.end_date : end;

                actualStart = actualStart.Date;
                actualEnd = actualEnd.Date;

                if (evt.interval_type == Consts.IntervalType.Day)
                {
                    events.AddRange(GenerateUserEvents(GetDatesFromEveryDay(actualStart, actualEnd), evt.start_time, evt.end_time, evt.name,evt.id,false, string.Empty));
                }
                else if(evt.interval_type == Consts.IntervalType.Week)
                {
                    foreach (var dayOfWeek in ParseDay(evt.occur_day))
                    {
                        events.AddRange(GenerateUserEvents(GetDatesFromDayOfWeek(actualStart, actualEnd, dayOfWeek), evt.start_time, evt.end_time, evt.name, evt.id,false, string.Empty));
                    }
                }
                else if (evt.interval_type == Consts.IntervalType.Month)
                {
                    foreach (var days in ParseMonthDay(evt.occur_day))
                    {
                        events.AddRange(GenerateUserEvents(GetDatesFromEveryMonth(actualStart, actualEnd, days), evt.start_time, evt.end_time, evt.name,evt.id, false, string.Empty));
                    }
                }
                else if (evt.interval_type == Consts.IntervalType.OneDay)
                {
                    events.Add(new UserEvent
                    {
                        Title = evt.name,
                        Location = string.Empty,
                        IsMeeting = false,
                        Start = (evt.start_date + evt.start_time).ToString("o"),
                        End = (evt.end_date + evt.end_time).ToString("o"),
                        EventID = evt.id
                    });
                }
            }

            return events;
        }

        private IList<UserEvent> GetEvent(Meeting evt, DateTime start, DateTime end)
        {
            List<UserEvent> events = new List<UserEvent>();

            if (end >= evt.start_date && start <= evt.end_date)
            {
                DateTime actualStart = start > evt.start_date ? start : evt.start_date;
                DateTime actualEnd = end > evt.end_date ? evt.end_date : end;

                if (evt.interval_type == Consts.IntervalType.Day)
                {
                    events.AddRange(GenerateUserEvents(GetDatesFromEveryDay(actualStart, actualEnd), evt.start_time, evt.end_time, evt.name,evt.id, true, evt.Location.address));
                }
                else if (evt.interval_type == Consts.IntervalType.Week)
                {
                    foreach (var dayOfWeek in ParseDay(evt.occur_day))
                    {
                        events.AddRange(GenerateUserEvents(GetDatesFromDayOfWeek(actualStart, actualEnd, dayOfWeek), evt.start_time, evt.end_time, evt.name,evt.id, true, evt.Location.address));
                    }
                }
                else if (evt.interval_type == Consts.IntervalType.Month)
                {
                    foreach (var days in ParseMonthDay(evt.occur_day))
                    {
                        events.AddRange(GenerateUserEvents(GetDatesFromEveryMonth(actualStart, actualEnd, days), evt.start_time, evt.end_time, evt.name, evt.id,true, evt.Location.address));
                    }
                }
                else if (evt.interval_type == Consts.IntervalType.OneDay)
                {
                    events.Add(new UserEvent
                    {
                        Title = evt.name,
                        Location = evt.Location.name,
                        IsMeeting = false,
                        Start = (evt.start_date + evt.start_time).ToString("o"),
                        End = (evt.end_date + evt.end_time).ToString("o"),
                        EventID = evt.id
                    });
                }
            }

            return events;
        }

        private IList<DayOfWeek> ParseDay(string days)
        {
            List<DayOfWeek> daysOfWeek = new List<DayOfWeek>();

            if (!string.IsNullOrWhiteSpace(days))
            {
                DayOfWeek dayOfWeek;
                foreach (var day in days.Split(','))
                {

                    if (Consts.DayOfWeek.TryGetValue(day, out dayOfWeek))
                    {
                        daysOfWeek.Add(dayOfWeek);
                    }
                }
                daysOfWeek = daysOfWeek.Distinct().ToList();
            }

            return daysOfWeek;
        }

        private IList<int> ParseMonthDay(string days)
        {
            List<int> monthDays = new List<int>();

            if (!string.IsNullOrWhiteSpace(days))
            {
                int rst;
                foreach (var day in days.Split(','))
                {

                    if (Int32.TryParse(day, out rst))
                    {
                        monthDays.Add(rst);
                    }
                }
                monthDays = monthDays.Distinct().ToList();
            }

            return monthDays;
        }
        
    }

    public class UserEvent
    {
        public string Title { get; set; }
        public string Start { get; set; }
        public string End { get; set; }

        public string Location { get; set; }

        public bool IsMeeting { get; set; }

        public int EventID { get; set; }
    }

    /*public class UserEvent
    {
        public UserEvent(Event _event)
        {
            IsMeeting = false;

            Name = _event.name;

            StartDate = _event.start_date;
            EndDate = _event.end_date;

            StartTime = _event.start_time;
            EndTime = _event.end_time;

            IntervalType = _event.interval_type;
            OccurDay = new List<string>();
            if (!string.IsNullOrWhiteSpace(_event.occur_day))
            {
                foreach (var day in _event.occur_day.Split(','))
                {
                    OccurDay.Add(day);
                }
                OccurDay = OccurDay.Distinct().ToList();
            }

        }

        public UserEvent(Meeting _event)
        {

            IsMeeting = true;

            Name = _event.name;

            StartDate = _event.start_date;
            EndDate = _event.end_date;

            StartTime = _event.start_time;
            EndTime = _event.end_time;

            IntervalType = _event.interval_type;
            OccurDay = new List<string>();
            if (!string.IsNullOrWhiteSpace(_event.occur_day))
            {
                foreach (var day in _event.occur_day.Split(','))
                {
                    OccurDay.Add(day);
                }
                OccurDay = OccurDay.Distinct().ToList();
            }
            Location = _event.Location;

        }
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string IntervalType { get; set; }

        public IList<string> OccurDay { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public Location Location { get; set; }
        public bool IsMeeting { get; set; }
    }*/
}