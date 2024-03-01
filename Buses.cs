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
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace CBP
{
    public partial class Buses : Form
    {

        SQLiteConnection DB;
        SQLiteCommand CMD;
        DataTable BusesTable, ModelsTable, ManufacturerTable;
        public Buses()
        {
            InitializeComponent();
            KeyPreview = true;
            KeyDown += (s, e) => { if (e.KeyValue == (char)Keys.Enter) AddButton_Click(AddButton, null); };
            KeyDown += (s, e) => { if (e.KeyValue == (char)Keys.Escape) ExitButton_Click(ExitButton, null); };
        }

        private void Buses_Load(object sender, EventArgs e)
        {
            //Connect to Buses Table
            DB = new SQLiteConnection("Data Source = CBP.sqlite; Version = 3; FailIfMissing = false");

            CMD = new SQLiteCommand();
            CMD.Connection = DB;

            DB.Open();

            BusesTable = new DataTable();

            ModelsTable = new DataTable();

            ManufacturerTable = new DataTable();

            CMD.CommandText = "SELECT DISTINCT Производитель FROM Manufacturers";
            ManufacturersComboBox.DataSource = ManufacturerTable;
            ManufacturerTable.Clear();
            ManufacturerTable.Load(CMD.ExecuteReader());
            ManufacturersComboBox.DisplayMember = "Производитель";
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            DateTime dDate = Calendar.Value;
            int year = int.Parse(String.Format("{0:yyyy}", dDate));
            string pattern = @"[A-Z]{2}\s[0-9]{4}-[1-8]{1}";
            if (IndividualNumberBox.Text == "индивидуальный номер" || LicensePlateBox.Text == "номерной знак" || MileageBox.Text == "пробег")
            {
                MessageBox.Show("Поля не могут быть пустыми");
            }
            else if (year < 2023)
            {

                MessageBox.Show("Год не может быть раньше 2023");
            }
            else
            {
                if (int.TryParse(MileageBox.Text, out var parsedNumber))
                {
                    if (Regex.IsMatch(LicensePlateBox.Text, pattern, RegexOptions.IgnoreCase))
                    {
                        CMD.CommandText = "INSERT INTO Buses (ManufacturersID, [Индивидуальный номер], [Номерной знак], [Дата поступления], Пробег) " +
                            "VALUES ((SELECT ID FROM Manufacturers WHERE Производитель = @Manufacture AND Модель = @Model), " +
                            "@IndividualNumber, @LicensePlate, @Date, @Mileage)";
                        CMD.Parameters.AddWithValue("@IndividualNumber", IndividualNumberBox.Text);
                        CMD.Parameters.AddWithValue("@LicensePlate", LicensePlateBox.Text);
                        CMD.Parameters.AddWithValue("@Date", String.Format("{0:dd.MM.yyyy}", dDate));
                        CMD.Parameters.AddWithValue("@Mileage", MileageBox.Text);
                        CMD.Parameters.AddWithValue("@Manufacture", ManufacturersComboBox.Text);
                        CMD.Parameters.AddWithValue("@Model", ModelsComboBox.Text);
                        BusesTable.Clear();
                        BusesTable.Load(CMD.ExecuteReader());
                        MessageBox.Show("Новый автобус успешно добавлен");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Номер должен соответствовать белорусскому автобусу");
                    }
                }
                else
                {
                    MessageBox.Show("Пробег должен быть числом");
                }
            }
        }

        private void IndividualNumberBox_Enter(object sender, EventArgs e)
        {
            if (IndividualNumberBox.Text == "индивидуальный номер")
            {
                IndividualNumberBox.Text = "";
                IndividualNumberBox.ForeColor = Color.Black;
            }
        }

        private void IndividualNumberBox_Leave(object sender, EventArgs e)
        {
            if (IndividualNumberBox.Text == "")
            {
                IndividualNumberBox.Text = "индивидуальный номер";
                IndividualNumberBox.ForeColor = Color.Silver;
            }
        }

        private void LicensePlateBox_Enter(object sender, EventArgs e)
        {
            if (LicensePlateBox.Text == "номерной знак")
            {
                LicensePlateBox.Text = "";
                LicensePlateBox.ForeColor = Color.Black;
            }
        }

        private void LicensePlateBox_Leave(object sender, EventArgs e)
        {
            if (LicensePlateBox.Text == "")
            {
                LicensePlateBox.Text = "номерной знак";
                LicensePlateBox.ForeColor = Color.Silver;
            }
        }

        private void MileageBox_Enter(object sender, EventArgs e)
        {
            if (MileageBox.Text == "пробег")
            {
                MileageBox.Text = "";
                MileageBox.ForeColor = Color.Black;
            }
        }

        private void ModelsComboBox_Click(object sender, EventArgs e)
        {
            if(ManufacturersComboBox.Text == "Производитель")
            {
                MessageBox.Show("Выберите производителя");
            }
        }

        private void ManufacturersComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CMD.CommandText = $"SELECT Модель FROM Manufacturers WHERE Производитель = @Manufacturer";
            CMD.Parameters.AddWithValue("@Manufacturer", ManufacturersComboBox.Text);
            ModelsComboBox.DataSource = ModelsTable;
            ModelsTable.Clear();
            ModelsTable.Load(CMD.ExecuteReader());
            ModelsComboBox.DisplayMember = "Модель";
        }

        private void MileageBox_Leave(object sender, EventArgs e)
        {
            if (MileageBox.Text == "")
            {
                MileageBox.Text = "пробег";
                MileageBox.ForeColor = Color.Silver;
            }
        }

        private void Buses_FormClosing(object sender, FormClosingEventArgs e)
        {
            DB.Close();
        }
    }
}
