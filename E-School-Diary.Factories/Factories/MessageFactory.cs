using E_School_Diary.Data.Models;
using E_School_Diary.Factories.Contracts;
using E_School_Diary.Utils.DTOs.Common;

namespace E_School_Diary.Factories
{
    public class MessageFactory : IMessageFactory
    {
        public Message CreateMessage(MessageDTO messageDTO)
        {
            var message = new Message()
            {
                Content = messageDTO.Content,
                SendFrom = messageDTO.From,
                SendOn = messageDTO.SendOn
            };

            return message;
        }
    }
}
