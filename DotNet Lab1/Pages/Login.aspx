<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" MasterPageFile="~/lab01.Master" Inherits="DotNet_Lab1.Pages.Login" %>

<asp:Content ID="loginForms" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
    <asp:Button ID="btnLogin" runat="server" CssClass="col-lg-4 btn btn-default col-md-offset-2" Text="Login" OnClick="btnLogin_Click" /><br /><br />
    <asp:LinkButton ID="lbNewUser" runat="server" CssClass="col-lg-4 btn btn-default" PostBackUrl="~/Home/Register" CausesValidation="false">Sign Up!</asp:LinkButton><br />
    <asp:ValidationSummary ID="vsForm" ShowSummary="true" ShowMessageBox="true" runat="server" />







    <br />
    <br />
</asp:Content>
