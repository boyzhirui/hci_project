
namespace HCI.Models.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("locations")]
    public partial class Location
    {
        public Location()
        {
            Meetings = new HashSet<Meeting>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int id { get; set; }

        [StringLength(50)]
        [Required]
        public string name { get; set; }

        [StringLength(500)]
        [Required]
        public string address { get; set; }

        public virtual ICollection<Meeting> Meetings { get; set; }
    }
}