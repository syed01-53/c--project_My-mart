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
    public partial class FormAddAdmin : Form
    {
        databaseConnection myDB = new databaseConnection();
        public FormAddAdmin()
        {
            InitializeComponent();
        }

        //clera function ;
        private void clearTextBox()
        {
            textBox1ID.Clear();
            textAdminName.Clear();
            textPassword.Clear();
            textPhone.Clear();

        }
        private void FormAddAdmin_Load(object sender, EventArgs e)
        {
            bindingGridView();
        }

        private void add_Click(object sender, EventArgs e)
        {
            if (textAdminName.Text == string.Empty)
            {

                MessageBox.Show("Please enter a text Admin  name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textAdminName.Focus();
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
                SqlCommand cmd = new SqlCommand("select userName  from AdminTable where userName=@userName", myDB.getCon());
                cmd.Parameters.AddWithValue("@userName", textAdminName.Text);
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
                        cmd = new SqlCommand("INSERT INTO AdminTable(AdminID,userName,Password,phone) VALUES (@AdminID,@userName,@Password,@phone)", myDB.getCon());
                        cmd.Parameters.AddWithValue("@AdminID", textBox1ID.Text);
                        cmd.Parameters.AddWithValue("@userName", textAdminName.Text);

                        cmd.Parameters.AddWithValue("@Password", textPassword.Text);
                        cmd.Parameters.AddWithValue("@phone", textPhone.Text);

                        cmd.CommandType = CommandType.Text;
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            MessageBox.Show("Category Inserted Successfully...", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bindingGridView();
                            //clear function
                            clearTextBox();
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
                    SqlCommand cmd = new SqlCommand(" UPDATE AdminTable  SET AdminID=@AdminID,userName=@userName,Password=@Password, phone=@phone WHERE  AdminID=@AdminID", myDB.getCon());

                    cmd.Parameters.AddWithValue("@AdminID", textBox1ID.Text);
                    cmd.Parameters.AddWithValue("@userName", textAdminName.Text);

                    cmd.Parameters.AddWithValue("@Password", textPassword.Text);
                    cmd.Parameters.AddWithValue("@phone", textPhone.Text);
                    myDB.OpenCon();
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("update sucessfully", "save", MessageBoxButtons.OK);
                    //clear function
                    clearTextBox();

                    //  call grid view 
                    bindingGridView();

                    myDB.CloseCon();
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



                SqlCommand cmd = new SqlCommand("DELETE    from AdminTable WHERE AdminID=@AdminID ", myDB.getCon());
                cmd.Parameters.AddWithValue("@AdminID", textBox1ID.Text);
                myDB.OpenCon();
                cmd.ExecuteNonQuery();
                myDB.CloseCon();
                MessageBox.Show("deleted sucessfully", "save", MessageBoxButtons.OK);
                //clear function
                clearTextBox();

                //call grid view 
                bindingGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void bindingGridView()
        {
            try
            {
                myDB.OpenCon();
                SqlCommand cmd = new SqlCommand("SELECT AdminID,userName,Password,phone From AdminTable", myDB.getCon());
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
        private void dataGridView1_Click_1(object sender, EventArgs e)
        {
         
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            // Id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            textBox1ID.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textAdminName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textPassword.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textPhone.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
        }
    }
}
