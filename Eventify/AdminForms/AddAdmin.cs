using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eventify.AdminForms
{
    public partial class AddAdmin : Form
    {
        public AddAdmin()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Codings\C# Project\Eventify\Database\EVENTIFY.mdf"";Integrated Security=True;Connect Timeout=30");

        private void AddAdmin_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Admin", con);
            DataTable dt = new DataTable();
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            string pattern = @"[^a-zA-Z0-9\s]";
            Regex regex = new Regex(pattern);

            if (textBox1.Text == "" && textBox2.Text != "")
            {
                MessageBox.Show("Please enter username");
            }
            else if (textBox2.Text == "" && textBox1.Text != "")
            {
                MessageBox.Show("Please enter password");
            }
            else if (textBox1.Text == "" && textBox2.Text == "")
            {
                MessageBox.Show("Please enter username and password");
            }
            else
            {
                if (textBox2.Text.Length < 8)
                {
                    MessageBox.Show("Password must have at least 8 charecters.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (!textBox2.Text.Any(char.IsDigit))
                {
                    MessageBox.Show("Password must contain at least one digit.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (!regex.IsMatch(textBox2.Text))
                {
                    MessageBox.Show("Password must contain at least one Speacial Charecter.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int isAdmin = 0;
                    con.Open();
                    SqlCommand sq1 = new SqlCommand("Select * from Admin", con);
                    SqlDataReader dr1 = sq1.ExecuteReader();
                    while (dr1.Read())
                    {
                        string nameA = dr1["name"].ToString();

                        if (nameA == "aaa" + textBox1.Text)
                        {
                            isAdmin = 1;
                            break;
                        }
                    }
                    con.Close();

                    if (isAdmin == 1)
                    {
                        MessageBox.Show("Already an admin");
                    }
                    else
                    {
                        con.Open();
                        SqlCommand cmd2 = new SqlCommand("Insert into Admin(name, password) values (@name, @password)", con);
                        cmd2.Parameters.AddWithValue("@name", "aaa" + textBox1.Text);
                        cmd2.Parameters.AddWithValue("@password", textBox2.Text);
                        cmd2.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Admin added");
                        loadData();
                    }
                }

            }
        }
    }
}
