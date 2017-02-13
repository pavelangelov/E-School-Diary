using System;
using System.ComponentModel.DataAnnotations;

using E_School_Diary.Data.CustomModels.Contracts;
using E_School_Diary.Utils;

namespace E_School_Diary.Data.CustomModels.Models
{
    public partial class Message : IMessage, IIdentifiable
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
            this.SendFrom = from;
        }

        [StringLength(128)]
        public string Id { get; set; }

        [Required]
        [MinLength(Constants.ContentMinLength, ErrorMessage = Constants.ContentErrorMessage)]
        [MaxLength(Constants.ContentMaxLength, ErrorMessage = Constants.ContentErrorMessage)]
        public string Content { get; set; }
        
        [Required]
        [MinLength(Constants.SendFromMinLength, ErrorMessage = Constants.SendFromErrorMessage)]
        [MaxLength(Constants.SendFromMaxLength, ErrorMessage = Constants.SendFromErrorMessage)]
        public string SendFrom { get; set; }

        public DateTime SendOn { get; set; }
    }
}
