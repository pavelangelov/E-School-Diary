using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using E_School_Diary.Data;
using E_School_Diary.Data.Enums;
using E_School_Diary.Data.Models;
using E_School_Diary.Services.Contracts;
using E_School_Diary.Utils;
using E_School_Diary.Utils.DTOs.Common;
using E_School_Diary.Utils.DTOs;
using System;

namespace E_School_Diary.Services
{
    public class TeacherService : ITeacherService
    {
        private IDatabaseContext dbContext;

        public TeacherService(IDatabaseContext dbContext)
        {
            Validator.ValidateForNull(dbContext, "dbContext");
            this.dbContext = dbContext;
        }

        public void Add(User entity)
        {
            this.dbContext.Users.Add(entity);
        }

        public User FindById(string teacherId)
        {
            var teacher = this.dbContext.Users.Include(t => t.Lectures)
                                                .Include(t => t.StudentClasses)
                                                .FirstOrDefault(t => t.Id == teacherId);

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

            var ownClass = this.dbContext.StudentClasses.FirstOrDefault(st => st.FormMasterId == teacherId);
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

        public IEnumerable<ChangeLectureStatusDTO> GetTeacherActualLectures(string teacherId, DateTime startDate)
        {
            var teacher = this.dbContext.Users.Include(st => st.Lectures).FirstOrDefault(st => st.Id == teacherId);
            var lectures = teacher.Lectures.Where(l => l.Start >= startDate)
                                            .Select(l => new ChangeLectureStatusDTO()
                                            {
                                                Id = l.Id,
                                                Title = l.Title,
                                                ClassName = l.StudentClass.Name,
                                                Start = l.Start,
                                                End = l.End,
                                                Status = l.Status.ToString()
                                            });
            return lectures;
        }

        public int Save()
        {
            return dbContext.Save();
        }
    }
}
