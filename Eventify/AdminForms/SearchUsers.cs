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
    public partial class SearchUsers : Form
    {
        public SearchUsers()
        {
            InitializeComponent();
        }
        string text = "", option = "";
        public SearchUsers(string o, string t)
        {
            InitializeComponent();
            option = o;
            text = t;
        }
        SqlConnection bCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Codings\C# Project\Eventify\Database\EVENTIFY.mdf"";Integrated Security=True;Connect Timeout=30");

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SearchUsers_Load(object sender, EventArgs e)
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
            SqlCommand bSq = new SqlCommand("select uId, username, status from AppUser", bCon);
            SqlDataReader bDr = bSq.ExecuteReader();
            while (bDr.Read())
            {
                UserList userList = new UserList();
                userList.ID = Convert.ToInt32(bDr["uId"]);
                userList.USERNAME = bDr["username"].ToString();
                userList.STATUS = bDr["status"].ToString();


                if (userList.USERNAME.Length > 0)
                {
                    flowLayoutPanel1.Controls.Add(userList);
                    label1.Visible = false;
                    count++;
                }
            }
            bCon.Close();
            label2.Text = count + " User(s) found";
        }
        private void GetData1()
        {
            bCon.Open();
            SqlCommand bSq = new SqlCommand("select uId, username, status from AppUser WHERE " + option + " LIKE '%" + text + "%'", bCon);
            SqlDataReader bDr = bSq.ExecuteReader();
            while (bDr.Read())
            {
                UserList userList = new UserList();
                userList.ID = Convert.ToInt32(bDr["uId"]);
                userList.USERNAME = bDr["username"].ToString();
                userList.STATUS = bDr["status"].ToString();

                if (userList.USERNAME.Length > 0)
                {
                    flowLayoutPanel1.Controls.Add(userList);
                    label1.Visible = false;
                    count++;
                }
            }
            bCon.Close();
            label2.Text = count + " User(s) found";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
