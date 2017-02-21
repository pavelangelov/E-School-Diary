<%@ Page 
    Title="Our Teachers" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="TeachersList.aspx.cs" 
    Inherits="E_School_Diary.WebClient.TeachersList" %>
<%@ Import Namespace="E_School_Diary.Data.Enums" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:SqlDataSource
    runat="server"
    ID="TeachersData"
    ConnectionString="<%$ ConnectionStrings:DefaultConnection%>"
    SelectCommand="SELECT ImageUrl, FirstName, LastName, Subject, Age, UserName FROM Users WHERE (UserType = 2)">
    </asp:SqlDataSource>

<div class="container row">
    <asp:Repeater 
        ID="Teachers" 
        runat="server"
        DataSourceID="TeachersData">
        <HeaderTemplate>
            <ul class="collection col s6 offset-s2">
        </HeaderTemplate>
        <ItemTemplate>
            <li class="collection-item avatar">
                <img src="<%#: Eval("ImageUrl") %>" alt="" class="circle">
                <span class="title teal-text"><%#: Eval("FirstName") %> <%#: Eval("LastName") %></span><p>
                    Age: <%#: Eval("Age") %>
                    <br />
                    Subject: <%#: Enum.Parse(typeof(Subject), Eval("Subject").ToString()) %>
                </p>
            </li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>
</div>
</asp:Content>
