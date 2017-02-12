<%@ Page 
    Title="Register Student" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="Default.aspx.cs" 
    Inherits="E_School_Diary.WebClient.Register.Student.Default" %>

<%@ Register Src="~/UserControls/Registration/RegisterStudent.ascx" TagPrefix="uc" TagName="registerStudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc:registerStudent runat="server"></uc:registerStudent>
</asp:Content>
