<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="ChangeStatus.ascx.cs"
    Inherits="E_School_Diary.WebClient.UserControls.Teacher.ChangeLectureStatus.ChangeStatus" %>

<%@ Register Src="~/UserControls/Common/MessageContainer.ascx" TagPrefix="uc" TagName="message" %>

<uc:message runat="server" ID="MessageContainer" />

<div class="row">
    <h4 class="teal-text">Your lectures</h4>
    <asp:GridView 
        runat="server"
        ID="LecturesGridView"
        OnRowUpdating="LecturesGridView_RowUpdating"
        OnRowCancelingEdit="LecturesGridView_RowCancelingEdit"
        OnRowEditing="LecturesGridView_RowEditing"
        ItemType="E_School_Diary.Utils.DTOs.ChangeLectureStatusDTO"
        CssClass="responsive-table"
        AutoGenerateColumns="false">
        <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                    <thead>
                        <tr>
                            <th>Lecture title</th>
                            <th>Class</th>
                            <th>Start</th>
                            <th>End</th>
                            <th>Status</th>
                            <th>Action</th>
                        </tr>
                    </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%#: Item.Title %></td>
                        <td><%#: Item.ClassName %></td>
                        <td>
                            <%#: Item.Start.Value.ToShortDateString() %>
                            <br />
                            at <%#: Item.Start.Value.ToShortTimeString() %>

                        </td>
                        <td>
                            <%#: Item.End.Value.ToShortDateString() %>
                            <br />
                            at <%#: Item.End.Value.ToShortTimeString() %>

                        </td>
                        <td><%#: Item.Status.ToString() %></td>
                        <td>
                            <asp:LinkButton runat="server" CommandName="Edit" Text="Edit" />
                        </td>
                    </tr>
                </ItemTemplate>
                <EditItemTemplate>
                    <tr>
                        <td data-id="<%#: Item.Id %>"><%#: Item.Title %></td>
                        <td><%#: Item.ClassName %></td>
                        <td>
                            <%#: Item.Start.Value.ToShortDateString() %> at <%#: Item.Start.Value.ToShortTimeString() %>

                        </td>
                        <td>
                            <%#: Item.End.Value.ToShortDateString() %> at <%#: Item.End.Value.ToShortTimeString() %>

                        </td>
                        <td>
                            <asp:RadioButtonList runat="server" ID="StatusChange" data-id="<%# Item.Id %>">
                                <asp:ListItem Text="No changes" Value=""></asp:ListItem>
                                <asp:ListItem Text="Mark as Active" Value="Ahead"></asp:ListItem>
                                <asp:ListItem Text="Mark as Canceled" Value="Canceled"></asp:ListItem>
                                <asp:ListItem Text="Mark as Past" Value="Past"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td>
                            <asp:LinkButton runat="server" CommandName="Update" Text="Update" />
                            <asp:LinkButton ID="btnCancel" runat="server" CommandName="Cancel" Text="Cancel" />
                        </td>
                    </tr>
                </EditItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>
