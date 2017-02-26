using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Diagnostics;
using OverwatchAPI;
using System.Threading.Tasks;
using static System.Console;

namespace DotNet_Lab1
{
    public partial class lab01 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            search.Attributes.Add("Placeholder", "Search Battle Tag");

            



            if (!IsPostBack)
            {


                //Declare list



                //Draw login/logout buttons based on IsAuthenticated
                if (Request.IsAuthenticated)
                {
                    lbLoginState.Text = "Logout";


                    lblGreetings.Text = "Welcome " + Session["FullName"] + "!";
                }
                else if (!Request.IsAuthenticated)
                {
                    Session["FullName"] = "Guest";
                    lbLoginState.Text = "Login";


                    lblGreetings.Text = "Welcome " + Session["FullName"] + "!";
                }

                //check admin status to render admin button

                string usrEmail;
                try
                {
                    usrEmail = Session["FullName"].ToString();
                }
                catch
                {
                    usrEmail = "ajoijsoifjd";
                }
                App_Code.User usr = new App_Code.User(usrEmail);

                if (usr.UserIsAdmin)
                {
                    lbAdminPanel.Text = "Admin Panel";
                }
                else
                {
                    lbAdminPanel.Text = "";
                }
            }
        }

        protected void lbLoginState_Click(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {

                FormsAuthentication.SignOut();
                Session.Abandon();
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
            Response.Redirect("~/Admin");
        }


        public void lbSearch_Click(object sender, EventArgs e)
        {
            //Task.Run(() => { this.RunDemo(); }).Wait();
            
        }




        












    }
}