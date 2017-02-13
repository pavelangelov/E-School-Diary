using E_School_Diary.Data.DB.Contracts;
using E_School_Diary.Data.Repositories.Contracts;

namespace E_School_Diary.Data.Repositories
{
    public class StudentClassRepository : IStudentClassRepository
    {
        private IDatabaseContext dbContext;

        public StudentClassRepository(IDatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //public IQueryable<StudentClass> GetAll()
        //{
        //    var classes = this.dbContext.StudentClasses;

        //    return classes;
        //}

        //public void Add(StudentClass entity)
        //{
        //    this.dbContext.StudentClasses.Add(entity);
        //}

        public int Save()
        {
            return this.dbContext.Save();
        }
    }
}
