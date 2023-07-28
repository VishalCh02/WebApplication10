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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                fillgrid();
        }
        private void fillgrid()
        {
            SqlConnection con = new SqlConnection("initial catalog=construct;integrated security=true;server=VDILEWVPNTH512");
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("Select * from emp_desig",con);
            da.Fill(ds);
            GridView1.DataSource = ds.Tables[0];
            int pno = GridView1.PageIndex ;
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int i = e.NewEditIndex;
            GridView1.EditIndex = i;
            
            this.fillgrid();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            SqlConnection con = new SqlConnection("initial catalog = construct;integrated security = true;server=VDILEWVPNTH512");
            SqlCommand cmd = new SqlCommand();

            String id = ((TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0]).Text.Trim();
            String Name = ((TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0]).Text.Trim();
            String Designation = ((TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0]).Text.Trim();
            String Gender = ((TextBox)GridView1.Rows[e.RowIndex].Cells[4].Controls[0]).Text.Trim();
            String Salary = ((TextBox)GridView1.Rows[e.RowIndex].Cells[5].Controls[0]).Text.Trim();
            String City = ((TextBox)GridView1.Rows[e.RowIndex].Cells[6].Controls[0]).Text.Trim();
            String state = ((TextBox)GridView1.Rows[e.RowIndex].Cells[7].Controls[0]).Text.Trim();
            String zip = ((TextBox)GridView1.Rows[e.RowIndex].Cells[8].Controls[0]).Text.Trim();
            String cm = "update emp_desig set name='" + Name + "',Designation='" + Designation + "',Gender='" + Gender + "',Salary=" + Salary + ",City='" + City + "',state='" + state + "',zip='" + zip+"'where id="+id;
            con.Open();
            cmd = new SqlCommand(cm, con);
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                Response.Write("SUCCESS");
                GridView1.EditIndex = -1;
                this.fillgrid();
            }
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            this.fillgrid();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            
            
            
        }
    }
}