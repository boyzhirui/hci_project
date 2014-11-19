namespace HCI.Models.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("group_memberships")]
    public partial class GroupMembership
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int id { get; set; }

        public int group_id { get; set; }

        public int user_id { get; set; }

        public string approval { get; set; }

        public virtual Group Group { get; set; }

        public virtual User User { get; set; }
    }
}
