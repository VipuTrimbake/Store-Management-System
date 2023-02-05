using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace NewUIProject
{
    public partial class WebForm12 : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["HeaderText"] != null)
            {
                lblHeaderText.Text = FirstCharToUpper(Session["Headertext"].ToString());
            }
            else
            {
                Session["Headertext"] = "Vipul";
                lblHeaderText.Text = FirstCharToUpper(Session["Headertext"].ToString());
            }
            if (!IsPostBack)
            {
                Display();
            }
           
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
        public void Display()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            SqlDataAdapter da = new SqlDataAdapter("Select * from Records where Fname = '" + Session["HeaderText"].ToString() + "' and C_id = " + Convert.ToInt32(Session["Number"]), conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            GrdOrderCompleted.DataSource = dt;
            GrdOrderCompleted.DataBind();
            conn.Close();
        }
        protected void lnkProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx");
        }
    }
}