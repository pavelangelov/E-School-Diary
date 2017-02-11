using Ninject.Modules;

using E_School_Diary.Utils;
using E_School_Diary.Utils.Contracts;

namespace E_School_Diary.WebClient.Modules
{
    public class StudentsNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IDateParser>().To<DateParser>();
        }
    }
}