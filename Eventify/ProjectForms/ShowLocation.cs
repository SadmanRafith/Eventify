using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Eventify.ProjectForms
{
    public partial class ShowLocation : Form
    {
        public ShowLocation()
        {
            InitializeComponent();
        }
        public ShowLocation(string district, string province, string country)
        {
            InitializeComponent();
            /*
            StringBuilder location = new StringBuilder("https://www.google.com/maps/dir/23.76726,90.421103/House+No.+373,"+ "Rajshahi" + ",+Dhaka+(%E0%A6%B0%E0%A6%BE%E0%A6%9C%E0%A6%B6%E0%A6%BE%E0%A6%B9%E0%A7%80+%E0%A6%AC%E0%A6%BF%E0%A6%B6%E0%A7%8D%E0%A6%AC%E0%A6%AC%E0%A6%BF%E0%A6%A6%E0%A7%8D%E0%A6%AF%E0%A6%BE%E0%A6%B2%E0%A7%9F+%E0%A6%85%E0%A6%A4%E0%A6%BF%E0%A6%A5%E0%A6%BF+%E0%A6%AD%E0%A6%AC%E0%A6%A8,+%E0%A6%A2%E0%A6%BE%E0%A6%95%E0%A6%BE),+12+Free+School+St,+Dhaka+1205/@23.7571057,90.3964314,15z/data=!3m1!4b1!4m9!4m8!1m1!4e1!1m5!1m1!1s0x3755b95108f87909:0xf0950c53bce7e949!2m2!1d90.3916553!2d23.7458587?entry=ttu");
            //if (district !=""){
                location.Append("Rajshahi" + "," + "+");
            //}
            //if (province !=""){
                location.Append("Rajshahi" + "," + "+");
            //}
            //if (country !=""){
                location.Append("Bangladesh" + "," + "+");
            //}
            webBrowser1.Navigate(location.ToString());
            */
        }

        private void ShowLocation_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
