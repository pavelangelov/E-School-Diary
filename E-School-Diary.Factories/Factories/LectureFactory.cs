using E_School_Diary.Factories.Contracts;
using System;
using E_School_Diary.Data.Models;
using E_School_Diary.Data.Enums;
using E_School_Diary.Utils.DTOs;

namespace E_School_Diary.Factories
{
    public class LectureFactory : ILectureFactory
    {
        public Lecture CreateLecture(CreateLectureDTO lectureDTO)
        {
            var lecture = new Lecture()
            {
                TeacherId = lectureDTO.TeacherId,
                StudentClassId = lectureDTO.StudentClassId,
                Title = lectureDTO.Title,
                Start = lectureDTO.Start,
                End = lectureDTO.End,
                Status = LectureStatus.Ahead,
                Subject = (Subject)Enum.Parse(typeof(Subject), lectureDTO.SubjectName)
            };

            return lecture;
        }
    }
}
