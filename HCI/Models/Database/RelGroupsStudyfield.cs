namespace HCI.Models.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("rel_groups_studyfields")]
    public partial class RelGroupsStudyfield
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int id { get; set; }

        public int group_id { get; set; }

        public int study_field_id { get; set; }

        public virtual Group Group { get; set; }

        public virtual StudyField StudyField { get; set; }
    }
}
