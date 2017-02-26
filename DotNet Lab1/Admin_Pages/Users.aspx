<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="DotNet_Lab1.Admin_Pages.Sections" %>






<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="false" DataSourceID="sdsUsers" CssClass="responsive-table bordered">

        <Columns>


            <asp:BoundField DataField="UserID" HeaderText="User ID" />
            <asp:BoundField DataField="UserEmail" HeaderText="User Email" />
            <asp:BoundField DataField="UserRank" HeaderText="User Rank" />
            <asp:BoundField DataField="UserIsAdmin" HeaderText="Administrator?" />
            <asp:BoundField DataField="UserIsBanned" HeaderText="Banned?" />

            <asp:HyperLinkField Text="View/Edit" DataNavigateUrlFields="UserID" DataNavigateUrlFormatString="~/Admin/User/{0}" />
        </Columns>

    </asp:GridView>

    <asp:SqlDataSource ID="sdsUsers" runat="server"
        ConnectionString="<%$ ConnectionStrings:SQL Server %>"
        SelectCommand="getAllUsers" SelectCommandType="StoredProcedure"></asp:SqlDataSource>


</asp:Content>





