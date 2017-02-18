using System;

namespace E_School_Diary.WebClient.Models.CustomEventArgs
{
    public class IdEventArgs : EventArgs
    {
        public IdEventArgs(string id)
        {
            this.Id = id;
        }

        public string Id { get; set; }
    }
}