using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using E_School_Diary.Data;
using E_School_Diary.Services.Contracts;
using E_School_Diary.Utils.DTOs.Common;

namespace E_School_Diary.Services
{
    public class StudentService : IStudentService
    {
        private IDatabaseContext dbContext;

        public StudentService(IDatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<LectureDTO> GetStudentLectures(string studentId)
        {
            var student = this.dbContext.Users.Include(u => u.Lectures)
                                                    .FirstOrDefault(u => u.Id == studentId);

            var lectures = student.Lectures.Select(l => new LectureDTO()
                                                {
                                                    Title = l.Title,
                                                    Start = l.Start,
                                                    End = l.End,
                                                    Status = l.Status.ToString(),
                                                    Subject = l.Subject.ToString()
                                                });

            return lectures;
        }

        public IEnumerable<IGrouping<string, MarkDTO>> GetStudentMarks(string studentId)
        {
            var student = this.dbContext.Users.Include(u => u.Lectures)
                                                    .FirstOrDefault(u => u.Id == studentId);
            var marks = student.Marks.Select(m => new MarkDTO()
                                              {
                                                  Subject = m.Subject.ToString(),
                                                  Value = m.Value
                                              })
                                              .GroupBy(m => m.Subject);

            return marks;
        }
    }
}
