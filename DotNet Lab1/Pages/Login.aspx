<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" MasterPageFile="~/lab01.Master" Inherits="DotNet_Lab1.Pages.Login" %>

<asp:Content ID="loginForms" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--username validator, textbox and label--%>
    <div class="form-group col-lg-8 col-md-offset-2">
        <asp:Label ID="lblUsername" runat="server" Text="Username" CssClass="col-lg-2 control-label"></asp:Label>
        <div class="col-lg-10">
            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvUsername" runat="server" Display="None" ControlToValidate="txtUsername" ErrorMessage="Username is required"></asp:RequiredFieldValidator>
        </div>
    </div>
    <br />
    <br />

    <%--password validator, textbox and label--%>
    <div class="form-group col-lg-8 col-md-offset-2">
        <asp:Label ID="lblPassword" runat="server" Text="Password" CssClass="col-lg-2 control-label"></asp:Label>
        <div class="col-lg-10">
            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" Display="None" ControlToValidate="txtPassword" ErrorMessage="Password is required"></asp:RequiredFieldValidator>
        </div>

    </div>
    <br />
    <br />
    <asp:Button ID="btnLogin" runat="server" CssClass="col-lg-4 btn btn-default col-md-offset-2" Text="Login" OnClick="btnLogin_Click" />
    <asp:Button ID="btnForgotPassword" runat="server" CssClass="col-lg-4 btn btn-default" Text="Forgot Password" />
    <asp:ValidationSummary ID="vsForm" ShowSummary="true" ShowMessageBox="true" runat="server" />







    <br />
    <br />
</asp:Content>
