using E_School_Diary.Data.DbData.Enums;

namespace E_School_Diary.Data.DbData.Contracts
{
    public interface IMark
    {
        string StudentId { get; set; }

        AspNetUser Student { get; set; }

        Subject Subject { get; set; }

        double Value { get; set; }
    }
}
