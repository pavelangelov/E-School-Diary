using System.Collections.Generic;

using E_School_Diary.Data.CustomModels.Models;

namespace E_School_Diary.Data.CustomModels.Contracts
{
    public interface IParent
    {
        string ChildId { get; set; }

        User Child { get; set; }

        ICollection<Message> Messages { get; set; }
    }
}
