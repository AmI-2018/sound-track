namespace Sound_Track_Win
{
    partial class formST
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formST));
            this.notifyIconST = new System.Windows.Forms.NotifyIcon(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.statusDisplay = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbTracker = new System.Windows.Forms.RadioButton();
            this.rbOutput = new System.Windows.Forms.RadioButton();
            this.btnUser = new System.Windows.Forms.Button();
            this.process1 = new System.Diagnostics.Process();
            this.btnSystem = new System.Windows.Forms.Button();
            this.trayContextStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showMI = new System.Windows.Forms.ToolStripMenuItem();
            this.userSettingsMI = new System.Windows.Forms.ToolStripMenuItem();
            this.systemSettingsMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitMI = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.trayContextStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIconST
            // 
            this.notifyIconST.ContextMenuStrip = this.trayContextStrip;
            this.notifyIconST.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconST.Icon")));
            this.notifyIconST.Text = "notifyIcon1";
            this.notifyIconST.Visible = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Status:";
            // 
            // statusDisplay
            // 
            this.statusDisplay.AutoSize = true;
            this.statusDisplay.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusDisplay.Location = new System.Drawing.Point(81, 14);
            this.statusDisplay.Name = "statusDisplay";
            this.statusDisplay.Size = new System.Drawing.Size(35, 19);
            this.statusDisplay.TabIndex = 1;
            this.statusDisplay.Text = "Idle";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbTracker);
            this.groupBox1.Controls.Add(this.rbOutput);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(13, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(231, 97);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mode:";
            // 
            // rbTracker
            // 
            this.rbTracker.AutoSize = true;
            this.rbTracker.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTracker.Location = new System.Drawing.Point(6, 56);
            this.rbTracker.Name = "rbTracker";
            this.rbTracker.Size = new System.Drawing.Size(85, 23);
            this.rbTracker.TabIndex = 0;
            this.rbTracker.Text = "Tracker";
            this.rbTracker.UseVisualStyleBackColor = true;
            // 
            // rbOutput
            // 
            this.rbOutput.AutoSize = true;
            this.rbOutput.Checked = true;
            this.rbOutput.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbOutput.Location = new System.Drawing.Point(7, 27);
            this.rbOutput.Name = "rbOutput";
            this.rbOutput.Size = new System.Drawing.Size(77, 23);
            this.rbOutput.TabIndex = 0;
            this.rbOutput.TabStop = true;
            this.rbOutput.Text = "Output";
            this.rbOutput.UseVisualStyleBackColor = true;
            // 
            // btnUser
            // 
            this.btnUser.Font = new System.Drawing.Font("Arial", 10.2F);
            this.btnUser.Location = new System.Drawing.Point(12, 165);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(231, 49);
            this.btnUser.TabIndex = 3;
            this.btnUser.Text = "User Settings";
            this.btnUser.UseVisualStyleBackColor = true;
            // 
            // process1
            // 
            this.process1.StartInfo.Domain = "";
            this.process1.StartInfo.LoadUserProfile = false;
            this.process1.StartInfo.Password = null;
            this.process1.StartInfo.StandardErrorEncoding = null;
            this.process1.StartInfo.StandardOutputEncoding = null;
            this.process1.StartInfo.UserName = "";
            this.process1.SynchronizingObject = this;
            // 
            // btnSystem
            // 
            this.btnSystem.Font = new System.Drawing.Font("Arial", 10.2F);
            this.btnSystem.Location = new System.Drawing.Point(12, 232);
            this.btnSystem.Name = "btnSystem";
            this.btnSystem.Size = new System.Drawing.Size(231, 49);
            this.btnSystem.TabIndex = 3;
            this.btnSystem.Text = "System Settings";
            this.btnSystem.UseVisualStyleBackColor = true;
            // 
            // trayContextStrip
            // 
            this.trayContextStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.trayContextStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showMI,
            this.userSettingsMI,
            this.systemSettingsMI,
            this.toolStripMenuItem1,
            this.exitMI});
            this.trayContextStrip.Name = "trayContextStrip";
            this.trayContextStrip.Size = new System.Drawing.Size(211, 134);
            // 
            // showMI
            // 
            this.showMI.Name = "showMI";
            this.showMI.Size = new System.Drawing.Size(210, 24);
            this.showMI.Text = "Show";
            this.showMI.Click += new System.EventHandler(this.showForm);
            // 
            // userSettingsMI
            // 
            this.userSettingsMI.Name = "userSettingsMI";
            this.userSettingsMI.Size = new System.Drawing.Size(210, 24);
            this.userSettingsMI.Text = "User Settings";
            // 
            // systemSettingsMI
            // 
            this.systemSettingsMI.Name = "systemSettingsMI";
            this.systemSettingsMI.Size = new System.Drawing.Size(210, 24);
            this.systemSettingsMI.Text = "System Settings";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(207, 6);
            // 
            // exitMI
            // 
            this.exitMI.Name = "exitMI";
            this.exitMI.Size = new System.Drawing.Size(210, 24);
            this.exitMI.Text = "Exit";
            // 
            // formST
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(256, 293);
            this.Controls.Add(this.btnSystem);
            this.Controls.Add(this.btnUser);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusDisplay);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "formST";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Sound Track";
            this.SizeChanged += new System.EventHandler(this.formST_SizeChanged);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.trayContextStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIconST;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label statusDisplay;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbTracker;
        private System.Windows.Forms.RadioButton rbOutput;
        private System.Windows.Forms.Button btnUser;
        private System.Diagnostics.Process process1;
        private System.Windows.Forms.Button btnSystem;
        private System.Windows.Forms.ContextMenuStrip trayContextStrip;
        private System.Windows.Forms.ToolStripMenuItem showMI;
        private System.Windows.Forms.ToolStripMenuItem userSettingsMI;
        private System.Windows.Forms.ToolStripMenuItem systemSettingsMI;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitMI;
    }
}

