using Eventify.AdminForms;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eventify.ProjectForms
{
    public partial class RegisteredUsers : Form
    {
        public RegisteredUsers()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Codings\C# Project\Eventify\Database\EVENTIFY.mdf"";Integrated Security=True;Connect Timeout=30");

        int eid;
        public RegisteredUsers(int eid)
        {
            InitializeComponent();
            this.eid = eid;
        }
        private void RegisteredUsers_Load(object sender, EventArgs e)
        {
            GetDatas();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }



        int[] jj = new int[500];
        int j = 0;
        private void GetDatas()
        {
            con.Open();
            SqlCommand mSqId = new SqlCommand("select uId from Register WHERE eId =" + eid, con);
            SqlDataReader mDrId = mSqId.ExecuteReader();
            while (mDrId.Read())
            {
                jj[j++] = Convert.ToInt32(mDrId["uId"]);
            }
            con.Close();
            foreach (int j in jj)
            {
                string title = "";
                con.Open();
                SqlCommand c = new SqlCommand("select username from AppUser WHERE uId =" + j, con);
                SqlDataReader cr = c.ExecuteReader();
                if (cr.Read())
                {
                    title = cr["username"].ToString();
                }
                con.Close();

                con.Open();
                SqlCommand bSq = new SqlCommand("select * from Register WHERE uId=" + j + "and eid = " +eid, con);
                SqlDataReader bDr = bSq.ExecuteReader();
                while (bDr.Read())
                {
                    RegisteredUserList rl = new RegisteredUserList();
                    rl.Title = title;
                    rl.Date = bDr["reg_date"].ToString();
                    rl.Nos = Convert.ToInt32(bDr["nOs"]);
                    rl.Tprice = Convert.ToInt32(bDr["s_price"]);
                    rl.Fprice = Convert.ToInt32(bDr["f_price"]);
                    rl.Pprice = Convert.ToInt32(bDr["p_price"]);


                    if (title.Length > 0)
                    {
                        flowLayoutPanel1.Controls.Add(rl);
                        label1.Visible = false;
                    }
                }
                con.Close();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
