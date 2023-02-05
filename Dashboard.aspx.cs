using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace NewUIProject
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);
        SqlCommand cmd = null;
        SqlDataReader rd = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT Count(Id) as Id FROM Customer";
            rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                lblCustomer.Text =  rd["Id"].ToString();
            }
            conn.Close();

            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT Count(Productname) as Pname FROM Products";
            rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                lblProducts.Text = rd["Pname"].ToString();
            }
            conn.Close();

            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT Count(Id) as Rid FROM Records";
            rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                lblOrders.Text = rd["Rid"].ToString();
            }
            conn.Close();

            double sum1 = 0;
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select distinct Purchase.Product,Purchase.Unit as prUnit,Sales.Total as slTotal,Sales.Qty as slQty from Purchase,Sales where Purchase.Product = Sales.Product;";
            SqlDataReader rd1 = cmd.ExecuteReader();

            while (rd1.Read())
            {
                sum1 = sum1 + (Convert.ToInt32(rd1["slTotal"])) - (Convert.ToInt32(rd1["prUnit"]) * Convert.ToInt32(rd1["slQty"]));
                
            } 

            conn.Close();

            string profit = "0";
            if (sum1 > 1000000)
            {
                sum1 /= 1000000;
                profit = sum1.ToString() + "M";
            }
            else if (sum1 > 1000)
            {
                sum1 = sum1 / 1000;
                profit = sum1.ToString() + "k";
            }
            lblIncome.Text = profit.ToString();

        }
    }
}