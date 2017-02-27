namespace Contact_Center_Kone.View
{
    partial class FindTicket
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
            this.dtgrid_find_ticket = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_tagging = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_ticketno = new System.Windows.Forms.TextBox();
            this.lbl_CountGrid = new System.Windows.Forms.Label();
            this.btn_search = new System.Windows.Forms.Button();
            this.dte_until = new System.Windows.Forms.DateTimePicker();
            this.dte_from = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtgrid_list_tagging = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrid_find_ticket)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrid_list_tagging)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 230F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(962, 713);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dtgrid_find_ticket
            // 
            this.dtgrid_find_ticket.AllowUserToAddRows = false;
            this.dtgrid_find_ticket.AllowUserToDeleteRows = false;
            this.dtgrid_find_ticket.BackgroundColor = System.Drawing.Color.White;
            this.dtgrid_find_ticket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgrid_find_ticket.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgrid_find_ticket.EnableHeadersVisualStyles = false;
            this.dtgrid_find_ticket.Location = new System.Drawing.Point(3, 18);
            this.dtgrid_find_ticket.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtgrid_find_ticket.Name = "dtgrid_find_ticket";
            this.dtgrid_find_ticket.ReadOnly = true;
            this.dtgrid_find_ticket.RowHeadersVisible = false;
            this.dtgrid_find_ticket.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dtgrid_find_ticket.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgrid_find_ticket.Size = new System.Drawing.Size(950, 382);
            this.dtgrid_find_ticket.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(954, 66);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.PowderBlue;
            this.panel2.Controls.Add(this.btn_tagging);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txt_ticketno);
            this.panel2.Controls.Add(this.lbl_CountGrid);
            this.panel2.Controls.Add(this.btn_search);
            this.panel2.Controls.Add(this.dte_until);
            this.panel2.Controls.Add(this.dte_from);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(954, 66);
            this.panel2.TabIndex = 1;
            // 
            // btn_tagging
            // 
            this.btn_tagging.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_tagging.Location = new System.Drawing.Point(723, 34);
            this.btn_tagging.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_tagging.Name = "btn_tagging";
            this.btn_tagging.Size = new System.Drawing.Size(100, 28);
            this.btn_tagging.TabIndex = 8;
            this.btn_tagging.Text = "Tagging Ticket";
            this.btn_tagging.UseVisualStyleBackColor = true;
            this.btn_tagging.Click += new System.EventHandler(this.btn_tagging_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(403, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "TICKET NO";
            // 
            // txt_ticketno
            // 
            this.txt_ticketno.Location = new System.Drawing.Point(407, 37);
            this.txt_ticketno.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_ticketno.Name = "txt_ticketno";
            this.txt_ticketno.Size = new System.Drawing.Size(199, 22);
            this.txt_ticketno.TabIndex = 6;
            // 
            // lbl_CountGrid
            // 
            this.lbl_CountGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_CountGrid.AutoSize = true;
            this.lbl_CountGrid.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CountGrid.Location = new System.Drawing.Point(1056, 39);
            this.lbl_CountGrid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_CountGrid.Name = "lbl_CountGrid";
            this.lbl_CountGrid.Size = new System.Drawing.Size(36, 23);
            this.lbl_CountGrid.TabIndex = 5;
            this.lbl_CountGrid.Text = "List";
            // 
            // btn_search
            // 
            this.btn_search.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_search.Location = new System.Drawing.Point(615, 33);
            this.btn_search.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(100, 28);
            this.btn_search.TabIndex = 4;
            this.btn_search.Text = "Search";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // dte_until
            // 
            this.dte_until.CustomFormat = "dd -MM- yyyy";
            this.dte_until.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte_until.Location = new System.Drawing.Point(207, 37);
            this.dte_until.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dte_until.Name = "dte_until";
            this.dte_until.Size = new System.Drawing.Size(191, 22);
            this.dte_until.TabIndex = 3;
            // 
            // dte_from
            // 
            this.dte_from.CustomFormat = "dd -MM- yyyy";
            this.dte_from.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dte_from.Location = new System.Drawing.Point(7, 37);
            this.dte_from.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dte_from.Name = "dte_from";
            this.dte_from.Size = new System.Drawing.Size(191, 22);
            this.dte_from.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(203, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "UNTIL";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "FROM";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtgrid_find_ticket);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.ForeColor = System.Drawing.Color.Red;
            this.groupBox1.Location = new System.Drawing.Point(3, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(956, 403);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "List Ticket";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtgrid_list_tagging);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 486);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(956, 224);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "List Tagging";
            // 
            // dtgrid_list_tagging
            // 
            this.dtgrid_list_tagging.AllowUserToAddRows = false;
            this.dtgrid_list_tagging.AllowUserToDeleteRows = false;
            this.dtgrid_list_tagging.BackgroundColor = System.Drawing.Color.White;
            this.dtgrid_list_tagging.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgrid_list_tagging.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgrid_list_tagging.EnableHeadersVisualStyles = false;
            this.dtgrid_list_tagging.Location = new System.Drawing.Point(3, 18);
            this.dtgrid_list_tagging.Margin = new System.Windows.Forms.Padding(4);
            this.dtgrid_list_tagging.Name = "dtgrid_list_tagging";
            this.dtgrid_list_tagging.ReadOnly = true;
            this.dtgrid_list_tagging.RowHeadersVisible = false;
            this.dtgrid_list_tagging.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dtgrid_list_tagging.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgrid_list_tagging.Size = new System.Drawing.Size(950, 203);
            this.dtgrid_list_tagging.TabIndex = 3;
            // 
            // FindTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 713);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FindTicket";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FindTicket";
            this.Load += new System.EventHandler(this.FindTicket_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgrid_find_ticket)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgrid_list_tagging)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_CountGrid;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.DateTimePicker dte_until;
        private System.Windows.Forms.DateTimePicker dte_from;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtgrid_find_ticket;
        private System.Windows.Forms.TextBox txt_ticketno;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_tagging;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dtgrid_list_tagging;
    }
}