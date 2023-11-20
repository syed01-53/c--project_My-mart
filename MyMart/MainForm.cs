using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;

using System.Windows.Forms;

namespace MyMart
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MyMart_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Form1.loginName != null)
            {
               toolStripStatusLabel1.Text = Form1.loginName; 
            }
            if (Form1.loginType != null && Form1.loginType == "Sallar")
            {
                categoryToolStripMenuItem.Enabled = false;
                productToolStripMenuItem.Enabled = false;
                addUserToolStripMenuItem.Enabled = false;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 fcat = new Form2();
            fcat.Show();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you want to close?" , "Close", MessageBoxButtons.YesNo,MessageBoxIcon.Stop);
            if(dialog == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                Application.Exit();
            }
        }

        private void sallarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddSeller  fseller = new frmAddSeller();
            fseller.ShowDialog();
        }

        private void admineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddAdmin fAdmin = new FormAddAdmin();
            fAdmin.Show();
        }

        private void addProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addProduc1t pro = new addProduc1t();
            pro.Show();

        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 repo = new Form3();
            repo.Show();
        }
    }
}
