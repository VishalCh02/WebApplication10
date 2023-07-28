using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication10
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        
        
            string gender;
            protected void Page_Load(object sender, EventArgs e)
            {
                SqlConnection con = new SqlConnection("initial catalog=construct;integrated security=true;server=VDILEWVPNTH512");
            SqlDataAdapter da = new SqlDataAdapter("select * from student_new", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
            }
            void sql_con(string s)
            {
                SqlConnection con = new SqlConnection("initial catalog=construct;integrated security=true;server=VDILEWVPNTH512");
            con.Open();
                SqlCommand cmd = new SqlCommand(s, con);
                int i = cmd.ExecuteNonQuery();
                Response.Write(i + " Row(s) affected!");
            }
            protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
            {
                gender = "Male";
            }



            protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
            {
                gender = "Female";
            }



            protected void Button2_Click(object sender, EventArgs e)
            {
                TextBox1.Text = string.Empty;
                TextBox2.Text = string.Empty;
                TextBox3.Text = string.Empty;
                TextBox4.Text = string.Empty;
                RadioButton1.Checked = false;
                RadioButton2.Checked = false;
            }



            protected void Button1_Click(object sender, EventArgs e)
            {
                sql_con("insert into student_new values('" + TextBox1.Text + "','" + TextBox2.Text + "'," + TextBox3.Text + ",'" + gender + "','" + TextBox4.Text + "')");
            }
        }
    }

    