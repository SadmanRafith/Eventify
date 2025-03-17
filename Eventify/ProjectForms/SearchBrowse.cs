using Eventify.AdminForms;
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
    public partial class SearchBrowse : Form
    {
        public SearchBrowse()
        {
            InitializeComponent();
        }

        string text="", option = "";
        public SearchBrowse(string o, string t)
        {
            InitializeComponent();
            option = o;
            text = t;
        }
        SqlConnection bCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Codings\C# Project\Eventify\Database\EVENTIFY.mdf"";Integrated Security=True;Connect Timeout=30");

        private void SearchBrowse_Load(object sender, EventArgs e)
        {
            if(text == "")
            {
                GetData();
            }
            else
            {
                GetData1();
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        int count = 0;
        private void GetData1()
        {
            bCon.Open();
            SqlCommand bSq = new SqlCommand("select display, title, category, date, venue, eId, e_status, block_status, capacity, registerd_seats, city from Event WHERE " + option + " LIKE '%" + text + "%'", bCon);
            SqlDataReader bDr = bSq.ExecuteReader();
            while (bDr.Read())
            {
                long len = bDr.GetBytes(0, 0, null, 0, 0);
                byte[] array = new byte[System.Convert.ToInt32(len) + 1];
                bDr.GetBytes(0, 0, array, 0, System.Convert.ToInt32(len));
                MemoryStream memoryStream = new MemoryStream(array);
                Bitmap bitmap = new Bitmap(memoryStream);


                AllEventList allEventList = new AllEventList();
                allEventList.ID = Convert.ToInt32(bDr["eId"]);
                allEventList.TITLE1 = bDr["title"].ToString();
                allEventList.CATEGORY1 = bDr["category"].ToString();
                allEventList.DATE1 = bDr["date"].ToString();
                string city = bDr["city"].ToString();
                allEventList.VENUE1 = bDr["venue"].ToString() + ", " + city;
                allEventList.ESTATUS = bDr["e_status"].ToString();
                allEventList.NOS = Convert.ToInt32(bDr["capacity"]);
                allEventList.RS = Convert.ToInt32(bDr["registerd_seats"]);

                allEventList.DISPLAY = bitmap;
                if (allEventList.TITLE1.Length > 0)
                {
                    if (allEventList.ESTATUS == "valid" && bDr["block_status"].ToString() != "Blocked")
                    {
                        flowLayoutPanel1.Controls.Add(allEventList);
                        label1.Visible = false;
                        count++;
                    }
                }
            }
            bCon.Close();
            label2.Text = count + "Event(s) found";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void GetData()
        {
            bCon.Open();
            SqlCommand bSq = new SqlCommand("select display, title, category, date, venue, eId, e_status, block_status, capacity, registerd_seats, city from Event", bCon);
            SqlDataReader bDr = bSq.ExecuteReader();
            while (bDr.Read())
            {
                long len = bDr.GetBytes(0, 0, null, 0, 0);
                byte[] array = new byte[System.Convert.ToInt32(len) + 1];
                bDr.GetBytes(0, 0, array, 0, System.Convert.ToInt32(len));
                MemoryStream memoryStream = new MemoryStream(array);
                Bitmap bitmap = new Bitmap(memoryStream);


                AllEventList allEventList = new AllEventList();
                allEventList.ID = Convert.ToInt32(bDr["eId"]);
                allEventList.TITLE1 = bDr["title"].ToString();
                allEventList.CATEGORY1 = bDr["category"].ToString();
                allEventList.DATE1 = bDr["date"].ToString();
                string city = bDr["city"].ToString();
                allEventList.VENUE1 = bDr["venue"].ToString() + ", " + city;
                allEventList.ESTATUS = bDr["e_status"].ToString();
                allEventList.NOS = Convert.ToInt32(bDr["capacity"]);
                allEventList.RS = Convert.ToInt32(bDr["registerd_seats"]);

                allEventList.DISPLAY = bitmap;
                if (allEventList.TITLE1.Length > 0)
                {
                    if (allEventList.ESTATUS == "valid" && bDr["block_status"].ToString() != "Blocked")
                    {
                        flowLayoutPanel1.Controls.Add(allEventList);
                        label1.Visible = false;
                        count++;
                    }
                }
            }
            bCon.Close();
            label2.Text = count + " Event(s) found";
        }
    }
}
