using FontAwesome.Sharp;
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
    public partial class History : Form
    {
        public History()
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
        private void iconButton1_Click(object sender, EventArgs e)
        {
            iconButton1.Visible = false;
            iconButton2.Visible = false;
            iconButton4.Visible = true;

            panel2.Visible = true;
            panel2.Dock = DockStyle.Fill;
            openForm(new ProjectForms.RegisteredHistory());
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            openForm(new ProjectForms.OrganizedHistory());
            iconButton1.Visible = false;
            iconButton2.Visible = false;
            iconButton4.Visible = true;

            panel2.Visible = true;
            panel2.Dock = DockStyle.Fill;
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            iconButton1.Visible = true;
            iconButton2.Visible = true;
        }
    }
}
