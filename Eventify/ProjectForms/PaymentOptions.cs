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
    public partial class PaymentOptions : Form
    {
        public PaymentOptions()
        {
            InitializeComponent();
        }

        private void PaymentOptions_Load(object sender, EventArgs e)
        {

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
            ProjectForms.AccountPay ap =new ProjectForms.AccountPay();
            ap.Visible = true;
            this.Visible = false;
            
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            ProjectForms.BkashPay bp = new ProjectForms.BkashPay();
            bp.Visible = true;
            this.Visible = false;
        }
    }
}
