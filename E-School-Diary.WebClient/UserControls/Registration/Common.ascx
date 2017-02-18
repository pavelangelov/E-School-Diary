<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="Common.ascx.cs"
    Inherits="E_School_Diary.WebClient.UserControls.Registration.Common" %>

<%@ Register Src="~/UserControls/Common/MessageContainer.ascx" TagPrefix="uc" TagName="message" %>

<uc:message runat="server" ID="Message" />

<div class="form-horizontal">
    <h4 runat="server" id="Title" class="center-align blue-text"></h4>
    <hr />

    <div class="row">
        <div class="input-field col s6">
            <asp:TextBox
                 runat="server" 
                ID="FirstNameInput" 
                ClientIDMode="Static" 
                MaxLength="20"></asp:TextBox>
            <label for="FirstNameInput">First Name</label>
            <asp:RequiredFieldValidator 
                runat="server" 
                ControlToValidate="FirstNameInput" 
                 Display="Dynamic"
                CssClass="red-text" 
                ErrorMessage="The first name field is required." />
        </div>
        <div class="input-field col s6">
            <asp:TextBox 
                runat="server"
                ID="LastNameInput" 
                CssClass="validate" 
                ClientIDMode="Static" />
            <label for="LastNameInput">Last Name</label>
            <asp:RequiredFieldValidator 
                runat="server" 
                ControlToValidate="LastNameInput"  
                Display="Dynamic"
                CssClass="red-text" 
                ErrorMessage="The last name field is required." />
        </div>
    </div>

    <div class="row">
        <div class="input-field col s6">
            <label for="EmailInput">Email</label>
            <asp:TextBox 
                runat="server" 
                ID="EmailInput" 
                ClientIDMode="Static" 
                TextMode="Email" />
            <asp:RequiredFieldValidator 
                runat="server" 
                ControlToValidate="EmailInput"  
                Display="Dynamic"
                CssClass="red-text" 
                ErrorMessage="The email field is required." />
        </div>
        <div class="input-field col s6">
            <label for="AgeInput">Age</label>
            <asp:TextBox 
                runat="server" 
                ID="AgeInput" 
                ClientIDMode="Static" 
                TextMode="Number" />
            <asp:RequiredFieldValidator 
                runat="server" 
                ControlToValidate="AgeInput" 
                Display="Dynamic"
                CssClass="red-text" ErrorMessage="The age field is required." />
            <asp:RangeValidator 
                runat="server" 
                ControlToValidate="AgeInput"
                CssClass="red-text" 
                MinimumValue="6" 
                MaximumValue="100" 
                Type="Integer"
                ErrorMessage="The age field must be greater than 6."/>
        </div>
    </div>

    <div class="row">
        <div class="input-field col s6"">
            <label for="PasswordInput">Password</label>
            <asp:TextBox 
                runat="server" 
                ID="PasswordInput" 
                ClientIDMode="Static" 
                TextMode="Password" />
            <asp:RequiredFieldValidator 
                runat="server" 
                ControlToValidate="PasswordInput"
                CssClass="red-text" 
                ErrorMessage="The password field is required." />
        </div>
        <div class="input-field col s6">
            <label for="ConfirmPasswordInput">Confirm Password</label>
            <asp:TextBox 
                runat="server" 
                ID="ConfirmPasswordInput" 
                ClientIDMode="Static" 
                TextMode="Password" />
            <asp:RequiredFieldValidator 
                runat="server" 
                ControlToValidate="ConfirmPasswordInput"
                CssClass="red-text"
                Display="Dynamic" 
                ErrorMessage="The confirm password field is required." />
            <asp:CompareValidator 
                runat="server" 
                ControlToCompare="PasswordInput" 
                ControlToValidate="ConfirmPasswordInput"
                CssClass="red-text" 
                Display="Dynamic" 
                ErrorMessage="The password and confirmation password do not match." />
        </div>
    </div>
</div>
