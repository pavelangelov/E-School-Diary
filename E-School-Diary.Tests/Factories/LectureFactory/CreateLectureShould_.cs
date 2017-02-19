using System;

using NUnit.Framework;
using System.Collections.Generic;
using E_School_Diary.Utils.DTOs;
using E_School_Diary.Data.Enums;
using E_School_Diary.Factories;
using E_School_Diary.Data.Models;

namespace E_School_Diary.Tests.Factories
{
    [TestFixture]
    public class CreateLectureShould_
    {
        [Test]
        public void NotToThrow_AndReturnNewLecture()
        {
            var lecturesDTO = this.GetLectures();
            var lectureFactory = new LectureFactory();

            foreach (var lectureDTO in lecturesDTO)
            {
                var lecture = lectureFactory.CreateLecture(lectureDTO);

                Assert.AreEqual(lectureDTO.StudentClassId, lecture.StudentClassId);
                Assert.AreEqual(lectureDTO.TeacherId, lecture.TeacherId);
                Assert.AreEqual(lectureDTO.SubjectName, lecture.Subject.ToString());
                Assert.AreEqual(lectureDTO.Title, lecture.Title);
                Assert.AreEqual(lectureDTO.Start, lecture.Start);
                Assert.AreEqual(lectureDTO.End, lecture.End);
                Assert.AreEqual(typeof(Lecture), lecture.GetType());
            }
        }

        public IEnumerable<CreateLectureDTO> GetLectures()
        {
            var lectures = new List<CreateLectureDTO>()
            {
                new CreateLectureDTO()
                {
                    StudentClassId = Guid.NewGuid().ToString(),
                    TeacherId = Guid.NewGuid().ToString(),
                    SubjectName = Subject.Art.ToString(),
                    Title = "Title",
                    Start = DateTime.Now.AddHours(1),
                    End = DateTime.Now.AddHours(2)
                },
                new CreateLectureDTO()
                {
                    StudentClassId = Guid.NewGuid().ToString(),
                    TeacherId = Guid.NewGuid().ToString(),
                    SubjectName = Subject.Art.ToString(),
                    Title = "Title1",
                    Start = DateTime.Now.AddHours(2),
                    End = DateTime.Now.AddHours(3)
                },
                new CreateLectureDTO()
                {
                    StudentClassId = Guid.NewGuid().ToString(),
                    TeacherId = Guid.NewGuid().ToString(),
                    SubjectName = Subject.Art.ToString(),
                    Title = "Title2",
                    Start = DateTime.Now.AddHours(3),
                    End = DateTime.Now.AddHours(4)
                }
            };

            return lectures;
        }
    }
}
