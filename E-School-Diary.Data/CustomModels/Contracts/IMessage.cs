using System;

namespace E_School_Diary.Data.Contracts
{
    interface IMessage
    {
        string Content { get; set; }

        string SendFrom { get; set; }

        DateTime SendOn { get; set; }
    }
}
