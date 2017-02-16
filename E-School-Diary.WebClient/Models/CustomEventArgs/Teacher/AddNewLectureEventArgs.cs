using E_School_Diary.Utils.DTOs.Add;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_School_Diary.WebClient.Models.CustomEventArgs.Teacher
{
    public class AddNewLectureEventArgs : EventArgs
    {
        public AddNewLectureEventArgs(AddNewLectureDTO lectureDTO)
        {
            this.LectureDTO = lectureDTO;
        }

        public AddNewLectureDTO LectureDTO { get; set; }
    }
}