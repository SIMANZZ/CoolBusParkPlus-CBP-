namespace CBP
{
    partial class Routes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Routes));
            this.NumberOfRouteBox = new System.Windows.Forms.TextBox();
            this.NumberOfStationsBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.BusStationsStartComboBox = new System.Windows.Forms.ComboBox();
            this.BusStationsEndComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // NumberOfRouteBox
            // 
            this.NumberOfRouteBox.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NumberOfRouteBox.ForeColor = System.Drawing.Color.Silver;
            this.NumberOfRouteBox.Location = new System.Drawing.Point(253, 12);
            this.NumberOfRouteBox.Name = "NumberOfRouteBox";
            this.NumberOfRouteBox.Size = new System.Drawing.Size(306, 35);
            this.NumberOfRouteBox.TabIndex = 1;
            this.NumberOfRouteBox.Text = "номер маршрута";
            this.NumberOfRouteBox.Enter += new System.EventHandler(this.NumberOfRouteBox_Enter);
            this.NumberOfRouteBox.Leave += new System.EventHandler(this.NumberOfRouteBox_Leave);
            // 
            // NumberOfStationsBox
            // 
            this.NumberOfStationsBox.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NumberOfStationsBox.ForeColor = System.Drawing.Color.Silver;
            this.NumberOfStationsBox.Location = new System.Drawing.Point(253, 71);
            this.NumberOfStationsBox.Name = "NumberOfStationsBox";
            this.NumberOfStationsBox.Size = new System.Drawing.Size(306, 35);
            this.NumberOfStationsBox.TabIndex = 2;
            this.NumberOfStationsBox.Text = "количество остановок";
            this.NumberOfStationsBox.Enter += new System.EventHandler(this.NumberOfStationsBox_Enter);
            this.NumberOfStationsBox.Leave += new System.EventHandler(this.NumberOfStationsBox_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(30, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(215, 24);
            this.label5.TabIndex = 21;
            this.label5.Text = "Конечная остановка*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(229, 24);
            this.label4.TabIndex = 20;
            this.label4.Text = "Начальная остановка*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(237, 24);
            this.label3.TabIndex = 19;
            this.label3.Text = "Количество остановок*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(63, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 24);
            this.label1.TabIndex = 18;
            this.label1.Text = "Номер маршрута*";
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.White;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExitButton.ForeColor = System.Drawing.Color.RoyalBlue;
            this.ExitButton.Location = new System.Drawing.Point(149, 249);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(0);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(98, 43);
            this.ExitButton.TabIndex = 7;
            this.ExitButton.Text = "Отмена";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.AddButton.FlatAppearance.BorderSize = 0;
            this.AddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddButton.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddButton.ForeColor = System.Drawing.Color.White;
            this.AddButton.Location = new System.Drawing.Point(253, 249);
            this.AddButton.Margin = new System.Windows.Forms.Padding(0);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(306, 43);
            this.AddButton.TabIndex = 6;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = false;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // BusStationsStartComboBox
            // 
            this.BusStationsStartComboBox.BackColor = System.Drawing.Color.White;
            this.BusStationsStartComboBox.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BusStationsStartComboBox.ForeColor = System.Drawing.Color.Black;
            this.BusStationsStartComboBox.FormattingEnabled = true;
            this.BusStationsStartComboBox.Items.AddRange(new object[] {
            "МАЗ",
            "Белкомунмаш"});
            this.BusStationsStartComboBox.Location = new System.Drawing.Point(253, 130);
            this.BusStationsStartComboBox.Name = "BusStationsStartComboBox";
            this.BusStationsStartComboBox.Size = new System.Drawing.Size(306, 38);
            this.BusStationsStartComboBox.TabIndex = 50;
            this.BusStationsStartComboBox.Text = "Название";
            // 
            // BusStationsEndComboBox
            // 
            this.BusStationsEndComboBox.BackColor = System.Drawing.Color.White;
            this.BusStationsEndComboBox.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BusStationsEndComboBox.ForeColor = System.Drawing.Color.Black;
            this.BusStationsEndComboBox.FormattingEnabled = true;
            this.BusStationsEndComboBox.Items.AddRange(new object[] {
            "МАЗ",
            "Белкомунмаш"});
            this.BusStationsEndComboBox.Location = new System.Drawing.Point(251, 190);
            this.BusStationsEndComboBox.Name = "BusStationsEndComboBox";
            this.BusStationsEndComboBox.Size = new System.Drawing.Size(306, 38);
            this.BusStationsEndComboBox.TabIndex = 51;
            this.BusStationsEndComboBox.Text = "Название";
            // 
            // Routes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(570, 308);
            this.Controls.Add(this.BusStationsEndComboBox);
            this.Controls.Add(this.BusStationsStartComboBox);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.NumberOfRouteBox);
            this.Controls.Add(this.NumberOfStationsBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Routes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dream Bus";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Routes_FormClosing);
            this.Load += new System.EventHandler(this.Routes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NumberOfRouteBox;
        private System.Windows.Forms.TextBox NumberOfStationsBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.ComboBox BusStationsStartComboBox;
        private System.Windows.Forms.ComboBox BusStationsEndComboBox;
    }
}