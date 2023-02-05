using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace NewUIProject
{
    public partial class New_User : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateUser_Click(object sender, EventArgs e)
        {

            if (txtFname.Text != "" && txtLname.Text != "" && txtAddress.Text != "" && txtEmail.Text != "" && txtPhone.Text != "" && txtPasswd.Text != "" && txtCPasswd.Text != "")
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT Email FROM Customer";
                SqlDataReader rd = cmd.ExecuteReader();

                bool value = false;
                while (rd.Read())
                {

                    if (rd["Email"].ToString().CompareTo(txtEmail.Text) == 0)
                    {
                        value = true;
                    }
                }
                conn.Close();
                if (value != true)
                {
                    conn.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO Customer(Fname,Lname,Address,Email,Phone,Password) VALUES(@fn,@ln,@ad,@eml,@ph,@ps)";
                    cmd.Parameters.AddWithValue("fn", txtFname.Text);
                    cmd.Parameters.AddWithValue("ln", txtLname.Text);
                    cmd.Parameters.AddWithValue("ad", txtAddress.Text);
                    cmd.Parameters.AddWithValue("eml", txtEmail.Text);
                    cmd.Parameters.AddWithValue("ph", txtPhone.Text);
                    cmd.Parameters.AddWithValue("ps", txtPasswd.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "UserCreate()", true);

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "EmailExists()", true);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "FieldsRequired()", true);
            }

        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }
    }
}