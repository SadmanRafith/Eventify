using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eventify
{
    public partial class ForgotPassword : Form
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }
        
        private void ForgotPassword_Load(object sender, EventArgs e)
        {
            textBox2.Visible = false;
            iconButton2.Visible = false;
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Codings\C# Project\Eventify\Database\EVENTIFY.mdf"";Integrated Security=True;Connect Timeout=30");

        string randomCode;
        public static string to;
        public static string username;
        public static int uId;
        private void iconButton1_Click(object sender, EventArgs e)
        {
            if((textBox1.Text == "" || textBox1.Text == "Email Address") || (textBox3.Text == "" || textBox3.Text == "Username"))
            {

                if ((textBox1.Text == "" || textBox1.Text == "Email Address") && (textBox3.Text == "" || textBox3.Text == "Username"))
                {
                    MessageBox.Show("Please enter your Username and Email.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if ((textBox1.Text == "" || textBox1.Text == "Email Address"))
                    {
                        MessageBox.Show("Please enter email.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Please enter your Username.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                
            }
            else
            {
                int m = 0;
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from AppUser", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    if(textBox3.Text == dr["username"].ToString())
                    {
                        m = 1;
                        uId = Convert.ToInt32(dr["uId"]);
                        break;
                    }
                }
                con.Close();

                if(m == 0)
                {
                    MessageBox.Show("User not found.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (!textBox1.Text.Contains('@') && textBox1.Text.Contains(".com"))
                    {
                        MessageBox.Show("Please enter a valid email", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        String from, pass, messageBody;
                        Random rand = new Random();
                        randomCode = (rand.Next(100000, 999999)).ToString();
                        MailMessage message = new MailMessage();
                        to = (textBox1.Text).ToString();
                        from = "eventify.corp@gmail.com";
                        pass = "qowomlxagdacilol";
                        messageBody = "Your account verification code is: " + randomCode;
                        message.To.Add(to);
                        message.From = new MailAddress(from);
                        message.Body = messageBody;
                        message.Subject = "Reset Password";
                        SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                        smtp.EnableSsl = true;
                        smtp.Port = 587;
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.Credentials = new NetworkCredential(from, pass);

                        try
                        {
                            smtp.Send(message);
                            MessageBox.Show("Code Send Successfully", "Massage", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            textBox2.Visible = true;
                            iconButton2.Visible = true;
                            textBox1.Visible = false;
                            iconButton1.Visible = false;
                            iconButton3.Visible = true;
                            textBox3.Enabled = false;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignInForm form = new SignInForm();
            form.Visible = true;
            this.Visible = false;
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            if(randomCode == textBox2.Text)
            {
                to = textBox1.Text;
                ChangePassword changePassword = new ChangePassword();
                changePassword.Visible = true;
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("Incorrect code. Verification failed. Please try again", "Massage", MessageBoxButtons.OK, MessageBoxIcon.Information);
                iconButton2.Visible= true;
            }
        }

        

        private void iconButton3_Click(object sender, EventArgs e)
        {
            textBox2.Visible = false;
            iconButton2.Visible = false;
            textBox1.Visible = true;
            iconButton1.Visible = true;
            textBox3.Enabled = true;
            iconButton3.Visible = false;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Email Address")
            {
                textBox1.Text = "";
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Email Address";
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Enter Verification Code")
            {
                textBox2.Text = "";
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Enter Verification Code";
            }
        }

        private void minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if(textBox3.Text == "Username")
            {
                textBox3.Text = "";
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Username";
            }
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private static extern void ReleseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
