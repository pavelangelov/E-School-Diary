<%@ Page
    Title="Change lecture status"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Default.aspx.cs"
    Inherits="E_School_Diary.WebClient.ChangeLectureStatus.Default" %>

<%@ Register Src="~/UserControls/Teacher/ChangeLectureStatus/ChangeStatus.ascx" TagPrefix="uc" TagName="changeStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <uc:changeStatus runat="server" />
    </div>
</asp:Content>
