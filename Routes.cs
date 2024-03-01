using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace CBP
{
    public partial class Routes : Form
    {
        SQLiteConnection DB;
        SQLiteCommand CMD;
        DataTable RoutesTable, BusStationsStartTable, BusStationsEndTable;
        public Routes()
        {
            InitializeComponent();
            KeyPreview = true;
            KeyDown += (s, e) => { if (e.KeyValue == (char)Keys.Enter) AddButton_Click(AddButton, null); };
            KeyDown += (s, e) => { if (e.KeyValue == (char)Keys.Escape) ExitButton_Click(ExitButton, null); };
        }
        private void Routes_Load(object sender, EventArgs e)
        {
            //Connect to Routes Table
            DB = new SQLiteConnection("Data Source = CBP.sqlite; Version = 3; FailIfMissing = false");

            CMD = new SQLiteCommand();
            CMD.Connection = DB;

            DB.Open();

            RoutesTable = new DataTable();

            BusStationsStartTable = new DataTable(); BusStationsEndTable = new DataTable();

            CMD.CommandText = $"SELECT Название FROM StationsNames";
            BusStationsStartComboBox.DataSource = BusStationsStartTable;
            BusStationsStartTable.Clear();
            BusStationsStartTable.Load(CMD.ExecuteReader());
            BusStationsStartComboBox.DisplayMember = "Название";

            BusStationsEndComboBox.DataSource = BusStationsEndTable;
            BusStationsEndTable.Clear();
            BusStationsEndTable.Load(CMD.ExecuteReader());
            BusStationsEndComboBox.DisplayMember = "Название";
        }
        private void NumberOfRouteBox_Enter(object sender, EventArgs e)
        {
            if (NumberOfRouteBox.Text == "номер маршрута")
            {
                NumberOfRouteBox.Text = "";
                NumberOfRouteBox.ForeColor = Color.Black;
            }
        }

        private void NumberOfRouteBox_Leave(object sender, EventArgs e)
        {
            if (NumberOfRouteBox.Text == "")
            {
                NumberOfRouteBox.Text = "номер маршрута";
                NumberOfRouteBox.ForeColor = Color.Silver;
            }
        }

        private void NumberOfStationsBox_Enter(object sender, EventArgs e)
        {
            if (NumberOfStationsBox.Text == "количество остановок")
            {
                NumberOfStationsBox.Text = "";
                NumberOfStationsBox.ForeColor = Color.Black;
            }
        }

        private void NumberOfStationsBox_Leave(object sender, EventArgs e)
        {
            if (NumberOfStationsBox.Text == "")
            {
                NumberOfStationsBox.Text = "количество остановок";
                NumberOfStationsBox.ForeColor = Color.Silver;
            }
        }
        
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (NumberOfRouteBox.Text == "номер маршрута" || NumberOfStationsBox.Text == "количество остановок")
            {
                MessageBox.Show("Поля не могут быть пустыми");
            }
            else if (int.TryParse(NumberOfStationsBox.Text, out var parsedNumber))
            {
                CMD.CommandText = "INSERT INTO Routes ([Номер маршрута], [Количество остановок], [Начальная остановка], [Конечная остановка]) " +
                  "VALUES (@NumberOfRoute, @NumberOfStations, " +
                  "(SELECT ID FROM StationsNames WHERE Название = @StartStation), " +
                  "(SELECT ID FROM StationsNames WHERE Название = @EndStation))";
                CMD.Parameters.AddWithValue("@NumberOfRoute", NumberOfRouteBox.Text);
                CMD.Parameters.AddWithValue("@NumberOfStations", int.Parse(NumberOfStationsBox.Text));
                CMD.Parameters.AddWithValue("@StartStation", BusStationsStartComboBox.Text);
                CMD.Parameters.AddWithValue("@EndStation", BusStationsEndComboBox.Text);
                RoutesTable.Clear();
                RoutesTable.Load(CMD.ExecuteReader());
                MessageBox.Show("Новый маршрут успешно добавлен");
                this.Close();
            }
            else
            {
                MessageBox.Show("Количество остановок должно быть числом");
            }
        }

        private void Routes_FormClosing(object sender, FormClosingEventArgs e)
        {
            DB.Close();
        }
    }
}