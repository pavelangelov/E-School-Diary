using E_School_Diary.Models.Enums;
using E_School_Diary.Models.Models;

namespace E_School_Diary.Models.Contracts
{
    public interface IMark
    {
        string StudentId { get; set; }

        AppUser Student { get; set; }

        Subject Subject { get; set; }

        double Value { get; set; }
    }
}
