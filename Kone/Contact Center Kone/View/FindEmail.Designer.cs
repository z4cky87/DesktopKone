namespace Contact_Center_Kone.View
{
    partial class FindEmail
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_status = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_direction = new System.Windows.Forms.ComboBox();
            this.btn_new_email = new System.Windows.Forms.Button();
            this.lbl_CountGrid = new System.Windows.Forms.Label();
            this.btn_search = new System.Windows.Forms.Button();
            this.dte_until = new System.Windows.Forms.DateTimePicker();
            this.dte_from = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtgrid_findemail = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_subject = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrid_findemail)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtgrid_findemail, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(871, 490);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PowderBlue;
            this.panel1.Controls.Add(this.txt_subject);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cmb_status);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmb_direction);
            this.panel1.Controls.Add(this.btn_new_email);
            this.panel1.Controls.Add(this.lbl_CountGrid);
            this.panel1.Controls.Add(this.btn_search);
            this.panel1.Controls.Add(this.dte_until);
            this.panel1.Controls.Add(this.dte_from);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(865, 54);
            this.panel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(341, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 18);
            this.label4.TabIndex = 16;
            this.label4.Text = "STATUS";
            // 
            // cmb_status
            // 
            this.cmb_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_status.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmb_status.FormattingEnabled = true;
            this.cmb_status.Location = new System.Drawing.Point(344, 26);
            this.cmb_status.Name = "cmb_status";
            this.cmb_status.Size = new System.Drawing.Size(109, 21);
            this.cmb_status.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(234, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 18);
            this.label3.TabIndex = 14;
            this.label3.Text = "DIRECTION";
            // 
            // cmb_direction
            // 
            this.cmb_direction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_direction.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmb_direction.FormattingEnabled = true;
            this.cmb_direction.Location = new System.Drawing.Point(237, 27);
            this.cmb_direction.Name = "cmb_direction";
            this.cmb_direction.Size = new System.Drawing.Size(98, 21);
            this.cmb_direction.TabIndex = 11;
            this.cmb_direction.SelectedValueChanged += new System.EventHandler(this.cmb_direction_SelectedValueChanged);
            // 
            // btn_new_email
            // 
            this.btn_new_email.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_new_email.Location = new System.Drawing.Point(751, 27);
            this.btn_new_email.Name = "btn_new_email";
            this.btn_new_email.Size = new System.Drawing.Size(70, 23);
            this.btn_new_email.TabIndex = 6;
            this.btn_new_email.Text = "New Email";
            this.btn_new_email.UseVisualStyleBackColor = true;
            this.btn_new_email.Click += new System.EventHandler(this.btn_new_email_Click);
            // 
            // lbl_CountGrid
            // 
            this.lbl_CountGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_CountGrid.AutoSize = true;
            this.lbl_CountGrid.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CountGrid.Location = new System.Drawing.Point(827, 33);
            this.lbl_CountGrid.Name = "lbl_CountGrid";
            this.lbl_CountGrid.Size = new System.Drawing.Size(29, 18);
            this.lbl_CountGrid.TabIndex = 5;
            this.lbl_CountGrid.Text = "List";
            // 
            // btn_search
            // 
            this.btn_search.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_search.Location = new System.Drawing.Point(670, 27);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 23);
            this.btn_search.TabIndex = 4;
            this.btn_search.Text = "Search";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // dte_until
            // 
            this.dte_until.CustomFormat = "dd -MM- yyyy";
            this.dte_until.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte_until.Location = new System.Drawing.Point(123, 29);
            this.dte_until.Name = "dte_until";
            this.dte_until.Size = new System.Drawing.Size(105, 20);
            this.dte_until.TabIndex = 3;
            // 
            // dte_from
            // 
            this.dte_from.CustomFormat = "dd -MM- yyyy";
            this.dte_from.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte_from.Location = new System.Drawing.Point(12, 30);
            this.dte_from.Name = "dte_from";
            this.dte_from.Size = new System.Drawing.Size(104, 20);
            this.dte_from.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(120, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "UNTIL";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "FROM";
            // 
            // dtgrid_findemail
            // 
            this.dtgrid_findemail.AllowUserToAddRows = false;
            this.dtgrid_findemail.AllowUserToDeleteRows = false;
            this.dtgrid_findemail.BackgroundColor = System.Drawing.Color.White;
            this.dtgrid_findemail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgrid_findemail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgrid_findemail.EnableHeadersVisualStyles = false;
            this.dtgrid_findemail.Location = new System.Drawing.Point(3, 63);
            this.dtgrid_findemail.MultiSelect = false;
            this.dtgrid_findemail.Name = "dtgrid_findemail";
            this.dtgrid_findemail.ReadOnly = true;
            this.dtgrid_findemail.RowHeadersVisible = false;
            this.dtgrid_findemail.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dtgrid_findemail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgrid_findemail.Size = new System.Drawing.Size(865, 424);
            this.dtgrid_findemail.TabIndex = 0;
            this.dtgrid_findemail.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgrid_findemail_CellMouseDoubleClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(456, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 18);
            this.label5.TabIndex = 17;
            this.label5.Text = "BY SUBJECT";
            // 
            // txt_subject
            // 
            this.txt_subject.Location = new System.Drawing.Point(459, 25);
            this.txt_subject.Name = "txt_subject";
            this.txt_subject.Size = new System.Drawing.Size(205, 20);
            this.txt_subject.TabIndex = 18;
            // 
            // FindEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(871, 490);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FindEmail";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FindEmail";
            this.Load += new System.EventHandler(this.FindEmail_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrid_findemail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_CountGrid;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.DateTimePicker dte_until;
        private System.Windows.Forms.DateTimePicker dte_from;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtgrid_findemail;
        private System.Windows.Forms.Button btn_new_email;
        private System.Windows.Forms.ComboBox cmb_direction;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_status;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_subject;
    }
}