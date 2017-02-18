<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="Message.ascx.cs"
    Inherits="E_School_Diary.WebClient.UserControls.Teacher.Add.Message" %>

<div class="row">
    <div class="col s4">
        <asp:DropDownList runat="server" ID="Classes" ClientIDMode="Static"></asp:DropDownList>
    </div>
    <div class="col s7">
        <asp:DropDownList runat="server" ID="Students" ClientIDMode="Static"></asp:DropDownList>
    </div>
    <div runat="server" id="messageContent" visible="false" class="row">
        <div class="input-field col s8">
            <textarea id="content" placeholder="Limit 200 symbols..." class="materialize-textarea" data-length="100"></textarea>
            <label for="content">Message content</label>
        </div>
    </div>
</div>

<asp:Button runat="server" OnClick="Unnamed_Click" CssClass="btn" Text="Send" />

<script>
    $(document).ready(function () {
        $('textarea#content').characterCounter();
    });
</script>
