using System;

using E_School_Diary.Utils.Contracts;

namespace E_School_Diary.Utils
{
    public class DateParser : IDateParser
    {
        public int ConvertMonthToNumber(string monthName)
        {
            var symbol = monthName[0];
            switch (symbol)
            {
                case 'J':
                    if (monthName == "January")
                    {
                        return 1;
                    }
                    else
                    {
                        return monthName == "June" ? 6 : 7;
                    }
                case 'F':
                    return 2;
                case 'M':
                    return monthName == "March" ? 3 : 5;
                case 'A':
                    return monthName == "April" ? 4 : 8;
                case 'S':
                    return 9;
                case 'O':
                    return 10;
                case 'N':
                    return 11;
                case 'D':
                    return 12;
                default:
                    throw new ArgumentException("monthName");
            }
        }

        public DateTime ExtractDate(string dateStr)
        {
            // Expected date format -> 11 February, 2017
            var dateArr = dateStr.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            var day = int.Parse(dateArr[0]);
            var month = this.ConvertMonthToNumber(dateArr[1]);
            var year = int.Parse(dateArr[2]);

            return new DateTime(year, month, day);
        }
    }
}
