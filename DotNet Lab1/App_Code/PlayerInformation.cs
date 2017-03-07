using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using OverwatchAPI;

namespace DotNet_Lab1.App_Code
{
    public class PlayerInformation
    {

        #region constructors

        public PlayerInformation()
        {

        }

        public PlayerInformation(string BattleTag)
        {
            DataTable dt = getPlayerInfo(BattleTag);
            if (dt.Rows.Count > 0)
            {
                this.PlayerRank = (int)dt.Rows[0]["PlayerRank"];
                this.UserID = (int)dt.Rows[0]["UserID"];
                this.TopHero = dt.Rows[0]["TopHero"].ToString();
                this.PlayTime = (int)dt.Rows[0]["PlayTime"];
                this.BattleID = (int)dt.Rows[0]["BattleID"];
                this.BattleTag = dt.Rows[0]["BattleTag"].ToString();

            }
        }


        #endregion

        #region properties


        public int BattleID { get; set; }

        public string BattleTag { get; set; }

        public int UserID { get; set; }

        public string TopHero { get; set; }

        public int PlayerRank { get; set; }

        public int PlayTime { get; set; }



        #endregion

        #region methods

        private static DataTable getPlayerInfo(string BatleTag)
        {

            DataTable dt = new DataTable();

            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQL Server"].ConnectionString);
            SqlCommand cmd = new SqlCommand("getAllPlayerInfo_byBattleTag", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BattleTag", SqlDbType.VarChar).Value = BatleTag;

            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch
            {

            }
            finally
            {
                cn.Close();
            }



            return dt;
        }

        public static bool checkExistingPlayer(string battleTag)
        {

            DataTable dt = getPlayerInfo(battleTag);
            if (dt.Rows.Count > 0)
            {
                
                //player exists
                return true;
            }
            else if (dt.Rows.Count == 0)
            {
                //player doesnt exist
                return false;
            }
            else
            {
                //error probaly occured
                return false;
            }
           




        }



        public static bool UpdatePlayerInfo(PlayerInformation player)
        {

            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQL Server"].ConnectionString);
            SqlCommand cmd = new SqlCommand("updatePlayerStatsByBattleTag", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BattleTag", SqlDbType.VarChar).Value = player.BattleTag;
            cmd.Parameters.Add("@BattleID", SqlDbType.Int).Value = player.BattleID;
            cmd.Parameters.Add("@TopHero", SqlDbType.VarChar).Value = player.TopHero;
            cmd.Parameters.Add("@PlayerRank", SqlDbType.Int).Value = player.PlayerRank;
            cmd.Parameters.Add("@PlayTime", SqlDbType.Int).Value = player.PlayTime;

            // Open the database connection and execute the command
            try
            {
                //opens connection to database, most failures happen here
                //check connection string for proper settings
                cn.Open();

                //data adapter object is trasport link between data source and 
                //execute the non-query stored procedure
                cmd.ExecuteNonQuery();
                //id = Convert.ToInt32(cmd.Parameters["@BattleID"].Value);

            }
            catch (Exception exc)
            {
                //just put here to make debugging easier, can look at error directly
                exc.ToString();
            }
            finally
            {
                //must always close connections
                cn.Close();
            }

            bool isUpdated = false;
            return isUpdated;
        }




        public static bool InsertPlayerInfo(PlayerInformation playerinfo)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQL Server"].ConnectionString);
            SqlCommand cmd = new SqlCommand("createNewPlayer", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = playerinfo.UserID;
            cmd.Parameters.Add("@BattleTag", SqlDbType.VarChar).Value = playerinfo.BattleTag;
            cmd.Parameters.Add("@BattleID", SqlDbType.Int).Value = playerinfo.BattleID;
            cmd.Parameters.Add("@TopHero", SqlDbType.VarChar).Value = playerinfo.TopHero;
            cmd.Parameters.Add("@PlayerRank", SqlDbType.Int).Value = playerinfo.PlayerRank;
            cmd.Parameters.Add("@PlayTime", SqlDbType.Int).Value = playerinfo.PlayTime;




            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception exc)
            {
                exc.ToString();

            }
            finally
            {
                cn.Close();
            }
            return false;
        }

        #endregion
    }
}