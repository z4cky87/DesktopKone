using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Contact_Center_Kone.Utility;

namespace Contact_Center_Kone.View
{
    public partial class Login : Form
    {
        View.Main main = new Main();
        Dao.UserDao userDao = new Dao.UserDao();
        
        public Login()
        {
            InitializeComponent();

            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fileVersionInfo.ProductVersion;
            lbl_Version.Text = "V " + version;
            this.txt_username.Focus();
           
        }

        private void Clear()
        {
            this.txt_username.Clear();
            this.txt_password.Clear();
        }
        private void btn_login_Click(object sender, EventArgs e)
        {
            if (this.cmbShift.Text == "") { MessageBox.Show("Select shift."); }
            else
            {
                var user = new Entity.User();
                user.username = this.txt_username.Text;
                user.password = this.txt_password.Text;

                if (userDao.Login(user))
                  {
                      Assembly assembly = Assembly.GetExecutingAssembly();
                      FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
                      var _loglogin = new Entity.LogLogin();
                      if (userDao.CheckLoginFirst(_loglogin))
                      {
                          //Global.userAccount.id = userDao.UpdateLog_login_Next();
                         userDao.UpdateLog_login_Next();
                          //userDao.UpdateLog_login_Next();   
                      }
                      else
                      {
                          //Global.log_login_id = userDao.InsertLog_login();
                          userDao.InsertLog_login();
                      }
                      main.login = this;
                      this.Hide();
                      Global.userAccount.password = this.txt_password.Text;                      
                      this.txt_password.Clear();
                      this.txt_username.Clear();
                      userDao.LogAppVer(fileVersionInfo.ProductVersion);
                      userDao.ChangeActivityUser(Global.userAccount.id, "8");
                      Global.shiftId = cmbShift.SelectedIndex + 1;
                      main.ShowDialog();
                      
                  }
                else
                {
                    MessageBox.Show("Username and password not match.");
                }
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit application ? ", "Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Global.KillApp("Telephony");
                Global.KillApp("VoiceUploader");

                var userDao = new Dao.UserDao().ChangeActivityUser(Global.userAccount.id, "1");
                //System.Environment.Exit(0);
                Application.Exit();
                
            }
            else { }

        }

        private void txt_username_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                txt_password.Focus();
            }
        }

        private void txt_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                btn_login.PerformClick();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            //var userDao=new Dao.UserDao().ChangeActivityUser(Global.userAccount.id, "8");
        }


    }
}
