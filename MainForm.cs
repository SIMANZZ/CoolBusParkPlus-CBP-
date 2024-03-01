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
using System.Threading;
using System.Data.SqlClient;

namespace CBP
{
    public partial class MainForm : Form
    {
        Thread th;
        Button clickedButton, clickedIcon;
        SQLiteConnection DB;
        SQLiteCommand CMD;
        DataTable Routes, Drivers, BusStations, Buses, Trips;
        public MainForm()
        {
            InitializeComponent(); KeyPreview = true;
            KeyDown += (s, e) => { if (e.KeyValue == (char)Keys.Escape) FormOpen(); };
            KeyDown += (s, e) => { if (e.KeyValue == (char)Keys.Enter) SearchButton_Click(SearchButton,null); };
        }
        private void FormOpen()
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
        private void MainForm_Load(object sender, EventArgs e)
        {
            RoutesButton.PerformClick();

            //Connect to Routes Table
            DB = new SQLiteConnection("Data Source = CBP.sqlite; Version = 3; FailIfMissing = false");

            CMD = new SQLiteCommand();
            CMD.Connection = DB;

            Routes = new DataTable();
            RoutesGrid.DataSource = Routes; // связываем DataTable и таблицу на форме (просто dt)

            Buses = new DataTable();
            BusesGrid.DataSource = Buses;

            Drivers = new DataTable();
            DriversGrid.DataSource = Drivers;

            BusStations = new DataTable();
            BusStationsGrid.DataSource = BusStations;

            Trips = new DataTable();
            TripsGrid.DataSource = Trips;
            

            DB.Open(); // open the connection with DB

            CMD.CommandText = "SELECT Routes.ID, Routes.[Номер маршрута], Routes.[Количество остановок], " +
              "sn_start.Название AS [Начальная остановка], sn_end.Название AS [Конечная остановка] " +
              "FROM Routes " +
              "JOIN StationsNames sn_start ON Routes.[Начальная остановка] = sn_start.ID " +
              "JOIN StationsNames sn_end ON Routes.[Конечная остановка] = sn_end.ID";
            Routes.Clear();
            Routes.Load(CMD.ExecuteReader()); // Выполнение SQL запроса


            CMD.CommandText = "SELECT B.ID, M.Производитель, M.Модель, B.[Индивидуальный номер], B.[Номерной знак], B.[Дата поступления], " +
                "B.Пробег FROM Buses B JOIN Manufacturers M ON B.ManufacturersID = M.ID";
            Buses.Clear();
            Buses.Load(CMD.ExecuteReader());

            CMD.CommandText = "SELECT D.ID, D.ФИО, B.[Индивидуальный номер] AS [Закреплённый автобус], D.[Стаж вождения] " +
                "FROM Drivers D JOIN Buses B ON D.[Закреплённый автобус] = B.ID";
            Drivers.Clear();
            Drivers.Load(CMD.ExecuteReader());

            CMD.CommandText = "SELECT BS.ID, SN.Название, R.[Номер маршрута] " +
                "FROM BusStations BS JOIN Routes R ON BS.[Номер маршрута] = R.ID " +
                "JOIN StationsNames SN ON BS.Название = SN.ID";
            BusStations.Clear();
            BusStations.Load(CMD.ExecuteReader());

            CMD.CommandText = "SELECT T.ID, D.ФИО AS Водитель, R.[Номер маршрута] AS Маршрут, T.Дата FROM Trips T JOIN Drivers D ON T.Водитель = D.ID " +
                "JOIN Routes R ON T.Маршрут = R.ID";
            Trips.Clear();
            Trips.Load(CMD.ExecuteReader());
        }

        //Change the button color when hover
        private void HoverColor(Button Button, Button Icon)
        {
            Button[] ButtonsAndIcons = { RoutesButton, RouteIcon, StationsButton, StationIcon, DriversButton, DriverIcon, BusesButton, BusIcon, TripsButton, TripIcon };
            foreach (Button i in ButtonsAndIcons)
            {
                if (i == Button || i == Icon)
                {
                    i.BackColor = Color.Blue;
                }
                else
                {
                    i.BackColor = Color.RoyalBlue;
                }
            }
        }
        private void RoutesButton_Click(object sender, EventArgs e)
        {
            HoverColor(RoutesButton, RouteIcon);
            Button theLabel = (Button)sender;
            clickedButton = theLabel;
            TabControl.SelectedTab = RoutesTab;
            Flags.BusesFlag = false; Flags.RoutesFlag = true; Flags.DriversFlag = false; Flags.StationsFlag = false; Flags.TripsFlag = false;
        }

