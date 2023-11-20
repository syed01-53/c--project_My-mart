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
    public partial class Form2 : Form
    {
        databaseConnection myDB = new databaseConnection();
        public int Id;
        public Form2()
        {
            InitializeComponent();

        }

        private void Form2_Load(object sender, EventArgs e)
        {    
            //atumatical load 
            bindingGridView();
            
    }
        private void MyMart_Click(object sender, EventArgs e)
        {

        }
        //clera function ;
        private void clearTextBox()
        {
            textBox1ID.Clear();
            textBoxCato.Clear();
            richTexCato.Clear();
           
        }

        private void add_Click(object sender, EventArgs e)
        {
            if (textBoxCato.Text == string.Empty)
            {

                MessageBox.Show("Please enter a category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxCato.Focus();
                return ;
            }
           else if (richTexCato.Text == string.Empty)
            {
                MessageBox.Show("Please enter a category Description.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                richTexCato.Focus();
                return;
            }
            else
            {
                //Select
                SqlCommand cmd = new SqlCommand("select CategoryName from category where categoryName=@CategoryName", myDB.getCon());
                cmd.Parameters.AddWithValue("@categoryName", textBoxCato.Text);
                myDB.OpenCon();
                var result = cmd.ExecuteScalar();

                if (result != null)
                {

                    MessageBox.Show(string.Format("categoryName(0) already exist"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bindingGridView();
                }
              

                else
                {
                    //insert code 



                    //   cmd = new SqlCommand("INSERT INTO category(categoryName,categoryDesc) WHERE (@categoryName,@categoryDesc) ", myDB.getCon());
                    try
                    {
                        cmd = new SqlCommand("INSERT INTO category(catId,categoryName,categoryDesc) VALUES (@catId,@categoryName,@categoryDesc)", myDB.getCon());
                        cmd.Parameters.AddWithValue("@catId", textBox1ID.Text);
                        cmd.Parameters.AddWithValue("@categoryName", textBoxCato.Text);
                        cmd.Parameters.AddWithValue("@categoryDesc", richTexCato.Text);

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

        private void bindingGridView()
        {
            try
            {
                myDB.OpenCon();
                SqlCommand cmd = new SqlCommand("SELECT catId,categoryName,categoryDesc From category", myDB.getCon());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                myDB.CloseCon();
               


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            Id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            textBox1ID.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBoxCato.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            richTexCato.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void update_Click(object sender, EventArgs e)
        {
            try
            {
                if(1 > 0)
                {
                    SqlCommand cmd = new SqlCommand(" UPDATE  category SET catId=@catId,categoryName=@categoryName,categoryDesc=@categoryDesc WHERE  catId=@catId", myDB.getCon());

                    cmd.Parameters.AddWithValue("@catId",this.Id);
                    cmd.Parameters.AddWithValue("@categoryName", textBoxCato.Text);
                    cmd.Parameters.AddWithValue("@categoryDesc", richTexCato.Text);
                    myDB.OpenCon();
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("update sucessfully", "save", MessageBoxButtons.OK);
                    //calling clera function 
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


                //  SqlCommand cmd = new SqlCommand(" DELETE FROM category   WHERE carId =@carId ", myDB.getCon());
                //  cmd.CommandType = CommandType.Text;
                SqlCommand cmd = new SqlCommand("DELETE FROM category   WHERE catId =@carId ", myDB.getCon());
                cmd.Parameters.AddWithValue("@carId", this.Id );
                myDB.OpenCon();
                cmd.ExecuteNonQuery();
                myDB.CloseCon();
                MessageBox.Show("deleted sucessfully", "save", MessageBoxButtons.OK);
                //calling clear function 
                clearTextBox();
                //call grid view 
                bindingGridView();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
     //   ColumnClickEventArgs event for grid view
 
    }

}
