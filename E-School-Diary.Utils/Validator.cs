using System;

namespace E_School_Diary.Utils
{
    public static class Validator
    {
        public static void ValidateStringLength(string value, int maxLength, int minLength = 1, string paramName = null, string errorMessage = null)
        {
            if (value.Length < minLength || maxLength < value.Length)
            {
                throw new ArgumentException(paramName, errorMessage);
            }
        }

        public static void ValidateDoubleValue(double value, double maxValue, double minValue = 0, string paramName = null, string errorMessage = null)
        {
            if (value < minValue || maxValue < value)
            {
                throw new ArgumentException(paramName, errorMessage);
            }
        }

        public static void ValidateInteger(int value, double maxValue, double minValue = 0, string paramName = null, string errorMessage = null)
        {
            if (value < minValue || maxValue < value)
            {
                throw new ArgumentException(paramName, errorMessage);
            }
        }
    }
}
