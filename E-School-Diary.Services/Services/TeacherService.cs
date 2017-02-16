using System;
using System.Collections.Generic;
using System.Linq;

using E_School_Diary.Data;
using E_School_Diary.Data.Enums;
using E_School_Diary.Data.Models;
using E_School_Diary.Services.Contracts;
using E_School_Diary.Utils.DTOs.Common;
using System.Data.Entity;

namespace E_School_Diary.Services
{
    public class TeacherService : ITeacherService
    {
        private IDatabaseContext dbContext;

        public TeacherService(IDatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(User entity)
        {
            this.dbContext.Users.Add(entity);
        }

        public User FindById(string teacherId)
        {
            var teacher = this.dbContext.Users.Find(teacherId);

            return teacher;
        }

        public IEnumerable<User> GetAll()
        {
            var teachers = this.dbContext.Users.Where(x => x.UserType == UserTypes.Teacher);

            return teachers;
        }

        public IEnumerable<StudentClassDTO> GetTeacherClasses(string teacherId)
        {
            var teacher = this.dbContext.Users.Include(t => t.StudentClasses)
                                                .Single(t => t.Id == teacherId);

            var ownClass = this.dbContext.StudentClasses.First(st => st.FormMasterId == teacherId);
            var classes = new List<StudentClassDTO>();
            if (ownClass != null)
            {
                classes.Add(new StudentClassDTO() {Id = ownClass.Id, Name = ownClass.Name });
            }

            foreach (var cl in teacher.StudentClasses)
            {
                classes.Add(new StudentClassDTO() { Id = cl.Id, Name = cl.Name });
            }

            return classes;
        }

        public IEnumerable<MinTeacherInfoDTO> GetTeachersWithoutClass()
        {
            var freeTeachers = this.dbContext.Users
                                            .Where(u => u.UserType == UserTypes.Teacher && 
                                                        u.IsFreeTeacher == true)
                                            .Select(t => new MinTeacherInfoDTO()
                                            {
                                                Id = t.Id,
                                                FirstName = t.FirstName,
                                                LastName = t.LastName,
                                                SubjectName = t.Subject.ToString()
                                            });
            return freeTeachers;
        }

        public int Save()
        {
            return dbContext.Save();
        }
    }
}
