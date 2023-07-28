using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebApplication10
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MyComponent con = new MyComponent();
            
            DataSet ds = con.getdata("select * from emp where " + DropDownList1.Text + "='" + TextBox1.Text + "'");
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            Response.Write("Hello");
        }
    }
}