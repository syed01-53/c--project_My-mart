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
    public partial class Form1 : Form
    { //   class name  which impoort 
        databaseConnection myDB = new databaseConnection();
      public  static string loginName, loginType;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }
        //making clear function 
        public void clearTextBox()
        {
            comboBox1.SelectedIndex = 0;
            userNameText.Clear();
            passwordText.Clear();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //login code 


        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > 0)
            {
                if (userNameText.Text != string.Empty)
                {
                    userNameText.Focus();

                    if (passwordText.Text != string.Empty)
                    {
                        passwordText.Focus();

                        // If condition for checking all conditions of logging

                        if (comboBox1.SelectedIndex > 0 && userNameText.Text != string.Empty && passwordText.Text != string.Empty)
                        {
                            // Login code
                            if (comboBox1.Text == "Admin")
                            {
                                myDB.OpenCon();
                                SqlCommand cmd = new SqlCommand("select  1 AdminID,Password,userName from AdminTable where userName=@userName and Password=@Password", myDB.getCon());
                                cmd.Parameters.AddWithValue("@userName", userNameText.Text);
                                cmd.Parameters.AddWithValue("@Password", passwordText.Text);
                               
                               
                               //      cmd.CommandType = CommandType.Text;
                                SqlDataAdapter da = new SqlDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                if (dt.Rows.Count > 0)
                                {
                                    MessageBox.Show("You are logged in.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //login name and type of admin take 
                                    loginName = userNameText.Text;
                                    loginType = comboBox1.Text;
                                    clearTextBox();
                                    this.Hide();
                                    MainForm fm = new MainForm();
                                    fm.Show();
                                }
                                else
                                {
                                    MessageBox.Show("Login failed. Please check your credentials.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else if (comboBox1.Text == "Sallar")
                            {
                                // Handle Seller login

                                myDB.OpenCon();
                                SqlCommand cmd = new SqlCommand("select top 1 sellerName,sellerPass from sellerTB where sellerName=@sellerName and sellerPass=@sellerPass", myDB.getCon());
                                cmd.Parameters.AddWithValue("@sellerName ", userNameText.Text);
                                cmd.Parameters.AddWithValue("@sellerPass", passwordText.Text);


                                //      cmd.CommandType = CommandType.Text;
                                SqlDataAdapter da = new SqlDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                if (dt.Rows.Count > 0)
                                {
                                    MessageBox.Show("You are logged in.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //login name and type of seller take 
                                    loginName = userNameText.Text;
                                    loginType = comboBox1.Text;
                                    clearTextBox();
                                    this.Hide();
                                    MainForm fm = new MainForm();
                                    fm.Show();
                                }
                                else
                                {
                                    MessageBox.Show("Login failed. Please check your credentials.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }

                            MessageBox.Show("Welcome");
                            clearTextBox();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter a password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select Seller or Admin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
     

    }
}
