using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewUIProject
{
    public partial class User : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        public static string FirstCharToUpper(string s)
        {
            // Check for empty string.  
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.  
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        protected void linkdashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("User_Dashboard.aspx");
        }
        protected void linkorder_Click(object sender, EventArgs e)
        {
            Response.Redirect("User_Orders.aspx");
        }
        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            Session["HeaderText"] = null;
            Response.Redirect("LoginPage.aspx");
        }

        protected void lnkProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx");
        }

        protected void lnkOrderCompleted_Click(object sender, EventArgs e)
        {
            Response.Redirect("User_OrderCompleted.aspx");
        }
    }
}