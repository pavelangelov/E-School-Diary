<%@ Page Title="Register Teacher" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="Default.aspx.cs" 
    Inherits="E_School_Diary.WebClient.Register.Teacher.Default" %>

<%@ Register Src="~/UserControls/Registration/RegisterTeacher.ascx" TagPrefix="uc" TagName="TeacherRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc:TeacherRegistration runat="server"></uc:TeacherRegistration>
</asp:Content>
