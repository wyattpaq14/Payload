<%@ Page Async="true" Title="" Language="C#" MasterPageFile="~/lab01.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DotNet_Lab1.Default" %>

<asp:Content ID="cntSearch" ContentPlaceHolderID="cphSearch" runat="server">
    <li>


        <div class="input-field">

            <asp:TextBox ID="txtSearch" runat="server" CssClass="white-text blue" TextMode="Search"></asp:TextBox>


            <label class="label-icon" for="search"><i class="material-icons white-text">search</i></label>

        </div>
    </li>

    <li>

        <asp:LinkButton ID="lbSearch" runat="server" OnClick="btnExecuteAPI_Click"><i id="icoclose" class="material-icons white-text">play_arrow</i></asp:LinkButton>
    </li>

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--   Icon Section   -->
    <div class="row">
        <div class="col m12">
            <div class="icon-block">
                <h2 class="center brown-text"><i class="material-icons">flash_on</i></h2>
                <h3 class="center">Popular Streams</h3>


            </div>
        </div>
    </div>

    <div class="container">
        <asp:Panel ID="Panel1" runat="server"></asp:Panel>
        <br />
        <br />
        <div class="row">
            <div class="col l4">
                <asp:Button ID="btnStream1" runat="server" Text="Stream 1" CssClass="waves-effect waves-light btn blue valign" OnClientClick="return false;" />
            </div>
            <div class="col l4">
                <asp:Button ID="btnStream2" runat="server" Text="Stream 2" CssClass="waves-effect waves-light btn blue" OnClientClick="return false;" />
            </div>
            <div class="col l4">
                <asp:Button ID="btnStream3" runat="server" Text="Stream 3" CssClass="waves-effect waves-light btn blue" OnClientClick="return false;" />
            </div>

        </div>

        <div class="row">
            <div class="col l4">
                <asp:Button ID="btnStream4" runat="server" Text="Stream 4" CssClass="waves-effect waves-light btn blue" OnClientClick="return false;" />
            </div>
            <div class="col l4">
                <asp:Button ID="btnStream5" runat="server" Text="Stream 5" CssClass="waves-effect waves-light btn blue" OnClientClick="return false;" />
            </div>
            <div class="col l4">
                <asp:Button ID="btnStream6" runat="server" Text="Stream 6" CssClass="waves-effect waves-light btn blue" OnClientClick="return false;" />
            </div>


        </div>
        <br />
        <br />
        <br />
        <br />
        <div class="row">
            <div class="col l8">
                <div id="twitchPlayer"></div>
            </div>

            <div class="col l4">
                <div class="row">
                    <asp:Button ID="btnUpvote" runat="server" Text="Upvote" CssClass="waves-effect waves-light btn bignoodle" OnClick="btnUpvote_Click" />
                </div>
                <div class="row">
                    <asp:Button ID="btnDownVote" runat="server" Text="Downvote" CssClass="waves-effect waves-light btn red" OnClick="btnDownVote_Click" />
                </div>
            </div>
        </div>



    </div>

    <asp:HiddenField ID="hfStreamName" runat="server" />
    <!-- /.container -->
    <script src="http://player.twitch.tv/js/embed/v1.js"></script>
    <script>

        var hiddenField = document.querySelector('#ContentPlaceHolder1_hfStreamName');
        var stream = '';
        var options = {
            width: '100%',
            height: 350,
            channel: stream
        };
        var player = new Twitch.Player("twitchPlayer", options);
        player.setChannel(document.querySelector('#ContentPlaceHolder1_btnStream1').value);
        player.setVolume(0.0);


        //declare event listerns for buttons
        var btn1 = document.querySelector('#ContentPlaceHolder1_btnStream1').addEventListener('click', function () {
            player.setChannel(document.querySelector('#ContentPlaceHolder1_btnStream1').value);
            hiddenField.value = document.querySelector('#ContentPlaceHolder1_btnStream1').value;

            var ico = document.querySelector('#icoclose');
            ico.style.visibility = false;

        });
        var btn2 = document.querySelector('#ContentPlaceHolder1_btnStream2').addEventListener('click', function () {
            player.setChannel(document.querySelector('#ContentPlaceHolder1_btnStream2').value);
            hiddenField.value = document.querySelector('#ContentPlaceHolder1_btnStream2').value;
        });
        var btn3 = document.querySelector('#ContentPlaceHolder1_btnStream3').addEventListener('click', function () {
            player.setChannel(document.querySelector('#ContentPlaceHolder1_btnStream3').value);
            hiddenField.value = document.querySelector('#ContentPlaceHolder1_btnStream3').value;
        });
        var btn4 = document.querySelector('#ContentPlaceHolder1_btnStream4').addEventListener('click', function () {
            player.setChannel(document.querySelector('#ContentPlaceHolder1_btnStream4').value);
            hiddenField.value = document.querySelector('#ContentPlaceHolder1_btnStream4').value;
        });
        var btn5 = document.querySelector('#ContentPlaceHolder1_btnStream5').addEventListener('click', function () {
            player.setChannel(document.querySelector('#ContentPlaceHolder1_btnStream5').value);
            hiddenField.value = document.querySelector('#ContentPlaceHolder1_btnStream5').value;
        });
        var btn6 = document.querySelector('#ContentPlaceHolder1_btnStream6').addEventListener('click', function () {
            player.setChannel(document.querySelector('#ContentPlaceHolder1_btnStream6').value);
            hiddenField.value = document.querySelector('#ContentPlaceHolder1_btnStream6').value;
        });



    </script>


    <br />
    <br />
    <br />
    <br />

    <br />
    <br />

    <asp:TextBox ID="txtHeros" runat="server" Visible="true" TextMode="MultiLine" Height="600px"></asp:TextBox>

    <div class="container">

        <div class="row">
            <div class="col s1" style="height: 75px;">
                <asp:Image ID="imgProfile" runat="server" ImageUrl="~/Images/pic.png" Height="75px" />
            </div>

            <div runat="server" id="divUser" class="col s2 valign-wrapper" style="height: 75px;">
                stickynote69
            </div>

            <div class="col s1 valign-wrapper" style="height: 75px;">
                <asp:Image ID="imgLevelBorder" runat="server" ImageUrl="~/Images/borderpic.png" Height="75px"></asp:Image>
                <asp:Panel ID="pnlLevelBorder" runat="server"></asp:Panel>


            </div>

            <div class="col s2" style="height: 75px;">
            </div>
            <div class="col s6 valign-wrapper" style="height: 200px;">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/career-portrait.png" Height="200px"></asp:Image>
            </div>


        </div>

        <h4>Casual Stats</h4>
        <asp:Panel ID="pnlCasual" runat="server">
            <asp:Panel ID="pnlCasualRow1" runat="server" CssClass="row">
            </asp:Panel>

            <asp:Panel ID="pnlCasualRow2" runat="server" CssClass="row">
            </asp:Panel>
        </asp:Panel>

        <br />

        <h4>Competitive Stats</h4>
        <asp:Panel ID="pnlCompetitive" runat="server">
            <asp:Panel ID="pnlCompetitiveRow1" runat="server" CssClass="row">
            </asp:Panel>

            <asp:Panel ID="pnlCompetitiveRow2" runat="server" CssClass="row">
            </asp:Panel>
        </asp:Panel>

    </div>

</asp:Content>
