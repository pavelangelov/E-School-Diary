using System;
using System.Linq;

using WebFormsMvp;

using E_School_Diary.Utils.DTOs.Common;
using E_School_Diary.WebClient.Models.CustomEventArgs.Student;
using E_School_Diary.WebClient.Views.Student;
using E_School_Diary.Utils.Contracts;
using E_School_Diary.Data.Repositories.Contracts;

namespace E_School_Diary.WebClient.Presenters.Student
{
    public class StudentCalendarPresenter : Presenter<IStudentCalendarView>
    {
        private IStudentRepository studentRepository;
        private IDateParser dateParser;

        public StudentCalendarPresenter(IStudentCalendarView view, IStudentRepository studentRepository, IDateParser dateParser) 
            : base(view)
        {
            this.studentRepository = studentRepository;
            this.dateParser = dateParser;

            this.View.LoadLectures += View_LoadLectures;
        }

        private void View_LoadLectures(object sender, CalendarEventArgs e)
        {
            var date = this.dateParser.ExtractDate(e.Date);

            var lectures = this.studentRepository.GetStudentLectures(e.UserId);

            this.GetAheadLectures(lectures, date);
            this.GetPastLectures(lectures, date);
            this.GetCalceledLectures(lectures, date);
        }

        public void GetPastLectures(IQueryable<LectureDTO> lectures, DateTime currentDate)
        {
            this.View.Model.PastLectures = lectures
                        .Where(l => l.Start.Value.Year == currentDate.Year &&
                               l.Start.Value.DayOfYear == currentDate.DayOfYear)
                        .Where(p => p.Status == "Past")
                        .OrderBy(x => x.Start)
                        .ToList();
        }

        public void GetAheadLectures(IQueryable<LectureDTO> lectures, DateTime currentDate)
        {
            this.View.Model.AheadLectures = lectures
                        .Where(l => l.Start.Value.Year == currentDate.Year &&
                               l.Start.Value.DayOfYear == currentDate.DayOfYear)
                        .Where(p => p.Status == "Ahead")
                        .OrderBy(x => x.Start)
                        .ToList();
        }

        public void GetCalceledLectures(IQueryable<LectureDTO> lectures, DateTime currentDate)
        {
            this.View.Model.CanceledLectures = lectures
                        .Where(l => l.Start.Value.Year == currentDate.Year &&
                               l.Start.Value.DayOfYear == currentDate.DayOfYear)
                        .Where(p => p.Status == "Canceled")
                        .OrderBy(x => x.Start)
                        .ToList();
        }
    }
}