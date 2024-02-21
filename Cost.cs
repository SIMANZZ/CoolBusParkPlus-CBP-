using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Data.SQLite;

namespace CBP
{
    public partial class Cost : Form
    {
        public Cost()
        {
            InitializeComponent();
            KeyPreview = true;
            KeyDown += (s, e) => { if (e.KeyValue == (char)Keys.Enter) YesButton_Click(YesButton, null); };
            KeyDown += (s, e) => { if (e.KeyValue == (char)Keys.Escape) ExitButton_Click(ExitButton, null); };
        }

        private void Cost_Load(object sender, EventArgs e)
        {
            CostLabel.Text = $"Итоговая стоимость равна {Flags.MainSum} BYN, вы согласны?";
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void YesButton_Click(object sender, EventArgs e)
        {
            Flags.Exit = true;
            Random rnd = new Random();
            int numberofticket = rnd.Next(100000, 999999);
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("CoolBusPark@gmail.com", "nqczgdniqtbvjjbi"),
                EnableSsl = true
            };

            var message = new MailMessage
            {
                From = new MailAddress("CoolBusPark@gmail.com"),
                Subject = "DreamBus Notification",
                Body = $"<p>Вы успешно купили билет в приложении DreamBus</p>" + $"<p>Номер вашего чека: {numberofticket}</p>" + $"",
                IsBodyHtml = true
            };
            message.To.Add(Flags.EmailSupport);

            smtpClient.Send(message);
            MessageBox.Show("Вы успешно купили билет, номер вашего чека отправлен на привязанный вами email");
            Flags.TicketNumber = numberofticket;
            this.Close();
        }
    }
}
