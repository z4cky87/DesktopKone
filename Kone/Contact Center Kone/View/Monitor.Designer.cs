namespace Contact_Center_Kone.View
{
    partial class Monitor
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
            this.txtActivity = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.rbTransfer = new System.Windows.Forms.RadioButton();
            this.rbWhisper = new System.Windows.Forms.RadioButton();
            this.gb_Whisper = new System.Windows.Forms.GroupBox();
            this.btn_listen = new System.Windows.Forms.Button();
            this.btn_whisper = new System.Windows.Forms.Button();
            this.txt_exten = new System.Windows.Forms.TextBox();
            this.gb_Transfer = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbTransferMakeCall = new System.Windows.Forms.RadioButton();
            this.rbBlindTransfer = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCall = new System.Windows.Forms.Button();
            this.btnBlindTransfer = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtGridUser = new System.Windows.Forms.DataGridView();
            this.txt_user = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.gb_Whisper.SuspendLayout();
            this.gb_Transfer.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridUser)).BeginInit();
            this.SuspendLayout();
            // 
            // txtActivity
            // 
            this.txtActivity.Enabled = false;
            this.txtActivity.Location = new System.Drawing.Point(783, 76);
            this.txtActivity.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtActivity.Name = "txtActivity";
            this.txtActivity.Size = new System.Drawing.Size(313, 22);
            this.txtActivity.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(708, 82);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 17);
            this.label3.TabIndex = 19;
            this.label3.Text = "Activity";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnClose);
            this.groupBox3.Controls.Add(this.txtActivity);
            this.groupBox3.Controls.Add(this.rbTransfer);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.rbWhisper);
            this.groupBox3.Controls.Add(this.gb_Whisper);
            this.groupBox3.Controls.Add(this.txt_exten);
            this.groupBox3.Controls.Add(this.gb_Transfer);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.dtGridUser);
            this.groupBox3.Controls.Add(this.txt_user);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(16, 15);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(1301, 751);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Control";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(1139, 20);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(155, 33);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "Close Monitoring";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // rbTransfer
            // 
            this.rbTransfer.AutoSize = true;
            this.rbTransfer.Location = new System.Drawing.Point(880, 122);
            this.rbTransfer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbTransfer.Name = "rbTransfer";
            this.rbTransfer.Size = new System.Drawing.Size(83, 21);
            this.rbTransfer.TabIndex = 10;
            this.rbTransfer.TabStop = true;
            this.rbTransfer.Text = "Transfer";
            this.rbTransfer.UseVisualStyleBackColor = true;
            this.rbTransfer.CheckedChanged += new System.EventHandler(this.rbTransfer_CheckedChanged);
            // 
            // rbWhisper
            // 
            this.rbWhisper.AutoSize = true;
            this.rbWhisper.Location = new System.Drawing.Point(709, 122);
            this.rbWhisper.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbWhisper.Name = "rbWhisper";
            this.rbWhisper.Size = new System.Drawing.Size(81, 21);
            this.rbWhisper.TabIndex = 9;
            this.rbWhisper.TabStop = true;
            this.rbWhisper.Text = "Whisper";
            this.rbWhisper.UseVisualStyleBackColor = true;
            this.rbWhisper.CheckedChanged += new System.EventHandler(this.rbWhisper_CheckedChanged);
            // 
            // gb_Whisper
            // 
            this.gb_Whisper.Controls.Add(this.btn_listen);
            this.gb_Whisper.Controls.Add(this.btn_whisper);
            this.gb_Whisper.Enabled = false;
            this.gb_Whisper.Location = new System.Drawing.Point(701, 159);
            this.gb_Whisper.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gb_Whisper.Name = "gb_Whisper";
            this.gb_Whisper.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gb_Whisper.Size = new System.Drawing.Size(168, 112);
            this.gb_Whisper.TabIndex = 7;
            this.gb_Whisper.TabStop = false;
            this.gb_Whisper.Text = "Whisper And Listen";
            // 
            // btn_listen
            // 
            this.btn_listen.BackColor = System.Drawing.Color.White;
            this.btn_listen.Location = new System.Drawing.Point(8, 69);
            this.btn_listen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_listen.Name = "btn_listen";
            this.btn_listen.Size = new System.Drawing.Size(155, 34);
            this.btn_listen.TabIndex = 4;
            this.btn_listen.Text = "Listening";
            this.btn_listen.UseVisualStyleBackColor = false;
            this.btn_listen.Click += new System.EventHandler(this.btn_listen_Click);
            // 
            // btn_whisper
            // 
            this.btn_whisper.BackColor = System.Drawing.Color.White;
            this.btn_whisper.Location = new System.Drawing.Point(8, 26);
            this.btn_whisper.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_whisper.Name = "btn_whisper";
            this.btn_whisper.Size = new System.Drawing.Size(155, 33);
            this.btn_whisper.TabIndex = 3;
            this.btn_whisper.Text = "Whisper";
            this.btn_whisper.UseVisualStyleBackColor = false;
            this.btn_whisper.Click += new System.EventHandler(this.btn_whisper_Click);
            // 
            // txt_exten
            // 
            this.txt_exten.Enabled = false;
            this.txt_exten.Location = new System.Drawing.Point(783, 48);
            this.txt_exten.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_exten.Name = "txt_exten";
            this.txt_exten.Size = new System.Drawing.Size(313, 22);
            this.txt_exten.TabIndex = 17;
            // 
            // gb_Transfer
            // 
            this.gb_Transfer.Controls.Add(this.tableLayoutPanel1);
            this.gb_Transfer.Enabled = false;
            this.gb_Transfer.Location = new System.Drawing.Point(872, 159);
            this.gb_Transfer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gb_Transfer.Name = "gb_Transfer";
            this.gb_Transfer.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gb_Transfer.Size = new System.Drawing.Size(381, 112);
            this.gb_Transfer.TabIndex = 8;
            this.gb_Transfer.TabStop = false;
            this.gb_Transfer.Text = "Transfer";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 19);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(373, 89);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbTransferMakeCall);
            this.panel1.Controls.Add(this.rbBlindTransfer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(365, 36);
            this.panel1.TabIndex = 1;
            // 
            // rbTransferMakeCall
            // 
            this.rbTransferMakeCall.AutoSize = true;
            this.rbTransferMakeCall.Location = new System.Drawing.Point(207, 9);
            this.rbTransferMakeCall.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbTransferMakeCall.Name = "rbTransferMakeCall";
            this.rbTransferMakeCall.Size = new System.Drawing.Size(148, 21);
            this.rbTransferMakeCall.TabIndex = 1;
            this.rbTransferMakeCall.TabStop = true;
            this.rbTransferMakeCall.Text = "Transfer Make Call";
            this.rbTransferMakeCall.UseVisualStyleBackColor = true;
            this.rbTransferMakeCall.CheckedChanged += new System.EventHandler(this.rbTransferMakeCall_CheckedChanged);
            // 
            // rbBlindTransfer
            // 
            this.rbBlindTransfer.AutoSize = true;
            this.rbBlindTransfer.Location = new System.Drawing.Point(36, 9);
            this.rbBlindTransfer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbBlindTransfer.Name = "rbBlindTransfer";
            this.rbBlindTransfer.Size = new System.Drawing.Size(118, 21);
            this.rbBlindTransfer.TabIndex = 0;
            this.rbBlindTransfer.TabStop = true;
            this.rbBlindTransfer.Text = "Blind Transfer";
            this.rbBlindTransfer.UseVisualStyleBackColor = true;
            this.rbBlindTransfer.CheckedChanged += new System.EventHandler(this.rbBlindTransfer_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCall);
            this.panel2.Controls.Add(this.btnBlindTransfer);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(4, 48);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(365, 37);
            this.panel2.TabIndex = 2;
            // 
            // btnCall
            // 
            this.btnCall.BackColor = System.Drawing.Color.White;
            this.btnCall.Enabled = false;
            this.btnCall.Location = new System.Drawing.Point(204, 2);
            this.btnCall.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCall.Name = "btnCall";
            this.btnCall.Size = new System.Drawing.Size(155, 33);
            this.btnCall.TabIndex = 5;
            this.btnCall.Text = "Call";
            this.btnCall.UseVisualStyleBackColor = false;
            this.btnCall.Click += new System.EventHandler(this.btnCall_Click);
            // 
            // btnBlindTransfer
            // 
            this.btnBlindTransfer.BackColor = System.Drawing.Color.White;
            this.btnBlindTransfer.Enabled = false;
            this.btnBlindTransfer.Location = new System.Drawing.Point(4, 0);
            this.btnBlindTransfer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBlindTransfer.Name = "btnBlindTransfer";
            this.btnBlindTransfer.Size = new System.Drawing.Size(155, 33);
            this.btnBlindTransfer.TabIndex = 4;
            this.btnBlindTransfer.Text = "Transfer";
            this.btnBlindTransfer.UseVisualStyleBackColor = false;
            this.btnBlindTransfer.Click += new System.EventHandler(this.btnBlindTransfer_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(708, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "Extension";
            // 
            // dtGridUser
            // 
            this.dtGridUser.AllowUserToAddRows = false;
            this.dtGridUser.AllowUserToDeleteRows = false;
            this.dtGridUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridUser.Location = new System.Drawing.Point(8, 23);
            this.dtGridUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtGridUser.MultiSelect = false;
            this.dtGridUser.Name = "dtGridUser";
            this.dtGridUser.ReadOnly = true;
            this.dtGridUser.RowHeadersVisible = false;
            this.dtGridUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGridUser.Size = new System.Drawing.Size(680, 690);
            this.dtGridUser.TabIndex = 0;
            this.dtGridUser.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGridUser_CellClick);
            // 
            // txt_user
            // 
            this.txt_user.Enabled = false;
            this.txt_user.Location = new System.Drawing.Point(783, 20);
            this.txt_user.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_user.Name = "txt_user";
            this.txt_user.Size = new System.Drawing.Size(313, 22);
            this.txt_user.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(705, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "Username";
            // 
            // Monitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1324, 752);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Monitor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monitor";
            this.Load += new System.EventHandler(this.Monitor_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gb_Whisper.ResumeLayout(false);
            this.gb_Transfer.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGridUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtActivity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbTransfer;
        private System.Windows.Forms.RadioButton rbWhisper;
        private System.Windows.Forms.GroupBox gb_Whisper;
        private System.Windows.Forms.Button btn_listen;
        private System.Windows.Forms.Button btn_whisper;
        private System.Windows.Forms.GroupBox gb_Transfer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbTransferMakeCall;
        private System.Windows.Forms.RadioButton rbBlindTransfer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCall;
        private System.Windows.Forms.Button btnBlindTransfer;
        private System.Windows.Forms.DataGridView dtGridUser;
        private System.Windows.Forms.TextBox txt_exten;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_user;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
    }
}