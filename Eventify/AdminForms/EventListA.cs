using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eventify.AdminForms
{
    public partial class EventListA : UserControl
    {
        public EventListA()
        {
            InitializeComponent();
        }
        string title1;//
        string category1;//
        string date1;//
        string e_status;//
        string b_status;//
        private Bitmap pic1;//
        int id;//

        [Category("Custom Props")]
        public int ID
        { get { return id; } set { id = value; } }

        [Category("Custom Props")]
        public string TITLE1
        { get { return title1; } set { title1 = value; label1.Text = value; } }

        [Category("Custom Props")]
        public string CATEGORY1
        { get { return category1; } set { category1 = value; label2.Text = value; } }

        [Category("Custom Props")]
        public string DATE1
        { get { return date1; } set { date1 = value; label3.Text = value; } }

        [Category("Custom Props")]
        public string ESTATUS
        { get { return e_status; } set { e_status = value; } }
        [Category("Custom Props")]
        public string BSTATUS
        { get { return b_status; } set { b_status = value; } }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Codings\C# Project\Eventify\Database\EVENTIFY.mdf"";Integrated Security=True;Connect Timeout=30");

        private void EventListA_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(905, 81);
            if(b_status == "Blocked")
            {
                int adID = 0;
                string admin = "";
                con.Open();
                SqlCommand sqlCommand1 = new SqlCommand("Select aId from Event where eId =" + id, con);
                SqlDataReader reader1 = sqlCommand1.ExecuteReader();
                if (reader1.Read())
                {
                    adID = Convert.ToInt32(reader1["aId"]);
                }
                con.Close();

                if(adID != 0)
                {
                    con.Open();
                    SqlCommand sqlCommand2 = new SqlCommand("Select name from Admin where aId =" + adID, con);
                    SqlDataReader reader2 = sqlCommand2.ExecuteReader();
                    if (reader2.Read())
                    {
                        admin = reader2["name"].ToString();
                    }
                    con.Close();

                }
                label3.Text = admin.Remove(0, 3);
                iconButton5.Visible = false;
                iconButton6.Visible = true;
                label8.Text = "Seized by "+ admin.Remove(0, 3); ;
            }
            else
            {
                iconButton5.Visible = true;
                iconButton6.Visible = false;
                label8.Text = "Unseized";
            }
        }

        int f_price, p_price, price;
        private void iconButton1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd1 = new SqlCommand("Select g1_image, g2_image, g3_image, g4_image, image1, image2, title, category, capacity, price, venue, date, time, duration, description, organizer, guest1, guest2, guest3, guest4, display, food, food_price, parking, park_sts, registerd_seats, city from event where eid = " + id, con);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            while(dr1.Read())
            {
                long len = dr1.GetBytes(0, 0, null, 0, 0);
                byte[] array = new byte[System.Convert.ToInt32(len) + 1];
                dr1.GetBytes(0, 0, array, 0, System.Convert.ToInt32(len));
                MemoryStream memoryStream = new MemoryStream(array);
                Bitmap bitmap = new Bitmap(memoryStream);

                label30.Text = dr1["venue"].ToString() + ", "+ dr1["city"].ToString();
                label31.Text = dr1["time"].ToString();
                label32.Text = dr1["duration"].ToString();
                label33.Text = dr1["capacity"].ToString();
                label34.Text = dr1["registerd_seats"].ToString();
                label35.Text = dr1["price"].ToString();
                label37.Text = dr1["organizer"].ToString();
                label22.Text = dr1["guest1"].ToString();
                label23.Text = dr1["guest2"].ToString();
                label24.Text = dr1["guest3"].ToString();
                label25.Text = dr1["guest4"].ToString();
                fPrice.Text = dr1["food_price"].ToString();
                pPrice.Text = dr1["parking"].ToString();
                string park_sts = dr1["park_sts"].ToString();
                pictureBox2.Image = bitmap;

                if (park_sts == "No" && label20.Text != "None")
                {
                    label36.Text = "Food";
                }
                else if (park_sts == "Yes" && label20.Text == "None")
                {
                    label36.Text = "Parking";
                }
                else if (park_sts == "Yes" && label20.Text != "None")
                {
                    label36.Text = "Food and Parking";

                }
                else if (park_sts == "No" && label20.Text == "None")
                {
                    label36.Text = "No extra facilities";
                    
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
                pictureBox3.Image = bitmap1;
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
                pictureBox4.Image = bitmap2;
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
                pictureBox5.Image = bitmap3;
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
                pictureBox6.Image = bitmap4;
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
                pictureBox7.Image = bitmap5;
            }
            con.Close();

            con.Open();
            SqlCommand cmdD = new SqlCommand("select display from event where eId =" + id, con);
            SqlDataReader cDr = cmdD.ExecuteReader();
            while (cDr.Read())
            {
                long len6 = cDr.GetBytes(0, 0, null, 0, 0);
                byte[] array6 = new byte[System.Convert.ToInt32(len6) + 1];
                cDr.GetBytes(0, 0, array6, 0, System.Convert.ToInt32(len6));
                MemoryStream memoryStream6 = new MemoryStream(array6);
                Bitmap bitmap6 = new Bitmap(memoryStream6);
                pictureBox1.Image = bitmap6;
            }
            con.Close();

            this.Size = new System.Drawing.Size(905, 467);
            iconButton2.Visible = true;
            iconButton1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
            panel2.Dock = DockStyle.Fill;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(905, 81);
            iconButton1.Visible = true;
            iconButton2.Visible = false;
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand sqlCommand = new SqlCommand("Update Event set block_status = @block_status where eId =" +id, con);
            sqlCommand.Parameters.AddWithValue("@block_status", "Blocked");
            sqlCommand.ExecuteNonQuery();
            con.Close();

            con.Open();
            SqlCommand sqlCommand1 = new SqlCommand("Update Event set aId = @aId where eId =" + id, con);
            sqlCommand1.Parameters.AddWithValue("@aId", SignInForm.AID);
            sqlCommand1.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("This event has been seized.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            iconButton5.Visible = false;
            iconButton6.Visible = true;
            label8.Text = "Seized";
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand sqlCommand = new SqlCommand("Update Event set block_status = @block_status where eId =" + id, con);
            sqlCommand.Parameters.AddWithValue("@block_status", "Unblocked");
            sqlCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("This event has been unseized.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            iconButton5.Visible = true;
            iconButton6.Visible = false;
            label8.Text = "Unseized";
            con.Open();
            SqlCommand sqlCommand1 = new SqlCommand("Update Event set aId = @aId where eId =" + id, con);
            sqlCommand1.Parameters.AddWithValue("@aId", 0);
            sqlCommand1.ExecuteNonQuery();
            con.Close();
        }

        private Form currentForm1;
        private void openForm(Form newForm)
        {
            if (currentForm1 != null)
            {
                currentForm1.Close();
            }
            currentForm1 = newForm;
            currentForm1.TopLevel = false;
            currentForm1.FormBorderStyle = FormBorderStyle.None;
            currentForm1.Dock = DockStyle.Fill;
            this.panel2.Controls.Add(newForm);
            newForm.BringToFront();
            newForm.Show();
        }
        private void iconButton9_Click(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(905, 467);
            openForm(new ProjectForms.RegisteredUsers(id));
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = true;
            panel3.Dock = DockStyle.Fill;
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel3.Visible = false;
            panel2.Dock = DockStyle.Fill;
        }
    }
}
