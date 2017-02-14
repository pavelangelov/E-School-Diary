<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="AddNewClass.ascx.cs"
    Inherits="E_School_Diary.WebClient.UserControls.Admin.AddNewClass" %>

<div runat="server" class="card-panel" visible="false" id="errorContainer">
    <span><i class="tiny red-text material-icons">info_outline</i></span>
    <asp:Label runat="server" CssClass="red-text" ID="Error" />
</div>
<div runat="server" class="card-panel" visible="false" id="successContainer">
    <span class="teal-text"><i class="tiny teal-text material-icons">info_outline</i></span>
    <asp:Label runat="server" CssClass="teal-text" ID="Success" />
</div>

<div class="row">
    <div class="input-field col s6">
        <asp:TextBox runat="server" ID="ClassName" ClientIDMode="Static" CssClass="validate" />
        <label for="ClassName">Class name</label>
        <asp:RequiredFieldValidator
            runat="server"
            ControlToValidate="ClassName"
            CssClass="red-text"
            ErrorMessage="Class name must be between 2 and 15 symbols." />
    </div>

    <div class="col s6">
        <asp:DropDownList runat="server" CssClass="teal-text" ID="Teachers" ClientIDMode="Static">
        </asp:DropDownList>
    </div>
</div>

<asp:Button runat="server" Text="Create" CssClass="btn" OnClick="CreateClass" />
