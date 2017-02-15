﻿<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="Lecture.ascx.cs"
    Inherits="E_School_Diary.WebClient.UserControls.Teacher.Add.Lecture" %>

<div class="container">
    <div class="form-horizontal">
        <h4 runat="server" id="Title" class="center-align blue-text"></h4>
        <hr />

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
            <input id="calendar" type="date" class="datepicker" runat="server">
        </div>
    </div>

    <div class="row">
        <div class="input-field col s4">
            <span class="badge">Start time </span>
            <asp:TextBox runat="server" ID="StartTime" ClientIDMode="Static" TextMode="Time" />
        </div>
        <div class="input-field col s4">
            <span class="badge">End time </span>
            <asp:TextBox runat="server" ID="EndTime" ClientIDMode="Static" TextMode="Time" />
        </div>
        <div class="input-field col s4">
            <asp:DropDownList runat="server" ID="Subjects2" ClientIDMode="Static" Visible="true"></asp:DropDownList>
            <label for="Subjects">Subjects</label>
        </div>
    </div>

    <%--<asp:Button runat="server" CssClass="btn" Text="Submit" OnClick="RegisterClick" />--%>
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
