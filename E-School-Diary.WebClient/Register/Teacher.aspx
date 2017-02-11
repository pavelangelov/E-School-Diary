<%@ Page Title="Register" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="Teacher.aspx.cs" 
    Inherits="E_School_Diary.WebClient.Register.Teacher" %>

<%@ Register Src="~/UserControls/Admin/Registration/RegisterTeacher.ascx" TagPrefix="uc" TagName="TeacherRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc:TeacherRegistration runat="server"></uc:TeacherRegistration>
</asp:Content>
