﻿namespace Contact_Center_Kone.View
{
    partial class Multimedia
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
            this.eMAILToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sMSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vOICEMAILToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl_Multimedia = new System.Windows.Forms.TabControl();
            this.tabPage_Email = new System.Windows.Forms.TabPage();
            this.tabPage_Sms = new System.Windows.Forms.TabPage();
            this.tabPage_VoiceMail = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabControl_Multimedia.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.menuStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabControl_Multimedia, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(970, 470);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Turquoise;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eMAILToolStripMenuItem,
            this.sMSToolStripMenuItem,
            this.vOICEMAILToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(970, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // eMAILToolStripMenuItem
            // 
            this.eMAILToolStripMenuItem.Enabled = false;
            this.eMAILToolStripMenuItem.Name = "eMAILToolStripMenuItem";
            this.eMAILToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.eMAILToolStripMenuItem.Text = "EMAIL";
            this.eMAILToolStripMenuItem.Click += new System.EventHandler(this.eMAILToolStripMenuItem_Click);
            // 
            // sMSToolStripMenuItem
            // 
            this.sMSToolStripMenuItem.Enabled = false;
            this.sMSToolStripMenuItem.Name = "sMSToolStripMenuItem";
            this.sMSToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.sMSToolStripMenuItem.Text = "SMS";
            this.sMSToolStripMenuItem.Click += new System.EventHandler(this.sMSToolStripMenuItem_Click);
            // 
            // vOICEMAILToolStripMenuItem
            // 
            this.vOICEMAILToolStripMenuItem.Name = "vOICEMAILToolStripMenuItem";
            this.vOICEMAILToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.vOICEMAILToolStripMenuItem.Text = "VOICE MAIL";
            this.vOICEMAILToolStripMenuItem.Click += new System.EventHandler(this.vOICEMAILToolStripMenuItem_Click);
            // 
            // tabControl_Multimedia
            // 
            this.tabControl_Multimedia.Controls.Add(this.tabPage_Email);
            this.tabControl_Multimedia.Controls.Add(this.tabPage_Sms);
            this.tabControl_Multimedia.Controls.Add(this.tabPage_VoiceMail);
            this.tabControl_Multimedia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_Multimedia.Location = new System.Drawing.Point(3, 31);
            this.tabControl_Multimedia.Name = "tabControl_Multimedia";
            this.tabControl_Multimedia.SelectedIndex = 0;
            this.tabControl_Multimedia.Size = new System.Drawing.Size(964, 436);
            this.tabControl_Multimedia.TabIndex = 1;
            // 
            // tabPage_Email
            // 
            this.tabPage_Email.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Email.Name = "tabPage_Email";
            this.tabPage_Email.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Email.Size = new System.Drawing.Size(956, 410);
            this.tabPage_Email.TabIndex = 0;
            this.tabPage_Email.Text = "EMAIL";
            this.tabPage_Email.UseVisualStyleBackColor = true;
            // 
            // tabPage_Sms
            // 
            this.tabPage_Sms.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Sms.Name = "tabPage_Sms";
            this.tabPage_Sms.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Sms.Size = new System.Drawing.Size(956, 410);
            this.tabPage_Sms.TabIndex = 1;
            this.tabPage_Sms.Text = "SMS";
            this.tabPage_Sms.UseVisualStyleBackColor = true;
            // 
            // tabPage_VoiceMail
            // 
            this.tabPage_VoiceMail.Location = new System.Drawing.Point(4, 22);
            this.tabPage_VoiceMail.Name = "tabPage_VoiceMail";
            this.tabPage_VoiceMail.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_VoiceMail.Size = new System.Drawing.Size(956, 410);
            this.tabPage_VoiceMail.TabIndex = 2;
            this.tabPage_VoiceMail.Text = "VOICE MAIL";
            this.tabPage_VoiceMail.UseVisualStyleBackColor = true;
            // 
            // Multimedia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(970, 470);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Multimedia";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Multimedia";
            this.Load += new System.EventHandler(this.Multimedia_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl_Multimedia.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem eMAILToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sMSToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl_Multimedia;
        private System.Windows.Forms.TabPage tabPage_Email;
        private System.Windows.Forms.TabPage tabPage_Sms;
        private System.Windows.Forms.ToolStripMenuItem vOICEMAILToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage_VoiceMail;


    }
}