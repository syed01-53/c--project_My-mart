using System;
using System.Collections.Generic;

using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace MyMart
{
    class databaseConnection
    {
        SqlConnection con = new SqlConnection(@"Data Source=REVISION-PC;Initial Catalog=Mart_Database;Integrated Security=True");

        public SqlConnection getCon()
        {
            return con;

        }
        //for connection open 
        public void OpenCon()
        {
            if ( con.State== ConnectionState.Closed)
            {
                con.Open();
            }

        }
        //for the connection close 
        public void CloseCon()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

        }
    }
}
