using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eventify.AdminForms
{
    public partial class MainAdminForm : Form
    {
        public MainAdminForm()
        {
            InitializeComponent();
        }

        int randomCode;
        private Color selectThemeColor()
        {
            Random rand = new Random();
            randomCode = (rand.Next(1,9));
            string color = ThemeColor.ColorList[randomCode];
            return ColorTranslator.FromHtml(color);
        }
        IconButton currentButton;
        Color c;
        private void enableButton(object btn)
        {
            if (btn != null)
            {
                disableButton();
                Color color = selectThemeColor();
                c = color;
                currentButton = (IconButton)btn;
                currentButton.BackColor = color;
                currentButton.ForeColor = Color.Gainsboro;
                this.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                panel2.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
            }
        }
        private void disableButton()
        {
            if (currentButton != null)
            {
                currentButton.BackColor = Color.FromArgb(51, 51, 76);
                currentButton.ForeColor = Color.Gainsboro;
            }
        }
        private void MainAdminForm_Load(object sender, EventArgs e)
        {
            Color color = selectThemeColor();
            c = color;
            iconButton1.BackColor = color;
            iconButton1.ForeColor = Color.Gainsboro;
            panel2.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
            iconButton1.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
            openForm(new AdminForms.UserForm());
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
            openForm(new AdminForms.UserForm());
            enableButton(sender);
            iconButton2.BackColor = Color.FromArgb(51, 51, 76);
            iconButton3.BackColor = Color.FromArgb(51, 51, 76);
            iconButton5.BackColor = Color.FromArgb(51, 51, 76);
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            openForm(new AdminForms.EventForm());
            enableButton(sender);
            iconButton1.BackColor = Color.FromArgb(51, 51, 76);
            iconButton3.BackColor = Color.FromArgb(51, 51, 76);
            iconButton5.BackColor = Color.FromArgb(51, 51, 76);
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            openForm(new AdminForms.GenerateCards());
            enableButton(sender);
            iconButton2.BackColor = Color.FromArgb(51, 51, 76);
            iconButton1.BackColor = Color.FromArgb(51, 51, 76);
            iconButton5.BackColor = Color.FromArgb(51, 51, 76);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private static extern void ReleseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            SignInForm signInForm = new SignInForm();
            signInForm.Visible = true;
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            openForm(new AdminForms.AddAdmin());
            enableButton(sender);
            iconButton2.BackColor = Color.FromArgb(51, 51, 76);
            iconButton1.BackColor = Color.FromArgb(51, 51, 76);
            iconButton3.BackColor = Color.FromArgb(51, 51, 76);
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {

        }
    }
}
