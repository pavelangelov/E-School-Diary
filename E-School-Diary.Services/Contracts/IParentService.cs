﻿using System.Collections.Generic;
using System.Linq;

using E_School_Diary.Utils.DTOs.Common;

namespace E_School_Diary.Services.Contracts
{
    public interface IParentService
    {
        IEnumerable<IGrouping<string, MarkDTO>> GetChildMarks(string parentId);

        IEnumerable<ParentDTO> FindParents(string studentId);

        int Save();
    }
}
