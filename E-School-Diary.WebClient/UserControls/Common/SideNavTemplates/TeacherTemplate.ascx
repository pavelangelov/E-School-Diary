<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="TeacherTemplate.ascx.cs"
    Inherits="E_School_Diary.WebClient.UserControls.Common.SideNavTemplates.TeacherTemplate" %>

<li class="no-padding">
    <ul class="collapsible collapsible-accordion">
        <li>
            <a class="collapsible-header">Register<i class="material-icons">expand_more</i></a>
            <div class="collapsible-body">
                <ul>
                    <li>
                        <a class="waves-effect" href="/Register/Student">Create new Student Account</a>

                    </li>
                    <li>
                        <a class="waves-effect" href="#">Create new Parent Account</a>

                    </li>
                </ul>
            </div>
        </li>
        <li>
            <a class="collapsible-header">Lectures<i class="material-icons">expand_more</i></a>
            <div class="collapsible-body">
                <ul>
                    <li><a class="waves-effect" href="/Lectures/Add">Add new lecture</a></li>
                    <li><a class="waves-effect" href="/Lectures/ChangeStatus">Change lecture status</a></li>
                    <li><a class="waves-effect" href="/Lectures/Update">Update lectures</a></li>
                </ul>
            </div>
        </li>
        <li>
            <a class="collapsible-header">Other options<i class="material-icons">expand_more</i></a>
            <div class="collapsible-body">
                <ul>
                    <li><a class="waves-effect" href="/AddMarks">Add marks to students</a></li>
                    <li><a class="waves-effect" href="#">Send message to student parents</a></li>
                </ul>
            </div>
        </li>
    </ul>
</li>
