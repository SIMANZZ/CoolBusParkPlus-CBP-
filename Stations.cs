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
    public partial class Stations : Form
    {

        SQLiteConnection DB;
        SQLiteCommand CMD;
        DataTable StationsTable;
        public Stations()
        {
            InitializeComponent();
            KeyPreview = true;
            KeyDown += (s, e) => { if (e.KeyValue == (char)Keys.Enter) AddButton_Click(AddButton, null); };
            KeyDown += (s, e) => { if (e.KeyValue == (char)Keys.Escape) ExitButton_Click(ExitButton, null); };
        }

        private void Stations_Load(object sender, EventArgs e)
        {
            //Connect to Drivers Table
            DB = new SQLiteConnection("Data Source = CBP.sqlite; Version = 3; FailIfMissing = false");

            CMD = new SQLiteCommand();
            CMD.Connection = DB;

            DB.Open();

            StationsTable = new DataTable();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            string TempString = "";
            for(int i = 0; i<NameBox.Text.Length; i++)
            {
                if(i == 0)
                {
                    TempString += NameBox.Text[i].ToString().ToUpper();
                }
                else
                {
                    TempString += NameBox.Text[i].ToString();
                }
            }
            CMD.CommandText = "INSERT INTO BusStations (Название, Маршруты) VALUES (@Name, @Routes)";
            CMD.Parameters.AddWithValue("@Name", TempString);
            CMD.Parameters.AddWithValue("@Routes", RoutesBox.Text);
            StationsTable.Clear();
            StationsTable.Load(CMD.ExecuteReader());
            MessageBox.Show("Новая остановка успешно добавлена");
            this.Close();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RoutesBox_Enter(object sender, EventArgs e)
        {
            if (RoutesBox.Text == "107,104,105")
            {
                RoutesBox.Text = "";
                RoutesBox.ForeColor = Color.Black;
            }
        }

        private void RoutesBox_Leave(object sender, EventArgs e)
        {
            if (RoutesBox.Text == "")
            {
                RoutesBox.Text = "107,104,105";
                RoutesBox.ForeColor = Color.Silver;
            }
        }

        private void NameBox_Enter(object sender, EventArgs e)
        {
            if (NameBox.Text == "колягино")
            {
                NameBox.Text = "";
                NameBox.ForeColor = Color.Black;
            }
        }

        private void NameBox_Leave(object sender, EventArgs e)
        {
            if (NameBox.Text == "")
            {
                NameBox.Text = "колягино";
                NameBox.ForeColor = Color.Silver;
            }
        }

        private void Stations_FormClosing(object sender, FormClosingEventArgs e)
        {
            DB.Close();
        }
    }
}
