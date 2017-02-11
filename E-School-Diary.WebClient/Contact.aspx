<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="E_School_Diary.WebClient.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <ul id="side-out" class="side-nav">
        <li>
            <div class="userView">
                <div class="background" id="profilepic">
                    <img src="/Images/side-nav-bacground.jpg" class="responsive-img">
                </div>
                <a href="#!user">
                    <img class="circle" width="67" height="67" src="/Images/admin.png"></a>
                <a href="#!name"><span class="white-text name">John Doe</span></a>
                <a href="#!email"><span class="white-text email">jdandturk@gmail.com</span></a>
            </div>
        </li>
        <li><a href="#!"><i class="material-icons">cloud</i>First Link With Icon</a></li>
        <li><a href="#!">Second Link</a></li>
        <li>
            <div class="divider"></div>
        </li>
        <li><a class="subheader">Subheader</a></li>
        <li><a class="waves-effect" href="#!">Third Link With Waves</a></li>
    </ul>
    <a href="#" data-activates="slide-out" class="button-collapse"><i class="material-icons">menu</i></a>

    <script>
        $(".button-collapse").sideNav();

        $('.button-collapse').sideNav({
            menuWidth: 350, // Default is 300
            edge: 'left', // Choose the horizontal origin
            closeOnClick: true, // Closes side-nav on <a> clicks, useful for Angular/Meteor
            draggable: true // Choose whether you can drag to open on touch screens
        }
  );

        //$(document).ready(function() {
        //    Materialize.fadeInImage('#profilepic');
        //    Materialize.showStaggeredList('.staggered-list');
        //});
    </script>
</asp:Content>
