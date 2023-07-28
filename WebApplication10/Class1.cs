using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication10
{
    public class MyComponent
    {
        public DataSet getdata(String s)
        {
            SqlConnection con = new SqlConnection("initial catalog=construct;integrated security=true;server=VDILEWVPNTH512");
            SqlDataAdapter da = new SqlDataAdapter(s, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return(ds);
        }
    }
}