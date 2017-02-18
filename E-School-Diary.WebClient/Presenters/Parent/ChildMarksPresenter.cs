using WebFormsMvp;

using E_School_Diary.Services.Contracts;
using E_School_Diary.Utils;
using E_School_Diary.WebClient.Models.CustomEventArgs;
using E_School_Diary.WebClient.Views.Parent;

namespace E_School_Diary.WebClient.Presenters.Parent
{
    public class ChildMarksPresenter : Presenter<IChildMarksView>
    {
        private IParentService parentService;

        public ChildMarksPresenter(IChildMarksView view, IParentService parentService) 
            : base(view)
        {
            Validator.ValidateForNull(parentService, "parentService");

            this.parentService = parentService;

            this.View.PageLoad += View_PageLoad;
        }

        private void View_PageLoad(object sender, IdEventArgs e)
        {
            var marks = parentService.GetChildMarks(e.Id);

            this.View.Model.Marks = marks;
        }
    }
}