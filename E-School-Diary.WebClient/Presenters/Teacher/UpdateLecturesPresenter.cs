using E_School_Diary.Data.Enums;
using E_School_Diary.Services.Contracts;
using E_School_Diary.Utils;
using System;
using System.Linq;

using WebFormsMvp;

using E_School_Diary.WebClient.Models.CustomEventArgs;
using E_School_Diary.WebClient.Views.Teacher;

namespace E_School_Diary.WebClient.Presenters.Teacher
{
    public class UpdateLecturesPresenter : Presenter<IUpdateLecturesView>
    {
        private ITeacherService teacherService;

        public UpdateLecturesPresenter(IUpdateLecturesView view, ITeacherService teacherService) 
            : base(view)
        {
            Validator.ValidateForNull(teacherService, "teacherService");

            this.teacherService = teacherService;

            this.View.UpdateClick += View_UpdateClick;
        }

        private void View_UpdateClick(object sender, IdEventArgs e)
        {
            var teacher = this.teacherService.FindById(e.Id);
            var now = DateTime.Now;

            foreach (var lecture in teacher.Lectures.ToList())
            {
                if (lecture.End < now)
                {
                    lecture.Status = LectureStatus.Past;
                }
            }

            try
            {
                this.teacherService.Save();
            }
            catch (Exception)
            {
                this.View.Model.IsSuccess = false;
                this.View.Model.ErrorMessage = "Error while updating the lectures. Please try again later.";
                return;
            }

            this.View.Model.IsSuccess = true;
        }
    }
}