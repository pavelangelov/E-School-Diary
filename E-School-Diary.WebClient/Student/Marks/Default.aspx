<%@ Page 
    Title="Student marks" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="Default.aspx.cs" 
    Inherits="E_School_Diary.WebClient.Student.Marks.Default" %>

<%@ Register Src="~/UserControls/Student/Marks.ascx" TagPrefix="uc" TagName="marks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <uc:marks runat="server" />
    </div>
</asp:Content>
