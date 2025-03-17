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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Eventify.ProjectForms
{
    public partial class EventList : UserControl
    {
        public EventList()
        {
            InitializeComponent();
        }
        SqlConnection con4 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Codings\C# Project\Eventify\Database\EVENTIFY.mdf"";Integrated Security=True;Connect Timeout=30");

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void EventList_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(905, 133);

            string ubSts = "";
            con4.Open();
            SqlCommand cmd11 = new SqlCommand("Select block_status from AppUser where uId = " + SignInForm.ID, con4);
            SqlDataReader sqlDataReader11 = cmd11.ExecuteReader();
            if (sqlDataReader11.Read())
            {
                ubSts = sqlDataReader11["block_status"].ToString();
            }
            con4.Close();

            if (ubSts == "blocked")
            {
                iconButton1.Visible = false;
                iconButton3.Visible = false;
                label35.Visible = true;
            }
            else
            {
                string bSts = "";
                con4.Open();
                SqlCommand cmd = new SqlCommand("Select block_status from Event where eId = " + eid, con4);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    bSts = sqlDataReader["block_status"].ToString();
                }
                con4.Close();

                if (bSts == "Blocked")
                {
                    iconButton1.Visible = false;
                    iconButton2.Visible = false;
                    iconButton3.Visible = false;
                    label34.Visible = true;
                }
            }
        }
        public int eid;
        string title;
        string category;
        string date;
        string venue;
        private Bitmap pic;
        string bstatus;

        [Category("Custom Props")]
        public int ID
        { get { return eid; } set { eid = value; } }

        [Category("Custom Props")]
        public string TITLE
        { get { return title; } set { title = value; label1.Text = value; } }

        [Category("Custom Props")]
        public string CATEGORY
        { get { return category; } set { category = value; label2.Text = value; } }

        [Category("Custom Props")]
        public string DATE
        { get { return date; } set { date = value; label3.Text = value; } }

        [Category("Custom Props")]
        public string VENUE
        { get { return venue; } set { venue = value; label4.Text = value; } }

        [Category("Custom Props")]
        public Bitmap IMAGE
        { get { return pic; } set { pic = value; pictureBox1.Image = value; } }

        [Category("Custom Props")]
        public string BSTATUS
        { get { return bstatus; } set { bstatus = value; } }

        private Form currentForm;
        private void iconButton1_Click(object sender, EventArgs e)
        {
            con4.Open();
            
            SqlCommand sel = new SqlCommand("Select g1_image, g2_image, g3_image, g4_image, image1, image2, title, category, capacity, price, venue, date, time, duration, block_status, description, organizer, guest1, guest2, guest3, guest4, display, food, food_price, parking, park_sts, registerd_seats, city from event where eid = " + eid, con4);
            SqlDataReader r1 = sel.ExecuteReader();
            while (r1.Read())
            {
                textBox1.Text = r1["title"].ToString();
                textBox2.Text = r1["category"].ToString();
                textBox5.Text = r1["venue"].ToString();
                textBox3.Text = r1["capacity"].ToString();
                textBox4.Text = r1["price"].ToString();
                textBox6.Text = r1["duration"].ToString();
                textBox7.Text = r1["city"].ToString();
                richTextBox1.Text = r1["description"].ToString();
                bstatus = r1["block_status"].ToString();
                dateTimePicker1.Text = r1["date"].ToString();
                dateTimePicker2.Text = r1["time"].ToString();

            }
            con4.Close();

            this.Size = new System.Drawing.Size(905, 570);
            iconButton1.Visible = false;
            iconButton2.Visible = true;
            panel3.Dock = DockStyle.Fill;
            panel3.Visible = true;
            panel4.Visible = false;
            panel5.Visible = false;
            if(bstatus == "Blocked" || bstatus == "Can't edit")
            {
                iconButton6.Enabled = false;
                label32.Visible = true;
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            iconButton2.Visible = false;
            iconButton1.Visible=true;
            this.Size = new System.Drawing.Size(905, 133);
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deleted events can't be recovered. Are you sure to delete this event?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                SqlConnection dCon11 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Codings\C# Project\Eventify\Database\EVENTIFY.mdf"";Integrated Security=True;Connect Timeout=30");
                dCon11.Open();
                SqlCommand cmd11 = new SqlCommand("delete from Event where eId = " +eid, dCon11);
                cmd11.ExecuteNonQuery();
                dCon11.Close();
                MessageBox.Show("Event deleted successfully");
                this.Visible = false;
                label1.Visible = true;
            }
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            con4.Open();

            SqlCommand sel = new SqlCommand("Select g1_image, g2_image, g3_image, g4_image, image1, image2, title, category, capacity, price, venue, date, time, duration, description, organizer, guest1, guest2, guest3, guest4, display, food, food_price, parking, park_sts, registerd_seats, edit_status from event where eid = " + eid, con4);
            SqlDataReader r1 = sel.ExecuteReader();
            while (r1.Read())
            {

                long len = r1.GetBytes(0, 0, null, 0, 0);
                byte[] array = new byte[System.Convert.ToInt32(len) + 1];
                r1.GetBytes(0, 0, array, 0, System.Convert.ToInt32(len));
                MemoryStream memoryStream = new MemoryStream(array);
                Bitmap bitmap = new Bitmap(memoryStream);

                textBox8.Text = r1["food"].ToString();
                textBox9.Text = r1["food_price"].ToString();
                textBox10.Text = r1["parking"].ToString();
                if (r1["park_sts"].ToString() == "Yes")
                {
                    checkBox1.Checked = true;
                }
                else
                {
                    checkBox1.Checked = false;
                }
                if (r1["edit_status"].ToString() == "Editable")
                {
                    checkBox2.Checked = false;
                }
                else
                {
                    checkBox2.Checked = true;
                }
                textBox12.Text = r1["guest1"].ToString();
                textBox13.Text = r1["guest2"].ToString();
                textBox14.Text = r1["guest3"].ToString();
                textBox15.Text = r1["guest4"].ToString();
                dateTimePicker1.Text = r1["date"].ToString();
                dateTimePicker2.Text = r1["time"].ToString();
                iconPictureBox4.Image = bitmap;

            }
            con4.Close();
            con4.Open();
            SqlCommand cmdg1 = new SqlCommand("select g2_image from event where eId =" + eid, con4);
            SqlDataReader cmdg1Dr = cmdg1.ExecuteReader();
            while (cmdg1Dr.Read())
            {
                long len1 = cmdg1Dr.GetBytes(0, 0, null, 0, 0);
                byte[] array1 = new byte[System.Convert.ToInt32(len1) + 1];
                cmdg1Dr.GetBytes(0, 0, array1, 0, System.Convert.ToInt32(len1));
                MemoryStream memoryStream1 = new MemoryStream(array1);
                Bitmap bitmap1 = new Bitmap(memoryStream1);
                iconPictureBox5.Image = bitmap1;
            }
            con4.Close();

            con4.Open();
            SqlCommand cmdg2 = new SqlCommand("select g3_image from event where eId =" + eid, con4);
            SqlDataReader cmdg2Dr = cmdg2.ExecuteReader();
            while (cmdg2Dr.Read())
            {
                long len2 = cmdg2Dr.GetBytes(0, 0, null, 0, 0);
                byte[] array2 = new byte[System.Convert.ToInt32(len2) + 1];
                cmdg2Dr.GetBytes(0, 0, array2, 0, System.Convert.ToInt32(len2));
                MemoryStream memoryStream2 = new MemoryStream(array2);
                Bitmap bitmap2 = new Bitmap(memoryStream2);
                iconPictureBox6.Image = bitmap2;
            }
            con4.Close();

            con4.Open();
            SqlCommand cmdg3 = new SqlCommand("select g4_image from event where eId =" + eid, con4);
            SqlDataReader cmdg3Dr = cmdg3.ExecuteReader();
            while (cmdg3Dr.Read())
            {
                long len3 = cmdg3Dr.GetBytes(0, 0, null, 0, 0);
                byte[] array3 = new byte[System.Convert.ToInt32(len3) + 1];
                cmdg3Dr.GetBytes(0, 0, array3, 0, System.Convert.ToInt32(len3));
                MemoryStream memoryStream3 = new MemoryStream(array3);
                Bitmap bitmap3 = new Bitmap(memoryStream3);
                iconPictureBox7.Image = bitmap3;
            }
            con4.Close();

            con4.Open();
            SqlCommand cmdi1 = new SqlCommand("select image1 from event where eId =" + eid, con4);
            SqlDataReader cmdi1Dr = cmdi1.ExecuteReader();
            while (cmdi1Dr.Read())
            {
                long len4 = cmdi1Dr.GetBytes(0, 0, null, 0, 0);
                byte[] array4 = new byte[System.Convert.ToInt32(len4) + 1];
                cmdi1Dr.GetBytes(0, 0, array4, 0, System.Convert.ToInt32(len4));
                MemoryStream memoryStream4 = new MemoryStream(array4);
                Bitmap bitmap4 = new Bitmap(memoryStream4);
                iconPictureBox1.Image = bitmap4;
            }
            con4.Close();

            con4.Open();
            SqlCommand cmdi2 = new SqlCommand("select image2 from event where eId =" + eid, con4);
            SqlDataReader cmdi2Dr = cmdi2.ExecuteReader();
            while (cmdi2Dr.Read())
            {
                long len5 = cmdi2Dr.GetBytes(0, 0, null, 0, 0);
                byte[] array5 = new byte[System.Convert.ToInt32(len5) + 1];
                cmdi2Dr.GetBytes(0, 0, array5, 0, System.Convert.ToInt32(len5));
                MemoryStream memoryStream5 = new MemoryStream(array5);
                Bitmap bitmap5 = new Bitmap(memoryStream5);
                iconPictureBox2.Image = bitmap5;
            }
            con4.Close();

            con4.Open();
            SqlCommand cDisp = new SqlCommand("select display from event where eId =" + eid, con4);
            SqlDataReader cDispr = cDisp.ExecuteReader();
            while (cDispr.Read())
            {
                long len5 = cDispr.GetBytes(0, 0, null, 0, 0);
                byte[] array5 = new byte[System.Convert.ToInt32(len5) + 1];
                cDispr.GetBytes(0, 0, array5, 0, System.Convert.ToInt32(len5));
                MemoryStream memoryStream5 = new MemoryStream(array5);
                Bitmap bitmap5 = new Bitmap(memoryStream5);
                iconPictureBox3.Image = bitmap5;
            }
            con4.Close();
            panel4.Dock = DockStyle.Fill;
            panel4.Visible = true;
            panel3.Visible = false;
            panel5.Visible = false;
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            panel5.Dock = DockStyle.Fill;
            panel5.Visible = true;
            panel3.Visible = false;
            panel4.Visible = false;
        }

        private void iconButton7_Click(object sender, EventArgs e)
        {
            panel3.Dock = DockStyle.Fill;
            panel3.Visible = true;
            panel4.Visible = false;
            panel5.Visible = false;
        }

        private void iconButton8_Click(object sender, EventArgs e)
        {
            panel4.Dock = DockStyle.Fill;
            panel4.Visible = true;
            panel3.Visible = false;
            panel5.Visible = false;
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text) || string.IsNullOrEmpty(textBox6.Text) || string.IsNullOrEmpty(textBox12.Text) || string.IsNullOrEmpty(textBox13.Text) || string.IsNullOrEmpty(textBox14.Text) || string.IsNullOrEmpty(textBox15.Text) && string.IsNullOrEmpty(richTextBox1.Text))
            { 
                MessageBox.Show("Please fill up all the information", "Massage", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (dateTimePicker1.Value.ToString() == DateTime.Today.ToString())
                {
                    MessageBox.Show("Evant can not be created for today", "Massage", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Codings\C# Project\Eventify\Database\EVENTIFY.mdf"";Integrated Security=True;Connect Timeout=30");
                    con1.Open();
                    SqlCommand sq1 = new SqlCommand("Update Event set title = @title, category = @category, capacity = @capacity, price = @price, venue = @venue, date = @date, time = @time, duration = @duration, description = @description, image1 = @image1, image2 = @image2, organizer = @organizer, guest1 = @guest1, guest2 = @guest2, guest3 = @guest3, guest4 = @guest4, g1_image = @g1_image, g2_image = @g2_image, g3_image = @g3_image, g4_image = @g4_image, display = @display, food = @food, food_price = @food_price, parking = @parking, park_sts = @park_sts, creation_date = @creation_date, edit_status = @edit_status, @city = city where eId =" + eid, con1);
                    sq1.Parameters.AddWithValue("@title", textBox1.Text);
                    sq1.Parameters.AddWithValue("@category", textBox2.Text);
                    sq1.Parameters.AddWithValue("@capacity", textBox3.Text);
                    sq1.Parameters.AddWithValue("@price", int.Parse(textBox4.Text));
                    sq1.Parameters.AddWithValue("@venue", textBox5.Text);
                    sq1.Parameters.AddWithValue("@description", richTextBox1.Text);
                    sq1.Parameters.AddWithValue("@date", dateTimePicker1.Text);
                    sq1.Parameters.AddWithValue("@time", dateTimePicker2.Text);
                    sq1.Parameters.AddWithValue("@duration", textBox6.Text);
                    sq1.Parameters.AddWithValue("@city", textBox7.Text);
                    sq1.Parameters.AddWithValue("@food", textBox8.Text);
                    sq1.Parameters.AddWithValue("@food_price", int.Parse(textBox9.Text));
                    sq1.Parameters.AddWithValue("@parking", int.Parse(textBox10.Text));
                    sq1.Parameters.AddWithValue("@image1", getImage1());
                    sq1.Parameters.AddWithValue("@image2", getImage2());
                    sq1.Parameters.AddWithValue("@guest1", textBox12.Text);
                    sq1.Parameters.AddWithValue("@guest2", textBox13.Text);
                    sq1.Parameters.AddWithValue("@guest3", textBox14.Text);
                    sq1.Parameters.AddWithValue("@guest4", textBox15.Text);
                    sq1.Parameters.AddWithValue("@g1_image", getImage4());
                    sq1.Parameters.AddWithValue("@g2_image", getImage5());
                    sq1.Parameters.AddWithValue("@g3_image", getImage6());
                    sq1.Parameters.AddWithValue("@g4_image", getImage7());
                    sq1.Parameters.AddWithValue("@display", getImage3());
                    sq1.Parameters.AddWithValue("@organizer", SignInForm.USERNAME);
                    sq1.Parameters.AddWithValue("@creation_date", DateTime.Today.ToString());
                    if (checkBox1.Checked)
                    {
                        sq1.Parameters.AddWithValue("@park_sts", "Yes");
                    }
                    if (!checkBox1.Checked)
                    {
                        sq1.Parameters.AddWithValue("@park_sts", "No");
                    }
                    if (!checkBox2.Checked)
                    {
                        sq1.Parameters.AddWithValue("@edit_status", "Editable");
                    }
                    if (checkBox2.Checked)
                    {
                        sq1.Parameters.AddWithValue("@edit_status", "Uneditable");
                    }
                    sq1.ExecuteNonQuery();

                    con1.Close();

                    MessageBox.Show("Event updated successfully", "Massage", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Size = new System.Drawing.Size(905, 133);
                    iconButton2.Visible = false;
                    iconButton1.Visible = true;
                }

            }
        }

        private byte[] getImage1()
        {
            MemoryStream stream1 = new MemoryStream();
            iconPictureBox1.Image.Save(stream1, iconPictureBox1.Image.RawFormat);
            return stream1.GetBuffer();
        }
        private byte[] getImage2()
        {
            MemoryStream stream2 = new MemoryStream();
            iconPictureBox2.Image.Save(stream2, iconPictureBox2.Image.RawFormat);
            return stream2.GetBuffer();
        }
        private byte[] getImage3()
        {
            MemoryStream stream3 = new MemoryStream();
            iconPictureBox3.Image.Save(stream3, iconPictureBox3.Image.RawFormat);
            return stream3.GetBuffer();
        }

        private byte[] getImage4()
        {
            MemoryStream stream4 = new MemoryStream();
            iconPictureBox4.Image.Save(stream4, iconPictureBox4.Image.RawFormat);
            return stream4.GetBuffer();
        }
        private byte[] getImage5()
        {
            MemoryStream stream5 = new MemoryStream();
            iconPictureBox5.Image.Save(stream5, iconPictureBox5.Image.RawFormat);
            return stream5.GetBuffer();
        }
        private byte[] getImage6()
        {
            MemoryStream stream6 = new MemoryStream();
            iconPictureBox6.Image.Save(stream6, iconPictureBox6.Image.RawFormat);
            return stream6.GetBuffer();
        }
        private byte[] getImage7()
        {
            MemoryStream stream7 = new MemoryStream();
            iconPictureBox7.Image.Save(stream7, iconPictureBox7.Image.RawFormat);
            return stream7.GetBuffer();
        }
        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*.*)|*.*";
            string imageLocation1 = "";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                imageLocation1 = openFileDialog1.FileName;
                iconPictureBox1.ImageLocation = imageLocation1;
            }
        }
        private void iconPictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog2 = new OpenFileDialog();
            openFileDialog2.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*.*)|*.*";
            string imageLocation2 = "";
            if (openFileDialog2.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                imageLocation2 = openFileDialog2.FileName;
                iconPictureBox2.ImageLocation = imageLocation2;
            }
        }

        private void iconPictureBox4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog4 = new OpenFileDialog();
            openFileDialog4.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*.*)|*.*";
            string imageLocation4 = "";
            if (openFileDialog4.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                imageLocation4 = openFileDialog4.FileName;
                iconPictureBox4.ImageLocation = imageLocation4;
            }
        }

        private void iconPictureBox3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog3 = new OpenFileDialog();
            openFileDialog3.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*.*)|*.*";
            string imageLocation3 = "";
            if (openFileDialog3.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                imageLocation3 = openFileDialog3.FileName;
                iconPictureBox3.ImageLocation = imageLocation3;
            }
        }

        private void iconPictureBox5_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog5 = new OpenFileDialog();
            openFileDialog5.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*.*)|*.*";
            string imageLocation5 = "";
            if (openFileDialog5.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                imageLocation5 = openFileDialog5.FileName;
                iconPictureBox5.ImageLocation = imageLocation5;
            }
        }

        private void iconPictureBox6_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog6 = new OpenFileDialog();
            openFileDialog6.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*.*)|*.*";
            string imageLocation6 = "";
            if (openFileDialog6.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                imageLocation6 = openFileDialog6.FileName;
                iconPictureBox6.ImageLocation = imageLocation6;
            }
        }

        private void iconPictureBox7_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog7 = new OpenFileDialog();
            openFileDialog7.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*.*)|*.*";
            string imageLocation7 = "";
            if (openFileDialog7.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                imageLocation7 = openFileDialog7.FileName;
                iconPictureBox7.ImageLocation = imageLocation7;
            }
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
            this.panel3.Controls.Add(newForm);
            newForm.BringToFront();
            newForm.Show();
        }
        private void iconButton9_Click(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(905, 570);
            openForm(new ProjectForms.RegisteredUsers(eid));
        }
    }
}
