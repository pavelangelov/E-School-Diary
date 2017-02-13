using System;

namespace E_School_Diary.Data.DbData.Contracts
{
    interface IMessage
    {
        string Content { get; set; }

        string From { get; set; }

        DateTime SendOn { get; set; }
    }
}
