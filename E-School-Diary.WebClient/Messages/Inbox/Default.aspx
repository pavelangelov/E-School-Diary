<%@ Page 
    Title="Messages" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="Default.aspx.cs" 
    Inherits="E_School_Diary.WebClient.Messages.Inbox.Default" %>

<%@ Register Src="~/UserControls/Parent/Messages.ascx" TagPrefix="uc" TagName="parentMessages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <uc:parentMessages runat="server" />
    </div>
</asp:Content>
