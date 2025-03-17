using FontAwesome.Sharp;
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

namespace Eventify.ProjectForms
{
    public partial class CreateEvents : Form
    {
        public CreateEvents()
        {
            InitializeComponent();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void CreateEvents_Load(object sender, EventArgs e)
        {
            string status = "";
            con.Open();
            SqlCommand selE = new SqlCommand("select status from AppUser where uId = " + SignInForm.ID, con);
            SqlDataReader dr1 = selE.ExecuteReader();
            while (dr1.Read())
            {
                status = dr1["status"].ToString();
            }
            con.Close();
            if (status == "requested")
            {
                requestButton.Enabled = false;
                requestButton.Text = "Requested";
                iconButton1.Visible = true;
            }
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Codings\C# Project\Eventify\Database\EVENTIFY.mdf"";Integrated Security=True;Connect Timeout=30");

        private void requestButton_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand sqU = new SqlCommand("update AppUser set status = @status WHERE uId =" + SignInForm.ID, con);
            sqU.Parameters.AddWithValue("@status", "requested");
            sqU.ExecuteNonQuery();
            con.Close();
            requestButton.Visible = false;
            requestButton.Text = "Requested";
            iconButton1.Visible = true;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand sqU = new SqlCommand("update AppUser set status = @status WHERE uId =" + SignInForm.ID, con);
            sqU.Parameters.AddWithValue("@status", "user");
            sqU.ExecuteNonQuery();
            con.Close();
            requestButton.Enabled = true;
            requestButton.Text = "Request";
            iconButton1.Visible = false;
        }
    }
}
