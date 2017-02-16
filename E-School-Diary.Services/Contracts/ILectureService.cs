using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_School_Diary.Services.Contracts
{
    public interface ILectureService
    {
        Tuple<string, string>[] GetLectureHours();
    }
}
