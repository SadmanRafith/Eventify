using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eventify.ProjectForms
{
    public partial class RegisteredEventList : UserControl
    {
        public RegisteredEventList()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Codings\C# Project\Eventify\Database\EVENTIFY.mdf"";Integrated Security=True;Connect Timeout=30");

        private void RegiresteredEventList_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(297, 305);
            string bSts = "";
            con.Open();
            SqlCommand cmd = new SqlCommand("Select block_status from AppUser where uId = " + SignInForm.ID, con);
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            if (sqlDataReader.Read())
            {
                bSts = sqlDataReader["block_status"].ToString();
            }
            con.Close();

            if (bSts == "blocked")
            {
                iconButton1.Visible = false;
                iconButton2.Visible = false;
                iconButton3.Visible = false;
                label7.Visible = false;
                label2.Text = "User blocked";
                label2.ForeColor = System.Drawing.Color.Red;
            }

            string talp = "";
            con.Open();
            SqlCommand cmd1 = new SqlCommand("Select price from Register where uId = " + SignInForm.ID + "and eId =" +id, con);
            SqlDataReader sqlDataReader1 = cmd1.ExecuteReader();
            if (sqlDataReader1.Read())
            {
                talp = sqlDataReader1["price"].ToString();
            }
            con.Close();
            label34.Text = talp;

        }

        string title1;//
        string category1;//
        string date1;//
        string venue1;//
        private Bitmap pic1;//
        int id;//
        int capacity; //
        int registered_seats; //
        int price; //
        string time;//
        string duration;//
        private Bitmap f1;
        private Bitmap f2;
        private Bitmap g1;
        private Bitmap g2;
        private Bitmap g3;
        private Bitmap g4;
        private string description; //
        private string organizer; //
        private string other_organizers; //
        private string guest1; //
        private string guest2; //
        private string guest3; //
        private string guest4; //
        private int food_price;
        private int parking;

        [Category("Custom Props")]
        public int ID
        { get { return id; } set { id = value; } }

        [Category("Custom Props")]
        public string TITLE1
        { get { return title1; } set { title1 = value; label8.Text = value; } }

        [Category("Custom Props")]
        public string CATEGORY1
        { get { return category1; } set { category1 = value; label7.Text = value; } }

        [Category("Custom Props")]
        public string DATE1
        { get { return date1; } set { date1 = value; label6.Text = value; } }

        [Category("Custom Props")]
        public string VENUE1
        { get { return date1; } set { venue1 = value; label5.Text = value; } }

        [Category("Custom Props")]
        public Bitmap DISPLAY
        { get { return pic1; } set { pic1 = value; iconPictureBox1.Image = value; } }
        
        int f_price, s_price, p_price, t_price;
        private void iconButton1_Click(object sender, EventArgs e)
        {
            int f=0, p=0;
            con.Open();
            SqlCommand cmdg = new SqlCommand("select nOs, f_price, p_price from Register where eId =" + id + "and uId =" + SignInForm.ID, con);
            SqlDataReader cmdgDr = cmdg.ExecuteReader();
            while (cmdgDr.Read())
            {
                comboBox1.Text = cmdgDr["nOs"].ToString();
                f = Convert.ToInt32(cmdgDr["f_price"]);
                p = Convert.ToInt32(cmdgDr["p_price"]);
            }
            con.Close();

            con.Open();
            SqlCommand sel = new SqlCommand("Select g1_image, g2_image, g3_image, g4_image, image1, image2, title, category, capacity, price, venue, date, time, duration, description, organizer, guest1, guest2, guest3, guest4, display, food, food_price, parking, park_sts, registerd_seats, edit_status, block_status from event where eid = " + id, con);
            SqlDataReader bDr = sel.ExecuteReader();
            while (bDr.Read())
            {
                long len = bDr.GetBytes(0, 0, null, 0, 0);
                byte[] array = new byte[System.Convert.ToInt32(len) + 1];
                bDr.GetBytes(0, 0, array, 0, System.Convert.ToInt32(len));
                MemoryStream memoryStream = new MemoryStream(array);
                Bitmap bitmap = new Bitmap(memoryStream);

                label17.Text = bDr["time"].ToString();
                label18.Text = bDr["duration"].ToString();
                label19.Text = bDr["capacity"].ToString();
                //label28.Text = bDr["title"].ToString();
                label21.Text = bDr["price"].ToString();
                label23.Text = bDr["organizer"].ToString();
                label16.Text = bDr["description"].ToString();
                label24.Text = bDr["guest1"].ToString();
                label25.Text = bDr["guest2"].ToString();
                label26.Text = bDr["guest3"].ToString();
                label27.Text = bDr["guest4"].ToString();
                label28.Text = bDr["food"].ToString();
                f_price = Convert.ToInt32(bDr["food_price"]);
                p_price = Convert.ToInt32(bDr["parking"]);
                price = Convert.ToInt32(bDr["price"]);
                string park_sts = bDr["park_sts"].ToString();
                string edit_status = bDr["edit_status"].ToString();
                string b_status = bDr["block_status"].ToString();
                pictureBox1.Image = bitmap;

                int r_seats = Convert.ToInt32(bDr["registerd_seats"]);
                int a_seats = Convert.ToInt32(label19.Text) - r_seats;
                label20.Text = a_seats.ToString();

                if (edit_status == "Uneditable" || b_status == "blocked")
                {
                    label32.Text = "This event has been made uneditable. Can not be edited";
                    comboBox1.Enabled = false;
                    checkBox1.Enabled = false;
                    checkBox2.Enabled = false;
                    iconButton9.Enabled = false;
                }


                if (park_sts == "No" && label28.Text != "None")
                {
                    label22.Text = "Food";
                    checkBox1.Enabled = false;
                    checkBox1.Text = "Not available";
                    label29.Text = "No parking facilities";
                    checkBox1.Location = new System.Drawing.Point(50, 131);
                    label37.Text = f_price.ToString();
                    label36.Visible = true;
                    label37.Visible = true;
                    label38.Visible = true;
                }
                else if (park_sts == "Yes" && label28.Text == "None")
                {
                    label22.Text = "Parking";
                    checkBox2.Enabled = false;
                    checkBox2.Text = "Not available";
                    checkBox2.Location = new System.Drawing.Point(50, 158);
                    label28.Text = "No food facilities";
                    label40.Text = p_price.ToString();
                    label39.Visible = true;
                    label40.Visible = true;
                    label41.Visible = true;
                }
                else if (park_sts == "Yes" && label28.Text != "None")
                {
                    label22.Text = "Food and Parking";
                    label37.Text = f_price.ToString();
                    label36.Visible = true;
                    label37.Visible = true;
                    label38.Visible = true;
                    label40.Text = p_price.ToString();
                    label39.Visible = true;
                    label40.Visible = true;
                    label41.Visible = true;
                }
                else if (park_sts == "No" && label28.Text == "None")
                {
                    label22.Text = "No extra facilities";
                    checkBox1.Enabled = false;
                    checkBox1.Text = "Not available";
                    checkBox1.Location = new System.Drawing.Point(50, 131);
                    checkBox2.Location = new System.Drawing.Point(50, 158);
                    checkBox2.Enabled = false;
                    checkBox2.Text = "Not available";
                    panel4.Visible = false;
                    iconButton7.Visible = false;
                    iconButton9.Visible = true;
                }

                if(f != 0)
                {
                    checkBox2.Checked = true;
                }
                else if(p != 0)
                {
                    checkBox1.Checked = true;
                }
                else if(f != 0 && p != 0)
                {
                    checkBox1.Checked= true;
                    checkBox2.Checked= true;
                }

                if(label24.Text == "None" && label25.Text == "None" && label26.Text == "None" && label27.Text == "None")
                {
                    panel3.Visible = false;
                    iconButton4.Visible = false;
                    iconButton12.Visible = true;

                }
                if(label22.Text == "No extra facilities")
                {
                    panel4.Visible= false;
                    iconButton11.Visible = true;
                    iconButton4.Visible = false;
                    iconButton12.Visible = false;  
                }

            }
            con.Close();
            

            con.Open();
            SqlCommand cmdg1 = new SqlCommand("select g2_image from event where eId =" + id, con);
            SqlDataReader cmdg1Dr = cmdg1.ExecuteReader();
            while (cmdg1Dr.Read())
            {
                long len1 = cmdg1Dr.GetBytes(0, 0, null, 0, 0);
                byte[] array1 = new byte[System.Convert.ToInt32(len1) + 1];
                cmdg1Dr.GetBytes(0, 0, array1, 0, System.Convert.ToInt32(len1));
                MemoryStream memoryStream1 = new MemoryStream(array1);
                Bitmap bitmap1 = new Bitmap(memoryStream1);
                pictureBox2.Image = bitmap1;
            }
            con.Close();

            con.Open();
            SqlCommand cmdg2 = new SqlCommand("select g3_image from event where eId =" + id, con);
            SqlDataReader cmdg2Dr = cmdg2.ExecuteReader();
            while (cmdg2Dr.Read())
            {
                long len2 = cmdg2Dr.GetBytes(0, 0, null, 0, 0);
                byte[] array2 = new byte[System.Convert.ToInt32(len2) + 1];
                cmdg2Dr.GetBytes(0, 0, array2, 0, System.Convert.ToInt32(len2));
                MemoryStream memoryStream2 = new MemoryStream(array2);
                Bitmap bitmap2 = new Bitmap(memoryStream2);
                pictureBox3.Image = bitmap2;
            }
            con.Close();

            con.Open();
            SqlCommand cmdg3 = new SqlCommand("select g4_image from event where eId =" + id, con);
            SqlDataReader cmdg3Dr = cmdg3.ExecuteReader();
            while (cmdg3Dr.Read())
            {
                long len3 = cmdg3Dr.GetBytes(0, 0, null, 0, 0);
                byte[] array3 = new byte[System.Convert.ToInt32(len3) + 1];
                cmdg3Dr.GetBytes(0, 0, array3, 0, System.Convert.ToInt32(len3));
                MemoryStream memoryStream3 = new MemoryStream(array3);
                Bitmap bitmap3 = new Bitmap(memoryStream3);
                pictureBox4.Image = bitmap3;
            }
            con.Close();

            con.Open();
            SqlCommand cmdi1 = new SqlCommand("select image1 from event where eId =" + id, con);
            SqlDataReader cmdi1Dr = cmdi1.ExecuteReader();
            while (cmdi1Dr.Read())
            {
                long len4 = cmdi1Dr.GetBytes(0, 0, null, 0, 0);
                byte[] array4 = new byte[System.Convert.ToInt32(len4) + 1];
                cmdi1Dr.GetBytes(0, 0, array4, 0, System.Convert.ToInt32(len4));
                MemoryStream memoryStream4 = new MemoryStream(array4);
                Bitmap bitmap4 = new Bitmap(memoryStream4);
                pictureBox5.Image = bitmap4;
            }
            con.Close();

            con.Open();
            SqlCommand cmdi2 = new SqlCommand("select image2 from event where eId =" + id, con);
            SqlDataReader cmdi2Dr = cmdi2.ExecuteReader();
            while (cmdi2Dr.Read())
            {
                long len5 = cmdi2Dr.GetBytes(0, 0, null, 0, 0);
                byte[] array5 = new byte[System.Convert.ToInt32(len5) + 1];
                cmdi2Dr.GetBytes(0, 0, array5, 0, System.Convert.ToInt32(len5));
                MemoryStream memoryStream5 = new MemoryStream(array5);
                Bitmap bitmap5 = new Bitmap(memoryStream5);
                pictureBox6.Image = bitmap5;
            }
            con.Close();

            this.Size = new System.Drawing.Size(905, 365);
            iconButton1.Visible = false;
            iconButton3.Visible = true;
            panel2.Visible = true;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel2.Dock = DockStyle.Fill;
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(297, 305);
            iconButton1.Visible = true;
            iconButton3.Visible = false;
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = true;
            panel4.Visible = false;
            panel5.Visible = false;
            panel3.Dock = DockStyle.Fill;
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = true;
            panel5.Visible = false;
            panel4.Dock = DockStyle.Fill;
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel2.Dock = DockStyle.Fill;
        }

        private void iconButton9_Click(object sender, EventArgs e)
        {
            int nOs = Convert.ToInt32(comboBox1.SelectedIndex) + 1;
            s_price = nOs * price;
            if (checkBox1.Checked && !checkBox2.Checked)
            {
                t_price = s_price + p_price;
            }
            if (!checkBox1.Checked && checkBox2.Checked)
            {
                t_price = s_price + (f_price * nOs);
            }
            if (checkBox1.Checked && checkBox2.Checked)
            {
                t_price = s_price + p_price + (f_price * nOs);
            }
            if (!checkBox1.Checked && !checkBox2.Checked)
            {
                t_price = s_price;
            }

            int userCount = 0;
            int previousPrice = 0;
            int newPrice = t_price;
            int balance = 0;
            con.Open();
            SqlCommand cCount = new SqlCommand("SELECT price FROM Register WHERE eId =" + id, con);
            SqlDataReader cdr1 = cCount.ExecuteReader();
            while (cdr1.Read())
            {
                previousPrice = Convert.ToInt32(cdr1["price"]);
            }
            con.Close();

            con.Open();
            SqlCommand co1 = new SqlCommand("SELECT balance FROM Appuser WHERE uId =" + SignInForm.ID, con);
            SqlDataReader d1 = co1.ExecuteReader();
            while (d1.Read())
            {
                balance = Convert.ToInt32(d1["balance"]);
            }
            con.Close();
            int updatedBalance = (balance + previousPrice) - newPrice;

            if (MessageBox.Show("Total bill is " + t_price + " BDT. Do you want to proceed?", "Register", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if(updatedBalance>=0)
                {
                    con.Open();
                    SqlCommand cmdg = new SqlCommand("update Register set f_price = @f_price, p_price = @p_price, s_price = @s_price, price = @price, nOs = @nOs where eId =" + id + "and uId =" + SignInForm.ID, con);
                    if (!checkBox1.Checked)
                    {
                        cmdg.Parameters.AddWithValue("@p_price", 0); ;
                    }
                    else
                    {
                        cmdg.Parameters.AddWithValue("@p_price", p_price);
                    }
                    if (!checkBox2.Checked)
                    {
                        cmdg.Parameters.AddWithValue("@f_price", 0); ;
                    }
                    else
                    {
                        cmdg.Parameters.AddWithValue("@f_price", f_price);
                    }
                    cmdg.Parameters.AddWithValue("@s_price", s_price);
                    cmdg.Parameters.AddWithValue("@price", t_price);
                    cmdg.Parameters.AddWithValue("@nOs", nOs);
                    cmdg.ExecuteNonQuery();
                    con.Close();
                    label34.Text = t_price.ToString();
                    con.Open();
                    SqlCommand uCount = new SqlCommand("SELECT nOs, price FROM Register WHERE eId =" + id, con);
                    SqlDataReader dr1 = uCount.ExecuteReader();
                    while (dr1.Read())
                    {
                        int nos = Convert.ToInt32(dr1["nOs"]);
                        userCount = userCount + nos;
                    }
                    con.Close();
                    if(userCount > capacity)
                    {
                        con.Open();
                        SqlCommand sqU = new SqlCommand("update Event set registerd_seats = @registerd_seats WHERE eId =" + id, con);
                        sqU.Parameters.AddWithValue("@registerd_seats", userCount);
                        sqU.ExecuteNonQuery();
                        con.Close();

                        con.Open();
                        SqlCommand sqUser = new SqlCommand("update AppUser set balance = @balance WHERE uId =" + SignInForm.ID, con);
                        sqUser.Parameters.AddWithValue("@balance", updatedBalance);
                        sqUser.ExecuteNonQuery();
                        con.Close();

                        MessageBox.Show("Event updated successfully", "Massage", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        this.Size = new System.Drawing.Size(297, 305);
                        iconButton3.Visible = false;
                        iconButton1.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("Not enough seats available", "Massage", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    }
                    
                }
                else
                {
                    MessageBox.Show("Insufficient balance", "Massage", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    this.Visible = false;
                } 
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton12_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = true;
            panel5.Visible = false;
            panel4.Dock = DockStyle.Fill;
            iconButton13.Visible = true;
            iconButton7.Visible = false;
        }

        private void iconButton13_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel2.Dock = DockStyle.Fill;
        }

        private void iconButton11_Click(object sender, EventArgs e)
        {
            panel5.Size = new System.Drawing.Size(233, 365);
            panel5.Visible = true;
        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to unregister this event ", "Massage", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                int total = 0;
                con.Open();
                SqlCommand cmd4 = new SqlCommand("Select price from Register where uId = " + SignInForm.ID + "and eId =" + id, con);
                SqlDataReader r1 = cmd4.ExecuteReader();
                while (r1.Read())
                {
                    total = Convert.ToInt32(r1["price"]);
                }
                con.Close();
                int balance = 0;
                con.Open();
                SqlCommand cmd3 = new SqlCommand("Select balance from AppUser where uId = " + SignInForm.ID, con);
                SqlDataReader r = cmd3.ExecuteReader();
                while (r.Read())
                {
                    balance = Convert.ToInt32(r["balance"]);
                }
                con.Close();

                int n=0;
                con.Open();
                SqlCommand cmd1 = new SqlCommand("Select nOs from Register where eId =" + id + "and uId =" + SignInForm.ID, con);
                SqlDataReader reader = cmd1.ExecuteReader();
                while(reader.Read())
                {
                    n = Convert.ToInt32(reader["nOs"]);
                }
                con.Close();

                int m=0;
                con.Open();
                SqlCommand cmd2 = new SqlCommand("Select registerd_seats from Event where eId =" + id, con);
                SqlDataReader reader1 = cmd2.ExecuteReader();
                while (reader1.Read())
                {
                    m = Convert.ToInt32(reader1["registerd_seats"]);
                }
                con.Close();

                int updated = m - n;
                con.Open();
                SqlCommand sqU = new SqlCommand("update Event set registerd_seats = @registerd_seats WHERE eId =" + id, con);
                sqU.Parameters.AddWithValue("@registerd_seats", updated);
                sqU.ExecuteNonQuery();
                con.Close();

                int updatedBalance = balance + total;
                con.Open();
                SqlCommand cmd5 = new SqlCommand("update AppUser set balance = @balance where uId =" + SignInForm.ID, con);
                cmd5.Parameters.AddWithValue("@balance", updatedBalance);
                cmd5.ExecuteNonQuery();
                con.Close();

                con.Open();
                SqlCommand cmd = new SqlCommand("Delete from Register where eId =" + id + "and uId =" + SignInForm.ID, con);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Event unregistered successfully", "Massage", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                this.Visible = false;
            }
        }

        private void iconButton10_Click(object sender, EventArgs e)
        {
            panel5.Size = new System.Drawing.Size(233, 363);
            panel5.Visible = true;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }


        private void iconButton7_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = true;
            panel4.Visible = false;
            panel5.Visible = false;
            panel3.Dock = DockStyle.Fill;
        }

        private void iconButton8_Click(object sender, EventArgs e)
        {
            panel5.Size = new System.Drawing.Size(10, 363);
            panel5.Visible = false;
        }
    }
}
