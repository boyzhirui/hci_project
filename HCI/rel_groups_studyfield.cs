//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HCI
{
    using System;
    using System.Collections.Generic;
    
    public partial class rel_groups_studyfield
    {
        public int id { get; set; }
        public int group_id { get; set; }
        public int study_field_id { get; set; }
    
        public virtual group group { get; set; }
        public virtual study_fields study_fields { get; set; }
    }
}
