using System;
using System.Collections.Generic;
using System.Linq;

namespace E_School_Diary.WebClient.Models.ViewModels.Student
{
    public class StudentMarksViewModel
    {
        public ICollection<Tuple<string, string>> Marks { get; set; }
    }
}