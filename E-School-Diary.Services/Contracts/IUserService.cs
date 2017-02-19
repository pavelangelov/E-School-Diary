using E_School_Diary.Data.Models;
using E_School_Diary.Utils.DTOs.Common;

namespace E_School_Diary.Services.Contracts
{
    public interface IUserService
    {
        User FindById(string id);

        UserDTO GetMinInfo(string userId);

        int Save();
    }
}
