<%@ Page 
    Title="Calendar" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="Default.aspx.cs" 
    Inherits="E_School_Diary.WebClient.Student.Calendar.Default" %>

<%@ Register Src="~/UserControls/Student/Calendar.ascx" TagPrefix="uc" TagName="calendar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <uc:calendar runat="server"></uc:calendar>
    </div>
</asp:Content>
