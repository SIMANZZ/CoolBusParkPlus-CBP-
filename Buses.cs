﻿using System;
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

namespace CBP
{
    public partial class Buses : Form
    {

        SQLiteConnection DB;
        SQLiteCommand CMD;
        DataTable BusesTable;
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
            if (BrandBox.Text == "марка" || ModelBox.Text == "модель" || IndividualNumberBox.Text == "индивидуальный номер" || LicensePlateBox.Text == "номерной знак" || MileageBox.Text == "пробег")
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
                        CMD.CommandText = "INSERT INTO Buses (Марка,Модель,[Индивидуальный номер],[Номерной знак],[Дата поступления],Пробег) VALUES (@Brand, @Model, @IndividualNumber,@LicensePlate,@Date,@Mileage)";
                        CMD.Parameters.AddWithValue("@Brand", BrandBox.Text);
                        CMD.Parameters.AddWithValue("@Model", ModelBox.Text);
                        CMD.Parameters.AddWithValue("@IndividualNumber", IndividualNumberBox.Text);
                        CMD.Parameters.AddWithValue("@LicensePlate", LicensePlateBox.Text);
                        CMD.Parameters.AddWithValue("@Date", String.Format("{0:dd.MM.yyyy}", dDate));
                        CMD.Parameters.AddWithValue("@Mileage", MileageBox.Text);
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


        private void BrandBox_Enter(object sender, EventArgs e)
        {
            if (BrandBox.Text == "марка")
            {
                BrandBox.Text = "";
                BrandBox.ForeColor = Color.Black;
            }
        }

        private void BrandBox_Leave(object sender, EventArgs e)
        {
            if (BrandBox.Text == "")
            {   
                BrandBox.Text = "марка";
                BrandBox.ForeColor = Color.Silver;
            }
        }

        private void ModelBox_Enter(object sender, EventArgs e)
        {
            if (ModelBox.Text == "модель")
            {
                ModelBox.Text = "";
                ModelBox.ForeColor = Color.Black;
            }
        }

        private void ModelBox_Leave(object sender, EventArgs e)
        {
            if (ModelBox.Text == "")
            {
                ModelBox.Text = "модель";
                ModelBox.ForeColor = Color.Silver;
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
