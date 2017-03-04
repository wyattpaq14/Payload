using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DotNet_Lab1.App_Code
{
    public class TStream
    {

        #region constructors

        public TStream()
        {

        }

        public TStream(int streamID)
        {
            DataTable dt = getStreamByStreamID(streamID);

            if (dt.Rows.Count > 0)
            {
                this.StreamID = (int)dt.Rows[0]["StreamID"];
                this.StreamName = dt.Rows[0]["StreamName"].ToString();
                this.StreamRank = (int)dt.Rows[0]["StreamRank"];
                this.StreamIsBanned = (bool)dt.Rows[0]["StreamIsBanned"];
            }
        }
        #endregion


        #region properties

        public int StreamID { get; set; }

        public string StreamName { get; set; }

        public int StreamRank { get; set; }

        public bool StreamIsBanned { get; set; }



        #endregion



        #region methods/functions

        private static DataTable getStreamByStreamID(int streamID)
        {

            DataTable dt = new DataTable();

            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQL Server"].ConnectionString);
            SqlCommand cmd = new SqlCommand("getStream_byStreamID", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@StreamID", SqlDbType.Int).Value = streamID;

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




        public static DataTable getPopularStreams()
        {

            DataTable dt = new DataTable();

            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQL Server"].ConnectionString);
            SqlCommand cmd = new SqlCommand("getPopularStreams", cn);
            cmd.CommandType = CommandType.StoredProcedure;

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

        public static bool AddStreamPoints(string StreamName)
        {

            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQL Server"].ConnectionString);
            SqlCommand cmd = new SqlCommand("addStreamPointsByStreamName", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@StreamName", SqlDbType.VarChar).Value = StreamName;


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

        public static bool SubStreamPoints(string StreamName)
        {

            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQL Server"].ConnectionString);
            SqlCommand cmd = new SqlCommand("subStreamPointsByStreamName", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@StreamName", SqlDbType.VarChar).Value = StreamName;


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


        public static bool UpdateStreamInfo(TStream stream)
        {

            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQL Server"].ConnectionString);
            SqlCommand cmd = new SqlCommand("updateStreamByStreamID", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@StreamID", SqlDbType.Int).Value = stream.StreamID;
            cmd.Parameters.Add("@StreamName", SqlDbType.VarChar).Value = stream.StreamName;
            cmd.Parameters.Add("@StreamRank", SqlDbType.Int).Value = stream.StreamRank;
            cmd.Parameters.Add("@StreamIsBanned", SqlDbType.Bit).Value = stream.StreamIsBanned;


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




        public static bool InsertStream(TStream stream)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQL Server"].ConnectionString);
            SqlCommand cmd = new SqlCommand("createNewStream", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@StreamName", SqlDbType.VarChar).Value = stream.StreamName;
            cmd.Parameters.Add("@StreamRank", SqlDbType.Int).Value = stream.StreamRank;
            cmd.Parameters.Add("@StreamIsBanned", SqlDbType.Bit).Value = stream.StreamIsBanned;




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