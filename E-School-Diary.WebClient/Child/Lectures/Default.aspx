<%@ Page 
    Title="Child lectures" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="Default.aspx.cs" 
    Inherits="E_School_Diary.WebClient.Child.Lectures.Default" %>

<%@ Register Src="~/UserControls/Parent/ChildLectures.ascx" TagPrefix="uc" TagName="lectures" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <uc:lectures runat="server" />
    </div>
</asp:Content>
