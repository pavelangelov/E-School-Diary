using System.Linq;

using E_School_Diary.Models.Enums;
using E_School_Diary.Utils.DTOs.Common;

namespace E_School_Diary.Data.Repositories.Contracts
{
    public interface IStudentRepository
    {
        IQueryable<IGrouping<Subject, MarkDTO>> GetStudentMarks(string studentId);

        IQueryable<LectureDTO> GetStudentLectures(string studentId);
    }
}
