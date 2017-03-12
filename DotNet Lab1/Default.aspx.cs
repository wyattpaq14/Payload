using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Linq;
using System.Web.UI.WebControls;
using System.Data;
using OverwatchAPI;
using System.Threading.Tasks;


namespace DotNet_Lab1
{
    public partial class Default : System.Web.UI.Page
    {
        //declare variables

        //variable to determin if http request has been ran
        public bool apiPull = false;
        public string selectedStream;
        //staticly assigned array with heros
        public string[] heros = { "Ana", "Bastion", "Dva", "Genji", "Hanzo", "Junkrat", "Lucio", "McCree", "Mei", "Mercy", "Pharah", "Reaper", "Reinhardt", "Roadhog",
            "Soldier-76", "Sombra", "Symmetra", "Torbjorn", "Tracer", "Widowmaker", "Winston", "Zarya", "Zenyatta" };

        //secondary array to store hero hours in relation to the above array
        public double[] hours = new double[23];

        //default variable
        public string heroName = "Ana";



        protected void Page_Load(object sender, EventArgs e)
        {
            txtSearch.Attributes.Add("Placeholder", "Search Battle Tag");



            try
            {
                selectedStream = hfStreamName.Value;
            }
            catch
            {
                //error
            }
            if (!IsPostBack)
            {

                DisplayPopularStreams();
                divPlayerStats.Visible = false;


            }
        }

        private void DisplayPopularStreams()
        {

            App_Code.TStream streams = new App_Code.TStream();


            DataTable dt = App_Code.TStream.getPopularStreams();

            btnStream1.Text = dt.Rows[0]["StreamName"].ToString();
            btnStream2.Text = dt.Rows[1]["StreamName"].ToString();
            btnStream3.Text = dt.Rows[2]["StreamName"].ToString();
            btnStream4.Text = dt.Rows[3]["StreamName"].ToString();
            btnStream5.Text = dt.Rows[4]["StreamName"].ToString();
            btnStream6.Text = dt.Rows[5]["StreamName"].ToString();

            selectedStream = btnStream1.Text;
            hfStreamName.Value = selectedStream;
        }

        //up vote selected stream
        protected void btnUpvote_Click(object sender, EventArgs e)
        {
            App_Code.TStream.AddStreamPoints(selectedStream);
            DisplayPopularStreams();

        }



        //down vote selected stream
        protected void btnDownVote_Click(object sender, EventArgs e)
        {
            App_Code.TStream.SubStreamPoints(selectedStream);
            DisplayPopularStreams();
        }

        protected void btnExecuteAPI_Click(object sender, EventArgs e)
        {
            //registers asyn task
            registerRunTask();

        }

        async Task StorePlayer()
        {

            OverwatchPlayer player = new OverwatchPlayer(txtSearch.Text);

            await player.DetectPlatform();
            await player.DetectRegionPC();
            await player.UpdateStats();



            if (!apiPull)
            {
                WritePlayer(player);
            }
            else
            {
                //do nothing
            }

        }

