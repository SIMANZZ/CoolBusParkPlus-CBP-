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
using System.Windows.Forms.DataVisualization.Charting;

namespace CBP
{
    public partial class Chart : Form
    {
        SQLiteConnection DB;
        public Chart()
        {
            InitializeComponent();
            KeyPreview = true;
            KeyDown += (s, e) => { if (e.KeyValue == (char)Keys.Escape) this.Close(); };
        }

        private void Chart_Load(object sender, EventArgs e)
        {
            DB = new SQLiteConnection("Data Source = CBP.sqlite; Version = 3; FailIfMissing = false");

            DB.Open();

            string querry = "SELECT * FROM Users";
            SQLiteCommand CMD = new SQLiteCommand(querry, DB);
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(CMD);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            int number = dataTable.Rows.Count;
            ChartGraph.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            for(int i = 0; i <= number; i++)
            {
                ChartGraph.Series[0].Points.AddY(i);
            }
        }

        private void Chart_FormClosing(object sender, FormClosingEventArgs e)
        {
            DB.Close();
        }
    }
}
