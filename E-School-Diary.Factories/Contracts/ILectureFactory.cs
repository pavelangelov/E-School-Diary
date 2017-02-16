using E_School_Diary.Data.Models;
using E_School_Diary.Utils.DTOs;

namespace E_School_Diary.Factories.Contracts
{
    public interface ILectureFactory
    {
        Lecture CreateLecture(CreateLectureDTO lectureDTO);
    }
}
