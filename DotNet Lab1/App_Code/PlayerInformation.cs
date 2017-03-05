using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DotNet_Lab1.App_Code
{
    public class PlayerInformation
    {

        #region constructors

        public PlayerInformation()
        {

        }

        public PlayerInformation(int BattleID)
        {
            DataTable dt = getPlayerInfo(BattleID);
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

        private static DataTable getPlayerInfo(int BattleID)
        {

            DataTable dt = new DataTable();

            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQL Server"].ConnectionString);
            SqlCommand cmd = new SqlCommand("getPlayerInfoByBattleTag", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BattleID", SqlDbType.Int).Value = BattleID;

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



        public static bool InsertGuest(DataTable guest)
        {
            int id = 0;
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQL Server"].ConnectionString);
            SqlCommand cmd = new SqlCommand("guests_Insert", cn);

            cmd.Parameters.Add("@guest_email", SqlDbType.VarChar).Value = guest.Rows[0]["guest_email"];
            cmd.Parameters.Add("@guest_first", SqlDbType.VarChar).Value = guest.Rows[0]["guest_first"];
            cmd.Parameters.Add("@guest_last", SqlDbType.VarChar).Value = guest.Rows[0]["guest_last"];
            cmd.Parameters.Add("@guest_salt", SqlDbType.VarChar).Value = guest.Rows[0]["guest_salt"];
            cmd.Parameters.Add("@guest_pwd", SqlDbType.VarChar).Value = guest.Rows[0]["guest_pwd"];
            cmd.Parameters.Add("@guest_phone", SqlDbType.VarChar).Value = guest.Rows[0]["guest_phone"];

            // Open the database connection and execute the command
            try
            {
                //opens connection to database, most failures happen here
                //check connection string for proper settings
                cn.Open();
                //data adapter object is trasport link between data source and 
                //execute the non-query stored procedure
                cmd.ExecuteNonQuery();
                id = Convert.ToInt32(cmd.Parameters["@guest_id"].Value);
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





            bool isInserted = false;
            return isInserted;
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
        



        private static DataTable GetGuestByEmail(string email)
        {
            DataTable dt = new DataTable();

            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQL Server"].ConnectionString);
            SqlCommand cmd = new SqlCommand("guest_GetByEmail", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@guest_email", SqlDbType.Int).Value = email;

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