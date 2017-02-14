using System.Collections.Generic;
using System.Linq;

using E_School_Diary.Utils.DTOs.Common;

namespace E_School_Diary.Services.Contracts
{
    public interface IStudentService
    {
        IEnumerable<IGrouping<string, MarkDTO>> GetStudentMarks(string studentId);

        IEnumerable<LectureDTO> GetStudentLectures(string studentId);
    }
}
