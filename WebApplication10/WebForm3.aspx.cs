using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication10
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                fillgrid(0);
        }
        private void fillgrid(int pno)
        {
            SqlConnection con = new SqlConnection("initial catalog = construct; integrated security=true;server=VDILEWVPNTH512");
            SqlDataAdapter da = new SqlDataAdapter("select * from emp", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds.Tables[0];
            GridView1.PageIndex=pno;
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            fillgrid(e.NewPageIndex);

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new SqlConnection("initial catalog = construct;integrated security=true;server=VDILEWVPNTH512");
            Response.Write(e.RowIndex);
            String pid = GridView1.Rows[e.RowIndex].Cells[2].Text;
            
            cmd.CommandText = "delete from emp where empno=" + int.Parse(GridView1.Rows[e.RowIndex].Cells[1].Text);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            Label1.Text = "1 Row Deleted";
            Response.Write("Hello");

            
        }
    }
}