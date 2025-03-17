using Eventify.ProjectForms;
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

namespace Eventify.AdminForms
{
    public partial class SearchEvents : Form
    {
        public SearchEvents()
        {
            InitializeComponent();
        }

        string text = "", option = "";
        public SearchEvents(string o, string t)
        {
            InitializeComponent();
            option = o;
            text = t;
        }
        SqlConnection bCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Codings\C# Project\Eventify\Database\EVENTIFY.mdf"";Integrated Security=True;Connect Timeout=30");

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SearchEvents_Load(object sender, EventArgs e)
        {
            if (text == "")
            {
                GetData();
            }
            else
            {
                GetData1();
            }
        }
        int count = 0;
        private void GetData()
        {
            bCon.Open();
            SqlCommand bSq = new SqlCommand("select display, title, category, date, venue, eId, e_status, block_status from Event", bCon);
            SqlDataReader bDr = bSq.ExecuteReader();
            while (bDr.Read())
            {
                EventListA eventListA = new EventListA();
                eventListA.ID = Convert.ToInt32(bDr["eId"]);
                eventListA.TITLE1 = bDr["title"].ToString();
                eventListA.CATEGORY1 = bDr["category"].ToString();
                eventListA.ESTATUS = bDr["e_status"].ToString();
                eventListA.BSTATUS = bDr["block_status"].ToString();
                eventListA.DATE1 = bDr["date"].ToString();
                if (eventListA.TITLE1.Length > 0)
                {
  
                    flowLayoutPanel1.Controls.Add(eventListA);
                    label1.Visible = false;
                    count++;

                }
            }
            bCon.Close();
            label2.Text = count + " Event(s) found";
        }

        private void GetData1()
        {
            bCon.Open();
            SqlCommand bSq = new SqlCommand("select display, title, category, date, venue, eId, e_status, block_status from Event WHERE " + option + " LIKE '%" + text + "%'", bCon);
            SqlDataReader bDr = bSq.ExecuteReader();
            while (bDr.Read())
            {
                EventListA eventListA = new EventListA();
                eventListA.ID = Convert.ToInt32(bDr["eId"]);
                eventListA.TITLE1 = bDr["title"].ToString();
                eventListA.CATEGORY1 = bDr["category"].ToString();
                eventListA.ESTATUS = bDr["e_status"].ToString();
                eventListA.BSTATUS = bDr["block_status"].ToString();
                eventListA.DATE1 = bDr["date"].ToString();
                if (eventListA.TITLE1.Length > 0)
                {
                    flowLayoutPanel1.Controls.Add(eventListA);
                    label1.Visible = false;
                    count++;
                }
            }
            bCon.Close();
            label2.Text = count + " Event(s) found";
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            AdminForms.MainAdminForm aM = new AdminForms.MainAdminForm();
            aM.Visible = true;
            Application.Exit();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
