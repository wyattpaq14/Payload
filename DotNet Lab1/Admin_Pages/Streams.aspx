<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Streams.aspx.cs" Inherits="DotNet_Lab1.Admin_Pages.Streams" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="btnNewStream" runat="server" Text="New Stream" CssClass="btn" OnClick="btnNewStream_Click" />
    <asp:GridView ID="gvStreams" runat="server" AutoGenerateColumns="false" DataSourceID="sdsStreams" CssClass="responsive-table bordered">

        <Columns>



            <asp:BoundField DataField="StreamID" HeaderText="Stream ID" />
            <asp:BoundField DataField="StreamName" HeaderText="Stream Name" />
            <asp:BoundField DataField="StreamPoints" HeaderText="Stream Points" />

            <asp:BoundField DataField="StreamIsBanned" HeaderText="Banned?" />

            <asp:HyperLinkField Text="view/edit" DataNavigateUrlFields="StreamID" DataNavigateUrlFormatString="~/Admin/Stream/{0}" />
        </Columns>

    </asp:GridView>

    <asp:SqlDataSource ID="sdsStreams" runat="server"
        ConnectionString="<%$ ConnectionStrings:SQL Server %>"
        SelectCommand="getAllStreams" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

</asp:Content>
