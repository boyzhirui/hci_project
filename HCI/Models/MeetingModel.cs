using HCI.Models.Database;
using HCI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace HCI.Models
{
    public class MeetingModel:ModelBase
    {
        public MeetingModel()
        {

        }

        public MeetingModel(HciDb ctx) : base(ctx)
        {

        }

        public void InitMeeting(int meetingID)
        {
            Meeting mtg = Context.Meetings.Where(x => x.id == meetingID).FirstOrDefault();

            MeetingInfo = new MeetingInfo { description = mtg.description, name = mtg.name, location = mtg.Location.address, time = ParseMeetingTime(mtg) };

        }

        private string ParseMeetingTime(Meeting mtg)
        {
            StringBuilder sb = new StringBuilder();
                sb.Clear();
                string start = string.Empty;
                string end = string.Empty;

                if (mtg.start_time.Hours < 10)
                {
                    start = "0" + mtg.start_time.Hours.ToString();
                }
                else
                {
                    start = mtg.start_time.Hours.ToString();
                }

                if (mtg.start_time.Minutes < 10)
                {
                    start = start + ":0" + mtg.start_time.Minutes.ToString();
                }
                else
                {
                    start = start + ":" + mtg.start_time.Minutes.ToString();
                }

                if (mtg.end_time.Hours < 10)
                {
                    end = "0" + mtg.end_time.Hours.ToString();
                }
                else
                {
                    end = mtg.end_time.Hours.ToString();
                }

                if (mtg.end_time.Minutes < 10)
                {
                    end = end + ":0" + mtg.end_time.Minutes.ToString();
                }
                else
                {
                    end = end + ":" + mtg.end_time.Minutes.ToString();
                }

                sb.Append(start).Append(" ~ ").Append(end).Append(" (");
                if (mtg.interval_type == Consts.IntervalType.Week)
                {
                    sb.Append("Weekly on ").Append(mtg.occur_day);
                }
                else if (mtg.interval_type == Consts.IntervalType.Month)
                {
                    sb.Append("Monthly on day ").Append(mtg.occur_day);
                }
                else
                {
                    sb.Append("Daily");
                }


                if (mtg.end_date < DateTime.MaxValue.Date)
                {
                    sb.Append(" until ").Append(mtg.end_date.ToString("yyyy-MM-dd"));
                }

                sb.Append(")");
                return sb.ToString();
        }
        public MeetingInfo MeetingInfo { get; set; }
    }

    public class MeetingInfo
    {
        public string name;
        public string time;
        public string location;
        public string description;
    }
}