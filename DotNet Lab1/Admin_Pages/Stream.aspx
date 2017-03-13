<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Stream.aspx.cs" Inherits="DotNet_Lab1.Admin_Pages.Stream" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="sectionForm" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <%--StreamID validator, textbox and label--%>
    <div class="row">

        <div class="input-field col s12">
            <asp:TextBox ID="txtStreamID" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            <asp:Label ID="lblStreamID" runat="server" Text="StreamID" CssClass="col-lg-2 control-label" AssociatedControlID="txtStreamID"></asp:Label>
        </div>
    </div>
    <br />
    <br />


    <%--Stream Name validator, textbox and label--%>
    <div class="row">

        <div class="input-field col s12">
            <asp:TextBox ID="txtStreamName" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="lblStreamName" runat="server" Text="Stream Name" CssClass="col-lg-2 control-label" AssociatedControlID="txtStreamName"></asp:Label>
            <asp:RequiredFieldValidator ID="rfvStreamName" runat="server" Display="None" ControlToValidate="txtStreamName" ErrorMessage="Stream Name is required"></asp:RequiredFieldValidator>
        </div>
    </div>
    <br />
    <br />

    <%--Stream Points validator, textbox and label--%>
    <div class="row">

        <div class="input-field col s12">
            <asp:TextBox ID="txtStreamPoints" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="lblStreamPoints" runat="server" Text="Stream Points" CssClass="col-lg-2 control-label" AssociatedControlID="txtStreamPoints"></asp:Label>
            <asp:RequiredFieldValidator ID="rfvStreamPoints" runat="server" Display="None" ControlToValidate="txtStreamPoints" ErrorMessage="Stream Points is required"></asp:RequiredFieldValidator>
        </div>
    </div>
    <br />
    <br />

    <%--Stream Is Banned validator, textbox and label--%>
    <div class="row">

        <div class="input-field col s12">
            <asp:TextBox ID="txtStreamIsBanned" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="lblStreamIsBanned" runat="server" Text="Stream Is Banned?" CssClass="col-lg-2 control-label" AssociatedControlID="txtStreamIsBanned"></asp:Label>
            <asp:RequiredFieldValidator ID="rfvStreamIsBanned" runat="server" Display="None" ControlToValidate="txtStreamIsBanned" ErrorMessage="Stream Is Banned is required"></asp:RequiredFieldValidator>
        </div>
    </div>
    <br />
    <br />





    <asp:LinkButton ID="lbUpdate" runat="server" CssClass="btn" OnClick="btnUpdate_Click">Update Stream</asp:LinkButton><br /><br />
    <asp:Button ID="btnDelete" runat="server" CssClass="btn" Text="Delete Player" OnClick="btnDelete_Click" /><br /><br />
    <asp:LinkButton ID="lbInsert" runat="server" CssClass="btn" OnClick="lbInsert_Click">Insert Stream</asp:LinkButton><br /><br />
    <asp:Button ID="btnCancel" runat="server" CssClass="col-lg-4 btn btn-default" Text="Cancel" CausesValidation="false" /><br />
    <asp:ValidationSummary ID="vsForm" ShowSummary="true" ShowMessageBox="true" runat="server" />

    <br />
    <br />

</asp:Content>
