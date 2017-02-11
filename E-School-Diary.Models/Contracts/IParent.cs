using System.Collections.Generic;

using E_School_Diary.Models.Models;
using E_School_Diary.Models.Models.DataModels;

namespace E_School_Diary.Models.Contracts
{
    public interface IParent
    {
        string ChildId { get; set; }

        AppUser Child { get; set; }

        ICollection<Message> Messages { get; set; }
    }
}
