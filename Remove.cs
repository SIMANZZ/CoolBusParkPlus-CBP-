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
    public partial class Remove : Form
    {
        SQLiteConnection DB;
        SQLiteCommand CMD;
        DataTable RemoveTable;
        public Remove()
        {
            InitializeComponent();
            KeyPreview = true;
            KeyDown += (s, e) => { if (e.KeyValue == (char)Keys.Enter) RemoveButton_Click(RemoveButton, null); };
            KeyDown += (s, e) => { if (e.KeyValue == (char)Keys.Escape) ExitButton_Click(ExitButton, null); };
        }

        private void Remove_Load(object sender, EventArgs e)
        {
            DB = new SQLiteConnection("Data Source = CBP.sqlite; Version = 3; FailIfMissing = false");

            CMD = new SQLiteCommand();
            CMD.Connection = DB;

            DB.Open();

            RemoveTable = new DataTable();
        }

        private void Remove_FormClosing(object sender, FormClosingEventArgs e)
        {
            DB.Close();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            string Table = "";
            if (int.TryParse(IdBox.Text,out var parseNumber))
            {
                if (Flags.RoutesFlag)
                {
                    Table = "Routes";
                }
                else if (Flags.BusesFlag)
                {
                    Table = "Buses";
                }
                else if (Flags.StationsFlag)
                {
                    Table = "BusStations";
                }
                else if (Flags.DriversFlag)
                {
                    Table = "Drivers";
                }
                else if (Flags.TripsFlag)
                {
                    Table = "Trips";
                }
                CMD.CommandText = $"DELETE FROM {Table} WHERE ID = {IdBox.Text}";
                RemoveTable.Clear();
                RemoveTable.Load(CMD.ExecuteReader());
                MessageBox.Show("Удаление прошло успешно");
                this.Close();
            }
            else
            {
                MessageBox.Show("id должно быть числом");
            }
        }

        private void IdBox_Enter(object sender, EventArgs e)
        {
            if (IdBox.Text == "id")
            {
                IdBox.Text = "";
                IdBox.ForeColor = Color.Black;
            }
        }

        private void IdBox_Leave(object sender, EventArgs e)
        {
            if (IdBox.Text == "")
            {
                IdBox.Text = "id";
                IdBox.ForeColor = Color.Silver;
            }
        }
    }
}