        private void BusesButton_Click(object sender, EventArgs e)
        {
            HoverColor(BusesButton, BusIcon);
            Button theLabel = (Button)sender;
            clickedButton = theLabel;
            TabControl.SelectedTab = BusesTab;
            Flags.BusesFlag = true; Flags.RoutesFlag = false; Flags.DriversFlag = false; Flags.StationsFlag = false; Flags.TripsFlag = false;
        }

        private void DriversButton_Click(object sender, EventArgs e)
        {
            HoverColor(DriversButton, DriverIcon);
            Button theLabel = (Button)sender;
            clickedButton = theLabel;
            TabControl.SelectedTab = DriversTab;
            Flags.BusesFlag = false; Flags.RoutesFlag = false; Flags.DriversFlag = true; Flags.StationsFlag = false; Flags.TripsFlag = false;
        }

        private void StationsButton_Click(object sender, EventArgs e)
        {
            HoverColor(StationsButton, StationIcon);
            Button theLabel = (Button)sender;
            clickedButton = theLabel;
            TabControl.SelectedTab = BusStationsTab;
            Flags.BusesFlag = false; Flags.RoutesFlag = false; Flags.DriversFlag = false; Flags.StationsFlag = true; Flags.TripsFlag = false;
        }

        private void TripsButton_Click(object sender, EventArgs e)
        {
            HoverColor(TripsButton, TripIcon);
            Button theLabel = (Button)sender;
            clickedButton = theLabel;
            TabControl.SelectedTab = TripsTab;
            Flags.BusesFlag = false; Flags.RoutesFlag = false; Flags.DriversFlag = false; Flags.StationsFlag = false; Flags.TripsFlag = true;
        }

        private void RoutesButton_MouseEnter(object sender, EventArgs e)
        {
            Button theLabel = (Button)sender;
            if (theLabel != clickedButton)
            {
                RoutesButton.BackColor = Color.Blue;
                RouteIcon.BackColor = Color.Blue;
            } 
        }

        private void RoutesButton_MouseLeave(object sender, EventArgs e)
        {
            Button theLabel = (Button)sender;
            if (theLabel != clickedButton)
            {
                RoutesButton.BackColor = Color.RoyalBlue;
                RouteIcon.BackColor = Color.RoyalBlue;
            }
        }

        private void BusesButton_MouseEnter(object sender, EventArgs e)
        {
            Button theLabel = (Button)sender;
            if (theLabel != clickedButton)
            {
                BusesButton.BackColor = Color.Blue;
                BusIcon.BackColor = Color.Blue;
            }
        }

        private void BusesButton_MouseLeave(object sender, EventArgs e)
        {
            Button theLabel = (Button)sender;
            if (theLabel != clickedButton)
            {
                BusesButton.BackColor = Color.RoyalBlue;
                BusIcon.BackColor = Color.RoyalBlue;
            }
        }

        private void DriversButton_MouseEnter(object sender, EventArgs e)
        {
            Button theLabel = (Button)sender;
            if (theLabel != clickedButton)
            {
                DriversButton.BackColor = Color.Blue;
                DriverIcon.BackColor = Color.Blue;
            }
        }

        private void DriversButton_MouseLeave(object sender, EventArgs e)
        {
            Button theLabel = (Button)sender;
            if (theLabel != clickedButton)
            {
                DriversButton.BackColor = Color.RoyalBlue;
                DriverIcon.BackColor = Color.RoyalBlue;
            }
        }

        private void StationsButton_MouseEnter(object sender, EventArgs e)
        {
            Button theLabel = (Button)sender;
            if (theLabel != clickedButton)
            {
                StationsButton.BackColor = Color.Blue;
                StationIcon.BackColor = Color.Blue;
            }
        }

