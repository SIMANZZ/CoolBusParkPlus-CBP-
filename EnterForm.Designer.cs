namespace CBP
{
    partial class EnterForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnterForm));
            this.Enter = new System.Windows.Forms.Button();
            this.AboutApp = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripText = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.графикToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Enter
            // 
            this.Enter.BackColor = System.Drawing.Color.RoyalBlue;
            this.Enter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Enter.Font = new System.Drawing.Font("Arial Rounded MT Bold", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Enter.ForeColor = System.Drawing.Color.White;
            this.Enter.Location = new System.Drawing.Point(41, 30);
            this.Enter.Margin = new System.Windows.Forms.Padding(0);
            this.Enter.Name = "Enter";
            this.Enter.Size = new System.Drawing.Size(224, 65);
            this.Enter.TabIndex = 0;
            this.Enter.Text = "Войти";
            this.toolTip1.SetToolTip(this.Enter, "Перейти ко входу в аккаунт");
            this.Enter.UseVisualStyleBackColor = false;
            this.Enter.Click += new System.EventHandler(this.Enter_Click);
            // 
            // AboutApp
            // 
            this.AboutApp.BackColor = System.Drawing.Color.RoyalBlue;
            this.AboutApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AboutApp.Font = new System.Drawing.Font("Arial Rounded MT Bold", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AboutApp.ForeColor = System.Drawing.Color.White;
            this.AboutApp.Location = new System.Drawing.Point(41, 140);
            this.AboutApp.Name = "AboutApp";
            this.AboutApp.Size = new System.Drawing.Size(224, 65);
            this.AboutApp.TabIndex = 1;
            this.AboutApp.Text = "О приложении";
            this.toolTip1.SetToolTip(this.AboutApp, "Просмотреть информацию о приложении");
            this.AboutApp.UseVisualStyleBackColor = false;
            this.AboutApp.Click += new System.EventHandler(this.AboutApp_Click);
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.RoyalBlue;
            this.Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exit.Font = new System.Drawing.Font("Arial Rounded MT Bold", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exit.ForeColor = System.Drawing.Color.White;
            this.Exit.Location = new System.Drawing.Point(41, 251);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(224, 65);
            this.Exit.TabIndex = 2;
            this.Exit.Text = "Выйти";
            this.toolTip1.SetToolTip(this.Exit, "Выйти из приложения");
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripText,
            this.toolStripDate,
            this.toolStripTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 326);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(299, 22);
            this.statusStrip1.Stretch = false;
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripText
            // 
            this.toolStripText.Name = "toolStripText";
            this.toolStripText.Size = new System.Drawing.Size(73, 17);
            this.toolStripText.Text = "toolStripText";
            // 
            // toolStripDate
            // 
            this.toolStripDate.Name = "toolStripDate";
            this.toolStripDate.Size = new System.Drawing.Size(76, 17);
            this.toolStripDate.Text = "toolStripDate";
            // 
            // toolStripTime
            // 
            this.toolStripTime.Name = "toolStripTime";
            this.toolStripTime.Size = new System.Drawing.Size(78, 17);
            this.toolStripTime.Text = "toolStripTime";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справкаToolStripMenuItem,
            this.графикToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(299, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            this.справкаToolStripMenuItem.ToolTipText = "Прочтите перед тем как пользоваться приложением";
            this.справкаToolStripMenuItem.Click += new System.EventHandler(this.справкаToolStripMenuItem_Click);
            // 
            // графикToolStripMenuItem
            // 
            this.графикToolStripMenuItem.Name = "графикToolStripMenuItem";
            this.графикToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.графикToolStripMenuItem.Text = "График";
            this.графикToolStripMenuItem.Click += new System.EventHandler(this.графикToolStripMenuItem_Click);
            // 
            // EnterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(299, 348);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.AboutApp);
            this.Controls.Add(this.Enter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EnterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dream Bus";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private new System.Windows.Forms.Button Enter;
        private System.Windows.Forms.Button AboutApp;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripText;
        private System.Windows.Forms.ToolStripStatusLabel toolStripDate;
        private System.Windows.Forms.ToolStripStatusLabel toolStripTime;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem графикToolStripMenuItem;
    }
}

