using System;

using E_School_Diary.Models.Contracts;

namespace E_School_Diary.Models.Models.DataModels
{
    public class Message : IMessage, IIdentifiable
    {
        public Message()
        {
            this.Id = Guid.NewGuid().ToString();
            this.SendOn = DateTime.Now;
        }

        public Message(string content, string from)
            : this()
        {
            this.Content = content;
            this.From = from;
        }

        public string Id { get; set; }

        public string Content { get; set; }

        public string From { get; set; }

        public DateTime SendOn { get; set; }
    }
}
