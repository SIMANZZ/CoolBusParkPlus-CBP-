using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace CBP
{
    public partial class SplashForm : Form
    {
        Thread th;
        private static System.Timers.Timer aTimer;
        public SplashForm()
        {
            InitializeComponent();
        }

        private void SplashForm_Load(object sender, EventArgs e)
        {
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += ShowSplashForm;
            aTimer.AutoReset= false;
            aTimer.Enabled = true;
        }

        private void ShowSplashForm(object sender, EventArgs e)
        {
            aTimer.Dispose();
            this.Close();
            th = new Thread(Opennewform);
            th.SetApartmentState(ApartmentState.STA);
            th.Start(); 
        }
        private void Opennewform(object sender)
        {
            Application.Run(new EnterForm());
        }
    }
}
