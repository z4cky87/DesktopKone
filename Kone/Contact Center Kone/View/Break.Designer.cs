namespace Contact_Center_Kone.View
{
    partial class Break
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
            this.Gropbx_break_reason = new System.Windows.Forms.GroupBox();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_break = new System.Windows.Forms.Button();
            this.cmb_break_reason = new System.Windows.Forms.ComboBox();
            this.txt_note_reason = new System.Windows.Forms.TextBox();
            this.GroupBox_pwd = new System.Windows.Forms.GroupBox();
            this.btn_resume_break = new System.Windows.Forms.Button();
            this.txt_enter_pwd = new System.Windows.Forms.TextBox();
            this.lbl__duration_breaktime = new System.Windows.Forms.Label();
            this.lbl_breaktime = new System.Windows.Forms.Label();
            this.Timer_workbreak = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_user = new System.Windows.Forms.Label();
            this.Gropbx_break_reason.SuspendLayout();
            this.GroupBox_pwd.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Gropbx_break_reason
            // 
            this.Gropbx_break_reason.Controls.Add(this.btn_cancel);
            this.Gropbx_break_reason.Controls.Add(this.btn_break);
            this.Gropbx_break_reason.Controls.Add(this.cmb_break_reason);
            this.Gropbx_break_reason.Controls.Add(this.txt_note_reason);
            this.Gropbx_break_reason.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gropbx_break_reason.Location = new System.Drawing.Point(6, 30);
            this.Gropbx_break_reason.Name = "Gropbx_break_reason";
            this.Gropbx_break_reason.Size = new System.Drawing.Size(327, 137);
            this.Gropbx_break_reason.TabIndex = 4;
            this.Gropbx_break_reason.TabStop = false;
            this.Gropbx_break_reason.Text = "Break Reason";
            // 
            // btn_cancel
            // 
            this.btn_cancel.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.Location = new System.Drawing.Point(246, 20);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 7;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_break
            // 
            this.btn_break.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_break.Location = new System.Drawing.Point(161, 20);
            this.btn_break.Name = "btn_break";
            this.btn_break.Size = new System.Drawing.Size(75, 23);
            this.btn_break.TabIndex = 2;
            this.btn_break.Text = "Break";
            this.btn_break.UseVisualStyleBackColor = true;
            this.btn_break.Click += new System.EventHandler(this.btn_break_Click);
            // 
            // cmb_break_reason
            // 
            this.cmb_break_reason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_break_reason.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_break_reason.FormattingEnabled = true;
            this.cmb_break_reason.Location = new System.Drawing.Point(6, 20);
            this.cmb_break_reason.Name = "cmb_break_reason";
            this.cmb_break_reason.Size = new System.Drawing.Size(149, 21);
            this.cmb_break_reason.TabIndex = 5;
            // 
            // txt_note_reason
            // 
            this.txt_note_reason.Location = new System.Drawing.Point(6, 47);
            this.txt_note_reason.Multiline = true;
            this.txt_note_reason.Name = "txt_note_reason";
            this.txt_note_reason.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_note_reason.Size = new System.Drawing.Size(315, 79);
            this.txt_note_reason.TabIndex = 6;
            // 
            // GroupBox_pwd
            // 
            this.GroupBox_pwd.Controls.Add(this.btn_resume_break);
            this.GroupBox_pwd.Controls.Add(this.txt_enter_pwd);
            this.GroupBox_pwd.Enabled = false;
            this.GroupBox_pwd.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox_pwd.Location = new System.Drawing.Point(6, 173);
            this.GroupBox_pwd.Name = "GroupBox_pwd";
            this.GroupBox_pwd.Size = new System.Drawing.Size(327, 56);
            this.GroupBox_pwd.TabIndex = 7;
            this.GroupBox_pwd.TabStop = false;
            this.GroupBox_pwd.Text = "Enter Password";
            // 
            // btn_resume_break
            // 
            this.btn_resume_break.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_resume_break.Location = new System.Drawing.Point(246, 18);
            this.btn_resume_break.Name = "btn_resume_break";
            this.btn_resume_break.Size = new System.Drawing.Size(75, 23);
            this.btn_resume_break.TabIndex = 4;
            this.btn_resume_break.Text = "OK";
            this.btn_resume_break.UseVisualStyleBackColor = true;
            this.btn_resume_break.Click += new System.EventHandler(this.btn_resume_break_Click);
            // 
            // txt_enter_pwd
            // 
            this.txt_enter_pwd.Location = new System.Drawing.Point(6, 20);
            this.txt_enter_pwd.Name = "txt_enter_pwd";
            this.txt_enter_pwd.PasswordChar = '*';
            this.txt_enter_pwd.Size = new System.Drawing.Size(230, 21);
            this.txt_enter_pwd.TabIndex = 0;
            // 
            // lbl__duration_breaktime
            // 
            this.lbl__duration_breaktime.AutoSize = true;
            this.lbl__duration_breaktime.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl__duration_breaktime.Location = new System.Drawing.Point(341, 120);
            this.lbl__duration_breaktime.Name = "lbl__duration_breaktime";
            this.lbl__duration_breaktime.Size = new System.Drawing.Size(121, 36);
            this.lbl__duration_breaktime.TabIndex = 9;
            this.lbl__duration_breaktime.Text = "00:00:00";
            // 
            // lbl_breaktime
            // 
            this.lbl_breaktime.AutoSize = true;
            this.lbl_breaktime.BackColor = System.Drawing.Color.Aqua;
            this.lbl_breaktime.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_breaktime.Location = new System.Drawing.Point(341, 39);
            this.lbl_breaktime.Name = "lbl_breaktime";
            this.lbl_breaktime.Size = new System.Drawing.Size(137, 33);
            this.lbl_breaktime.TabIndex = 8;
            this.lbl_breaktime.Text = "Break Time";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LimeGreen;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(-1, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(751, 24);
            this.panel2.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 19);
            this.label1.TabIndex = 13;
            this.label1.Text = "Break";
            // 
            // lbl_user
            // 
            this.lbl_user.AutoSize = true;
            this.lbl_user.BackColor = System.Drawing.Color.Aqua;
            this.lbl_user.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_user.Location = new System.Drawing.Point(339, 191);
            this.lbl_user.Name = "lbl_user";
            this.lbl_user.Size = new System.Drawing.Size(127, 33);
            this.lbl_user.TabIndex = 36;
            this.lbl_user.Text = "Username";
            // 
            // Break
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(606, 234);
            this.Controls.Add(this.lbl_user);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Gropbx_break_reason);
            this.Controls.Add(this.GroupBox_pwd);
            this.Controls.Add(this.lbl__duration_breaktime);
            this.Controls.Add(this.lbl_breaktime);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Break";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Break";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Break_FormClosing);
            this.Gropbx_break_reason.ResumeLayout(false);
            this.Gropbx_break_reason.PerformLayout();
            this.GroupBox_pwd.ResumeLayout(false);
            this.GroupBox_pwd.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.GroupBox Gropbx_break_reason;
        internal System.Windows.Forms.Button btn_break;
        internal System.Windows.Forms.TextBox txt_note_reason;
        internal System.Windows.Forms.ComboBox cmb_break_reason;
        internal System.Windows.Forms.GroupBox GroupBox_pwd;
        internal System.Windows.Forms.Button btn_resume_break;
        internal System.Windows.Forms.TextBox txt_enter_pwd;
        internal System.Windows.Forms.Label lbl__duration_breaktime;
        internal System.Windows.Forms.Label lbl_breaktime;
        internal System.Windows.Forms.Timer Timer_workbreak;
        internal System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label lbl_user;
        internal System.Windows.Forms.Button btn_cancel;
    }
}