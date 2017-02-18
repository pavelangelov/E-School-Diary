<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="AdminTemplate.ascx.cs"
    Inherits="E_School_Diary.WebClient.UserControls.Common.SideNavTemplates.AdminTemplate" %>

<li class="no-padding">
    <ul class="collapsible collapsible-accordion">
        <li>
            <a class="collapsible-header">Create Accounts<i class="material-icons">expand_more</i></a>
            <div class="collapsible-body">
                <ul>
                    <li><a class="waves-effect" href="/Register/Teacher">Create new Teacher Account</a></li>
                    <li><a class="waves-effect" href="/Administration/AddNewClass">Create new Class</a></li>
                </ul>
            </div>
        </li>
        <li>
            <a class="collapsible-header">Edit<i class="material-icons">expand_more</i></a>
            <div class="collapsible-body">
                <ul>
                    <li><a class="waves-effect" href="/Administration/AddTeacherToClass">Add teacher to class</a></li>
                    <li><a class="waves-effect" href="/Edit/Students">Edit Students accounts</a></li>
                    <li><a class="waves-effect" href="/Edit/Teachers">Edit Teachers acounts</a></li>
                    <li><a class="waves-effect" href="/Edit/Parents">Edit Parents accounts</a></li>
                    <li><a class="waves-effect" href="/Edit/Classes">Edit Classes</a></li>
                </ul>
            </div>
        </li>
    </ul>
</li>
