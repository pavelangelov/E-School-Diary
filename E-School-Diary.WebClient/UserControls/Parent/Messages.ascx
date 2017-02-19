<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="Messages.ascx.cs"
    Inherits="E_School_Diary.WebClient.UserControls.Parent.Messages" %>

<h4 class="center">Recieved messages from teachers</h4>

<asp:Repeater
    runat="server"
    ID="MessagesContainer"
    ClientIDMode="Static"
    ItemType="E_School_Diary.Utils.DTOs.Common.MessageDTO">
    <HeaderTemplate>
        <ul class="collapsible popout" data-collapsible="accordion">
    </HeaderTemplate>
    <ItemTemplate>
        <li>
            <div class="collapsible-header teal-text"><i class="material-icons">message</i>From: <%# Item.From %></div>
            <div class="collapsible-body">
                <label for="message-content">Content:</label>
                <p id="message-content"><%#: Item.Content %></p>
                <label for="date">Send on:</label>
                <div id="date" class="teal-text"><%#: Item.SendOn.ToShortDateString() %> <%#: Item.SendOn.ToShortTimeString() %></div>
            </div>
        </li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
</asp:Repeater>
