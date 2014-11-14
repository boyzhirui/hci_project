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
    
    public partial class user
    {
        public user()
        {
            this.group_memberships = new HashSet<group_membership>();
            this.groups = new HashSet<group>();
            this.meeting_attenders = new HashSet<meeting_attender>();
            this.requests = new HashSet<request>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string addr { get; set; }
        public Nullable<int> degree_level_id { get; set; }
        public int schedule_id { get; set; }
        public byte[] photo { get; set; }
        public int major_id { get; set; }
    
        public virtual degree_level degree_levels { get; set; }
        public virtual ICollection<group_membership> group_memberships { get; set; }
        public virtual ICollection<group> groups { get; set; }
        public virtual major major { get; set; }
        public virtual ICollection<meeting_attender> meeting_attenders { get; set; }
        public virtual ICollection<request> requests { get; set; }
        public virtual schedule schedule { get; set; }
    }
}
