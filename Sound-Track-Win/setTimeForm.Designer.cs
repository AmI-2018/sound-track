namespace Sound_Track_Win
{
    partial class setTimeForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.startBox = new System.Windows.Forms.TextBox();
            this.btnStHrUp = new System.Windows.Forms.Button();
            this.btnStMinUp = new System.Windows.Forms.Button();
            this.btnStHrDn = new System.Windows.Forms.Button();
            this.btnStMinDn = new System.Windows.Forms.Button();
            this.endBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.rb24Hr = new System.Windows.Forms.RadioButton();
            this.rb12Hr = new System.Windows.Forms.RadioButton();
            this.cbMon = new System.Windows.Forms.CheckBox();
            this.cbTue = new System.Windows.Forms.CheckBox();
            this.cbWed = new System.Windows.Forms.CheckBox();
            this.cbThur = new System.Windows.Forms.CheckBox();
            this.cbFri = new System.Windows.Forms.CheckBox();
            this.cbSat = new System.Windows.Forms.CheckBox();
            this.cbSun = new System.Windows.Forms.CheckBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSet = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10.2F);
            this.label1.Location = new System.Drawing.Point(43, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Start";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10.2F);
            this.label2.Location = new System.Drawing.Point(198, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "End";
            // 
            // startBox
            // 
            this.startBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startBox.Location = new System.Drawing.Point(12, 77);
            this.startBox.Name = "startBox";
            this.startBox.ReadOnly = true;
            this.startBox.Size = new System.Drawing.Size(113, 27);
            this.startBox.TabIndex = 98;
            this.startBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.startBox.Enter += new System.EventHandler(this.TextBox_Focused);
            // 
            // btnStHrUp
            // 
            this.btnStHrUp.Location = new System.Drawing.Point(23, 46);
            this.btnStHrUp.Name = "btnStHrUp";
            this.btnStHrUp.Size = new System.Drawing.Size(32, 25);
            this.btnStHrUp.TabIndex = 3;
            this.btnStHrUp.Tag = "0";
            this.btnStHrUp.Text = "+";
            this.btnStHrUp.UseVisualStyleBackColor = true;
            this.btnStHrUp.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStMinUp
            // 
            this.btnStMinUp.Location = new System.Drawing.Point(78, 46);
            this.btnStMinUp.Name = "btnStMinUp";
            this.btnStMinUp.Size = new System.Drawing.Size(32, 25);
            this.btnStMinUp.TabIndex = 3;
            this.btnStMinUp.Tag = "1";
            this.btnStMinUp.Text = "+";
            this.btnStMinUp.UseVisualStyleBackColor = true;
            this.btnStMinUp.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStHrDn
            // 
            this.btnStHrDn.Location = new System.Drawing.Point(23, 110);
            this.btnStHrDn.Name = "btnStHrDn";
            this.btnStHrDn.Size = new System.Drawing.Size(32, 25);
            this.btnStHrDn.TabIndex = 3;
            this.btnStHrDn.Tag = "2";
            this.btnStHrDn.Text = "-";
            this.btnStHrDn.UseVisualStyleBackColor = true;
            this.btnStHrDn.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStMinDn
            // 
            this.btnStMinDn.Location = new System.Drawing.Point(78, 110);
            this.btnStMinDn.Name = "btnStMinDn";
            this.btnStMinDn.Size = new System.Drawing.Size(32, 25);
            this.btnStMinDn.TabIndex = 3;
            this.btnStMinDn.Tag = "3";
            this.btnStMinDn.Text = "-";
            this.btnStMinDn.UseVisualStyleBackColor = true;
            this.btnStMinDn.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // endBox
            // 
            this.endBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endBox.Location = new System.Drawing.Point(163, 77);
            this.endBox.Name = "endBox";
            this.endBox.ReadOnly = true;
            this.endBox.Size = new System.Drawing.Size(113, 27);
            this.endBox.TabIndex = 99;
            this.endBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.endBox.Enter += new System.EventHandler(this.TextBox_Focused);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(174, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 25);
            this.button1.TabIndex = 3;
            this.button1.Tag = "0";
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(174, 110);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(32, 25);
            this.button2.TabIndex = 3;
            this.button2.Tag = "2";
            this.button2.Text = "-";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(229, 46);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(32, 25);
            this.button3.TabIndex = 3;
            this.button3.Tag = "1";
            this.button3.Text = "+";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(229, 110);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(32, 25);
            this.button4.TabIndex = 3;
            this.button4.Tag = "3";
            this.button4.Text = "-";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // rb24Hr
            // 
            this.rb24Hr.AutoSize = true;
            this.rb24Hr.Checked = true;
            this.rb24Hr.Location = new System.Drawing.Point(296, 94);
            this.rb24Hr.Name = "rb24Hr";
            this.rb24Hr.Size = new System.Drawing.Size(58, 21);
            this.rb24Hr.TabIndex = 4;
            this.rb24Hr.TabStop = true;
            this.rb24Hr.Text = "24hr";
            this.rb24Hr.UseVisualStyleBackColor = true;
            this.rb24Hr.Click += new System.EventHandler(this.rbHourFormat_Click);
            // 
            // rb12Hr
            // 
            this.rb12Hr.AutoSize = true;
            this.rb12Hr.Location = new System.Drawing.Point(296, 67);
            this.rb12Hr.Name = "rb12Hr";
            this.rb12Hr.Size = new System.Drawing.Size(58, 21);
            this.rb12Hr.TabIndex = 4;
            this.rb12Hr.Text = "12hr";
            this.rb12Hr.UseVisualStyleBackColor = true;
            this.rb12Hr.Click += new System.EventHandler(this.rbHourFormat_Click);
            // 
            // cbMon
            // 
            this.cbMon.AutoSize = true;
            this.cbMon.Location = new System.Drawing.Point(38, 161);
            this.cbMon.Name = "cbMon";
            this.cbMon.Size = new System.Drawing.Size(57, 21);
            this.cbMon.TabIndex = 5;
            this.cbMon.Text = "Mon";
            this.cbMon.UseVisualStyleBackColor = true;
            // 
            // cbTue
            // 
            this.cbTue.AutoSize = true;
            this.cbTue.Location = new System.Drawing.Point(101, 161);
            this.cbTue.Name = "cbTue";
            this.cbTue.Size = new System.Drawing.Size(55, 21);
            this.cbTue.TabIndex = 5;
            this.cbTue.Text = "Tue";
            this.cbTue.UseVisualStyleBackColor = true;
            // 
            // cbWed
            // 
            this.cbWed.AutoSize = true;
            this.cbWed.Location = new System.Drawing.Point(162, 161);
            this.cbWed.Name = "cbWed";
            this.cbWed.Size = new System.Drawing.Size(59, 21);
            this.cbWed.TabIndex = 5;
            this.cbWed.Text = "Wed";
            this.cbWed.UseVisualStyleBackColor = true;
            // 
            // cbThur
            // 
            this.cbThur.AutoSize = true;
            this.cbThur.Location = new System.Drawing.Point(227, 161);
            this.cbThur.Name = "cbThur";
            this.cbThur.Size = new System.Drawing.Size(60, 21);
            this.cbThur.TabIndex = 5;
            this.cbThur.Text = "Thur";
            this.cbThur.UseVisualStyleBackColor = true;
            // 
            // cbFri
            // 
            this.cbFri.AutoSize = true;
            this.cbFri.Location = new System.Drawing.Point(293, 161);
            this.cbFri.Name = "cbFri";
            this.cbFri.Size = new System.Drawing.Size(46, 21);
            this.cbFri.TabIndex = 5;
            this.cbFri.Text = "Fri";
            this.cbFri.UseVisualStyleBackColor = true;
            // 
            // cbSat
            // 
            this.cbSat.AutoSize = true;
            this.cbSat.Location = new System.Drawing.Point(128, 188);
            this.cbSat.Name = "cbSat";
            this.cbSat.Size = new System.Drawing.Size(51, 21);
            this.cbSat.TabIndex = 5;
            this.cbSat.Text = "Sat";
            this.cbSat.UseVisualStyleBackColor = true;
            // 
            // cbSun
            // 
            this.cbSun.AutoSize = true;
            this.cbSun.Location = new System.Drawing.Point(185, 188);
            this.cbSun.Name = "cbSun";
            this.cbSun.Size = new System.Drawing.Size(55, 21);
            this.cbSun.TabIndex = 5;
            this.cbSun.Text = "Sun";
            this.cbSun.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(285, 279);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 32);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(185, 231);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(97, 32);
            this.btnSet.TabIndex = 6;
            this.btnSet.Text = "Set Days";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(82, 231);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(97, 32);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear Days";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // setTimeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 323);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cbSun);
            this.Controls.Add(this.cbFri);
            this.Controls.Add(this.cbSat);
            this.Controls.Add(this.cbThur);
            this.Controls.Add(this.cbWed);
            this.Controls.Add(this.cbTue);
            this.Controls.Add(this.cbMon);
            this.Controls.Add(this.rb12Hr);
            this.Controls.Add(this.rb24Hr);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnStMinDn);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnStMinUp);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnStHrDn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnStHrUp);
            this.Controls.Add(this.endBox);
            this.Controls.Add(this.startBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "setTimeForm";
            this.Text = "Set Time";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox startBox;
        private System.Windows.Forms.Button btnStHrUp;
        private System.Windows.Forms.Button btnStMinUp;
        private System.Windows.Forms.Button btnStHrDn;
        private System.Windows.Forms.Button btnStMinDn;
        private System.Windows.Forms.TextBox endBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.RadioButton rb24Hr;
        private System.Windows.Forms.RadioButton rb12Hr;
        private System.Windows.Forms.CheckBox cbMon;
        private System.Windows.Forms.CheckBox cbTue;
        private System.Windows.Forms.CheckBox cbWed;
        private System.Windows.Forms.CheckBox cbThur;
        private System.Windows.Forms.CheckBox cbFri;
        private System.Windows.Forms.CheckBox cbSat;
        private System.Windows.Forms.CheckBox cbSun;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.Button btnClear;
    }
}