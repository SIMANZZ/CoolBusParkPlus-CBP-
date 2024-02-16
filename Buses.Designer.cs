namespace CBP
{
    partial class Buses
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Buses));
            this.ExitButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.BrandBox = new System.Windows.Forms.TextBox();
            this.ModelBox = new System.Windows.Forms.TextBox();
            this.IndividualNumberBox = new System.Windows.Forms.TextBox();
            this.LicensePlateBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MileageBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Calendar = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.White;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExitButton.ForeColor = System.Drawing.Color.RoyalBlue;
            this.ExitButton.Location = new System.Drawing.Point(147, 369);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(0);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(98, 43);
            this.ExitButton.TabIndex = 8;
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
            this.AddButton.Location = new System.Drawing.Point(251, 369);
            this.AddButton.Margin = new System.Windows.Forms.Padding(0);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(306, 43);
            this.AddButton.TabIndex = 7;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = false;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // BrandBox
            // 
            this.BrandBox.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BrandBox.ForeColor = System.Drawing.Color.Silver;
            this.BrandBox.Location = new System.Drawing.Point(251, 14);
            this.BrandBox.Name = "BrandBox";
            this.BrandBox.Size = new System.Drawing.Size(306, 35);
            this.BrandBox.TabIndex = 1;
            this.BrandBox.Text = "марка";
            this.BrandBox.Enter += new System.EventHandler(this.BrandBox_Enter);
            this.BrandBox.Leave += new System.EventHandler(this.BrandBox_Leave);
            // 
            // ModelBox
            // 
            this.ModelBox.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ModelBox.ForeColor = System.Drawing.Color.Silver;
            this.ModelBox.Location = new System.Drawing.Point(251, 73);
            this.ModelBox.Name = "ModelBox";
            this.ModelBox.Size = new System.Drawing.Size(306, 35);
            this.ModelBox.TabIndex = 2;
            this.ModelBox.Text = "модель";
            this.ModelBox.Enter += new System.EventHandler(this.ModelBox_Enter);
            this.ModelBox.Leave += new System.EventHandler(this.ModelBox_Leave);
            // 
            // IndividualNumberBox
            // 
            this.IndividualNumberBox.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IndividualNumberBox.ForeColor = System.Drawing.Color.Silver;
            this.IndividualNumberBox.Location = new System.Drawing.Point(251, 132);
            this.IndividualNumberBox.Name = "IndividualNumberBox";
            this.IndividualNumberBox.Size = new System.Drawing.Size(306, 35);
            this.IndividualNumberBox.TabIndex = 3;
            this.IndividualNumberBox.Text = "индивидуальный номер";
            this.IndividualNumberBox.Enter += new System.EventHandler(this.IndividualNumberBox_Enter);
            this.IndividualNumberBox.Leave += new System.EventHandler(this.IndividualNumberBox_Leave);
            // 
            // LicensePlateBox
            // 
            this.LicensePlateBox.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LicensePlateBox.ForeColor = System.Drawing.Color.Silver;
            this.LicensePlateBox.Location = new System.Drawing.Point(251, 192);
            this.LicensePlateBox.Name = "LicensePlateBox";
            this.LicensePlateBox.Size = new System.Drawing.Size(306, 35);
            this.LicensePlateBox.TabIndex = 4;
            this.LicensePlateBox.Text = "номерной знак";
            this.LicensePlateBox.Enter += new System.EventHandler(this.LicensePlateBox_Enter);
            this.LicensePlateBox.Leave += new System.EventHandler(this.LicensePlateBox_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(81, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 24);
            this.label5.TabIndex = 31;
            this.label5.Text = "Номерной знак*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(236, 24);
            this.label4.TabIndex = 30;
            this.label4.Text = "Индивидульный номер*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(151, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 24);
            this.label3.TabIndex = 29;
            this.label3.Text = "Модель*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(164, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 24);
            this.label1.TabIndex = 28;
            this.label1.Text = "Марка*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(51, 258);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 24);
            this.label2.TabIndex = 33;
            this.label2.Text = "Дата поступления*";
            // 
            // MileageBox
            // 
            this.MileageBox.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MileageBox.ForeColor = System.Drawing.Color.Silver;
            this.MileageBox.Location = new System.Drawing.Point(251, 312);
            this.MileageBox.Name = "MileageBox";
            this.MileageBox.Size = new System.Drawing.Size(306, 35);
            this.MileageBox.TabIndex = 6;
            this.MileageBox.Text = "пробег";
            this.MileageBox.Enter += new System.EventHandler(this.MileageBox_Enter);
            this.MileageBox.Leave += new System.EventHandler(this.MileageBox_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(156, 319);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 24);
            this.label6.TabIndex = 35;
            this.label6.Text = "Пробег*";
            // 
            // Calendar
            // 
            this.Calendar.Font = new System.Drawing.Font("Franklin Gothic Book", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Calendar.Location = new System.Drawing.Point(251, 250);
            this.Calendar.Name = "Calendar";
            this.Calendar.Size = new System.Drawing.Size(306, 35);
            this.Calendar.TabIndex = 36;
            // 
            // Buses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(572, 425);
            this.Controls.Add(this.Calendar);
            this.Controls.Add(this.MileageBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.BrandBox);
            this.Controls.Add(this.ModelBox);
            this.Controls.Add(this.IndividualNumberBox);
            this.Controls.Add(this.LicensePlateBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Buses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dream Bus";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Buses_FormClosing);
            this.Load += new System.EventHandler(this.Buses_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.TextBox BrandBox;
        private System.Windows.Forms.TextBox ModelBox;
        private System.Windows.Forms.TextBox IndividualNumberBox;
        private System.Windows.Forms.TextBox LicensePlateBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox MileageBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker Calendar;
    }
}