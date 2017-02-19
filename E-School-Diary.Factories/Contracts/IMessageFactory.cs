using E_School_Diary.Data.Models;
using E_School_Diary.Utils.DTOs.Common;

namespace E_School_Diary.Factories.Contracts
{
    public interface IMessageFactory
    {
        Message CreateMessage(MessageDTO messageDTO);
    }
}
