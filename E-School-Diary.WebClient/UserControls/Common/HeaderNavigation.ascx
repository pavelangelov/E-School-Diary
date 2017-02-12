<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="HeaderNavigation.ascx.cs"
    Inherits="E_School_Diary.WebClient.UserControls.Common.HeaderNavigation" %>

<nav class="white" role="navigation">
    <div class="nav-wrapper">
        <a id="logo-container" class="left brand-logo teal-text" href="/">E-School Diary</a>

        <asp:LoginView runat="server" ID="UsernameView" ViewStateMode="Enabled">
            <AnonymousTemplate>
                <div class="nav-wrapper">
                    <ul id="nav-mobile" class="right hide-on-med-and-down">
                        <li><a href="#about" class="teal-text">About</a></li>
                        <li><a href="#contact" class="teal-text">Contact</a></li>
                    </ul>
                </div>
            </AnonymousTemplate>
            <LoggedInTemplate>
                <a class="waves-effect waves-light btn-small right" title="Log off" runat="server" onserverclick="Unnamed_LoggingOut" onclick="logout()"><i class="material-icons teal-text">power_settings_new</i></a>
                <span class="right teal-text">Hello, <%: Context.User.Identity.GetUserName()  %> </span>
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
                    <img class="circle user-image" src="/Images/admin.png"></a>
                <a href="#!name"><span class="blue-text name"><%: Context.User.Identity.GetUserName() %></span></a>
                <a href="#!email"><span class="blue-text email">email@gmail.com</span></a>
            </div>
            </li>
        </LoggedInTemplate>
    </asp:LoginView>
    <asp:LoginView runat="server">
        <RoleGroups>
            <asp:RoleGroup Roles="Admin">
                <ContentTemplate>
                    <li><a class="waves-effect" href="/Register/Teacher">Create new Teacher Account</a></li>
                    <li><a class="waves-effect" href="/">Create new Admin Account</a></li>
                    <li>
                        <div class="divider"></div>
                    </li>
                    <li class="no-padding">
                        <ul class="collapsible collapsible-accordion">
                            <li>
                                <a class="collapsible-header">Edit Accounts<i class="material-icons">arrow_drop_down</i></a>
                                <div class="collapsible-body">
                                    <ul>
                                        <li><a class="waves-effect" href="/Edit/Students">Edit Students accounts</a></li>
                                        <li>
                                            <a class="waves-effect" href="/Edit/Teachers">Edit Teachers acounts</a></li>
                                        <li>
                                            <a class="waves-effect" href="/Edit/Parents">Edit Parents accounts</a></li>
                                    </ul>
                                </div>
                            </li>
                        </ul>
                    </li>
                </ContentTemplate>
            </asp:RoleGroup>
            <asp:RoleGroup Roles="Teacher">
                <ContentTemplate>
                    <li>Add new lecture</li>
                    <li>Cancel lecture</li>
                    <li>Add marks to students</li>
                    <li>Send message to student parents</li>
                    <li>Edit profile</li>
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
                    <li>Check out your marks</li>
                    <li>Check out your calendar</li>
                    <li>Edit profile</li>
                </ContentTemplate>
            </asp:RoleGroup>
        </RoleGroups>
    </asp:LoginView>
</ul>
<a href="#" data-activates="slide-out" class="button-collapse"><i class="material-icons">menu</i></a>
