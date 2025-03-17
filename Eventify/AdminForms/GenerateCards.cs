using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Eventify.AdminForms
{
    public partial class GenerateCards : Form
    {
        public GenerateCards()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Codings\C# Project\Eventify\Database\EVENTIFY.mdf"";Integrated Security=True;Connect Timeout=30");

        string randomCode;
        string c1()
        {

            Random rand = new Random();
            randomCode = (rand.Next(999)).ToString();
            return randomCode;

        }
        string c2()
        {
                Random rand = new Random();
                randomCode = (rand.Next(99)).ToString();
                return randomCode;
        }
        string c3()
        {
            Random rand = new Random();
            randomCode = (rand.Next(999)).ToString();
            return randomCode;
        }
        string c4()
        {
            Random rand = new Random();
            randomCode = (rand.Next(999)).ToString();
            return randomCode;
        }
        Random rand = new Random();
        private void iconButton1_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 0 || comboBox1.SelectedIndex == 1 || comboBox1.SelectedIndex == 2 || comboBox1.SelectedIndex == 3 || comboBox1.SelectedIndex == 4 || comboBox1.SelectedIndex == 5 || comboBox1.SelectedIndex == 6)
            {
                if(!radioButton1.Checked && !radioButton2.Checked)
                {
                    MessageBox.Show("Please select the amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int n = Convert.ToInt32(comboBox1.Text);
                    string[] cards = new string[n];
                    if (radioButton1.Checked)
                    {
                        for (int index = 1; index <= n; index++)
                        {
                            con.Open();
                            SqlCommand cmd1 = new SqlCommand("Insert into Card(cardNumber, aId) values (@cardNumber, @aId)", con);
                            cmd1.Parameters.AddWithValue("@cardNumber", (rand.Next(100, 1000)).ToString() + " - " + (rand.Next(10, 100)).ToString() + " - " + (rand.Next(100, 1000)).ToString());
                            cmd1.Parameters.AddWithValue("@aId", SignInForm.AID);
                            cmd1.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                    else
                    {
                        for (int index = 1; index <= n; index++)
                        {
                            con.Open();
                            SqlCommand cmd2 = new SqlCommand("Insert into Card(cardNumber, aId) values (@cardNumber, @aId)", con);
                            cmd2.Parameters.AddWithValue("@cardNumber", (rand.Next(100, 1000)).ToString() + " - " + (rand.Next(100, 1000)).ToString() + " - " + (rand.Next(100, 1000)).ToString());
                            cmd2.Parameters.AddWithValue("@aId", SignInForm.AID);
                            cmd2.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                    getData();
                }
            }
            else
            {
                MessageBox.Show("Please select the number of cards.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerateCards_Load(object sender, EventArgs e)
        {
            getData();
        }

        int count = 0;
        private void getData()
        {
            con.Open();
            SqlCommand bSq = new SqlCommand("select * from Card", con);
            SqlDataReader bDr = bSq.ExecuteReader();
            while (bDr.Read())
            {
                CardDataList l = new CardDataList();
                l.ID = Convert.ToInt32(bDr["Id"]);
                l.NO = bDr["cardNumber"].ToString();
                l.AID = Convert.ToInt32(bDr["aId"]);

                if (Convert.ToInt32(bDr["Id"]) > 0)
                {
                    flowLayoutPanel1.Controls.Add(l);
                    count++;
                }
            }
            con.Close();
            label5.Text = "Total " + count + " Cards";
        }

        private void InsertTextintoImage(string text, int i, string path)
        {

            PointF firstLocation = new PointF(182f, 157f);

            string imageFilePath = "D:\\Codings\\C# Project\\Eventify v3.1\\Images\\500.jpg";

            Bitmap newBitmap;
            using (var bitmap = (Bitmap)Image.FromFile(imageFilePath))//load the image file
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    using (Font arialFont = new Font("Verdana", 30))
                    {
                        graphics.DrawString(text.ToUpper(), arialFont, Brushes.Black, firstLocation);
                    }
                }
                newBitmap = new Bitmap(bitmap);
            }
            
            string savePath = path + " " + i + ".jpg"; // set image ;
            newBitmap.Save(savePath);//save the image file
            newBitmap.Dispose();
        }

        private void InsertTextintoImage1(string text, int i, string path)
        {

            PointF firstLocation = new PointF(166f, 157f);

            string imageFilePath = "D:\\Codings\\C# Project\\Eventify v3.1\\Images\\1000.jpg";

            Bitmap newBitmap;
            using (var bitmap = (Bitmap)Image.FromFile(imageFilePath))//load the image file
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    using (Font arialFont = new Font("Verdana", 30))
                    {
                        graphics.DrawString(text.ToUpper(), arialFont, Brushes.Black, firstLocation);
                    }
                }
                newBitmap = new Bitmap(bitmap);
            }
            string savePath = path +" " + i + ".jpg"; // set image ;
            newBitmap.Save(savePath);//save the image file
            newBitmap.Dispose();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sd = new SaveFileDialog();
            string imageLocation3 = "";
            if (sd.ShowDialog() == DialogResult.OK)
            {
                imageLocation3 = sd.FileName;
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Card", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int i = Convert.ToInt32(reader["Id"]);
                    string text = reader["cardNumber"].ToString();
                    if (text.Length == 14)
                    {
                        InsertTextintoImage(text, i, imageLocation3);
                    }
                    else
                    {
                        InsertTextintoImage1(text, i, imageLocation3);
                    }
                }
                con.Close();
                MessageBox.Show("Card images generated successfully.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
