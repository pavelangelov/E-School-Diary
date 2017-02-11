using System.Collections.Generic;

using Microsoft.AspNet.Identity.EntityFramework;

using E_School_Diary.Models.Contracts;
using E_School_Diary.Models.Enums;
using E_School_Diary.Models.Models.DataModels;

namespace E_School_Diary.Models.Models
{
    public class AppUser : IdentityUser, IPerson, ITeacher, IStudent, IParent
    {
        private ICollection<AppUser> parents;
        private ICollection<Mark> marks;
        private ICollection<Lecture> lectures;
        private ICollection<Message> messages;

        public AppUser()
        {
            this.parents = new HashSet<AppUser>();
            this.marks = new HashSet<Mark>();
            this.lectures = new HashSet<Lecture>();
            this.Messages = new HashSet<Message>();
        }

        public AppUser(string userName)
            : this()
        {
            this.UserName = userName;
        }
        public string AdditionalInfo { get; set; }

        public int Age { get; set; }

        public AppUser Child { get; set; }

        public string ChildId { get; set; }

        public string ConfirmIdentity { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string ImageUrl { get; set; }

        public AppUser FormMaster { get; set; }

        public string FormMasterId { get; set; }

        public StudentClass StudentClass { get; set; }

        public string StudentClassId { get; set; }

        public Subject Subject { get; set; }

        public virtual ICollection<Lecture> Lectures
        {
            get
            {
                return this.lectures;
            }

            set
            {
                this.lectures = value;
            }
        }

        public virtual ICollection<Mark> Marks
        {
            get
            {
                return this.marks;
            }

            set
            {
                this.marks = value;
            }
        }

        public virtual ICollection<AppUser> Parents
        {
            get
            {
                return this.parents;
            }

            set
            {
                this.parents = value;
            }
        }

        public ICollection<Message> Messages
        {
            get
            {
                return this.messages;
            }

            set
            {
                this.messages = value;
            }
        }
    }
}
