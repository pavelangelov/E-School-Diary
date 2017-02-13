﻿using Ninject.Modules;

using E_School_Diary.Utils;
using E_School_Diary.Utils.Contracts;
using E_School_Diary.Data;
using E_School_Diary.Data.Repositories.Contracts;
using E_School_Diary.Data.Repositories;
using E_School_Diary.Data.EF_DataSource;

namespace E_School_Diary.WebClient.Modules
{
    public class StudentsNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IDateParser>().To<DateParser>();
            this.Bind<IDatabaseContext>().To<ESchoolDiaryEntities>();
            this.Bind<IStudentClassRepository>().To<StudentClassRepository>();
            this.Bind<ITeacherRepository>().To<TeacherRepository>();
            this.Bind<IStudentRepository>().To<StudentRepository>();
        }
    }
}