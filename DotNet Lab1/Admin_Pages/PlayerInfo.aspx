<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="PlayerInfo.aspx.cs" Inherits="DotNet_Lab1.Admin_Pages.PlayerInfo" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="menuItemForm" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--User ID validator, textbox and label--%>
    <div class="form-group col-lg-8 col-md-offset-2">
        <asp:Label ID="lblUserID" runat="server" Text="User ID" CssClass="col-lg-2 control-label"></asp:Label>
        <div class="col-lg-10">
            <asp:TextBox ID="txtUserID" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvUserID" runat="server" Display="None" ControlToValidate="txtUserID" ErrorMessage="User ID is required"></asp:RequiredFieldValidator>
        </div>
    </div>
    <br />
    <br />

     <%--Battle ID validator, textbox and label--%>
    <div class="form-group col-lg-8 col-md-offset-2">
        <asp:Label ID="lblBattleID" runat="server" Text="Battle ID" CssClass="col-lg-2 control-label"></asp:Label>
        <div class="col-lg-10">
            <asp:TextBox ID="txtBattleID" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvBattleID" runat="server" Display="None" ControlToValidate="txtBattleID" ErrorMessage="Battle ID is required"></asp:RequiredFieldValidator>
        </div>
    </div>
    <br />
    <br />

     <%--Battle Tag validator, textbox and label--%>
    <div class="form-group col-lg-8 col-md-offset-2">
        <asp:Label ID="lblBattleTag" runat="server" Text="Battle Tag" CssClass="col-lg-2 control-label"></asp:Label>
        <div class="col-lg-10">
            <asp:TextBox ID="txtBattleTag" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvBattleTag" runat="server" Display="None" ControlToValidate="txtBattleTag" ErrorMessage="Battle Tag is required"></asp:RequiredFieldValidator>
        </div>
    </div>
    <br />
    <br />

     <%--Top Hero validator, textbox and label--%>
    <div class="form-group col-lg-8 col-md-offset-2">
        <asp:Label ID="lblTopHero" runat="server" Text="Top Hero" CssClass="col-lg-2 control-label"></asp:Label>
        <div class="col-lg-10">
            <asp:TextBox ID="txtTopHero" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvTopHero" runat="server" Display="None" ControlToValidate="txtTopHero" ErrorMessage="Top Hero is required"></asp:RequiredFieldValidator>
        </div>
    </div>
    <br />
    <br />


    <%--Player Rank validator, textbox and label--%>
    <div class="form-group col-lg-8 col-md-offset-2">
        <asp:Label ID="lblPlayerRank" runat="server" Text="Player Rank" CssClass="col-lg-2 control-label"></asp:Label>
        <div class="col-lg-10">
            <asp:TextBox ID="txtPlayerRank" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPlayerRank" runat="server" Display="None" ControlToValidate="txtPlayerRank" ErrorMessage="Player Rank is required"></asp:RequiredFieldValidator>
        </div>
    </div>
    <br />
    <br />

    <%--Play Time validator, textbox and label--%>
    <div class="form-group col-lg-8 col-md-offset-2">
        <asp:Label ID="lblPlayTime" runat="server" Text="Play Time" CssClass="col-lg-2 control-label"></asp:Label>
        <div class="col-lg-10">
            <asp:TextBox ID="txtPlayTime" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="None" ControlToValidate="txtBattleTag" ErrorMessage="Play Time is required"></asp:RequiredFieldValidator>
            
        </div>
    </div>
    <br />
    <br />

    


  

    

    <asp:Button ID="btnUpdate" runat="server" CssClass="col-lg-4 btn btn-default col-md-offset-2" Text="Update Player" OnClick="btnUpdate_Click"   />
    <asp:Button ID="btnInsert" runat="server" CssClass="col-lg-4 btn btn-default col-md-offset-2" Text="Insert Player" OnClick="btnInsert_Click"   />
    <asp:Button ID="btnCancel" runat="server" CssClass="col-lg-4 btn btn-default" Text="Cancel" CausesValidation="false" PostBackUrl="~/Home"/>
    <asp:ValidationSummary ID="vsForm" ShowSummary="true" ShowMessageBox="true" runat="server" />

    <br />
    <br />

</asp:Content>
