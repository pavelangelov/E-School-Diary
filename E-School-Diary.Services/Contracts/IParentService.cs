using System.Collections.Generic;
using System.Linq;

using E_School_Diary.Utils.DTOs.Common;
using E_School_Diary.Data.Models;

namespace E_School_Diary.Services.Contracts
{
    public interface IParentService
    {
        IEnumerable<IGrouping<string, MarkDTO>> GetChildMarks(string parentId);

        IEnumerable<User> FindParents(string studentId);

        IEnumerable<MessageDTO> GetParentMessages(string parentId);

        string GetChildId(string parentId);

        int Save();
    }
}
