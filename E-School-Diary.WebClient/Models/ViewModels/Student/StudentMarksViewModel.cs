using E_School_Diary.Models.Enums;
using E_School_Diary.Utils.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace E_School_Diary.WebClient.Models.ViewModels.Student
{
    public class StudentMarksViewModel
    {
        public IEnumerable<IGrouping<Subject, MarkDTO>> Marks { get; set; }
    }
}