<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="AddTeacherToClass.ascx.cs"
    Inherits="E_School_Diary.WebClient.UserControls.Admin.AddTeacherToClass" %>

<%@ Register Src="~/UserControls/Common/MessageContainer.ascx" TagPrefix="uc" TagName="message" %>

<uc:message runat="server" ID="Message" />

<div class="row">
    <div class="col s6">
        <asp:DropDownList 
            runat="server" 
            ID="Teachers" 
            CssClass="teal-text" 
            ClientIDMode="Static" 
            OnSelectedIndexChanged="Teachers_SelectedIndexChanged" 
            AutoPostBack="true"></asp:DropDownList>
    </div>
    <div class="col s6">
        <asp:DropDownList 
            runat="server" 
            ID="Classes" 
            CssClass="teal-text" 
            ClientIDMode="Static"></asp:DropDownList>
    </div>

    <asp:Button runat="server" CssClass="btn" Text="Add" ID="AddBtn" OnClick="Unnamed_Click" />
</div>
