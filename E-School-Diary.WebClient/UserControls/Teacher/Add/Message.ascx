<%@ Control
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="Message.ascx.cs"
    Inherits="E_School_Diary.WebClient.UserControls.Teacher.Add.Message" %>

<%@ Register Src="~/UserControls/Common/MessageContainer.ascx" TagPrefix="uc" TagName="message" %>

<uc:message runat="server" ID="MessageContainer" />

<div class="row">
    <div class="col s4">
            <label for="Classes">Select class</label>
        <asp:DropDownList
            runat="server" 
            ID="Classes" 
            AutoPostBack="true"
            OnSelectedIndexChanged="Classes_SelectedIndexChanged"
            ClientIDMode="Static"></asp:DropDownList>
    </div>
    <div class="col s7">
            <label for="Students">Select student</label>
        <asp:DropDownList runat="server" ID="Students" ClientIDMode="Static"></asp:DropDownList>
    </div>
    <div runat="server" id="messageContent" visible="false" class="row">
        <div class="input-field col s8">
            <textarea 
                runat="server"
                id="content" 
                placeholder="Limit 200 symbols..." 
                class="materialize-textarea" 
                data-length="100"></textarea>
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
