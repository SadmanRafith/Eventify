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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography;
using System.Windows.Controls;

namespace Eventify.ProjectForms
{
    public partial class AddBalance : Form
    {
        public AddBalance()
        {
            InitializeComponent();
        }

        int balance, amount;
        private void AddBalance_Load(object sender, EventArgs e)
        {
            label3.Text = getBalance() + "BDT";
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Codings\C# Project\Eventify\Database\EVENTIFY.mdf"";Integrated Security=True;Connect Timeout=30");

        int cid;

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private int getBalance()
        {
            int balance = 0;
            con.Open();
            SqlCommand sc1 = new SqlCommand("Select balance from AppUser where uId =" + SignInForm.ID, con);
            SqlDataReader dr = sc1.ExecuteReader();
            if (dr.Read())
            {
                balance = Convert.ToInt32(dr["balance"]);
            }
            con.Close();
            return balance;
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select balance from AppUser WHERE uId =" + SignInForm.ID, con);
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                balance = Convert.ToInt32(r["balance"]);
            }
            con.Close();

            string code = textBox1.Text;
            if(code.Length == 8)
            {
                string c1 = (code.Substring(0, 3) + " - " + code.Substring(3, 2) + " - " + code.Substring(5, 3)).ToString();
                int m = 0;
                con.Open();
                SqlCommand sq = new SqlCommand("select * from Card", con);
                SqlDataReader dr = sq.ExecuteReader();
                while (dr.Read())
                {
                    string card = dr["cardNumber"].ToString();
                    if (card == c1)
                    {
                        m = 1;
                        cid = Convert.ToInt32(dr["Id"]);
                        break;
                    }
                }
                con.Close();
                if (m == 0)
                {
                    MessageBox.Show("Invalid number or the card have been used", "Massage", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    con.Open();
                    SqlCommand sq1 = new SqlCommand("delete from Card where Id =" + cid, con);
                    sq1.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Recharge successfull. 500 BDT added to your account", "Massage", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    amount = 500;
                    con.Open();
                    SqlCommand sq3 = new SqlCommand("Update AppUser set balance = @balance where uId =" + SignInForm.ID, con);
                    sq3.Parameters.AddWithValue("@balance", Convert.ToInt32(balance + amount));
                    sq3.ExecuteNonQuery();
                    con.Close();
                    label3.Text = (balance + amount) + "BDT";
                }
            }
            else if(code.Length == 9)
            {
                string c1 = code.Substring(0, 3) + " - " + code.Substring(3, 3) + " - " + code.Substring(6, 3);
                int m = 0;
                con.Open();
                SqlCommand sq = new SqlCommand("select * from Card", con);
                SqlDataReader dr = sq.ExecuteReader();
                while (dr.Read())
                {
                    string card = dr["cardNumber"].ToString();
                    if (card == c1)
                    {
                        m = 1;
                        cid = Convert.ToInt32(dr["Id"]);
                        break;
                    }
                }
                con.Close();
                if (m == 0)
                {
                    MessageBox.Show("Invalid number or the card have been used", "Massage", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    con.Open();
                    SqlCommand sq2 = new SqlCommand("delete from Card where Id =" + cid, con);
                    sq2.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Recharge successfull. 1000 BDT added to your account", "Massage", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    amount = 1000;
                    con.Open();
                    SqlCommand sq4 = new SqlCommand("Update AppUser set balance = @balance where uId =" + SignInForm.ID, con);
                    sq4.Parameters.AddWithValue("@balance", Convert.ToInt32(balance + amount));
                    sq4.ExecuteNonQuery();
                    con.Close();
                    label3.Text = (balance + amount) + "BDT";
                }
            }
            else
            {
                MessageBox.Show("Invalid code");
            }


            
        }
        
    }
}
