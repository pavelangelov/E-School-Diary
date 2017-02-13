namespace E_School_Diary.Data.DB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Contracts;

    public partial class MyDbContext : DbContext, IDatabaseContext
    {
        public MyDbContext()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoles1> AspNetRoles1 { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserClaims1> AspNetUserClaims1 { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserLogins1> AspNetUserLogins1 { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUsers1> AspNetUsers1 { get; set; }
        public virtual DbSet<Lecture> Lectures { get; set; }
        public virtual DbSet<Mark> Marks { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<StudentClass> StudentClasses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUserRoles)
                .WithRequired(e => e.AspNetRole)
                .HasForeignKey(e => e.RoleId);

            modelBuilder.Entity<AspNetRoles1>()
                .HasMany(e => e.AspNetUsers1)
                .WithMany(e => e.AspNetRoles1)
                .Map(m => m.ToTable("AspNetUserAspNetRoles").MapLeftKey("AspNetRole_Id").MapRightKey("AspNetUser_Id"));

            modelBuilder.Entity<AspNetUsers1>()
                .HasMany(e => e.AspNetUserClaims)
                .WithOptional(e => e.AspNetUsers1)
                .HasForeignKey(e => e.AspNetUser_Id);

            modelBuilder.Entity<AspNetUsers1>()
                .HasMany(e => e.AspNetUserClaims1)
                .WithOptional(e => e.AspNetUsers1)
                .HasForeignKey(e => e.AspNetUser_Id);

            modelBuilder.Entity<AspNetUsers1>()
                .HasMany(e => e.AspNetUserLogins)
                .WithOptional(e => e.AspNetUsers1)
                .HasForeignKey(e => e.AspNetUser_Id);

            modelBuilder.Entity<AspNetUsers1>()
                .HasMany(e => e.AspNetUserLogins1)
                .WithOptional(e => e.AspNetUsers1)
                .HasForeignKey(e => e.AspNetUser_Id);

            modelBuilder.Entity<AspNetUsers1>()
                .HasMany(e => e.AspNetUserRoles)
                .WithOptional(e => e.AspNetUsers1)
                .HasForeignKey(e => e.AspNetUser_Id);

            modelBuilder.Entity<AspNetUsers1>()
                .HasOptional(e => e.AspNetUser)
                .WithRequired(e => e.AspNetUsers1);

            modelBuilder.Entity<AspNetUsers1>()
                .HasMany(e => e.AspNetUsers11)
                .WithOptional(e => e.AspNetUsers12)
                .HasForeignKey(e => e.AspNetUser_Id);

            modelBuilder.Entity<AspNetUsers1>()
                .HasMany(e => e.AspNetUsers111)
                .WithOptional(e => e.AspNetUsers13)
                .HasForeignKey(e => e.ChildId);

            modelBuilder.Entity<AspNetUsers1>()
                .HasMany(e => e.AspNetUsers112)
                .WithOptional(e => e.AspNetUsers14)
                .HasForeignKey(e => e.FormMasterId);

            modelBuilder.Entity<AspNetUsers1>()
                .HasMany(e => e.Lectures)
                .WithOptional(e => e.AspNetUsers1)
                .HasForeignKey(e => e.TeacherId);

            modelBuilder.Entity<AspNetUsers1>()
                .HasMany(e => e.Marks)
                .WithOptional(e => e.AspNetUsers1)
                .HasForeignKey(e => e.StudentId);

            modelBuilder.Entity<AspNetUsers1>()
                .HasMany(e => e.Messages)
                .WithOptional(e => e.AspNetUsers1)
                .HasForeignKey(e => e.AspNetUser_Id);
        }

        public int Save()
        {
            return base.SaveChanges();
        }
    }
}
