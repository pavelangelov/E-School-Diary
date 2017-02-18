<%@ Page
    Title="Register parent"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Default.aspx.cs"
    Inherits="E_School_Diary.WebClient.Register.Parent.Default" %>

<%@ Register Src="~/UserControls/Registration/RegisterParent.ascx" TagPrefix="uc" TagName="parentRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <uc:parentRegistration runat="server" />
    </div>
</asp:Content>
