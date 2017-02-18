using E_School_Diary.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_School_Diary.Services.Contracts
{
    public interface ILectureService
    {
        Lecture FindById(string lectureId);

        int Save();

        Tuple<string, string>[] GetLectureHours();
    }
}
