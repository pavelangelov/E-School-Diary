using System;
using System.Collections.Generic;

using NUnit.Framework;

using E_School_Diary.Data.Enums;
using E_School_Diary.Factories;
using E_School_Diary.Utils.DTOs.RegisterDTOs;

namespace E_School_Diary.Tests.Factories
{
    [TestFixture]
    public class CreateStudentShould_
    {
        [Test]
        public void NotToThrow_AndReturnNewApplicationUser()
        {
            var students = this.GetStudents();
            var userFactory = new ApplicationUserFactory();

            foreach (var student in students)
            {
                var user = userFactory.CreateStudent(student);

                Assert.AreEqual(student.Age, user.Age);
                Assert.AreEqual(student.LastName, user.LastName);
                Assert.AreEqual(student.FirstName, user.FirstName);
                Assert.IsTrue(user.UserType == UserTypes.Student);
            }
        }

        public IEnumerable<RegisterStudentDTO> GetStudents()
        {
            var students = new List<RegisterStudentDTO>()
            {
                new RegisterStudentDTO
                {
                    FormMasterId=Guid.NewGuid().ToString(),
                    StudentClassId = Guid.NewGuid().ToString(),
                    Age=30,
                    Email="pesho@mail.bg",
                    FirstName ="Pesho",
                    LastName ="Kirov"
                },
                new RegisterStudentDTO
                {
                    FormMasterId=Guid.NewGuid().ToString(),
                    StudentClassId = Guid.NewGuid().ToString(),
                    Age=40,
                    Email="gosho@mail.bg",
                    FirstName ="Gosho",
                    LastName ="Kirov",
                },
                new RegisterStudentDTO
                {
                    FormMasterId=Guid.NewGuid().ToString(),
                    StudentClassId = Guid.NewGuid().ToString(),
                    Age=30,
                    Email="mitko@mail.bg",
                    FirstName ="Mitko",
                    LastName ="Kirov"
                },
                new RegisterStudentDTO
                {
                    FormMasterId=Guid.NewGuid().ToString(),
                    StudentClassId = Guid.NewGuid().ToString(),
                    Age=30,
                    Email="kiro@mail.bg",
                    FirstName ="Kiro",
                    LastName ="Kirov"
                }
            };

            return students;
        }
    }
}
