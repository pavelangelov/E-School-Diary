using System;
using System.Linq;

using WebFormsMvp;

using E_School_Diary.Data.Enums;
using E_School_Diary.Services.Contracts;
using E_School_Diary.Utils;
using E_School_Diary.WebClient.Models.CustomEventArgs;
using E_School_Diary.WebClient.Models.CustomEventArgs.Teacher;
using E_School_Diary.WebClient.Views.Teacher;

namespace E_School_Diary.WebClient.Presenters.Teacher
{
    public class ChangeLectureStatusPresenter : Presenter<IChangeLectureStatusView>
    {
        private ITeacherService teacherService;
        private ILectureService lectureService;

        public ChangeLectureStatusPresenter(IChangeLectureStatusView view, ITeacherService teacherService, ILectureService lectureService) 
            : base(view)
        {
            Validator.ValidateForNull(teacherService, "teacherService");
            Validator.ValidateForNull(lectureService, "lectureService");

            this.teacherService = teacherService;
            this.lectureService = lectureService;

            this.View.PageLoad += View_PageLoad;
            this.View.UpdateStatus += View_UpdateStatus;
        }

        public void View_PageLoad(object sender, IdEventArgs e)
        {
            var today = DateTime.Now;
            var lectures = this.teacherService.GetTeacherActualLectures(e.Id, today)
                                                                        .OrderBy(l => l.Start);

            this.View.Model.Lectures = lectures;
        }

        public void View_UpdateStatus(object sender, ChangeLectureStatusEventArgs e)
        {
            var lecture = this.lectureService.FindById(e.LectureId);
            var selectedStatus = (LectureStatus)Enum.Parse(typeof(LectureStatus), e.LectureStatus);

            lecture.Status = selectedStatus;
            try
            {
                this.lectureService.Save();
            }
            catch (Exception ex)
            {
                this.View.Model.IsSuccess = false;
                this.View.Model.ErrorMessage = "Something`s wrong.";
                return;
            }

            this.View.Model.IsSuccess = true;
        }
    }
}