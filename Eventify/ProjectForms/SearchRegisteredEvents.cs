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
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Eventify.ProjectForms
{
    public partial class SearchRegisteredEvents : Form
    {
        public SearchRegisteredEvents()
        {
            InitializeComponent();
        }

        string text = "", option = "";
        public SearchRegisteredEvents(string o, string t)
        {
            InitializeComponent();
            option = o;
            text = t;
        }

        private void SearchRegisteredEvents_Load(object sender, EventArgs e)
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
        SqlConnection mConId = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Codings\C# Project\Eventify\Database\EVENTIFY.mdf"";Integrated Security=True;Connect Timeout=30");


        private int[] ii = new int[100];
        int i = 0;
        private void GetData()
        {
            mConId.Open();
            SqlCommand mSqId = new SqlCommand("select eId from Register WHERE uId = " + SignInForm.ID, mConId);
            SqlDataReader mDrId = mSqId.ExecuteReader();

            while (mDrId.Read())
            {
                ii[i++] = Convert.ToInt32(mDrId["eId"]); ;
            }
            mConId.Close();
            foreach (int i in ii)
            {
                mConId.Open();
                SqlCommand bSq = new SqlCommand("select display, title, category, date, venue, eId, e_status, city from Event WHERE eId=" + i, mConId);
                SqlDataReader bDr = bSq.ExecuteReader();
                while (bDr.Read())
                {
                    long len = bDr.GetBytes(0, 0, null, 0, 0);
                    byte[] array = new byte[System.Convert.ToInt32(len) + 1];
                    bDr.GetBytes(0, 0, array, 0, System.Convert.ToInt32(len));
                    MemoryStream memoryStream = new MemoryStream(array);
                    Bitmap bitmap = new Bitmap(memoryStream);


                    RegisteredEventList regEventList = new RegisteredEventList();
                    regEventList.ID = Convert.ToInt32(bDr["eId"]);
                    regEventList.TITLE1 = bDr["title"].ToString();
                    regEventList.CATEGORY1 = bDr["category"].ToString();
                    regEventList.DATE1 = bDr["date"].ToString();
                    string city = bDr["city"].ToString();
                    regEventList.VENUE1 = bDr["venue"].ToString() + ", " + city; ;

                    regEventList.DISPLAY = bitmap;
                    if (regEventList.TITLE1.Length > 0 && bDr["e_status"].ToString() != "expired")
                    {
                        flowLayoutPanel1.Controls.Add(regEventList);
                        label1.Visible = false;
                        count++;
                    }
                }
                mConId.Close();
                label2.Text = count + " Event(s) found";
            }
        }

        private int[] jj = new int[100];
        int j = 0;

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        int count = 0;
        private void GetData1()
        {
            SqlConnection mConId = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Codings\C# Project\Eventify\Database\EVENTIFY.mdf"";Integrated Security=True;Connect Timeout=30");
            mConId.Open();
            SqlCommand mSqId = new SqlCommand("select eId from Register WHERE uId = " + SignInForm.ID, mConId);
            SqlDataReader mDrId = mSqId.ExecuteReader();

            while (mDrId.Read())
            {
                jj[j++] = Convert.ToInt32(mDrId["eId"]); ;
            }
            mConId.Close();
            foreach (int j in jj)
            {
                mConId.Open();
                SqlCommand bSq = new SqlCommand("select display, title, category, date, venue, eId, e_status, city from Event WHERE " + option + " LIKE '%" + text + "%' and eId=" + j, mConId);
                SqlDataReader bDr = bSq.ExecuteReader();
                while (bDr.Read())
                {
                    long len = bDr.GetBytes(0, 0, null, 0, 0);
                    byte[] array = new byte[System.Convert.ToInt32(len) + 1];
                    bDr.GetBytes(0, 0, array, 0, System.Convert.ToInt32(len));
                    MemoryStream memoryStream = new MemoryStream(array);
                    Bitmap bitmap = new Bitmap(memoryStream);


                    RegisteredEventList regEventList = new RegisteredEventList();
                    regEventList.ID = Convert.ToInt32(bDr["eId"]);
                    regEventList.TITLE1 = bDr["title"].ToString();
                    regEventList.CATEGORY1 = bDr["category"].ToString();
                    regEventList.DATE1 = bDr["date"].ToString();
                    string city = bDr["city"].ToString();
                    regEventList.VENUE1 = bDr["venue"].ToString() + ", " + city; ;

                    regEventList.DISPLAY = bitmap;
                    if (regEventList.TITLE1.Length > 0 && bDr["e_status"].ToString() != "expired")
                    {
                        flowLayoutPanel1.Controls.Add(regEventList);
                        label1.Visible = false;
                        count++;
                    }
                }
                mConId.Close();
                label2.Text = count + " Event(s) found";
            }
        }
    }
}
