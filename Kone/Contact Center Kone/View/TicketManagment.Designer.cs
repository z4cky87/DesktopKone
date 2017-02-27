namespace Contact_Center_Kone.View
{
    partial class TicketManagment
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
            this.geckoWebBrowser1 = new Gecko.GeckoWebBrowser();
            this.tabControl_TicketMangment = new System.Windows.Forms.TabControl();
            this.tabPage_Ticket = new System.Windows.Forms.TabPage();
            this.tabControl_TicketMangment.SuspendLayout();
            this.tabPage_Ticket.SuspendLayout();
            this.SuspendLayout();
            // 
            // geckoWebBrowser1
            // 
            this.geckoWebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.geckoWebBrowser1.Location = new System.Drawing.Point(3, 3);
            this.geckoWebBrowser1.Name = "geckoWebBrowser1";
            this.geckoWebBrowser1.Size = new System.Drawing.Size(861, 472);
            this.geckoWebBrowser1.TabIndex = 1;
            this.geckoWebBrowser1.UseHttpActivityObserver = false;
            this.geckoWebBrowser1.Click += new System.EventHandler(this.geckoWebBrowser1_Click);
            // 
            // tabControl_TicketMangment
            // 
            this.tabControl_TicketMangment.Controls.Add(this.tabPage_Ticket);
            this.tabControl_TicketMangment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_TicketMangment.Location = new System.Drawing.Point(0, 0);
            this.tabControl_TicketMangment.Name = "tabControl_TicketMangment";
            this.tabControl_TicketMangment.SelectedIndex = 0;
            this.tabControl_TicketMangment.Size = new System.Drawing.Size(875, 504);
            this.tabControl_TicketMangment.TabIndex = 2;
            // 
            // tabPage_Ticket
            // 
            this.tabPage_Ticket.Controls.Add(this.geckoWebBrowser1);
            this.tabPage_Ticket.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Ticket.Name = "tabPage_Ticket";
            this.tabPage_Ticket.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Ticket.Size = new System.Drawing.Size(867, 478);
            this.tabPage_Ticket.TabIndex = 0;
            this.tabPage_Ticket.Text = "Ticket";
            this.tabPage_Ticket.UseVisualStyleBackColor = true;
            // 
            // TicketManagment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 504);
            this.Controls.Add(this.tabControl_TicketMangment);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TicketManagment";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "TicketManagment";
            this.Activated += new System.EventHandler(this.TicketManagment_Activated);
            this.Load += new System.EventHandler(this.TicketManagment_Load);
            this.tabControl_TicketMangment.ResumeLayout(false);
            this.tabPage_Ticket.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gecko.GeckoWebBrowser geckoWebBrowser1;
        private System.Windows.Forms.TabControl tabControl_TicketMangment;
        private System.Windows.Forms.TabPage tabPage_Ticket;
    }
}