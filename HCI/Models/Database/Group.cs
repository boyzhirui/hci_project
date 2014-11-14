namespace HCI.Models.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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

        public int is_closed { get; set; }

        public int max_member_number { get; set; }

        public virtual ICollection<GroupMembership> GroupMemberships { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Meeting> Meetings { get; set; }

        public virtual ICollection<RelGroupsStudyfield> RelGroupsStudyfields { get; set; }

        public virtual ICollection<Request> Requests { get; set; }
    }
}
