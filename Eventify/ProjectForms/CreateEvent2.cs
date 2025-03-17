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
    public partial class CreateEvent2 : Form
    {
        public CreateEvent2()
        {
            InitializeComponent();
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
            this.mainCreatePanel.Controls.Add(newForm);
            newForm.BringToFront();
            newForm.Show();
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            openForm(new ProjectForms.CreateEvent1_0());
        }

        private void mainCreatePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CreateEvent2_Load(object sender, EventArgs e)
        {
            SqlConnection con4 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Codings\C# Project\Eventify\Database\EVENTIFY.mdf"";Integrated Security=True;Connect Timeout=30");
            string bSts = "";
            con4.Open();
            SqlCommand cmd = new SqlCommand("Select block_status from AppUser where uId = " + SignInForm.ID, con4);
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            if (sqlDataReader.Read())
            {
                bSts = sqlDataReader["block_status"].ToString();
            }
            con4.Close();

            if (bSts == "blocked")
            {
                iconButton1.Enabled = false;
                label1.Visible = true;

            }
        }

    }
}
