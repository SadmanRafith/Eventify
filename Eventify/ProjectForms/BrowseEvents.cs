using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eventify.ProjectForms
{
    public partial class BrowseEvents : Form
    {
        public BrowseEvents()
        {
            InitializeComponent();
        }

        private Form currentForm;
        public void openForm(Form newForm)
        {
            if (currentForm != null)
            {
                currentForm.Close();
            }
            currentForm = newForm;
            currentForm.TopLevel = false;
            currentForm.FormBorderStyle = FormBorderStyle.None;
            currentForm.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(newForm);
            newForm.BringToFront();
            newForm.Show();
        }

        private void BrowseEvents_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            openForm(new ProjectForms.SearchBrowse());
        }

        int i = 0;

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Search events")
            {
                textBox1.Text = "";
            }
            i = 6;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Search events";
            }
            i = 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string option = "";
            if (comboBox1.SelectedIndex == 0)
            {
                option = "title";
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                option = "category";
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                option = "date";
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                option = "organizer";
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                option = "city";
            }
            string text = textBox1.Text;
            if (i == 6)
            {
                if (textBox1.Focused || textBox1.Text == "")
                {
                    text = textBox1.Text;
                    openForm(new ProjectForms.SearchBrowse(option, text));
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
