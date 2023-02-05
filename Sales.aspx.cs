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
    public partial class WebForm3 : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);
        SqlCommand cmd = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Display();
            }
        }
        public void Display()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=DESKTOP-QPTR928\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=true";

            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            SqlDataAdapter da = new SqlDataAdapter("select * from Sales order by Bill desc", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            GrdSales.DataSource = dt;
            GrdSales.DataBind();
            conn.Close();
        }

        protected void GrdSales_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int i = e.RowIndex;
            int bid = Convert.ToInt32(GrdSales.Rows[i].Cells[1].Text);

            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM Sales WHERE Bill = @id";
            cmd.Parameters.AddWithValue("@id", bid);
            int t = cmd.ExecuteNonQuery();
            if (t > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "ItemDelete()", true);
            }
            cmd.Dispose();
            conn.Close();
            conn.Dispose();
            GrdSales.EditIndex = -1;
            Display();
        }

        protected void GrdSales_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int i = e.RowIndex;
            int sid = Convert.ToInt32(GrdSales.Rows[i].Cells[1].Text);
            TextBox product = (TextBox)GrdSales.Rows[i].Cells[2].Controls[0];
            TextBox qty = (TextBox)GrdSales.Rows[i].Cells[3].Controls[0];
            TextBox unit = (TextBox)GrdSales.Rows[i].Cells[4].Controls[0];
            TextBox total = (TextBox)GrdSales.Rows[i].Cells[5].Controls[0];


            conn.Open();
            cmd = new SqlCommand("update Sales set Product = @product, Qty = @qty, Unit = @unit, Total = @total where Bill = @id", conn);

            cmd.Parameters.AddWithValue("@product", product.Text);
            cmd.Parameters.AddWithValue("@qty", qty.Text);
            cmd.Parameters.AddWithValue("@unit", unit.Text);
            cmd.Parameters.AddWithValue("@total", total.Text);
            cmd.Parameters.AddWithValue("@id", sid);
            int t = cmd.ExecuteNonQuery();
            if (t > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "ItemUpdate()", true);
            }
            conn.Close();

            GrdSales.EditIndex = -1;
            Display();
        }

        protected void GrdSales_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GrdSales.EditIndex = -1;
            Display();
        }

        protected void GrdSales_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GrdSales.EditIndex = e.NewEditIndex;
            Display();
        }
    }
}