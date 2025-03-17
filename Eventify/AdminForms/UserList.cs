using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eventify.AdminForms
{
    public partial class UserList : UserControl
    {
        public UserList()
        {
            InitializeComponent();
        }

        private void UserList_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(905, 64);
            if(status == "requested")
            {
                iconButton4.Visible = true;
                iconButton6.Visible = true;
            }
            if(status == "organizer")
            {
                iconButton7.Visible = false;
                iconButton3.Visible = true;
            }
            if (status == "uesr")
            {
                iconButton7.Visible = true;
                iconButton3.Visible = false;
            }
        }

        int id; 
        string username;
        string status;
        public int ID
        { get { return id; } set { id = value; } }

        [Category("Custom Props")]
        public string USERNAME
        { get { return username; } set { username = value; label4.Text = value; } }

        [Category("Custom Props")]
        public string STATUS
        { get { return status; } set { status = value; label3.Text = value; } }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Codings\C# Project\Eventify\Database\EVENTIFY.mdf"";Integrated Security=True;Connect Timeout=30");

        string block_status = "";
        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(905, 248);
            iconButton2.Visible = true;
            iconButton1.Visible = false;

            con.Open();
            SqlCommand cmd1 = new SqlCommand("Select * from AppUser WHERE uId = " + id, con);
            SqlDataReader r1 = cmd1.ExecuteReader();
            if (r1.Read())
            {
                label16.Text = r1["first_name"].ToString();
                label15.Text = r1["last_name"].ToString();
                label14.Text = r1["phone_no"].ToString();
                label13.Text = r1["email"].ToString();
                label12.Text = r1["gender"].ToString();
                label11.Text = r1["balance"].ToString();
                block_status = r1["block_status"].ToString();
            }
            con.Close();

            if(block_status == "blocked")
            {

                iconButton8.Visible = true;
                iconButton5.Visible = false;
                int adID = 0;
                string admin = "";
                con.Open();
                SqlCommand sqlCommand1 = new SqlCommand("Select aId from AppUser where uId =" + id, con);
                SqlDataReader reader1 = sqlCommand1.ExecuteReader();
                if (reader1.Read())
                {
                    adID = Convert.ToInt32(reader1["aId"]);
                }
                con.Close();

                if (adID != 0)
                {
                    con.Open();
                    SqlCommand sqlCommand2 = new SqlCommand("Select name from Admin where aId =" + adID, con);
                    SqlDataReader reader2 = sqlCommand2.ExecuteReader();
                    if (reader2.Read())
                    {
                        admin = reader2["name"].ToString();
                    }
                    con.Close();
                    label17.Visible = true;
                    label17.Text = "Blocked by " + admin.Remove(0, 3);
                }
                else
                {
                    label17.Visible = false;

                }
            }
            else
            {
                iconButton8.Visible = false;
                iconButton5.Visible = true;
                label17.Visible = false;

            }
            if(label3.Text == "organizer")
            {
                iconButton3.Visible = false;
                iconButton7.Visible = true;
            }
            else
            {
                iconButton3.Visible = true;
                iconButton7.Visible = false;
            }
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd2 = new SqlCommand("Update AppUser set status = @status Where uId =" +id, con);
            cmd2.Parameters.AddWithValue("@status", "organizer");
            cmd2.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Request Accepted", "Massage", MessageBoxButtons.OK, MessageBoxIcon.Information);
            iconButton4.Visible = false;
            iconButton6.Visible = false;
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd2 = new SqlCommand("Update AppUser set status = @status Where uId =" + id, con);
            cmd2.Parameters.AddWithValue("@status", "user");
            cmd2.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Request Rejected", "Massage", MessageBoxButtons.OK, MessageBoxIcon.Information);
            iconButton4.Visible = false;
            iconButton6.Visible = false;
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd2 = new SqlCommand("Update AppUser set status = @status Where uId =" + id, con);
            cmd2.Parameters.AddWithValue("@status", "organizer");
            cmd2.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Added as Organizer","Massage", MessageBoxButtons.OK, MessageBoxIcon.Information);
            iconButton3.Visible = false;
            iconButton7.Visible = true;
            label3.Text = "organizer";
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd2 = new SqlCommand("Update AppUser set block_status = @block_status Where uId =" + id, con);
            cmd2.Parameters.AddWithValue("@block_status", "blocked");
            cmd2.ExecuteNonQuery();
            con.Close();

            con.Open();
            SqlCommand sqlCommand1 = new SqlCommand("Update AppUser set aId = @aId where uId =" + id, con);
            sqlCommand1.Parameters.AddWithValue("@aId", SignInForm.AID);
            sqlCommand1.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("User Blocked", "Massage", MessageBoxButtons.OK, MessageBoxIcon.Information);
            iconButton8.Visible = true;
            iconButton5.Visible = false;
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(905, 64);
            iconButton1.Visible = true;
            iconButton2.Visible = false;
        }

        private void iconButton7_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd2 = new SqlCommand("Update AppUser set status = @status Where uId =" + id, con);
            cmd2.Parameters.AddWithValue("@status", "user");
            cmd2.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Removed as Organizer", "Massage", MessageBoxButtons.OK, MessageBoxIcon.Information);
            iconButton3.Visible = true;
            iconButton7.Visible = false;
            label3.Text = "user";

        }

        private void iconButton8_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd2 = new SqlCommand("Update AppUser set block_status = @block_status Where uId =" + id, con);
            cmd2.Parameters.AddWithValue("@block_status", "unblocked");
            cmd2.ExecuteNonQuery();
            con.Close();

            con.Open();
            SqlCommand sqlCommand1 = new SqlCommand("Update AppUser set aId = @aId where uId =" + id, con);
            sqlCommand1.Parameters.AddWithValue("@aId", 0);
            sqlCommand1.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("User Unblocked", "Massage", MessageBoxButtons.OK, MessageBoxIcon.Information);
            iconButton8.Visible = false;
            iconButton5.Visible = true;
            label17.Visible = false;
        }

        private Form currentForm;
        private void openForm(Form newForm)
        {
            if (currentForm != null)
            {
                currentForm.Close();
            }
            currentForm = newForm;
            currentForm.TopLevel = false;
            currentForm.FormBorderStyle = FormBorderStyle.None;
            currentForm.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(newForm);
            newForm.BringToFront();
            newForm.Show();
        }
        private void iconButton9_Click(object sender, EventArgs e)
        {
            //AdminForms.RegisteredEvents registeredEvents = new AdminForms.RegisteredEvents(id);
            this.Size = new System.Drawing.Size(905, 354);
            openForm(new AdminForms.RegisteredEvents(id));
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
