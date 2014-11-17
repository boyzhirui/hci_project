using HCI.Models.Database;
using HCI.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace HCI.Models
{
    public class ScheduleMeetingModel : ModelBase
    {
        public ScheduleMeetingModel()
        {

        }

        public ScheduleMeetingModel(HciDb ctx):base(ctx)
        {

        }

        public void Init(int groupId)
        {
            Group group = this.Context.Groups.Where(x => x.id == groupId).First();

            this.GroupID = group.id;
            this.GroupName = group.name;
            this.StartDate = DateTime.Now.ToString("yyyy-MM-dd");
            this.EndDate = DateTime.Now.ToString("yyyy-MM-dd");
            this.StartTime = "0";
            this.EndTime = "47";
        }

        public void Save(HciDb ctx)
        {
            DateTime startDt = DateTime.ParseExact(this.StartDate, "yyyy-MM-dd", DateTimeFormatInfo.InvariantInfo);

            DateTime endDt = DateTime.MaxValue;
            if (IntervalType == Consts.IntervalType.OneDay)
            {
                endDt = DateTime.ParseExact(this.EndDate, "yyyy-MM-dd", DateTimeFormatInfo.InvariantInfo);
            }
            else if (!this.NeverEnd)
            {
                endDt = DateTime.ParseExact(this.EndDateForCycle, "yyyy-MM-dd", DateTimeFormatInfo.InvariantInfo);
            }

            TimeSpan startTs = TimeSpan.ParseExact(this.StartTime, "HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
            TimeSpan endTs = TimeSpan.ParseExact(this.EndTime, "HH:mm:ss", DateTimeFormatInfo.InvariantInfo);

            Meeting mtg = new Meeting
            {
                name = this.Title,
                occur_day = this.OccurDays,
                start_date = startDt,
                end_date =  endDt,
                start_time = startTs,
                end_time = endTs,
                interval_type = this.IntervalType,
                group_id = this.GroupID,
                location_id = this.LocationID
            };

            ctx.Meetings.Add(mtg);
            ctx.SaveChanges();
        }

        public int GroupID { get; set; }
        public String GroupName { get; set; }

        [Required]
        [MaxLength(50)]
        public String Title { get; set; }

        public String IntervalType { get; set; }

        public bool Repeat { get; set; }
        public String OccurDays { get; set; }
        public String Description { get; set; }

        [Required]
        public String StartDate { get; set; }

        public bool NeverEnd { get; set; }
        public String EndDate { get; set; }

        [Required]
        public String StartTime { get; set; }

        [Required]
        public String EndTime { get; set; }
        public int LocationID { get; set; }

        [Required]
        public String LocationName { get; set; }

        public string EndDateForCycle { get; set; }
        
    }
}