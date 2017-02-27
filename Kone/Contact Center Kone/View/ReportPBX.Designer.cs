namespace Contact_Center_Kone.View
{
    partial class ReportPBX
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
            this.dtgrid_reportpbx = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbx_call_status = new System.Windows.Forms.CheckBox();
            this.cmb_call_status = new System.Windows.Forms.ComboBox();
            this.btn_export = new System.Windows.Forms.Button();
            this.lbl_row = new System.Windows.Forms.Label();
            this.btn_search = new System.Windows.Forms.Button();
            this.dte_until = new System.Windows.Forms.DateTimePicker();
            this.dte_from = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrid_reportpbx)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgrid_reportpbx
            // 
            this.dtgrid_reportpbx.AllowUserToAddRows = false;
            this.dtgrid_reportpbx.AllowUserToDeleteRows = false;
            this.dtgrid_reportpbx.BackgroundColor = System.Drawing.Color.White;
            this.dtgrid_reportpbx.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgrid_reportpbx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgrid_reportpbx.EnableHeadersVisualStyles = false;
            this.dtgrid_reportpbx.Location = new System.Drawing.Point(3, 63);
            this.dtgrid_reportpbx.Name = "dtgrid_reportpbx";
            this.dtgrid_reportpbx.ReadOnly = true;
            this.dtgrid_reportpbx.RowHeadersVisible = false;
            this.dtgrid_reportpbx.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dtgrid_reportpbx.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgrid_reportpbx.Size = new System.Drawing.Size(876, 247);
            this.dtgrid_reportpbx.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtgrid_reportpbx, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(882, 313);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PowderBlue;
            this.panel1.Controls.Add(this.cbx_call_status);
            this.panel1.Controls.Add(this.cmb_call_status);
            this.panel1.Controls.Add(this.btn_export);
            this.panel1.Controls.Add(this.lbl_row);
            this.panel1.Controls.Add(this.btn_search);
            this.panel1.Controls.Add(this.dte_until);
            this.panel1.Controls.Add(this.dte_from);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(876, 54);
            this.panel1.TabIndex = 0;
            // 
            // cbx_call_status
            // 
            this.cbx_call_status.AutoSize = true;
            this.cbx_call_status.Location = new System.Drawing.Point(313, 6);
            this.cbx_call_status.Name = "cbx_call_status";
            this.cbx_call_status.Size = new System.Drawing.Size(98, 17);
            this.cbx_call_status.TabIndex = 18;
            this.cbx_call_status.Text = "CALL STATUS";
            this.cbx_call_status.UseVisualStyleBackColor = true;
            this.cbx_call_status.CheckedChanged += new System.EventHandler(this.cbx_call_status_CheckedChanged);
            // 
            // cmb_call_status
            // 
            this.cmb_call_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_call_status.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmb_call_status.FormattingEnabled = true;
            this.cmb_call_status.Items.AddRange(new object[] {
            "ABANDON",
            "TRANSFERRED"});
            this.cmb_call_status.Location = new System.Drawing.Point(313, 28);
            this.cmb_call_status.Name = "cmb_call_status";
            this.cmb_call_status.Size = new System.Drawing.Size(121, 21);
            this.cmb_call_status.TabIndex = 17;
            // 
            // btn_export
            // 
            this.btn_export.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_export.Location = new System.Drawing.Point(522, 27);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(75, 23);
            this.btn_export.TabIndex = 8;
            this.btn_export.Text = "Export";
            this.btn_export.UseVisualStyleBackColor = true;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // lbl_row
            // 
            this.lbl_row.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_row.AutoSize = true;
            this.lbl_row.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_row.Location = new System.Drawing.Point(725, 32);
            this.lbl_row.Name = "lbl_row";
            this.lbl_row.Size = new System.Drawing.Size(29, 18);
            this.lbl_row.TabIndex = 5;
            this.lbl_row.Text = "List";
            // 
            // btn_search
            // 
            this.btn_search.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_search.Location = new System.Drawing.Point(441, 28);
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
            // ReportPBX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 313);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReportPBX";
            this.Text = "ReportPBX";
            this.Load += new System.EventHandler(this.ReportPBX_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgrid_reportpbx)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgrid_reportpbx;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cbx_call_status;
        private System.Windows.Forms.ComboBox cmb_call_status;
        private System.Windows.Forms.Button btn_export;
        private System.Windows.Forms.Label lbl_row;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.DateTimePicker dte_until;
        private System.Windows.Forms.DateTimePicker dte_from;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}