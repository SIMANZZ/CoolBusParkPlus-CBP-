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

            CMD.CommandText = "SELECT ID,[Номер маршрута],[Количество остановок],[Начальная остановка],[Конечная остановка] FROM Routes";
            Routes.Clear();
            Routes.Load(CMD.ExecuteReader()); // perfrom the SQL request

            CMD.CommandText = "SELECT ID,Марка, Модель, [Индивидуальный номер], [Номерной знак], [Дата поступления], Пробег FROM Buses";
            Buses.Clear();
            Buses.Load(CMD.ExecuteReader());

            CMD.CommandText = "SELECT ID,ФИО, [Закреплённый автобус], [Стаж вождения] FROM Drivers";
            Drivers.Clear();
            Drivers.Load(CMD.ExecuteReader());

            CMD.CommandText = "SELECT ID,Название,Маршруты FROM BusStations";
            BusStations.Clear();
            BusStations.Load(CMD.ExecuteReader());

            CMD.CommandText = "SELECT ID,Водитель,Маршрут,Дата FROM Trips";
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
            Flags.BusesFlag = false; Flags.RoutesFlag = true; Flags.DriversFlag = false; Flags.StationsFlag = false;
        }

        private void BusesButton_Click(object sender, EventArgs e)
        {
            HoverColor(BusesButton, BusIcon);
            Button theLabel = (Button)sender;
            clickedButton = theLabel;
            TabControl.SelectedTab = BusesTab;
            Flags.BusesFlag = true; Flags.RoutesFlag = false; Flags.DriversFlag = false; Flags.StationsFlag = false;
        }

        private void DriversButton_Click(object sender, EventArgs e)
        {
            HoverColor(DriversButton, DriverIcon);
            Button theLabel = (Button)sender;
            clickedButton = theLabel;
            TabControl.SelectedTab = DriversTab;
            Flags.BusesFlag = false; Flags.RoutesFlag = false; Flags.DriversFlag = true; Flags.StationsFlag = false;
        }

        private void StationsButton_Click(object sender, EventArgs e)
        {
            HoverColor(StationsButton, StationIcon);
            Button theLabel = (Button)sender;
            clickedButton = theLabel;
            TabControl.SelectedTab = BusStationsTab;
            Flags.BusesFlag = false; Flags.RoutesFlag = false; Flags.DriversFlag = false; Flags.StationsFlag = true;
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
            BusStationsGrid.DataSource = BusStations;
            DriversGrid.DataSource = Drivers;
            BusesGrid.DataSource = Buses;
            RoutesGrid.DataSource = Routes;

            CMD.CommandText = "SELECT ID,[Номер маршрута],[Количество остановок],[Начальная остановка],[Конечная остановка] FROM Routes";
            Routes.Clear();
            Routes.Load(CMD.ExecuteReader()); // perfrom the SQL request

            CMD.CommandText = "SELECT ID,Марка, Модель, [Индивидуальный номер], [Номерной знак], [Дата поступления], Пробег FROM Buses";
            Buses.Clear();
            Buses.Load(CMD.ExecuteReader());

            CMD.CommandText = "SELECT ID,ФИО, [Закреплённый автобус], [Стаж вождения] FROM Drivers";
            Drivers.Clear();
            Drivers.Load(CMD.ExecuteReader());

            CMD.CommandText = "SELECT ID,Название,Маршруты FROM BusStations";
            BusStations.Clear();
            BusStations.Load(CMD.ExecuteReader());

            CMD.CommandText = "SELECT ID,Водитель,Маршрут,Дата FROM Trips";
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

        private void SearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                string SearchText = SearchBox.Text;
                if (SearchBox.Text == "поиск...")
                {
                    UpdateButton.PerformClick();
                }
                else if (Flags.RoutesFlag)
                {
                    CMD.CommandText = $"SELECT * FROM Routes WHERE ID LIKE {SearchText} OR [Номер маршрута] LIKE {SearchText} OR [Количество остановок] LIKE {SearchText} OR [Начальная остановка] LIKE {SearchText} OR [Конечная остановка] LIKE {SearchText}";
                    Routes.Clear();
                    Routes.Load(CMD.ExecuteReader());
                }
                else if (Flags.BusesFlag)
                {
                    CMD.CommandText = $"SELECT * FROM Buses WHERE ID LIKE {SearchText} OR Марка LIKE {SearchText} OR Модель LIKE {SearchText} OR [Индивидуальный номер] LIKE {SearchText} OR [Номерной знак] LIKE {SearchText} OR [Дата поступления] LIKE {SearchText} OR Пробег LIKE {SearchText}";
                    Buses.Clear();
                    Buses.Load(CMD.ExecuteReader());
                }
                else if (Flags.DriversFlag)
                {
                    CMD.CommandText = $"SELECT * FROM Drivers WHERE ID LIKE {SearchText} OR ФИО LIKE {SearchText} OR [Закреплённый автобус] LIKE {SearchText} OR [Стаж вождения] LIKE {SearchText}";
                    Drivers.Clear();
                    Drivers.Load(CMD.ExecuteReader());
                }
                else if (Flags.StationsFlag)
                {
                    CMD.CommandText = $"SELECT * FROM BusStations WHERE ID LIKE {SearchText} OR Название LIKE {SearchText} OR Маршруты LIKE {SearchText}";
                    BusStations.Clear();
                    BusStations.Load(CMD.ExecuteReader());
                }
                else if (Flags.TripsFlag)
                {
                    CMD.CommandText = $"SELECT * FROM Trips WHERE ID LIKE {SearchText} OR Водитель LIKE {SearchText} OR Маршрут LIKE {SearchText} OR Дата LIKE {SearchText}";
                    Trips.Clear();
                    Trips.Load(CMD.ExecuteReader());
                }
            }
            catch
            {
                MessageBox.Show("Неизвестная ошибка");
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
