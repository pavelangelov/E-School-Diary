<%@ Page 
    Title="Log in" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="Default.aspx.cs" 
    Inherits="E_School_Diary.WebClient.Login.Default" 
    Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="container">
        <h2><%: Title %>.</h2>

        <div class="row">
            <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                <p class="text-red">
                    <asp:Literal runat="server" ID="FailureText" />
                </p>
            </asp:PlaceHolder>
            <div class="row">
                <asp:Label runat="server" AssociatedControlID="Email" CssClass="col s2 control-label"></asp:Label>
                <div class="input-field col s7">
                    <i class="material-icons prefix">account_circle</i>
                    <label for="Email">Email</label>
                    <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                        CssClass="text-red" ErrorMessage="The email field is required." />
                </div>
            </div>

            <div class="row">
                <asp:Label runat="server" AssociatedControlID="Password" CssClass="col s2 control-label"></asp:Label>
                <div class="input-field col s7">
                    <i class="material-icons prefix">vpn_key</i>
                    <label for="Password">Password</label>
                    <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="validate" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-red" ErrorMessage="The password field is required." />
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <div class="checkbox">
                        <asp:CheckBox runat="server" ID="RememberMe" />
                        <asp:Label runat="server" AssociatedControlID="RememberMe">Remember me?</asp:Label>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <asp:Button runat="server" OnClick="LogIn" Text="Log in" CssClass="btn btn-default" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
