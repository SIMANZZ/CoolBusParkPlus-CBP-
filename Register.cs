using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CBP
{
    public partial class Register : Form
    {
        Thread th;
        //Create DB variable
        SQLiteConnection DB;
        string querry;
        public Register()
        {
            InitializeComponent();
            //Event RegisterButton
            KeyPreview = true;
            KeyDown += (s, e) => { if (e.KeyValue == (char)Keys.Enter) RegisterButton_Click(RegisterButton, null); };
            KeyDown += (s, e) => { if (e.KeyValue == (char)Keys.Escape) ExitButton_Click(ExitButton, null); };
        }
        private void Register_Load(object sender, EventArgs e)
        {
            //Connect to DB
            DB = new SQLiteConnection("Data Source = CBP.sqlite; Version = 3; FailIfMissing = false");
            DB.Open();
        }
        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if (LoginBox.Text == "логин" || PassBox.Text == "пароль" || EmailBox.Text == "email" || RetryPassBox.Text == "повтор пароля")
            {
                MessageBox.Show("Поля не могут быть пустыми.");
            }
            else
            {
                if(PassBox.Text != RetryPassBox.Text)
                {
                    MessageBox.Show("Пароли не совпадают.");
                }
                else
                {
                    if (IsValidEmail(EmailBox.Text))
                    {
                        try
                        {
                            querry = "INSERT INTO Users (login,email,pass) VALUES (:login, :email, :pass)";
                            SQLiteCommand CMD = new SQLiteCommand(querry, DB);
                            CMD.Parameters.AddWithValue("login", LoginBox.Text);
                            CMD.Parameters.AddWithValue("email", EmailBox.Text);
                            CMD.Parameters.AddWithValue("pass", PassBox.Text);
                            SQLiteDataAdapter adapter = new SQLiteDataAdapter(CMD);
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            this.Close();
                            th = new Thread(Open_Login_Form);
                            th.SetApartmentState(ApartmentState.STA);
                            th.Start();
                        }
                        catch (SQLiteException ex)
                        {
                        if (ex.Message == "constraint failed\r\nUNIQUE constraint failed: Users.email")
                        {
                            MessageBox.Show("Этот эмейл уже используется");
                        }
                        else
                        {
                            MessageBox.Show("Этот логин уже занят");
                        }
                    }
                }
                    else
                    {
                        MessageBox.Show("Неверный email.");
                    }
                }
            }
        }
        private void LoginBox_Enter(object sender, EventArgs e)
        {
            if (LoginBox.Text == "логин")
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

        private void EmailBox_Enter(object sender, EventArgs e)
        {
            if (EmailBox.Text == "email")
            {
                EmailBox.Text = "";
                EmailBox.ForeColor = Color.Black;
            }
        }

        private void EmailBox_Leave(object sender, EventArgs e)
        {
            if (EmailBox.Text == "")
            {
                EmailBox.Text = "email";
                EmailBox.ForeColor = Color.Silver;
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

        private void RetryPassBox_Enter(object sender, EventArgs e)
        {
            if (RetryPassBox.Text == "повтор пароля")
            {
                RetryPassBox.Text = "";
                RetryPassBox.ForeColor = Color.Black;
            }
        }

        private void RetryPassBox_Leave(object sender, EventArgs e)
        {
            if (RetryPassBox.Text == "")
            {
                RetryPassBox.Text = "повтор пароля";
                RetryPassBox.ForeColor = Color.Silver;
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(Open_Login_Form);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        private void Open_Login_Form(object sender)
        {
            Application.Run(new Login());
        }

        private void Register_FormClosing(object sender, FormClosingEventArgs e)
        {
            DB.Close();
        }
        bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}
