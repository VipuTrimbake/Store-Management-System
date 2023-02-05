using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace NewUIProject
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);
        SqlCommand cmd = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            SqlDataAdapter da = new SqlDataAdapter("Select Id,Fname,Lname,ProductName,Qty,Prize,ProductImg,Address,Email,Phone,Date from Records where Fname = '" + Session["MoreInfoName"].ToString() + "'", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            grdMoreInfo.DataSource = dt;
            grdMoreInfo.DataBind();
            conn.Close();

        }
    }
}