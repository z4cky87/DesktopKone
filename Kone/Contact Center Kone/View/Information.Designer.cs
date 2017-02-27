namespace Contact_Center_Kone.View
{
    partial class Information
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
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControlInformation = new System.Windows.Forms.TabControl();
            this.tabControlInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(1049, 415);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Top 10 Dealers";
            this.tabPage6.UseVisualStyleBackColor = true;
            this.tabPage6.Click += new System.EventHandler(this.tabPage6_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1049, 415);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "List All Dealer";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1049, 415);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Status Repair";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1049, 415);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Repair Code";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1049, 415);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Sympthom Code";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1049, 415);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Address Branch";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // tabControlInformation
            // 
            this.tabControlInformation.Controls.Add(this.tabPage1);
            this.tabControlInformation.Controls.Add(this.tabPage2);
            this.tabControlInformation.Controls.Add(this.tabPage3);
            this.tabControlInformation.Controls.Add(this.tabPage4);
            this.tabControlInformation.Controls.Add(this.tabPage5);
            this.tabControlInformation.Controls.Add(this.tabPage6);
            this.tabControlInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlInformation.Location = new System.Drawing.Point(0, 0);
            this.tabControlInformation.Name = "tabControlInformation";
            this.tabControlInformation.SelectedIndex = 0;
            this.tabControlInformation.Size = new System.Drawing.Size(1057, 441);
            this.tabControlInformation.TabIndex = 0;
            this.tabControlInformation.SelectedIndexChanged += new System.EventHandler(this.tabControlInformation_SelectedIndexChanged);
            // 
            // Information
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 441);
            this.Controls.Add(this.tabControlInformation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Information";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Information";
            this.Load += new System.EventHandler(this.Information_Load);
            this.tabControlInformation.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControlInformation;

    }
}