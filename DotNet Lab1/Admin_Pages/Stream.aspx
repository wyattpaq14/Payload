<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Stream.aspx.cs" Inherits="DotNet_Lab1.Admin_Pages.Section" %>




<asp:Content ID="sectionForm" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <%--StreamID validator, textbox and label--%>
    <div class="form-group col-lg-8 col-md-offset-2">
        <asp:Label ID="lblStreamID" runat="server" Text="StreamID" CssClass="col-lg-2 control-label"></asp:Label>
        <div class="col-lg-10">
            <asp:TextBox ID="txtStreamID" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
        </div>
    </div>
    <br />
    <br />


    <%--Stream Name validator, textbox and label--%>
    <div class="form-group col-lg-8 col-md-offset-2">
        <asp:Label ID="lblStreamName" runat="server" Text="Stream Name" CssClass="col-lg-2 control-label"></asp:Label>
        <div class="col-lg-10">
            <asp:TextBox ID="txtStreamName" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvStreamName" runat="server" Display="None" ControlToValidate="txtStreamName" ErrorMessage="Stream Name is required"></asp:RequiredFieldValidator>
        </div>
    </div>
    <br />
    <br />

    <%--Stream Rank validator, textbox and label--%>
    <div class="form-group col-lg-8 col-md-offset-2">
        <asp:Label ID="lblStreamRank" runat="server" Text="Stream Rank" CssClass="col-lg-2 control-label"></asp:Label>
        <div class="col-lg-10">
            <asp:TextBox ID="txtStreamRank" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvStreamRank" runat="server" Display="None" ControlToValidate="txtStreamRank" ErrorMessage="Stream Rank is required"></asp:RequiredFieldValidator>
        </div>
    </div>
    <br />
    <br />

    <%--Stream Is Banned validator, textbox and label--%>
    <div class="form-group col-lg-8 col-md-offset-2">
        <asp:Label ID="lblStreamIsBanned" runat="server" Text="Stream Is Banned?" CssClass="col-lg-2 control-label"></asp:Label>
        <div class="col-lg-10">
            <asp:TextBox ID="txtStreamIsBanned" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvStreamIsBanned" runat="server" Display="None" ControlToValidate="txtStreamIsBanned" ErrorMessage="Stream Is Banned is required"></asp:RequiredFieldValidator>
        </div>
    </div>
    <br />
    <br />





    <asp:Button ID="btnUpdate" runat="server" CssClass="col-lg-4 btn btn-default col-md-offset-2" Text="Update" OnClick="btnUpdate_Click" />
    <asp:Button ID="btnCancel" runat="server" CssClass="col-lg-4 btn btn-default" Text="Cancel" />
    <asp:ValidationSummary ID="vsForm" ShowSummary="true" ShowMessageBox="true" runat="server" />

    <br />
    <br />

</asp:Content>
