using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace DotNet_Lab1.Pages
{
    public partial class User : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                int userID = Convert.ToInt32(RouteData.Values["UserID"]);
                App_Code.User user = new App_Code.User(userID);


                txtUserID.Text = user.UserID.ToString();
                txtUserEmail.Text = user.UserEmail.ToString();
                txtUserIsAdmin.Text = user.UserIsAdmin.ToString();
                txtUserIsBanned.Text = user.UserIsBanned.ToString();
                txtUserRank.Text = user.UserRank.ToString();
               

            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
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


        }
    }
}
