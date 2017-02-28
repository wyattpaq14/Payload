using System;
using System.Collections.Generic;
using System.Web;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Security.Cryptography;

namespace DotNet_Lab1.App_Code
{
    public class User
    {

        #region constructors

        public User()
        {
            this.UserSalt = CreateSalt();
        }

        public User(string email)
        {
            DataTable dt = GetUser(email);
            if (dt.Rows.Count > 0)
            {
                this.UserRank = (int)dt.Rows[0]["UserRank"];
                this.UserEmail = dt.Rows[0]["UserEmail"].ToString();
                this.UserSalt = dt.Rows[0]["UserSalt"].ToString();
                this.UserIsAdmin = (bool)dt.Rows[0]["UserIsAdmin"];
                this.UserIsBanned = (bool)dt.Rows[0]["UserIsBanned"];
                this.UserHashedPw = dt.Rows[0]["UserHashedPw"].ToString();
            }

        }

        public User(int UserID)
        {
            DataTable dt = GetUserByID(UserID);
            if (dt.Rows.Count > 0)
            {

                this.UserID = (int)dt.Rows[0]["UserID"];
                this.UserEmail = dt.Rows[0]["UserEmail"].ToString();
                this.UserSalt = dt.Rows[0]["UserSalt"].ToString();
                this.UserRank = (int)dt.Rows[0]["UserRank"];
                this.UserIsAdmin = (bool)dt.Rows[0]["UserIsAdmin"];
                this.UserIsBanned = (bool)dt.Rows[0]["UserIsBanned"];
                this.UserHashedPw = dt.Rows[0]["UserHashedPw"].ToString();
            }

        }
        #endregion


        #region properties

        public int UserRank { get; set; }

        public int UserID { get; set; }

        public string UserFavStream { get; set; }

        public string UserSalt { get; set; }

        public string UserHashedPw { get; set; }

        public string UserEmail { get; set; }

        public bool UserIsAdmin { get; set; }

        public bool UserIsBanned { get; set; }

        public bool validLogin { get; set; }




        #endregion



        #region methods/functions

        public static string CreateSalt()
        {
            // Generate a cryptographic random number using the cryptographic 
            // service provider
            byte[] saltBytes = new byte[16];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(saltBytes);
            // Return a Base64 string representation of the random number
            return Convert.ToBase64String(saltBytes);
        }


        public static string CreatePasswordHash(string salt, string pwd)
        {
            string saltAndPwd = string.Concat(salt, pwd);
            // Create a new instance of the hash crypto service provider.
            HashAlgorithm hashAlg = new SHA256CryptoServiceProvider();
            // Convert the data to hash to an array of Bytes.
            byte[] bytValue = System.Text.Encoding.UTF8.GetBytes(saltAndPwd);
            // Compute the Hash. This returns an array of Bytes.
            byte[] bytHash = hashAlg.ComputeHash(bytValue);
            // Optionally, represent the hash value as a base64-encoded string, 
            // For example, if you need to display the value or transmit it over a network.
            return Convert.ToBase64String(bytHash);
        }


        public static User Login(string email, string freeTxtPwd)
        {
            User au = new User();
            au.UserEmail = "bsmith@asdf.com";
            au.UserFavStream = "favstream";
            au.UserIsAdmin = false;
            au.UserIsBanned = false;
            au.UserHashedPw = CreatePasswordHash(au.UserSalt, freeTxtPwd);


            return au;




        }

        public bool isAdmin(string email)
        {
            DataTable dt = GetUser(email);
            if (dt.Rows.Count > 0)
            {
                this.UserIsAdmin = (bool)dt.Rows[0]["UserIsAdmin"];
            }

            if (this.UserIsAdmin)
            {
                return true;
            }
            else
            {
                return false;
            }
        }




        public static DataTable GetUser(string email)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQL Server"].ConnectionString);
            SqlCommand cmd = new SqlCommand("users_getByEmail", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter pEmail = new SqlParameter("@UserEmail", SqlDbType.VarChar);
            pEmail.Value = email;
            cmd.Parameters.Add(pEmail);


            DataTable dt = new DataTable();


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


        public static DataTable GetUserByID(int UserID)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQL Server"].ConnectionString);
            SqlCommand cmd = new SqlCommand("users_getByID", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter pUserID = new SqlParameter("@UserID", SqlDbType.VarChar);
            pUserID.Value = UserID;
            cmd.Parameters.Add(pUserID);


            DataTable dt = new DataTable();


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



        private static DataTable getTblById(int tblId)
        {

            DataTable dt = new DataTable();

            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQL Server"].ConnectionString);
            SqlCommand cmd = new SqlCommand("users_getbyid", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@user_id", SqlDbType.Int).Value = tblId;

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


        public static bool InsertUser(User usr)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQL Server"].ConnectionString);
            SqlCommand cmd = new SqlCommand("createNewUser", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@UserRank", SqlDbType.Int).Value = usr.UserRank;
            cmd.Parameters.Add("@UserEmail", SqlDbType.VarChar).Value = usr.UserEmail;
            cmd.Parameters.Add("@UserSalt", SqlDbType.VarChar).Value = usr.UserSalt;
            cmd.Parameters.Add("@UserIsAdmin", SqlDbType.Bit).Value = usr.UserIsAdmin;
            cmd.Parameters.Add("@UserIsBanned", SqlDbType.Bit).Value = usr.UserIsBanned;
            cmd.Parameters.Add("@UserHashedPw", SqlDbType.VarChar).Value = usr.UserHashedPw;




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

        public static bool UpdateUserInfo(User user)
        {

            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQL Server"].ConnectionString);
            SqlCommand cmd = new SqlCommand("updateUserInfoByID", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = user.UserID;
            cmd.Parameters.Add("@UserEmail", SqlDbType.VarChar).Value = user.UserEmail;
            cmd.Parameters.Add("@UserRank", SqlDbType.Int).Value = user.UserRank;
            cmd.Parameters.Add("@UserIsBanned", SqlDbType.Bit).Value = user.UserIsBanned;
            cmd.Parameters.Add("@UserIsAdmin", SqlDbType.Bit).Value = user.UserIsAdmin;
            

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

        #endregion
    }
}