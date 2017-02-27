﻿namespace Contact_Center_Kone.View
{
    partial class Report
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.callToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hourlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dailyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.performanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.breakToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.voiceMailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pBXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl_Report = new System.Windows.Forms.TabControl();
            this.tabPage_Call = new System.Windows.Forms.TabPage();
            this.tabPage_Hourly = new System.Windows.Forms.TabPage();
            this.tabPage_Daily = new System.Windows.Forms.TabPage();
            this.tabPage_Performance = new System.Windows.Forms.TabPage();
            this.tabPage_Sms = new System.Windows.Forms.TabPage();
            this.tabPage_Email = new System.Windows.Forms.TabPage();
            this.tabPage_Break = new System.Windows.Forms.TabPage();
            this.tabPage_Login = new System.Windows.Forms.TabPage();
            this.tabPage_VoicMail = new System.Windows.Forms.TabPage();
            this.tabPage_PBX = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabControl_Report.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.menuStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabControl_Report, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(858, 516);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip1.BackColor = System.Drawing.Color.Turquoise;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.callToolStripMenuItem,
            this.hourlyToolStripMenuItem,
            this.dailyToolStripMenuItem,
            this.performanceToolStripMenuItem,
            this.smsToolStripMenuItem,
            this.emailToolStripMenuItem,
            this.breakToolStripMenuItem,
            this.loginToolStripMenuItem,
            this.voiceMailToolStripMenuItem,
            this.pBXToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 2);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(858, 26);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // callToolStripMenuItem
            // 
            this.callToolStripMenuItem.Name = "callToolStripMenuItem";
            this.callToolStripMenuItem.Size = new System.Drawing.Size(43, 22);
            this.callToolStripMenuItem.Text = "Call";
            this.callToolStripMenuItem.Click += new System.EventHandler(this.callToolStripMenuItem_Click);
            // 
            // hourlyToolStripMenuItem
            // 
            this.hourlyToolStripMenuItem.Name = "hourlyToolStripMenuItem";
            this.hourlyToolStripMenuItem.Size = new System.Drawing.Size(61, 22);
            this.hourlyToolStripMenuItem.Text = "Hourly";
            this.hourlyToolStripMenuItem.Click += new System.EventHandler(this.hourlyToolStripMenuItem_Click);
            // 
            // dailyToolStripMenuItem
            // 
            this.dailyToolStripMenuItem.Name = "dailyToolStripMenuItem";
            this.dailyToolStripMenuItem.Size = new System.Drawing.Size(51, 22);
            this.dailyToolStripMenuItem.Text = "Daily";
            this.dailyToolStripMenuItem.Click += new System.EventHandler(this.dailyToolStripMenuItem_Click);
            // 
            // performanceToolStripMenuItem
            // 
            this.performanceToolStripMenuItem.Name = "performanceToolStripMenuItem";
            this.performanceToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.performanceToolStripMenuItem.Text = "Performance";
            this.performanceToolStripMenuItem.Click += new System.EventHandler(this.performanceToolStripMenuItem_Click);
            // 
            // smsToolStripMenuItem
            // 
            this.smsToolStripMenuItem.Enabled = false;
            this.smsToolStripMenuItem.Name = "smsToolStripMenuItem";
            this.smsToolStripMenuItem.Size = new System.Drawing.Size(45, 22);
            this.smsToolStripMenuItem.Text = "Sms";
            this.smsToolStripMenuItem.Click += new System.EventHandler(this.smsToolStripMenuItem_Click);
            // 
            // emailToolStripMenuItem
            // 
            this.emailToolStripMenuItem.Enabled = false;
            this.emailToolStripMenuItem.Name = "emailToolStripMenuItem";
            this.emailToolStripMenuItem.Size = new System.Drawing.Size(54, 22);
            this.emailToolStripMenuItem.Text = "Email";
            this.emailToolStripMenuItem.Click += new System.EventHandler(this.emailToolStripMenuItem_Click);
            // 
            // breakToolStripMenuItem
            // 
            this.breakToolStripMenuItem.Name = "breakToolStripMenuItem";
            this.breakToolStripMenuItem.Size = new System.Drawing.Size(55, 22);
            this.breakToolStripMenuItem.Text = "Break";
            this.breakToolStripMenuItem.Click += new System.EventHandler(this.breakToolStripMenuItem_Click);
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(53, 22);
            this.loginToolStripMenuItem.Text = "Login";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuItem_Click);
            // 
            // voiceMailToolStripMenuItem
            // 
            this.voiceMailToolStripMenuItem.Name = "voiceMailToolStripMenuItem";
            this.voiceMailToolStripMenuItem.Size = new System.Drawing.Size(81, 22);
            this.voiceMailToolStripMenuItem.Text = "VoiceMail";
            this.voiceMailToolStripMenuItem.Click += new System.EventHandler(this.voiceMailToolStripMenuItem_Click);
            // 
            // pBXToolStripMenuItem
            // 
            this.pBXToolStripMenuItem.Name = "pBXToolStripMenuItem";
            this.pBXToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.pBXToolStripMenuItem.Text = "PBX";
            this.pBXToolStripMenuItem.Click += new System.EventHandler(this.pBXToolStripMenuItem_Click);
            // 
            // tabControl_Report
            // 
            this.tabControl_Report.Controls.Add(this.tabPage_Call);
            this.tabControl_Report.Controls.Add(this.tabPage_Hourly);
            this.tabControl_Report.Controls.Add(this.tabPage_Daily);
            this.tabControl_Report.Controls.Add(this.tabPage_Performance);
            this.tabControl_Report.Controls.Add(this.tabPage_Sms);
            this.tabControl_Report.Controls.Add(this.tabPage_Email);
            this.tabControl_Report.Controls.Add(this.tabPage_Break);
            this.tabControl_Report.Controls.Add(this.tabPage_Login);
            this.tabControl_Report.Controls.Add(this.tabPage_VoicMail);
            this.tabControl_Report.Controls.Add(this.tabPage_PBX);
            this.tabControl_Report.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_Report.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl_Report.Location = new System.Drawing.Point(3, 33);
            this.tabControl_Report.Name = "tabControl_Report";
            this.tabControl_Report.SelectedIndex = 0;
            this.tabControl_Report.Size = new System.Drawing.Size(852, 480);
            this.tabControl_Report.TabIndex = 1;
            // 
            // tabPage_Call
            // 
            this.tabPage_Call.Location = new System.Drawing.Point(4, 24);
            this.tabPage_Call.Name = "tabPage_Call";
            this.tabPage_Call.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Call.Size = new System.Drawing.Size(844, 452);
            this.tabPage_Call.TabIndex = 0;
            this.tabPage_Call.Text = "Call";
            this.tabPage_Call.UseVisualStyleBackColor = true;
            // 
            // tabPage_Hourly
            // 
            this.tabPage_Hourly.Location = new System.Drawing.Point(4, 24);
            this.tabPage_Hourly.Name = "tabPage_Hourly";
            this.tabPage_Hourly.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Hourly.Size = new System.Drawing.Size(844, 452);
            this.tabPage_Hourly.TabIndex = 1;
            this.tabPage_Hourly.Text = "Hourly";
            this.tabPage_Hourly.UseVisualStyleBackColor = true;
            // 
            // tabPage_Daily
            // 
            this.tabPage_Daily.Location = new System.Drawing.Point(4, 24);
            this.tabPage_Daily.Name = "tabPage_Daily";
            this.tabPage_Daily.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Daily.Size = new System.Drawing.Size(844, 452);
            this.tabPage_Daily.TabIndex = 2;
            this.tabPage_Daily.Text = "Daily";
            this.tabPage_Daily.UseVisualStyleBackColor = true;
            // 
            // tabPage_Performance
            // 
            this.tabPage_Performance.Location = new System.Drawing.Point(4, 24);
            this.tabPage_Performance.Name = "tabPage_Performance";
            this.tabPage_Performance.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Performance.Size = new System.Drawing.Size(844, 452);
            this.tabPage_Performance.TabIndex = 3;
            this.tabPage_Performance.Text = "Performance";
            this.tabPage_Performance.UseVisualStyleBackColor = true;
            // 
            // tabPage_Sms
            // 
            this.tabPage_Sms.Location = new System.Drawing.Point(4, 24);
            this.tabPage_Sms.Name = "tabPage_Sms";
            this.tabPage_Sms.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Sms.Size = new System.Drawing.Size(844, 452);
            this.tabPage_Sms.TabIndex = 4;
            this.tabPage_Sms.Text = "Sms";
            this.tabPage_Sms.UseVisualStyleBackColor = true;
            // 
            // tabPage_Email
            // 
            this.tabPage_Email.Location = new System.Drawing.Point(4, 24);
            this.tabPage_Email.Name = "tabPage_Email";
            this.tabPage_Email.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Email.Size = new System.Drawing.Size(844, 452);
            this.tabPage_Email.TabIndex = 5;
            this.tabPage_Email.Text = "Email";
            this.tabPage_Email.UseVisualStyleBackColor = true;
            // 
            // tabPage_Break
            // 
            this.tabPage_Break.Location = new System.Drawing.Point(4, 24);
            this.tabPage_Break.Name = "tabPage_Break";
            this.tabPage_Break.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Break.Size = new System.Drawing.Size(844, 452);
            this.tabPage_Break.TabIndex = 6;
            this.tabPage_Break.Text = "Break";
            this.tabPage_Break.UseVisualStyleBackColor = true;
            // 
            // tabPage_Login
            // 
            this.tabPage_Login.Location = new System.Drawing.Point(4, 24);
            this.tabPage_Login.Name = "tabPage_Login";
            this.tabPage_Login.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Login.Size = new System.Drawing.Size(844, 452);
            this.tabPage_Login.TabIndex = 7;
            this.tabPage_Login.Text = "Login";
            this.tabPage_Login.UseVisualStyleBackColor = true;
            // 
            // tabPage_VoicMail
            // 
            this.tabPage_VoicMail.Location = new System.Drawing.Point(4, 24);
            this.tabPage_VoicMail.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage_VoicMail.Name = "tabPage_VoicMail";
            this.tabPage_VoicMail.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage_VoicMail.Size = new System.Drawing.Size(844, 452);
            this.tabPage_VoicMail.TabIndex = 8;
            this.tabPage_VoicMail.Text = "VoiceMail";
            this.tabPage_VoicMail.UseVisualStyleBackColor = true;
            // 
            // tabPage_PBX
            // 
            this.tabPage_PBX.Location = new System.Drawing.Point(4, 24);
            this.tabPage_PBX.Name = "tabPage_PBX";
            this.tabPage_PBX.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_PBX.Size = new System.Drawing.Size(844, 452);
            this.tabPage_PBX.TabIndex = 9;
            this.tabPage_PBX.Text = "PBX";
            this.tabPage_PBX.UseVisualStyleBackColor = true;
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(858, 516);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Report";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "r";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl_Report.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem callToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hourlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dailyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem performanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem breakToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl_Report;
        private System.Windows.Forms.TabPage tabPage_Call;
        private System.Windows.Forms.TabPage tabPage_Hourly;
        private System.Windows.Forms.TabPage tabPage_Daily;
        private System.Windows.Forms.TabPage tabPage_Performance;
        private System.Windows.Forms.TabPage tabPage_Sms;
        private System.Windows.Forms.TabPage tabPage_Email;
        private System.Windows.Forms.TabPage tabPage_Break;
        private System.Windows.Forms.TabPage tabPage_Login;
        private System.Windows.Forms.ToolStripMenuItem voiceMailToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage_VoicMail;
        private System.Windows.Forms.ToolStripMenuItem pBXToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage_PBX;
    }
}