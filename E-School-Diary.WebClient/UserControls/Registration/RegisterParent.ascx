<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="RegisterParent.ascx.cs"
    Inherits="E_School_Diary.WebClient.UserControls.Registration.RegisterParent" %>

<%@ Register Src="~/UserControls/Registration/Common.ascx" TagPrefix="uc" TagName="CommonFields" %>

<asp:UpdatePanel runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <uc:CommonFields runat="server" ID="CommonFields" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="BtnSubmit" />
    </Triggers>
</asp:UpdatePanel>

<asp:UpdatePanel runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div class="row">
            <div class="col s4">
                <label for="Classes">Select class:</label>
                <asp:DropDownList runat="server" ID="Classes" ClientIDMode="Static" OnSelectedIndexChanged="Classes_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            </div>
            <div class="col s7">
                <label for="Students">Select student:</label>
                <asp:Label runat="server" CssClass="red-text label" Visible="false" ID="StudentSelectError"></asp:Label>
                <asp:DropDownList runat="server" ID="Students" ClientIDMode="Static"></asp:DropDownList>
            </div>
        </div>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="Classes" />
    </Triggers>
</asp:UpdatePanel>

<asp:Button runat="server" ID="BtnSubmit" ValidationGroup="Register" CssClass="btn" Text="Submit" OnClick="RegisterClick" />