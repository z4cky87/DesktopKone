using Contact_Center_Kone.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Contact_Center_Kone.View
{
    public partial class ChangePassword : Form
    {
        private Dao.UserDao userDao = new Dao.UserDao();
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if(this.txtOldPassword.Text!=Global.userAccount.password)
            {
                MessageBox.Show("Old Password Wrong !!","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                if(this.txtNewPassword.Text!=this.txtConfirm.Text)
                {
                    MessageBox.Show("New Password and Confirm Password Not Match !!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    var changePassword = userDao.ChangePassword(Global.userAccount.id, this.txtNewPassword.Text);
                    if(changePassword)
                    {
                        MessageBox.Show("Change Password Success"); Dispose();
                    }
                    else { MessageBox.Show("Change Password Failed"); }
                }
            }
        }
    }
}
