using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Timers;

namespace CBP
{
    public partial class EnterForm : Form
    {
        System.Windows.Forms.Timer timer;
        Thread th;
 
        public EnterForm()
        {
            InitializeComponent();

            timer = new System.Windows.Forms.Timer() { Interval = 1000 };
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            toolStripText.Text = "Текущие дата и время:";
            toolStripDate.Text = DateTime.Now.ToLongDateString();
            toolStripTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void Enter_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(Opennewform);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void Opennewform(object sender)
        {
            Application.Run(new Login());
        }

        private void AboutApp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Приложение разработано учащимся учебной группы 52ТП Симаченко Антоном МГКЦТ 2024");
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpForm helpform = new HelpForm();
            helpform.ShowDialog();
        }

        private void графикToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Chart chart = new Chart();
            chart.ShowDialog();
        }
    }
}
