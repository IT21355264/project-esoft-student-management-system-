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
    public partial class details : Form
    {
        public details()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-C3LMKPR;Initial Catalog=Student;Integrated Security=True");
        private int Age;

        private void button3_Click(object sender, EventArgs e)
        {
            c_1.ResetText();
            t_1.Clear();
            t_2.Clear();
            d_1.ResetText();
            r_1.Refresh();
            r_2.Refresh();
            t_3.Clear();
            t_4.Clear();
            t_5.Clear();
            t_6.Clear();
            t_7.Clear();
            t_7.Clear();
            t_8.Clear();
            t_9.Clear();
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string regNo = c_1.Text;
                string firstName = t_1.Text;
                string lastname = t_2.Text;
                DateTime dateOfBirth = DateTime.Parse(d_1.Text).Date;
                string gender;

                if ( r_1.Checked)
                {
                    gender = "Male";
                }
                else
                {
                    gender = "Female";
                }
                string address = t_3.Text;
                string email = t_4.Text;
                string mobilePhone = t_5.Text;
                string homePhone = t_6.Text;
                string parentName = t_7.Text;
                string nic = t_8.Text;
                string contactNo = t_9.Text;


                string query_insert = "INSERT INTO Registration VALUES  ('" + regNo + "','" + firstName + "','" + lastname + "'," +
                    "'" + dateOfBirth + "','" + gender + "','" + address + "','" + email + "','" + mobilePhone + "','" + homePhone + "'," +
                    "'"+ parentName + "','"+nic+"','"+ contactNo +"')";     
                SqlCommand cmnd = new SqlCommand(query_insert,con);
                con.Open();
				cmnd.ExecuteNonQuery();

                MessageBox.Show("Record Added Succecfully");

				this.Hide();
				course_details ss = new course_details();
				ss.Show();
			}
            catch (Exception ex)
            {
                MessageBox.Show("Error while saving" + ex);
            }
            finally { con.Close(); }
                

        }

        private void button2_Click(object sender, EventArgs e)
        {
			try
			{
				string regNo = c_1.Text;
				string firstName = t_1.Text;
				string lastname = t_2.Text;
				DateTime dateOfBirth = DateTime.Parse(d_1.Text).Date;
				string gender;

				if (r_1.Checked)
				{
					gender = "Male";
				}
				else
				{
					gender = "Female";
				}
				string address = t_3.Text;
				string email = t_4.Text;
				string mobilePhone = t_5.Text;
				string homePhone = t_6.Text;
				string parentName = t_7.Text;
				string nic = t_8.Text;
				string contactNo = t_9.Text;

				string updatesql = "UPDATE Registration SET firstName = '" + firstName + "',lastname = '" + lastname + "',dateOfBirth = '" + dateOfBirth + "'" +
                    ",gender = '" + gender + "',address = '" + address + "',email = '" + email + "',mobilePhone = '" + mobilePhone + "',homePhone = '" + homePhone + "'" +
                    ",parentName = '" + parentName + "',nic = '" + nic + "',contactNo = '" + contactNo + "' WHERE regNo = '" + regNo + "'";
				SqlCommand cmnd = new SqlCommand(updatesql, con);
				con.Open();
				cmnd.ExecuteNonQuery();

				MessageBox.Show("Record Updated Succecfully", "Update Student");
				
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error while updating" + ex);
			}
			finally { con.Close(); }

		}

		private void button4_Click(object sender, EventArgs e)
        {
			try
			{
				string regNo = c_1.Text;
				string deletesql = "delete from Registration where RegNo='" + regNo + "'";
				SqlCommand comd = new SqlCommand(deletesql, con);
				con.Open();
				comd.ExecuteNonQuery();
				MessageBox.Show("Record deleted succesfully");
				
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error while deleting" + ex);
			}
			finally
			{
				con.Close();
			}
		}

        private void groupBox1_Enter(object sender, EventArgs e)
        {
           
        }

        private void d_1_ValueChanged(object sender, EventArgs e, DateTimePicker d_1, DateTimePicker d_11)
        {
            d_1_ValueChanged(sender, e, d_1);
        }

        private void d_1_ValueChanged(object sender, EventArgs e, DateTimePicker d_1)
        {
            d_1_ValueChanged(sender, e, d_1, d_1);
        }

  

        private void btn_Search_Click(object sender, EventArgs e)
		{
			try
			{
				string regNo = c_1.Text;
				string query_search = "SELECT * FROM Registration where regNo= '" + regNo + "'";
				SqlCommand cmnd = new SqlCommand(query_search, con);
				con.Open();
				SqlDataReader dr = cmnd.ExecuteReader();
				if (dr.Read())
				{
					c_1.Text = dr["regNo"].ToString();
					t_1.Text=dr["firstName"].ToString();
					t_2.Text = dr ["lastname"].ToString();
					d_1.Text=dr ["dateOfBirth"].ToString();
					string gender= dr ["gender"].ToString();

					if (gender=="Male")
					{
						r_1.Checked = true;
					}
					else
					{
						r_2.Checked = true;
					}
					t_3.Text =  dr["address"].ToString();
					t_4.Text = dr["email"].ToString();
					t_5.Text = dr["mobilePhone"].ToString();
					t_6.Text = dr ["homePhone"].ToString();
					t_7.Text = dr ["parentName"].ToString();
					t_8.Text = dr["nic"].ToString();
					t_9.Text = dr ["contactNo"].ToString();
				}
				else
					MessageBox.Show("Record not found");

			}
			catch (Exception ex)
			{
				MessageBox.Show("Error while deleting" + ex);
			}
			finally { con.Close(); }
		}

		private void btn_CD_Click(object sender, EventArgs e)
		{
			course_details fm = new course_details();
			fm.Show();
		}
	}
}
