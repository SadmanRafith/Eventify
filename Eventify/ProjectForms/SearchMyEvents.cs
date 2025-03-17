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
using System.Windows.Shapes;

namespace Eventify.ProjectForms
{
    public partial class SearchMyEvents : Form
    {
        public SearchMyEvents()
        {
            InitializeComponent();
        }

        string text = "", option = "";
        public SearchMyEvents(string o, string t)
        {
            InitializeComponent();
            option = o;
            text = t;
        }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SearchMyEvents_Load(object sender, EventArgs e)
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


        private int[] org = new int[100];
        int j = 0;

        int count = 0;
        private void GetData()
        {
            SqlConnection mConId = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Codings\C# Project\Eventify\Database\EVENTIFY.mdf"";Integrated Security=True;Connect Timeout=30");
            mConId.Open();
            SqlCommand mSqId = new SqlCommand("select eId from Organize WHERE uId = " + SignInForm.ID, mConId);
            SqlDataReader mDrId = mSqId.ExecuteReader();

            while (mDrId.Read())
            {
                org[j++] = Convert.ToInt32(mDrId["eId"]); ;
            }
            mConId.Close();
            foreach (int j in org)
            {
                SqlConnection mCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Codings\C# Project\Eventify\Database\EVENTIFY.mdf"";Integrated Security=True;Connect Timeout=30");
                mCon.Open();
                SqlCommand mSq = new SqlCommand("select display, title, category, date, venue, eid, e_status, city from Event WHERE eId=" + j, mCon);
                SqlDataReader mDr = mSq.ExecuteReader();
                while (mDr.Read())
                {
                    long len = mDr.GetBytes(0, 0, null, 0, 0);
                    byte[] array = new byte[System.Convert.ToInt32(len) + 1];
                    mDr.GetBytes(0, 0, array, 0, System.Convert.ToInt32(len));
                    MemoryStream memoryStream = new MemoryStream(array);
                    Bitmap bitmap = new Bitmap(memoryStream);


                    EventList eventList = new EventList();
                    
                    eventList.ID = Convert.ToInt32(mDr["eId"]);
                    eventList.TITLE = mDr["title"].ToString();
                    eventList.CATEGORY = mDr["category"].ToString();
                    eventList.DATE = mDr["date"].ToString();
                    string city = mDr["city"].ToString();
                    eventList.VENUE = mDr["venue"].ToString() + ", "+city;
                    eventList.IMAGE = bitmap;
                    if (eventList.TITLE.Length > 0)
                    {
                        if (mDr["e_status"].ToString() != "expired")
                        {
                            flowLayoutPanel1.Controls.Add(eventList);
                            label1.Visible = false;
                            count++;
                        }
                    }
                }
                mCon.Close();
                label2.Text = count + " Event(s) found";
            }
        }


        private int[] ii = new int[100];
        int i = 0;

        private void GetData1()
        {
            SqlConnection mConId = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Codings\C# Project\Eventify\Database\EVENTIFY.mdf"";Integrated Security=True;Connect Timeout=30");
            mConId.Open();
            SqlCommand mSqId = new SqlCommand("select eId from Organize WHERE uId = " + SignInForm.ID, mConId);
            SqlDataReader mDrId = mSqId.ExecuteReader();

            while (mDrId.Read())
            {
                ii[i++] = Convert.ToInt32(mDrId["eId"]); ;
            }
            mConId.Close();
            foreach (int i in ii)
            {
                SqlConnection mCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Codings\C# Project\Eventify\Database\EVENTIFY.mdf"";Integrated Security=True;Connect Timeout=30");
                mCon.Open();
                SqlCommand mSq = new SqlCommand("select display, title, category, date, venue, eId, e_status, city from Event WHERE " + option + " LIKE '%" + text + "%' and eId=" + i, mCon);
                SqlDataReader mDr = mSq.ExecuteReader();
                while (mDr.Read())
                {
                    long len = mDr.GetBytes(0, 0, null, 0, 0);
                    byte[] array = new byte[System.Convert.ToInt32(len) + 1];
                    mDr.GetBytes(0, 0, array, 0, System.Convert.ToInt32(len));
                    MemoryStream memoryStream = new MemoryStream(array);
                    Bitmap bitmap = new Bitmap(memoryStream);


                    EventList eventList = new EventList();
                    eventList.ID = Convert.ToInt32(mDr["eId"]);
                    eventList.TITLE = mDr["title"].ToString();
                    eventList.CATEGORY = mDr["category"].ToString();
                    eventList.DATE = mDr["date"].ToString();
                    string city = mDr["city"].ToString();
                    eventList.VENUE = mDr["venue"].ToString() + ", " + city;
                    eventList.IMAGE = bitmap;
                    if (eventList.TITLE.Length > 0)
                    {
                        if (mDr["e_status"].ToString() != "expired")
                        {
                            flowLayoutPanel1.Controls.Add(eventList);
                            label1.Visible = false;
                            count++;
                        }
                    }
                }
                mCon.Close();
                label2.Text = count + " Event(s) found";
            }
        }
    }
}
