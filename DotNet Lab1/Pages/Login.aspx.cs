using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using DotNet_Lab1.App_Code;



namespace DotNet_Lab1.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            App_Code.User you = new App_Code.User(txtUsername.Text);
            string hsh = App_Code.User.CreatePasswordHash(you.UserSalt, txtPassword.Text);

            //check password
            if (hsh == you.UserHashedPw)
            {
                you.validLogin = true;
            }



            //check username is valid by checking if exception is thrown

            try
            {
                int emailLength = you.UserEmail.Length;
            }
            catch (NullReferenceException)
            {
                you.validLogin = false;
            }


            //use validLogin to create auth ticket

            if (you.validLogin)
            {
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, you.UserID.ToString(), DateTime.Now, DateTime.Now.AddMinutes(480), false, "Admin");


                //encrypt cookies
                string encryptedTicket = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

                //add cookies 
                Response.Cookies.Add(cookie);

                //create session variable
                Session["FullName"] = you.UserEmail;

                //final redirect, well redirect to admin pages
                Response.Redirect("~/Home");

            }

            
        }

    }
}