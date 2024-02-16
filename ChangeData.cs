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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace CBP
{
    public partial class ChangeData : Form
    {
        SQLiteConnection DB;
        SQLiteCommand CMD;

        int ID;
        string pass, email;
        public ChangeData()
        {
            InitializeComponent();
            KeyPreview = true;
            KeyDown += (s, e) => { if (e.KeyValue == (char)Keys.Enter) ChangeButton_Click(ChangeButton, null); };
            KeyDown += (s, e) => { if (e.KeyValue == (char)Keys.Escape) ExitButton_Click(ExitButton, null); };
        }

        private void ChangeData_Load(object sender, EventArgs e)
        {
            DB = new SQLiteConnection("Data Source = CBP.sqlite; Version = 3; FailIfMissing = false");

            CMD = new SQLiteCommand();
            CMD.Connection = DB;

            DB.Open();

            CMD.CommandText = "SELECT ID FROM Users WHERE login = @login";
            CMD.Parameters.AddWithValue("@login", Flags.CurrentLogin);

            ID = int.Parse(CMD.ExecuteScalar().ToString());

            CMD.CommandText = $"SELECT pass FROM Users WHERE ID = {ID}";
            pass = CMD.ExecuteScalar().ToString();
            CMD.CommandText = $"SELECT email FROM Users WHERE ID = {ID}";
            email = CMD.ExecuteScalar().ToString();

            LoginBox.Text = Flags.CurrentLogin;
            LoginBox.ForeColor= Color.Black;
            EmailBox.Text = email;
            EmailBox.ForeColor= Color.Black;
        }

        private void ChangeButton_Click(object sender, EventArgs e)
        {
            if (OldPassBox.Text == "старый пароль" || NewPassBox.Text == "новый пароль" || RetryNewPassBox.Text == "повтор нового пароля")
            {
                MessageBox.Show("Поля не должны быть пустыми");
            }
            else
            {
                if (OldPassBox.Text == pass)
                {
                    if(NewPassBox.Text == RetryNewPassBox.Text)
                    {
                        CMD.CommandText = "UPDATE Users SET login = @login, pass = @pass, email == @email WHERE ID = @ID";
                        CMD.Parameters.AddWithValue("@login",LoginBox.Text);
                        CMD.Parameters.AddWithValue("@pass", NewPassBox.Text);
                        CMD.Parameters.AddWithValue("@email", EmailBox.Text);
                        CMD.Parameters.AddWithValue("@ID",ID);
                        CMD.ExecuteNonQuery();
                        MessageBox.Show("Данные изменены");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Пароли не совподают");
                    }
                }
                else
                {
                    MessageBox.Show("Неверный пароль");
                }
            }   
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void OldPassBox_Enter(object sender, EventArgs e)
        {
            if (OldPassBox.Text == "старый пароль")
            {
                OldPassBox.Text = "";
                OldPassBox.ForeColor = Color.Black;
            }
        }

        private void OldPassBox_Leave(object sender, EventArgs e)
        {
            if (OldPassBox.Text == "")
            {
                OldPassBox.Text = "старый пароль";
                OldPassBox.ForeColor = Color.Silver;
            }
        }

        private void NewPassBox_Enter(object sender, EventArgs e)
        {
            if (NewPassBox.Text == "новый пароль")
            {
                NewPassBox.Text = "";
                NewPassBox.ForeColor = Color.Black;
            }
        }

        private void NewPassBox_Leave(object sender, EventArgs e)
        {
            if (NewPassBox.Text == "")
            {
                NewPassBox.Text = "новый пароль";
                NewPassBox.ForeColor = Color.Silver;
            }
        }

        private void RetryNewPassBox_Enter(object sender, EventArgs e)
        {
            if (RetryNewPassBox.Text == "повтор нового пароля")
            {
                RetryNewPassBox.Text = "";
                RetryNewPassBox.ForeColor = Color.Black;
            }
        }

        private void RetryNewPassBox_Leave(object sender, EventArgs e)
        {
            if (RetryNewPassBox.Text == "")
            {
                RetryNewPassBox.Text = "повтор нового пароля";
                RetryNewPassBox.ForeColor = Color.Silver;
            }
        }
    }
}
