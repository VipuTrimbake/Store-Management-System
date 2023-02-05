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
    public partial class WebForm10 : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

            QtyStatus();
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
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=DESKTOP-QPTR928\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=true";

            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            SqlDataAdapter da = new SqlDataAdapter("select * from Products where Qty != 0 ", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dlProducts.DataSource = dt;
            dlProducts.DataBind();
            conn.Close();
        }
        public void QtyStatus()
        {
            conn.Open();
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = conn;
            cmd1.CommandText = "SELECT ProductName,Qty FROM Inventory";
            SqlDataReader rd = cmd1.ExecuteReader();
            int[] q = new int[100];
            string[] pn = new string[100];
            string[] qt = new string[100];
            int i = 0;
            while (rd.Read())
            {
                q[i] = Convert.ToInt32(rd["Qty"]);
                pn[i] = rd["ProductName"].ToString();
                i++;
            }
            conn.Close();

            for (int k = 0; k < pn.Length; k++)
            {
                if (q[k] == 0)
                {
                    qt[k] = "Out Of Stock";
                }
                else if (q[k] <= 10)
                {
                    qt[k] = "Only " + q[k] + " left";
                }
                else if (q[k] > 10)
                {
                    qt[k] = "In Stock";
                }
            }

            conn.Open();
            for (int j = 0; j < pn.Length; j++)
            {
                SqlCommand cmd2 = new SqlCommand("Update Products set Qty =" + q[j] + ",QtyStatus ='" + qt[j] + "' Where Productname='" + pn[j] + "'", conn);
                cmd2.ExecuteNonQuery();
            }
            conn.Close();
        }
        protected void dlProducts_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Insert")
            {
                long sessionid = Convert.ToInt32(Session["Number"].ToString());
                DataListItem record = e.Item;
                string pn = ((Label)record.FindControl("Productname")).Text;
                string mpz = ((Label)record.FindControl("mPrize")).Text;
                string pz = ((Label)record.FindControl("Prize")).Text;
                string Date = DateTime.Now.ToString("d");
                string img = ((Image)record.FindControl("Image1")).ImageUrl;
                int qty = Convert.ToInt32(((DropDownList)record.FindControl("ddlQty")).Text);

                conn.Open();
                SqlCommand cmd1 = new SqlCommand();
                cmd1.Connection = conn;
                cmd1.CommandText = "Select Qty FROM Inventory Where ProductName = '" + pn + "'";
                SqlDataReader rd = cmd1.ExecuteReader();
                int qy = 0;
                while (rd.Read())
                {
                    qy = Convert.ToInt32(rd["Qty"]);
                }
                conn.Close();

                if (qy >= qty)
                {
                    int sumQty = 0;
                    sumQty = qy - qty;
                    conn.Open();
                    SqlCommand cmd2 = new SqlCommand("Update Inventory set Qty = " + sumQty + " Where ProductName = '" + pn + "'", conn);
                    cmd2.ExecuteNonQuery();
                    conn.Close();

                    conn.Open();
                    SqlCommand cmd3 = new SqlCommand("Insert into Orders(C_id,Productname,Prize,mPrize,Date,ProductImg,Qty) Values(@cid,@pn,@pz,@mpz,@dt,@pimg,@qty)", conn);
                    cmd3.Parameters.AddWithValue("@cid", sessionid);
                    cmd3.Parameters.AddWithValue("@pn", pn);
                    cmd3.Parameters.AddWithValue("@pz", pz);
                    cmd3.Parameters.AddWithValue("@mpz", mpz);
                    cmd3.Parameters.AddWithValue("@dt", Date);
                    cmd3.Parameters.AddWithValue("@pimg", img);
                    cmd3.Parameters.AddWithValue("@qty", qty);
                    cmd3.CommandType = CommandType.Text;
                    int t = cmd3.ExecuteNonQuery();
                    if (t > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "OrderPlaced()", true);
                    }
                    conn.Close();
                    QtyStatus();
                    Display();
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "ValidQty()", true);
                }


            }
        }

        protected void lnkProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx");
        }
    }
}