<%@ Control 
    Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="MessageContainer.ascx.cs" 
    Inherits="E_School_Diary.WebClient.UserControls.Common.MessageContainer" %>

<div runat="server" class="card-panel" visible="false" id="errorContainer">
    <span><i class="tiny red-text material-icons">info_outline</i></span>
    <asp:Label runat="server" CssClass="red-text" ID="Error" />
</div>
<div runat="server" class="card-panel" visible="false" id="successContainer">
    <span class="teal-text"><i class="tiny teal-text material-icons">info_outline</i></span>
    <asp:Label runat="server" CssClass="teal-text" ID="Success" />
</div>