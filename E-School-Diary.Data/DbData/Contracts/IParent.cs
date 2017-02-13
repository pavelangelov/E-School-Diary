using System.Collections.Generic;

using E_School_Diary.Data.DbData.Models;

namespace E_School_Diary.Data.DbData.Contracts
{
    public interface IParent
    {
        string ChildId { get; set; }

        AspNetUser Child { get; set; }

        ICollection<Message> Messages { get; set; }
    }
}
