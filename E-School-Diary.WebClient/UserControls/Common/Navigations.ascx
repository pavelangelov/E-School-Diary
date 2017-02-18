<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="Navigations.ascx.cs"
    Inherits="E_School_Diary.WebClient.UserControls.Common.Navigations" %>

<nav class="white" role="navigation">
    <div class="nav-wrapper">
        <a id="logo-container" class="left brand-logo teal-text" href="/">E-School Diary</a>

        <asp:LoginView runat="server" ID="UsernameView" ViewStateMode="Enabled">
            <AnonymousTemplate>
                <ul id="nav-mobile" class="right hide-on-med-and-down">
                    <li><a href="#about" class="teal-text">About</a></li>
                    <li><a href="#contact" class="teal-text">Contact</a></li>
                </ul>
            </AnonymousTemplate>
            <LoggedInTemplate>
                <a class="waves-effect waves-light btn-small right" title="Log off" runat="server" onserverclick="Unnamed_LoggingOut" onclick="logout()"><i class="material-icons teal-text">power_settings_new</i></a>
                <span class="right teal-text">Hello, <%: this.Model.FirstName  %> </span>
            </LoggedInTemplate>
        </asp:LoginView>
    </div>
</nav>

<ul id="slide-out" class="side-nav">
    <asp:LoginView runat="server">
        <AnonymousTemplate>
            <li><a runat="server" class="teal-text" href="~/Account/Login">Login</a></li>
            <li><a runat="server" class="teal-text" href="~/TeachersList">Our Teachers</a></li>
        </AnonymousTemplate>
        <LoggedInTemplate>
            <div class="userView">
                <a href="#!user">
                    <img class="circle user-image" src="<%: this.Model.ImageUrl %>"></a>
                <a href="#!name"><span class="white-text name"><%: this.Model.FirstName + " " + this.Model.LastName %></span></a>
                <a href="#!email"><span class="white-text email"><%: this.Model.Email %></span></a>
            </div>
            </li>
        </LoggedInTemplate>
    </asp:LoginView>
    <asp:LoginView runat="server">
        <RoleGroups>
            <asp:RoleGroup Roles="Admin">
                <ContentTemplate>
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
                </ContentTemplate>
            </asp:RoleGroup>
            <asp:RoleGroup Roles="Teacher">
                <ContentTemplate>
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
                                        <li><a class="waves-effect" href="/AddNewLecture">Add new lecture</a></li>
                                        <li><a class="waves-effect" href="/ChangeLectureStatus">Manage lectures</a></li>
                                    </ul>
                                </div>
                            </li>
                            <li>
                                <a class="collapsible-header">Other options<i class="material-icons">expand_more</i></a>
                                <div class="collapsible-body">
                                    <ul>
                                        <li><a class="waves-effect" href="/AddMarks">Add marks to students</a></li>
                                        <li><a class="waves-effect" href="#">Send message to student parents</a></li>
                                        <li><a class="waves-effect" href="#">Edit profile</a></li>
                                    </ul>
                                </div>
                            </li>
                        </ul>
                    </li>
                </ContentTemplate>
            </asp:RoleGroup>
            <asp:RoleGroup Roles="Parent">
                <ContentTemplate>
                    <li>Check out your child marks</li>
                    <li>Check out your child lectures</li>
                    <li>Messages and events</li>
                    <li>Edit profile</li>
                </ContentTemplate>
            </asp:RoleGroup>
            <asp:RoleGroup Roles="Student">
                <ContentTemplate>
                    <li><a class="waves-effect" href="/Student/Marks">Check out your marks</a></li>
                    <li><a class="waves-effect" href="/Student/Calendar">Check out your calendar</a></li>
                    <li>Edit profile</li>
                </ContentTemplate>
            </asp:RoleGroup>
        </RoleGroups>
    </asp:LoginView>
</ul>
<a href="#" data-activates="slide-out" class="button-collapse"><i class="material-icons">menu</i></a>
