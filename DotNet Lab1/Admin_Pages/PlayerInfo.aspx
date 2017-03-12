<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="PlayerInfo.aspx.cs" Inherits="DotNet_Lab1.Admin_Pages.PlayerInfo" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="menuItemForm" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--User ID validator, textbox and label--%>
    <div class="row">

        <div class="input-field col s12">
            <asp:TextBox ID="txtUserID" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="lblUserID" runat="server" Text="User ID" CssClass="col-lg-2 control-label" AssociatedControlID="txtUserID"></asp:Label>

        </div>
    </div>
    <br />
    <br />

    <%--Battle ID validator, textbox and label--%>
    <div class="row">
        
        <div class="input-field col s12">
            <asp:TextBox ID="txtBattleID" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="lblBattleID" runat="server" Text="Battle ID" CssClass="col-lg-2 control-label" AssociatedControlID="txtBattleID"></asp:Label>
        </div>
    </div>
    <br />
    <br />

    <%--Battle Tag validator, textbox and label--%>
    <div class="row">
        
        <div class="input-field col s12">
            <asp:TextBox ID="txtBattleTag" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="lblBattleTag" runat="server" Text="Battle Tag" CssClass="col-lg-2 control-label" AssociatedControlID="txtBattleTag"></asp:Label>
            <asp:RequiredFieldValidator ID="rfvBattleTag" runat="server" Display="None" ControlToValidate="txtBattleTag" ErrorMessage="Battle Tag is required"></asp:RequiredFieldValidator>
        </div>
    </div>
    <br />
    <br />

    <%--Top Hero validator, textbox and label--%>
    <div class="row">
        
        <div class="input-field col s12">
            <asp:TextBox ID="txtTopHero" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            <asp:Label ID="lblTopHero" runat="server" Text="Top Hero" CssClass="col-lg-2 control-label" AssociatedControlID="txtTopHero"></asp:Label>
        </div>
    </div>
    <br />
    <br />


    <%--Player Rank validator, textbox and label--%>
    <div class="row">

        <div class="input-field col s12">
            <asp:TextBox ID="txtPlayerRank" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            <asp:Label ID="lblPlayerRank" runat="server" Text="Player Rank" CssClass="col-lg-2 control-label" AssociatedControlID="txtPlayerRank"></asp:Label>
        </div>
    </div>
    <br />
    <br />

    <%--Play Time validator, textbox and label--%>
    <div class="row">

        <div class="input-field col s12">
            <asp:TextBox ID="txtPlayTime" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            <asp:Label ID="lblPlayTime" runat="server" Text="Play Time" CssClass="col-lg-2 control-label" AssociatedControlID="txtPlayTime"></asp:Label>

        </div>
    </div>
    <br />
    <br />








    <asp:Button ID="btnUpdate" runat="server" CssClass="col-lg-4 btn btn-default col-md-offset-2" Text="Update Player" OnClick="btnUpdate_Click" /><br /><br />
    <asp:Button ID="btnInsert" runat="server" CssClass="col-lg-4 btn btn-default col-md-offset-2" Text="Insert Player" OnClick="btnInsert_Click" /><br /><br />
    <asp:Button ID="btnCancel" runat="server" CssClass="col-lg-4 btn btn-default" Text="Cancel" CausesValidation="false" PostBackUrl="~/Home" />
    <asp:ValidationSummary ID="vsForm" ShowSummary="true" ShowMessageBox="true" runat="server" />

    <br />
    <br />

</asp:Content>
