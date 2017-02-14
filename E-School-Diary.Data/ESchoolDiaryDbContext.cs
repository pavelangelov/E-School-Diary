using E_School_Diary.Data.CustomModels.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_School_Diary.Data
{
    public class ESchoolDiaryDbContext : DbContext, IDatabaseContext
    {
        public ESchoolDiaryDbContext()
            : base("name=DefaultConnection")
        {
        }

        public ESchoolDiaryDbContext(string connection)
           : base(connection)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserRole>()
                    .HasKey(x => new { x.RoleId, x.UserId });

            modelBuilder.Entity<IdentityUserLogin>()
                    .HasKey(l => new { l.LoginProvider, l.ProviderKey, l.UserId });
        }

        public int Save()
        {
            return base.SaveChanges();
        }
        
        public virtual DbSet<Lecture> Lectures { get; set; }
        public virtual DbSet<Mark> Marks { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<StudentClass> StudentClasses { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
