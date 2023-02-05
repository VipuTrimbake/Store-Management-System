using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace NewUIProject
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                InsertingProduct();
                CancelProRepeat();

                Display();
            }

            txtDate.Text = DateTime.Now.ToString("d");
        }
        public void InsertingProduct()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT Product from Purchase Group by Product";
            SqlDataReader rd1 = cmd.ExecuteReader();
            ddlProducts.Items.Insert(0, "--Select--");
            while (rd1.Read())
            {

                ddlProducts.Items.Add(rd1["Product"].ToString());

            }
            conn.Close();
        }
        public void CancelProRepeat()
        {
            conn.Open();
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = conn;
            cmd1.CommandText = "SELECT Productname from Products";
            SqlDataReader rd2 = cmd1.ExecuteReader();
            while (rd2.Read())
            {

                ddlProducts.Items.Remove(rd2["Productname"].ToString());

            }
            conn.Close();
        }
        public void Display()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=DESKTOP-QPTR928\SQLEXPRESS;Initial Catalog=MyProject;Integrated Security=true";

            conn.Open();
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = conn;
            SqlDataAdapter da = new SqlDataAdapter("select * from Products order by Pid desc", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            GrdProducts.DataSource = dt;
            GrdProducts.DataBind();
            conn.Close();
        }
        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (ddlProducts.Text != "--Select--" && ddlQty.Text != "--Select--" && txtPrize.Text != "")
            {
                FileUpload.SaveAs(Server.MapPath("~/Upics/") + Path.GetFileName(FileUpload.FileName));
                string link = "~/Upics/" + Path.GetFileName(FileUpload.FileName);
                long mprize = Convert.ToInt32(txtPrize.Text) * 10 / 100;
                mprize = Convert.ToInt32(txtPrize.Text) + mprize;

                
               
                conn.Open();
                SqlCommand cmd4 = new SqlCommand();
                cmd4.Connection = conn;
                cmd4.CommandText = "Insert into Products(Category,Productname,Prize,Qty,mPrize,Date,ProductImg) values(@ct,@pn,@pz,@qt,@mpz,@dt,@pimg)";
                cmd4.Parameters.AddWithValue("@ct", ddlCategory.Text);
                cmd4.Parameters.AddWithValue("@pn", ddlProducts.Text);
                cmd4.Parameters.AddWithValue("@qt", ddlQty.Text);
                cmd4.Parameters.AddWithValue("@pz", txtPrize.Text);
                cmd4.Parameters.AddWithValue("@dt", txtDate.Text);
                cmd4.Parameters.AddWithValue("@mpz", mprize);
                cmd4.Parameters.AddWithValue("@pimg", link);
                int t = cmd4.ExecuteNonQuery();
                if (t > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "AddItem()", true);
                }
                conn.Close();
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT Pid from Products where Productname = '" + ddlProducts.Text + "'";
                SqlDataReader rd = cmd.ExecuteReader();
                int pid = 0;
                while (rd.Read())
                {
                    pid = Convert.ToInt32(rd["Pid"].ToString());
                }
                conn.Close();


                conn.Open();
                SqlCommand cmd3 = new SqlCommand();
                cmd3.Connection = conn;
                cmd3.CommandText = "Update Inventory set ProductImg = '" + link + "', P_id = " + pid + " Where ProductName = '" + ddlProducts.Text + "'";
                cmd3.ExecuteNonQuery();
                conn.Close();

                conn.Open();
                SqlCommand cmd5 = new SqlCommand();
                cmd5.Connection = conn;
                cmd5.CommandText = "Update Purchase set P_id = " + pid + " Where Product = '" + ddlProducts.Text + "'";
                cmd5.ExecuteNonQuery();
                conn.Close();

                CancelProRepeat();
                Display();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "FieldsRequired()", true);
            }
        }

        protected void GrdProducts_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int i = e.RowIndex;
            int bid = Convert.ToInt32(GrdProducts.Rows[i].Cells[1].Text);

            conn.Open();

            SqlCommand cmd5 = new SqlCommand();
            cmd5.Connection = conn;
            cmd5.CommandText = "DELETE FROM Products WHERE Pid = @id";
            cmd5.Parameters.AddWithValue("@id", bid);
            int t = cmd5.ExecuteNonQuery();
            if (t > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "ItemDelete()", true);
            }
            conn.Close();
            GrdProducts.EditIndex = -1;
            Display();
        }
        protected void GrdProducts_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GrdProducts.EditIndex = e.NewEditIndex;
            Display();
        }
        protected void GrdProducts_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int i = e.RowIndex;
            int sid = Convert.ToInt32(GrdProducts.Rows[i].Cells[1].Text);
            string product = GrdProducts.Rows[i].Cells[2].Text;
           // TextBox qty = (TextBox)GrdProducts.Rows[i].Cells[3].Controls[0];
            TextBox prize = (TextBox)GrdProducts.Rows[i].Cells[4].Controls[0];
            TextBox mprize = (TextBox)GrdProducts.Rows[i].Cells[5].Controls[0];
            TextBox category = (TextBox)GrdProducts.Rows[i].Cells[6].Controls[0];

            conn.Open();
            SqlCommand cmd7 = new SqlCommand("Update Inventory set Productname = '"+product+"' where P_id = "+sid, conn);
            cmd7.ExecuteNonQuery();
            conn.Close();

            conn.Open();
            SqlCommand cmd8 = new SqlCommand("Update Purchase set Product = '" + product + "' where P_id = " + sid, conn);
            cmd8.ExecuteNonQuery();
            conn.Close();



            conn.Open();
            SqlCommand cmd6 = new SqlCommand("Update Products set Category = @category, Prize = @prize, mPrize = @mprize where Pid = @id", conn);
           // cmd6.Parameters.AddWithValue("product", product);
            cmd6.Parameters.AddWithValue("category", category.Text);
            cmd6.Parameters.AddWithValue("prize", prize.Text);
            cmd6.Parameters.AddWithValue("mprize", mprize.Text);
            //cmd6.Parameters.AddWithValue("qty", qty.Text);
            cmd6.Parameters.AddWithValue("id", sid);
            int t = cmd6.ExecuteNonQuery();
            if (t > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "ItemUpdate()", true);
            }
            conn.Close();

            GrdProducts.EditIndex = -1;
            Display();
        }
        protected void GrdProducts_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GrdProducts.EditIndex = -1;
            Display();
        }

        protected void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            int sid = 0;
            for (int i = 0; i < GrdProducts.Rows.Count; i++)
            {
                CheckBox chkselect = (CheckBox)GrdProducts.Rows[i].FindControl("chkselect");
                if (chkselect.Checked == true)
                {
                    sid = Convert.ToInt32(GrdProducts.Rows[i].Cells[1].Text);
                    conn.Open();
                    SqlCommand cmd7 = new SqlCommand("Delete from Products where Pid = '" + sid + "'", conn);
                    cmd7.ExecuteNonQuery();
                    conn.Close();
                }
            }
            Display();
        }

        protected void ddlProducts_TextChanged(object sender, EventArgs e)
        {
            ddlQty.Items.Clear();
            conn.Open();
            SqlCommand cmd8 = new SqlCommand();
            cmd8.Connection = conn;
            cmd8.CommandText = "SELECT Qty from Inventory Where ProductName = '" + ddlProducts.Text + "'";
            SqlDataReader rd3 = cmd8.ExecuteReader();
            ddlQty.Items.Insert(0, "--Select--");
            while (rd3.Read())
            {
                ddlQty.Items.Add(rd3["Qty"].ToString());
            }
            conn.Close();

            conn.Open();
            SqlCommand cmd9 = new SqlCommand();
            cmd9.Connection = conn;
            cmd9.CommandText = "SELECT Unit from Purchase Where Product = '" + ddlProducts.Text + "'";
            SqlDataReader rd4 = cmd9.ExecuteReader();
            while (rd4.Read())
            {
                txtPrize.Text = Convert.ToInt32(rd4["Unit"]).ToString();
            }
            conn.Close();


        }
    }
}