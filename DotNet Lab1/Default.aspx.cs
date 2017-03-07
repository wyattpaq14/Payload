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
        public bool apiPull = false;
        public string selectedStream;
        public string[] heros = { "Ana", "Bastion", "Dva", "Genji", "Hanzo", "Junkrat", "Lucio", "McCree", "Mei", "Mercy", "Pharah", "Reaper", "Reinhardt", "Roadhog",
            "Soldier76", "Sombra", "Symmetra", "Torbjorn", "Tracer", "Widowmaker", "Winston", "Zarya", "Zenyatta" };

        public double[] hours = new double[23];

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


        protected void btnUpvote_Click(object sender, EventArgs e)
        {
            App_Code.TStream.AddStreamPoints(selectedStream);
            DisplayPopularStreams();

        }




        protected void btnDownVote_Click(object sender, EventArgs e)
        {
            App_Code.TStream.SubStreamPoints(selectedStream);
            DisplayPopularStreams();
        }

        protected void btnExecuteAPI_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(RunDemo));
            Task.Run(RunDemo);

        }

        async Task RunDemo()
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




            //set profile pic

            //imgProfile.ImageUrl = player.ProfilePortraitURL;

            ////set profile username

            //divUser.InnerHtml = player.Username;

            //heroName = getTopHero(player);

            ////https://blzgdapipro-a.akamaihd.net/hero/lucio/career-portrait.png

            //imgCareerPortrait.ImageUrl = "https://blzgdapipro-a.akamaihd.net/hero/" + heroName.ToLower() + "/career-portrait.png";
            //try
            //{
            //    //loop to output Casual Hero Speficifc Stats
            //    foreach (var item in player.CasualStats.GetHero(heroName).GetCategory("Hero Specific"))
            //    {

            //        pnlCasualRow1.Controls.Add(new LiteralControl("<div class='col s3 valign-wrapper red' style='height:100px;'>" + item.Name + " : " + item.Value + "</div>"));
            //    }


            //}
            //catch (NullReferenceException)
            //{
            //    //catches eexception thrown due to heros that havent been used
            //}


            //try
            //{
            //    //loop to output Casual Combat Stats
            //    foreach (var item in player.CasualStats.GetHero(heroName).GetCategory("Combat"))
            //    {
                    
            //        pnlCasualRow2.Controls.Add(new LiteralControl("<div class='col s3 valign-wrapper red' style='height:100px;'>" + item.Name + " : " + item.Value + "</div>"));
            //    }

            //}
            //catch (NullReferenceException)
            //{
            //    //catches eexception thrown due to heros that havent been used
            //}

            //try
            //{
            //    //loop to output Competitive Hero Specific Stats
            //    foreach (var item in player.CasualStats.GetHero(heroName).GetCategory("Hero Specific"))
            //    {

            //        pnlCompetitiveRow1.Controls.Add(new LiteralControl("<div class='col s3 valign-wrapper red' style='height:100px;'>" + item.Name + " : " + item.Value + "</div>"));
            //    }
            //}
            //catch (NullReferenceException)
            //{
            //    //catches eexception thrown due to heros that havent been used
            //}

            //try
            //{
            //    //loop to output Competitive Combat Stats
            //    foreach (var item in player.CasualStats.GetHero(heroName).GetCategory("Combat"))
            //    {

            //        pnlCompetitiveRow2.Controls.Add(new LiteralControl("<div class='col s3 valign-wrapper red' style='height:100px;'>" + item.Name + " : " + item.Value + "</div>"));
            //    }
            //}
            //catch (NullReferenceException)
            //{
            //    //catches eexception thrown due to heros that havent been used
            //}





            //apiPull = true;
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
    }
}