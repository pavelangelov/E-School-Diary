<%@ Page
    Title="Add teacher to class"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs"
    Inherits="E_School_Diary.WebClient.Administration.AddTeacherToClass.Default" %>

<%@ Register Src="~/UserControls/Admin/AddTeacherToClass.ascx" TagPrefix="uc" TagName="addTeacherToClass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <uc:addTeacherToClass runat="server" />
    </div>
</asp:Content>
