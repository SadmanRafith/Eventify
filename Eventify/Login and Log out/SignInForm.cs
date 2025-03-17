using Eventify.ProjectForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eventify
{
    public partial class SignInForm : Form
    {
        public SignInForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private void SignInForm_Load(object sender, EventArgs e)
        {
            
        }
        private static string username;
        private string password;
        private static string status;
        public static int id, aid;

        public static int ID
        { get { return id; } }

        public static int AID
        { get { return aid; } }
        public static string STATUS
        { get { return status; } }
        public static string USERNAME
        { get { return username; } }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if(textBox2.PasswordChar == '*')
            {
                textBox2.PasswordChar = '\0';
                textBox2.Focus();
                iconButton1.IconSize = 30;
                iconButton1.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            }
            else
            {
                textBox2.PasswordChar = '*';
                textBox2.Focus();
                iconButton1.IconSize = 27;
                iconButton1.IconChar = FontAwesome.Sharp.IconChar.Eye;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPassword forgotPassword = new ForgotPassword();
            forgotPassword.Visible = true;
            this.Visible=false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void roundButton1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Username" && textBox2.Text != "Password")
            {
                MessageBox.Show("Please enter username", "Massage", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (textBox2.Text == "Password" && textBox1.Text != "Username")
            {

                MessageBox.Show("Please enter password", "Massage", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (textBox1.Text == "Username" && textBox2.Text == "Password")
            {
                MessageBox.Show("Please enter username and password", "Massage", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                if (textBox1.Text.Substring(0, 3) == "aaa")
                {
                    int isAdmin = 0;
                    SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Codings\C# Project\Eventify\Database\EVENTIFY.mdf"";Integrated Security=True;Connect Timeout=30");
                    con1.Open();
                    SqlCommand sq1 = new SqlCommand("Select * from Admin", con1);
                    SqlDataReader dr1 = sq1.ExecuteReader();
                    while (dr1.Read())
                    {
                        string nameA = dr1["name"].ToString();
                        string passwordA = dr1["password"].ToString();

                        if (passwordA == textBox2.Text && nameA == textBox1.Text)
                        {
                            isAdmin = 1;
                            aid = Convert.ToInt32(dr1["aid"]);
                            break;
                        }
                    }
                    con1.Close();

                    if (isAdmin == 1)
                    {
                        AdminForms.MainAdminForm aM = new AdminForms.MainAdminForm();
                        aM.Visible = true;
                        this.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Invalid admin info", "Massage", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    int m = 0;
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""E:\CSE\SIXTH SEMESTER\C#\LAB\Eventify v3.3\Database\EVENTIFY.mdf"";Integrated Security=True;Connect Timeout=30;Encrypt=True");
                    con.Open();
                    SqlCommand sq = new SqlCommand("select * from AppUser", con);
                    SqlDataReader dr = sq.ExecuteReader();
                    while (dr.Read())
                    {
                        username = dr["username"].ToString();
                        password = dr["password"].ToString();
                        

                        if (password == textBox2.Text && username == textBox1.Text)
                        {
                            m = 1;
                            id = Convert.ToInt32(dr["uId"]);
                            status = dr["status"].ToString();
                            break;
                        }
                    }
                    con.Close();
                    if (m == 0)
                    {
                        MessageBox.Show("Invalid username or password", "Massage", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        LoadingScreen l = new LoadingScreen();
                        l.Visible = true;
                        this.Visible = false;
                    }
                }
            }
        }


        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Password")
            {
                textBox2.Text = "";
                textBox2.PasswordChar = '*';
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.PasswordChar = '\0';
                textBox2.Text = "Password";
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Username")
            {
                textBox1.Text = "";
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Username";
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUpForm signUpForm = new SignUpForm();
            this.Visible = false;
            signUpForm.Visible = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
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

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            About about = new About();
            about.Show();
        }
    }
}
