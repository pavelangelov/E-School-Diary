using System.Linq;
using System.Data.Entity;

using E_School_Diary.Data.Repositories.Contracts;
using E_School_Diary.Utils.DTOs.Common;
using E_School_Diary.Models.Enums;

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
            var lectures = this.dbContext.AppUsers.Where(x => x.Id == studentId)
                                                    .Include(st => st.Lectures)
                                                    .Select(l => l.Lectures)
                                                    .ToList()
                                                    .First()
                                                    .Select(l => new LectureDTO()
                                                    {
                                                        Title = l.Title,
                                                        Start = l.Start,
                                                        End = l.End,
                                                        Status = (LectureStatus)l.Status,
                                                        Subject = (Subject)l.Subject
                                                    })
                                                    .AsQueryable();

            return lectures;
        }

        public IQueryable<IGrouping<Subject, MarkDTO>> GetStudentMarks(string studentId)
        {
            var studentMarks = this.dbContext.Marks.Where(m => m.StudentId == studentId)
                                                    .Select(m => new MarkDTO()
                                                    {
                                                        Subject = (Subject)m.Subject,
                                                        Value = m.Value
                                                    })
                                                    .GroupBy(m => m.Subject);

            return studentMarks;
        }
    }
}
