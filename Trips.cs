using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CBP
{
    public partial class Trips : Form
    {
        SQLiteConnection DB;
        SQLiteCommand CMD;
        DataTable DriversTable, RoutesTable;
        public Trips()
        {
            InitializeComponent();
            KeyPreview = true;
            KeyDown += (s, e) => { if (e.KeyValue == (char)Keys.Enter) AddButton_Click(AddButton, null); };
            KeyDown += (s, e) => { if (e.KeyValue == (char)Keys.Escape) ExitButton_Click(ExitButton, null); };
        }

        private void Trips_Load(object sender, EventArgs e)
        {
            //Connect to Drivers Table
            DB = new SQLiteConnection("Data Source = CBP.sqlite; Version = 3; FailIfMissing = false");

            CMD = new SQLiteCommand();
            CMD.Connection = DB;

            DB.Open();

            DriversTable = new DataTable();

            RoutesTable = new DataTable();

            CMD.CommandText = "SELECT ФИО FROM Drivers";
            DriversComboBox.DataSource = DriversTable;
            DriversTable.Clear();
            DriversTable.Load(CMD.ExecuteReader());
            DriversComboBox.DisplayMember = "ФИО";

            CMD.CommandText = "SELECT [Номер маршрута] FROM Routes";
            RoutesComboBox.DataSource = RoutesTable;
            RoutesTable.Clear();
            RoutesTable.Load(CMD.ExecuteReader());
            RoutesComboBox.DisplayMember = "Номер маршрута";
        }

        private void Trips_FormClosing(object sender, FormClosingEventArgs e)
        {
            DB.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            CMD.CommandText = "INSERT INTO Trips (Водитель,Маршрут,Дата) VALUES ((SELECT ID FROM Drivers WHERE ФИО = @Driver), " +
                "(SELECT ID FROM Routes WHERE [Номер маршрута] = @Route), @Date)";
            CMD.Parameters.AddWithValue("@Driver", DriversComboBox.Text);
            CMD.Parameters.AddWithValue("@Route", RoutesComboBox.Text);
            CMD.Parameters.AddWithValue("@Date", Calendar.Text);
            RoutesTable.Clear();
            RoutesTable.Load(CMD.ExecuteReader());
            MessageBox.Show("Новый рейс успешно добавлен");
            this.Close();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
