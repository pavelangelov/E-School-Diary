<%@ Page 
    Title="Child marks" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="Default.aspx.cs" 
    Inherits="E_School_Diary.WebClient.Child.Marks.Default" %>

<%@ Register Src="~/UserControls/Parent/ChildMarks.ascx" TagPrefix="uc" TagName="marks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <uc:marks runat="server" />
    </div>
</asp:Content>
