﻿<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="Lecture.ascx.cs"
    Inherits="E_School_Diary.WebClient.UserControls.Teacher.Add.Lecture" %>

<%@ Register Src="~/UserControls/Common/MessageContainer.ascx" TagPrefix="uc" TagName="message" %>

<div class="container">
    <div class="form-horizontal">
        <h4 runat="server" id="Title" class="center-align blue-text"></h4>
        <hr />

        <uc:message runat="server" ID="Message" />

        <div class="row">
            <div class="input-field col s6">
                <asp:TextBox
                    runat="server"
                    ID="LectureTitle"
                    ClientIDMode="Static"
                    MaxLength="35"></asp:TextBox>
                <label for="LectureTitle">Title</label>
                <asp:RequiredFieldValidator
                    runat="server"
                    ControlToValidate="LectureTitle"
                    ValidationGroup="AddLecture"
                    Display="Dynamic"
                    CssClass="red-text"
                    ErrorMessage="The lecture title field is required." />
            </div>
            <div class="input-field col s6">
                <asp:DropDownList runat="server" ID="StudentClasses" ClientIDMode="Static" Visible="true"></asp:DropDownList>
                <label for="StudentClasses">Select class</label>
            </div>
        </div>

        <div class="datepicker-container col s4">
            <label for="calendar">Pick a date</label>
            <asp:Label runat="server" ID="NoDate" CssClass="red-text" />
            <input id="calendar" type="date" class="datepicker" runat="server" required="required">
        </div>
    </div>

    <div class="row">
        <div class="input-field col s4">
            <asp:DropDownList runat="server" ID="StartTime" ClientIDMode="Static" Visible="true"></asp:DropDownList>
                <label for="StartTime">Select start time</label>
        </div>
        <div class="input-field col s4">
            <asp:DropDownList runat="server" ID="EndTime" ClientIDMode="Static" Visible="true"></asp:DropDownList>
                <label for="EndTime">Select end time</label>
        </div>
    </div>
    <asp:Button runat="server" CssClass="btn" ID="AddBtn" ValidationGroup="AddLecture" Text="Add" OnClick="AddClick" />
</div>

<script>

    $(document).ready(function () {
        $('select').material_select();
    });

    $('.datepicker').pickadate({
        selectMonths: true, // Creates a dropdown to control month
        selectYears: 15 // Creates a dropdown of 15 years to control year
    });

    $('.date-submit').on('click', (ev) => {
        ev.preventDefault();
        var date = $('.datepicker').val();
        if (date) {
            $('.result').html(date);
            $('.hidden-click').trigger('click');
        }
    })
</script>
