using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eventify.ProjectForms
{
    public partial class HistoryList : UserControl
    {
        public HistoryList()
        {
            InitializeComponent();
        }

        private void HistoryList_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(905, 133);
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
        private string e_status; //
        private int food_price;
        private int parking;

        int en;
        [Category("Custom Props")]
        public int EN
        { get { return en; } set { en = value; } }

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
        public string VENUE1
        { get { return venue1; } set { venue1 = value; label4.Text = value; } }
        public string ESTATUS
        { get { return e_status; } set { e_status = value; } }

        [Category("Custom Props")]
        public Bitmap DISPLAY
        { get { return pic1; } set { pic1 = value; pictureBox1.Image = value; } }

        SqlConnection con4 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Codings\C# Project\Eventify\Database\EVENTIFY.mdf"";Integrated Security=True;Connect Timeout=30");
        int f_price, s_price, p_price, t_price;

        private void iconButton4_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = true;
            panel3.Dock = DockStyle.Fill;
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel2.Visible = true;
            panel2.Dock = DockStyle.Fill;
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            if(en == 1)
            {
                label30.Visible = true;
                label31.Visible = true;
                label32.Visible = true;
                label33.Visible = true;
                label34.Visible = true;
                label35.Visible = true;
                label36.Visible = true;
                label37.Visible = true;
                label38.Visible = true;
                label39.Visible = true;
                con4.Open();
                SqlCommand cc = new SqlCommand("Select * from Register Where eId = " + id + " and uId = " + SignInForm.ID, con4);
                SqlDataReader r = cc.ExecuteReader();
                while (r.Read())
                {
                    label37.Text = r["nOs"].ToString();
                    label36.Text = r["f_price"].ToString();
                    label35.Text = r["p_price"].ToString();
                    label34.Text = r["price"].ToString();
                    label38.Text = r["reg_date"].ToString();
                }
                con4.Close();
            }
            con4.Open();
            SqlCommand sel = new SqlCommand("Select g1_image, g2_image, g3_image, g4_image, image1, image2, title, category, capacity, price, venue, date, time, duration, description, organizer, guest1, guest2, guest3, guest4, display, food, food_price, parking, park_sts, registerd_seats, creation_date from event where eid = " + id, con4);
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
                label27.Text = bDr["organizer"].ToString();
                label15.Text = bDr["description"].ToString();
                label22.Text = bDr["guest1"].ToString();
                label23.Text = bDr["guest2"].ToString();
                label24.Text = bDr["guest3"].ToString();
                label25.Text = bDr["guest4"].ToString();
                label29.Text = bDr["food"].ToString();
                label40.Text = bDr["creation_date"].ToString();
                f_price = Convert.ToInt32(bDr["food_price"]);
                p_price = Convert.ToInt32(bDr["parking"]);
                price = Convert.ToInt32(bDr["price"]);
                string park_sts = bDr["park_sts"].ToString();
                pictureBox2.Image = bitmap;

                int r_seats = Convert.ToInt32(bDr["registerd_seats"]);
                int a_seats = Convert.ToInt32(label19.Text) - r_seats;
                label20.Text = a_seats.ToString();

                if (park_sts == "No" && label29.Text != "None")
                {
                    label26.Text = "Food";                                                              
                    label28.Text = "No parking facilities";
                    fPrice.Text = f_price.ToString();
                    fPrice.Visible = true;
                    labelBDT.Visible = true;
                }
                else if (park_sts == "Yes" && label29.Text == "None")
                {
                    label26.Text = "Parking";
                    label29.Text = "No food facilities";
                    pPrice.Text = p_price.ToString();
                    pPrice.Visible = true;
                    labelBDT1.Visible = true;
                }
                else if (park_sts == "Yes" && label29.Text != "None")
                {
                    label26.Text = "Food and Parking";
                    pPrice.Text = p_price.ToString();
                    pPrice.Visible = true;
                    fPrice.Text = f_price.ToString();
                    fPrice.Visible = true;
                    labelBDT.Visible = true;
                    labelBDT1.Visible = true;
                }
                else if (park_sts == "No" && label29.Text == "None")
                {
                    label26.Text = "No extra facilities";
                    label28.Text = "No parking facilities";
                }
            }
            con4.Close();
            con4.Open();
            SqlCommand cmdg1 = new SqlCommand("select g2_image from event where eId =" + id, con4);
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
            con4.Close();

            con4.Open();
            SqlCommand cmdg2 = new SqlCommand("select g3_image from event where eId =" + id, con4);
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
            con4.Close();

            con4.Open();
            SqlCommand cmdg3 = new SqlCommand("select g4_image from event where eId =" + id, con4);
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
            con4.Close();

            con4.Open();
            SqlCommand cmdi1 = new SqlCommand("select image1 from event where eId =" + id, con4);
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
            con4.Close();

            con4.Open();
            SqlCommand cmdi2 = new SqlCommand("select image2 from event where eId =" + id, con4);
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
            con4.Close();

            this.Size = new System.Drawing.Size(905, 570);
            panel2.Visible = true;
            panel3.Visible = false;
            panel2.Dock = DockStyle.Fill;
            iconButton2.Visible = false;
            iconButton3.Visible = true;
        }
        private void iconButton3_Click(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(905, 133);
            iconButton2.Visible = true;
            iconButton3.Visible = false;
        }
    }
}
