using System.Linq;

using E_School_Diary.Utils.DTOs.Common;

namespace E_School_Diary.Data.Repositories.Contracts
{
    public interface IStudentRepository
    {
        IQueryable<IGrouping<string, MarkDTO>> GetStudentMarks(string studentId);

        IQueryable<LectureDTO> GetStudentLectures(string studentId);
    }
}
