using Ninject.Modules;
using Ninject.Web.Common;

using E_School_Diary.Data;
using E_School_Diary.Factories;
using E_School_Diary.Factories.Contracts;
using E_School_Diary.Services;
using E_School_Diary.Services.Contracts;
using E_School_Diary.Utils;
using E_School_Diary.Utils.Contracts;

namespace E_School_Diary.WebClient.Modules
{
    public class StudentsNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IDateParser>().To<DateParser>();
            this.Bind<IDatabaseContext>().To<ESchoolDiaryDbContext>().InRequestScope();

            this.Bind<IStudentClassService>().To<StudentClassService>();
            this.Bind<ITeacherService>().To<TeacherService>();
            this.Bind<IStudentService>().To<StudentService>();
            this.Bind<ILectureService>().To<LectureService>();
            this.Bind<IMarkService>().To<MarkService>();
            this.Bind<IParentService>().To<ParentService>();
            this.Bind<IUserService>().To<UserService>();

            this.Bind<IAppicationUserFactory>().To<ApplicationUserFactory>();
            this.Bind<IStudentClassFactory>().To<StudentClassFactory>();
            this.Bind<ILectureFactory>().To<LectureFactory>();
            this.Bind<IMarkFactory>().To<MarkFactory>();
            this.Bind<IMessageFactory>().To<MessageFactory>();
        }
    }
}