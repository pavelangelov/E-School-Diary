<%@ Page 
    Title="Send message" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="Default.aspx.cs" 
    Inherits="E_School_Diary.WebClient.Messages.Send.Default" %>

<%@ Register Src="~/UserControls/Teacher/Add/Message.ascx" TagPrefix="uc" TagName="message" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <uc:message runat="server" />
    </div>
</asp:Content>
