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

namespace Eventify.AdminForms
{
    public partial class CardDataList : UserControl
    {
        public CardDataList()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Codings\C# Project\Eventify\Database\EVENTIFY.mdf"";Integrated Security=True;Connect Timeout=30");


        private int id, aid;
        private string no;

        public int ID
        { get { return id; } set {  id = value; label1.Text = id.ToString(); } }
        public string NO
        { get { return no; } set {  no = value; label2.Text = no.ToString(); } }

        public int AID
        { get { return aid; } set { aid = value; } }


        private void CardDataList_Load(object sender, EventArgs e)
        {
            string admin = "";
            con.Open();
            SqlCommand sqlCommand1 = new SqlCommand("Select name from Admin where aId =" + aid, con);
            SqlDataReader reader1 = sqlCommand1.ExecuteReader();
            if(reader1.Read())
            {
                admin = reader1["name"].ToString();
            }
            con.Close();

            label3.Text = admin.Remove(0,3);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
