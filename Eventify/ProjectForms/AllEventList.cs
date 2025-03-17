using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.TextFormatting;

namespace Eventify.ProjectForms
{
    public partial class AllEventList : UserControl
    {
        public AllEventList()
        {
            InitializeComponent();
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
        private int nos;
        private int rs;



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
        { get { return date1; } set { venue1 = value; label4.Text = value; } }

        [Category("Custom Props")]
        public string ESTATUS
        { get { return e_status; } set { e_status = value; } }

        [Category("Custom Props")]
        public int NOS
        { get { return nos; } set { nos = value; } }
        public int RS
        { get { return rs; } set { rs = value; } }

        [Category("Custom Props")]
        public Bitmap DISPLAY
        { get { return pic1; } set { pic1 = value; pictureBox1.Image = value; } }
        
        SqlConnection con4 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Codings\C# Project\Eventify\Database\EVENTIFY.mdf"";Integrated Security=True;Connect Timeout=30");
        int f_price, s_price, p_price, t_price;
        private void AllEventList_Load(object sender, EventArgs e)
        {
            string bSts = "";
            con4.Open();
            SqlCommand cmd = new SqlCommand("Select block_status from AppUser where uId = " + SignInForm.ID, con4);
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            if (sqlDataReader.Read())
            {
                bSts = sqlDataReader["block_status"].ToString();
            }
            con4.Close();

            if(bSts == "blocked")
            {
                iconButton1.Visible = false;
                iconButton3.Visible = false;
                label34.Visible = true;
            }
            else
            {
                this.Size = new System.Drawing.Size(905, 133);
                //panel3.Visible = true;
                //panel4.Visible = false;
                //panel3.Dock = DockStyle.Fill;
                if (nos == rs)
                {
                    label19.Visible = true;
                }

                int[] regE = new int[500];
                int i = 0;
                con4.Open();
                SqlCommand selE = new SqlCommand("select eId from Register where uId = " + SignInForm.ID, con4);
                SqlDataReader dr1 = selE.ExecuteReader();
                while (dr1.Read())
                {
                    regE[i++] = Convert.ToInt32(dr1["eId"]); ;
                }
                con4.Close();
                foreach (int eid in regE)
                {
                    if (eid == id)
                    {
                        iconButton1.Visible = false;
                        iconButton3.Visible = false;
                        label18.Visible = true;
                    }
                }

                int[] org = new int[500];
                int j = 0;
                con4.Open();
                SqlCommand selO = new SqlCommand("select eId from Organize where uId = " + SignInForm.ID, con4);
                SqlDataReader dr2 = selO.ExecuteReader();
                while (dr2.Read())
                {
                    org[j++] = Convert.ToInt32(dr2["eId"]); ;
                }
                con4.Close();
                foreach (int eid in org)
                {
                    if (eid == id)
                    {
                        iconButton1.Visible = false;
                        iconButton3.Visible = false;
                        label18.Visible = true;
                        label18.Text = "Your Event";
                    }
                }
            }
        }
        private void iconButton2_Click(object sender, EventArgs e)
        {
            /*
            con4.Open();
            SqlCommand sq4 = new SqlCommand("insert into Register(uId ,eId) values(@uId, @eId)", con4);
            sq4.Parameters.AddWithValue("@uId", SignInForm.ID);
            sq4.Parameters.AddWithValue("@eId", id);

            sq4.ExecuteNonQuery();
            con4.Close();

            MessageBox.Show("Event registered");
            */
        }

        static int total;
        static int users;
        static int parkingPrice;
        static int foodPrice;
        static int seatPrice;
        static int numberOfSeats;
        static int userID;
        static int eventID;
        public static int TOTAL
        { get { return total; } }
        public static int USERS
        { get { return users; } }
        public static int ParkingPrice
        { get { return parkingPrice; } }
        public static int FoodPrice
        { get { return foodPrice; } }
        public static int SeatPrice
        { get { return seatPrice; } }
        public static int NumberOfSeats
        { get { return numberOfSeats; } }
        public static int UserID
        { get { return userID; } }
        public static int EventID
        { get { return eventID; } }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            con4.Open();
            SqlCommand sel = new SqlCommand("Select g1_image, g2_image, g3_image, g4_image, image1, image2, title, category, capacity, price, venue, date, time, duration, description, organizer, guest1, guest2, guest3, guest4, display, food, food_price, parking, park_sts, registerd_seats from event where eid = " + id, con4);
            SqlDataReader bDr = sel.ExecuteReader();
            while (bDr.Read())
            {

                long len = bDr.GetBytes(0, 0, null, 0, 0);
                byte[] array = new byte[System.Convert.ToInt32(len) + 1];
                bDr.GetBytes(0, 0, array, 0, System.Convert.ToInt32(len));
                MemoryStream memoryStream = new MemoryStream(array);
                Bitmap bitmap = new Bitmap(memoryStream);

                label4.Text = bDr["venue"].ToString();
                label31.Text = bDr["time"].ToString();
                label30.Text = bDr["duration"].ToString();
                label29.Text = bDr["capacity"].ToString();
                capacity = Convert.ToInt32(bDr["capacity"]);
                //label28.Text = bDr["title"].ToString();
                label27.Text = bDr["price"].ToString();
                label32.Text = bDr["organizer"].ToString();
                label15.Text = bDr["description"].ToString();
                label22.Text = bDr["guest1"].ToString();
                label23.Text = bDr["guest2"].ToString();
                label24.Text = bDr["guest3"].ToString();
                label25.Text = bDr["guest4"].ToString();
                label20.Text = bDr["food"].ToString();
                f_price = Convert.ToInt32(bDr["food_price"]);
                p_price = Convert.ToInt32(bDr["parking"]);
                price = Convert.ToInt32(bDr["price"]);
                string park_sts = bDr["park_sts"].ToString();
                pictureBox2.Image = bitmap;

                int r_seats = Convert.ToInt32(bDr["registerd_seats"]);
                int a_seats = Convert.ToInt32(label29.Text) - r_seats;
                label28.Text = a_seats.ToString();


                if (park_sts == "No" && label20.Text != "None")
                {
                    label26.Text = "Food";
                    checkBox1.Enabled = false;
                    checkBox1.Text = "Not available";
                    label21.Text = "No parking facilities";
                    checkBox1.Location = new System.Drawing.Point(50, 131);
                    fPrice.Text = f_price.ToString();
                    fPrice.Visible = true;
                    labelBDT.Visible = true;
                }
                else if (park_sts == "Yes" && label20.Text == "None")
                {
                    label26.Text = "Parking";
                    checkBox2.Enabled = false;
                    checkBox2.Text = "Not available";
                    checkBox2.Location = new System.Drawing.Point(50, 158);
                    label20.Text = "No food facilities";
                    pPrice.Text = p_price.ToString();
                    pPrice.Visible = true;
                    labelBDT1.Visible = true;
                }
                else if (park_sts == "Yes" && label20.Text != "None")
                {
                    label26.Text = "Food and Parking";
                    pPrice.Text = p_price.ToString();
                    pPrice.Visible = true;
                    fPrice.Text = f_price.ToString();
                    fPrice.Visible = true;
                    labelBDT.Visible = true;
                    labelBDT1.Visible = true;
                }
                else if (park_sts == "No" && label20.Text == "None")
                {
                    label26.Text = "No extra facilities";
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
            iconButton1.Visible = false;
            iconButton3.Visible = true;

            panel3.Dock = DockStyle.Fill;
            panel3.Visible = true;
            panel4.Visible = false;
        }
        private Image getImage(byte[] img)
        {
            MemoryStream ms = new MemoryStream();
            return Image.FromStream(ms);
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(905, 133);
            iconButton3.Visible = false;
            iconButton1.Visible = true;
            panel3.Visible= false;
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel4.Visible = false;
            panel3.Dock = DockStyle.Fill;
        }

        private void iconButton7_Click(object sender, EventArgs e)
        {
            //panel3.Size = new System.Drawing.Size(662, 436);
            panel3.Visible = false;
            panel4.Visible = true;
            panel4.Dock = DockStyle.Fill;
            panel2.Size = new System.Drawing.Size(10, 436);
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            panel2.Size = new System.Drawing.Size(228, 436); 
            panel2.Visible = true;
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            panel2.Size = new System.Drawing.Size(10, 436);
            panel2.Visible = false;
        }

        private void iconButton8_Click(object sender, EventArgs e)
        {
            iconButton1.Visible = false;
            iconButton3.Visible = true;

            if(comboBox1.Text == "1" || comboBox1.Text == "2" || comboBox1.Text == "3" || comboBox1.Text == "4")
            {
                int nOs = Convert.ToInt32(comboBox1.SelectedIndex) + 1;
                s_price = nOs * price;
                if (checkBox1.Checked && !checkBox2.Checked)
                {
                    t_price = s_price + p_price;
                }
                if (!checkBox1.Checked && checkBox2.Checked)
                {
                    t_price = s_price + (f_price* nOs);
                }
                if (checkBox1.Checked && checkBox2.Checked)
                {
                    t_price = s_price + p_price + (f_price * nOs);
                }
                if (!checkBox1.Checked && !checkBox2.Checked)
                {
                    t_price = s_price;
                }
                total = t_price;

                userID = SignInForm.ID;
                eventID = id;
                if (!checkBox1.Checked)
                {
                    parkingPrice = 0;
                }
                else
                {
                    parkingPrice = p_price;
                }
                if (!checkBox2.Checked)
                {
                    foodPrice = 0;
                }
                else
                {
                    foodPrice= f_price;
                }
                seatPrice = s_price;
                numberOfSeats = nOs;

                con4.Open();
                SqlCommand uCount = new SqlCommand("SELECT registerd_seats FROM Event Where eId =" + id, con4);
                SqlDataReader dr1 = uCount.ExecuteReader();
                int userCount = 0;
                while (dr1.Read())
                {
                    userCount = Convert.ToInt32(dr1["registerd_seats"]);
                    userCount = userCount + nOs;
                }
                con4.Close();
                users = userCount;

                if (userCount > capacity)
                {
                    MessageBox.Show("Not enough seats available" + userCount);
                }
                else
                {
                    if (MessageBox.Show("Total bill is " + t_price + " BDT. Do you want to proceed?", "Register", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        PaymentOptions paymentOptions = new PaymentOptions();
                        paymentOptions.Visible = true;
                        this.Size = new System.Drawing.Size(905, 133);
                        iconButton1.Visible = true;
                        iconButton3.Visible = false;
                    }
                }
                
            }
            else
            {
                MessageBox.Show("Please select the number of seats", "Massage", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton9_Click(object sender, EventArgs e)
        {
            panel2.Size = new System.Drawing.Size(228, 436);
            panel2.Visible = true;
        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

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
            this.panel3.Controls.Add(newForm);
            newForm.BringToFront();
            newForm.Show();
        }
        private void iconButton10_Click(object sender, EventArgs e)
        {
            panel3.Dock = DockStyle.Fill;
            panel3.Visible = true;
            panel4.Visible = false;
            openForm(new ProjectForms.ShowLocation(label4.Text.ToString(), "Rajshahi", "Bangladesh"));

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }
    }
}
