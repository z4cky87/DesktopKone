namespace Contact_Center_Kone.View
{
    partial class CallerType
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblNoDataInboundTypeDetail = new System.Windows.Forms.Label();
            this.gridCategory = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnDeleteCategory = new System.Windows.Forms.Button();
            this.btnEditCategory = new System.Windows.Forms.Button();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNoDataInboundType = new System.Windows.Forms.Label();
            this.gridInboundCallerType = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnDeleteInboundCallerType = new System.Windows.Forms.Button();
            this.btnEditInboundCallerType = new System.Windows.Forms.Button();
            this.btnAddInboundCallerType = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cmbDirection = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCategory)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridInboundCallerType)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 293F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 49);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(835, 424);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblNoDataInboundTypeDetail);
            this.panel2.Controls.Add(this.gridCategory);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(296, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(536, 418);
            this.panel2.TabIndex = 1;
            // 
            // lblNoDataInboundTypeDetail
            // 
            this.lblNoDataInboundTypeDetail.AutoSize = true;
            this.lblNoDataInboundTypeDetail.BackColor = System.Drawing.Color.White;
            this.lblNoDataInboundTypeDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoDataInboundTypeDetail.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblNoDataInboundTypeDetail.Location = new System.Drawing.Point(218, 217);
            this.lblNoDataInboundTypeDetail.Name = "lblNoDataInboundTypeDetail";
            this.lblNoDataInboundTypeDetail.Size = new System.Drawing.Size(120, 16);
            this.lblNoDataInboundTypeDetail.TabIndex = 11;
            this.lblNoDataInboundTypeDetail.Text = "No data to preview";
            this.lblNoDataInboundTypeDetail.Visible = false;
            // 
            // gridCategory
            // 
            this.gridCategory.AllowUserToAddRows = false;
            this.gridCategory.AllowUserToDeleteRows = false;
            this.gridCategory.BackgroundColor = System.Drawing.Color.White;
            this.gridCategory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCategory.Location = new System.Drawing.Point(0, 18);
            this.gridCategory.Name = "gridCategory";
            this.gridCategory.ReadOnly = true;
            this.gridCategory.RowHeadersVisible = false;
            this.gridCategory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridCategory.Size = new System.Drawing.Size(536, 358);
            this.gridCategory.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Silver;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(536, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "Caller Type Detail";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnDeleteCategory);
            this.panel4.Controls.Add(this.btnEditCategory);
            this.panel4.Controls.Add(this.btnAddCategory);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 376);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(536, 42);
            this.panel4.TabIndex = 1;
            // 
            // btnDeleteCategory
            // 
            this.btnDeleteCategory.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteCategory.Location = new System.Drawing.Point(157, 5);
            this.btnDeleteCategory.Name = "btnDeleteCategory";
            this.btnDeleteCategory.Size = new System.Drawing.Size(75, 32);
            this.btnDeleteCategory.TabIndex = 5;
            this.btnDeleteCategory.Text = "Delete";
            this.btnDeleteCategory.UseVisualStyleBackColor = true;
            this.btnDeleteCategory.Click += new System.EventHandler(this.btnDeleteCategory_Click);
            // 
            // btnEditCategory
            // 
            this.btnEditCategory.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditCategory.Location = new System.Drawing.Point(80, 5);
            this.btnEditCategory.Name = "btnEditCategory";
            this.btnEditCategory.Size = new System.Drawing.Size(75, 32);
            this.btnEditCategory.TabIndex = 4;
            this.btnEditCategory.Text = "Edit";
            this.btnEditCategory.UseVisualStyleBackColor = true;
            this.btnEditCategory.Click += new System.EventHandler(this.btnEditCategory_Click);
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCategory.Location = new System.Drawing.Point(3, 5);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(75, 32);
            this.btnAddCategory.TabIndex = 3;
            this.btnAddCategory.Text = "Add";
            this.btnAddCategory.UseVisualStyleBackColor = true;
            this.btnAddCategory.Click += new System.EventHandler(this.btnAddCategory_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblNoDataInboundType);
            this.panel1.Controls.Add(this.gridInboundCallerType);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(287, 418);
            this.panel1.TabIndex = 0;
            // 
            // lblNoDataInboundType
            // 
            this.lblNoDataInboundType.AutoSize = true;
            this.lblNoDataInboundType.BackColor = System.Drawing.Color.White;
            this.lblNoDataInboundType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoDataInboundType.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblNoDataInboundType.Location = new System.Drawing.Point(83, 217);
            this.lblNoDataInboundType.Name = "lblNoDataInboundType";
            this.lblNoDataInboundType.Size = new System.Drawing.Size(120, 16);
            this.lblNoDataInboundType.TabIndex = 11;
            this.lblNoDataInboundType.Text = "No data to preview";
            this.lblNoDataInboundType.Visible = false;
            // 
            // gridInboundCallerType
            // 
            this.gridInboundCallerType.AllowUserToAddRows = false;
            this.gridInboundCallerType.AllowUserToDeleteRows = false;
            this.gridInboundCallerType.BackgroundColor = System.Drawing.Color.White;
            this.gridInboundCallerType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridInboundCallerType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridInboundCallerType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridInboundCallerType.Location = new System.Drawing.Point(0, 18);
            this.gridInboundCallerType.Name = "gridInboundCallerType";
            this.gridInboundCallerType.ReadOnly = true;
            this.gridInboundCallerType.RowHeadersVisible = false;
            this.gridInboundCallerType.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridInboundCallerType.Size = new System.Drawing.Size(287, 358);
            this.gridInboundCallerType.TabIndex = 6;
            this.gridInboundCallerType.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridInboundCallerType_CellClick);
            this.gridInboundCallerType.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridInboundCallerType_CellDoubleClick);
            this.gridInboundCallerType.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gridInboundCallerType_KeyUp);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Silver;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(287, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "Caller Type";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnDeleteInboundCallerType);
            this.panel3.Controls.Add(this.btnEditInboundCallerType);
            this.panel3.Controls.Add(this.btnAddInboundCallerType);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 376);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(287, 42);
            this.panel3.TabIndex = 0;
            // 
            // btnDeleteInboundCallerType
            // 
            this.btnDeleteInboundCallerType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteInboundCallerType.Location = new System.Drawing.Point(158, 5);
            this.btnDeleteInboundCallerType.Name = "btnDeleteInboundCallerType";
            this.btnDeleteInboundCallerType.Size = new System.Drawing.Size(75, 32);
            this.btnDeleteInboundCallerType.TabIndex = 5;
            this.btnDeleteInboundCallerType.Text = "Delete";
            this.btnDeleteInboundCallerType.UseVisualStyleBackColor = true;
            this.btnDeleteInboundCallerType.Click += new System.EventHandler(this.btnDeleteInboundCallerType_Click);
            // 
            // btnEditInboundCallerType
            // 
            this.btnEditInboundCallerType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditInboundCallerType.Location = new System.Drawing.Point(81, 5);
            this.btnEditInboundCallerType.Name = "btnEditInboundCallerType";
            this.btnEditInboundCallerType.Size = new System.Drawing.Size(75, 32);
            this.btnEditInboundCallerType.TabIndex = 4;
            this.btnEditInboundCallerType.Text = "Edit";
            this.btnEditInboundCallerType.UseVisualStyleBackColor = true;
            this.btnEditInboundCallerType.Click += new System.EventHandler(this.btnEditInboundCallerType_Click);
            // 
            // btnAddInboundCallerType
            // 
            this.btnAddInboundCallerType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddInboundCallerType.Location = new System.Drawing.Point(4, 5);
            this.btnAddInboundCallerType.Name = "btnAddInboundCallerType";
            this.btnAddInboundCallerType.Size = new System.Drawing.Size(75, 32);
            this.btnAddInboundCallerType.TabIndex = 3;
            this.btnAddInboundCallerType.Text = "Add";
            this.btnAddInboundCallerType.UseVisualStyleBackColor = true;
            this.btnAddInboundCallerType.Click += new System.EventHandler(this.btnAddInboundCallerType_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.cmbDirection);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(835, 49);
            this.panel5.TabIndex = 4;
            // 
            // cmbDirection
            // 
            this.cmbDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDirection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDirection.FormattingEnabled = true;
            this.cmbDirection.Items.AddRange(new object[] {
            "Inbound",
            "Outbound"});
            this.cmbDirection.Location = new System.Drawing.Point(10, 20);
            this.cmbDirection.Name = "cmbDirection";
            this.cmbDirection.Size = new System.Drawing.Size(140, 24);
            this.cmbDirection.TabIndex = 1;
            this.cmbDirection.SelectedIndexChanged += new System.EventHandler(this.cmbDirection_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Direction";
            // 
            // CallerType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 473);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CallerType";
            this.Text = "InboundCategory";
            this.Load += new System.EventHandler(this.InboundCategory_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCategory)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridInboundCallerType)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblNoDataInboundTypeDetail;
        internal System.Windows.Forms.DataGridView gridCategory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnDeleteCategory;
        private System.Windows.Forms.Button btnEditCategory;
        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblNoDataInboundType;
        internal System.Windows.Forms.DataGridView gridInboundCallerType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnDeleteInboundCallerType;
        private System.Windows.Forms.Button btnEditInboundCallerType;
        private System.Windows.Forms.Button btnAddInboundCallerType;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox cmbDirection;
    }
}