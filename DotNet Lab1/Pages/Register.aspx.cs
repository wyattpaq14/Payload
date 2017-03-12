using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNet_Lab1.Pages
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            DataTable usrTbl = App_Code.User.GetUser(txtEmail.Text);
            if (usrTbl.Rows.Count >= 1)
            {
                //do nothing, should refresh fields indicating email is taken
            }
            else
            {
                App_Code.User usr = new App_Code.User();
                string hsh = App_Code.User.CreatePasswordHash(usr.UserSalt, txtPassword.Text);
                usr.UserEmail = txtEmail.Text;
                usr.UserHashedPw = hsh;
                usr.UserIsAdmin = false;
                usr.UserIsBanned = false;
                usr.UserRank = 0;

                App_Code.User.InsertUser(usr);

                Response.Redirect("~/Home/Sign-In");
            }
           
        }
    }
}