using System;

namespace E_School_Diary.WebClient.Models.CustomEventArgs
{
    public class RegisterTeacherEventArgs : EventArgs
    {
        public RegisterTeacherEventArgs(string firstName, string lastName, string email,  string password, int age, string subject, ApplicationUserManager manager)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Password = password;
            this.Age = age;
            this.SubjectName = subject;
            this.Manager = manager;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int Age { get; set; }

        public string SubjectName { get; set; }

        public ApplicationUserManager Manager { get; set; }
    }
}