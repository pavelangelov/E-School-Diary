using System;
using System.Collections.Generic;

using E_School_Diary.Data.Models;
using E_School_Diary.Utils.DTOs;
using E_School_Diary.Utils.DTOs.Common;

namespace E_School_Diary.Services.Contracts
{
    public interface ITeacherService
    {
        IEnumerable<User> GetAll();

        User FindById(string teacherId);

        IEnumerable<MinTeacherInfoDTO> GetTeachersWithoutClass();

        IEnumerable<StudentClassDTO> GetTeacherClasses(string teacherId);

        IEnumerable<ChangeLectureStatusDTO> GetTeacherActualLectures(string teacherId, DateTime startDate);

        void Add(User entity);

        int Save();
    }
}
