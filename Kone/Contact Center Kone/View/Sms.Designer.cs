namespace Contact_Center_Kone.View
{
    partial class Sms
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_outbound = new System.Windows.Forms.Button();
            this.btnTicket = new System.Windows.Forms.Button();
            this.btn_Reply = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_send = new System.Windows.Forms.Button();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.lbl_size = new System.Windows.Forms.Label();
            this.lbl_text_character = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbCategorySms = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_tagticket = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_ticket_no = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_text = new System.Windows.Forms.TextBox();
            this.txt_from = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txt_to = new Contact_Center_Kone.Utility.CustomTextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.Panel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(916, 473);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LimeGreen;
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Controls.Add(this.btn_outbound);
            this.panel3.Controls.Add(this.btnTicket);
            this.panel3.Controls.Add(this.btn_Reply);
            this.panel3.Controls.Add(this.btn_cancel);
            this.panel3.Controls.Add(this.btn_send);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(5, 414);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(906, 54);
            this.panel3.TabIndex = 35;
            // 
            // btn_outbound
            // 
            this.btn_outbound.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_outbound.BackColor = System.Drawing.Color.White;
            this.btn_outbound.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_outbound.Location = new System.Drawing.Point(738, 15);
            this.btn_outbound.Margin = new System.Windows.Forms.Padding(4);
            this.btn_outbound.Name = "btn_outbound";
            this.btn_outbound.Size = new System.Drawing.Size(155, 28);
            this.btn_outbound.TabIndex = 2;
            this.btn_outbound.Text = "Outbound";
            this.btn_outbound.UseVisualStyleBackColor = false;
            this.btn_outbound.Click += new System.EventHandler(this.btn_outbound_Click);
            // 
            // btnTicket
            // 
            this.btnTicket.BackColor = System.Drawing.Color.White;
            this.btnTicket.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTicket.Enabled = false;
            this.btnTicket.Location = new System.Drawing.Point(15, 15);
            this.btnTicket.Margin = new System.Windows.Forms.Padding(4);
            this.btnTicket.Name = "btnTicket";
            this.btnTicket.Size = new System.Drawing.Size(100, 28);
            this.btnTicket.TabIndex = 5;
            this.btnTicket.Text = "Open Ticket";
            this.btnTicket.UseVisualStyleBackColor = false;
            this.btnTicket.Click += new System.EventHandler(this.btnTicket_Click);
            // 
            // btn_Reply
            // 
            this.btn_Reply.BackColor = System.Drawing.Color.White;
            this.btn_Reply.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Reply.Enabled = false;
            this.btn_Reply.Location = new System.Drawing.Point(239, 15);
            this.btn_Reply.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Reply.Name = "btn_Reply";
            this.btn_Reply.Size = new System.Drawing.Size(100, 28);
            this.btn_Reply.TabIndex = 4;
            this.btn_Reply.Text = "Replay";
            this.btn_Reply.UseVisualStyleBackColor = false;
            this.btn_Reply.Click += new System.EventHandler(this.btn_Reply_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.White;
            this.btn_cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_cancel.Location = new System.Drawing.Point(563, 15);
            this.btn_cancel.Margin = new System.Windows.Forms.Padding(4);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(100, 28);
            this.btn_cancel.TabIndex = 1;
            this.btn_cancel.Text = "Exit";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_send
            // 
            this.btn_send.BackColor = System.Drawing.Color.White;
            this.btn_send.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_send.Location = new System.Drawing.Point(455, 15);
            this.btn_send.Margin = new System.Windows.Forms.Padding(4);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(100, 28);
            this.btn_send.TabIndex = 0;
            this.btn_send.Text = "Send";
            this.btn_send.UseVisualStyleBackColor = false;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.LimeGreen;
            this.Panel1.Controls.Add(this.lbl_size);
            this.Panel1.Controls.Add(this.lbl_text_character);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel1.Location = new System.Drawing.Point(5, 376);
            this.Panel1.Margin = new System.Windows.Forms.Padding(4);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(906, 29);
            this.Panel1.TabIndex = 33;
            // 
            // lbl_size
            // 
            this.lbl_size.AutoSize = true;
            this.lbl_size.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_size.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lbl_size.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_size.ForeColor = System.Drawing.Color.White;
            this.lbl_size.Location = new System.Drawing.Point(148, 4);
            this.lbl_size.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_size.Name = "lbl_size";
            this.lbl_size.Size = new System.Drawing.Size(20, 24);
            this.lbl_size.TabIndex = 13;
            this.lbl_size.Text = "0";
            this.lbl_size.Visible = false;
            // 
            // lbl_text_character
            // 
            this.lbl_text_character.AutoSize = true;
            this.lbl_text_character.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_text_character.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lbl_text_character.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_text_character.ForeColor = System.Drawing.Color.White;
            this.lbl_text_character.Location = new System.Drawing.Point(195, 4);
            this.lbl_text_character.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_text_character.Name = "lbl_text_character";
            this.lbl_text_character.Size = new System.Drawing.Size(199, 24);
            this.lbl_text_character.TabIndex = 12;
            this.lbl_text_character.Text = "160 CHARACHTER LEFT";
            this.lbl_text_character.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LimeGreen;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(5, 5);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(906, 29);
            this.panel2.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 24);
            this.label1.TabIndex = 13;
            this.label1.Text = "Status SMS";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.cmbCategorySms);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.txt_to);
            this.panel4.Controls.Add(this.btn_tagticket);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.txt_ticket_no);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.txt_text);
            this.panel4.Controls.Add(this.txt_from);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(5, 43);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(906, 324);
            this.panel4.TabIndex = 36;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(414, 57);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 23);
            this.label7.TabIndex = 12;
            this.label7.Text = "Category";
            // 
            // cmbCategorySms
            // 
            this.cmbCategorySms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategorySms.FormattingEnabled = true;
            this.cmbCategorySms.Location = new System.Drawing.Point(500, 55);
            this.cmbCategorySms.Name = "cmbCategorySms";
            this.cmbCategorySms.Size = new System.Drawing.Size(276, 24);
            this.cmbCategorySms.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(108, 36);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(172, 18);
            this.label6.TabIndex = 10;
            this.label6.Text = "Lebih Satu ; Diakhir Nomor";
            // 
            // btn_tagticket
            // 
            this.btn_tagticket.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_tagticket.Enabled = false;
            this.btn_tagticket.Location = new System.Drawing.Point(781, 9);
            this.btn_tagticket.Margin = new System.Windows.Forms.Padding(4);
            this.btn_tagticket.Name = "btn_tagticket";
            this.btn_tagticket.Size = new System.Drawing.Size(100, 28);
            this.btn_tagticket.TabIndex = 2;
            this.btn_tagticket.Text = "TagTicket";
            this.btn_tagticket.UseVisualStyleBackColor = true;
            this.btn_tagticket.Click += new System.EventHandler(this.btn_tagticket_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 84);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "Message";
            // 
            // txt_ticket_no
            // 
            this.txt_ticket_no.Location = new System.Drawing.Point(500, 11);
            this.txt_ticket_no.Margin = new System.Windows.Forms.Padding(4);
            this.txt_ticket_no.Name = "txt_ticket_no";
            this.txt_ticket_no.Size = new System.Drawing.Size(276, 22);
            this.txt_ticket_no.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(427, 11);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "Ticket";
            // 
            // txt_text
            // 
            this.txt_text.Location = new System.Drawing.Point(112, 84);
            this.txt_text.Margin = new System.Windows.Forms.Padding(4);
            this.txt_text.Multiline = true;
            this.txt_text.Name = "txt_text";
            this.txt_text.Size = new System.Drawing.Size(781, 236);
            this.txt_text.TabIndex = 4;
            // 
            // txt_from
            // 
            this.txt_from.Location = new System.Drawing.Point(112, 11);
            this.txt_from.Margin = new System.Windows.Forms.Padding(4);
            this.txt_from.Name = "txt_from";
            this.txt_from.Size = new System.Drawing.Size(276, 22);
            this.txt_from.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 53);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "From";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Location = new System.Drawing.Point(347, 15);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 28);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txt_to
            // 
            this.txt_to.IsMoneyFormat = false;
            this.txt_to.IsNumber = true;
            this.txt_to.IsProperCase = false;
            this.txt_to.Location = new System.Drawing.Point(112, 57);
            this.txt_to.Margin = new System.Windows.Forms.Padding(4);
            this.txt_to.Name = "txt_to";
            this.txt_to.Size = new System.Drawing.Size(276, 22);
            this.txt_to.TabIndex = 9;
            this.txt_to.ValidString = "0987654321;";
            // 
            // Sms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(916, 473);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Sms";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sms";
            this.Load += new System.EventHandler(this.Sms_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label lbl_size;
        internal System.Windows.Forms.Label lbl_text_character;
        internal System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_from;
        private System.Windows.Forms.TextBox txt_text;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_ticket_no;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_tagticket;
        private System.Windows.Forms.Button btn_outbound;
        private Contact_Center_Kone.Utility.CustomTextBox txt_to;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_Reply;
        private System.Windows.Forms.ComboBox cmbCategorySms;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnTicket;
        private System.Windows.Forms.Button btnSave;

    }
}