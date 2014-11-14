namespace HCI.Models.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("meeting_attenders")]
    public partial class MeetingAttender
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int id { get; set; }

        public int meeting_id { get; set; }

        public int user_id { get; set; }

        public virtual Meeting Meeting { get; set; }

        public virtual User User { get; set; }
    }
}
