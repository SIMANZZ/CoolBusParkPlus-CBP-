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
        DataTable RoutesTable;
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

            RoutesTable= new DataTable();
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

        private void StartStationBox_Enter(object sender, EventArgs e)
        {
            if (StartStationBox.Text == "начальная остановка")
            {
                StartStationBox.Text = "";
                StartStationBox.ForeColor = Color.Black;
            }
        }

        private void StartStationBox_Leave(object sender, EventArgs e)
        {
            if (StartStationBox.Text == "")
            {
                StartStationBox.Text = "начальная остановка";
                StartStationBox.ForeColor = Color.Silver;
            }
        }

        private void EndStationBox_Enter(object sender, EventArgs e)
        {
            if (EndStationBox.Text == "конечная остановка")
            {
                EndStationBox.Text = "";
                EndStationBox.ForeColor = Color.Black;
            }
        }

        private void EndStationBox_Leave(object sender, EventArgs e)
        {
            if (EndStationBox.Text == "")
            {
                EndStationBox.Text = "конечная остановка";
                EndStationBox.ForeColor = Color.Silver;
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (NumberOfRouteBox.Text == "номер маршрута" || NumberOfStationsBox.Text == "количество остановок" || StartStationBox.Text == "начальная остановка" || EndStationBox.Text == "конечная остановка")
            {
                MessageBox.Show("Поля не могут быть пустыми");
            }
            else if(int.TryParse(NumberOfStationsBox.Text,out var parsedNumber))
            {     
                CMD.CommandText = "INSERT INTO Routes ([Номер маршрута],[Количество остановок],[Начальная остановка],[Конечная остановка]) VALUES (@NumberOfRoute, @NumberOfStations, @StartStation,@EndStation)";
                CMD.Parameters.AddWithValue("@NumberOfRoute", NumberOfRouteBox.Text);
                CMD.Parameters.AddWithValue("@NumberOfStations", int.Parse(NumberOfStationsBox.Text));
                CMD.Parameters.AddWithValue("@StartStation", StartStationBox.Text);
                CMD.Parameters.AddWithValue("@EndStation", EndStationBox.Text);
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

        //Checked for the number
        //public static bool isValidTime(String str)
        //{

        //    // Regex to check valid LEI Code
        //    var regex = new Regex("^(?:[01]?[0-9]|2[0-3]):[0-5]?[0-9](?::[0-5]?[0-9])?$");

        //    // If the str
        //    // is empty return false
        //    if (str == null)
        //    {
        //        return false;
        //    }

        //    // Pattern class contains matcher()
        //    // method to find matching between
        //    // given LEI Code using regex.
        //    var m = regex.Match(str);

        //    // Return if the MICR Code
        //    // matched the ReGex
        //    return m.Success;
        //}

//        if (DateTime.TryParse(DateBox.Text, out dDate))
//                {
//DateTime dDate;
//int year;
//                    year = int.Parse(String.Format("{0:yyyy}", dDate));
//                    if(year< 2023)
//                    {
//                        MessageBox.Show("Год не может быть раньше 2023");
//                    }
//                    else
//                    {

//                                CMD.CommandText = "INSERT INTO Routes (Название,[Время отправления],[Время прибытия],Дата,Стоимость) VALUES (@Name, @DepartureTime, @ArrivalTime,@Date, @Cost)";
//                                CMD.Parameters.AddWithValue("@Name", NameBox.Text);
//                                CMD.Parameters.AddWithValue("@DepartureTime", DepartureTimeBox.Text);
//                                CMD.Parameters.AddWithValue("@ArrivalTime", ArrivalTimeBox.Text);
//                                CMD.Parameters.AddWithValue("@Date", String.Format("{0:d.MM.yyyy}", dDate));
//                                RoutesTable.Clear();
//                                RoutesTable.Load(CMD.ExecuteReader());
//                                MessageBox.Show("Новый маршрут успешно добавлен");
//                                this.Close();
//    }
//}
//                else
//{
//    MessageBox.Show("Неправельный формат даты");
//}

        private void Routes_FormClosing(object sender, FormClosingEventArgs e)
        {
            DB.Close();
        }
    }
}