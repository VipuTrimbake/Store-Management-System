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
    public partial class WebForm7 : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);
        SqlCommand cmd = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] s1 = new string[20];
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Select Fname from Records group by Fname";
            SqlDataReader rd = cmd.ExecuteReader();

            int i = 0;
            while (rd.Read())
            {
                s1[i] = rd["Fname"].ToString();
                i++;
            }
            conn.Close();

            int[] id = new int[20];
            int j = 0;
            foreach (string s in s1)
            {
                conn.Open();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Select Id from Records where Fname ='" + s + "'";
                rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    id[j] = Convert.ToInt32(rd["Id"]);
                    j++;
                    break;
                }
                conn.Close();
            }

            foreach (int s in id)
            {
                if (s != 0)
                {
                    conn.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "Insert into Rtemp(t_id) Values(" + s + ")";
                    cmd.ExecuteNonQuery();

                    cmd.Dispose();
                    conn.Close();
                }
            }

            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            SqlDataAdapter da = new SqlDataAdapter("Select Records.Id,Fname,Lname,ProductName,Prize,Qty,ProductImg,Address,Email,Phone,Date from Records,Rtemp where Records.Id=Rtemp.t_id order by Records.Id desc", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            grdRecords.DataSource = dt;
            grdRecords.DataBind();
            conn.Close();

            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Delete from Rtemp";
            cmd.ExecuteNonQuery();

            cmd.Dispose();
            conn.Close();

        }
        protected void grdRecords_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int i = e.RowIndex;
            string name = grdRecords.Rows[i].Cells[1].Text;
            Session["MoreInfoName"] = name;
            Response.Redirect("More info.aspx");

        }
    }
}