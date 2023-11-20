using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;

using System.Data.SqlClient;
using System.Windows.Forms;

namespace MyMart
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=REVISION-PC;Initial Catalog=Mart_Database;Integrated Security=True");
        CrystalReport1 rpt = new CrystalReport1();
        private void button1_Click(object sender, EventArgs e)
        {
            Get();
        }
        private void Get()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM  Product",con);
          
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cmd.ExecuteNonQuery();

            rpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();
            con.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
