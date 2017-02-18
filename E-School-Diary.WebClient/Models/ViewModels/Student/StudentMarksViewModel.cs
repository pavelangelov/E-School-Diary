using System.Linq;
using System.Collections.Generic;

using E_School_Diary.Utils.DTOs.Common;

namespace E_School_Diary.WebClient.Models.ViewModels.Student
{
    public class StudentMarksViewModel : BaseViewModel
    {
        public IEnumerable<IGrouping<string, MarkDTO>> Marks { get; set; }
    }
}