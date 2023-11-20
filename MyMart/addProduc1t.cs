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
    public partial class addProduc1t : Form
    {
        databaseConnection myDB = new databaseConnection();
        public addProduc1t()
        {
            InitializeComponent();
        }

        private void addProduc1t_Load(object sender, EventArgs e)
        {

        }

        private void bindingGridView()
        {
            try
            {
                myDB.OpenCon();
                SqlCommand cmd = new SqlCommand("SELECT catId,categoryName From category", myDB.getCon());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // dataGridView1.DataSourc
                category.DataSource = dt;
                category.DisplayMember = "CategoryName";
                category.ValueMember = "CatID";



                myDB.CloseCon();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
          
            textBox1ID.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            category.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textQantity.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBoxPrice.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            
        }
        //insert 
        private void add_Click(object sender, EventArgs e)
        {

        }
      //  update
        private void update_Click(object sender, EventArgs e)
        {

        }
        //Del
        private void clear_Click(object sender, EventArgs e)
        {

        }
    }
}
