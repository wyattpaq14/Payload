using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNet_Lab1.App_Code;

namespace DotNet_Lab1
{
    public partial class SaltAndHashGenerator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            string salt = "salt";
            string pwHash = "hash";

            salt = app_user.CreateSalt();
            pwHash = app_user.CreatePasswordHash(salt, txtPassword.Text);

            txtHash.Text = pwHash;
            txtSalt.Text = salt;



        }
    }
}