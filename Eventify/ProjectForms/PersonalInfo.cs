using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eventify.ProjectForms
{
    public partial class PersonalInfo : Form
    {
        public PersonalInfo()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Codings\C# Project\Eventify\Database\EVENTIFY.mdf"";Integrated Security=True;Connect Timeout=30");

        private void PersonalInfo_Load(object sender, EventArgs e)
        {
            getInfo();
        }


        private void getInfo()
        {
            con.Open();
            SqlCommand sq1 = new SqlCommand("select * from AppUser where uId =" + SignInForm.ID, con);
            SqlDataReader sdr = sq1.ExecuteReader();
            while (sdr.Read())
            {
                textBox1.Text = sdr["username"].ToString();
                textBox2.Text = sdr["phone_no"].ToString();
                textBox3.Text = sdr["first_name"].ToString();
                textBox4.Text = sdr["last_name"].ToString();
                textBox5.Text = sdr["address"].ToString();
                textBox6.Text = sdr["email"].ToString();
                dateTimePicker1.Text = sdr["dob"].ToString();
                string gender = sdr["gender"].ToString();
                if (gender == "Male")
                {
                    radioButton1.Checked = true;
                }
                if (gender == "Female")
                {
                    radioButton2.Checked = true;
                }
                if(gender == "Others")
                {
                    radioButton3.Checked = true;
                }
            }

            con.Close();
        }

        private void roundButton1_Click(object sender, EventArgs e)
        {

            
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "") || (textBox2.Text == "") || (textBox3.Text == "") || (textBox4.Text == "") || (textBox5.Text == "") || (textBox6.Text == "") || (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked))
            {
                if (textBox1.Text == "")
                {
                    label7.ForeColor = Color.Red;
                }
                if (textBox2.Text == "")
                {
                    label3.ForeColor = Color.Red;
                }
                if (textBox3.Text == "")
                {
                    label2.ForeColor = Color.Red;
                }
                if (textBox4.Text == "")
                {
                    label6.ForeColor = Color.Red;
                }
                if (textBox5.Text == "")
                { label11.ForeColor = Color.Red; }
                if (textBox6.Text == "")
                { label1.ForeColor = Color.Red; }

                if (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked)
                { label4.ForeColor = Color.Red; }
                MessageBox.Show("Please fill up all the information", "Massage", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                if (textBox2.Text.Length != 11)
                {
                    MessageBox.Show("Invalid Phone No.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (!textBox6.Text.Contains('@') || !textBox6.Text.Contains(".com"))
                    {
                        MessageBox.Show("Please enter a valid email", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        con.Open();
                        SqlCommand sq1 = new SqlCommand("update AppUser set username = @username, phone_no = @phone_no, first_name = @first_name, last_name = @last_name, address = @address, dob = @dob, email = @email, gender = @gender Where uId =" + SignInForm.ID, con);
                        sq1.Parameters.AddWithValue("@username", textBox1.Text);
                        sq1.Parameters.AddWithValue("@phone_no", textBox2.Text);
                        sq1.Parameters.AddWithValue("@first_name", textBox3.Text);
                        sq1.Parameters.AddWithValue("@last_name", textBox4.Text);
                        sq1.Parameters.AddWithValue("@address", textBox5.Text);
                        sq1.Parameters.AddWithValue("@email", textBox6.Text);
                        sq1.Parameters.AddWithValue("@dob", dateTimePicker1.Text);

                        if (radioButton1.Checked)
                        {
                            sq1.Parameters.AddWithValue("@gender", "Male");
                        }
                        if (radioButton2.Checked)
                        {
                            sq1.Parameters.AddWithValue("@gender", "Female");
                        }
                        if (radioButton3.Checked)
                        {
                            sq1.Parameters.AddWithValue("@gender", "Others");
                        }
                        sq1.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Value updated successfully", "Massage", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
