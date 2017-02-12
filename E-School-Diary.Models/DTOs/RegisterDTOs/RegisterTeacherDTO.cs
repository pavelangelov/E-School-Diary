using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_School_Diary.Models.DTOs.RegisterDTOs
{
    public class RegisterTeacherDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int Age { get; set; }

        public string Subject { get; set; }

        public string StudentClassId { get; set; }
    }
}
