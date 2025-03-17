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
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void apperanceButton_Click(object sender, EventArgs e)
        {

        }
        private Form currentForm;
        private void openForm(Form newForm)
        {
            if (currentForm != null)
            {
                currentForm.Close();
            }
            currentForm = newForm;
            currentForm.TopLevel = false;
            currentForm.FormBorderStyle = FormBorderStyle.None;
            currentForm.Dock = DockStyle.Fill;
            this.mainSettingPanel.Controls.Add(newForm);
            newForm.BringToFront();
            newForm.Show();
        }

        private void appearanceButton_Click(object sender, EventArgs e)
        {
            
        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }

        private void mainSettingPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            openForm(new ProjectForms.AddBalance());
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            openForm(new ProjectForms.PersonalInfo());
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            openForm(new ProjectForms.Security());
        }
    }
}
