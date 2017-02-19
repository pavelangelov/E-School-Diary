using E_School_Diary.Data;
using E_School_Diary.Data.Models;
using E_School_Diary.Services.Contracts;
using E_School_Diary.Utils.DTOs.Common;

namespace E_School_Diary.Services
{
    public class UserService : IUserService
    {
        private IDatabaseContext dbContext;

        public UserService(IDatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public User FindById(string id)
        {
            var user = this.dbContext.Users.Find(id);

            return user;
        }

        public UserDTO GetMinInfo(string userId)
        {
            var dbUser = this.dbContext.Users.Find(userId);
            var userDTO = new UserDTO()
            {
                FirstName = dbUser.FirstName,
                MiddleName = dbUser.MiddleName,
                LastName = dbUser.LastName,
                Username = dbUser.UserName,
                ImageUrl = dbUser.ImageUrl
            };

            return userDTO;
                
        }

        public int Save()
        {
            return this.dbContext.Save();
        }
    }
}
