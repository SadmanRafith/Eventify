using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eventify
{
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignInForm signInForm = new SignInForm();
            signInForm.Visible = true;
            this.Visible = false;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void SignUpForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if(textBox1.Text == "Username")
            {
                textBox1.Text = "";
                textBox1.ForeColor = System.Drawing.Color.BlueViolet;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.ForeColor = System.Drawing.Color.BlueViolet;
                textBox1.Text = "Username";
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Phone No")
            {
                textBox2.ForeColor = System.Drawing.Color.BlueViolet;
                textBox2.Text = "";
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.ForeColor = System.Drawing.Color.BlueViolet;
                textBox2.Text = "Phone No";
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "First Name")
            {
                textBox3.ForeColor = System.Drawing.Color.BlueViolet;
                textBox3.Text = "";
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.ForeColor = System.Drawing.Color.BlueViolet;
                textBox3.Text = "First Name";
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Last Name")
            {
                textBox4.ForeColor = System.Drawing.Color.BlueViolet;
                textBox4.Text = "";
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.ForeColor = System.Drawing.Color.BlueViolet;
                textBox4.Text = "Last Name";
            }
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (textBox5.Text == "Address")
            {
                textBox5.ForeColor = System.Drawing.Color.BlueViolet;
                textBox5.Text = "";
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                textBox5.ForeColor = System.Drawing.Color.BlueViolet;
                textBox5.Text = "Address";
            }
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            if (textBox6.Text == "Email")
            {
                textBox6.ForeColor = System.Drawing.Color.BlueViolet;
                textBox6.Text = "";
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                textBox6.ForeColor = System.Drawing.Color.BlueViolet;
                textBox6.Text = "Email";
            }
        }

        private void textBox7_Enter(object sender, EventArgs e)
        {
            if (textBox7.Text == "Password")
            {
                textBox7.ForeColor = System.Drawing.Color.BlueViolet;
                textBox7.Text = "";
            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
            {   textBox7.ForeColor = System.Drawing.Color.BlueViolet;
                textBox7.Text = "Password";
            }
        }

        private void textBox8_Enter(object sender, EventArgs e)
        {
            if (textBox8.Text == "Confirm Password")
            {
                textBox8.ForeColor = System.Drawing.Color.BlueViolet;
                textBox8.Text = "";
            }
        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            if (textBox8.Text == "")
            {
                textBox8.ForeColor = System.Drawing.Color.BlueViolet;
                textBox8.Text = "Confirm Password";
            }
        }

        private void roundButton1_Click(object sender, EventArgs e)
        {
            if((textBox1.Text == "" || textBox1.Text == "Username") || (textBox2.Text == "" || textBox2.Text == "Phone No") || (textBox3.Text == "" || textBox3.Text == "First Name") || (textBox4.Text == "" || textBox4.Text == "Last Name") || (textBox5.Text == "" || textBox5.Text == "Address") || (textBox6.Text == "" || textBox6.Text == "Email") || (textBox7.Text == "" || textBox7.Text == "Password") || (textBox8.Text == "" || textBox8.Text == "Confirm Password") || (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked))
            {
                if(textBox1.Text == "" || textBox1.Text == "Username")
                {
                    textBox1.ForeColor = Color.Red;
                }
                if(textBox2.Text == "" || textBox2.Text == "Phone No")
                {
                    textBox2.ForeColor = Color.Red;
                }
                if(textBox3.Text == "" || textBox3.Text == "First Name")
                {
                    textBox3.ForeColor = Color.Red;
                }
                if(textBox4.Text == "" || textBox4.Text == "Last Name")
                {
                    textBox4.ForeColor = Color.Red;
                }
                if(textBox5.Text == "" || textBox5.Text == "Address")
                { textBox5.ForeColor = Color.Red;}
                if(textBox6.Text == "" || textBox6.Text == "Email")
                { textBox6.ForeColor = Color.Red;}
                if(textBox7.Text == "" || textBox7.Text == "Password")
                { textBox7.ForeColor = Color.Red;}
                if(textBox8.Text == "" || textBox8.Text == "Confirm Password")
                { textBox8.ForeColor = Color.Red;}
                if(!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked)
                { label4.ForeColor = Color.Red; }
                MessageBox.Show("Please fill all the information carefully");
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\CSE\SIXTH SEMESTER\C#\LAB\Eventify v3.3\Database\EVENTIFY.mdf"";Integrated Security=True;Connect Timeout=30;Encrypt=True");

                if (textBox7.Text != textBox8.Text)
                {
                    MessageBox.Show("Password didn't match.");
                }
                else
                {
                    int i = 0;
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Select username from AppUser", con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (textBox1.Text == reader["username"].ToString())
                        {
                            i = 1; 
                            break;
                        }
                    }
                    con.Close();

                    string pattern = @"[^a-zA-Z0-9\s]";
                    Regex regex = new Regex(pattern);
                    if (i != 0)
                    {
                        MessageBox.Show("This username is taken.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (textBox7.Text.Length < 8)
                    {
                        MessageBox.Show("Password must have at least 8 charecters.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if(!textBox7.Text.Any(char.IsDigit))
                    {
                        MessageBox.Show("Password must contain at least one digit.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (!regex.IsMatch(textBox7.Text))
                    {
                        MessageBox.Show("Password must contain at least one Speacial Charecter.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if(textBox2.Text.Length != 11)
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
                            SqlCommand sqlCommand = new SqlCommand("Insert into AppUser(username, email, phone_no, address, gender, password, first_name, last_name, balance, status, block_status, dob) values (@username, @email, @phone_no, @address, @gender, @password, @first_name, @last_name, @balance, @status, @block_status, @dob)", con);
                            sqlCommand.Parameters.AddWithValue("@username", textBox1.Text);
                            sqlCommand.Parameters.AddWithValue("@phone_no", textBox2.Text);
                            sqlCommand.Parameters.AddWithValue("@first_name", textBox3.Text);
                            sqlCommand.Parameters.AddWithValue("@last_name", textBox4.Text);
                            sqlCommand.Parameters.AddWithValue("@address", textBox5.Text);
                            sqlCommand.Parameters.AddWithValue("@email", textBox6.Text);
                            sqlCommand.Parameters.AddWithValue("@password", textBox7.Text);
                            sqlCommand.Parameters.AddWithValue("@status", "user");
                            sqlCommand.Parameters.AddWithValue("@block_status", "unblocked");
                            sqlCommand.Parameters.AddWithValue("@balance", 0);
                            sqlCommand.Parameters.AddWithValue("@dob", dateTimePicker1.Text);

                            if (radioButton1.Checked)
                            {
                                sqlCommand.Parameters.AddWithValue("@gender", "Male");
                            }
                            else if (radioButton2.Checked)
                            {
                                sqlCommand.Parameters.AddWithValue("@gender", "Female");
                            }
                            else
                            {
                                sqlCommand.Parameters.AddWithValue("@gender", "Others");
                            }
                            sqlCommand.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Account created successfully");
                            SignInForm form = new SignInForm();
                            this.Visible = false;
                            form.Visible = true;
                        }
                    }
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label4.ForeColor = System.Drawing.Color.BlueViolet;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label4.ForeColor = System.Drawing.Color.BlueViolet;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label4.ForeColor = System.Drawing.Color.BlueViolet;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private static extern void ReleseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            About about = new About();
            about.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
