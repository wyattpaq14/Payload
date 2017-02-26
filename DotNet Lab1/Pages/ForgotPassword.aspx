<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" MasterPageFile="~/lab01.Master" Inherits="DotNet_Lab1.Pages.ForgotPassword" %>

<asp:Content ID="forgotPwForms" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--email validator, textbox and label--%>
    <div class="form-group col-lg-8 col-md-offset-2">
        <asp:Label ID="lblEmail" runat="server" Text="Email" CssClass="col-lg-2 control-label"></asp:Label>
        <div class="col-lg-10">
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" Display="None" ControlToValidate="txtEmail" ErrorMessage="Email is required"></asp:RequiredFieldValidator>
        </div>
    </div>

    <%--email confirm validator, textbox and label--%>
    <div class="form-group col-lg-8 col-md-offset-2">
        <asp:Label ID="lblEmailConfirm" runat="server" Text="Confirm Email" CssClass="col-lg-2 control-label"></asp:Label>
        <div class="col-lg-10">
            <asp:TextBox ID="txtEmailConfirm" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvEmailConfirm" runat="server" Display="None" ControlToValidate="txtEmailConfirm" ErrorMessage="Email confirm is required"></asp:RequiredFieldValidator>
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

    <%--password validator, textbox and label--%>
    <div class="form-group col-lg-8 col-md-offset-2">
        <asp:Label ID="lblPasswordConfirm" runat="server" Text="Confirm Password" CssClass="col-lg-2 control-label"></asp:Label>
        <div class="col-lg-10">
            <asp:TextBox ID="txtPasswordConfirm" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPasswordConfirm" runat="server" Display="None" ControlToValidate="txtPasswordConfirm" ErrorMessage="Password confirm is required"></asp:RequiredFieldValidator>
        </div>
    </div>


    <asp:Button ID="btnResetPassword" runat="server" CssClass="col-lg-8 btn btn-default col-md-offset-2" Text="Reset Password" />
    <asp:ValidationSummary ID="vsForm" ShowSummary="true" ShowMessageBox="true" runat="server" />

    <br />
    <br />

</asp:Content>
