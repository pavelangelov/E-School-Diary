<%@ Page 
    Title="Add lecture" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="Default.aspx.cs" 
    Inherits="E_School_Diary.WebClient.AddNewLecture.Default" %>

<%@ Register Src="~/UserControls/Teacher/Add/Lecture.ascx" TagPrefix="uc" TagName="newLecture" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc:newLecture runat="server" />
</asp:Content>
