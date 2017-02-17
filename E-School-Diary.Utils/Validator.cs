using System;

namespace E_School_Diary.Utils
{
    public static class Validator
    {
        /// <summary>
        /// Validate if string has valid length.
        /// </summary>
        /// <param name="value">String to validate.</param>
        /// <param name="maxLength">Max length.</param>
        /// <param name="minLength">Min length.</param>
        /// <param name="paramName">Parameter name.</param>
        /// <param name="errorMessage">Error message.</param>
        /// <exception cref="ArgumentException"></exception>
        public static void ValidateStringLength(string value, int maxLength, int minLength = 1, string paramName = null, string errorMessage = null)
        {
            if (value.Length < minLength || maxLength < value.Length)
            {
                throw new ArgumentException(errorMessage, paramName);
            }
        }

        /// <summary>
        /// Validate if passed double has valid value.
        /// </summary>
        /// <param name="value">Number to validate.</param>
        /// <param name="maxValue">Max value.</param>
        /// <param name="minValue">Min value</param>
        /// <param name="paramName">Parameter name.</param>
        /// <param name="errorMessage">Error message.</param>
        /// <exception cref="ArgumentException"></exception>
        public static void ValidateDoubleValue(double value, double maxValue, double minValue = 0, string paramName = null, string errorMessage = null)
        {
            if (value < minValue || maxValue < value)
            {
                throw new ArgumentException(errorMessage, paramName);
            }
        }

        /// <summary>
        /// Validate if passed integer has valid value.
        /// </summary>
        /// <param name="value">Number to validate.</param>
        /// <param name="maxValue">Max value.</param>
        /// <param name="minValue">Min value</param>
        /// <param name="paramName">Parameter name.</param>
        /// <param name="errorMessage">Error message.</param>
        /// <exception cref="ArgumentException"></exception>
        public static void ValidateInteger(int value, double maxValue, double minValue = 0, string paramName = null, string errorMessage = null)
        {
            if (value < minValue || maxValue < value)
            {
                throw new ArgumentException(errorMessage, paramName);
            }
        }

        /// <summary>
        /// Validate if passed object is null.
        /// </summary>
        /// <param name="value">Object to validate.</param>
        /// <param name="paramName">Parameter name.</param>
        /// <param name="errorMessage">Error message.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void ValidateForNull(object value, string paramName = null, string errorMessage = null)
        {
            if (value == null)
            {
                throw new ArgumentNullException(paramName, errorMessage);
            }
        }
    }
}
