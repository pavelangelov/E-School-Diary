using System;

namespace E_School_Diary.WebClient.Models.CustomEventArgs
{
    public class FileUploadEventArgs : EventArgs
    {
        public FileUploadEventArgs(string userId, string filePath, string fileName)
        {
            this.UserId = userId;
            this.FilePath = filePath;
            this.FileName = fileName;
        }

        public string UserId { get; set; }

        public string FilePath { get; set; }

        public string FileName { get; set; }
    }
}