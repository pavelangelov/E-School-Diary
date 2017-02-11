namespace E_School_Diary.Utils
{
    public class Constants
    {
        public const int NameMinLength = 2;
        public const int NameMaxLength = 20;
        public const int StudentAgeMinValue = 6;
        public const int TeacherAgeMinValue = 19;
        public const int ParentAgeMinValue = 18;
        public const int AdminAgeMinValue = 15;
        public const int AgeMaxValue = 100;
        public const int ConfirmIdentityMinLength = 8;
        public const int ConfirmIdentityMaxLength = 30;
        public const int AdditionalInfoMaxLength = 150;
        public const int LectureTitleMinLength = 2;
        public const int LectureTitleMaxLength = 35;
        public const int MarkMinValue = 2;
        public const int MarkMaxValue = 6;
        public const int ClassNameMinLength = 2;
        public const int ClassNameMaxLength = 6;

        public const string NameErrorMessage = "Name must be between 2 and 20 symbols.";
        public const string StudentAgeErrorMessage = "Age value must be between 6 and 100.";
        public const string TeacherAgeErrorMessage = "Age value must be between 19 and 100.";
        public const string ParentAgeErrorMessage = "Age value must be between 18 and 100.";
        public const string AdminAgeErrorMessage = "Age value must be between 15 and 100.";
        public const string ConfirmIdentityErrorMessage = "ConfirmIdentity must be between 8 and 30 symbols!";
        public const string AdditionalInfoErrorMessage = "Additional info must be less than 150 symbols";
        public const string LectureTitleErrorMessage = "Lecture title mus be between 2 and 35 symbols.";
        public const string MarkValueErrorMessage = "Mark value must be between 2 and 6.";
        public const string StudentClassNameErrorMessage = "Class name must be between 2 and 15 symbols.";
    }
}
