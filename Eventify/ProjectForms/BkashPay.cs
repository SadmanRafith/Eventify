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
    public partial class BkashPay : Form
    {
        public BkashPay()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Codings\C# Project\Eventify\Database\EVENTIFY.mdf"";Integrated Security=True;Connect Timeout=30");

        private void iconButton2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length == 11)
            {
                iconButton2.Visible = false;
                iconButton1.Visible = true;
                textBox1.Visible = false;
                textBox2.Visible = true;
                label1.Text = "Enter Pin No";
            }
            else
            {
                MessageBox.Show("Invalid Phone number");
            }
        }

        private void BkashPay_Load(object sender, EventArgs e)
        {
            label2.Text = "Total amount " + AllEventList.TOTAL;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand sqU = new SqlCommand("update Event set registerd_seats = @registerd_seats WHERE eId =" + AllEventList.EventID, con);
            sqU.Parameters.AddWithValue("@registerd_seats", AllEventList.USERS);
            sqU.ExecuteNonQuery();
            con.Close();

            con.Open();
            SqlCommand sq4 = new SqlCommand("insert into Register(uId ,eId, f_price, p_price, s_price, price, nOs, reg_date) values(@uId, @eId,  @f_price, @p_price, @s_price, @price, @nOs, @reg_date)", con);
            sq4.Parameters.AddWithValue("@uId", AllEventList.UserID);
            sq4.Parameters.AddWithValue("@eId", AllEventList.EventID);
            sq4.Parameters.AddWithValue("@p_price", AllEventList.ParkingPrice);
            sq4.Parameters.AddWithValue("@f_price", AllEventList.FoodPrice);
            sq4.Parameters.AddWithValue("@s_price", AllEventList.SeatPrice);
            sq4.Parameters.AddWithValue("@price", AllEventList.TOTAL);
            sq4.Parameters.AddWithValue("@nOs", AllEventList.NumberOfSeats);
            sq4.Parameters.AddWithValue("@reg_date", DateTime.Today.ToString());
            sq4.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Event registered successfully");
            this.Visible = false;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            PaymentOptions paymentOptions = new PaymentOptions();
            paymentOptions.Visible = true;
            this.Visible = false;
        }
    }
}
