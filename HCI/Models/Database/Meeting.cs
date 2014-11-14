namespace HCI.Models.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("meetings")]
    public partial class Meeting
    {
        public Meeting()
        {
            MeetingAttenders = new HashSet<MeetingAttender>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int id { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        public int group_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime start_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime end_date { get; set; }

        [Required]
        [StringLength(50)]
        public string interval_type { get; set; }

        [Required]
        [StringLength(500)]
        public string occur_day { get; set; }

        public TimeSpan start_time { get; set; }

        public TimeSpan end_time { get; set; }

        public virtual Group Group { get; set; }

        public virtual ICollection<MeetingAttender> MeetingAttenders { get; set; }
    }
}
