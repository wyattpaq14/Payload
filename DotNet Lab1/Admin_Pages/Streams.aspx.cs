﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNet_Lab1.Admin_Pages
{
    public partial class Streams : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnNewStream_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Stream/" + null);
        }
    }
}