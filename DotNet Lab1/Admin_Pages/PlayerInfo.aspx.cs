using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNet_Lab1.App_Code;

namespace DotNet_Lab1.Admin_Pages
{
    public partial class PlayerInfo : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                string battleTag = RouteData.Values["BattleTag"].ToString();

                if (battleTag != "")
                {
                    PlayerInformation info = new PlayerInformation(battleTag);

                    btnInsert.Visible = false;
                    txtUserID.Enabled = false;
                    txtUserID.Visible = false;
                    lblUserID.Visible = false;


                    txtPlayTime.Text = info.PlayTime.ToString();
                    txtBattleID.Text = info.BattleID.ToString();
                    txtBattleTag.Text = info.BattleTag;
                    txtPlayerRank.Text = info.PlayerRank.ToString();
                    txtTopHero.Text = info.TopHero;
                    txtUserID.Text = info.UserID.ToString();
                }
                else if (battleTag == "")
                {

                    btnUpdate.Visible = false;
                    txtPlayTime.Text = "";
                    txtBattleID.Text = "";
                    txtBattleTag.Text = "";
                    txtPlayerRank.Text = "";
                    txtTopHero.Text = "";
                    txtUserID.Text = "";



                }

            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //here we will update the selected player-info

            //to-do: incorporate api fetch here

            //create new obj to forward to player-info class

            PlayerInformation p_info = new PlayerInformation();

            p_info.PlayTime = Convert.ToInt32(txtPlayTime.Text);
            p_info.BattleID = Convert.ToInt32(txtBattleID.Text);
            p_info.BattleTag = txtBattleTag.Text;
            p_info.PlayerRank = Convert.ToInt32(txtPlayerRank.Text);
            p_info.TopHero = txtTopHero.Text;
            p_info.UserID = Convert.ToInt32(txtUserID.Text);


            PlayerInformation.UpdatePlayerInfo(p_info);


        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            PlayerInformation p_info = new PlayerInformation();

            p_info.PlayTime = Convert.ToInt32(txtPlayTime.Text);
            p_info.BattleID = Convert.ToInt32(txtBattleID.Text);
            p_info.BattleTag = txtBattleTag.Text;
            p_info.PlayerRank = Convert.ToInt32(txtPlayerRank.Text);
            p_info.TopHero = txtTopHero.Text;
            p_info.UserID = Convert.ToInt32(txtUserID.Text);



            PlayerInformation.InsertPlayerInfo(p_info);

            Response.Redirect("~/Admin/Streams");
        }
    }
}