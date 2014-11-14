namespace HCI.Models.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("schedules")]
    public partial class Schedule
    {
        public Schedule()
        {
            Events = new HashSet<Event>();
            Users = new HashSet<User>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int id { get; set; }

        [StringLength(50)]
        public string description { get; set; }

        public virtual ICollection<Event> Events { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
