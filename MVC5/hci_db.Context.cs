﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class hci : DbContext
    {
        public hci()
            : base("name=hci")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<degree_level> degree_level { get; set; }
        public virtual DbSet<major> majors { get; set; }
        public virtual DbSet<schedule> schedules { get; set; }
        public virtual DbSet<@event> events { get; set; }
        public virtual DbSet<group_membership> group_membership { get; set; }
        public virtual DbSet<group> groups { get; set; }
        public virtual DbSet<meeting_attender> meeting_attender { get; set; }
        public virtual DbSet<meeting> meetings { get; set; }
        public virtual DbSet<rel_group_studyfield> rel_group_studyfield { get; set; }
        public virtual DbSet<request> requests { get; set; }
        public virtual DbSet<study_field> study_field { get; set; }
    }
}
