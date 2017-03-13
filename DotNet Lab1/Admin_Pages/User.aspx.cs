using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNet_Lab1.Admin_Pages
{
    public partial class User1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                int userID = Convert.ToInt32(RouteData.Values["UserID"]);

                if (userID > 0)
                {  
                    //update statement
                    App_Code.User user = new App_Code.User(userID);


                    txtUserID.Text = user.UserID.ToString();
                    txtUserEmail.Text = user.UserEmail.ToString();
                    txtUserIsAdmin.Text = user.UserIsAdmin.ToString();
                    txtUserIsBanned.Text = user.UserIsBanned.ToString();
                    txtUserRank.Text = user.UserRank.ToString();
                    lbInsert.Visible = false;
                }
                else if (userID <= 0)
                {

                    //insert statement
                    btnDelete.Visible = false;
                    lblUserID.Visible = false;
                    txtUserID.Visible = false; 
                    txtUserID.Enabled = false;
                    txtUserEmail.Text = "";
                    txtUserIsAdmin.Text = "";
                    txtUserIsBanned.Text = "";
                    txtUserRank.Text = "";
                    lbUpdate.Visible = false;

                }



            }
        }


        protected void lbUpdate_Click(object sender, EventArgs e)
        {
            //here we will update the selected player-info

            //to-do: incorporate api fetch here

            //create new obj to forward to player-info class

            App_Code.User u_info = new App_Code.User();


            u_info.UserID = Convert.ToInt32(txtUserID.Text);
            u_info.UserEmail = txtUserEmail.Text;
            u_info.UserIsAdmin = Convert.ToBoolean(txtUserIsAdmin.Text);
            u_info.UserIsBanned = Convert.ToBoolean(txtUserIsBanned.Text);
            u_info.UserRank = Convert.ToInt32(txtUserRank.Text);



            App_Code.User.UpdateUserInfo(u_info);

            Response.Redirect("~/Admin/Users");
        }

        protected void lbInsert_Click(object sender, EventArgs e)
        {
            App_Code.User u_info = new App_Code.User();


            u_info.UserEmail = txtUserEmail.Text;
            u_info.UserIsAdmin = Convert.ToBoolean(txtUserIsAdmin.Text);
            u_info.UserIsBanned = Convert.ToBoolean(txtUserIsBanned.Text);
            u_info.UserRank = Convert.ToInt32(txtUserRank.Text);

            u_info.UserHashedPw = App_Code.User.CreatePasswordHash(u_info.UserSalt, txtUserPassword.Text);


            App_Code.User.InsertUser(u_info);

            Response.Redirect("~/Admin/Users");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            App_Code.User.DeleteUser(Convert.ToInt32(txtUserID.Text));
            Response.Redirect("~/Admin/Users");
        }
    }
}