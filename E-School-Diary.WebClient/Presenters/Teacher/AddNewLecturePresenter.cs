using E_School_Diary.Factories.Contracts;
using E_School_Diary.Services.Contracts;
using E_School_Diary.Utils.Contracts;
using E_School_Diary.Utils.DTOs;
using E_School_Diary.WebClient.Models.CustomEventArgs;
using E_School_Diary.WebClient.Models.CustomEventArgs.Teacher;
using E_School_Diary.WebClient.Views.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsMvp;

namespace E_School_Diary.WebClient.Presenters.Teacher
{
    public class AddNewLecturePresenter : Presenter<IAddNewLectureView>
    {
        private ITeacherService teacherService;
        private ILectureService lectureService;
        private IStudentClassService studentClassService;
        private ILectureFactory lectureFactory;
        private IDateParser dateParser;

        public AddNewLecturePresenter(IAddNewLectureView view, ITeacherService teacherService, ILectureService lectureService, IStudentClassService studentClassService, ILectureFactory lectureFactory, IDateParser dateParser)
            : base(view)
        {
            if (teacherService == null)
            {
                throw new ArgumentNullException("teacherService");
            }

            if (lectureService == null)
            {
                throw new ArgumentNullException("lectureService");
            }

            if (studentClassService == null)
            {
                throw new ArgumentNullException("studentClassService");
            }

            if (lectureFactory == null)
            {
                throw new ArgumentNullException("lectureFactory");
            }

            if (dateParser == null)
            {
                throw new ArgumentNullException("dateParser");
            }

            this.teacherService = teacherService;
            this.lectureService = lectureService;
            this.studentClassService = studentClassService;
            this.lectureFactory = lectureFactory;
            this.dateParser = dateParser;

            this.View.PageLoad += View_PageLoad;
            this.View.AddLectureClick += View_AddLectureClick;
        }

        public void View_AddLectureClick(object sender, AddNewLectureEventArgs e)
        {
            var teacher = this.teacherService.FindById(e.LectureDTO.TeacherId);
            var studentClass = this.studentClassService.GetById(e.LectureDTO.StudentClassId);

            var startDate = this.dateParser.GetDate(e.LectureDTO.Date, e.LectureDTO.Start);
            var endDate = this.dateParser.GetDate(e.LectureDTO.Date, e.LectureDTO.End);

            var lectureDTO = new CreateLectureDTO()
            {
                StudentClassId = e.LectureDTO.StudentClassId,
                Title = e.LectureDTO.Title,
                SubjectName = teacher.Subject.ToString(),
                TeacherId = e.LectureDTO.TeacherId,
                Start = startDate,
                End = endDate
            };

            try
            {
                e.LectureDTO.SubjectName = teacher.Subject.ToString();
                var lecture = this.lectureFactory.CreateLecture(lectureDTO);

                teacher.Lectures.Add(lecture);
                studentClass.Lectures.Add(lecture);
            }
            catch (ArgumentException ex)
            {
                this.View.Model.ErrorMessage = ex.Message;
                this.View.Model.IsSuccess = false;
                return;
            }

            try
            {
                this.teacherService.Save();
            }
            catch (Exception ex)
            {
                this.View.Model.ErrorMessage = ex.Message;
                this.View.Model.IsSuccess = false;
                return;
            }

            this.View.Model.IsSuccess = true;
        }

        public void View_PageLoad(object sender, UserIdEventArgs e)
        {
            var classes = this.teacherService.GetTeacherClasses(e.UserId);
            if (classes.Count() == 0)
            {
                this.View.Model.ErrorMessage = "This Teacher doesn`t have classes to teach!";
                return;
            }

            var lectudeHours = this.lectureService.GetLectureHours();

            this.View.Model.Classes = classes;
            this.View.Model.LectureHours = lectudeHours;
        }
    }
}