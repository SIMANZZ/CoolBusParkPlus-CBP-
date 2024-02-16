using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace CBP
{
    public partial class UserForm : Form
    {
        Thread th;

        SQLiteConnection DB;
        SQLiteCommand CMD;
        DataTable CostTable;

        int ID;
        string email;
        double Ticket;
        double TicketExpress;
        int TravelCard;
        int TravelCardExpress;
        enum BusesType
        {
            BusExpress,
            Bus,
        }

        Enum EnumBuses;
        public UserForm()
        {
            InitializeComponent();
            KeyPreview = true;
            KeyDown += (s, e) => { if (e.KeyValue == (char)Keys.Escape) выходToolStripMenuItem_Click(выходToolStripMenuItem,null); };
        }

        private void UserForm_Load(object sender, EventArgs e)
        {

            DB = new SQLiteConnection("Data Source = CBP.sqlite; Version = 3; FailIfMissing = false");

            CMD = new SQLiteCommand();
            CMD.Connection = DB;

            DB.Open();

            CMD.CommandText = "SELECT ID FROM Users WHERE login = @login";
            CMD.Parameters.AddWithValue("@login", Flags.CurrentLogin);

            ID = int.Parse(CMD.ExecuteScalar().ToString());

            CMD.CommandText = "SELECT [Номер чека],[Вид автобуса],[Вид документа],Количество, Стоимость FROM Tickets WHERE UserID = @ID";
            CMD.Parameters.AddWithValue("@ID", ID);

            CostTable = new DataTable();
            CostGrid.DataSource = CostTable;

            CostTable.Clear();
            CostTable.Load(CMD.ExecuteReader());

            CMD.CommandText = $"SELECT email FROM Users WHERE ID = {ID}";
            email = CMD.ExecuteScalar().ToString();
            Flags.EmailSupport = email;

            LoginLabel.Text = Flags.CurrentLogin;
            MailLabel.Text = email;

            //Work with txt
            FileInfo fileinfo = new FileInfo("Costs.txt");
            if (fileinfo.Exists)
            {
                string[] filetext = File.ReadAllLines(fileinfo.FullName);
                Ticket = double.Parse(filetext[0]);
                TicketExpress = double.Parse(filetext[1]);
                TravelCard = int.Parse(filetext[2]);
                TravelCardExpress = int.Parse(filetext[3]);
            }
            else
            {
                File.WriteAllLines(fileinfo.FullName, new[] { "0,90", "1,05", "25","32"});
            }
            TravelNumberBox.Visible= false;

            CMD.CommandText = "SELECT [Номер чека],[Вид автобуса],[Вид документа],Количество, Стоимость FROM Tickets WHERE UserID = @ID";
            CMD.Parameters.AddWithValue("@ID", ID);
            CostTable.Clear();
            CostTable.Load(CMD.ExecuteReader());
        }

        private void мойАккаунтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabControl.SelectedTab = MyAccountTab;
        }

        private void заказатьБилетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabControl.SelectedTab = OrderTicketTab;
        }
        private void ChangeData_Click(object sender, EventArgs e)
        {
            ChangeData changedata = new ChangeData();
            changedata.ShowDialog();
            CMD.CommandText = $"SELECT email FROM Users WHERE ID = {ID}";
            MailLabel.Text = CMD.ExecuteScalar().ToString();
            CMD.CommandText = $"SELECT login FROM Users WHERE ID = {ID}";
            LoginLabel.Text = CMD.ExecuteScalar().ToString();
        }

        private void UserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DB.Close();
        }

        private void моиБилетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabControl.SelectedTab = MyTickets;
            CMD.CommandText = "SELECT [Номер чека],[Вид автобуса],[Вид документа],Количество, Стоимость FROM Tickets WHERE UserID = @ID";
            CMD.Parameters.AddWithValue("@ID", ID);
            CostTable.Clear();
            CostTable.Load(CMD.ExecuteReader());
        }

        private void OrderTicket_Click(object sender, EventArgs e)
        {
            int sum = 0;
            double doublesum = 0;
            if(TravelNumberBox.Text == "количество поездок" && TravelCardscomboBox.SelectedIndex == 1)
            {
                MessageBox.Show("Введите количество поездок");
            }
            else
            {
                if(int.TryParse(TravelNumberBox.Text,out var parsedNumber) || TravelCardscomboBox.SelectedIndex == 0)
                {
                    CMD.CommandText = "INSERT INTO Tickets ([Номер чека],[Вид автобуса],[Вид документа],Количество, Стоимость, UserID) VALUES (@NumberOfTicket, @TypeOfBus, @TypeOfDocument, @Numbers, @Cost, @ID)";
                    CMD.Parameters.AddWithValue("@ID", ID);
                    if (BusRadioButton.Checked)
                    {
                        EnumBuses = BusesType.Bus;
                    }
                    else if (BusExpressRadioButton.Checked)
                    {
                        EnumBuses = BusesType.BusExpress;
                    }
                    switch (EnumBuses)
                    {
                        case BusesType.Bus:
                            CMD.Parameters.AddWithValue("@TypeOfBus", "Автобус");
                            if (TravelCardscomboBox.SelectedIndex == 0) 
                            { 
                                sum = TravelCard; Flags.MainSum = sum;
                                CMD.Parameters.AddWithValue("@TypeOfDocument", "Проездной на месяц");
                                CMD.Parameters.AddWithValue("@Numbers", 1);
                                CMD.Parameters.AddWithValue("@Cost", sum.ToString());
                            }
                            else 
                            { 
                                doublesum = Ticket * double.Parse(TravelNumberBox.Text); Flags.MainSum = doublesum;
                                CMD.Parameters.AddWithValue("@TypeOfDocument", "Поездки");
                                CMD.Parameters.AddWithValue("@Numbers", int.Parse(TravelNumberBox.Text));
                                CMD.Parameters.AddWithValue("@Cost", doublesum.ToString());
                            }
                            break;
                        case BusesType.BusExpress:
                            CMD.Parameters.AddWithValue("@TypeOfBus", "Автобус-экспресс");
                            if (TravelCardscomboBox.SelectedIndex == 0) 
                            { 
                                sum = TravelCardExpress; Flags.MainSum = sum;
                                CMD.Parameters.AddWithValue("@TypeOfDocument", "Проездной на месяц");
                                CMD.Parameters.AddWithValue("@Numbers", 1);
                                CMD.Parameters.AddWithValue("@Cost", sum.ToString());
                            }
                            else 
                            { 
                                doublesum = TicketExpress * double.Parse(TravelNumberBox.Text); Flags.MainSum = doublesum;
                                CMD.Parameters.AddWithValue("@TypeOfDocument", "Поездки");
                                CMD.Parameters.AddWithValue("@Numbers", int.Parse(TravelNumberBox.Text));
                                CMD.Parameters.AddWithValue("@Cost", doublesum.ToString());
                            }
                            break;
                    }
                    
                    Cost cost = new Cost();
                    cost.ShowDialog();

                    if (Flags.Exit)
                    {
                        CMD.Parameters.AddWithValue("@NumberOfTicket", Flags.TicketNumber);
                        CostTable.Clear();
                        CostTable.Load(CMD.ExecuteReader());

                        CMD.CommandText = "SELECT [Номер чека],[Вид автобуса],[Вид документа],Количество, Стоимость FROM Tickets WHERE UserID = @ID";
                        CMD.Parameters.AddWithValue("@ID", ID);
                        CostTable.Clear();
                        CostTable.Load(CMD.ExecuteReader());
                    }
                }
                else
                {
                    if(TravelNumberBox.Visible == true)
                    {
                        MessageBox.Show("Количество поездок должно быть числом");
                    } 
                }
            }
        }

        private void TravelNumber_Enter(object sender, EventArgs e)
        {
            if (TravelNumberBox.Text == "количество поездок")
            {
                TravelNumberBox.Text = "";
                TravelNumberBox.ForeColor = Color.Black;
            }
        }

        private void TravelNumber_Leave(object sender, EventArgs e)
        {
            if (TravelNumberBox.Text == "")
            {
                TravelNumberBox.Text = "количество поездок";
                TravelNumberBox.ForeColor = Color.Silver;
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(OpenForm1);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void OpenForm1(object sender)
        {
            Application.Run(new EnterForm());
        }

        private void TravelCardscomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(TravelCardscomboBox.SelectedIndex == 1) { TravelNumberBox.Visible = true; }
            else { TravelNumberBox.Visible = false; }
        }
    }
}
