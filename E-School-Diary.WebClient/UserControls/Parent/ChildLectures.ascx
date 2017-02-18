<%@ Control 
    Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="ChildLectures.ascx.cs" 
    Inherits="E_School_Diary.WebClient.UserControls.Parent.ChildLectures" %>
<div class="datepicker-container col s4">
    <label for="calendar">Pick a date</label>
    <input id="calendar" type="date" class="datepicker" runat="server">
</div>

<asp:UpdatePanel runat="server" ID="LecturesPanel"><Triggers>
        <asp:AsyncPostBackTrigger ControlID="Check" />
    </Triggers>
    <ContentTemplate>
        <asp:Button runat="server" ID="Check" OnClick="LoadLecturesClick" CssClass="waves-effect waves-light btn date-submit" Text="Check" />
        <div class="row">
            <div class="col s4">
                <h5 runat="server" id="ActiveTitle"></h5>
                <asp:Repeater ID="ActiveLectures" runat="server" ItemType="E_School_Diary.Utils.DTOs.Common.LectureDTO">
                    <HeaderTemplate>
                        <ul class="collection">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li class="collection-item avatar">
                            <i class="material-icons circle green" title="ahead">insert_chart</i>
                            <span class="title">Lecture: <%#: Item.Title %></span>
                            <p>
                                Subject: <%# Item.Subject%>
                                <br />
                                Start: <%# Item.Start.Value.ToShortTimeString()%>
                                <br />
                                End: <%# Item.End.Value.ToShortTimeString()%>
                            </p>
                        </li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                    </FooterTemplate>
                </asp:Repeater>
            </div>

            <div class="col s4">
                <h5 runat="server" id="CanceledTitle"></h5>
                <asp:Repeater ID="CanceledLectures" runat="server" ItemType="E_School_Diary.Utils.DTOs.Common.LectureDTO">
                    <HeaderTemplate>
                        <ul class="collection">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li class="collection-item avatar">
                            <i class="material-icons circle red" title="canceled">insert_chart</i>
                            <span class="title">Lecture: <%#: Item.Title %></span>
                            <p>
                                Subject: <%# Item.Subject%>
                                <br />
                                Start: <%# Item.Start.Value.ToShortTimeString()%>
                                <br />
                                End: <%# Item.End.Value.ToShortTimeString()%>
                            </p>
                        </li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                    </FooterTemplate>
                </asp:Repeater>
            </div>

            <div class="col s4">
                <h5 runat="server" id="PastTitle"></h5>
                <asp:Repeater ID="PastLectures" runat="server" ItemType="E_School_Diary.Utils.DTOs.Common.LectureDTO">
                    <HeaderTemplate>
                        <ul class="collection">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li class="collection-item avatar">
                            <i class="material-icons circle gray" title="past">insert_chart</i>
                            <span class="title">Lecture: <%#: Item.Title %></span>
                            <p>
                                Subject: <%# Item.Subject%>
                                <br />
                                Start: <%# Item.Start.Value.ToShortTimeString()%>
                                <br />
                                End: <%# Item.End.Value.ToShortTimeString()%>
                            </p>
                        </li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>

<script>
    $('.datepicker').pickadate({
        selectMonths: true, // Creates a dropdown to control month
        selectYears: 15 // Creates a dropdown of 15 years to control year
    });
</script>