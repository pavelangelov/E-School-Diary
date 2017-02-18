using System;
using System.Collections.Generic;
using System.Linq;

using WebFormsMvp;

using E_School_Diary.Services.Contracts;
using E_School_Diary.Utils;
using E_School_Diary.Utils.Contracts;
using E_School_Diary.Utils.DTOs.Common;
using E_School_Diary.WebClient.Models.CustomEventArgs;
using E_School_Diary.WebClient.Models.CustomEventArgs.Student;
using E_School_Diary.WebClient.Views.Parent;

namespace E_School_Diary.WebClient.Presenters.Parent
{
    public class ChildLecturesPresenter : Presenter<IChildLecturesView>
    {
        private IParentService parentService;
        private IStudentService studentService;
        private IDateParser dateParser;

        public ChildLecturesPresenter(IChildLecturesView view, IParentService parentService, IStudentService studentService, IDateParser dateParser)
            : base(view)
        {
            Validator.ValidateForNull(parentService, "parentService");
            Validator.ValidateForNull(studentService, "studentService");
            Validator.ValidateForNull(dateParser, "dateParser");

            this.parentService = parentService;
            this.studentService = studentService;
            this.dateParser = dateParser;

            this.View.PageLoad += View_PageLoad;
            this.View.LoadLectures += View_LoadLectures;
        }

        private void View_PageLoad(object sender, IdEventArgs e)
        {
            var childId = this.parentService.GetChildId(e.Id);

            this.View.Model.ChildId = childId;
        }

        private void View_LoadLectures(object sender, CalendarEventArgs e)
        {
            var date = this.dateParser.ExtractDate(e.Date);

            var lectures = this.studentService.GetStudentLectures(e.UserId);

            this.GetAheadLectures(lectures, date);
            this.GetPastLectures(lectures, date);
            this.GetCalceledLectures(lectures, date);
        }

        public void GetPastLectures(IEnumerable<LectureDTO> lectures, DateTime currentDate)
        {
            this.View.Model.PastLectures = lectures
                        .Where(l => l.Start.Value.Year == currentDate.Year &&
                               l.Start.Value.DayOfYear == currentDate.DayOfYear)
                        .Where(p => p.Status == "Past")
                        .OrderBy(x => x.Start)
                        .ToList();
        }

        public void GetAheadLectures(IEnumerable<LectureDTO> lectures, DateTime currentDate)
        {
            this.View.Model.AheadLectures = lectures
                        .Where(l => l.Start.Value.Year == currentDate.Year &&
                               l.Start.Value.DayOfYear == currentDate.DayOfYear)
                        .Where(p => p.Status == "Ahead")
                        .OrderBy(x => x.Start)
                        .ToList();
        }

        public void GetCalceledLectures(IEnumerable<LectureDTO> lectures, DateTime currentDate)
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