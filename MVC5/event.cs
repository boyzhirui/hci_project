//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC5
{
    using System;
    using System.Collections.Generic;
    
    public partial class @event
    {
        public @event()
        {
            this.event_schedules = new HashSet<event_schedule>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public int schedule_id { get; set; }
        public System.DateTime start_date { get; set; }
        public System.DateTime end_date { get; set; }
    
        public virtual ICollection<event_schedule> event_schedules { get; set; }
        public virtual schedule schedule { get; set; }
    }
}
