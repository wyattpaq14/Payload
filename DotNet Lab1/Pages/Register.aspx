<%@ Page Title="" Language="C#" MasterPageFile="~/lab01.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="DotNet_Lab1.Pages.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphSearch" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />

    <%--email validator, textbox and label--%>
    <div class="row">
        
        <div class="input-field col s12">
            
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="lblEmail" runat="server" Text="Email" CssClass="col-lg-2 control-label" AssociatedControlID="txtEmail"></asp:Label>
            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" Display="None" ControlToValidate="txtEmail" ErrorMessage="Username is required"></asp:RequiredFieldValidator>
        </div>
    </div>
    <br />
    <br />



    <%--password validator, textbox and label--%>
    <div class="row">

        <div class="input-field col s12">
            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
            <asp:Label ID="lblPassword" runat="server" Text="Password" CssClass="col-lg-2 control-label" AssociatedControlID="txtPassword"></asp:Label>
            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" Display="None" ControlToValidate="txtPassword" ErrorMessage="Password is required"></asp:RequiredFieldValidator>
        </div>

    </div>
    <br />
    <br />

    <%--confirm password validator, textbox and label--%>
    <div class="row">

        <div class="input-field col s12">
            <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
            <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password" CssClass="col-lg-2 control-label" AssociatedControlID="txtConfirmPassword"></asp:Label>
            <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" Display="None" ControlToValidate="txtConfirmPassword" ErrorMessage="Confirm password is required"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="cvConfirmPassword" runat="server" ControlToCompare="txtPassword" ErrorMessage="Passwords must be the same" ControlToValidate="txtConfirmPassword" Operator="Equal"></asp:CompareValidator>
        </div>

    </div>
    <br />
    <br />
    <asp:Button ID="btnRegister" runat="server" CssClass="col-lg-4 btn btn-default col-md-offset-2" Text="Register" OnClick="btnRegister_Click" /><br />

    <asp:ValidationSummary ID="vsForm" ShowSummary="true" runat="server" />







    <br />
    <br />
</asp:Content>
