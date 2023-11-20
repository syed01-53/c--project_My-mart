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
    public partial class frmAddSeller : Form
    {
        databaseConnection myDB = new databaseConnection();
        public int Id;
        public frmAddSeller()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
             
        }

        private void frmAddSeller_Load(object sender, EventArgs e)
        {
            bindingGridView();
        }
        private void clearTextBox()
        {
            textSellerName.Clear();
            textFatherName.Clear();
            textFatherName.Clear();
            textPassword.Clear();
            textPhone.Clear();
        }

        private void add_Click(object sender, EventArgs e)
        {
            if (textSellerName.Text == string.Empty)
            {

                MessageBox.Show("Please enter a seller name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textSellerName.Focus();
                return;
            }
            else if (textFatherName.Text == string.Empty)
            {
                MessageBox.Show("Please enter a father name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textFatherName.Focus();
                return;
            }
            else if (textPassword.Text == string.Empty)
            {
                MessageBox.Show("Please enter a Password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textPassword.Focus();
                return;
            }
            else if (textPhone.Text == string.Empty)
            {
                MessageBox.Show("Please enter a phone.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textPhone.Focus();
                return;
            }
       
            else
            {
                //Select
                SqlCommand cmd = new SqlCommand("select sellerName from sellerTB where sellerName=@sellerName", myDB.getCon());
                cmd.Parameters.AddWithValue("@sellerName", textSellerName.Text);
                myDB.OpenCon();
                var result = cmd.ExecuteScalar();

                if (result != null)
                {

                    MessageBox.Show(string.Format("sellerName(0) already exist"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bindingGridView();
                }


                else
                {
                    //insert code 



                    //   cmd = new SqlCommand("INSERT INTO category(categoryName,categoryDesc) WHERE (@categoryName,@categoryDesc) ", myDB.getCon());
                    try
                    {
                        cmd = new SqlCommand("INSERT INTO sellerTB(sellerID,sellerName,fatherName,SellerPhone,sellerPass) VALUES (@sellerID,@sellerName,@fatherName,@SellerPhone,@sellerPass)", myDB.getCon());
                        cmd.Parameters.AddWithValue("@sellerID", textBox1ID.Text);
                        cmd.Parameters.AddWithValue("@sellerName", textSellerName.Text);
                        cmd.Parameters.AddWithValue("@fatherName", textFatherName.Text);
                       
                        cmd.Parameters.AddWithValue("@SellerPhone", textPhone.Text);
                        cmd.Parameters.AddWithValue("@sellerPass", textPassword.Text);
                        //claer  function calling her 
                        clearTextBox();
                        cmd.CommandType = CommandType.Text;
                        int i = cmd.ExecuteNonQuery();

                        if (i > 0)
                        {
                            MessageBox.Show("Category Inserted Successfully...", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bindingGridView();
                        }
                        myDB.CloseCon();
                    }
                    catch (Exception ex)

                    {
                        MessageBox.Show(ex.Message);
                    }

                }



            }

        }

        private void update_Click(object sender, EventArgs e)
        {
            try
            {
                if (1 > 0)
                {
                    SqlCommand cmd = new SqlCommand(" UPDATE sellerTB  SET sellerID=@sellerID,sellerName=@sellerName,fatherName=@fatherName,SellerPhone=@SellerPhone,sellerPass=@sellerPass WHERE  sellerID=@sellerID", myDB.getCon());

                    cmd.Parameters.AddWithValue("@sellerID", textBox1ID.Text);
                    cmd.Parameters.AddWithValue("@sellerName", textSellerName.Text);
                    cmd.Parameters.AddWithValue("@fatherName", textFatherName.Text);

                    cmd.Parameters.AddWithValue("@SellerPhone", textPhone.Text);
                    cmd.Parameters.AddWithValue("@sellerPass", textPassword.Text);
                    myDB.OpenCon();
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("update sucessfully", "save", MessageBoxButtons.OK);

                    //  call grid view 
                    bindingGridView();

                    myDB.CloseCon();
                    // calling clear function ;
                    clearTextBox();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void clear_Click(object sender, EventArgs e)
        {
            try
            {
                // SqlCommand cmd = new SqlCommand(" DELETE FROM category   WHERE '" + Convert.ToInt32(textBox1ID.Text )+ "' ", myDB.getCon());


                
                SqlCommand cmd = new SqlCommand("DELETE FROM sellerTB    WHERE sellerID = @sellerID ", myDB.getCon());
                cmd.Parameters.AddWithValue("@sellerID", textBox1ID.Text);
                myDB.OpenCon();
                cmd.ExecuteNonQuery();
                myDB.CloseCon();
                MessageBox.Show("deleted sucessfully", "save", MessageBoxButtons.OK);
                // calling clear function ;
                clearTextBox();
                //call grid view 
                bindingGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void bindingGridView()
        {
            try
            {
                myDB.OpenCon();
                SqlCommand cmd = new SqlCommand("SELECT sellerID,sellerName,fatherName,SellerPhone,sellerPass From sellerTB", myDB.getCon());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                myDB.CloseCon();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
        

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_Click_1(object sender, EventArgs e)
        {
            Id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            textBox1ID.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textSellerName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textFatherName.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textPassword.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textPhone.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }
    }
}
