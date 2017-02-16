<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="Marks.ascx.cs"
    Inherits="E_School_Diary.WebClient.UserControls.Teacher.Add.Marks" %>

<%@ Register Src="~/UserControls/Common/MessageContainer.ascx" TagPrefix="uc" TagName="message" %>

<uc:message runat="server" ID="Message" />

<asp:DropDownList
    runat="server"
    ID="Classes"
    ClientIDMode="Static"
    OnSelectedIndexChanged="Classes_SelectedIndexChanged"
    AutoPostBack="true">
</asp:DropDownList>

<asp:Repeater
    runat="server"
    ID="Students"
    ItemType="E_School_Diary.Utils.DTOs.Common.StudentDTO">
    <HeaderTemplate>
        <table>
            <thead>
                <tr>
                    <th>Student ID</th>
                    <th>Fitst Name</th>
                    <th>Middle Name</th>
                    <th>Last Name</th>
                    <th>Add marks</th>
                </tr>
            </thead>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td><%# Item.Id %></td>
            <td><%# Item.FirstName %></td>
            <td><%# Item.MiddleName %></td>
            <td><%# Item.LastName %></td>
            <td>
                <asp:TextBox runat="server" TextMode="Number" /></td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        <tr>
            <td>
                <asp:Button runat="server" OnClick="Unnamed_Click" CssClass="btn" Text="Update" /></td>
        </tr>
        </table>
    </FooterTemplate>
</asp:Repeater>
