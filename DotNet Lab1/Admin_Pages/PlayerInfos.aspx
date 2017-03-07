<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="PlayerInfos.aspx.cs" Inherits="DotNet_Lab1.Admin_Pages.PlayerInfos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="btnNewPlayerInfo" runat="server" Text="New Player" CssClass="btn" OnClick="btnNewPlayerInfo_Click" />
    <asp:GridView ID="gvPlayerInfo" runat="server" AutoGenerateColumns="false" DataSourceID="sdsPlayerInfo" CssClass="responsive-table bordered">

        <Columns>

            <asp:BoundField DataField="UserID" HeaderText="UserID" />
            <asp:BoundField DataField="BattleID" HeaderText="BattleTag" />
            <asp:BoundField DataField="BattleTag" HeaderText="BattleTag" />
            <asp:BoundField DataField="TopHero" HeaderText="Top Hero" />
            <asp:BoundField DataField="PlayerRank" HeaderText="Player Rank" />
            <asp:BoundField DataField="PlayTime" HeaderText="Play Time" />



            <asp:HyperLinkField Text="View/Edit" DataNavigateUrlFields="BattleTag" DataNavigateUrlFormatString="~/Admin/Player-Info/{0}" />
        </Columns>

    </asp:GridView>

    <asp:SqlDataSource ID="sdsPlayerInfo" runat="server"
        ConnectionString="<%$ ConnectionStrings:SQL Server %>"
        SelectCommand="getAllPlayerInfo" SelectCommandType="StoredProcedure"></asp:SqlDataSource>


</asp:Content>
