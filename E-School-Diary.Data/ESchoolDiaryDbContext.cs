using E_School_Diary.Data.Models;
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
        
        public virtual IDbSet<Lecture> Lectures { get; set; }
        public virtual IDbSet<Mark> Marks { get; set; }
        public virtual IDbSet<Message> Messages { get; set; }
        public virtual IDbSet<StudentClass> StudentClasses { get; set; }
        public virtual IDbSet<User> Users { get; set; }
    }
}
