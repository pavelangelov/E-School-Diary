<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="Marks.ascx.cs"
    Inherits="E_School_Diary.WebClient.UserControls.Student.Marks" %>

<%@ Import Namespace="E_School_Diary.Utils.DTOs.Common" %>
<%@ Import Namespace="E_School_Diary.Models.Enums" %>

<h3>Marks for student: <span class="teal-text"><%: Context.User.Identity.GetUserName() %></span></h3>
<ul>
    <asp:Repeater runat="server" ID="MarksList" ItemType="IGrouping<Subject, MarkDTO>">
           <ItemTemplate>
                    <li><%# Item.Key %><ul>
                        <asp:Repeater runat="server" ID="Child" ItemType="MarkDTO" DataSource="<%#Item%>">
                            <ItemTemplate>
                                <li><%# Item.Value %></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                    </li>
                </ItemTemplate>
    </asp:Repeater>
</ul>
