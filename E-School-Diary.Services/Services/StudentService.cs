using System;
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

        public IEnumerable<StudentDTO> FindByStudentClassId(string studentClassId)
        {
            var students = this.dbContext.Users.Where(u => u.UserType == Data.Enums.UserTypes.Student &&
                                                      u.StudentClassId == studentClassId)
                                                      .Select(st => new StudentDTO
                                                      {
                                                          Id = st.Id,
                                                          FirstName = st.FirstName,
                                                          MiddleName = st.MiddleName,
                                                          LastName = st.LastName
                                                      });
            return students;
        }

        public IEnumerable<LectureDTO> GetStudentLectures(string studentId)
        {
            var student = this.dbContext.Users.FirstOrDefault(u => u.Id == studentId);

            var lectures = this.dbContext.Lectures.Where(l => l.StudentClassId == student.StudentClassId) 
                                                     .Select(l => new LectureDTO()
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
