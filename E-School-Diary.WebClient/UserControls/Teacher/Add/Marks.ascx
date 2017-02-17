<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="Marks.ascx.cs"
    Inherits="E_School_Diary.WebClient.UserControls.Teacher.Add.Marks" %>

<%@ Register Src="~/UserControls/Common/MessageContainer.ascx" TagPrefix="uc" TagName="message" %>

<uc:message runat="server" ID="Message" />
<div class="row">
    <div class="col s2">
        <label for="Classes">Select class</label>
        <asp:DropDownList
            runat="server"
            ID="Classes"
            ClientIDMode="Static"
            OnSelectedIndexChanged="Classes_SelectedIndexChanged"
            AutoPostBack="true">
        </asp:DropDownList>
    </div>
    <div class="col s10">
        <asp:GridView
            runat="server"
            ID="Students"
            AutoGenerateColumns="false"
            OnRowUpdating="Students_RowUpdating"
            OnRowUpdated="Students_RowUpdated"
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
    </div>
</div>


