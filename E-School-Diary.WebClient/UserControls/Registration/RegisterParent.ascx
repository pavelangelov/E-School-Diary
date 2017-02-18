<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="RegisterParent.ascx.cs"
    Inherits="E_School_Diary.WebClient.UserControls.Registration.RegisterParent" %>

<%@ Register Src="~/UserControls/Registration/Common.ascx" TagPrefix="uc" TagName="CommonFields" %>

<asp:UpdatePanel runat="server">
    <ContentTemplate>
        <uc:CommonFields runat="server" ID="CommonFields" />

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
        <asp:Button runat="server" ID="BtnSubmit" CssClass="btn" Text="Submit" OnClick="RegisterClick" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="BtnSubmit" />
        <asp:AsyncPostBackTrigger ControlID="Classes" />
    </Triggers>
</asp:UpdatePanel>