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
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MyComponent con = new MyComponent();

            DataSet ds = con.getdata("insert into Summer_Camp values('"+TextBox1.Text+"','"+TextBox2.Text+"','"+TextBox3.Text+"')");
            
            Label4.Text = "Thank You for the Response.";

        }
    }
}