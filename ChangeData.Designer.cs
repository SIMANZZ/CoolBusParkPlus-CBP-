namespace CBP
{
    partial class ChangeData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeData));
            this.RetryNewPassBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.ChangeButton = new System.Windows.Forms.Button();
            this.OldPassBox = new System.Windows.Forms.TextBox();
            this.NewPassBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LoginBox = new System.Windows.Forms.TextBox();
            this.EmailBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RetryNewPassBox
            // 
            this.RetryNewPassBox.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RetryNewPassBox.ForeColor = System.Drawing.Color.Silver;
            this.RetryNewPassBox.Location = new System.Drawing.Point(251, 237);
            this.RetryNewPassBox.Name = "RetryNewPassBox";
            this.RetryNewPassBox.Size = new System.Drawing.Size(306, 35);
            this.RetryNewPassBox.TabIndex = 3;
            this.RetryNewPassBox.Text = "повтор нового пароля";
            this.RetryNewPassBox.Enter += new System.EventHandler(this.RetryNewPassBox_Enter);
            this.RetryNewPassBox.Leave += new System.EventHandler(this.RetryNewPassBox_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 244);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(233, 24);
            this.label6.TabIndex = 49;
            this.label6.Text = "Повтор нового пароля*";
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.White;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExitButton.ForeColor = System.Drawing.Color.RoyalBlue;
            this.ExitButton.Location = new System.Drawing.Point(149, 292);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(0);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(98, 43);
            this.ExitButton.TabIndex = 7;
            this.ExitButton.Text = "Отмена";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // ChangeButton
            // 
            this.ChangeButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.ChangeButton.FlatAppearance.BorderSize = 0;
            this.ChangeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChangeButton.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChangeButton.ForeColor = System.Drawing.Color.White;
            this.ChangeButton.Location = new System.Drawing.Point(253, 292);
            this.ChangeButton.Margin = new System.Windows.Forms.Padding(0);
            this.ChangeButton.Name = "ChangeButton";
            this.ChangeButton.Size = new System.Drawing.Size(306, 43);
            this.ChangeButton.TabIndex = 6;
            this.ChangeButton.Text = "Изменить";
            this.ChangeButton.UseVisualStyleBackColor = false;
            this.ChangeButton.Click += new System.EventHandler(this.ChangeButton_Click);
            // 
            // OldPassBox
            // 
            this.OldPassBox.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OldPassBox.ForeColor = System.Drawing.Color.Silver;
            this.OldPassBox.Location = new System.Drawing.Point(253, 129);
            this.OldPassBox.Name = "OldPassBox";
            this.OldPassBox.Size = new System.Drawing.Size(306, 35);
            this.OldPassBox.TabIndex = 1;
            this.OldPassBox.Text = "старый пароль";
            this.OldPassBox.Enter += new System.EventHandler(this.OldPassBox_Enter);
            this.OldPassBox.Leave += new System.EventHandler(this.OldPassBox_Leave);
            // 
            // NewPassBox
            // 
            this.NewPassBox.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NewPassBox.ForeColor = System.Drawing.Color.Silver;
            this.NewPassBox.Location = new System.Drawing.Point(253, 182);
            this.NewPassBox.Name = "NewPassBox";
            this.NewPassBox.Size = new System.Drawing.Size(306, 35);
            this.NewPassBox.TabIndex = 2;
            this.NewPassBox.Text = "новый пароль";
            this.NewPassBox.Enter += new System.EventHandler(this.NewPassBox_Enter);
            this.NewPassBox.Leave += new System.EventHandler(this.NewPassBox_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(83, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 24);
            this.label5.TabIndex = 47;
            this.label5.Text = "Новый пароль*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(72, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(165, 24);
            this.label4.TabIndex = 46;
            this.label4.Text = "Старый пароль*";
            // 
            // LoginBox
            // 
            this.LoginBox.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoginBox.ForeColor = System.Drawing.Color.Silver;
            this.LoginBox.Location = new System.Drawing.Point(251, 18);
            this.LoginBox.Name = "LoginBox";
            this.LoginBox.Size = new System.Drawing.Size(306, 35);
            this.LoginBox.TabIndex = 4;
            this.LoginBox.Text = "логин";
            this.LoginBox.Enter += new System.EventHandler(this.LoginBox_Enter);
            this.LoginBox.Leave += new System.EventHandler(this.LoginBox_Leave);
            // 
            // EmailBox
            // 
            this.EmailBox.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EmailBox.ForeColor = System.Drawing.Color.Silver;
            this.EmailBox.Location = new System.Drawing.Point(251, 77);
            this.EmailBox.Name = "EmailBox";
            this.EmailBox.Size = new System.Drawing.Size(306, 35);
            this.EmailBox.TabIndex = 5;
            this.EmailBox.Text = "email";
            this.EmailBox.Enter += new System.EventHandler(this.EmailBox_Enter);
            this.EmailBox.Leave += new System.EventHandler(this.EmailBox_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(168, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 24);
            this.label3.TabIndex = 54;
            this.label3.Text = "Email*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(163, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 24);
            this.label1.TabIndex = 53;
            this.label1.Text = "Логин*";
            // 
            // ChangeData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(569, 350);
            this.Controls.Add(this.LoginBox);
            this.Controls.Add(this.EmailBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RetryNewPassBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.ChangeButton);
            this.Controls.Add(this.OldPassBox);
            this.Controls.Add(this.NewPassBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangeData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dream Bus";
            this.Load += new System.EventHandler(this.ChangeData_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox RetryNewPassBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button ChangeButton;
        private System.Windows.Forms.TextBox OldPassBox;
        private System.Windows.Forms.TextBox NewPassBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox LoginBox;
        private System.Windows.Forms.TextBox EmailBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}