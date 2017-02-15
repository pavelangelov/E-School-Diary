using E_School_Diary.Data.Models;

namespace E_School_Diary.Factories.Contracts
{
    public interface IStudentClassFactory
    {
        StudentClass CreateClass(string className, string teacherId);
    }
}
