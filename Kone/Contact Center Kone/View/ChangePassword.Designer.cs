namespace Contact_Center_Kone.View
{
    partial class ChangePassword
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
            this.txtOldPassword = new Contact_Center_Kone.Utility.CustomTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.txtNewPassword = new Contact_Center_Kone.Utility.CustomTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtConfirm = new Contact_Center_Kone.Utility.CustomTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOldPassword.IsMoneyFormat = false;
            this.txtOldPassword.IsNumber = false;
            this.txtOldPassword.IsProperCase = false;
            this.txtOldPassword.Location = new System.Drawing.Point(135, 12);
            this.txtOldPassword.MaxLength = 30000;
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.Size = new System.Drawing.Size(223, 23);
            this.txtOldPassword.TabIndex = 39;
            this.txtOldPassword.UseSystemPasswordChar = true;
            this.txtOldPassword.ValidString = "0987654321";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(2, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 19);
            this.label4.TabIndex = 41;
            this.label4.Text = "Old Password";
            // 
            // btnSimpan
            // 
            this.btnSimpan.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSimpan.Location = new System.Drawing.Point(259, 98);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(99, 32);
            this.btnSimpan.TabIndex = 40;
            this.btnSimpan.Text = "Save";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPassword.IsMoneyFormat = false;
            this.txtNewPassword.IsNumber = false;
            this.txtNewPassword.IsProperCase = false;
            this.txtNewPassword.Location = new System.Drawing.Point(135, 37);
            this.txtNewPassword.MaxLength = 30000;
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '*';
            this.txtNewPassword.Size = new System.Drawing.Size(223, 23);
            this.txtNewPassword.TabIndex = 42;
            this.txtNewPassword.UseSystemPasswordChar = true;
            this.txtNewPassword.ValidString = "0987654321";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 19);
            this.label1.TabIndex = 43;
            this.label1.Text = "New Password";
            // 
            // txtConfirm
            // 
            this.txtConfirm.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirm.IsMoneyFormat = false;
            this.txtConfirm.IsNumber = false;
            this.txtConfirm.IsProperCase = false;
            this.txtConfirm.Location = new System.Drawing.Point(135, 62);
            this.txtConfirm.MaxLength = 30000;
            this.txtConfirm.Name = "txtConfirm";
            this.txtConfirm.PasswordChar = '*';
            this.txtConfirm.Size = new System.Drawing.Size(223, 23);
            this.txtConfirm.TabIndex = 44;
            this.txtConfirm.UseSystemPasswordChar = true;
            this.txtConfirm.ValidString = "0987654321";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 19);
            this.label2.TabIndex = 45;
            this.label2.Text = "Confirm Password";
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 142);
            this.Controls.Add(this.txtConfirm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtOldPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSimpan);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangePassword";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Change Password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Contact_Center_Kone.Utility.CustomTextBox txtOldPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSimpan;
        private Contact_Center_Kone.Utility.CustomTextBox txtNewPassword;
        private System.Windows.Forms.Label label1;
        private Contact_Center_Kone.Utility.CustomTextBox txtConfirm;
        private System.Windows.Forms.Label label2;
    }
}