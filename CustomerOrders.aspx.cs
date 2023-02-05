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
    public partial class WebForm6 : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            Display();
        }
        public void Display()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=DESKTOP-QPTR928\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=true";
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            SqlDataAdapter da = new SqlDataAdapter("Select * from Orders,Customer where Customer.Id = Orders.C_id", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            GrdOrders.DataSource = dt;
            GrdOrders.DataBind();
            conn.Close();
        }
        protected void GrdOrders_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int i = e.RowIndex;
            int bid = Convert.ToInt32(GrdOrders.Rows[i].Cells[0].Text);
            string fname = GrdOrders.Rows[i].Cells[1].Text;
            string lname = GrdOrders.Rows[i].Cells[2].Text;
            string productname = GrdOrders.Rows[i].Cells[3].Text;
            string prize = GrdOrders.Rows[i].Cells[4].Text;
            string qty = GrdOrders.Rows[i].Cells[5].Text;
            Image productimg = (Image)GrdOrders.Rows[i].Cells[6].Controls[0];
            string address = GrdOrders.Rows[i].Cells[7].Text;
            string email = GrdOrders.Rows[i].Cells[8].Text;
            string phone = GrdOrders.Rows[i].Cells[9].Text;
            string date = GrdOrders.Rows[i].Cells[10].Text;
            long cid = Convert.ToInt32(Session["Number"]);
            long tp = Convert.ToInt32(prize) * Convert.ToInt32(qty);

            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Insert into Records(Fname,Lname,ProductName,Prize,Qty,ProductImg,Address,Email,Phone,Date,C_id) Values(@fn,@ln,@pn,@pz,@qty,@pimg,@ad,@eml,@ph,@dt,@cid)";
            cmd.Parameters.AddWithValue("fn", fname);
            cmd.Parameters.AddWithValue("ln", lname);
            cmd.Parameters.AddWithValue("pn", productname);
            cmd.Parameters.AddWithValue("pz", tp);
            cmd.Parameters.AddWithValue("qty", qty);
            cmd.Parameters.AddWithValue("pimg", productimg.ImageUrl);
            cmd.Parameters.AddWithValue("ad", address);
            cmd.Parameters.AddWithValue("eml", email);
            cmd.Parameters.AddWithValue("ph", phone);
            cmd.Parameters.AddWithValue("dt", date);
            cmd.Parameters.AddWithValue("cid", cid);
            cmd.ExecuteNonQuery();
            conn.Close();

            int qty1 = 0;
            long pz = 0, tpz = 0;

            conn.Open();
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = conn;
            cmd2.CommandText = "SELECT Product,Qty,Unit,Total FROM Sales";
            SqlDataReader rd1 = cmd2.ExecuteReader();
            int value = 0;
            double totalprize = 0;
            while (rd1.Read())
            {
                if (rd1["Product"].ToString().CompareTo(productname) == 0)
                {
                    qty1 = Convert.ToInt32(rd1["Qty"]) + Convert.ToInt32(qty);
                    totalprize = qty1 * Convert.ToInt32(prize);
                    //tpz = Convert.ToInt32(rd1["Total"]) + Convert.ToInt32(totalprize);

                    value = 1;
                    break;
                }
            }
            conn.Close();

            if (value == 1)
            {
                conn.Open();
                SqlCommand cmd4 = new SqlCommand("Update Sales set Qty = @qty, Total = @total, Date = @dt Where Product = @product", conn);

                cmd4.Parameters.AddWithValue("@product", productname);
                cmd4.Parameters.AddWithValue("@qty", qty1);
                cmd4.Parameters.AddWithValue("@total", totalprize);
                cmd4.Parameters.AddWithValue("@dt", date);
                cmd4.ExecuteNonQuery();
                conn.Close();
            }
            else if (value == 0)
            {
                totalprize = Convert.ToInt32(qty) * Convert.ToInt32(prize);
                conn.Open();
                SqlCommand cmd3 = new SqlCommand("Insert into Sales(Product,Qty,Unit,Total,Date) Values(@pd,@qt,@un,@tt,@dt)", conn);
                cmd3.Parameters.AddWithValue("@pd", productname);
                cmd3.Parameters.AddWithValue("@qt", qty);
                cmd3.Parameters.AddWithValue("@un", prize);
                cmd3.Parameters.AddWithValue("@tt", totalprize);
                cmd3.Parameters.AddWithValue("@dt", date);
                cmd3.ExecuteNonQuery();
                conn.Close();
            }

            conn.Open();
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = conn;
            cmd1.CommandText = "DELETE FROM Orders WHERE Id = @id";
            cmd1.Parameters.AddWithValue("@id", bid);
            int u = cmd1.ExecuteNonQuery();
            if (u > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "OrderDone()", true);
            }
            conn.Close();
            Display();
        }
    }
}