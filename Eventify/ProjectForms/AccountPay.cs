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
    public partial class AccountPay : Form
    {
        public AccountPay()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Codings\C# Project\Eventify\Database\EVENTIFY.mdf"";Integrated Security=True;Connect Timeout=30");

        int balance = 0;
        int total = AllEventList.TOTAL;
        
        private void AccountPay_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select balance from AppUser Where uId =" + SignInForm.ID, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read()) { balance = Convert.ToInt32(dr["balance"]); }
            con.Close();
            iconButton1.Text = balance.ToString();
            iconButton3.Text = total.ToString();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            if (balance<total)
            {
                MessageBox.Show("Insufficient balance", "AccountPay", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                PaymentOptions paymentOptions = new PaymentOptions();
                paymentOptions.Visible = true;
                this.Visible = false;

            }
            else
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("update AppUser set balance = @balance where uId =" + AllEventList.UserID , con);
                cmd1.Parameters.AddWithValue("@balance", balance-total);
                cmd1.ExecuteNonQuery();
                con.Close();

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
                sq4.Parameters.AddWithValue("@price", total);
                sq4.Parameters.AddWithValue("@nOs", AllEventList.NumberOfSeats);
                sq4.Parameters.AddWithValue("@reg_date", DateTime.Now.ToString());
                sq4.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Event registered successfully", "Massage", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Visible = false;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            PaymentOptions paymentOptions = new PaymentOptions();
            paymentOptions.Visible = true;
            this.Visible = false;
        }
    }
}
