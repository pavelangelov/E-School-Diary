using System;

using E_School_Diary.Auth;
using E_School_Diary.Data.Enums;
using E_School_Diary.Factories.Contracts;
using E_School_Diary.Utils;
using E_School_Diary.Utils.DTOs.RegisterDTOs;

namespace E_School_Diary.Factories
{
    public class ApplicationUserFactory : IAppicationUserFactory
    {
        public ApplicationUser CreateParent(RegisterParentDTO parentDTO)
        {
            var appUser = new ApplicationUser()
            {
                UserName = parentDTO.Email,
                Email = parentDTO.Email,
                FirstName = parentDTO.FirstName,
                LastName = parentDTO.LastName,
                Age = parentDTO.Age,
                UserType = UserTypes.Parent,
                ChildId = parentDTO.ChildId,
                ImageUrl = Constants.DefaultParentImage
            };

            return appUser;
        }

        public ApplicationUser CreateStudent(RegisterStudentDTO studentDTO)
        {
            var appUser = new ApplicationUser()
            {
                UserName = studentDTO.Email,
                Email = studentDTO.Email,
                FirstName = studentDTO.FirstName,
                LastName = studentDTO.LastName,
                StudentClassId = studentDTO.StudentClassId,
                Age = studentDTO.Age,
                UserType = UserTypes.Student,
                ImageUrl = Constants.DefaultStudentImage
            };

            return appUser;
        }

        public ApplicationUser CreateTeacher(RegisterTeacherDTO teacherDTO)
        {
            var teacher = new ApplicationUser()
            {
                UserName = teacherDTO.Email,
                Email = teacherDTO.Email,
                FirstName = teacherDTO.FirstName,
                LastName = teacherDTO.LastName,
                Age = teacherDTO.Age,
                UserType = UserTypes.Teacher,
                IsFreeTeacher = true,
                Subject = (Subject)Enum.Parse(typeof(Subject), teacherDTO.Subject),
                ImageUrl = Constants.DefaultTeacherImage
            };

            return teacher;
        }
    }
}
