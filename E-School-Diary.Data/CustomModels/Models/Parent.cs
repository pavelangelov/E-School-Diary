using E_School_Diary.Data.CustomModels.Contracts;
using E_School_Diary.Data.CustomModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_School_Diary.Data.CustomModels.Models
{
    public class Parent : User, IParent
    {
        public Parent()
            : base(UserTypes.Parent)
        {
            this.Messages = new HashSet<Message>();
        }

        public Parent(string userName)
            : this()
        {
            this.UserName = userName;
        }

        public string ChildId { get; set; }

        public virtual Student Child { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
    }
}
