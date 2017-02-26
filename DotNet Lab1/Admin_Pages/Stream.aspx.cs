using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNet_Lab1.App_Code;

namespace DotNet_Lab1.Admin_Pages
{
    public partial class Section : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                int streamID = Convert.ToInt32(RouteData.Values["StreamID"]);
                TStream stream = new TStream(streamID);

                txtStreamID.Text = stream.StreamID.ToString();
                txtStreamName.Text = stream.StreamName;
                txtStreamRank.Text = stream.StreamRank.ToString();
                txtStreamIsBanned.Text = stream.StreamIsBanned.ToString();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //here we will update the selected player-info

            //to-do: incorporate api fetch here

            //create new obj to forward to player-info class

            TStream s_stream = new TStream();

            s_stream.StreamID = Convert.ToInt32(txtStreamID.Text);
            s_stream.StreamName = txtStreamName.Text;
            s_stream.StreamRank = Convert.ToInt32(txtStreamRank.Text);
            s_stream.StreamIsBanned = Convert.ToBoolean(txtStreamIsBanned.Text);



            TStream.UpdateStreamInfo(s_stream);


        }
    }
}