<%@ Control 
    Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="RegisterStudent.ascx.cs" 
    Inherits="E_School_Diary.WebClient.UserControls.Registration.RegisterStudent" %>

<%@ Register Src="~/UserControls/Registration/Common.ascx" TagPrefix="uc" TagName="CommonFields" %>

<div class="container">
    <uc:CommonFields runat="server" ID="CommonFields"></uc:CommonFields>

    <div class="row">
        <div class="input-field col s4">
            <asp:DropDownList runat="server" ID="FormMaster" ClientIDMode="Static" Visible="true"></asp:DropDownList>
            <label for="FormMaster">Select the form master</label>
        </div>
        <div class="input-field col s4">
            <asp:DropDownList runat="server" ID="StudentClasses" ClientIDMode="Static" Visible="true"></asp:DropDownList>
            <label for="StudentClasses">Select the class</label>
        </div>
    </div>

    <asp:Button runat="server" CssClass="btn" Text="Submit" OnClick="RegisterClick" />
</div>

<script>

    $(document).ready(function () {
        $('select').material_select();
    });
</script>
