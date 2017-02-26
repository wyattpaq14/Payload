using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace DotNet_Lab1
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {



                //Draw login/logout buttons based on IsAuthenticated
                if (Request.IsAuthenticated)
                {
                    lbLoginState.Text = "Logout";


                    lblGreetings.Text = "Welcome " + Session["FullName"] + "!";
                }
                else if (!Request.IsAuthenticated)
                {
                    lbLoginState.Text = "Login";


                    lblGreetings.Text = "Welcome " + Session["FullName"] + "!";
                    Response.Redirect("~/Home");
                }

            }
        }

        protected void lbLoginState_Click(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {

                FormsAuthentication.SignOut();
                Session["FullName"] = "Guest";

                Response.Redirect("~/Home");

            }
            else if (!Request.IsAuthenticated)
            {

                //nonexistant page might add in future?
                Response.Redirect("~/Home/Sign-In");

            }
        }

        protected void lbAdminPanel_Click(object sender, EventArgs e)
        {
            
        }

        protected void lbPlayerInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Player-Infos");
        }

        protected void lbUsers_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Users");
        }

        protected void lbStreams_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Streams");
        }
    }
}