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


                int battleID = Convert.ToInt32(RouteData.Values["BattleID"]);
                PlayerInformation info = new PlayerInformation(battleID);


                txtAvatar.Text = info.Avatar;
                txtBattleID.Text = info.BattleID.ToString();
                txtBattleTag.Text = info.BattleTag;
                txtCasualStat1.Text = info.CasualStat1.ToString();
                txtCasualStat2.Text = info.CasualStat2.ToString();
                txtCasualStat3.Text = info.CasualStat3.ToString();
                txtCompetitiveStat1.Text = info.CompetitiveStat1.ToString();
                txtCompetitiveStat2.Text = info.CompetitiveStat2.ToString();
                txtCompetitiveStat3.Text = info.CompetitiveStat3.ToString();
                txtEmblem.Text = info.Emblem;
                txtLevelBorder.Text = info.LevelBorder;
                txtPlayerRank.Text = info.PlayerRank.ToString();
                txtTopHero.Text = info.TopHero;
                txtUserID.Text = info.UserID.ToString();

            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //here we will update the selected player-info

            //to-do: incorporate api fetch here

            //create new obj to forward to player-info class

            PlayerInformation p_info = new PlayerInformation();

            p_info.Avatar = txtAvatar.Text;
            p_info.BattleID = Convert.ToInt32(txtBattleID.Text);
            p_info.BattleTag = txtBattleTag.Text;
            p_info.CasualStat1 = Convert.ToInt32(txtCasualStat1.Text);
            p_info.CasualStat2 = Convert.ToInt32(txtCasualStat2.Text);
            p_info.CasualStat3 = Convert.ToInt32(txtCasualStat3.Text);
            p_info.CompetitiveStat1 = Convert.ToInt32(txtCompetitiveStat1.Text);
            p_info.CompetitiveStat2 = Convert.ToInt32(txtCompetitiveStat2.Text);
            p_info.CompetitiveStat3 = Convert.ToInt32(txtCompetitiveStat3.Text);
            p_info.Emblem = txtEmblem.Text;
            p_info.LevelBorder = txtLevelBorder.Text;
            p_info.PlayerRank = Convert.ToInt32(txtPlayerRank.Text);
            p_info.TopHero = txtTopHero.Text;
            p_info.UserID = Convert.ToInt32(txtUserID.Text);


            PlayerInformation.UpdatePlayerInfo(p_info);


        }


    }
}