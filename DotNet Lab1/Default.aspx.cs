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

        protected void Page_Load(object sender, EventArgs e)
        {

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
            TextBox txttest = new TextBox();

            txttest.Attributes["bgcolor"] = "lightblue";
            txttest.Attributes["width"] = "200px";
            txttest.Attributes["height"] = "200px";
            txttest.Text = "hello world";
            Panel1.Controls.Add(txttest);
            
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

            OverwatchPlayer player = new OverwatchPlayer("Jorohara#21710");

            await player.DetectPlatform();
            await player.DetectRegionPC();
            await player.UpdateStats();

            //foreach (OverwatchPlayer player in playerCollection)
            WritePlayer(player);
            // txtHeros.Text += "Username: " + player.Username + " Platform: " + player.Platform + " Level: " + player.PlayerLevel + " Rank: " + player.CompetitiveRank;


        }

        public void WritePlayer(OverwatchPlayer player)
        {
            txtHeros.Text += "Username: " + player.Username + " Platform: " + player.Platform + " Level: " + player.PlayerLevel + " Rank: " + player.CompetitiveRank;
            txtHeros.Text += "---------------------------\n\n";
            txtHeros.Text += "Player Portrait: " + player.ProfilePortraitURL;
            txtHeros.Text += "---------------------------\n\n";
            txtHeros.Text += "Casual Stats";
            txtHeros.Text += "---------------------------\n\n";
            foreach (var item in player.CasualStats.GetHero("AllHeroes").GetCategory("Game"))
            {
                txtHeros.Text += item.Name + " : " + item.Value;
            }

            txtHeros.Text += "---------------------------\n\n";
            txtHeros.Text += "Competitive Stats";
            txtHeros.Text += "---------------------------\n\n";
            foreach (var item in player.CompetitiveStats.GetHero("AllHeroes").GetCategory("Game"))
            {
                txtHeros.Text += item.Name + " : " + item.Value;
            }

            txtHeros.Text += "---------------------------\n\n";
            txtHeros.Text += "General Achievements: ";
            txtHeros.Text += "---------------------------\n\n";
            foreach (var item in player.Achievements.GetCategory("General"))
                txtHeros.Text += item.Name + " : " + item.IsUnlocked;

            txtHeros.Text += "---------------------------\n\n";

        }
    }
}