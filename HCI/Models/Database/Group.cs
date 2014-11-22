namespace HCI.Models.Database
{
    using HCI.Utils;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Text;

    [Table("groups")]
    public partial class Group
    {
        public Group()
        {
            GroupMemberships = new HashSet<GroupMembership>();
            Meetings = new HashSet<Meeting>();
            RelGroupsStudyfields = new HashSet<RelGroupsStudyfield>();
            Requests = new HashSet<Request>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string name { get; set; }

        public int owner_id { get; set; }

        [Required]
        [StringLength(1000)]
        public string description { get; set; }

        [StringLength(50)]
        public string course_no { get; set; }

        public YesNo is_closed { get; set; }

        public int max_member_number { get; set; }

        public virtual ICollection<GroupMembership> GroupMemberships { get; set; }

        public virtual User Owner { get; set; }

        public virtual ICollection<Meeting> Meetings { get; set; }

        public virtual ICollection<RelGroupsStudyfield> RelGroupsStudyfields { get; set; }

        public virtual ICollection<Request> Requests { get; set; }

        
        public bool IsOwner(string userName)
        {
            if (Owner != null && Owner.name == userName)
            {
                return true;
            }

            return false;
        }

        public bool IsMember(int userID)
        {
            return GroupMemberships.Any(x => x.user_id == userID);
        }

        [NotMapped]
        public IList<string> MeetingDescriptions
        {
            get
            {
                List<string> list = new List<string>();
                StringBuilder sb = new StringBuilder();
                foreach (var mtg in this.Meetings.Where(x=> x.interval_type != Consts.IntervalType.OneDay))
                {
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

                    sb.Append(mtg.name).Append(": ");
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
                    list.Add(sb.ToString());
                }
                return list;
            }
        }
    }
}
