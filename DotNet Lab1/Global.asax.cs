using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;
using System.Web.Optimization;

namespace DotNet_Lab1
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
        }
        public static void RegisterRoutes(RouteCollection routes)
        {
            //Ignore WebResource.axd file

            routes.Ignore("{resource}.axd/{*pathInfo}");

            //non-admin routes
            routes.MapPageRoute("Home", "Home", "~/Default.aspx");
            routes.MapPageRoute("Sign-In", "Home/Sign-In", "~/Pages/Login.aspx");
            routes.MapPageRoute("Admin-Panel", "Admin", "~/Admin_Pages/Admin.aspx");
            routes.MapPageRoute("Register", "Home/Register", "~/Pages/Register.aspx");





            //admin routes
            routes.MapPageRoute("Player-Infos", "Admin/Player-Infos", "~/Admin_Pages/PlayerInfos.aspx");
            routes.MapPageRoute("Streams", "Admin/Streams", "~/Admin_Pages/Streams.aspx");
            routes.MapPageRoute("Users", "Admin/Users", "~/Admin_Pages/Users.aspx");



            //Player-Info page
            routes.MapPageRoute("Player-Info", "Admin/Player-Info/{BattleID}", "~/Admin_Pages/PlayerInfo.aspx", false, new RouteValueDictionary { { "BattleTag", "0" } });

            //User Page
            routes.MapPageRoute("User", "Admin/User/{UserID}", "~/Admin_Pages/User.aspx", false, new RouteValueDictionary { { "UserID", "0" } });
            //Section Page
            routes.MapPageRoute("Stream", "Admin/Stream/{StreamID}", "~/Admin_Pages/Stream.aspx", false, new RouteValueDictionary { { "StreamID", "0" } });

            
        }
    }
}