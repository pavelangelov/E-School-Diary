<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="Navigations.ascx.cs"
    Inherits="E_School_Diary.WebClient.UserControls.Common.Navigations" %>

<%@ Register Src="~/UserControls/Common/SideNavTemplates/AdminTemplate.ascx" TagPrefix="uc" TagName="adminTemplate" %>
<%@ Register Src="~/UserControls/Common/SideNavTemplates/TeacherTemplate.ascx" TagPrefix="uc" TagName="teacherTemplate" %>
<%@ Register Src="~/UserControls/Common/SideNavTemplates/StudentTemplate.ascx" TagPrefix="uc" TagName="studentTemplate" %>
<%@ Register Src="~/UserControls/Common/SideNavTemplates/ParentTemplate.ascx" TagPrefix="uc" TagName="parentTemplate" %>

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
            <li>
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
                    <uc:adminTemplate runat="server" />
                </ContentTemplate>
            </asp:RoleGroup>

            <asp:RoleGroup Roles="Teacher">
                <ContentTemplate>
                    <uc:teacherTemplate runat="server" />
                </ContentTemplate>
            </asp:RoleGroup>

            <asp:RoleGroup Roles="Parent">
                <ContentTemplate>
                    <uc:parentTemplate runat="server" />
                </ContentTemplate>
            </asp:RoleGroup>

            <asp:RoleGroup Roles="Student">
                <ContentTemplate>
                    <uc:studentTemplate runat="server" />
                </ContentTemplate>
            </asp:RoleGroup>

        </RoleGroups>
    </asp:LoginView>
</ul>
<a href="#" data-activates="slide-out" class="button-collapse"><i class="material-icons">menu</i></a>
