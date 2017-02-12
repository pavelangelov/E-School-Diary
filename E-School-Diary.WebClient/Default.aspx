<%@ Page
    Title="Home Page"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Default.aspx.cs"
    Inherits="E_School_Diary.WebClient._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="index-banner" class="parallax-container">
        <div class="section no-pad-bot">
            <div class="container">
                <br>
                <br>
                <h1 class="header center teal-text text-lighten-2">Wellcome!</h1>
                <div class="row center">
                    <h4 class="header col s12 light">This is the e-diary of our school.</h4>
                </div>
                <br>
                <br>
            </div>
        </div>
        <div class="parallax">
            <img src="/Images/School-Background-Top.jpg" alt="Unsplashed background img 1"></div>
    </div>


    <div class="container">
        <div class="section">

            <!--   Icon Section   -->
            <div id="about" class="row">
                <div class="col s12 m4">
                    <div class="icon-block">
                        <h2 class="center brown-text"><i class="material-icons">grade</i></h2>
                        <h5 class="center">Students options.</h5>

                        <p class="light">Here you can check your program, and will see if you have any canceled lectures. You can check all your recieved marks.</p>
                    </div>
                </div>

                <div class="col s12 m4">
                    <div class="icon-block">
                        <h2 class="center brown-text"><i class="material-icons">hearing</i></h2>
                        <h5 class="center">Parents options.</h5>

                        <p class="light">Dear parents of our students. Here you can check every day the marks of your child. Teachers can send you messages with information for what your child doing in the school (good or bad). They will send you messages with comming events.</p>
                    </div>
                </div>

                <div class="col s12 m4">
                    <div class="icon-block">
                        <h2 class="center brown-text"><i class="material-icons">info_outline</i></h2>
                        <h5 class="center">How to register?</h5>

                        <p class="light">In our school, your child can learn skills to make a modern and responsive web application like this. So this is the place for you and your child.</p>
                    </div>
                </div>
            </div>

        </div>
    </div>


    <div class="parallax-container valign-wrapper">
        <div class="section no-pad-bot">
            <div class="container">
                <div class="row center">
                    <h3 class="header col s12 light"></h3>
                </div>
            </div>
        </div>
        <div class="parallax">
            <img src="/Images/School-Background-Middle.jpg" alt="Unsplashed background img 2"></div>
    </div>

    <div class="container">
        <div class="section">

            <div id="contact" class="row">
                <div class="col s12 center">
                    <h4>Contact Us</h4>
                    <p class="left-align light">We don`t have registration page, so if you are student, ask your form-master for your account. If you are parent and your child is our student, please contact with the form-master of your child and you will get your acount soon. If you have any problems with your account, please contact first the teacher. If the problems still exist, find the IT sector in the school and explain the problems to one of our administrators. If you have other questions please ask it in the school. This is e-diary not school information site.</p>
                </div>
            </div>

        </div>
    </div>


    <div class="parallax-container valign-wrapper">
        <div class="section no-pad-bot">
            <div class="container">
            </div>
        </div>
        <div class="parallax">
            <img src="/Images/School-Background-Bottom.jpg" alt="Unsplashed background img 3"></div>
    </div>
</asp:Content>
