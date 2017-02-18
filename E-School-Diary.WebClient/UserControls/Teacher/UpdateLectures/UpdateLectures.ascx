<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="UpdateLectures.ascx.cs"
    Inherits="E_School_Diary.WebClient.UserControls.Teacher.UpdateLectures.UpdateLectures" %>

<%@ Register Src="~/UserControls/Common/MessageContainer.ascx" TagPrefix="uc" TagName="message" %>

<uc:message runat="server" ID="Message" />

<div class="row">
    <div class="col s4 offset-s4">
        <div class="icon-block">
            <h2 class="center gold-text">
                <a runat="server" class="waves-effect waves-light" title="update" onserverclick="Update_Lectures">
                    <i class="material-icons">cloud_upload</i>
                </a>
            </h2>
            <h5 runat="server" id="title" class="center">Students options.</h5>

            <p runat="server" id="content" class="light center">Click on the cloud to mark all lectures before this time, as Past.</p>
        </div>
    </div>
</div>

