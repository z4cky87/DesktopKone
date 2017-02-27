﻿namespace Contact_Center_Kone.View
{
    partial class CallCenter
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
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.txt_jml_row = new System.Windows.Forms.TextBox();
            this.btn_previous = new System.Windows.Forms.Button();
            this.btn_fisrt = new System.Windows.Forms.Button();
            this.btn_next = new System.Windows.Forms.Button();
            this.btn_last = new System.Windows.Forms.Button();
            this.lbl_rows = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNoData = new System.Windows.Forms.Label();
            this.dtgrid_CallDetail = new System.Windows.Forms.DataGridView();
            this.ContextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.OUTBOUNDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PLAYBACKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkSerialNo = new System.Windows.Forms.CheckBox();
            this.txtSerialNo = new System.Windows.Forms.TextBox();
            this.chkCustomerName = new System.Windows.Forms.CheckBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.chkCallerTypeDetail = new System.Windows.Forms.CheckBox();
            this.cmbCallerTypeDetail = new System.Windows.Forms.ComboBox();
            this.chkCallerType = new System.Windows.Forms.CheckBox();
            this.cmbCallerType = new System.Windows.Forms.ComboBox();
            this.chkPhoneNo = new System.Windows.Forms.CheckBox();
            this.chkUsername = new System.Windows.Forms.CheckBox();
            this.chkCallStatus = new System.Windows.Forms.CheckBox();
            this.chkCallType = new System.Windows.Forms.CheckBox();
            this.chkDirection = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.dtUntil = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cmbDirection = new System.Windows.Forms.ComboBox();
            this.cmbCallType = new System.Windows.Forms.ComboBox();
            this.cmbCallStatus = new System.Windows.Forms.ComboBox();
            this.cmbUsername = new System.Windows.Forms.ComboBox();
            this.txtPhoneNo = new System.Windows.Forms.TextBox();
            this.TableLayoutPanel1.SuspendLayout();
            this.TableLayoutPanel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrid_CallDetail)).BeginInit();
            this.ContextMenuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.AutoScroll = true;
            this.TableLayoutPanel1.ColumnCount = 1;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel1.Controls.Add(this.TableLayoutPanel3, 0, 2);
            this.TableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.TableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 3;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.1982F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 76.8018F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(1028, 476);
            this.TableLayoutPanel1.TabIndex = 1;
            // 
            // TableLayoutPanel3
            // 
            this.TableLayoutPanel3.ColumnCount = 7;
            this.TableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.99309F));
            this.TableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.40276F));
            this.TableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.40276F));
            this.TableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.40276F));
            this.TableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.40276F));
            this.TableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.40276F));
            this.TableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.99309F));
            this.TableLayoutPanel3.Controls.Add(this.txt_jml_row, 3, 0);
            this.TableLayoutPanel3.Controls.Add(this.btn_previous, 2, 0);
            this.TableLayoutPanel3.Controls.Add(this.btn_fisrt, 1, 0);
            this.TableLayoutPanel3.Controls.Add(this.btn_next, 4, 0);
            this.TableLayoutPanel3.Controls.Add(this.btn_last, 5, 0);
            this.TableLayoutPanel3.Controls.Add(this.lbl_rows, 6, 0);
            this.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel3.Location = new System.Drawing.Point(3, 447);
            this.TableLayoutPanel3.Name = "TableLayoutPanel3";
            this.TableLayoutPanel3.RowCount = 1;
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel3.Size = new System.Drawing.Size(1022, 26);
            this.TableLayoutPanel3.TabIndex = 4;
            // 
            // txt_jml_row
            // 
            this.txt_jml_row.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_jml_row.Enabled = false;
            this.txt_jml_row.Location = new System.Drawing.Point(449, 3);
            this.txt_jml_row.Name = "txt_jml_row";
            this.txt_jml_row.Size = new System.Drawing.Size(120, 20);
            this.txt_jml_row.TabIndex = 0;
            this.txt_jml_row.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_previous
            // 
            this.btn_previous.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_previous.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_previous.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_previous.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_previous.Location = new System.Drawing.Point(323, 3);
            this.btn_previous.Name = "btn_previous";
            this.btn_previous.Size = new System.Drawing.Size(120, 20);
            this.btn_previous.TabIndex = 1;
            this.btn_previous.Text = "Previous";
            this.btn_previous.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_previous.UseVisualStyleBackColor = true;
            this.btn_previous.Click += new System.EventHandler(this.btn_previous_Click_1);
            // 
            // btn_fisrt
            // 
            this.btn_fisrt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_fisrt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_fisrt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_fisrt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_fisrt.Location = new System.Drawing.Point(197, 3);
            this.btn_fisrt.Name = "btn_fisrt";
            this.btn_fisrt.Size = new System.Drawing.Size(120, 20);
            this.btn_fisrt.TabIndex = 2;
            this.btn_fisrt.Text = "First";
            this.btn_fisrt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_fisrt.UseVisualStyleBackColor = true;
            this.btn_fisrt.Click += new System.EventHandler(this.btn_fisrt_Click_1);
            // 
            // btn_next
            // 
            this.btn_next.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_next.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_next.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_next.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_next.Location = new System.Drawing.Point(575, 3);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(120, 20);
            this.btn_next.TabIndex = 3;
            this.btn_next.Text = "Next";
            this.btn_next.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_next.UseVisualStyleBackColor = true;
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click_1);
            // 
            // btn_last
            // 
            this.btn_last.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_last.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_last.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_last.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_last.Location = new System.Drawing.Point(701, 3);
            this.btn_last.Name = "btn_last";
            this.btn_last.Size = new System.Drawing.Size(120, 20);
            this.btn_last.TabIndex = 4;
            this.btn_last.Text = "Last";
            this.btn_last.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_last.UseVisualStyleBackColor = true;
            this.btn_last.Click += new System.EventHandler(this.btn_last_Click_1);
            // 
            // lbl_rows
            // 
            this.lbl_rows.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_rows.AutoSize = true;
            this.lbl_rows.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_rows.Location = new System.Drawing.Point(827, 6);
            this.lbl_rows.Name = "lbl_rows";
            this.lbl_rows.Size = new System.Drawing.Size(192, 14);
            this.lbl_rows.TabIndex = 9;
            this.lbl_rows.Text = "0";
            this.lbl_rows.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblNoData);
            this.panel1.Controls.Add(this.dtgrid_CallDetail);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 106);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1022, 335);
            this.panel1.TabIndex = 5;
            // 
            // lblNoData
            // 
            this.lblNoData.AutoSize = true;
            this.lblNoData.BackColor = System.Drawing.Color.White;
            this.lblNoData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoData.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblNoData.Location = new System.Drawing.Point(406, 186);
            this.lblNoData.Name = "lblNoData";
            this.lblNoData.Size = new System.Drawing.Size(120, 16);
            this.lblNoData.TabIndex = 9;
            this.lblNoData.Text = "No data to preview";
            this.lblNoData.Visible = false;
            // 
            // dtgrid_CallDetail
            // 
            this.dtgrid_CallDetail.AllowUserToAddRows = false;
            this.dtgrid_CallDetail.AllowUserToDeleteRows = false;
            this.dtgrid_CallDetail.BackgroundColor = System.Drawing.Color.White;
            this.dtgrid_CallDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgrid_CallDetail.ContextMenuStrip = this.ContextMenuStrip1;
            this.dtgrid_CallDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgrid_CallDetail.Location = new System.Drawing.Point(0, 0);
            this.dtgrid_CallDetail.Name = "dtgrid_CallDetail";
            this.dtgrid_CallDetail.ReadOnly = true;
            this.dtgrid_CallDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgrid_CallDetail.Size = new System.Drawing.Size(1022, 335);
            this.dtgrid_CallDetail.TabIndex = 2;
            this.dtgrid_CallDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgrid_CallDetail_CellContentClick);
            this.dtgrid_CallDetail.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgrid_CallDetail_CellDoubleClick);
            // 
            // ContextMenuStrip1
            // 
            this.ContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OUTBOUNDToolStripMenuItem,
            this.PLAYBACKToolStripMenuItem});
            this.ContextMenuStrip1.Name = "ContextMenuStrip1";
            this.ContextMenuStrip1.Size = new System.Drawing.Size(140, 48);
            // 
            // OUTBOUNDToolStripMenuItem
            // 
            this.OUTBOUNDToolStripMenuItem.BackColor = System.Drawing.Color.Silver;
            this.OUTBOUNDToolStripMenuItem.Name = "OUTBOUNDToolStripMenuItem";
            this.OUTBOUNDToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.OUTBOUNDToolStripMenuItem.Text = "OUTBOUND";
            // 
            // PLAYBACKToolStripMenuItem
            // 
            this.PLAYBACKToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.PLAYBACKToolStripMenuItem.Name = "PLAYBACKToolStripMenuItem";
            this.PLAYBACKToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.PLAYBACKToolStripMenuItem.Text = "PLAYBACK";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.chkSerialNo);
            this.panel2.Controls.Add(this.txtSerialNo);
            this.panel2.Controls.Add(this.chkCustomerName);
            this.panel2.Controls.Add(this.txtCustomerName);
            this.panel2.Controls.Add(this.chkCallerTypeDetail);
            this.panel2.Controls.Add(this.cmbCallerTypeDetail);
            this.panel2.Controls.Add(this.chkCallerType);
            this.panel2.Controls.Add(this.cmbCallerType);
            this.panel2.Controls.Add(this.chkPhoneNo);
            this.panel2.Controls.Add(this.chkUsername);
            this.panel2.Controls.Add(this.chkCallStatus);
            this.panel2.Controls.Add(this.chkCallType);
            this.panel2.Controls.Add(this.chkDirection);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.dtFrom);
            this.panel2.Controls.Add(this.dtUntil);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Controls.Add(this.btnRefresh);
            this.panel2.Controls.Add(this.cmbDirection);
            this.panel2.Controls.Add(this.cmbCallType);
            this.panel2.Controls.Add(this.cmbCallStatus);
            this.panel2.Controls.Add(this.cmbUsername);
            this.panel2.Controls.Add(this.txtPhoneNo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1022, 97);
            this.panel2.TabIndex = 6;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // chkSerialNo
            // 
            this.chkSerialNo.AutoSize = true;
            this.chkSerialNo.Enabled = false;
            this.chkSerialNo.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSerialNo.Location = new System.Drawing.Point(688, 50);
            this.chkSerialNo.Name = "chkSerialNo";
            this.chkSerialNo.Size = new System.Drawing.Size(68, 17);
            this.chkSerialNo.TabIndex = 43;
            this.chkSerialNo.Text = "Serial No";
            this.chkSerialNo.UseVisualStyleBackColor = true;
            this.chkSerialNo.Visible = false;
            this.chkSerialNo.Click += new System.EventHandler(this.chkSerialNo_Click);
            // 
            // txtSerialNo
            // 
            this.txtSerialNo.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerialNo.Location = new System.Drawing.Point(688, 67);
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.Size = new System.Drawing.Size(100, 23);
            this.txtSerialNo.TabIndex = 42;
            this.txtSerialNo.Visible = false;
            this.txtSerialNo.TextChanged += new System.EventHandler(this.txtSerialNo_TextChanged);
            // 
            // chkCustomerName
            // 
            this.chkCustomerName.AutoSize = true;
            this.chkCustomerName.Enabled = false;
            this.chkCustomerName.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCustomerName.Location = new System.Drawing.Point(313, 50);
            this.chkCustomerName.Name = "chkCustomerName";
            this.chkCustomerName.Size = new System.Drawing.Size(102, 17);
            this.chkCustomerName.TabIndex = 41;
            this.chkCustomerName.Text = "Customer Name";
            this.chkCustomerName.UseVisualStyleBackColor = true;
            this.chkCustomerName.Click += new System.EventHandler(this.chkCustomerName_Click);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName.Location = new System.Drawing.Point(313, 67);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(100, 23);
            this.txtCustomerName.TabIndex = 40;
            this.txtCustomerName.TextChanged += new System.EventHandler(this.txtCustomerName_TextChanged);
            // 
            // chkCallerTypeDetail
            // 
            this.chkCallerTypeDetail.AutoSize = true;
            this.chkCallerTypeDetail.Enabled = false;
            this.chkCallerTypeDetail.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCallerTypeDetail.Location = new System.Drawing.Point(514, 6);
            this.chkCallerTypeDetail.Name = "chkCallerTypeDetail";
            this.chkCallerTypeDetail.Size = new System.Drawing.Size(107, 17);
            this.chkCallerTypeDetail.TabIndex = 39;
            this.chkCallerTypeDetail.Text = "Caller type detail";
            this.chkCallerTypeDetail.UseVisualStyleBackColor = true;
            this.chkCallerTypeDetail.Visible = false;
            this.chkCallerTypeDetail.Click += new System.EventHandler(this.chkCallerTypeDetail_Click);
            // 
            // cmbCallerTypeDetail
            // 
            this.cmbCallerTypeDetail.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCallerTypeDetail.DropDownWidth = 200;
            this.cmbCallerTypeDetail.Enabled = false;
            this.cmbCallerTypeDetail.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCallerTypeDetail.FormattingEnabled = true;
            this.cmbCallerTypeDetail.Location = new System.Drawing.Point(513, 23);
            this.cmbCallerTypeDetail.Name = "cmbCallerTypeDetail";
            this.cmbCallerTypeDetail.Size = new System.Drawing.Size(107, 23);
            this.cmbCallerTypeDetail.TabIndex = 38;
            this.cmbCallerTypeDetail.Visible = false;
            this.cmbCallerTypeDetail.SelectedIndexChanged += new System.EventHandler(this.cmbCallerTypeDetail_SelectedIndexChanged);
            // 
            // chkCallerType
            // 
            this.chkCallerType.AutoSize = true;
            this.chkCallerType.Enabled = false;
            this.chkCallerType.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCallerType.Location = new System.Drawing.Point(415, 6);
            this.chkCallerType.Name = "chkCallerType";
            this.chkCallerType.Size = new System.Drawing.Size(77, 17);
            this.chkCallerType.TabIndex = 37;
            this.chkCallerType.Text = "Caller type";
            this.chkCallerType.UseVisualStyleBackColor = true;
            this.chkCallerType.Click += new System.EventHandler(this.checkBox1_Click);
            // 
            // cmbCallerType
            // 
            this.cmbCallerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCallerType.DropDownWidth = 200;
            this.cmbCallerType.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCallerType.FormattingEnabled = true;
            this.cmbCallerType.Location = new System.Drawing.Point(414, 23);
            this.cmbCallerType.Name = "cmbCallerType";
            this.cmbCallerType.Size = new System.Drawing.Size(96, 23);
            this.cmbCallerType.TabIndex = 36;
            this.cmbCallerType.SelectedIndexChanged += new System.EventHandler(this.cmbCallerType_SelectedIndexChanged);
            // 
            // chkPhoneNo
            // 
            this.chkPhoneNo.AutoSize = true;
            this.chkPhoneNo.Enabled = false;
            this.chkPhoneNo.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPhoneNo.Location = new System.Drawing.Point(211, 50);
            this.chkPhoneNo.Name = "chkPhoneNo";
            this.chkPhoneNo.Size = new System.Drawing.Size(70, 17);
            this.chkPhoneNo.TabIndex = 33;
            this.chkPhoneNo.Text = "Phone no";
            this.chkPhoneNo.UseVisualStyleBackColor = true;
            this.chkPhoneNo.Click += new System.EventHandler(this.chkPhoneNo_Click);
            // 
            // chkUsername
            // 
            this.chkUsername.AutoSize = true;
            this.chkUsername.Enabled = false;
            this.chkUsername.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUsername.Location = new System.Drawing.Point(109, 50);
            this.chkUsername.Name = "chkUsername";
            this.chkUsername.Size = new System.Drawing.Size(75, 17);
            this.chkUsername.TabIndex = 35;
            this.chkUsername.Text = "Username";
            this.chkUsername.UseVisualStyleBackColor = true;
            this.chkUsername.Click += new System.EventHandler(this.chkUsername_Click);
            // 
            // chkCallStatus
            // 
            this.chkCallStatus.AutoSize = true;
            this.chkCallStatus.Enabled = false;
            this.chkCallStatus.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCallStatus.Location = new System.Drawing.Point(7, 50);
            this.chkCallStatus.Name = "chkCallStatus";
            this.chkCallStatus.Size = new System.Drawing.Size(76, 17);
            this.chkCallStatus.TabIndex = 34;
            this.chkCallStatus.Text = "Call status";
            this.chkCallStatus.UseVisualStyleBackColor = true;
            this.chkCallStatus.Click += new System.EventHandler(this.chkCallStatus_Click);
            // 
            // chkCallType
            // 
            this.chkCallType.AutoSize = true;
            this.chkCallType.Enabled = false;
            this.chkCallType.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCallType.Location = new System.Drawing.Point(313, 6);
            this.chkCallType.Name = "chkCallType";
            this.chkCallType.Size = new System.Drawing.Size(67, 17);
            this.chkCallType.TabIndex = 33;
            this.chkCallType.Text = "Call type";
            this.chkCallType.UseVisualStyleBackColor = true;
            this.chkCallType.Click += new System.EventHandler(this.chkCallType_Click);
            // 
            // chkDirection
            // 
            this.chkDirection.AutoSize = true;
            this.chkDirection.Enabled = false;
            this.chkDirection.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDirection.Location = new System.Drawing.Point(210, 6);
            this.chkDirection.Name = "chkDirection";
            this.chkDirection.Size = new System.Drawing.Size(69, 17);
            this.chkDirection.TabIndex = 32;
            this.chkDirection.Text = "Direction";
            this.chkDirection.UseVisualStyleBackColor = true;
            this.chkDirection.Click += new System.EventHandler(this.chkDirection_Click);
            this.chkDirection.ChangeUICues += new System.Windows.Forms.UICuesEventHandler(this.chkDirection_ChangeUICues);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "From";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(137, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Until";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // dtFrom
            // 
            this.dtFrom.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFrom.Location = new System.Drawing.Point(6, 23);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(96, 23);
            this.dtFrom.TabIndex = 18;
            // 
            // dtUntil
            // 
            this.dtUntil.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtUntil.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtUntil.Location = new System.Drawing.Point(108, 23);
            this.dtUntil.Name = "dtUntil";
            this.dtUntil.Size = new System.Drawing.Size(96, 23);
            this.dtUntil.TabIndex = 19;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Image = global::Contact_Center_Kone.Properties.Resources.search;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(417, 67);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(71, 23);
            this.btnSearch.TabIndex = 25;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Image = global::Contact_Center_Kone.Properties.Resources.refresh_green;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(494, 67);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(71, 23);
            this.btnRefresh.TabIndex = 26;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cmbDirection
            // 
            this.cmbDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDirection.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDirection.FormattingEnabled = true;
            this.cmbDirection.Items.AddRange(new object[] {
            "INBOUND",
            "OUTBOUND"});
            this.cmbDirection.Location = new System.Drawing.Point(210, 23);
            this.cmbDirection.Name = "cmbDirection";
            this.cmbDirection.Size = new System.Drawing.Size(96, 23);
            this.cmbDirection.TabIndex = 27;
            this.cmbDirection.SelectedIndexChanged += new System.EventHandler(this.cmbDirection_SelectedIndexChanged);
            // 
            // cmbCallType
            // 
            this.cmbCallType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCallType.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCallType.FormattingEnabled = true;
            this.cmbCallType.Location = new System.Drawing.Point(312, 23);
            this.cmbCallType.Name = "cmbCallType";
            this.cmbCallType.Size = new System.Drawing.Size(96, 23);
            this.cmbCallType.TabIndex = 28;
            this.cmbCallType.SelectedIndexChanged += new System.EventHandler(this.cmbCallType_SelectedIndexChanged);
            // 
            // cmbCallStatus
            // 
            this.cmbCallStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCallStatus.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCallStatus.FormattingEnabled = true;
            this.cmbCallStatus.Location = new System.Drawing.Point(6, 67);
            this.cmbCallStatus.Name = "cmbCallStatus";
            this.cmbCallStatus.Size = new System.Drawing.Size(96, 23);
            this.cmbCallStatus.TabIndex = 29;
            this.cmbCallStatus.SelectedIndexChanged += new System.EventHandler(this.cmbCallStatus_SelectedIndexChanged);
            this.cmbCallStatus.Click += new System.EventHandler(this.cmbCallStatus_Click);
            // 
            // cmbUsername
            // 
            this.cmbUsername.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsername.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUsername.FormattingEnabled = true;
            this.cmbUsername.Location = new System.Drawing.Point(108, 67);
            this.cmbUsername.Name = "cmbUsername";
            this.cmbUsername.Size = new System.Drawing.Size(96, 23);
            this.cmbUsername.TabIndex = 30;
            this.cmbUsername.SelectedIndexChanged += new System.EventHandler(this.cmbUsername_SelectedIndexChanged);
            this.cmbUsername.Click += new System.EventHandler(this.cmbUsername_Click);
            // 
            // txtPhoneNo
            // 
            this.txtPhoneNo.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhoneNo.Location = new System.Drawing.Point(210, 67);
            this.txtPhoneNo.Name = "txtPhoneNo";
            this.txtPhoneNo.Size = new System.Drawing.Size(100, 23);
            this.txtPhoneNo.TabIndex = 31;
            this.txtPhoneNo.TextChanged += new System.EventHandler(this.txtPhoneNo_TextChanged);
            // 
            // CallCenter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 476);
            this.Controls.Add(this.TableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CallCenter";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "CallCenter";
            this.Load += new System.EventHandler(this.CallCenter_Load);
            this.Resize += new System.EventHandler(this.CallCenter_Resize);
            this.TableLayoutPanel1.ResumeLayout(false);
            this.TableLayoutPanel3.ResumeLayout(false);
            this.TableLayoutPanel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrid_CallDetail)).EndInit();
            this.ContextMenuStrip1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        internal System.Windows.Forms.ContextMenuStrip ContextMenuStrip1;
        internal System.Windows.Forms.ToolStripMenuItem OUTBOUNDToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem PLAYBACKToolStripMenuItem;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel3;
        internal System.Windows.Forms.TextBox txt_jml_row;
        internal System.Windows.Forms.Button btn_previous;
        internal System.Windows.Forms.Button btn_fisrt;
        internal System.Windows.Forms.Button btn_next;
        internal System.Windows.Forms.Button btn_last;
        internal System.Windows.Forms.Label lbl_rows;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.DataGridView dtgrid_CallDetail;
        private System.Windows.Forms.Label lblNoData;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.DateTimePicker dtUntil;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox cmbDirection;
        private System.Windows.Forms.ComboBox cmbCallType;
        private System.Windows.Forms.ComboBox cmbCallStatus;
        private System.Windows.Forms.ComboBox cmbUsername;
        private System.Windows.Forms.TextBox txtPhoneNo;
        private System.Windows.Forms.CheckBox chkPhoneNo;
        private System.Windows.Forms.CheckBox chkUsername;
        private System.Windows.Forms.CheckBox chkCallStatus;
        private System.Windows.Forms.CheckBox chkCallType;
        private System.Windows.Forms.CheckBox chkDirection;
        private System.Windows.Forms.CheckBox chkCallerType;
        private System.Windows.Forms.ComboBox cmbCallerType;
        private System.Windows.Forms.CheckBox chkCallerTypeDetail;
        private System.Windows.Forms.ComboBox cmbCallerTypeDetail;
        private System.Windows.Forms.CheckBox chkSerialNo;
        private System.Windows.Forms.TextBox txtSerialNo;
        private System.Windows.Forms.CheckBox chkCustomerName;
        private System.Windows.Forms.TextBox txtCustomerName;
    }
}