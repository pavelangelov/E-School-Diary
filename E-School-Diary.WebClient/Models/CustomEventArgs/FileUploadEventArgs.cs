using System;

namespace E_School_Diary.WebClient.Models.CustomEventArgs
{
    public class FileUploadEventArgs : EventArgs
    {
        public FileUploadEventArgs(string userId, string filePath)
        {
            this.UserId = userId;
            this.FilePath = filePath;
        }

        public string UserId { get; set; }

        public string FilePath { get; set; }
    }
}