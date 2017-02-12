<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="Marks.ascx.cs"
    Inherits="E_School_Diary.WebClient.UserControls.Student.Marks" %>

<h3>Marks for student: <span class="teal-text"><%: Context.User.Identity.GetUserName() %></span></h3>
<ul>
    <asp:Repeater runat="server" ID="MarksList" ItemType="ICollection<Tuple<string, string>>">
        <ItemTemplate>
            <li class="row">
                <div class="col s5">
                    <span><%# Eval("Item.Item1") %></span>
                </div>
                <div class="col s5">
                    <span><%# Eval("Item.Item2") %></span>
                </div>
            </li>
        </ItemTemplate>
    </asp:Repeater>
</ul>
