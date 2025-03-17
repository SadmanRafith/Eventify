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
    public partial class OrganizedHistory : Form
    {
        public OrganizedHistory()
        {
            InitializeComponent();
        }

        private void OrganizedHistory_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void GetData()
        {
            SqlConnection bCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Codings\C# Project\Eventify\Database\EVENTIFY.mdf"";Integrated Security=True;Connect Timeout=30");
            int[] regE = new int[500];
            int i = 0;
            bCon.Open();
            SqlCommand selE = new SqlCommand("select eId from Organize where uId = " + SignInForm.ID, bCon);
            SqlDataReader dr1 = selE.ExecuteReader();
            while (dr1.Read())
            {
                regE[i++] = Convert.ToInt32(dr1["eId"]); ;
            }
            bCon.Close();
            foreach (int eid in regE)
            {
                bCon.Open();
                SqlCommand bSq = new SqlCommand("select display, title, category, date, venue, eId, e_status from Event Where eId =" + eid, bCon); ;
                SqlDataReader bDr = bSq.ExecuteReader();
                while (bDr.Read())
                {
                    long len = bDr.GetBytes(0, 0, null, 0, 0);
                    byte[] array = new byte[System.Convert.ToInt32(len) + 1];
                    bDr.GetBytes(0, 0, array, 0, System.Convert.ToInt32(len));
                    MemoryStream memoryStream = new MemoryStream(array);
                    Bitmap bitmap = new Bitmap(memoryStream);


                    HistoryList historyList = new HistoryList();
                    historyList.ID = Convert.ToInt32(bDr["eId"]);
                    historyList.TITLE1 = bDr["title"].ToString();
                    historyList.CATEGORY1 = bDr["category"].ToString();
                    historyList.DATE1 = bDr["date"].ToString();
                    historyList.VENUE1 = bDr["venue"].ToString();
                    historyList.ESTATUS = bDr["e_status"].ToString();

                    historyList.DISPLAY = bitmap;
                    if (historyList.TITLE1.Length > 0)
                    {
                        if (historyList.ESTATUS == "expired")
                        {
                            flowLayoutPanel1.Controls.Add(historyList);
                            label1.Visible = false;
                        }
                    }
                }
                bCon.Close();
            }
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
