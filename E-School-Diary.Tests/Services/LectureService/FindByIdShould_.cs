using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using Moq;
using NUnit.Framework;

using E_School_Diary.Data;
using E_School_Diary.Data.Models;
using E_School_Diary.Services;

namespace E_School_Diary.Tests.Services.LectureServiceTests
{
    [TestFixture]
    public class FindByIdShould_
    {
        private string searchedLectureId = Guid.NewGuid().ToString();
        private string lecturesTitle;

        [Test]
        public void ReturnRightLecture()
        {
            var lectures = this.GetLectures();
            var mockDbContext = new Mock<IDatabaseContext>();
            var mockSet = new Mock<IDbSet<Lecture>>();

            mockSet.As<IQueryable<Lecture>>().Setup(m => m.Provider).Returns(lectures.Provider);
            mockSet.As<IQueryable<Lecture>>().Setup(m => m.Expression).Returns(lectures.Expression);
            mockSet.As<IQueryable<Lecture>>().Setup(m => m.ElementType).Returns(lectures.ElementType);

            mockDbContext.Setup(c => c.Lectures).Returns(mockSet.Object);


            var lectureService = new LectureService(mockDbContext.Object);
            var lecture = lectureService.FindById(this.searchedLectureId);

            Assert.AreEqual(this.lecturesTitle, lecture.Title);
            Assert.AreEqual(this.searchedLectureId, lecture.Id);
        }

        [Test]
        public void ReturnNull_IfLectureNotFound()
        {
            var lectures = this.GetLectures();
            var mockDbContext = new Mock<IDatabaseContext>();
            var mockSet = new Mock<IDbSet<Lecture>>();

            mockSet.As<IQueryable<Lecture>>().Setup(m => m.Provider).Returns(lectures.Provider);
            mockSet.As<IQueryable<Lecture>>().Setup(m => m.Expression).Returns(lectures.Expression);
            mockSet.As<IQueryable<Lecture>>().Setup(m => m.ElementType).Returns(lectures.ElementType);

            mockDbContext.Setup(c => c.Lectures).Returns(mockSet.Object);

            var lectureId = Guid.NewGuid().ToString();
            var lectureService = new LectureService(mockDbContext.Object);
            var lecture = lectureService.FindById(lectureId);

            Assert.IsNull(lecture);
        }

        public IQueryable<Lecture> GetLectures()
        {
            var lectures = new List<Lecture>()
            {
                new Lecture()
                {
                 Title="Title"
                },
                new Lecture()
                {
                 Title="Title2"
                },
                new Lecture()
                {
                 Title="Title3"
                },
                new Lecture()
                {
                 Title="Title4"
                }
            };

            lectures[3].Id = this.searchedLectureId;
            this.lecturesTitle = lectures[3].Title;

            return lectures.AsQueryable();
        }
    }
}
