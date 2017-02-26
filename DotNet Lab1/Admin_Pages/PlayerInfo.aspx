<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="PlayerInfo.aspx.cs" Inherits="DotNet_Lab1.Admin_Pages.MenuItem" %>

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
        </div>
    </div>
    <br />
    <br />

     <%--Competitive Stat 1 validator, textbox and label--%>
    <div class="form-group col-lg-8 col-md-offset-2">
        <asp:Label ID="lblCompetitiveStat1" runat="server" Text="Competitive Stat 1" CssClass="col-lg-2 control-label"></asp:Label>
        <div class="col-lg-10">
            <asp:TextBox ID="txtCompetitiveStat1" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            
        </div>
    </div>
    <br />
    <br />

     <%--Competitive Stat 2 validator, textbox and label--%>
    <div class="form-group col-lg-8 col-md-offset-2">
        <asp:Label ID="lblCompetitiveStat2" runat="server" Text="Competitive Stat 2" CssClass="col-lg-2 control-label"></asp:Label>
        <div class="col-lg-10">
            <asp:TextBox ID="txtCompetitiveStat2" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
           
        </div>
    </div>
    <br />
    <br />

     <%--Competitive Stat 3 validator, textbox and label--%>
    <div class="form-group col-lg-8 col-md-offset-2">
        <asp:Label ID="lblCompetitiveStat3" runat="server" Text="Competitive Stat 3" CssClass="col-lg-2 control-label"></asp:Label>
        <div class="col-lg-10">
            <asp:TextBox ID="txtCompetitiveStat3" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            
        </div>
    </div>
    <br />
    <br />

     <%--Casual Stat 1 validator, textbox and label--%>
    <div class="form-group col-lg-8 col-md-offset-2">
        <asp:Label ID="lblCasualStat1" runat="server" Text="Casual Stat 1" CssClass="col-lg-2 control-label"></asp:Label>
        <div class="col-lg-10">
            <asp:TextBox ID="txtCasualStat1" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            
        </div>
    </div>
    <br />
    <br />

    <%--Casual Stat 2 validator, textbox and label--%>
    <div class="form-group col-lg-8 col-md-offset-2">
        <asp:Label ID="lblCasualStat2" runat="server" Text="Casual Stat 2" CssClass="col-lg-2 control-label"></asp:Label>
        <div class="col-lg-10">
            <asp:TextBox ID="txtCasualStat2" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            
        </div>
    </div>
    <br />
    <br />

    <%--Casual Stat 3 validator, textbox and label--%>
    <div class="form-group col-lg-8 col-md-offset-2">
        <asp:Label ID="lblCasualStat3" runat="server" Text="Casual Stat 3" CssClass="col-lg-2 control-label"></asp:Label>
        <div class="col-lg-10">
            <asp:TextBox ID="txtCasualStat3" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
        </div>
    </div>
    <br />
    <br />

    <%--Player Rank validator, textbox and label--%>
    <div class="form-group col-lg-8 col-md-offset-2">
        <asp:Label ID="lblPlayerRank" runat="server" Text="Player Rank" CssClass="col-lg-2 control-label"></asp:Label>
        <div class="col-lg-10">
            <asp:TextBox ID="txtPlayerRank" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            
        </div>
    </div>
    <br />
    <br />

    <%--Avatar validator, textbox and label--%>
    <div class="form-group col-lg-8 col-md-offset-2">
        <asp:Label ID="lblAvatar" runat="server" Text="Avatar" CssClass="col-lg-2 control-label"></asp:Label>
        <div class="col-lg-10">
            <asp:TextBox ID="txtAvatar" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            
        </div>
    </div>
    <br />
    <br />

    <%--LevelBorder validator, textbox and label--%>
    <div class="form-group col-lg-8 col-md-offset-2">
        <asp:Label ID="lblLevelBorder" runat="server" Text="Level Border" CssClass="col-lg-2 control-label"></asp:Label>
        <div class="col-lg-10">
            <asp:TextBox ID="txtLevelBorder" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
        </div>
    </div>
    <br />
    <br />

    <%--Emblem validator, textbox and label--%>
    <div class="form-group col-lg-8 col-md-offset-2">
        <asp:Label ID="lblEmblem" runat="server" Text="Emblem" CssClass="col-lg-2 control-label"></asp:Label>
        <div class="col-lg-10">
            <asp:TextBox ID="txtEmblem" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
        </div>
    </div>
    <br />
    <br />


  

    

    <asp:Button ID="btnUpdate" runat="server" CssClass="col-lg-4 btn btn-default col-md-offset-2" Text="Update" OnClick="btnUpdate_Click" PostBackUrl="~/Admin"  />
    <asp:Button ID="btnCancel" runat="server" CssClass="col-lg-4 btn btn-default" Text="Cancel" CausesValidation="false" PostBackUrl="~/Home"/>
    <asp:ValidationSummary ID="vsForm" ShowSummary="true" ShowMessageBox="true" runat="server" />

    <br />
    <br />

</asp:Content>
