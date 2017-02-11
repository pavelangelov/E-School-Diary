using System;

namespace E_School_Diary.Utils.Contracts
{
    public interface IDateParser
    {
        DateTime ExtractDate(string dateStr);

        int ConvertMonthToNumber(string monthName);
    }
}
