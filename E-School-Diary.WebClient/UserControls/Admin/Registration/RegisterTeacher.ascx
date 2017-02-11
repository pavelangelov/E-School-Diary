﻿<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="RegisterTeacher.ascx.cs"
    Inherits="E_School_Diary.WebClient.UserControls.Admin.Registration.RegisterTeacher" %>

<%@ Register Src="~/UserControls/Admin/Registration/Common.ascx" TagPrefix="uc" TagName="CommonFields" %>

<div class="container">
    <uc:CommonFields runat="server" ID="CommonFields"></uc:CommonFields>

    <div class="row">
        <div class="input-field col s4">
            <asp:DropDownList runat="server" ID="Subjects" ClientIDMode="Static" Visible="true"></asp:DropDownList>
            <label for="Subjects">Subjects</label>
        </div>
    </div>

    <asp:Button runat="server" CssClass="btn" Text="Submit" OnClick="RegisterClick" />
</div>

<script>

    $(document).ready(function () {
        $('select').material_select();
    });
</script>
