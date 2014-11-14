namespace HCI.Models.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("degree_levels")]
    public partial class DegreeLevel
    {
        public DegreeLevel()
        {
            Users = new HashSet<User>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string degree_level_desc { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
