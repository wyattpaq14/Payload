<%@ Page Title="" Language="C#" MasterPageFile="~/lab01.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="DotNet_Lab1.Pages.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphSearch" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <%--email validator, textbox and label--%>
    <div class="form-group col-lg-8 col-md-offset-2">
        <asp:Label ID="lblEmail" runat="server" Text="Email" CssClass="col-lg-2 control-label"></asp:Label>
        <div class="col-lg-10">
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" Display="None" ControlToValidate="txtEmail" ErrorMessage="Email is required"></asp:RequiredFieldValidator>
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

    <%--confirm password validator, textbox and label--%>
    <div class="form-group col-lg-8 col-md-offset-2">
        <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password" CssClass="col-lg-2 control-label"></asp:Label>
        <div class="col-lg-10">
            <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" Display="None" ControlToValidate="txtConfirmPassword" ErrorMessage="Confirm password is required"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="cvConfirmPassword" runat="server" ControlToCompare="txtPassword" ErrorMessage="Passwords must be the same" ControlToValidate="txtConfirmPassword" Operator="Equal"></asp:CompareValidator>
        </div>

    </div>
    <br />
    <br />
    <asp:Button ID="btnRegister" runat="server" CssClass="col-lg-4 btn btn-default col-md-offset-2" Text="Register" OnClick="btnRegister_Click" /><br />
    <asp:Button ID="btnForgotPassword" runat="server" CssClass="col-lg-4 btn btn-default" Text="Forgot Password" />

    <asp:ValidationSummary ID="vsForm" ShowSummary="true" runat="server" />







    <br />
    <br />
</asp:Content>