        private void StationsButton_MouseLeave(object sender, EventArgs e)
        {
            Button theLabel = (Button)sender;
            if (theLabel != clickedButton)
            {
                StationsButton.BackColor = Color.RoyalBlue;
                StationIcon.BackColor = Color.RoyalBlue;
            }
        }

        private void TripsButton_MouseEnter(object sender, EventArgs e)
        {
            Button theLabel = (Button)sender;
            if (theLabel != clickedButton)
            {
                TripsButton.BackColor = Color.Blue;
                TripIcon.BackColor = Color.Blue;
            }
        }
        
        private void TripsButton_MouseLeave(object sender, EventArgs e)
        {
            Button theLabel = (Button)sender;
            if (theLabel != clickedButton)
            {
                TripsButton.BackColor = Color.RoyalBlue;
                TripIcon.BackColor = Color.RoyalBlue;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DB.Close(); // закрываем соединение с БД
                        
            Logger logger = new Logger("log.txt");

            // Логирование сообщения
            logger.LogGridContents(RoutesGrid);
            logger.LogGridContents(BusesGrid);
            logger.LogGridContents(DriversGrid);
            logger.LogGridContents(BusStationsGrid);
            logger.LogGridContents(TripsGrid);
        }

        private void RouteIcon_Click(object sender, EventArgs e)
        {
            Button theLabel = (Button)sender;
            clickedIcon = theLabel;
            RoutesButton.PerformClick();
        }

        private void RouteIcon_MouseEnter(object sender, EventArgs e)
        {
            Button theLabel = (Button)sender;
            if (theLabel != clickedIcon)
            {
                RoutesButton.BackColor = Color.Blue;
                RouteIcon.BackColor = Color.Blue;
            }
        }

        private void RouteIcon_MouseLeave(object sender, EventArgs e)
        {
            Button theLabel = (Button)sender;
            if (theLabel != clickedIcon)
            {
                RoutesButton.BackColor = Color.RoyalBlue;
                RouteIcon.BackColor = Color.RoyalBlue;
            }
        }

        private void BusIcon_Click(object sender, EventArgs e)
        {
            Button theLabel = (Button)sender;
            clickedIcon = theLabel;
            BusesButton.PerformClick();
        }

        private void BusIcon_MouseEnter(object sender, EventArgs e)
        {
            Button theLabel = (Button)sender;
            if (theLabel != clickedIcon)
            {
                BusesButton.BackColor = Color.Blue;
                BusIcon.BackColor = Color.Blue;
            }
        }

        private void BusIcon_MouseLeave(object sender, EventArgs e)
        {
            Button theLabel = (Button)sender;
            if (theLabel != clickedIcon)
            {
                BusesButton.BackColor = Color.RoyalBlue;
                BusIcon.BackColor = Color.RoyalBlue;
            }
        }

        private void DriverIcon_Click(object sender, EventArgs e)
        {
            Button theLabel = (Button)sender;
            clickedIcon = theLabel;
            DriversButton.PerformClick();
        }

        private void DriverIcon_MouseEnter(object sender, EventArgs e)
        {
            Button theLabel = (Button)sender;
            if (theLabel != clickedIcon)
            {
                DriversButton.BackColor = Color.Blue;
                DriverIcon.BackColor = Color.Blue;
            }
        }

        private void DriverIcon_MouseLeave(object sender, EventArgs e)
        {
            Button theLabel = (Button)sender;
            if (theLabel != clickedIcon)
            {
                DriversButton.BackColor = Color.RoyalBlue;
                DriverIcon.BackColor = Color.RoyalBlue;
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            Remove remove = new Remove();
            remove.ShowDialog();
            UpdateButton.PerformClick();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            comboBoxValue.Text = "значение";
            comboBoxFilter.Text = "поле";

            BusStationsGrid.DataSource = BusStations;
            DriversGrid.DataSource = Drivers;
            BusesGrid.DataSource = Buses;
            RoutesGrid.DataSource = Routes;
            TripsGrid.DataSource = Trips;

            CMD.CommandText = "SELECT Routes.ID, Routes.[Номер маршрута], Routes.[Количество остановок], " +
              "sn_start.Название AS [Начальная остановка], sn_end.Название AS [Конечная остановка] " +
              "FROM Routes " +
              "JOIN StationsNames sn_start ON Routes.[Начальная остановка] = sn_start.ID " +
              "JOIN StationsNames sn_end ON Routes.[Конечная остановка] = sn_end.ID";
            Routes.Clear();
            Routes.Load(CMD.ExecuteReader()); // perfrom the SQL request

            CMD.CommandText = "SELECT B.ID, M.Производитель, M.Модель, B.[Индивидуальный номер], " +
                "B.[Номерной знак], B.[Дата поступления], " +
                "B.Пробег FROM Buses B JOIN Manufacturers M ON B.ManufacturersID = M.ID";
            Buses.Clear();
            Buses.Load(CMD.ExecuteReader());

            CMD.CommandText = "SELECT D.ID, D.ФИО, B.[Индивидуальный номер] AS [Закреплённый автобус], D.[Стаж вождения] " +
                "FROM Drivers D JOIN Buses B ON D.[Закреплённый автобус] = B.ID";
            Drivers.Clear();
            Drivers.Load(CMD.ExecuteReader());

            CMD.CommandText = "SELECT BS.ID, SN.Название, R.[Номер маршрута] " +
                "FROM BusStations BS JOIN Routes R ON BS.[Номер маршрута] = R.ID " +
                "JOIN StationsNames SN ON BS.Название = SN.ID";
            BusStations.Clear();
            BusStations.Load(CMD.ExecuteReader());

            CMD.CommandText = "SELECT T.ID, D.ФИО AS Водитель, R.[Номер маршрута] AS Маршрут, T.Дата FROM Trips T " +
                "JOIN Drivers D ON T.Водитель = D.ID " +
                "JOIN Routes R ON T.Маршрут = R.ID";
            Trips.Clear();
            Trips.Load(CMD.ExecuteReader());

            SearchBox.Text = "поиск...";
            SearchBox.ForeColor = Color.Silver;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (Flags.RoutesFlag)
            {
                Routes routes = new Routes();
                routes.ShowDialog();
            }
            else if (Flags.BusesFlag)
            {
                Buses buses = new Buses();
                buses.ShowDialog();
            }
            else if (Flags.StationsFlag)
            {
                Stations stations = new Stations();
                stations.ShowDialog();
            }
            else if (Flags.DriversFlag)
            {
                Drivers drivers = new Drivers();
                drivers.ShowDialog();
            }
            else if (Flags.TripsFlag)
            {
                Trips trips = new Trips();
                trips.ShowDialog();
            }
            UpdateButton.PerformClick();
        }

        private void StationIcon_Click(object sender, EventArgs e)
        {
            Button theLabel = (Button)sender;
            clickedIcon = theLabel;
            StationsButton.PerformClick();
        }

        private void TripIcon_MouseEnter(object sender, EventArgs e)
        {
            Button theLabel = (Button)sender;
            if (theLabel != clickedIcon)
            {
                TripsButton.BackColor = Color.Blue;
                TripIcon.BackColor = Color.Blue;
            }
        }

        private void TripIcon_MouseLeave(object sender, EventArgs e)
        {
            Button theLabel = (Button)sender;
            if (theLabel != clickedIcon)
            {
                TripsButton.BackColor = Color.RoyalBlue;
                TripIcon.BackColor = Color.RoyalBlue;
            }
        }

        private void TripIcon_Click(object sender, EventArgs e)
        {
            Button theLabel = (Button)sender;
            clickedIcon = theLabel;
            TripsButton.PerformClick();
        }

        private void ExecuteFilterByQuery(string table_name)
        {
            comboBoxFilter.Invoke((MethodInvoker)delegate {
                comboBoxFilter.Items.Clear();
                CMD.CommandText = $"PRAGMA table_info({table_name})";
                SQLiteDataReader reader = CMD.ExecuteReader();
                while (reader.Read())
                {
                    string columnName = reader["name"].ToString();
                    comboBoxFilter.Items.Add(columnName);
                }
                reader.Close();
                if (Flags.BusesFlag)
                {
                    comboBoxFilter.Items.Remove("ManufacturersID");

                    comboBoxFilter.Items.Add("Производитель");
                    comboBoxFilter.Items.Add("Модель");
                }
            });
        }

        private void FilterRoutes()
        {
            string selectedFilter = comboBoxFilter.SelectedItem.ToString();
            string selectedValue = comboBoxValue.SelectedItem.ToString();

            string query = CMD.CommandText = "SELECT Routes.ID, Routes.[Номер маршрута], Routes.[Количество остановок], " +
              "sn_start.Название AS [Начальная остановка], sn_end.Название AS [Конечная остановка] " +
              "FROM Routes " +
              "JOIN StationsNames sn_start ON Routes.[Начальная остановка] = sn_start.ID " +
              "JOIN StationsNames sn_end ON Routes.[Конечная остановка] = sn_end.ID ";

            switch (selectedFilter)
            {
                case "Номер маршрута":
                    query += $"WHERE Routes.[Номер маршрута] = '{selectedValue}'";
                    break;
                case "Начальная остановка":
                    query += $"WHERE sn_start.Название = '{selectedValue}'";
                    break;
                case "Конечная остановка":
                    query += $"WHERE sn_end.Название = '{selectedValue}'";
                    break;
                case "Количество остановок":
                    query += $"WHERE Routes.[Количество остановок] = '{selectedValue}'";
                    break;
                case "ID":
                    query += $"WHERE Routes.ID = '{selectedValue}'";
                    break;
                default:
                    break;
            }

            // Выполнить запрос и обновить DataGridView с результатами
            CMD.CommandText = query;
            Routes.Clear();
            Routes.Load(CMD.ExecuteReader());
        }

        private void FilterBuses()
        {
            string selectedFilter = comboBoxFilter.SelectedItem.ToString();
            string selectedValue = comboBoxValue.SelectedItem.ToString();

            string query = "SELECT Buses.ID, Buses.[Индивидуальный номер], Buses.[Номерной знак], " +
                           "Buses.[Дата поступления], Buses.Пробег, " +
                           "m.Производитель, m.Модель " +
                           "FROM Buses " +
                           "JOIN Manufacturers m ON Buses.ManufacturersID = m.ID ";

            switch (selectedFilter)
            {
                case "Индивидуальный номер":
                    query += $"WHERE Buses.[Индивидуальный номер] = '{selectedValue}'";
                    break;
                case "Номерной знак":
                    query += $"WHERE Buses.[Номерной знак] = '{selectedValue}'";
                    break;
                case "Дата поступления":
                    query += $"WHERE Buses.[Дата поступления] = '{selectedValue}'";
                    break;
                case "Пробег":
                    query += $"WHERE Buses.Пробег = '{selectedValue}'";
                    break;
                case "Производитель":
                    query += $"WHERE m.Производитель = '{selectedValue}'";
                    break;
                case "Модель":
                    query += $"WHERE m.Модель = '{selectedValue}'";
                    break;
                case "ID":
                    query += $"WHERE Buses.ID = '{selectedValue}'";
                    break;
                default:
                    break;
            }

            // Выполнить запрос и обновить DataGridView с результатами
            CMD.CommandText = query;
            Buses.Clear();
            Buses.Load(CMD.ExecuteReader());
        }

        private void FilterDrivers()
        {
            string selectedFilter = comboBoxFilter.SelectedItem.ToString();
            string selectedValue = comboBoxValue.SelectedItem.ToString();

            string query = "SELECT Drivers.ID, Drivers.ФИО, Drivers.[Закреплённый автобус], " +
                           "Drivers.[Стаж вождения] " +
                           "FROM Drivers ";

            switch (selectedFilter)
            {
                case "ФИО":
                    query += $"WHERE Drivers.ФИО = '{selectedValue}'";
                    break;
                case "Закреплённый автобус":
                    query += $"WHERE Drivers.[Закреплённый автобус] = '{selectedValue}'";
                    break;
                case "Стаж вождения":
                    query += $"WHERE Drivers.[Стаж вождения] = '{selectedValue}'";
                    break;
                case "ID":
                    query += $"WHERE Drivers.ID = '{selectedValue}'";
                    break;
                default:
                    break;
            }

            // Выполнить запрос и обновить DataGridView с результатами
            CMD.CommandText = query;
            Drivers.Clear();
            Drivers.Load(CMD.ExecuteReader());
        }

        private void FilterBusStations()
        {
            string selectedFilter = comboBoxFilter.SelectedItem.ToString();
            string selectedValue = comboBoxValue.SelectedItem.ToString();

            string query = "SELECT bs.ID, sn.Название, r.[Номер маршрута] " +
               "FROM BusStations bs " +
               "JOIN StationsNames sn ON bs.Название = sn.ID " +
               "JOIN Routes r ON bs.[Номер маршрута] = r.ID ";

            switch (selectedFilter)
            {
                case "Название":
                    query += $"WHERE sn.Название = '{selectedValue}'";
                    break;
                case "Номер маршрута":
                    query += $"WHERE r.[Номер маршрута] = '{selectedValue}'";
                    break;
                case "ID":
                    query += $"WHERE bs.ID = '{selectedValue}'";
                    break;
                default:
                    break;
            }

            // Выполнить запрос и обновить DataGridView с результатами
            CMD.CommandText = query;
            BusStations.Clear();
            BusStations.Load(CMD.ExecuteReader());
        }

        private void FilterTrips()
        {
            string selectedFilter = comboBoxFilter.SelectedItem.ToString();
            string selectedValue = comboBoxValue.SelectedItem.ToString();

            string query = "SELECT T.ID, D.ФИО AS Водитель, R.[Номер маршрута] AS Маршрут, T.Дата FROM Trips T " +
                "JOIN Drivers D ON T.Водитель = D.ID " +
                "JOIN Routes R ON T.Маршрут = R.ID ";

            switch (selectedFilter)
            {
                case "Дата":
                    query += $"WHERE T.Дата = '{selectedValue}'";
                    break;
                case "Маршрут":
                    query += $"WHERE R.[Номер маршрута] = '{selectedValue}'";
                    break;
                case "Водитель":
                    query += $"WHERE D.ФИО = '{selectedValue}'";
                    break;
                case "ID":
                    query += $"WHERE T.ID = '{selectedValue}'";
                    break;
                default:
                    break;
            }

            // Выполнить запрос и обновить DataGridView с результатами
            CMD.CommandText = query;
            Trips.Clear();
            Trips.Load(CMD.ExecuteReader());
        }

        private void comboBoxFilter_Click(object sender, EventArgs e)
        {
            if (Flags.RoutesFlag)
            {
                ExecuteFilterByQuery("Routes");
            }
            else if (Flags.BusesFlag)
            {
                ExecuteFilterByQuery("Buses");
            }
            else if (Flags.StationsFlag)
            {
                ExecuteFilterByQuery("BusStations");
            }
            else if (Flags.DriversFlag)
            {
                ExecuteFilterByQuery("Drivers");
            }
            else if (Flags.TripsFlag)
            {
                ExecuteFilterByQuery("Trips");
            }
        }

        private void comboBoxValue_Click(object sender, EventArgs e)
        {
            if (comboBoxFilter.Text == "поле")
            {
                MessageBox.Show("Выберите поле");
                return;
            }

            string selectedField = comboBoxFilter.SelectedItem.ToString();
            comboBoxValue.Items.Clear();

            string columnName = ""; // Название столбца для выбора
            string query = "";      // Запрос SQL

            // Определите, из какой таблицы выбирать значения
            if (Flags.RoutesFlag)
            {
                switch (selectedField)
                {
                    case "Начальная остановка":
                    case "Конечная остановка":
                        columnName = "Название"; // Если выбрано поле "Начальная остановка" или "Конечная остановка", выберите название остановок из таблицы BusStations
                        query = $"SELECT DISTINCT sn.{columnName} FROM BusStations bs " +
                                $"JOIN StationsNames sn ON bs.{columnName} = sn.ID";
                        break;
                    default:
                        columnName = selectedField; // В противном случае используйте выбранное поле напрямую
                        query = $"SELECT DISTINCT [{columnName}] FROM Routes";
                        break;
                }
            }
            else if (Flags.BusesFlag)
            {
                switch (selectedField)
                {
                    case "Производитель":
                    case "Модель":
                        columnName = selectedField;
                        query = $"SELECT DISTINCT m.{columnName} FROM Buses b " +
                                $"JOIN Manufacturers m ON b.ManufacturersID = m.ID";
                        break;
                    default:
                        columnName = selectedField; // В противном случае используйте выбранное поле напрямую
                        query = $"SELECT DISTINCT [{columnName}] FROM Buses";
                        break;
                }
            }
            else if (Flags.StationsFlag)
            {
                switch (selectedField)
                {
                    case "Название":
                        columnName = "Название"; // Если выбрано поле "Название", выберите название остановки из таблицы StationsNames
                        query = $"SELECT DISTINCT sn.{columnName} FROM BusStations bs " +
                                $"JOIN StationsNames sn ON bs.{columnName} = sn.ID";
                        break;
                    case "Номер маршрута":
                        columnName = "Номер маршрута";
                        query = $"SELECT DISTINCT r.[{columnName}] FROM BusStations bs " +
                                $"JOIN Routes r ON bs.[{columnName}] = r.ID";
                        break;
                    default:
                        columnName = selectedField; // В противном случае используйте выбранное поле напрямую
                        query = $"SELECT DISTINCT [{columnName}] FROM BusStations";
                        break;
                }
            }
            else if (Flags.DriversFlag)
            {
                switch (selectedField)
                {
                    case "Закреплённый автобус":
                        columnName = "Индивидуальный номер";
                        query = $"SELECT DISTINCT b.[{columnName}] FROM Drivers d " +
                                $"JOIN Buses b ON d.[Закреплённый автобус] = b.ID";
                        break;
                    default:
                        columnName = selectedField; // В противном случае используйте выбранное поле напрямую
                        query = $"SELECT DISTINCT [{columnName}] FROM Drivers";
                        break;
                }
            }
            else if (Flags.TripsFlag)
            {
                switch (selectedField)
                {
                    case "Водитель":
                        columnName = "ФИО"; // Если выбрано поле "Водитель", выберите ФИО водителя из таблицы Drivers
                        query = $"SELECT DISTINCT d.{columnName} FROM Trips t " +
                                $"JOIN Drivers d ON t.Водитель = d.ID";
                        break;
                    case "Маршрут":
                        columnName = "Номер маршрута"; // Если выбрано поле "Маршрут", выберите номер маршрута из таблицы Routes
                        query = $"SELECT DISTINCT r.[{columnName}] FROM Trips t " +
                                $"JOIN Routes r ON t.Маршрут = r.ID";
                        break;
                    default:
                        columnName = selectedField; // В противном случае используйте выбранное поле напрямую
                        query = $"SELECT DISTINCT [{columnName}] FROM Trips";
                        break;
                }
            }

            // Выполните запрос и заполните comboBoxValue
            try
            {
                CMD.CommandText = query;
                SQLiteDataReader reader = CMD.ExecuteReader();
                while (reader.Read())
                {
                    string value = reader[columnName].ToString();
                    comboBoxValue.Items.Add(value);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }

        private void comboBoxValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Flags.RoutesFlag)
            {
                FilterRoutes();
            }
            else if (Flags.BusesFlag)
            {
                FilterBuses();
            }
            else if (Flags.StationsFlag)
            {
                FilterBusStations();
            }
            else if (Flags.DriversFlag)
            {
                FilterDrivers();
            }
            else if (Flags.TripsFlag)
            {
                FilterTrips();
            }
        }

        private void comboBoxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxValue.Text = "значение";
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = SearchBox.Text;
                if (SearchBox.Text == "поиск...")
                {
                    UpdateButton.PerformClick();
                }
                else if (Flags.RoutesFlag)
                {
                    CMD.CommandText = $"SELECT Routes.ID, Routes.[Номер маршрута], Routes.[Количество остановок], " +
                          $"sn_start.Название AS [Начальная остановка], sn_end.Название AS [Конечная остановка] " +
                          $"FROM Routes " +
                          $"JOIN StationsNames sn_start ON Routes.[Начальная остановка] = sn_start.ID " +
                          $"JOIN StationsNames sn_end ON Routes.[Конечная остановка] = sn_end.ID " +
                          $"WHERE Routes.ID LIKE '%{searchText}%' OR Routes.[Номер маршрута] LIKE '%{searchText}%' " +
                          $"OR Routes.[Количество остановок] LIKE '%{searchText}%' OR sn_start.ID " +
                          $"IN (SELECT ID FROM StationsNames WHERE Название LIKE '%{searchText}%') OR sn_end.ID " +
                          $"IN (SELECT ID FROM StationsNames WHERE Название LIKE '%{searchText}%')";
                    Routes.Clear();
                    Routes.Load(CMD.ExecuteReader());
                }
                else if (Flags.BusesFlag)
                {
                    CMD.CommandText = $"SELECT B.ID, M.Производитель, M.Модель, B.[Индивидуальный номер], " +
                          $"B.[Номерной знак], B.[Дата поступления], " +
                          $"B.Пробег FROM Buses B JOIN Manufacturers M ON B.ManufacturersID = M.ID " +
                          $"WHERE B.ID LIKE '%{searchText}%' OR M.Производитель LIKE '%{searchText}%' " +
                          $"OR M.Модель LIKE '%{searchText}%' OR B.[Индивидуальный номер] LIKE '%{searchText}%' " +
                          $"OR B.[Номерной знак] LIKE '%{searchText}%' OR B.[Дата поступления] LIKE '%{searchText}%' OR B.Пробег " +
                          $"LIKE '%{searchText}%'";
                    Buses.Clear();
                    Buses.Load(CMD.ExecuteReader());
                }
                else if (Flags.DriversFlag)
                {
                    CMD.CommandText = $"SELECT D.ID, D.ФИО, B.[Индивидуальный номер] AS [Закреплённый автобус], D.[Стаж вождения] " +
                          $"FROM Drivers D JOIN Buses B ON D.[Закреплённый автобус] = B.ID " +
                          $"WHERE D.ID LIKE '%{searchText}%' OR D.ФИО LIKE '%{searchText}%' " +
                          $"OR B.[Индивидуальный номер] LIKE '%{searchText}%' OR D.[Стаж вождения] " +
                          $"LIKE '%{searchText}%'";
                    Drivers.Clear();
                    Drivers.Load(CMD.ExecuteReader());
                }
                else if (Flags.StationsFlag)
                {
                    CMD.CommandText = $"SELECT BS.ID, SN.Название, R.[Номер маршрута] " +
                          $"FROM BusStations BS JOIN Routes R ON BS.[Номер маршрута] = R.ID " +
                          $"JOIN StationsNames SN ON BS.Название = SN.ID " +
                          $"WHERE BS.ID LIKE '%{searchText}%' OR SN.Название LIKE '%{searchText}%'";
                    BusStations.Clear();
                    BusStations.Load(CMD.ExecuteReader());
                }
                else if (Flags.TripsFlag)
                {
                    CMD.CommandText = $"SELECT T.ID, D.ФИО AS Водитель, R.[Номер маршрута] AS Маршрут, T.Дата " +
                           $"FROM Trips T JOIN Drivers D ON T.Водитель = D.ID " +
                           $"JOIN Routes R ON T.Маршрут = R.ID " +
                           $"WHERE T.ID LIKE '%{searchText}%' OR D.ФИО LIKE '%{searchText}%' " +
                           $"OR R.[Номер маршрута] LIKE '%{searchText}%' OR T.Дата LIKE '%{searchText}%'";
                    Trips.Clear();
                    Trips.Load(CMD.ExecuteReader());
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Неизвестная ошибка"+$" {ex.Message}");
            }
        }

        private void StationIcon_MouseEnter(object sender, EventArgs e)
        {
            Button theLabel = (Button)sender;
            if (theLabel != clickedIcon)
            {
                StationsButton.BackColor = Color.Blue;
                StationIcon.BackColor = Color.Blue;
            }
        }

        private void SearchBox_Enter(object sender, EventArgs e)
        {
            if (SearchBox.Text == "поиск...")
            {
                SearchBox.Text = "";
                SearchBox.ForeColor = Color.Black;
            }
        }

        private void SearchBox_Leave(object sender, EventArgs e)
        {
            if (SearchBox.Text == "")
            {
                SearchBox.Text = "поиск...";
                SearchBox.ForeColor = Color.Silver;
            }
        }

        private void StationIcon_MouseLeave(object sender, EventArgs e)
        {
            Button theLabel = (Button)sender;
            if (theLabel != clickedIcon)
            {
                StationsButton.BackColor = Color.RoyalBlue;
                StationIcon.BackColor = Color.RoyalBlue;
            }
        }
    }
}
