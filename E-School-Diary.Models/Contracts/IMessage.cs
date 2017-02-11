using System;

namespace E_School_Diary.Models.Contracts
{
    interface IMessage
    {
        string Content { get; set; }

        string From { get; set; }

        DateTime SendOn { get; set; }
    }
}
