using System;
using System.Collections.Generic;

using NUnit.Framework;

using E_School_Diary.Data.Enums;
using E_School_Diary.Factories;
using E_School_Diary.Utils.DTOs.RegisterDTOs;

namespace E_School_Diary.Tests.Factories
{
    [TestFixture]
    public class CraeteTeacherShould_
    {
        [Test]
        public void NotToThrow_AndReturnNewApplicationUser()
        {
            var teachers = this.GetTeachers();
            var userFactory = new ApplicationUserFactory();

            foreach (var teacher in teachers)
            {
                var user = userFactory.CreateTeacher(teacher);

                Assert.AreEqual(teacher.Age, user.Age);
                Assert.AreEqual(teacher.LastName, user.LastName);
                Assert.AreEqual(teacher.FirstName, user.FirstName);
                Assert.IsTrue(user.UserType == UserTypes.Teacher);
            }
        }

        public IEnumerable<RegisterTeacherDTO> GetTeachers()
        {
            var teachers = new List<RegisterTeacherDTO>()
            {
                new RegisterTeacherDTO
                {
                    StudentClassId=Guid.NewGuid().ToString(),
                    Age=30,
                    Email="pesho@mail.bg",
                    FirstName ="Pesho",
                    LastName ="Kirov",
                    Subject = Subject.Art.ToString()
                },
                new RegisterTeacherDTO
                {
                    StudentClassId=Guid.NewGuid().ToString(),
                    Age=30,
                    Email="gosho@mail.bg",
                    FirstName ="Gosho",
                    LastName ="Kirov",
                    Subject = Subject.Art.ToString()
                },
                new RegisterTeacherDTO
                {
                    StudentClassId=Guid.NewGuid().ToString(),
                    Age=30,
                    Email="petko@mail.bg",
                    FirstName ="Petko",
                    LastName ="Kirov",
                    Subject = Subject.Art.ToString()
                },
                new RegisterTeacherDTO
                {
                    StudentClassId =Guid.NewGuid().ToString(),
                    Age=30,
                    Email="lesho@mail.bg",
                    FirstName ="Lesho",
                    LastName ="Kirov",
                    Subject = Subject.Art.ToString()
                }
            };

            return teachers;
        }
    }
}
