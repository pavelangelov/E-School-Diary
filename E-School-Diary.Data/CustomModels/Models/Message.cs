using System;
using System.ComponentModel.DataAnnotations;

using E_School_Diary.Data.Contracts;
using E_School_Diary.Utils;

namespace E_School_Diary.Data.Models
{
    public partial class Message : IMessage, IIdentifiable
    {
        private string content;
        private string sendFrom;

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
        public string Content
        {
            get
            {
                return this.content;
            }

            set
            {
                var minLength = Constants.ContentMinLength;
                var maxLength = Constants.ContentMaxLength;
                var errorMsg = Constants.ContentErrorMessage;

                Utils.Validator.ValidateStringLength(value, maxLength, minLength, "Content", errorMsg);

                this.content = value;
            }
        }
        
        [Required]
        [MinLength(Constants.SendFromMinLength, ErrorMessage = Constants.SendFromErrorMessage)]
        [MaxLength(Constants.SendFromMaxLength, ErrorMessage = Constants.SendFromErrorMessage)]
        public string SendFrom
        {
            get
            {
                return this.sendFrom;
            }

            set
            {
                var minLength = Constants.SendFromMinLength;
                var maxLength = Constants.SendFromMaxLength;
                var errorMsg = Constants.SendFromErrorMessage;

                Utils.Validator.ValidateStringLength(value, maxLength, minLength, "SendFrom", errorMsg);

                this.sendFrom = value;
            }
        }

        public DateTime SendOn { get; set; }
    }
}
