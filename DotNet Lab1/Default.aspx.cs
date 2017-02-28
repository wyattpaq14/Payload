using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using OverwatchAPI;
using System.Threading.Tasks;


namespace DotNet_Lab1
{
    public partial class Default : System.Web.UI.Page
    {
        public string selectedStream;
        public string[] heros = { "Ana", "Bastion", "Dva", "Genji", "Hanzo", "Junkrat", "Lucio", "McCree", "Mei", "Mercy", "Pharah", "Reaper", "Reinhardt", "Roadhog",
            "Soldier76", "Sombra", "Symmetra", "Torbjorn", "Tracer", "Widowmaker", "Winston", "Zarya", "Zenyatta" };
        public int[] hours = new int[23];
        protected void Page_Load(object sender, EventArgs e)
        {
            txtSearch.Attributes.Add("Placeholder", "Search Battle Tag");

            txtHeros.Text = "";


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
            //new Task(new Default : System.Web.UI.Page.RunDemo).Start();
        }

        async Task RunDemo()
        {

            OverwatchPlayer player = new OverwatchPlayer(txtSearch.Text);

            await player.DetectPlatform();
            await player.DetectRegionPC();
            await player.UpdateStats();

            
            WritePlayer(player);
            


        }

        public void WritePlayer(OverwatchPlayer player)
        {
            string heroName = "Dva";
            txtHeros.Text += "Username: " + player.Username + " Platform: " + player.Platform + " Level: " + player.PlayerLevel + " Rank: " + player.CompetitiveRank;
            txtHeros.Text += "\n---------------------------\n";
            txtHeros.Text += "\nPlayer Portrait: " + player.ProfilePortraitURL;
            txtHeros.Text += "\n---------------------------\n";
            txtHeros.Text += "\nCasual Stats";
            txtHeros.Text += "\n---------------------------\n";
            try
            {
                foreach (var item in player.CasualStats.GetHero(heroName).GetCategory("Hero Specific"))
                    txtHeros.Text += "\n " + item.Name + " : " + item.Value + "\n";
            }
            catch (NullReferenceException)
            {
                //catches eexception thrown due to no time stats
            }

            txtHeros.Text += "\n---------------------------\n";
            txtHeros.Text += "\nCompetitive Stats \n";
            txtHeros.Text += "\n---------------------------\n";
            //foreach (var item in player.CompetitiveStats.GetHero("AllHeroes").GetCategory("Game"))
            //{
            //    txtHeros.Text += item.Name + " : " + item.Value;
            //}

            txtHeros.Text += "\n---------------------------\n";
            txtHeros.Text += "\nGeneral Achievements: \n";
            txtHeros.Text += "\n---------------------------\n";
            try
            {
                foreach (var item in player.Achievements.GetCategory("General"))
                    txtHeros.Text += "\n " + item.Name + " : " + item.IsUnlocked + "\n";
            }
            catch (NullReferenceException)
            {
                //catches eexception thrown due to no time stats
            }

            txtHeros.Text += "\n---------------------------\n";

        }
    }
}