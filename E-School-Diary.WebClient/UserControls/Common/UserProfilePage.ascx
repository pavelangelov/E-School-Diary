<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="UserProfilePage.ascx.cs"
    Inherits="E_School_Diary.WebClient.UserControls.Common.UserProfilePage" %>

<%@ Register Src="~/UserControls/Common/MessageContainer.ascx" TagPrefix="uc" TagName="message" %>

<div class="row">
    <div class="card col s8 offset-s2">
        <div class="card-header center">
            <asp:Image runat="server" ID="UserImage" ImageUrl="<%#: this.Model.ImageUrl %>" ClientIDMode="Static"/>
        </div>
        <div class="card-content">
            <h3 runat="server" id="nameContainer" class="center teal-text"><%#: this.Model.Names %></h3>
            <h4 runat="server" id="usernameContainer" class="center teal-text"><%#: this.Model.Username %></h4>
            <hr />
            <h5>Change your avatar</h5>
            <div class="file-field input-field">
                <div class="btn">
                    <span>File</span>
                    <asp:FileUpload runat="server" ID="file" ClientIDMode="Static" />
                </div>
                <div class="file-path-wrapper">
                    <input class="file-path validate" type="text">
                </div>
                <a class="waves-effect waves-teal btn-flat teal-text" title="Upload" runat="server" onserverclick="UploadImage"><i class="material-icons right">send</i>Upload</a>
                <span runat="server" id="FileError"></span>
            </div>
        </div>
    </div>
</div>

<uc:message runat="server" ID="Message" />
