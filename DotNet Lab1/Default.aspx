<%@ Page Title="" Language="C#" MasterPageFile="~/lab01.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DotNet_Lab1.Default" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--   Icon Section   -->
    <div class="row">
        <div class="col m12">
            <div class="icon-block">
                <h2 class="center brown-text"><i class="material-icons">flash_on</i></h2>
                <h5 class="center">Popular Streams</h5>


            </div>
        </div>
    </div>

    <div class="container">
        <asp:Panel ID="Panel1" runat="server"></asp:Panel>
        <br />
        <br />
        <div class="row">
            <div class="col l4">
                <asp:Button ID="btnStream1" runat="server" Text="Stream 1" CssClass="waves-effect waves-light btn blue" OnClientClick="return false;" />
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
                    <asp:Button ID="btnUpvote" runat="server" Text="Upvote" CssClass="waves-effect waves-light btn" OnClick="btnUpvote_Click" />
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

    <asp:Button ID="btnExecuteAPI" runat="server" CssClass="btn" Text="Execute API Fetch" OnClick="btnExecuteAPI_Click" />
    <br /><br />
    <asp:TextBox ID="txtHeros" runat="server" TextMode="MultiLine"></asp:TextBox>


</asp:Content>
