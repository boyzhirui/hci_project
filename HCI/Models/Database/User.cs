namespace HCI.Models.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("users")]
    public partial class User
    {
        public User()
        {
            GroupMemberships = new HashSet<GroupMembership>();
            Groups = new HashSet<Group>();
            MeetingAttenders = new HashSet<MeetingAttender>();
            Requests = new HashSet<Request>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [StringLength(50)]
        public string phone { get; set; }

        public string addr { get; set; }

        public int? degree_level_id { get; set; }

        public int schedule_id { get; set; }

        [Column(TypeName = "image")]
        public byte[] photo { get; set; }

        public int major_id { get; set; }

        public virtual DegreeLevel DegreeLevel { get; set; }

        public virtual ICollection<GroupMembership> GroupMemberships { get; set; }

        public virtual ICollection<Group> Groups { get; set; }

        public virtual Major Major { get; set; }

        public virtual ICollection<MeetingAttender> MeetingAttenders { get; set; }

        public virtual ICollection<Request> Requests { get; set; }

        public virtual Schedule Schedule { get; set; }
    }
}
