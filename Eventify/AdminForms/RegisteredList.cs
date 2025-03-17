using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eventify.AdminForms
{
    public partial class RegisteredList : UserControl
    {
        public RegisteredList()
        {
            InitializeComponent();
        }
        string title, date;
        int nos, fprice, pprice, tprice;

        public string Title
        { get { return title; } set { label20.Text = value; } }
        public string Date
        { get { return date; } set { label21.Text = value; } }
        public int Nos
        { get { return nos; } set { label22.Text = value.ToString(); } }
        public int Fprice
        { get { return fprice; } set { label23.Text = value.ToString(); } }
        public int Pprice 
        { get { return pprice; } set { label24.Text = value.ToString(); } }
        public int Tprice
        { get { return tprice; } set { label25.Text = value.ToString(); } }

        private void RegisteredList_Load(object sender, EventArgs e)
        {

        }
    }
}