        public void WritePlayer(OverwatchPlayer player)
        {


            //hide warning text 


            pnlSecPlayerSearch.Visible = false;

            //set profile pic

            imgPlayerProfile.ImageUrl = player.ProfilePortraitURL;

            //set profile username

            divPlayername.InnerHtml = player.Username;

            heroName = getTopHero(player);

            //https://blzgdapipro-a.akamaihd.net/hero/lucio/career-portrait.png

            imgHero.ImageUrl = "https://blzgdapipro-a.akamaihd.net/hero/" + heroName.ToLower() + "/career-portrait.png";

            divPlayerLevel.InnerHtml = "Level: " + player.PlayerLevel;
            try
            {
                //loop to output Casual Hero Speficifc Stats
                foreach (var item in player.CasualStats.GetHero(heroName).GetCategory("Hero Specific"))
                {

                    divCasualRow1.Controls.Add(new LiteralControl("<div class='col s3 valign-wrapper' style='height:100px; font-size:20px;'>" + item.Name + " : " + item.Value + "</div>"));
                }


            }
            catch (NullReferenceException)
            {
                //catches eexception thrown due to heros that havent been used
            }


            try
            {
                //loop to output Casual Combat Stats
                foreach (var item in player.CasualStats.GetHero(heroName).GetCategory("Combat"))
                {

                    divCasualRow2.Controls.Add(new LiteralControl("<div class='col s3 valign-wrapper' style='height:100px; font-size:20px;'>" + item.Name + " : " + item.Value + "</div>"));
                }

            }
            catch (NullReferenceException)
            {
                //catches eexception thrown due to heros that havent been used
            }

            try
            {
                //loop to output Competitive Hero Specific Stats
                foreach (var item in player.CompetitiveStats.GetHero(heroName).GetCategory("Hero Specific"))
                {

                    divCompRow1.Controls.Add(new LiteralControl("<div class='col s3 valign-wrapper' style='height:100px; font-size:20px;'>" + item.Name + " : " + item.Value + "</div>"));
                }
            }
            catch (NullReferenceException)
            {
                //catches eexception thrown due to heros that havent been used
            }

            try
            {
                //loop to output Competitive Combat Stats
                foreach (var item in player.CompetitiveStats.GetHero(heroName).GetCategory("Combat"))
                {

                    divCompRow2.Controls.Add(new LiteralControl("<div class='col s3 valign-wrapper' style='height:100px; font-size:20px;'>" + item.Name + " : " + item.Value + "</div>"));
                }
            }
            catch (NullReferenceException)
            {
                //catches eexception thrown due to heros that havent been used
            }





            apiPull = true;


            //write player to db but first we have to check if the player allready exists

            //first we have to format playaer name from stickynote69#1863 to stickynote69

            //since you can search with a # or - separating battleID, we need to do an if statement, and replace them seprately

            string[] splitUsername = { };

            //we will now check for '#'

            if (player.Username.IndexOf('#') != -1)
            {
                //username contains '#'
                splitUsername = player.Username.Split('#');

            }
            else if (player.Username.IndexOf('-') != -1)
            {
                //username contains '-'
                splitUsername = player.Username.Split('-');
            }
            else
            {
                splitUsername[0] = player.Username;
            }


            //now we will check if player exists

            if (App_Code.PlayerInformation.checkExistingPlayer(splitUsername[0]))
            {

                //player exists so we will update

                App_Code.PlayerInformation ply = new App_Code.PlayerInformation();

                ply.BattleTag = splitUsername[0];
                ply.BattleID = Convert.ToInt32(splitUsername[1]);
                ply.TopHero = heroName;
                ply.PlayerRank = player.PlayerLevel;
                ply.PlayTime = Convert.ToInt32(player.CasualStats.GetHero(heroName).GetCategory("Game").GetStat("Time Played").Value / 60 / 60);

                App_Code.PlayerInformation.UpdatePlayerInfo(ply);

            }
            else if (!App_Code.PlayerInformation.checkExistingPlayer(splitUsername[0]))
            {
                //player doesnt exist so we will insert

                App_Code.PlayerInformation ply = new App_Code.PlayerInformation();


                //need to convert email to user ID


                DataTable usrTbl = App_Code.User.GetUser(Session["FullName"].ToString());

                if (usrTbl.Rows.Count > 0)
                {
                    ply.UserID = (int)usrTbl.Rows[0]["UserID"];
                }
                else
                {
                    ply.UserID = 0;
                }







                ply.BattleTag = splitUsername[0];
                ply.BattleID = Convert.ToInt32(splitUsername[1]);
                ply.TopHero = heroName;
                ply.PlayerRank = player.PlayerLevel;
                ply.PlayTime = Convert.ToInt32(player.CasualStats.GetHero(heroName).GetCategory("Game").GetStat("Time Played").Value / 60 / 60);


                App_Code.PlayerInformation.InsertPlayerInfo(ply);
            }


            //make form visiable
            divPlayerStats.Visible = true;

            //refresh gridview
            this.gvPlayerLeaderbord.DataBind();

        }

        public string getTopHero(OverwatchPlayer player)
        {

            for (int i = 0; i < 22; i++)
            {
                try
                {
                    hours[i] = Convert.ToDouble(player.CasualStats.GetHero(heros[i]).GetCategory("Game").GetStat("Time Played").Value / 60 / 60);
                }
                catch (NullReferenceException)
                {

                }

            }
            int topHeroIndex = hours.ToList().IndexOf(Convert.ToInt32(hours.Max()));


            return heros[topHeroIndex];

        }




        public void registerRunTask()
        {
            RegisterAsyncTask(new PageAsyncTask(StorePlayer));
            Task.Run(StorePlayer);
        }
    }
}