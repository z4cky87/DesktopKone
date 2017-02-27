﻿namespace Contact_Center_Kone.View
{
    partial class ReportHourly
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
            this.cbx_username_in = new System.Windows.Forms.CheckBox();
            this.cmb_username_in = new System.Windows.Forms.ComboBox();
            this.btn_export_inbound = new System.Windows.Forms.Button();
            this.lbl_row_inbound = new System.Windows.Forms.Label();
            this.btn_search_inbound = new System.Windows.Forms.Button();
            this.dte_from_inbound = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtgrid_hourly_inbound = new System.Windows.Forms.DataGridView();
            this.tabControl_ReportHourly = new System.Windows.Forms.TabControl();
            this.tabPage_HourlyInbound = new System.Windows.Forms.TabPage();
            this.tabPage_HourlyOutbound = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbx_username_out = new System.Windows.Forms.CheckBox();
            this.cmb_username_out = new System.Windows.Forms.ComboBox();
            this.btn_export_outbound = new System.Windows.Forms.Button();
            this.lbl_row_outbound = new System.Windows.Forms.Label();
            this.btn_search_outbound = new System.Windows.Forms.Button();
            this.dte_from_outbound = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtgrid_hourly_outbound = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrid_hourly_inbound)).BeginInit();
            this.tabControl_ReportHourly.SuspendLayout();
            this.tabPage_HourlyInbound.SuspendLayout();
            this.tabPage_HourlyOutbound.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrid_hourly_outbound)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtgrid_hourly_inbound, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(914, 482);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PowderBlue;
            this.panel1.Controls.Add(this.cbx_username_in);
            this.panel1.Controls.Add(this.cmb_username_in);
            this.panel1.Controls.Add(this.btn_export_inbound);
            this.panel1.Controls.Add(this.lbl_row_inbound);
            this.panel1.Controls.Add(this.btn_search_inbound);
            this.panel1.Controls.Add(this.dte_from_inbound);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(908, 54);
            this.panel1.TabIndex = 0;
            // 
            // cbx_username_in
            // 
            this.cbx_username_in.AutoSize = true;
            this.cbx_username_in.Location = new System.Drawing.Point(162, 4);
            this.cbx_username_in.Name = "cbx_username_in";
            this.cbx_username_in.Size = new System.Drawing.Size(87, 17);
            this.cbx_username_in.TabIndex = 14;
            this.cbx_username_in.Text = "USERNAME";
            this.cbx_username_in.UseVisualStyleBackColor = true;
            this.cbx_username_in.CheckedChanged += new System.EventHandler(this.cbx_username_in_CheckedChanged);
            // 
            // cmb_username_in
            // 
            this.cmb_username_in.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_username_in.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmb_username_in.FormattingEnabled = true;
            this.cmb_username_in.Location = new System.Drawing.Point(162, 27);
            this.cmb_username_in.Name = "cmb_username_in";
            this.cmb_username_in.Size = new System.Drawing.Size(121, 21);
            this.cmb_username_in.TabIndex = 13;
            // 
            // btn_export_inbound
            // 
            this.btn_export_inbound.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_export_inbound.Location = new System.Drawing.Point(387, 27);
            this.btn_export_inbound.Name = "btn_export_inbound";
            this.btn_export_inbound.Size = new System.Drawing.Size(75, 23);
            this.btn_export_inbound.TabIndex = 7;
            this.btn_export_inbound.Text = "Export";
            this.btn_export_inbound.UseVisualStyleBackColor = true;
            this.btn_export_inbound.Click += new System.EventHandler(this.btn_export_inbound_Click);
            // 
            // lbl_row_inbound
            // 
            this.lbl_row_inbound.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_row_inbound.AutoSize = true;
            this.lbl_row_inbound.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_row_inbound.Location = new System.Drawing.Point(863, 33);
            this.lbl_row_inbound.Name = "lbl_row_inbound";
            this.lbl_row_inbound.Size = new System.Drawing.Size(29, 18);
            this.lbl_row_inbound.TabIndex = 5;
            this.lbl_row_inbound.Text = "List";
            // 
            // btn_search_inbound
            // 
            this.btn_search_inbound.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_search_inbound.Location = new System.Drawing.Point(306, 27);
            this.btn_search_inbound.Name = "btn_search_inbound";
            this.btn_search_inbound.Size = new System.Drawing.Size(75, 23);
            this.btn_search_inbound.TabIndex = 4;
            this.btn_search_inbound.Text = "Search";
            this.btn_search_inbound.UseVisualStyleBackColor = true;
            this.btn_search_inbound.Click += new System.EventHandler(this.btn_search_inbound_Click);
            // 
            // dte_from_inbound
            // 
            this.dte_from_inbound.CustomFormat = "dd -MM- yyyy";
            this.dte_from_inbound.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte_from_inbound.Location = new System.Drawing.Point(12, 30);
            this.dte_from_inbound.Name = "dte_from_inbound";
            this.dte_from_inbound.Size = new System.Drawing.Size(144, 20);
            this.dte_from_inbound.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "DATE";
            // 
            // dtgrid_hourly_inbound
            // 
            this.dtgrid_hourly_inbound.AllowUserToAddRows = false;
            this.dtgrid_hourly_inbound.AllowUserToDeleteRows = false;
            this.dtgrid_hourly_inbound.BackgroundColor = System.Drawing.Color.White;
            this.dtgrid_hourly_inbound.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgrid_hourly_inbound.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgrid_hourly_inbound.EnableHeadersVisualStyles = false;
            this.dtgrid_hourly_inbound.Location = new System.Drawing.Point(3, 63);
            this.dtgrid_hourly_inbound.Name = "dtgrid_hourly_inbound";
            this.dtgrid_hourly_inbound.ReadOnly = true;
            this.dtgrid_hourly_inbound.RowHeadersVisible = false;
            this.dtgrid_hourly_inbound.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dtgrid_hourly_inbound.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgrid_hourly_inbound.Size = new System.Drawing.Size(908, 416);
            this.dtgrid_hourly_inbound.TabIndex = 1;
            // 
            // tabControl_ReportHourly
            // 
            this.tabControl_ReportHourly.Controls.Add(this.tabPage_HourlyInbound);
            this.tabControl_ReportHourly.Controls.Add(this.tabPage_HourlyOutbound);
            this.tabControl_ReportHourly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_ReportHourly.Location = new System.Drawing.Point(0, 0);
            this.tabControl_ReportHourly.Name = "tabControl_ReportHourly";
            this.tabControl_ReportHourly.SelectedIndex = 0;
            this.tabControl_ReportHourly.Size = new System.Drawing.Size(928, 514);
            this.tabControl_ReportHourly.TabIndex = 3;
            // 
            // tabPage_HourlyInbound
            // 
            this.tabPage_HourlyInbound.Controls.Add(this.tableLayoutPanel1);
            this.tabPage_HourlyInbound.Location = new System.Drawing.Point(4, 22);
            this.tabPage_HourlyInbound.Name = "tabPage_HourlyInbound";
            this.tabPage_HourlyInbound.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage_HourlyInbound.Size = new System.Drawing.Size(920, 488);
            this.tabPage_HourlyInbound.TabIndex = 0;
            this.tabPage_HourlyInbound.Text = "Inbound";
            this.tabPage_HourlyInbound.UseVisualStyleBackColor = true;
            // 
            // tabPage_HourlyOutbound
            // 
            this.tabPage_HourlyOutbound.Controls.Add(this.tableLayoutPanel2);
            this.tabPage_HourlyOutbound.Location = new System.Drawing.Point(4, 22);
            this.tabPage_HourlyOutbound.Name = "tabPage_HourlyOutbound";
            this.tabPage_HourlyOutbound.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage_HourlyOutbound.Size = new System.Drawing.Size(920, 488);
            this.tabPage_HourlyOutbound.TabIndex = 1;
            this.tabPage_HourlyOutbound.Text = "Outbound";
            this.tabPage_HourlyOutbound.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.dtgrid_hourly_outbound, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(914, 482);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.PowderBlue;
            this.panel2.Controls.Add(this.cbx_username_out);
            this.panel2.Controls.Add(this.cmb_username_out);
            this.panel2.Controls.Add(this.btn_export_outbound);
            this.panel2.Controls.Add(this.lbl_row_outbound);
            this.panel2.Controls.Add(this.btn_search_outbound);
            this.panel2.Controls.Add(this.dte_from_outbound);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(908, 54);
            this.panel2.TabIndex = 0;
            // 
            // cbx_username_out
            // 
            this.cbx_username_out.AutoSize = true;
            this.cbx_username_out.Location = new System.Drawing.Point(162, 8);
            this.cbx_username_out.Name = "cbx_username_out";
            this.cbx_username_out.Size = new System.Drawing.Size(87, 17);
            this.cbx_username_out.TabIndex = 13;
            this.cbx_username_out.Text = "USERNAME";
            this.cbx_username_out.UseVisualStyleBackColor = true;
            this.cbx_username_out.CheckedChanged += new System.EventHandler(this.cbx_username_out_CheckedChanged);
            // 
            // cmb_username_out
            // 
            this.cmb_username_out.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_username_out.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmb_username_out.FormattingEnabled = true;
            this.cmb_username_out.Location = new System.Drawing.Point(162, 30);
            this.cmb_username_out.Name = "cmb_username_out";
            this.cmb_username_out.Size = new System.Drawing.Size(121, 21);
            this.cmb_username_out.TabIndex = 11;
            // 
            // btn_export_outbound
            // 
            this.btn_export_outbound.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_export_outbound.Location = new System.Drawing.Point(384, 27);
            this.btn_export_outbound.Name = "btn_export_outbound";
            this.btn_export_outbound.Size = new System.Drawing.Size(75, 23);
            this.btn_export_outbound.TabIndex = 8;
            this.btn_export_outbound.Text = "Export";
            this.btn_export_outbound.UseVisualStyleBackColor = true;
            this.btn_export_outbound.Click += new System.EventHandler(this.btn_export_outbound_Click);
            // 
            // lbl_row_outbound
            // 
            this.lbl_row_outbound.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_row_outbound.AutoSize = true;
            this.lbl_row_outbound.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_row_outbound.Location = new System.Drawing.Point(863, 33);
            this.lbl_row_outbound.Name = "lbl_row_outbound";
            this.lbl_row_outbound.Size = new System.Drawing.Size(29, 18);
            this.lbl_row_outbound.TabIndex = 5;
            this.lbl_row_outbound.Text = "List";
            // 
            // btn_search_outbound
            // 
            this.btn_search_outbound.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_search_outbound.Location = new System.Drawing.Point(295, 27);
            this.btn_search_outbound.Name = "btn_search_outbound";
            this.btn_search_outbound.Size = new System.Drawing.Size(75, 23);
            this.btn_search_outbound.TabIndex = 4;
            this.btn_search_outbound.Text = "Search";
            this.btn_search_outbound.UseVisualStyleBackColor = true;
            this.btn_search_outbound.Click += new System.EventHandler(this.btn_search_outbound_Click);
            // 
            // dte_from_outbound
            // 
            this.dte_from_outbound.CustomFormat = "dd -MM- yyyy";
            this.dte_from_outbound.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte_from_outbound.Location = new System.Drawing.Point(12, 30);
            this.dte_from_outbound.Name = "dte_from_outbound";
            this.dte_from_outbound.Size = new System.Drawing.Size(144, 20);
            this.dte_from_outbound.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 18);
            this.label5.TabIndex = 0;
            this.label5.Text = "DATE";
            // 
            // dtgrid_hourly_outbound
            // 
            this.dtgrid_hourly_outbound.AllowUserToAddRows = false;
            this.dtgrid_hourly_outbound.AllowUserToDeleteRows = false;
            this.dtgrid_hourly_outbound.BackgroundColor = System.Drawing.Color.White;
            this.dtgrid_hourly_outbound.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgrid_hourly_outbound.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgrid_hourly_outbound.EnableHeadersVisualStyles = false;
            this.dtgrid_hourly_outbound.Location = new System.Drawing.Point(3, 63);
            this.dtgrid_hourly_outbound.Name = "dtgrid_hourly_outbound";
            this.dtgrid_hourly_outbound.ReadOnly = true;
            this.dtgrid_hourly_outbound.RowHeadersVisible = false;
            this.dtgrid_hourly_outbound.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dtgrid_hourly_outbound.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgrid_hourly_outbound.Size = new System.Drawing.Size(908, 416);
            this.dtgrid_hourly_outbound.TabIndex = 1;
            // 
            // ReportHourly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(928, 514);
            this.Controls.Add(this.tabControl_ReportHourly);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReportHourly";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "ReportHourly";
            this.Load += new System.EventHandler(this.ReportHourly_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrid_hourly_inbound)).EndInit();
            this.tabControl_ReportHourly.ResumeLayout(false);
            this.tabPage_HourlyInbound.ResumeLayout(false);
            this.tabPage_HourlyOutbound.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrid_hourly_outbound)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_row_inbound;
        private System.Windows.Forms.Button btn_search_inbound;
        private System.Windows.Forms.DateTimePicker dte_from_inbound;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtgrid_hourly_inbound;
        private System.Windows.Forms.TabControl tabControl_ReportHourly;
        private System.Windows.Forms.TabPage tabPage_HourlyInbound;
        private System.Windows.Forms.TabPage tabPage_HourlyOutbound;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_row_outbound;
        private System.Windows.Forms.Button btn_search_outbound;
        private System.Windows.Forms.DateTimePicker dte_from_outbound;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dtgrid_hourly_outbound;
        private System.Windows.Forms.Button btn_export_inbound;
        private System.Windows.Forms.Button btn_export_outbound;
        private System.Windows.Forms.ComboBox cmb_username_out;
        private System.Windows.Forms.CheckBox cbx_username_in;
        private System.Windows.Forms.ComboBox cmb_username_in;
        private System.Windows.Forms.CheckBox cbx_username_out;
    }
}