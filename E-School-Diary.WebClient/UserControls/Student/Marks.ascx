<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="Marks.ascx.cs"
    Inherits="E_School_Diary.WebClient.UserControls.Student.Marks" %>

<%@ Import Namespace="E_School_Diary.Utils.DTOs.Common" %>
<%@ Import Namespace="E_School_Diary.Data.Enums" %>

<h3>Marks for student: <span class="teal-text"><%: Context.User.Identity.GetUserName() %></span></h3>
<ul class="row">
    <asp:Repeater runat="server" ID="MarksList" ItemType="IGrouping<string, MarkDTO>">
        <HeaderTemplate>
            <table class="col s8">
                <thead>
                    <tr>
                        <th>Subject</th>
                        <th colspan="2">Marks</th>
                    </tr>
                </thead>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
            <td><%# Item.Key %></td>
                <asp:Repeater runat="server" ID="Child" ItemType="MarkDTO" DataSource="<%#Item%>">
                    <ItemTemplate>
                        <td><%# Item.Value %></td>
                    </ItemTemplate>
                </asp:Repeater>

            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</ul>
