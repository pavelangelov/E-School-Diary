using E_School_Diary.Data.CustomModels.Enums;
using E_School_Diary.Data.CustomModels.Models;

namespace E_School_Diary.Data.CustomModels.Contracts
{
    public interface IMark
    {
        string StudentId { get; set; }

        User Student { get; set; }

        Subject Subject { get; set; }

        double Value { get; set; }
    }
}
