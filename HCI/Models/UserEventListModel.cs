using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HCI.Models.Database;

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
        public void InitList(string userName)
        {
            User user = Context.Users
                                .Include("Schedule.Events")
                                .Include("GroupMemberships.Group.Meetings.Location")
                                .Where(x => x.name == userName).First();

            Events = new List<UserEvent>();
            if (user.Schedule != null)
            {
                foreach (var e in user.Schedule.Events)
                {
                    Events.Add(new UserEvent(e));
                }
            }

            if (user.GroupMemberships != null)
            {
                foreach (var e in user.GroupMemberships.Select(x=>x.Group).SelectMany(x=>x.Meetings))
                {
                    Events.Add(new UserEvent(e));
                }
            }
}
    }

    public class UserEvent
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
    }
}