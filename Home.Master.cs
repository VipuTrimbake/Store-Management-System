using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewUIProject
{
    public partial class Home : System.Web.UI.MasterPage
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["HeaderText"] != null)
            //{
            //    lblHeaderText.Text = FirstCharToUpper(Session["Headertext"].ToString());
            //}
            //else
            //{
            //    Session["Headertext"] = "Vipul";
            //    lblHeaderText.Text = FirstCharToUpper(Session["Headertext"].ToString());
            //}
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
        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            Session["HeaderText"] = null;
            Response.Redirect("LoginPage.aspx");
        }
        protected void lnkDashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dashboard.aspx");
        }
        protected void lnkPurchase_Click(object sender, EventArgs e)
        {
            Response.Redirect("Purchase.aspx");
        }
        protected void lnkSales_Click(object sender, EventArgs e)
        {
            Response.Redirect("Sales.aspx");
        }

        protected void lnkProducts_Click(object sender, EventArgs e)
        {
            Response.Redirect("Products.aspx");
        }

        protected void lnkOrders_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerOrders.aspx");
        }

        protected void lnkRecords_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerRecords.aspx");
        }

        protected void lnkInventory_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inventory.aspx");
        }
        
    }
}