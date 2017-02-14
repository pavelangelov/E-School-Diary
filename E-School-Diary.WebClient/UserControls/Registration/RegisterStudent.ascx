﻿<%@ Control 
    Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="RegisterStudent.ascx.cs" 
    Inherits="E_School_Diary.WebClient.UserControls.Registration.RegisterStudent" %>

<%@ Register Src="~/UserControls/Registration/Common.ascx" TagPrefix="uc" TagName="CommonFields" %>

<div class="container">
    <uc:CommonFields runat="server" ID="CommonFields"></uc:CommonFields>

    <div class="row">
        <div class="card-panel hoverable col s4">
            <label for="FormMaster">Form master will be: </label>
            <asp:Label runat="server" ID="FormMaster" ClientIDMode="Static" />
        </div>
        <div class="card-panel hoverable col s4">
            <label for="StudentClass">The student will be in class: </label>
            <asp:Label runat="server" ID="StudentClass" ClientIDMode="Static" />
        </div>
    </div>

    <asp:Button runat="server" ID="BtnSubmit" CssClass="btn" Text="Submit" OnClick="RegisterClick" />
</div>

<script>

    $(document).ready(function () {
        $('select').material_select();
    });
</script>
