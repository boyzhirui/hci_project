namespace HCI.Models.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("study_fields")]
    public partial class StudyField
    {
        public StudyField()
        {
            RelGroupsStudyFields = new HashSet<RelGroupsStudyfield>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string name { get; set; }

        public virtual ICollection<RelGroupsStudyfield> RelGroupsStudyFields { get; set; }
    }
}
