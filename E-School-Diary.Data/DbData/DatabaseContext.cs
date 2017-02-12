namespace E_School_Diary.Data.DbData
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext()
            : base("name=DatabaseContext")
        {
        }

        public virtual IDbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual IDbSet<AppUser> AppUsers { get; set; }
        public virtual IDbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual IDbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual IDbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual IDbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual IDbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual IDbSet<Lecture> Lectures { get; set; }
        public virtual IDbSet<Mark> Marks { get; set; }
        public virtual IDbSet<Message> Messages { get; set; }
        public virtual IDbSet<StudentClass> StudentClasses { get; set; }

        public int Save()
        {
            return base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>()
                .HasMany(e => e.AppUsers1)
                .WithOptional(e => e.AppUser1)
                .HasForeignKey(e => e.AppUser_Id);

            modelBuilder.Entity<AppUser>()
                .HasMany(e => e.AppUsers11)
                .WithOptional(e => e.AppUser2)
                .HasForeignKey(e => e.ChildId);

            modelBuilder.Entity<AppUser>()
                .HasMany(e => e.AppUsers12)
                .WithOptional(e => e.AppUser3)
                .HasForeignKey(e => e.FormMasterId);

            modelBuilder.Entity<AppUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithOptional(e => e.AppUser)
                .HasForeignKey(e => e.AppUser_Id);

            modelBuilder.Entity<AppUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithOptional(e => e.AppUser)
                .HasForeignKey(e => e.AppUser_Id);

            modelBuilder.Entity<AppUser>()
                .HasMany(e => e.AspNetUserRoles)
                .WithOptional(e => e.AppUser)
                .HasForeignKey(e => e.AppUser_Id);

            modelBuilder.Entity<AppUser>()
                .HasOptional(e => e.AspNetUser)
                .WithRequired(e => e.AppUser);

            modelBuilder.Entity<AppUser>()
                .HasMany(e => e.Lectures)
                .WithOptional(e => e.AppUser)
                .HasForeignKey(e => e.TeacherId);

            modelBuilder.Entity<AppUser>()
                .HasMany(e => e.Marks)
                .WithOptional(e => e.AppUser)
                .HasForeignKey(e => e.StudentId);

            modelBuilder.Entity<AppUser>()
                .HasMany(e => e.Messages)
                .WithOptional(e => e.AppUser)
                .HasForeignKey(e => e.AppUser_Id);

            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUserRoles)
                .WithRequired(e => e.AspNetRole)
                .HasForeignKey(e => e.RoleId);
        }
    }
}
