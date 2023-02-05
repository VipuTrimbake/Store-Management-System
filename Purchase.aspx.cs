using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace NewUIProject
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);
        SqlCommand cmd = null;

        int value;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Display();
            }

            Count();
            txtDate.Text = DateTime.Now.ToString("d");
        }
        public void Count()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=DESKTOP-QPTR928\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=true";

            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM Purchase";

            int temp = 0;
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                temp = Convert.ToInt32(rd[0]);
            }
            if (temp != 0)
            {
                value = temp;
            }
            temp = value + 1;
            txtBillNo.Text = temp.ToString();
            conn.Close();
        }
        public void Display()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=DESKTOP-QPTR928\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=true";

            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            SqlDataAdapter da = new SqlDataAdapter("select * from Purchase order by Bill desc", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            GrdPurchase.DataSource = dt;
            GrdPurchase.DataBind();
            conn.Close();
        }
        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            if (txtSupplier.Text != "" && txtLocation.Text != "" && txtProduct.Text != "" && txtQty.Text != "" && txtUnit.Text != "" && txtTotal.Text != "")
            {
                conn.Open();
                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = conn;
                cmd2.CommandText = "SELECT Product,Qty FROM Purchase";
                SqlDataReader rd = cmd2.ExecuteReader();
                bool value = false;
                int qty1 = 0;
                while (rd.Read())
                {
                    if (txtProduct.Text == rd["Product"].ToString())
                    {
                        value = true;
                        break;
                    }
                }
                conn.Close();

                conn.Open();
                SqlCommand cmd3 = new SqlCommand("Select Qty from Inventory where ProductName='" + txtProduct.Text + "'", conn);
                SqlDataReader rd1 = cmd3.ExecuteReader();
                while (rd1.Read())
                {
                    qty1 = Convert.ToInt32(rd1["Qty"]);
                }
                conn.Close();

                if (value == false)
                {

                    conn.Open();
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.Connection = conn;
                    cmd1.CommandText = "INSERT INTO Inventory(ProductName,Qty) VALUES(@pd,@qt)";
                    cmd1.Parameters.AddWithValue("pd", txtProduct.Text);
                    cmd1.Parameters.AddWithValue("qt", txtQty.Text);
                    cmd1.ExecuteNonQuery();
                    conn.Close();
                }

                else
                {
                    int sum = 0;
                    sum = qty1 + Convert.ToInt32(txtQty.Text);
                    conn.Open();
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.Connection = conn;
                    cmd1.CommandText = "Update Inventory set Qty=" + sum + " where ProductName = '" + txtProduct.Text + "'";
                    cmd1.ExecuteNonQuery();
                    conn.Close();
                }

                int qty2 = 0;
                bool vl = false;
                conn.Open();
                SqlCommand cmd10 = new SqlCommand("Select Productname,Qty from Products Where Productname='" + txtProduct.Text + "'", conn);
                SqlDataReader rd5 = cmd10.ExecuteReader();
                while (rd5.Read())
                {
                    if (rd5["Productname"] != null || rd5["Productname"] != "")
                    {
                        vl = true;
                        qty2 = Convert.ToInt32(rd5["Qty"]);

                    }
                }
                conn.Close();

                if(vl == true)
                {
                    int sum1 = 0;
                    sum1 = qty2 + Convert.ToInt32(txtQty.Text);
                    conn.Open();
                    SqlCommand cmd5 = new SqlCommand();
                    cmd5.Connection = conn;
                    cmd5.CommandText = "Update Products set Qty=" + sum1 + " where Productname = '" + txtProduct.Text + "'";
                    cmd5.ExecuteNonQuery();
                    conn.Close();
                }


                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO Purchase(Product,Qty,Unit,Total,Supplier,Location,Date) VALUES(@pd,@qt,@un,@tt,@sp,@lc,@dt)";
                cmd.Parameters.AddWithValue("pd", txtProduct.Text);
                cmd.Parameters.AddWithValue("qt", txtQty.Text);
                cmd.Parameters.AddWithValue("un", txtUnit.Text);
                cmd.Parameters.AddWithValue("tt", txtTotal.Text);
                cmd.Parameters.AddWithValue("sp", txtSupplier.Text);
                cmd.Parameters.AddWithValue("lc", txtLocation.Text);
                cmd.Parameters.AddWithValue("dt", txtDate.Text);
                int t = cmd.ExecuteNonQuery();
                if (t > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "AddItem()", true);
                }
                conn.Close();
                Count();
                Display();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "FieldsRequired()", true);
            }
            Display();
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int sid = 0;

            for (int i = 0; i < GrdPurchase.Rows.Count; i++)
            {
                CheckBox chkselect = (CheckBox)GrdPurchase.Rows[i].FindControl("chkselect");
                if (chkselect.Checked == true)
                {
                    sid = Convert.ToInt32(GrdPurchase.Rows[i].Cells[1].Text);
                    string product1 = GrdPurchase.Rows[i].Cells[2].Text;
                    int qty = Convert.ToInt32(GrdPurchase.Rows[i].Cells[3].Text);


                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Delete from Purchase where Bill = '" + sid + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    bool val = false;
                    int qty3 = 0;

                    conn.Open();
                    SqlCommand cmd10 = new SqlCommand("Select ProductName,Qty from Inventory Where ProductName = '" + product1 + "'", conn);
                    SqlDataReader rd5 = cmd10.ExecuteReader();
                    while (rd5.Read())
                    {
                        if (rd5["ProductName"] != null || rd5["ProductName"].ToString() != "")
                        {
                            val = true;
                        }
                        qty3 = Convert.ToInt32(rd5["Qty"]);
                    }
                    conn.Close();

                    

                    if (val == false)
                    {
                        conn.Open();
                        SqlCommand cmd1 = new SqlCommand();
                        cmd1.Connection = conn;
                        cmd1.CommandText = "DELETE FROM Inventory WHERE ProductName = '" + product1 + "'";
                        cmd1.ExecuteNonQuery();
                        conn.Close();
                    }
                    else if (val == true)
                    {
                        qty3 = qty3 - qty;
                        conn.Open();
                        SqlCommand cmd5 = new SqlCommand();
                        cmd5.Connection = conn;
                        cmd5.CommandText = "Update Inventory set Qty=" + qty3 + " where ProductName = '" + product1 + "'";
                        cmd5.ExecuteNonQuery();
                        conn.Close();
                    }

                    if(qty3 == 0)
                    {
                        conn.Open();
                        SqlCommand cmd1 = new SqlCommand();
                        cmd1.Connection = conn;
                        cmd1.CommandText = "DELETE FROM Inventory WHERE ProductName = '" + product1 + "'";
                        cmd1.ExecuteNonQuery();
                        conn.Close();
                    }


                }
            }
            Display();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtSupplier.Text = null;
            txtLocation.Text = null;
            txtProduct.Text = null;
            txtQty.Text = null;
            txtUnit.Text = null;
            txtTotal.Text = null;
            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "ResetFields()", true);
        }

        protected void txtUnit_TextChanged(object sender, EventArgs e)
        {
            long temp = 0;
            temp = Convert.ToInt32(txtQty.Text) * Convert.ToInt32(txtUnit.Text);
            txtTotal.Text = temp.ToString();
        }

        //protected void txtQty_TextChanged(object sender, EventArgs e)
        //{
        //    long temp = 0;
        //    temp = Convert.ToInt32(txtQty.Text) * Convert.ToInt32(txtUnit.Text);
        //    txtTotal.Text = temp.ToString();
        //}

        protected void GrdPurchase_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GrdPurchase.EditIndex = e.NewEditIndex;
            Display();
        }

        protected void GrdPurchase_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int i = e.RowIndex;
            int sid = Convert.ToInt32(GrdPurchase.Rows[i].Cells[1].Text);
            string product = GrdPurchase.Rows[i].Cells[2].Text;
            TextBox qty = (TextBox)GrdPurchase.Rows[i].Cells[3].Controls[0];
            TextBox unit = (TextBox)GrdPurchase.Rows[i].Cells[4].Controls[0];
            TextBox total = (TextBox)GrdPurchase.Rows[i].Cells[5].Controls[0];
            TextBox supplier = (TextBox)GrdPurchase.Rows[i].Cells[6].Controls[0];
            TextBox location = (TextBox)GrdPurchase.Rows[i].Cells[7].Controls[0];


            conn.Open();
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = conn;
            cmd1.CommandText = "Update Inventory set Qty = "+qty.Text+" Where ProductName= '"+product.ToString()+"'";
            cmd1.ExecuteNonQuery();
            conn.Close();

            conn.Open();
            cmd = new SqlCommand("Update Purchase set Qty = @qty, Unit = @unit, Total = @total, Supplier = @supplier, Location = @location where Bill = @id", conn);
            //cmd.Parameters.AddWithValue("@product", product.Text);
            cmd.Parameters.AddWithValue("@qty", qty.Text);
            cmd.Parameters.AddWithValue("@unit", unit.Text);
            cmd.Parameters.AddWithValue("@total", total.Text);
            cmd.Parameters.AddWithValue("@supplier", supplier.Text);
            cmd.Parameters.AddWithValue("@location  ", location.Text);
            cmd.Parameters.AddWithValue("@id", sid);
            int t = cmd.ExecuteNonQuery();
            if (t > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "ItemUpdate()", true);
            }
            conn.Close();

            GrdPurchase.EditIndex = -1;
            Display();
        }

        protected void GrdPurchase_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int i = e.RowIndex;
            int bid = Convert.ToInt32(GrdPurchase.Rows[i].Cells[1].Text);
            string product1 = GrdPurchase.Rows[i].Cells[2].Text;
            int qty = Convert.ToInt32(GrdPurchase.Rows[i].Cells[3].Text);

            bool val = false;
            int qty3 = 0;

            conn.Open();
            SqlCommand cmd10 = new SqlCommand("Select ProductName,Qty from Inventory Where ProductName = '" + product1 + "'", conn);
            SqlDataReader rd5 = cmd10.ExecuteReader();
            while (rd5.Read())
            {
                if (rd5["ProductName"] != null || rd5["ProductName"].ToString() != "" )
                {
                    val = true;
                }
                qty3 = Convert.ToInt32(rd5["Qty"]);
            }
            conn.Close();

            if (val == false)
            {
                conn.Open();
                SqlCommand cmd1 = new SqlCommand();
                cmd1.Connection = conn;
                cmd1.CommandText = "DELETE FROM Inventory WHERE ProductName = '" + product1 + "'";
                cmd1.ExecuteNonQuery();
                conn.Close();
            }
            else if (val == true)
            {
                qty3 = qty3 - qty;
                conn.Open();
                SqlCommand cmd5 = new SqlCommand();
                cmd5.Connection = conn;
                cmd5.CommandText = "Update Inventory set Qty=" + qty3 + " where ProductName = '" + product1 + "'";
                cmd5.ExecuteNonQuery();
                conn.Close();
            }


            if (qty3 == 0)
            {
                conn.Open();
                SqlCommand cmd1 = new SqlCommand();
                cmd1.Connection = conn;
                cmd1.CommandText = "DELETE FROM Inventory WHERE ProductName = '" + product1 + "'";
                cmd1.ExecuteNonQuery();
                conn.Close();
            }

            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM Purchase WHERE Bill = @id";
            cmd.Parameters.AddWithValue("@id", bid);
            int t = cmd.ExecuteNonQuery();
            if (t > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "ItemDelete()", true);
            }
            conn.Close();
            GrdPurchase.EditIndex = -1;
            Display();
        }

        protected void GrdPurchase_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GrdPurchase.EditIndex = -1;
            Display();
        }
    }
}