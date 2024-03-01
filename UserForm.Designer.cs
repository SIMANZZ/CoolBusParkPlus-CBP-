namespace CBP
{
    partial class UserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserForm));
            this.StripMenu = new System.Windows.Forms.MenuStrip();
            this.мойАккаунтToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.моиБилетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заказатьБилетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.MyAccountTab = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ChangeData = new System.Windows.Forms.Button();
            this.MailLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LoginLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.MyTickets = new System.Windows.Forms.TabPage();
            this.CostGrid = new System.Windows.Forms.DataGridView();
            this.OrderTicketTab = new System.Windows.Forms.TabPage();
            this.TravelNumberBox = new System.Windows.Forms.TextBox();
            this.OrderTicket = new System.Windows.Forms.Button();
            this.BusExpressRadioButton = new System.Windows.Forms.RadioButton();
            this.BusRadioButton = new System.Windows.Forms.RadioButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.TravelCardscomboBox = new System.Windows.Forms.ComboBox();
            this.StripMenu.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.MyAccountTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.MyTickets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CostGrid)).BeginInit();
            this.OrderTicketTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // StripMenu
            // 
            this.StripMenu.BackColor = System.Drawing.Color.RoyalBlue;
            this.StripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.мойАккаунтToolStripMenuItem,
            this.моиБилетыToolStripMenuItem,
            this.заказатьБилетыToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.StripMenu.Location = new System.Drawing.Point(0, 0);
            this.StripMenu.Name = "StripMenu";
            this.StripMenu.Size = new System.Drawing.Size(1904, 38);
            this.StripMenu.TabIndex = 0;
            this.StripMenu.Text = "menuStrip1";
            // 
            // мойАккаунтToolStripMenuItem
            // 
            this.мойАккаунтToolStripMenuItem.BackColor = System.Drawing.Color.RoyalBlue;
            this.мойАккаунтToolStripMenuItem.Font = new System.Drawing.Font("Franklin Gothic Book", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.мойАккаунтToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.мойАккаунтToolStripMenuItem.Name = "мойАккаунтToolStripMenuItem";
            this.мойАккаунтToolStripMenuItem.Size = new System.Drawing.Size(154, 34);
            this.мойАккаунтToolStripMenuItem.Text = "Мой аккаунт";
            this.мойАккаунтToolStripMenuItem.Click += new System.EventHandler(this.мойАккаунтToolStripMenuItem_Click);
            // 
            // моиБилетыToolStripMenuItem
            // 
            this.моиБилетыToolStripMenuItem.Font = new System.Drawing.Font("Franklin Gothic Book", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.моиБилетыToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.моиБилетыToolStripMenuItem.Name = "моиБилетыToolStripMenuItem";
            this.моиБилетыToolStripMenuItem.Size = new System.Drawing.Size(149, 34);
            this.моиБилетыToolStripMenuItem.Text = "Мои билеты";
            this.моиБилетыToolStripMenuItem.Click += new System.EventHandler(this.моиБилетыToolStripMenuItem_Click);
            // 
            // заказатьБилетыToolStripMenuItem
            // 
            this.заказатьБилетыToolStripMenuItem.Font = new System.Drawing.Font("Franklin Gothic Book", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.заказатьБилетыToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.заказатьБилетыToolStripMenuItem.Name = "заказатьБилетыToolStripMenuItem";
            this.заказатьБилетыToolStripMenuItem.Size = new System.Drawing.Size(359, 34);
            this.заказатьБилетыToolStripMenuItem.Text = "Покупка Проездных Документов";
            this.заказатьБилетыToolStripMenuItem.Click += new System.EventHandler(this.заказатьБилетыToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Font = new System.Drawing.Font("Franklin Gothic Book", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.выходToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(90, 34);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // TabControl
            // 
            this.TabControl.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.TabControl.Controls.Add(this.MyAccountTab);
            this.TabControl.Controls.Add(this.MyTickets);
            this.TabControl.Controls.Add(this.OrderTicketTab);
            this.TabControl.Location = new System.Drawing.Point(0, 41);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(1920, 1020);
            this.TabControl.TabIndex = 1;
            // 
            // MyAccountTab
            // 
            this.MyAccountTab.Controls.Add(this.pictureBox1);
            this.MyAccountTab.Controls.Add(this.ChangeData);
            this.MyAccountTab.Controls.Add(this.MailLabel);
            this.MyAccountTab.Controls.Add(this.label2);
            this.MyAccountTab.Controls.Add(this.LoginLabel);
            this.MyAccountTab.Controls.Add(this.label1);
            this.MyAccountTab.Location = new System.Drawing.Point(4, 4);
            this.MyAccountTab.Name = "MyAccountTab";
            this.MyAccountTab.Padding = new System.Windows.Forms.Padding(3);
            this.MyAccountTab.Size = new System.Drawing.Size(1912, 994);
            this.MyAccountTab.TabIndex = 0;
            this.MyAccountTab.Text = "MyAccount";
            this.MyAccountTab.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CBP.Properties.Resources.bus1;
            this.pictureBox1.Location = new System.Drawing.Point(683, 331);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(646, 309);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // ChangeData
            // 
            this.ChangeData.BackColor = System.Drawing.Color.RoyalBlue;
            this.ChangeData.FlatAppearance.BorderSize = 0;
            this.ChangeData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChangeData.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChangeData.ForeColor = System.Drawing.Color.White;
            this.ChangeData.Location = new System.Drawing.Point(86, 245);
            this.ChangeData.Margin = new System.Windows.Forms.Padding(0);
            this.ChangeData.Name = "ChangeData";
            this.ChangeData.Size = new System.Drawing.Size(330, 56);
            this.ChangeData.TabIndex = 7;
            this.ChangeData.Text = "Изменить данные";
            this.ChangeData.UseVisualStyleBackColor = false;
            this.ChangeData.Click += new System.EventHandler(this.ChangeData_Click);
            // 
            // MailLabel
            // 
            this.MailLabel.AutoSize = true;
            this.MailLabel.Font = new System.Drawing.Font("Franklin Gothic Book", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MailLabel.Location = new System.Drawing.Point(581, 111);
            this.MailLabel.Name = "MailLabel";
            this.MailLabel.Size = new System.Drawing.Size(67, 61);
            this.MailLabel.TabIndex = 3;
            this.MailLabel.Text = "M";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Book", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(400, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 61);
            this.label2.TabIndex = 2;
            this.label2.Text = "Почта:";
            // 
            // LoginLabel
            // 
            this.LoginLabel.AutoSize = true;
            this.LoginLabel.Font = new System.Drawing.Font("Franklin Gothic Book", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoginLabel.Location = new System.Drawing.Point(247, 111);
            this.LoginLabel.Name = "LoginLabel";
            this.LoginLabel.Size = new System.Drawing.Size(52, 61);
            this.LoginLabel.TabIndex = 1;
            this.LoginLabel.Text = "L";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Book", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(75, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 61);
            this.label1.TabIndex = 0;
            this.label1.Text = "Логин:";
            // 
            // MyTickets
            // 
            this.MyTickets.Controls.Add(this.CostGrid);
            this.MyTickets.Location = new System.Drawing.Point(4, 4);
            this.MyTickets.Name = "MyTickets";
            this.MyTickets.Size = new System.Drawing.Size(1912, 974);
            this.MyTickets.TabIndex = 3;
            this.MyTickets.Text = "MyTickets";
            this.MyTickets.UseVisualStyleBackColor = true;
            // 
            // CostGrid
            // 
            this.CostGrid.AllowUserToAddRows = false;
            this.CostGrid.AllowUserToDeleteRows = false;
            this.CostGrid.AllowUserToResizeColumns = false;
            this.CostGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Franklin Gothic Book", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.CostGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.CostGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CostGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.CostGrid.BackgroundColor = System.Drawing.Color.White;
            this.CostGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CostGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.CostGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CostGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.CostGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CostGrid.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Franklin Gothic Book", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.CostGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.CostGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CostGrid.EnableHeadersVisualStyles = false;
            this.CostGrid.GridColor = System.Drawing.Color.Black;
            this.CostGrid.Location = new System.Drawing.Point(0, 0);
            this.CostGrid.Name = "CostGrid";
            this.CostGrid.ReadOnly = true;
            this.CostGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Franklin Gothic Book", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CostGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.CostGrid.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Franklin Gothic Book", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.CostGrid.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.CostGrid.RowTemplate.ReadOnly = true;
            this.CostGrid.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CostGrid.Size = new System.Drawing.Size(1912, 974);
            this.CostGrid.TabIndex = 15;
            // 
            // OrderTicketTab
            // 
            this.OrderTicketTab.Controls.Add(this.TravelNumberBox);
            this.OrderTicketTab.Controls.Add(this.OrderTicket);
            this.OrderTicketTab.Controls.Add(this.BusExpressRadioButton);
            this.OrderTicketTab.Controls.Add(this.BusRadioButton);
            this.OrderTicketTab.Controls.Add(this.pictureBox2);
            this.OrderTicketTab.Controls.Add(this.TravelCardscomboBox);
            this.OrderTicketTab.Location = new System.Drawing.Point(4, 4);
            this.OrderTicketTab.Name = "OrderTicketTab";
            this.OrderTicketTab.Size = new System.Drawing.Size(1912, 974);
            this.OrderTicketTab.TabIndex = 2;
            this.OrderTicketTab.Text = "OrderTicket";
            this.OrderTicketTab.UseVisualStyleBackColor = true;
            // 
            // TravelNumberBox
            // 
            this.TravelNumberBox.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TravelNumberBox.ForeColor = System.Drawing.Color.Silver;
            this.TravelNumberBox.Location = new System.Drawing.Point(234, 239);
            this.TravelNumberBox.Name = "TravelNumberBox";
            this.TravelNumberBox.Size = new System.Drawing.Size(387, 49);
            this.TravelNumberBox.TabIndex = 4;
            this.TravelNumberBox.Text = "количество поездок";
            this.TravelNumberBox.Enter += new System.EventHandler(this.TravelNumber_Enter);
            this.TravelNumberBox.Leave += new System.EventHandler(this.TravelNumber_Leave);
            // 
            // OrderTicket
            // 
            this.OrderTicket.BackColor = System.Drawing.Color.RoyalBlue;
            this.OrderTicket.FlatAppearance.BorderSize = 0;
            this.OrderTicket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OrderTicket.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OrderTicket.ForeColor = System.Drawing.Color.White;
            this.OrderTicket.Location = new System.Drawing.Point(820, 718);
            this.OrderTicket.Margin = new System.Windows.Forms.Padding(0);
            this.OrderTicket.Name = "OrderTicket";
            this.OrderTicket.Size = new System.Drawing.Size(403, 71);
            this.OrderTicket.TabIndex = 5;
            this.OrderTicket.Text = "Оформить билет";
            this.OrderTicket.UseVisualStyleBackColor = false;
            this.OrderTicket.Click += new System.EventHandler(this.OrderTicket_Click);
            // 
            // BusExpressRadioButton
            // 
            this.BusExpressRadioButton.AutoSize = true;
            this.BusExpressRadioButton.Font = new System.Drawing.Font("Franklin Gothic Book", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BusExpressRadioButton.Location = new System.Drawing.Point(1340, 168);
            this.BusExpressRadioButton.Name = "BusExpressRadioButton";
            this.BusExpressRadioButton.Size = new System.Drawing.Size(333, 47);
            this.BusExpressRadioButton.TabIndex = 2;
            this.BusExpressRadioButton.TabStop = true;
            this.BusExpressRadioButton.Text = "Автобус-Экспресс";
            this.BusExpressRadioButton.UseVisualStyleBackColor = true;
            // 
            // BusRadioButton
            // 
            this.BusRadioButton.AutoSize = true;
            this.BusRadioButton.Font = new System.Drawing.Font("Franklin Gothic Book", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BusRadioButton.Location = new System.Drawing.Point(888, 168);
            this.BusRadioButton.Name = "BusRadioButton";
            this.BusRadioButton.Size = new System.Drawing.Size(167, 47);
            this.BusRadioButton.TabIndex = 1;
            this.BusRadioButton.TabStop = true;
            this.BusRadioButton.Text = "Автобус";
            this.BusRadioButton.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::CBP.Properties.Resources.bus1;
            this.pictureBox2.Location = new System.Drawing.Point(683, 331);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(646, 309);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // TravelCardscomboBox
            // 
            this.TravelCardscomboBox.Font = new System.Drawing.Font("Franklin Gothic Book", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TravelCardscomboBox.FormattingEnabled = true;
            this.TravelCardscomboBox.Items.AddRange(new object[] {
            "На месяц",
            "Поездки"});
            this.TravelCardscomboBox.Location = new System.Drawing.Point(234, 167);
            this.TravelCardscomboBox.Name = "TravelCardscomboBox";
            this.TravelCardscomboBox.Size = new System.Drawing.Size(387, 51);
            this.TravelCardscomboBox.TabIndex = 3;
            this.TravelCardscomboBox.Text = "На месяц";
            this.TravelCardscomboBox.SelectedIndexChanged += new System.EventHandler(this.TravelCardscomboBox_SelectedIndexChanged);
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.StripMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.StripMenu;
            this.Name = "UserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dream Bus";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserForm_FormClosing);
            this.Load += new System.EventHandler(this.UserForm_Load);
            this.StripMenu.ResumeLayout(false);
            this.StripMenu.PerformLayout();
            this.TabControl.ResumeLayout(false);
            this.MyAccountTab.ResumeLayout(false);
            this.MyAccountTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.MyTickets.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CostGrid)).EndInit();
            this.OrderTicketTab.ResumeLayout(false);
            this.OrderTicketTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip StripMenu;
        private System.Windows.Forms.ToolStripMenuItem мойАккаунтToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заказатьБилетыToolStripMenuItem;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage MyAccountTab;
        private System.Windows.Forms.TabPage OrderTicketTab;
        private System.Windows.Forms.Label LoginLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label MailLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ChangeData;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox TravelCardscomboBox;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolStripMenuItem моиБилетыToolStripMenuItem;
        private System.Windows.Forms.TabPage MyTickets;
        private System.Windows.Forms.RadioButton BusExpressRadioButton;
        private System.Windows.Forms.RadioButton BusRadioButton;
        private System.Windows.Forms.Button OrderTicket;
        private System.Windows.Forms.TextBox TravelNumberBox;
        private System.Windows.Forms.DataGridView CostGrid;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
    }
}