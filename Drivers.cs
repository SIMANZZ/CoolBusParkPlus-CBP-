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
    public partial class Drivers : Form
    {
        SQLiteConnection DB;
        SQLiteCommand CMD;
        DataTable DriversTable, ComboTable;
        public Drivers()
        {
            InitializeComponent();
            KeyPreview = true;
            KeyDown += (s, e) => { if (e.KeyValue == (char)Keys.Enter) AddButton_Click(AddButton, null); };
            KeyDown += (s, e) => { if (e.KeyValue == (char)Keys.Escape) ExitButton_Click(ExitButton, null); };
        }

        private void Drivers_Load(object sender, EventArgs e)
        {
            //Connect to Drivers Table
            DB = new SQLiteConnection("Data Source = CBP.sqlite; Version = 3; FailIfMissing = false");

            CMD = new SQLiteCommand();
            CMD.Connection = DB;

            DB.Open();

            DriversTable = new DataTable();

            ComboTable = new DataTable();

            CMD.CommandText = "SELECT [Индивидуальный номер] FROM Buses";
            FixedBuscomboBox.DataSource = ComboTable;
            ComboTable.Clear();
            ComboTable.Load(CMD.ExecuteReader());
            FixedBuscomboBox.DisplayMember= "Индивидуальный номер";
        }

        private void Drivers_FormClosing(object sender, FormClosingEventArgs e)
        {
            DB.Close();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if(int.TryParse(DriverExpirienceBox.Text,out var parsedNumber))
            {
                CMD.CommandText = "INSERT INTO Drivers (ФИО,[Закреплённый автобус],[Стаж вождения]) " +
                    "VALUES (@LFP, (SELECT ID FROM Buses WHERE [Индивидуальный номер] = @IndividualNumber), " +
                    "@DriverExpirience)";
                CMD.Parameters.AddWithValue("@LFP", LFPBox.Text);
                CMD.Parameters.AddWithValue("@IndividualNumber", FixedBuscomboBox.Text.ToString());
                CMD.Parameters.AddWithValue("@DriverExpirience", DriverExpirienceBox.Text);
                DriversTable.Clear();
                DriversTable.Load(CMD.ExecuteReader());
                MessageBox.Show("Новый водитель успешно добавлен");
                this.Close();
            }
            else
            {
                MessageBox.Show("Неправельно введён стаж");
            }
        }

        private void LFPBox_Enter(object sender, EventArgs e)
        {
            if (LFPBox.Text == "Пупкин Иван Фёдорович")
            {
                LFPBox.Text = "";
                LFPBox.ForeColor = Color.Black;
            }
        }

        private void LFPBox_Leave(object sender, EventArgs e)
        {
            if (LFPBox.Text == "")
            {
                LFPBox.Text = "Пупкин Иван Фёдорович";
                LFPBox.ForeColor = Color.Silver;
            }
        }

        private void DriverExpirienceBox_Enter(object sender, EventArgs e)
        {
            if (DriverExpirienceBox.Text == "5")
            {
                DriverExpirienceBox.Text = "";
                DriverExpirienceBox.ForeColor = Color.Black;
            }
        }

        private void DriverExpirienceBox_Leave(object sender, EventArgs e)
        {
            if (DriverExpirienceBox.Text == "")
            {
                DriverExpirienceBox.Text = "5";
                DriverExpirienceBox.ForeColor = Color.Silver;
            }
        }
    }
}
