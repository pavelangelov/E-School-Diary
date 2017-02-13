using System.Linq;
using System.Data.Entity;

using E_School_Diary.Data.Repositories.Contracts;
using E_School_Diary.Utils.DTOs.Common;

namespace E_School_Diary.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private IDatabaseContext dbContext;

        public StudentRepository(IDatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<LectureDTO> GetStudentLectures(string studentId)
        {
            var lectures = this.dbContext.Users.Where(x => x.Id == studentId)
                                                    .Include(st => st.Lectures)
                                                    .Select(l => l.Lectures)
                                                    .ToList()
                                                    .First()
                                                    .Select(l => new LectureDTO()
                                                    {
                                                        Title = l.Title,
                                                        Start = l.Start,
                                                        End = l.End,
                                                        Status = l.Status.ToString(),
                                                        Subject = l.Subject.ToString()
                                                    })
                                                    .AsQueryable();

            return lectures;
        }

        public IQueryable<IGrouping<string, MarkDTO>> GetStudentMarks(string studentId)
        {
            var studentMarks = this.dbContext.Marks.Where(m => m.StudentId == studentId)
                                                    .Select(m => new MarkDTO()
                                                    {
                                                        Subject = m.Subject.ToString(),
                                                        Value = m.Value
                                                    })
                                                    .GroupBy(m => m.Subject);

            return studentMarks;
        }
    }
}
