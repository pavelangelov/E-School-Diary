using System;
using System.Data.Entity;
using System.Linq;

using E_School_Diary.Data;
using E_School_Diary.Data.Models;
using E_School_Diary.Services.Contracts;

namespace E_School_Diary.Services
{
    public class LectureService : ILectureService
    {
        private IDatabaseContext dbContext;

        public LectureService(IDatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Tuple<string, string>[] GetLectureHours()
        {
            return this.LectureHours;
        }

        public Lecture FindById(string lectureId)
        {
            var lecture = this.dbContext.Lectures.Include(l => l.StudentClass)
                                                   .Include(l => l.Teacher)     
                                                   .FirstOrDefault(l => l.Id == lectureId);
            return lecture;
        }

        public int Save()
        {
            return this.dbContext.Save();
        }

        public readonly Tuple<string, string>[] LectureHours = new Tuple<string, string>[]
        {
            new Tuple<string, string>("8 00", "8:00"),
            new Tuple<string, string>("8 30", "8:30"),
            new Tuple<string, string>("9 00", "9:00"),
            new Tuple<string, string>("9 30", "9:30"),
            new Tuple<string, string>("10 00", "10:00"),
            new Tuple<string, string>("10 30", "10:30"),
            new Tuple<string, string>("11 00", "11:00"),
            new Tuple<string, string>("11 30", "11:30"),
            new Tuple<string, string>("12 00", "12:00"),
            new Tuple<string, string>("12 30", "12:30"),
            new Tuple<string, string>("13 00", "13:00"),
            new Tuple<string, string>("13 30", "13:30"),
            new Tuple<string, string>("14 00", "14:00"),
            new Tuple<string, string>("14 30", "14:30"),
            new Tuple<string, string>("15 00", "15:00"),
            new Tuple<string, string>("15 30", "15:30"),
            new Tuple<string, string>("16 00", "16:00"),
            new Tuple<string, string>("16 30", "16:30"),
            new Tuple<string, string>("17 00", "17:00"),
            new Tuple<string, string>("17 30", "17:30"),
            new Tuple<string, string>("18 00", "18:00")
        };
    }
}
