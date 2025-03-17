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
    public partial class Security : Form
    {
        public Security()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Codings\C# Project\Eventify\Database\EVENTIFY.mdf"";Integrated Security=True;Connect Timeout=30");

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            string pattern = @"[^a-zA-Z0-9\s]";
            Regex regex = new Regex(pattern);

            if ((textBox1.Text == "") || (textBox2.Text == "") || (textBox3.Text == ""))
            {
                MessageBox.Show("Please enter all the information", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (textBox1.Text == "")
                {
                    label1.ForeColor = Color.Red;
                }
                if (textBox2.Text == "")
                {
                    label2.ForeColor = Color.Red;
                }
                if (textBox3.Text == "")
                {
                    label3.ForeColor = Color.Red;
                }
            }
            else
            {
                int m = 0;
                con.Open();
                SqlCommand cmd = new SqlCommand("select password from AppUser where uId =" + SignInForm.ID, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if(textBox1.Text == dr["password"].ToString())
                    {
                        m = 1;
                    }
                }
                dr.Close();
                con.Close();

                if (m == 1)
                {
                    if (textBox2.Text.Length < 8)
                    {
                        MessageBox.Show("Password must have at least 8 charecters.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (!textBox2.Text.Any(char.IsDigit))
                    {
                        MessageBox.Show("Password must contain at least one digit.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (!regex.IsMatch(textBox2.Text))
                    {
                        MessageBox.Show("Password must contain at least one Speacial Charecter.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (textBox2.Text == textBox3.Text)
                        {
                            con.Open();
                            SqlCommand cmd1 = new SqlCommand("Update AppUser set password = @password where uId = " + SignInForm.ID, con);

                            cmd1.Parameters.AddWithValue("@password", textBox3.Text);
                            cmd1.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Password changed successfully");
                        }
                        else
                        {
                            MessageBox.Show("Password didn't match", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Wrong Current Password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            if (textBox1.PasswordChar == '*')
            {
                textBox1.PasswordChar = '\0';
                textBox1.Focus();
                iconButton3.IconSize = 30;
                iconButton3.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            }
            else
            {
                textBox1.PasswordChar = '*';
                textBox1.Focus();
                iconButton3.IconSize = 27;
                iconButton3.IconChar = FontAwesome.Sharp.IconChar.Eye;
            }
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            if (textBox2.PasswordChar == '*')
            {
                textBox2.PasswordChar = '\0';
                textBox2.Focus();
                iconButton4.IconSize = 30;
                iconButton4.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            }
            else
            {
                textBox2.PasswordChar = '*';
                textBox2.Focus();
                iconButton4.IconSize = 27;
                iconButton4.IconChar = FontAwesome.Sharp.IconChar.Eye;
            }
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            if (textBox3.PasswordChar == '*')
            {
                textBox3.PasswordChar = '\0';
                textBox3.Focus();
                iconButton5.IconSize = 30;
                iconButton5.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            }
            else
            {
                textBox3.PasswordChar = '*';
                textBox3.Focus();
                iconButton5.IconSize = 27;
                iconButton5.IconChar = FontAwesome.Sharp.IconChar.Eye;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
