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

<asp:GridView
    runat="server"
    ID="Students"
    AutoGenerateColumns="false"
    OnRowUpdating="Students_RowUpdating"
    OnRowEditing="Students_RowEditing"
    ShowFooter="true"
    ItemType="E_School_Diary.Utils.DTOs.Common.StudentDTO">
    <Columns>
        <asp:BoundField DataField="Id" ApplyFormatInEditMode="false" HeaderText="ID" />
        <asp:BoundField DataField="FirstName" ApplyFormatInEditMode="false" HeaderText="First name" />
        <asp:BoundField DataField="MiddleName" ApplyFormatInEditMode="false" HeaderText="Middle name" />
        <asp:BoundField DataField="LastName" ApplyFormatInEditMode="false" HeaderText="Last name" />
        <asp:BoundField DataField="MarkValue" ApplyFormatInEditMode="true" HeaderText="Add mark" />
        <asp:CommandField ShowEditButton="true" />
    </Columns>
</asp:GridView>
