<%@ Page 
    Title="Update lectures" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="Default.aspx.cs" 
    Inherits="E_School_Diary.WebClient.Lectures.Update.Default" %>

<%@ Register Src="~/UserControls/Teacher/UpdateLectures/UpdateLectures.ascx" TagPrefix="uc" TagName="update" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <uc:update runat="server" />
    </div>
</asp:Content>
