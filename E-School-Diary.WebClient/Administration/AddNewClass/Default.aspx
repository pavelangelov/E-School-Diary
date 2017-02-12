<%@ Page 
    Title="Create new class" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="Default.aspx.cs" 
    Inherits="E_School_Diary.WebClient.Administration.AddNewClass.Default" %>

<%@ Register Src="~/UserControls/Admin/AddNewClass.ascx" TagPrefix="uc" TagName="createClass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <uc:createClass runat="server" />
    </div>
</asp:Content>
