using E_School_Diary.Data;
using E_School_Diary.Data.Models;
using E_School_Diary.Services.Contracts;
using E_School_Diary.Utils.DTOs.Common;
using System.Linq;

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
            var user = this.dbContext.Users.FirstOrDefault(u => u.Id == id);

            return user;
        }

        public UserDTO GetMinInfo(string userId)
        {
            var dbUser = this.dbContext.Users.FirstOrDefault(u => u.Id == userId);
            if (dbUser == null)
            {
                return null;
            }

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
