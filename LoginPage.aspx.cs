using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace NewUIProject
{
    public partial class LoginPage : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Admin" && txtPassword.Text == "admin")
            {
                Session["HeaderText"] = "Admin";
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "AdminLogin()", true);
            }
            else
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT Email,Password,Fname,Id FROM Customer";
                SqlDataReader rd = cmd.ExecuteReader();

                bool value = false;
                while (rd.Read())
                {

                    if (rd["Email"].ToString().CompareTo(txtUsername.Text) == 0 && rd["Password"].ToString().CompareTo(txtPassword.Text) == 0)
                    {
                        // Session["OP"] = Convert.ToInt32(rd["OrderPlaced"]); ;
                        Session["HeaderText"] = rd["Fname"].ToString();
                        Session["Number"] = rd["Id"].ToString();
                        value = true;
                    }
                }
                cmd.Dispose();
                conn.Close();
                conn.Dispose();

                if (value == true)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "UserLogin()", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "InvalidMsg()", true);
                }
            }

        }

        protected void lnCreateUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("New User.aspx");
        }

    }
}