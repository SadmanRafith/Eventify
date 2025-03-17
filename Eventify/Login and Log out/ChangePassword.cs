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
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Codings\C# Project\Eventify\Database\EVENTIFY.mdf"";Integrated Security=True;Connect Timeout=30");

            string pattern = @"[^a-zA-Z0-9\s]";
            Regex regex = new Regex(pattern);

            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter a New Password", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (textBox1.Text.Length < 8)
                {
                    MessageBox.Show("Password must have at least 8 charecters.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (!textBox1.Text.Any(char.IsDigit))
                {
                    MessageBox.Show("Password must contain at least one digit.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (!regex.IsMatch(textBox1.Text))
                {
                    MessageBox.Show("Password must contain at least one Speacial Charecter.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if(textBox2.Text == "")
                    {
                        MessageBox.Show("Please enter Confirm Password.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if(textBox1.Text != textBox2.Text)
                    {
                        MessageBox.Show("Password didn't match.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("Update AppUser set password = @password where uId = " + ForgotPassword.uId, con);

                        cmd.Parameters.AddWithValue("@password", textBox1.Text);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Password changed successfully.", "Massage!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SignInForm signInForm = new SignInForm();
                        signInForm.Visible = true;
                        this.Visible = false;
                    }
                }
            }  
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            ForgotPassword forgotPassword = new ForgotPassword();
            forgotPassword.Visible = true;
            this.Visible = false;
        }

        private void minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
    }
}
