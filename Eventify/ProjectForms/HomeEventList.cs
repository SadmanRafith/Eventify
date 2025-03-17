using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eventify.ProjectForms
{
    public partial class HomeEventList : UserControl
    {
        public HomeEventList()
        {
            InitializeComponent();
        }

        static int hid;
        string title, date, venue;
        int capacity, registred_seats;

        public string TITLE { get { return title; } set { title = value;  label8.Text = value; } }
        public string DATE { set { date = value; label7.Text = value;} }
        public string VENUE { set { venue = value; label6.Text = value; } }
        public int CAPACITY { set {  capacity = value; label10.Text = value.ToString();} }
        public int RS { set {  registred_seats = value;} }
        public int HID { set { hid = value; } }
        
        private void HomeEventList_Load(object sender, EventArgs e)
        {
            label9.Text = (capacity - registred_seats).ToString();
        }
    }
}
