using E_School_Diary.Data.Enums;
using E_School_Diary.Data.Models;

namespace E_School_Diary.Data.Contracts
{
    public interface IMark
    {
        string StudentId { get; set; }

        User Student { get; set; }

        Subject Subject { get; set; }

        double Value { get; set; }
    }
}
