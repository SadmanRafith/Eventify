using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eventify
{
    public partial class LoadingScreen : Form
    {
        public LoadingScreen()
        {
            InitializeComponent();
        }
        private void LoadingScreen_Load(object sender, EventArgs e)
        {
            
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width += 10;
            if(panel2.Width >= 200) 
            {
                MainForm m = new MainForm();
                timer1.Stop();
                this.Visible = false;
                m.Visible = true;  
            }
        }

        
    }
}
