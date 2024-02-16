using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SQLite;

namespace CBP
{
    public partial class Login : Form
    {
        Thread th;
        SQLiteConnection DB;
        string querry;
        public Login()
        {
            InitializeComponent();
            //Event EnterButton
            KeyPreview = true;
            KeyDown += (s, e) => { if (e.KeyValue == (char)Keys.Enter) EnterButton_Click(EnterButton, null); };
            KeyDown += (s, e) => { if (e.KeyValue == (char)Keys.Escape) ExitButton_Click(ExitButton, null); };
        }

        private void Login_Load(object sender, EventArgs e)
        {
            DB= new SQLiteConnection("Data Source = CBP.sqlite; Version = 3; FailIfMissing = false");
            DB.Open();
            eye.Visible = true;
        }
        private void LoginBox_Enter(object sender, EventArgs e)
        {
            if(LoginBox.Text == "логин")
            {
                LoginBox.Text = "";
                LoginBox.ForeColor = Color.Black;
            }
        }

        private void LoginBox_Leave(object sender, EventArgs e)
        {
            if (LoginBox.Text == "")
            {
                LoginBox.Text = "логин";
                LoginBox.ForeColor = Color.Silver;
            }
        }

        private void PassBox_Enter(object sender, EventArgs e)
        {
            if (PassBox.Text == "пароль")
            {
                PassBox.Text = "";
                PassBox.ForeColor = Color.Black;
            }
        }
        private void PassBox_Leave(object sender, EventArgs e)
        {
            if (PassBox.Text == "")
            {
                PassBox.Text = "пароль";
                PassBox.ForeColor = Color.Silver;
            }
        }
        private void hide_Click(object sender, EventArgs e)
        {
            hide.Visible = false;
            eye.Visible = true;
            PassBox.UseSystemPasswordChar = true;
        }
        private void eye_Click(object sender, EventArgs e)
        {
            hide.Visible= true;
            eye.Visible= false;
            PassBox.UseSystemPasswordChar = false;
        }
        private void EnterButton_Click(object sender, EventArgs e)
        {
            if(LoginBox.Text == "логин" || PassBox.Text == "пароль")
            {
                MessageBox.Show("Поля не могут быть пустыми.");
            }
            else
            {
                querry = "SELECT * FROM Users WHERE login = @login AND pass = @pass";
                SQLiteCommand CMD = new SQLiteCommand(querry, DB);
                CMD.Parameters.AddWithValue("@login", LoginBox.Text);
                CMD.Parameters.AddWithValue("@pass", PassBox.Text);
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(CMD);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    if(LoginBox.Text == "admin" && PassBox.Text == "admin")
                    {
                        this.Close();
                        th = new Thread(Open_MainForm_Form);
                        th.SetApartmentState(ApartmentState.STA);
                        th.Start();
                    }
                    else
                    {
                        Flags.CurrentLogin = LoginBox.Text;
                        this.Close();
                        th = new Thread(Open_UserForm_Form);
                        th.SetApartmentState(ApartmentState.STA);
                        th.Start();
                    }
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль.");
                }
            }
        }
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(Open_Form1_Form);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        private void NoAccountLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            th = new Thread(Open_Register_Form);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        private void Open_MainForm_Form(object sender)
        {
            Application.Run(new MainForm());
        }
        private void Open_Register_Form(object sender)
        {
            Application.Run(new Register());
        }
        private void Open_Form1_Form(object sender)
        {
            Application.Run(new EnterForm());
        }
        private void Open_UserForm_Form(object sender)
        {
            Application.Run(new UserForm());
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            DB.Close();
        }
    }
}
