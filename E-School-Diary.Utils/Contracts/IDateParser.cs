using System;

namespace E_School_Diary.Utils.Contracts
{
    public interface IDateParser
    {
        DateTime ExtractDate(string dateStr);

        DateTime GetDate(string date, string hour);

        int ConvertMonthToNumber(string monthName);
    }
}
