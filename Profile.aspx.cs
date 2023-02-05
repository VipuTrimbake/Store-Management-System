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
    public partial class WebForm8 : System.Web.UI.Page
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
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select * from Customer", conn);
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    if (rd["Id"].ToString() == Session["Number"].ToString())
                    {
                        lblId.Text = rd["Id"].ToString();
                        pFname.Text = rd["Fname"].ToString();
                        pLname.Text = rd["Lname"].ToString();
                        pEmail.Text = rd["Email"].ToString();
                        pPhone.Text = rd["Phone"].ToString();
                        pNewPwd.Text = rd["Password"].ToString();
                    }
                }
                conn.Close();
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
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Session["Number"].ToString());

            conn.Open();
            SqlCommand cmd = new SqlCommand("Update Customer set Fname = @fn, Lname = @ln, Email = @eml, Phone = @ph, Password = @pwd where Id = @id", conn);
            cmd.Parameters.AddWithValue("@fn", pFname.Text);
            cmd.Parameters.AddWithValue("@ln", pLname.Text);
            cmd.Parameters.AddWithValue("@eml", pEmail.Text);
            cmd.Parameters.AddWithValue("@ph", pPhone.Text);
            cmd.Parameters.AddWithValue("@pwd", pNewPwd.Text);
            cmd.Parameters.AddWithValue("@id", id);
            int t = cmd.ExecuteNonQuery();
            if (t > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "ItemUpdate()", true);
            }
            conn.Close();

        }

        protected void lnkProfile_Click(object sender, EventArgs e)
        {
        }

    }
}