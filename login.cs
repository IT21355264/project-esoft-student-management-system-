using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace project_esoft
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
		//string cs = @"Data Source=DESKTOP-C3LMKPR;Initial Catalog=Student;Integrated Security=True";

		private void label4_Click(object sender, EventArgs e)
        {
			

		}

		private void button1_Click(object sender, EventArgs e)
        {
            string username = txt_username.Text;
            string password = txt_password.Text;

            if(username == "Admin" && password == "Skills@123")
            {
                MessageBox.Show("Log in success!");

                this.Hide();
                details ss = new details();
                ss.Show();
            }
            else
            {
                MessageBox.Show("Please provide vallide UserName and Password");
            }
		}	
        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure, Doyou really want to exit....?", "Exit",
                MessageBoxButtons.OK, MessageBoxIcon.Question);
            Application.Exit();
        }

        private void txt_username_TextChanged(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            txt_username.Clear();
            txt_password.Clear();
        }

        private void txt_password_TextChanged(object sender, EventArgs e)
        {

        }
		SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-C3LMKPR;Initial Catalog=Student;Integrated Security=True");
        private void login_Load(object sender, EventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
