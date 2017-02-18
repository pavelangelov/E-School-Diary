<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="RegisterTeacher.ascx.cs"
    Inherits="E_School_Diary.WebClient.UserControls.Registration.RegisterTeacher" %>

<%@ Register Src="~/UserControls/Registration/Common.ascx" TagPrefix="uc" TagName="CommonFields" %>

<div class="container">
    <uc:CommonFields runat="server" ID="CommonFields"></uc:CommonFields>

    <div class="row">
        <div class="input-field col s4">
            <asp:DropDownList runat="server" ID="Subjects" ClientIDMode="Static" Visible="true"></asp:DropDownList>
            <label for="Subjects">Subjects</label>
        </div>
    </div>

    <asp:Button runat="server" CssClass="btn" ValidationGroup="Register" Text="Submit" OnClick="RegisterClick" />
</div>

<script>

    $(document).ready(function () {
        $('select').material_select();
    });
</script>
