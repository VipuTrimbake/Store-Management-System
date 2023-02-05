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
    public partial class WebForm11 : System.Web.UI.Page
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
            long sessionid = Convert.ToInt32(Session["Number"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            SqlDataAdapter da = new SqlDataAdapter("Select * from Orders where  C_id = " + sessionid + " order by Id desc ", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dlOrders.DataSource = dt;
            dlOrders.DataBind();
            conn.Close();
        }
        protected void dlOrders_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                DataListItem record = e.Item;
                long pn = Convert.ToInt32(((Label)record.FindControl("Id")).Text);
                int qty = Convert.ToInt32(((Label)record.FindControl("Qty")).Text);
                string pname = ((Label)record.FindControl("Pname")).Text;

                conn.Open();
                SqlCommand cmd2= new SqlCommand();
                cmd2.Connection = conn;
                cmd2.CommandText = "SELECT Qty FROM Products where Productname = '"+pname+"'";
                SqlDataReader rd = cmd2.ExecuteReader();

                int pqty = 0;

                while (rd.Read())
                { 
                    pqty = Convert.ToInt32(rd["Qty"].ToString());
                }
                conn.Close();
                pqty = pqty + qty;

                conn.Open();
                SqlCommand cmd1 = new SqlCommand("Update Products set Qty = "+pqty+" where Productname = '"+pname+"'", conn);
                cmd1.ExecuteNonQuery();
                conn.Close();


                conn.Open();
                SqlCommand cmd3 = new SqlCommand("Update Inventory set Qty = " + pqty + " where ProductName = '" + pname + "'", conn);
                cmd3.ExecuteNonQuery();
                conn.Close();

                conn.Open();
                SqlCommand cmd = new SqlCommand("Delete from Orders where Id = @pn", conn);
                cmd.Parameters.AddWithValue("@pn", pn);
                cmd.CommandType = CommandType.Text;
                int t = cmd.ExecuteNonQuery();
                if (t > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "OrderCancel()", true);
                }
                conn.Close();
                Display();
            }
        }

        protected void lnkProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx");
        }
    }
}