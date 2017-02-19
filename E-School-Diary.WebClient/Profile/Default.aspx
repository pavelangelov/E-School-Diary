<%@ Page 
    Title="Profile" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="Default.aspx.cs" 
    Inherits="E_School_Diary.WebClient.Profile.Default" %>

<%@ Register Src="~/UserControls/Common/UserProfilePage.ascx" TagPrefix="uc" TagName="profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <uc:profile runat="server" />
    </div>
</asp:Content>
