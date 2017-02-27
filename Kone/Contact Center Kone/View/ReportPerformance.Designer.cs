namespace Contact_Center_Kone.View
{
    partial class ReportPerformance
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
            this.btn_export = new System.Windows.Forms.Button();
            this.lbl_row_in = new System.Windows.Forms.Label();
            this.btn_search = new System.Windows.Forms.Button();
            this.dte_until = new System.Windows.Forms.DateTimePicker();
            this.dte_from = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtgrid_inbound = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbx_username_out = new System.Windows.Forms.CheckBox();
            this.cmb_username_out = new System.Windows.Forms.ComboBox();
            this.btn_export_outbound = new System.Windows.Forms.Button();
            this.lbl_row_out = new System.Windows.Forms.Label();
            this.btn_search_outbound = new System.Windows.Forms.Button();
            this.dte_until_outbound = new System.Windows.Forms.DateTimePicker();
            this.dte_from_outbound = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtgrid_outbound = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrid_inbound)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrid_outbound)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtgrid_inbound, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(912, 495);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PowderBlue;
            this.panel1.Controls.Add(this.cbx_username_in);
            this.panel1.Controls.Add(this.cmb_username_in);
            this.panel1.Controls.Add(this.btn_export);
            this.panel1.Controls.Add(this.lbl_row_in);
            this.panel1.Controls.Add(this.btn_search);
            this.panel1.Controls.Add(this.dte_until);
            this.panel1.Controls.Add(this.dte_from);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(906, 54);
            this.panel1.TabIndex = 0;
            // 
            // cbx_username_in
            // 
            this.cbx_username_in.AutoSize = true;
            this.cbx_username_in.Location = new System.Drawing.Point(312, 6);
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
            this.cmb_username_in.Location = new System.Drawing.Point(312, 28);
            this.cmb_username_in.Name = "cmb_username_in";
            this.cmb_username_in.Size = new System.Drawing.Size(121, 21);
            this.cmb_username_in.TabIndex = 13;
            // 
            // btn_export
            // 
            this.btn_export.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_export.Location = new System.Drawing.Point(536, 28);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(75, 23);
            this.btn_export.TabIndex = 8;
            this.btn_export.Text = "Export";
            this.btn_export.UseVisualStyleBackColor = true;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // lbl_row_in
            // 
            this.lbl_row_in.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_row_in.AutoSize = true;
            this.lbl_row_in.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_row_in.Location = new System.Drawing.Point(862, 33);
            this.lbl_row_in.Name = "lbl_row_in";
            this.lbl_row_in.Size = new System.Drawing.Size(29, 18);
            this.lbl_row_in.TabIndex = 5;
            this.lbl_row_in.Text = "List";
            // 
            // btn_search
            // 
            this.btn_search.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_search.Location = new System.Drawing.Point(455, 28);
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
            this.dte_until.Location = new System.Drawing.Point(162, 30);
            this.dte_until.Name = "dte_until";
            this.dte_until.Size = new System.Drawing.Size(144, 20);
            this.dte_until.TabIndex = 3;
            // 
            // dte_from
            // 
            this.dte_from.CustomFormat = "dd -MM- yyyy";
            this.dte_from.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte_from.Location = new System.Drawing.Point(12, 30);
            this.dte_from.Name = "dte_from";
            this.dte_from.Size = new System.Drawing.Size(144, 20);
            this.dte_from.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(159, 6);
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
            // dtgrid_inbound
            // 
            this.dtgrid_inbound.AllowUserToAddRows = false;
            this.dtgrid_inbound.AllowUserToDeleteRows = false;
            this.dtgrid_inbound.BackgroundColor = System.Drawing.Color.White;
            this.dtgrid_inbound.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgrid_inbound.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgrid_inbound.EnableHeadersVisualStyles = false;
            this.dtgrid_inbound.Location = new System.Drawing.Point(3, 63);
            this.dtgrid_inbound.Name = "dtgrid_inbound";
            this.dtgrid_inbound.ReadOnly = true;
            this.dtgrid_inbound.RowHeadersVisible = false;
            this.dtgrid_inbound.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dtgrid_inbound.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgrid_inbound.Size = new System.Drawing.Size(906, 429);
            this.dtgrid_inbound.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage2.Size = new System.Drawing.Size(918, 501);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Outbound";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.dtgrid_outbound, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(912, 495);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.PowderBlue;
            this.panel2.Controls.Add(this.cbx_username_out);
            this.panel2.Controls.Add(this.cmb_username_out);
            this.panel2.Controls.Add(this.btn_export_outbound);
            this.panel2.Controls.Add(this.lbl_row_out);
            this.panel2.Controls.Add(this.btn_search_outbound);
            this.panel2.Controls.Add(this.dte_until_outbound);
            this.panel2.Controls.Add(this.dte_from_outbound);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(906, 54);
            this.panel2.TabIndex = 0;
            // 
            // cbx_username_out
            // 
            this.cbx_username_out.AutoSize = true;
            this.cbx_username_out.Location = new System.Drawing.Point(312, 6);
            this.cbx_username_out.Name = "cbx_username_out";
            this.cbx_username_out.Size = new System.Drawing.Size(87, 17);
            this.cbx_username_out.TabIndex = 14;
            this.cbx_username_out.Text = "USERNAME";
            this.cbx_username_out.UseVisualStyleBackColor = true;
            this.cbx_username_out.CheckedChanged += new System.EventHandler(this.cbx_username_out_CheckedChanged);
            // 
            // cmb_username_out
            // 
            this.cmb_username_out.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_username_out.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmb_username_out.FormattingEnabled = true;
            this.cmb_username_out.Location = new System.Drawing.Point(312, 29);
            this.cmb_username_out.Name = "cmb_username_out";
            this.cmb_username_out.Size = new System.Drawing.Size(121, 21);
            this.cmb_username_out.TabIndex = 13;
            // 
            // btn_export_outbound
            // 
            this.btn_export_outbound.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_export_outbound.Location = new System.Drawing.Point(524, 26);
            this.btn_export_outbound.Name = "btn_export_outbound";
            this.btn_export_outbound.Size = new System.Drawing.Size(75, 23);
            this.btn_export_outbound.TabIndex = 8;
            this.btn_export_outbound.Text = "Export";
            this.btn_export_outbound.UseVisualStyleBackColor = true;
            this.btn_export_outbound.Click += new System.EventHandler(this.btn_export_outbound_Click);
            // 
            // lbl_row_out
            // 
            this.lbl_row_out.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_row_out.AutoSize = true;
            this.lbl_row_out.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_row_out.Location = new System.Drawing.Point(864, 33);
            this.lbl_row_out.Name = "lbl_row_out";
            this.lbl_row_out.Size = new System.Drawing.Size(29, 18);
            this.lbl_row_out.TabIndex = 5;
            this.lbl_row_out.Text = "List";
            // 
            // btn_search_outbound
            // 
            this.btn_search_outbound.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_search_outbound.Location = new System.Drawing.Point(443, 27);
            this.btn_search_outbound.Name = "btn_search_outbound";
            this.btn_search_outbound.Size = new System.Drawing.Size(75, 23);
            this.btn_search_outbound.TabIndex = 4;
            this.btn_search_outbound.Text = "Search";
            this.btn_search_outbound.UseVisualStyleBackColor = true;
            this.btn_search_outbound.Click += new System.EventHandler(this.btn_search_outbound_Click);
            // 
            // dte_until_outbound
            // 
            this.dte_until_outbound.CustomFormat = "dd -MM- yyyy";
            this.dte_until_outbound.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte_until_outbound.Location = new System.Drawing.Point(162, 30);
            this.dte_until_outbound.Name = "dte_until_outbound";
            this.dte_until_outbound.Size = new System.Drawing.Size(144, 20);
            this.dte_until_outbound.TabIndex = 3;
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(159, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 18);
            this.label4.TabIndex = 1;
            this.label4.Text = "UNTIL";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 18);
            this.label5.TabIndex = 0;
            this.label5.Text = "FROM";
            // 
            // dtgrid_outbound
            // 
            this.dtgrid_outbound.AllowUserToAddRows = false;
            this.dtgrid_outbound.AllowUserToDeleteRows = false;
            this.dtgrid_outbound.BackgroundColor = System.Drawing.Color.White;
            this.dtgrid_outbound.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgrid_outbound.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgrid_outbound.EnableHeadersVisualStyles = false;
            this.dtgrid_outbound.Location = new System.Drawing.Point(3, 63);
            this.dtgrid_outbound.Name = "dtgrid_outbound";
            this.dtgrid_outbound.ReadOnly = true;
            this.dtgrid_outbound.RowHeadersVisible = false;
            this.dtgrid_outbound.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dtgrid_outbound.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgrid_outbound.Size = new System.Drawing.Size(906, 429);
            this.dtgrid_outbound.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(926, 527);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage1.Size = new System.Drawing.Size(918, 501);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Inbound";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ReportPerformance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(926, 527);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReportPerformance";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "ReportPerformance";
            this.Load += new System.EventHandler(this.ReportPerformance_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrid_inbound)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrid_outbound)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_row_in;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.DateTimePicker dte_until;
        private System.Windows.Forms.DateTimePicker dte_from;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtgrid_inbound;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_row_out;
        private System.Windows.Forms.Button btn_search_outbound;
        private System.Windows.Forms.DateTimePicker dte_until_outbound;
        private System.Windows.Forms.DateTimePicker dte_from_outbound;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dtgrid_outbound;
        private System.Windows.Forms.Button btn_export;
        private System.Windows.Forms.Button btn_export_outbound;
        private System.Windows.Forms.CheckBox cbx_username_in;
        private System.Windows.Forms.ComboBox cmb_username_in;
        private System.Windows.Forms.CheckBox cbx_username_out;
        private System.Windows.Forms.ComboBox cmb_username_out;
    }
}