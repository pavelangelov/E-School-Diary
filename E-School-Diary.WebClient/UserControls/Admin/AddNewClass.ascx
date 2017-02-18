<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="AddNewClass.ascx.cs"
    Inherits="E_School_Diary.WebClient.UserControls.Admin.AddNewClass" %>

<%@ Register Src="~/UserControls/Common/MessageContainer.ascx" TagPrefix="uc" TagName="message" %>

<uc:message runat="server" ID="Message" />

<div class="row">
    <div class="input-field col s6">
        <asp:TextBox runat="server" ID="ClassName" ClientIDMode="Static" CssClass="validate" />
        <label for="ClassName">Class name</label>
        <asp:RequiredFieldValidator
            runat="server"
            ControlToValidate="ClassName"
            ValidationGroup="AddClass"
            CssClass="red-text"
            ErrorMessage="Class name must be between 2 and 15 symbols." />
    </div>

    <div class="col s6">
        <asp:DropDownList runat="server" CssClass="teal-text" ID="Teachers" ClientIDMode="Static">
        </asp:DropDownList>
    </div>
</div>

<asp:Button runat="server"  ValidationGroup="AddClass" Text="Create" CssClass="btn" OnClick="CreateClass" />
