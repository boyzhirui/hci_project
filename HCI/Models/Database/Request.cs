namespace HCI.Models.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("requests")]
    public partial class Request
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string type { get; set; }

        public int sender_id { get; set; }

        public int group_id { get; set; }

        public int status { get; set; }

        public virtual Group Group { get; set; }

        public virtual User User { get; set; }
    }
}
