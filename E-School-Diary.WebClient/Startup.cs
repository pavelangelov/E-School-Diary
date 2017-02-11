using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(E_School_Diary.WebClient.Startup))]
namespace E_School_Diary.WebClient
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
