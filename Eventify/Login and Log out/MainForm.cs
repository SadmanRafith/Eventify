using Eventify.ProjectForms;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Eventify
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Text = String.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Codings\C# Project\Eventify\Database\EVENTIFY.mdf"";Integrated Security=True;Connect Timeout=30");

        private void MainForm_Load(object sender, EventArgs e)
        {
            setEventStatus();
            label2.Text = "Hi there " + SignInForm.USERNAME;
            label4.Text = getBalance() + " BDT";
            GetData();
            GetDatas();
        }

        private int getBalance()
        {
            int balance = 0;
            con.Open();
            SqlCommand sc1 = new SqlCommand("Select balance from AppUser where uId =" + SignInForm.ID, con);
            SqlDataReader dr = sc1.ExecuteReader();
            if (dr.Read())
            {
                balance = Convert.ToInt32(dr["balance"]);
            }
            con.Close();
            return balance;
            
        }

        //Drag titlePanel {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private static extern void ReleseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void titlePanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        // }

        // ThemeColor {
        private int index = 1;
        private Color selectThemeColor()
        {
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }
        // }

        //Enable and Disable Button {
        IconButton currentButton;
        Color c;
        private void enableButton(object btn)
        {
            if(btn != null)
            {
                disableButton();
                Color color = selectThemeColor();
                c = color;
                currentButton = (IconButton)btn;
                currentButton.BackColor = color;
                currentButton.ForeColor = Color.Gainsboro;
                panel1.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                homeButton.Enabled = true;
                homeButton.IconChar = FontAwesome.Sharp.IconChar.Home;
                //titleButton.Text = currentButton.Text;
            }
        }
        private void disableButton()
        {
            if (currentButton != null)
            {
                currentButton.BackColor = Color.FromArgb(51, 51, 76);
                currentButton.ForeColor = Color.Gainsboro;
                titleButton.ForeColor = Color.Gainsboro;
            }
        }
        // }


        void setEventStatus()
        {
            int[] eid = new int[500];
            int i = 0;
            con.Open();
            SqlCommand cmd = new SqlCommand("Select eId from Event", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                eid[i++] = (int)dr["eId"];
            }
            dr.Close();
            con.Close();
            if (eid[0] != 0)
            {
                foreach (int id in eid)
                {
                    int capacity, res, thisTime;
                    DateTime now = DateTime.Now;
                    thisTime = now.Hour;
                    DateTime dateTime = DateTime.Today;
                    string date = "January 10 2020";
                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("Select * from Event WHERE eId =" + id, con);
                    SqlDataReader dr1 = cmd1.ExecuteReader();
                    while (dr1.Read())
                    {
                        date = dr1["date"].ToString();
                        capacity = Convert.ToInt32(dr1["capacity"]);
                        res = Convert.ToInt32(dr1["registerd_seats"]);
                    }
                    con.Close();
                    DateTime dateTime1 = DateTime.Parse(date);
                    int current = DateTime.Compare(dateTime, dateTime1);
                    if (current > 0)
                    {
                        con.Open();
                        SqlCommand c1 = new SqlCommand("Update Event set e_status = @e_status WHERE eId =" + id, con);
                        c1.Parameters.AddWithValue("@e_status", "expired");
                        c1.Parameters.AddWithValue("@edit_status", "Uneditable");
                        c1.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (current == 0)
                    {
                        con.Open();
                        SqlCommand c2 = new SqlCommand("Update Event set e_status = @e_status, edit_status = @edit_status, block_status = @block_status WHERE eId =" + id, con);
                        c2.Parameters.AddWithValue("@e_status", "invalid");
                        c2.Parameters.AddWithValue("@edit_status", "Uneditable");
                        c2.Parameters.AddWithValue("@Block_status", "Can't edit");
                        c2.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        string event_year = dateTime1.Year.ToString();
                        string event_month = dateTime1.Month.ToString();
                        int event_day = dateTime1.Day;
                        string today_year = dateTime.Year.ToString();
                        string today_month = dateTime.Month.ToString();
                        int today_day = dateTime.Day;
                        if(event_year == today_year && event_month == today_month && event_day == today_day+1)
                        {
                            con.Open();
                            SqlCommand c4 = new SqlCommand("Update Event set e_status = @e_status, edit_status = @edit_status, block_status = @block_status WHERE eId =" + id, con);
                            c4.Parameters.AddWithValue("@e_status", "invalid");
                            c4.Parameters.AddWithValue("@edit_status", "Uneditable");
                            c4.Parameters.AddWithValue("@Block_status", "Can't edit");
                            c4.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }
            }
        }


        // open new Form {
        private Form currentForm;
        public void openForm(Form newForm)
        {
            if (currentForm != null) 
            {
                currentForm.Close();
            }
            currentForm = newForm;
            currentForm.TopLevel = false;
            currentForm.FormBorderStyle = FormBorderStyle.None;
            currentForm.Dock = DockStyle.Fill;
            this.mainPanel.Controls.Add(newForm);
            newForm.BringToFront();
            newForm.Show();
        }
        // }
        private void titlePanel_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            titleButton.Text = "Browse Events";
            enableButton(sender);
            openForm(new ProjectForms.BrowseEvents());

            setEventStatus();
        }

        private void regesteredButton_Click(object sender, EventArgs e)
        {
            titleButton.Text = "Registered Events";
            enableButton(sender);
            openForm(new ProjectForms.RegisteredEvents());
        }
        String status = SignInForm.STATUS;
        private void createButton_Click(object sender, EventArgs e)
        {
            titleButton.Text = "Create Events";
            enableButton(sender);

            if (status == "user" || status == "requested")
            {
                openForm(new ProjectForms.CreateEvents());
            }
            else
            {
                openForm(new ProjectForms.CreateEvent2());
            }

        }

        private void myButtoy_Click(object sender, EventArgs e)
        {
            titleButton.Text = "My Events";
            enableButton(sender);
            setEventStatus();
            con.Close();
            if (status == "user" || status == "requested")
            {
                openForm(new ProjectForms.CreateEvents());
            }
            else
            {
                openForm(new ProjectForms.MyEvents());
            }
        }

        private void historyButton_Click(object sender, EventArgs e)
        {
            titleButton.Text = "Event History";
            enableButton(sender);
            openForm(new ProjectForms.History());
            setEventStatus();
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            titleButton.Text = "Settings";
            enableButton(sender);
            openForm(new ProjectForms.Settings());
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        int[] jj = new int[500];
        int j = 0;
        private void GetDatas()
        {
            con.Open();
            SqlCommand mSqId = new SqlCommand("select eId from Register WHERE uId = " + SignInForm.ID, con);
            SqlDataReader mDrId = mSqId.ExecuteReader();

            while (mDrId.Read())
            {
                jj[j++] = Convert.ToInt32(mDrId["eId"]); ;
            }
            con.Close();
            DateTime today = DateTime.Today;
            foreach (int j in jj)
            {
                con.Open();
                SqlCommand bSq = new SqlCommand("select * from Event WHERE eId=" + j, con);
                SqlDataReader bDr = bSq.ExecuteReader();
                while (bDr.Read())
                {
                    
                    string date = bDr["date"].ToString();
                    HomeEventList homeEvents1 = new HomeEventList();
                    homeEvents1.HID = Convert.ToInt32(bDr["eId"]);
                    homeEvents1.TITLE = bDr["title"].ToString();
                    homeEvents1.DATE = date;
                    homeEvents1.VENUE = bDr["venue"].ToString();
                    int capacity = Convert.ToInt32(bDr["capacity"]);
                    int regs = Convert.ToInt32(bDr["registerd_seats"]);
                    homeEvents1.RS = regs;
                    homeEvents1.CAPACITY = capacity;
                    string e_status = bDr["e_status"].ToString();


                    
                    DateTime dateTime1 = DateTime.Parse(date);
                    int current1 = DateTime.Compare(today, dateTime1);

                    if ((current1 == 0) && bDr["e_status"].ToString() != "expired")
                    {
                        flowLayoutPanel3.Controls.Add(homeEvents1);
                    }
                }
                con.Close();
            }
        }
        private void maximize_Click(object sender, EventArgs e)
        {
            if(WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void titleLabel_Click(object sender, EventArgs e)
        {

        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            label4.Text = getBalance() + "BDT";
            if (currentForm != null)
            {
                currentForm.Close();
            }
            disableButton();
            currentForm = null;
            titleButton.Text = "Home";
            titleButton.Location = new Point(429, 49);
            titleButton.ForeColor = Color.Gainsboro;
            panel1.BackColor = Color.FromArgb(39, 39, 58);
            homeButton.Enabled = false;
            GetData();
        }

        private void titleButton_Click(object sender, EventArgs e)
        {

        }

        private void titleButton_MouseHover(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            SignInForm signInForm = new SignInForm();
            signInForm.Visible = true;
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void GetData()
        {
            con.Open();
            SqlCommand bSq = new SqlCommand("select * from Event", con);
            SqlDataReader bDr = bSq.ExecuteReader();
            while (bDr.Read())
            {
                HomeEventList homeEvents = new HomeEventList();
                homeEvents.HID = Convert.ToInt32(bDr["eId"]);
                homeEvents.TITLE = bDr["title"].ToString();
                homeEvents.DATE = bDr["date"].ToString();
                homeEvents.VENUE = bDr["venue"].ToString();
                int capacity = Convert.ToInt32(bDr["capacity"]);
                int regs = Convert.ToInt32(bDr["registerd_seats"]);
                homeEvents.RS = regs;
                homeEvents.CAPACITY = capacity;
                string e_status = bDr["e_status"].ToString();

                if (e_status == "valid" && bDr["block_status"].ToString() != "Blocked" && homeEvents.TITLE.Length > 0 && (regs > (2 * capacity) / 3) && (regs < capacity))
                {

                    flowLayoutPanel1.Controls.Add(homeEvents);

                }
            }
            con.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            openForm(new ProjectForms.Credits());
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
