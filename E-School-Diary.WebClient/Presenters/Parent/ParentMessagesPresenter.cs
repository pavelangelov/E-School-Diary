using E_School_Diary.Services.Contracts;
using E_School_Diary.Utils;
using E_School_Diary.WebClient.Models.CustomEventArgs;
using E_School_Diary.WebClient.Views.Parent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsMvp;

namespace E_School_Diary.WebClient.Presenters.Parent
{
    public class ParentMessagesPresenter : Presenter<IParentMessagesView>
    {
        private IParentService parentService;

        public ParentMessagesPresenter(IParentMessagesView view, IParentService parentService) 
            : base(view)
        {
            Validator.ValidateForNull(parentService, "parentService");

            this.parentService = parentService;

            this.View.PageLoad += View_PageLoad;
        }

        private void View_PageLoad(object sender, IdEventArgs e)
        {
            var messages = this.parentService.GetParentMessages(e.Id)
                                                .OrderByDescending(m => m.SendOn);

            this.View.Model.Messages = messages;
        }
    }
}