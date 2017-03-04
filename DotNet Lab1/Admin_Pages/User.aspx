﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="DotNet_Lab1.Admin_Pages.User1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <%--UserID validator, textbox and label--%>
    <div class="form-group col-lg-8 col-md-offset-2">
        <asp:Label ID="lblUserID" runat="server" Text="UserID" CssClass="col-lg-2 control-label"></asp:Label>
        <div class="col-lg-10">
            <asp:TextBox ID="txtUserID" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
           
        </div>
    </div>
    <br />
    <br />

    <%--UserEmail validator, textbox and label--%>
    <div class="form-group col-lg-8 col-md-offset-2">
        <asp:Label ID="lblUsrEmail" runat="server" Text="User Email" CssClass="col-lg-2 control-label"></asp:Label>
        <div class="col-lg-10">
            <asp:TextBox ID="txtUserEmail" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvUserEmail" runat="server" Display="None" ControlToValidate="txtUserEmail" ErrorMessage="User Email is required"></asp:RequiredFieldValidator>
        </div>
    </div>
    <br />
    <br />

    <%--UserPassword validator, textbox and label--%>
    <div class="form-group col-lg-8 col-md-offset-2">
        <asp:Label ID="lblUserPassword" runat="server" Text="User Password" CssClass="col-lg-2 control-label"></asp:Label>
        <div class="col-lg-10">
            <asp:TextBox ID="txtUserPassword" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvUserPassword" runat="server" Display="None" ControlToValidate="txtUserPassword" ErrorMessage="User password is required"></asp:RequiredFieldValidator>
        </div>
    </div>
    <br />
    <br />

    <%--UserRank validator, textbox and label--%>
    <div class="form-group col-lg-8 col-md-offset-2">
        <asp:Label ID="lblUserRank" runat="server" Text="User Rank" CssClass="col-lg-2 control-label"></asp:Label>
        <div class="col-lg-10">
            <asp:TextBox ID="txtUserRank" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvUserRank" runat="server" Display="None" ControlToValidate="txtUserRank" ErrorMessage="User Rank is required"></asp:RequiredFieldValidator>
        </div>
    </div>
    <br />
    <br />

    <%--UserIsBanned validator, textbox and label--%>
    <div class="form-group col-lg-8 col-md-offset-2">
        <asp:Label ID="lblUserIsBanned" runat="server" Text="User Is Banned" CssClass="col-lg-2 control-label"></asp:Label>
        <div class="col-lg-10">
            <asp:TextBox ID="txtUserIsBanned" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvUserIsBanned" runat="server" Display="None" ControlToValidate="txtUserIsBanned" ErrorMessage="User Is Banned is required"></asp:RequiredFieldValidator>
        </div>
    </div>
    <br />
    <br />

    <%--UserIsAdmin validator, textbox and label--%>
    <div class="form-group col-lg-8 col-md-offset-2">
        <asp:Label ID="lblUserIsAdmin" runat="server" Text="User Is Admin" CssClass="col-lg-2 control-label"></asp:Label>
        <div class="col-lg-10">
            <asp:TextBox ID="txtUserIsAdmin" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvUserIsAdmin" runat="server" Display="None" ControlToValidate="txtUserIsAdmin" ErrorMessage="User Is Admin is required"></asp:RequiredFieldValidator>
        </div>
    </div>
    <br />
    <br />





    <asp:LinkButton ID="lbUpdate" runat="server" CssClass="btn" OnClick="lbUpdate_Click">Update User</asp:LinkButton><br />
    <asp:LinkButton ID="lbInsert" runat="server" CssClass="btn" OnClick="lbInsert_Click">Insert User</asp:LinkButton><br />
    <asp:Button ID="btnCancel" runat="server" CssClass="col-lg-4 btn btn-default" Text="Cancel" CausesValidation="false" PostBackUrl="~/Admin/Users" />
    <asp:ValidationSummary ID="vsForm" ShowSummary="true" ShowMessageBox="true" runat="server" />

    <br />
    <br />







</asp:Content>
