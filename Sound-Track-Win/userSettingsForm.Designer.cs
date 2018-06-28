namespace Sound_Track_Win
{
    partial class userSettingsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.usernameBox = new System.Windows.Forms.ComboBox();
            this.btnEditUser = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb12Hr = new System.Windows.Forms.RadioButton();
            this.rb24Hr = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btnEditTimes = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.monEndBox = new System.Windows.Forms.TextBox();
            this.sunEndBox = new System.Windows.Forms.TextBox();
            this.sunStartBox = new System.Windows.Forms.TextBox();
            this.satEndBox = new System.Windows.Forms.TextBox();
            this.friEndBox = new System.Windows.Forms.TextBox();
            this.satStartBox = new System.Windows.Forms.TextBox();
            this.thrEndBox = new System.Windows.Forms.TextBox();
            this.friStartBox = new System.Windows.Forms.TextBox();
            this.wedEndBox = new System.Windows.Forms.TextBox();
            this.thrStartBox = new System.Windows.Forms.TextBox();
            this.tueEndBox = new System.Windows.Forms.TextBox();
            this.wedStartBox = new System.Windows.Forms.TextBox();
            this.tueStartBox = new System.Windows.Forms.TextBox();
            this.monStartBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnChangeUser = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selected User:";
            // 
            // usernameBox
            // 
            this.usernameBox.Enabled = false;
            this.usernameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameBox.Location = new System.Drawing.Point(136, 13);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(185, 28);
            this.usernameBox.TabIndex = 1;
            this.usernameBox.Text = "Loading...";
            // 
            // btnEditUser
            // 
            this.btnEditUser.Location = new System.Drawing.Point(327, 12);
            this.btnEditUser.Name = "btnEditUser";
            this.btnEditUser.Size = new System.Drawing.Size(75, 28);
            this.btnEditUser.TabIndex = 2;
            this.btnEditUser.Text = "Edit";
            this.btnEditUser.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb12Hr);
            this.groupBox1.Controls.Add(this.rb24Hr);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.btnEditTimes);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.monEndBox);
            this.groupBox1.Controls.Add(this.sunEndBox);
            this.groupBox1.Controls.Add(this.sunStartBox);
            this.groupBox1.Controls.Add(this.satEndBox);
            this.groupBox1.Controls.Add(this.friEndBox);
            this.groupBox1.Controls.Add(this.satStartBox);
            this.groupBox1.Controls.Add(this.thrEndBox);
            this.groupBox1.Controls.Add(this.friStartBox);
            this.groupBox1.Controls.Add(this.wedEndBox);
            this.groupBox1.Controls.Add(this.thrStartBox);
            this.groupBox1.Controls.Add(this.tueEndBox);
            this.groupBox1.Controls.Add(this.wedStartBox);
            this.groupBox1.Controls.Add(this.tueStartBox);
            this.groupBox1.Controls.Add(this.monStartBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 10.2F);
            this.groupBox1.Location = new System.Drawing.Point(13, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(470, 338);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "\'Do Not Disturb\' Times";
            // 
            // rb12Hr
            // 
            this.rb12Hr.AutoSize = true;
            this.rb12Hr.Location = new System.Drawing.Point(87, 306);
            this.rb12Hr.Name = "rb12Hr";
            this.rb12Hr.Size = new System.Drawing.Size(63, 23);
            this.rb12Hr.TabIndex = 5;
            this.rb12Hr.Text = "12hr";
            this.rb12Hr.UseVisualStyleBackColor = true;
            this.rb12Hr.CheckedChanged += new System.EventHandler(this.rbHour_CheckedChanged);
            // 
            // rb24Hr
            // 
            this.rb24Hr.AutoSize = true;
            this.rb24Hr.Checked = true;
            this.rb24Hr.Location = new System.Drawing.Point(18, 305);
            this.rb24Hr.Name = "rb24Hr";
            this.rb24Hr.Size = new System.Drawing.Size(63, 23);
            this.rb24Hr.TabIndex = 6;
            this.rb24Hr.TabStop = true;
            this.rb24Hr.Text = "24hr";
            this.rb24Hr.UseVisualStyleBackColor = true;
            this.rb24Hr.CheckedChanged += new System.EventHandler(this.rbHour_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(46, 266);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 19);
            this.label8.TabIndex = 0;
            this.label8.Text = "Sunday Night:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.button2.Location = new System.Drawing.Point(284, 305);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 27);
            this.button2.TabIndex = 2;
            this.button2.Text = "Clear All";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnEditTimes_Click);
            // 
            // btnEditTimes
            // 
            this.btnEditTimes.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.btnEditTimes.Location = new System.Drawing.Point(389, 305);
            this.btnEditTimes.Name = "btnEditTimes";
            this.btnEditTimes.Size = new System.Drawing.Size(75, 27);
            this.btnEditTimes.TabIndex = 2;
            this.btnEditTimes.Text = "Edit";
            this.btnEditTimes.UseVisualStyleBackColor = true;
            this.btnEditTimes.Click += new System.EventHandler(this.btnEditTimes_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 233);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 19);
            this.label7.TabIndex = 0;
            this.label7.Text = "Saturday Night:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(55, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 19);
            this.label6.TabIndex = 0;
            this.label6.Text = "Friday Night:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // monEndBox
            // 
            this.monEndBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monEndBox.Location = new System.Drawing.Point(333, 60);
            this.monEndBox.Name = "monEndBox";
            this.monEndBox.ReadOnly = true;
            this.monEndBox.Size = new System.Drawing.Size(113, 27);
            this.monEndBox.TabIndex = 1;
            this.monEndBox.Tag = "0";
            this.monEndBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.monEndBox.Enter += new System.EventHandler(this.timeBox_Click);
            // 
            // sunEndBox
            // 
            this.sunEndBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sunEndBox.Location = new System.Drawing.Point(333, 258);
            this.sunEndBox.Name = "sunEndBox";
            this.sunEndBox.ReadOnly = true;
            this.sunEndBox.Size = new System.Drawing.Size(113, 27);
            this.sunEndBox.TabIndex = 1;
            this.sunEndBox.Tag = "6";
            this.sunEndBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.sunEndBox.Enter += new System.EventHandler(this.timeBox_Click);
            // 
            // sunStartBox
            // 
            this.sunStartBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sunStartBox.Location = new System.Drawing.Point(195, 258);
            this.sunStartBox.Name = "sunStartBox";
            this.sunStartBox.ReadOnly = true;
            this.sunStartBox.Size = new System.Drawing.Size(113, 27);
            this.sunStartBox.TabIndex = 1;
            this.sunStartBox.Tag = "6";
            this.sunStartBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.sunStartBox.Enter += new System.EventHandler(this.timeBox_Click);
            // 
            // satEndBox
            // 
            this.satEndBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.satEndBox.Location = new System.Drawing.Point(333, 225);
            this.satEndBox.Name = "satEndBox";
            this.satEndBox.ReadOnly = true;
            this.satEndBox.Size = new System.Drawing.Size(113, 27);
            this.satEndBox.TabIndex = 1;
            this.satEndBox.Tag = "5";
            this.satEndBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.satEndBox.Enter += new System.EventHandler(this.timeBox_Click);
            // 
            // friEndBox
            // 
            this.friEndBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.friEndBox.Location = new System.Drawing.Point(333, 192);
            this.friEndBox.Name = "friEndBox";
            this.friEndBox.ReadOnly = true;
            this.friEndBox.Size = new System.Drawing.Size(113, 27);
            this.friEndBox.TabIndex = 1;
            this.friEndBox.Tag = "4";
            this.friEndBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.friEndBox.Enter += new System.EventHandler(this.timeBox_Click);
            // 
            // satStartBox
            // 
            this.satStartBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.satStartBox.Location = new System.Drawing.Point(195, 225);
            this.satStartBox.Name = "satStartBox";
            this.satStartBox.ReadOnly = true;
            this.satStartBox.Size = new System.Drawing.Size(113, 27);
            this.satStartBox.TabIndex = 1;
            this.satStartBox.Tag = "5";
            this.satStartBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.satStartBox.Enter += new System.EventHandler(this.timeBox_Click);
            // 
            // thrEndBox
            // 
            this.thrEndBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thrEndBox.Location = new System.Drawing.Point(333, 159);
            this.thrEndBox.Name = "thrEndBox";
            this.thrEndBox.ReadOnly = true;
            this.thrEndBox.Size = new System.Drawing.Size(113, 27);
            this.thrEndBox.TabIndex = 1;
            this.thrEndBox.Tag = "3";
            this.thrEndBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.thrEndBox.Enter += new System.EventHandler(this.timeBox_Click);
            // 
            // friStartBox
            // 
            this.friStartBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.friStartBox.Location = new System.Drawing.Point(195, 192);
            this.friStartBox.Name = "friStartBox";
            this.friStartBox.ReadOnly = true;
            this.friStartBox.Size = new System.Drawing.Size(113, 27);
            this.friStartBox.TabIndex = 1;
            this.friStartBox.Tag = "4";
            this.friStartBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.friStartBox.Enter += new System.EventHandler(this.timeBox_Click);
            // 
            // wedEndBox
            // 
            this.wedEndBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wedEndBox.Location = new System.Drawing.Point(333, 126);
            this.wedEndBox.Name = "wedEndBox";
            this.wedEndBox.ReadOnly = true;
            this.wedEndBox.Size = new System.Drawing.Size(113, 27);
            this.wedEndBox.TabIndex = 1;
            this.wedEndBox.Tag = "2";
            this.wedEndBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.wedEndBox.Enter += new System.EventHandler(this.timeBox_Click);
            // 
            // thrStartBox
            // 
            this.thrStartBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thrStartBox.Location = new System.Drawing.Point(195, 159);
            this.thrStartBox.Name = "thrStartBox";
            this.thrStartBox.ReadOnly = true;
            this.thrStartBox.Size = new System.Drawing.Size(113, 27);
            this.thrStartBox.TabIndex = 1;
            this.thrStartBox.Tag = "3";
            this.thrStartBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.thrStartBox.Enter += new System.EventHandler(this.timeBox_Click);
            // 
            // tueEndBox
            // 
            this.tueEndBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tueEndBox.Location = new System.Drawing.Point(333, 93);
            this.tueEndBox.Name = "tueEndBox";
            this.tueEndBox.ReadOnly = true;
            this.tueEndBox.Size = new System.Drawing.Size(113, 27);
            this.tueEndBox.TabIndex = 1;
            this.tueEndBox.Tag = "1";
            this.tueEndBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tueEndBox.Enter += new System.EventHandler(this.timeBox_Click);
            // 
            // wedStartBox
            // 
            this.wedStartBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wedStartBox.Location = new System.Drawing.Point(195, 126);
            this.wedStartBox.Name = "wedStartBox";
            this.wedStartBox.ReadOnly = true;
            this.wedStartBox.Size = new System.Drawing.Size(113, 27);
            this.wedStartBox.TabIndex = 1;
            this.wedStartBox.Tag = "2";
            this.wedStartBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.wedStartBox.Enter += new System.EventHandler(this.timeBox_Click);
            // 
            // tueStartBox
            // 
            this.tueStartBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tueStartBox.Location = new System.Drawing.Point(195, 93);
            this.tueStartBox.Name = "tueStartBox";
            this.tueStartBox.ReadOnly = true;
            this.tueStartBox.Size = new System.Drawing.Size(113, 27);
            this.tueStartBox.TabIndex = 1;
            this.tueStartBox.Tag = "1";
            this.tueStartBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tueStartBox.Enter += new System.EventHandler(this.timeBox_Click);
            // 
            // monStartBox
            // 
            this.monStartBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monStartBox.Location = new System.Drawing.Point(195, 60);
            this.monStartBox.Name = "monStartBox";
            this.monStartBox.ReadOnly = true;
            this.monStartBox.Size = new System.Drawing.Size(113, 27);
            this.monStartBox.TabIndex = 1;
            this.monStartBox.Tag = "0";
            this.monStartBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.monStartBox.Enter += new System.EventHandler(this.timeBox_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "Thursday Night:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "Wednesday Night:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tuesday Night:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(368, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 19);
            this.label10.TabIndex = 0;
            this.label10.Text = "End";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(231, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 19);
            this.label9.TabIndex = 0;
            this.label9.Text = "Start";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Monday Night:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(374, 406);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(109, 42);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(248, 406);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(109, 42);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnChangeUser
            // 
            this.btnChangeUser.Location = new System.Drawing.Point(408, 13);
            this.btnChangeUser.Name = "btnChangeUser";
            this.btnChangeUser.Size = new System.Drawing.Size(75, 27);
            this.btnChangeUser.TabIndex = 2;
            this.btnChangeUser.Text = "New";
            this.btnChangeUser.UseVisualStyleBackColor = true;
            // 
            // userSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 457);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnEditUser);
            this.Controls.Add(this.btnChangeUser);
            this.Controls.Add(this.usernameBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "userSettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "User Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox usernameBox;
        private System.Windows.Forms.Button btnEditUser;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnEditTimes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox monEndBox;
        private System.Windows.Forms.TextBox sunEndBox;
        private System.Windows.Forms.TextBox sunStartBox;
        private System.Windows.Forms.TextBox satEndBox;
        private System.Windows.Forms.TextBox friEndBox;
        private System.Windows.Forms.TextBox satStartBox;
        private System.Windows.Forms.TextBox thrEndBox;
        private System.Windows.Forms.TextBox friStartBox;
        private System.Windows.Forms.TextBox wedEndBox;
        private System.Windows.Forms.TextBox thrStartBox;
        private System.Windows.Forms.TextBox tueEndBox;
        private System.Windows.Forms.TextBox wedStartBox;
        private System.Windows.Forms.TextBox tueStartBox;
        private System.Windows.Forms.TextBox monStartBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton rb12Hr;
        private System.Windows.Forms.RadioButton rb24Hr;
        private System.Windows.Forms.Button btnChangeUser;
    }
}