namespace HCI.Models.Database
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Entity.Infrastructure.Annotations;

    public partial class HciDb : DbContext
    {
        public HciDb()
            : base("name=HciDb")
        {
        }

        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<DegreeLevel> DegreeLevels { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<GroupMembership> GroupMemberships { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Major> Majors { get; set; }
        public virtual DbSet<MeetingAttender> MeetingAttenders { get; set; }
        public virtual DbSet<Meeting> Meetings { get; set; }
        public virtual DbSet<RelGroupsStudyfield> RelGroupsStudyfields { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<StudyField> StudyFields { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Location> Locations { get; set; }

        public virtual DbSet<Mail> Mails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DegreeLevel>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.DegreeLevel)
                .HasForeignKey(e => e.degree_level_id);

            modelBuilder.Entity<Event>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Event>()
                .Property(e => e.interval_type)
                .IsUnicode(false);

            modelBuilder.Entity<Event>()
                .Property(e => e.occur_day)
                .IsUnicode(false);

            modelBuilder.Entity<Group>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Group>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<Group>()
                .Property(e => e.course_no)
                .IsUnicode(false);

            modelBuilder.Entity<Group>()
                .HasMany(e => e.GroupMemberships)
                .WithRequired(e => e.Group)
                .HasForeignKey(e => e.group_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Group>()
                .HasMany(e => e.Meetings)
                .WithRequired(e => e.Group)
                .HasForeignKey(e => e.group_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Group>()
                .HasMany(e => e.RelGroupsStudyfields)
                .WithRequired(e => e.Group)
                .HasForeignKey(e => e.group_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Group>()
                .HasMany(e => e.Requests)
                .WithRequired(e => e.Group)
                .HasForeignKey(e => e.group_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Major>()
                .Property(e => e.major_name)
                .IsUnicode(false);

            modelBuilder.Entity<Major>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Major)
                .HasForeignKey(e => e.major_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Meeting>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Meeting>()
                .Property(e => e.interval_type)
                .IsUnicode(false);

            modelBuilder.Entity<Meeting>()
                .Property(e => e.occur_day)
                .IsUnicode(false);

            modelBuilder.Entity<Meeting>()
                .HasMany(e => e.MeetingAttenders)
                .WithRequired(e => e.Meeting)
                .HasForeignKey(e => e.meeting_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Request>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<Schedule>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<Schedule>()
                .HasMany(e => e.Events)
                .WithRequired(e => e.schedule)
                .HasForeignKey(e => e.schedule_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Schedule>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Schedule)
                .HasForeignKey(e => e.schedule_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StudyField>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<StudyField>()
                .HasMany(e => e.RelGroupsStudyFields)
                .WithRequired(e => e.StudyField)
                .HasForeignKey(e => e.study_field_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.GroupMemberships)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.user_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Groups)
                .WithRequired(e => e.Owner)
                .HasForeignKey(e => e.owner_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.MeetingAttenders)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.user_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Requests)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.sender_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Location>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Location>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<Location>()
                .HasMany(e => e.Meetings)
                .WithRequired(e => e.Location)
                .HasForeignKey(e => e.location_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.SentMails)
                .WithRequired(e => e.Sender)
                .HasForeignKey(e => e.sender_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ReceivedMails)
                .WithRequired(e => e.Receiver)
                .HasForeignKey(e => e.receiver_id)
                .WillCascadeOnDelete(false);
        }
    }
}
