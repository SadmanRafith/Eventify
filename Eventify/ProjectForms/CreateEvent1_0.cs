using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eventify.ProjectForms
{
    public partial class CreateEvent1_0 : Form
    {
        public CreateEvent1_0()
        {
            InitializeComponent();
        }
        private void CreateEvent1_0_Load(object sender, EventArgs e)
        {
            //openForm(new ProjectForms.EventDetails());
            enableButton(iconButton1);
            panel2.Visible = true;
            panel3.Visible = false;
            panel4.Visible = false;
            panel2.Dock = DockStyle.Fill;
 
            iconPictureBox1.Image = Properties.Resources.def_picture;
            iconPictureBox2.Image = Properties.Resources.def_picture;
            iconPictureBox3.Image = Properties.Resources.def_picture;
            iconPictureBox4.Image = Properties.Resources.def_person;
            iconPictureBox5.Image = Properties.Resources.def_person;
            iconPictureBox6.Image = Properties.Resources.def_person;
            iconPictureBox7.Image = Properties.Resources.def_person;
        }

        private int index = 1;
        private Color selectThemeColor()
        {
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }
        IconButton currentButton;
        private void enableButton(object btn)
        {
            if (btn != null)
            {
                disableButton();
                Color color = selectThemeColor();
                currentButton = (IconButton)btn;
                currentButton.BackColor = color;
                currentButton.ForeColor = Color.Gainsboro;
                panel1.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
            }
        }
        private void disableButton()
        {
            if (currentButton != null)
            {
                currentButton.BackColor = Color.FromArgb(51, 51, 76);
                currentButton.ForeColor = Color.Gainsboro;
            }
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
            this.panel2.Controls.Add(newForm);
            newForm.BringToFront();
            newForm.Show();
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            //openForm(new ProjectForms.EventDetails());
            enableButton(sender);
            panel2.Visible = true;
            panel3.Visible = false;
            panel4.Visible = false;
            panel2.Dock = DockStyle.Fill;

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            //openForm(new ProjectForms.EventServices());
            enableButton(sender);
            panel2.Visible = false;
            panel3.Visible = true;
            panel4.Visible = false;
            panel3.Dock = DockStyle.Fill;
            if (textBox8.Text == "None")
            {
                textBox9.Enabled = false;
            }
            if(!checkBox1.Checked)
            {
                textBox10.Enabled = false;
            }

        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            //openForm(new ProjectForms.CreateEvent1());
            enableButton(sender);
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = true;
            panel4.Dock = DockStyle.Fill;
        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        public static int eid;
        private void iconButton4_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text) || string.IsNullOrEmpty(textBox6.Text) || string.IsNullOrEmpty(textBox12.Text) || string.IsNullOrEmpty(textBox13.Text) || string.IsNullOrEmpty(textBox14.Text) || string.IsNullOrEmpty(textBox15.Text) && string.IsNullOrEmpty(richTextBox1.Text))
            {
                if (textBox1.Text == "")
                {
                    label1.ForeColor = Color.Red;
                }
                if (textBox2.Text == "")
                {
                    label2.ForeColor = Color.Red;
                }
                if (textBox3.Text == "")
                {
                    label3.ForeColor = Color.Red;
                }
                if (textBox4.Text == "")
                {
                    label4.ForeColor = Color.Red;
                }
                if (textBox5.Text == "")
                {
                    label5.ForeColor = Color.Red;
                }
                if (textBox6.Text == "")
                {
                    label8.ForeColor = Color.Red;
                }
                MessageBox.Show("Please fill up all the information", "Massage", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                if (dateTimePicker1.Value.ToString()  == DateTime.Today.ToString())
                {
                    MessageBox.Show("Evant can not be created for today", "Massage", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Codings\C# Project\Eventify\Database\EVENTIFY.mdf"";Integrated Security=True;Connect Timeout=30");
                    con1.Open();
                    SqlCommand sq1 = new SqlCommand("insert into Event(title, category, capacity, price, venue, date, time, duration, description, image1, image2, organizer, guest1, guest2, guest3, guest4, g1_image, g2_image, g3_image, g4_image, display, food, food_price, parking, park_sts, creation_date, edit_status, block_status, e_status, city) values(@title, @category, @capacity, @price, @venue, @date, @time, @duration, @description, @image1, @image2, @organizer, @guest1, @guest2, @guest3, @guest4, @g1_image, @g2_image, @g3_image, @g4_image, @display, @food, @food_price, @parking, @park_sts, @creation_date, @edit_status, @block_status, @e_status, @city) ", con1);
                    sq1.Parameters.AddWithValue("@title", textBox1.Text);
                    sq1.Parameters.AddWithValue("@category", textBox2.Text);
                    sq1.Parameters.AddWithValue("@capacity", textBox3.Text);
                    sq1.Parameters.AddWithValue("@price", int.Parse(textBox4.Text));
                    sq1.Parameters.AddWithValue("@venue", textBox5.Text);
                    sq1.Parameters.AddWithValue("@description", richTextBox1.Text);
                    sq1.Parameters.AddWithValue("@date", dateTimePicker1.Text);
                    sq1.Parameters.AddWithValue("@time", dateTimePicker2.Text);
                    sq1.Parameters.AddWithValue("@duration", textBox6.Text);
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
                    sq1.Parameters.AddWithValue("@block_status", "Unblocked");
                    sq1.Parameters.AddWithValue("@e_status", "valid");
                    sq1.Parameters.AddWithValue("@city", textBox7.Text);
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

                    SqlConnection con3 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Codings\C# Project\Eventify\Database\EVENTIFY.mdf"";Integrated Security=True;Connect Timeout=30");
                    con3.Open();
                    SqlCommand sq3 = new SqlCommand("select eId from Event", con3);
                    SqlDataReader dr3 = sq3.ExecuteReader();
                    while (dr3.Read())
                    {
                        eid = Convert.ToInt32(dr3["eId"]);
                    }
                    con3.Close();

                    SqlConnection con4 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Codings\C# Project\Eventify\Database\EVENTIFY.mdf"";Integrated Security=True;Connect Timeout=30");
                    con4.Open();
                    SqlCommand sq4 = new SqlCommand("insert into Organize(uId ,eId) values(@uId, @eId)", con4);
                    sq4.Parameters.AddWithValue("@uId", SignInForm.ID);
                    sq4.Parameters.AddWithValue("@eId", eid);

                    sq4.ExecuteNonQuery();
                    con4.Close();

                    MessageBox.Show("New event created successfully", "Massage", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();
                    //openForm(new ProjectForms.CreateEvent2());
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

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_Enter(object sender, EventArgs e)
        {
            if(textBox12.Text == "None")
            {
                textBox12.Text = "";
            }
        }

        private void textBox12_Leave(object sender, EventArgs e)
        {
            if (textBox12.Text == "")
            {
                textBox12.Text = "None";
            }
        }

        private void textBox13_Enter(object sender, EventArgs e)
        {
            if (textBox13.Text == "None")
            {
                textBox13.Text = "";
            }
        }

        private void textBox13_Leave(object sender, EventArgs e)
        {
            if (textBox13.Text == "")
            {
                textBox13.Text = "None";
            }
        }

        private void textBox14_Enter(object sender, EventArgs e)
        {
            if (textBox14.Text == "None")
            {
                textBox14.Text = "";
            }
        }

        private void textBox14_Leave(object sender, EventArgs e)
        {
            if (textBox14.Text == "")
            {
                textBox14.Text = "None";
            }
        }

        private void textBox15_Enter(object sender, EventArgs e)
        {
            if (textBox15.Text == "None")
            {
                textBox15.Text = "";
            }
        }

        private void textBox15_Leave(object sender, EventArgs e)
        {
            if (textBox15.Text == "")
            {
                textBox15.Text = "None";
            }
        }

        private void textBox8_Enter(object sender, EventArgs e)
        {
            if (textBox8.Text == "None")
            {
                textBox8.Text = "";
                textBox9.Enabled = true;
            }
        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            if (textBox8.Text == "")
            {
                textBox8.Text = "None";
                if (textBox8.Text == "None")
                {
                    textBox9.Enabled = false;
                }
            }
        }

        private void textBox10_Enter(object sender, EventArgs e)
        {
            if (textBox10.Text == "0")
            {
                textBox10.Text = "";
            }
        }

        private void textBox10_Leave(object sender, EventArgs e)
        {
            if (textBox10.Text == "")
            {
                textBox10.Text = "0";
            }
        }

        private void textBox9_Enter(object sender, EventArgs e)
        {
            if (textBox9.Text == "0")
            {
                textBox9.Text = "";
                
            }
        }

        private void textBox9_Leave(object sender, EventArgs e)
        {
            if (textBox9.Text == "0")
            {
                textBox9.Text = "";
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if(!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox10.Enabled = true;
            }
            else
            {
                textBox10.Enabled = false;
                textBox10.Text = "0";
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
