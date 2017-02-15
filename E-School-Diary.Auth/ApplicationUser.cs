using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;

using E_School_Diary.Data.Models;

namespace E_School_Diary.Auth
{
    public class ApplicationUser : User
    {
        public ApplicationUser()
        {
        }

        public ApplicationUser(string userName)
            : this()
        {
            this.UserName = userName;
        }

        public ClaimsIdentity GenerateUserIdentity(ApplicationUserManager manager)
        {
            var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);

            return userIdentity;
        }

        public Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager)
        {
            return Task.FromResult(GenerateUserIdentity(manager));
        }
    }
}
