using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Contact_Center_Kone.Utility;

namespace Contact_Center_Kone.View
{
    public partial class UserDetail : Form
    {
        
        public View.User userForm;
        private DbMyConnection myConn = new DbMyConnection();
        Dao.UserDao userDao = new Dao.UserDao();
        Entity.User user;

        void LoadComboUserLevel()
        {
            this.cmbLevel.DataSource = new Dao.UserLevelDao().GetAllLevelName();
            this.cmbLevel.DisplayMember = "level";
            this.cmbLevel.ValueMember = "id";
        }
        void LoadComboUserDepartment()
        {
            this.cmbDepartment.DataSource = new Dao.DepartmentDao().GetAllDepartmentName();
            this.cmbDepartment.DisplayMember = "department";
            this.cmbDepartment.ValueMember = "id";
        }
        public UserDetail(Entity.User myUser=null)
        {
            InitializeComponent();
            user = myUser;
        }

        private void UserDetail_Load(object sender, EventArgs e)
        {
            LoadComboUserLevel();
            LoadComboUserDepartment();
            if(user!=null)
            {
                this.txtUsername.Text = user.username;
                this.txtFullname.Text = user.fullname;
                this.txtEmail.Text = user.email;
                this.txtInboundExt.Text = user.inbound_ext.ToString();
                this.txtInboundExtPwd.Text = user.inbound_ext_pwd.ToString();
                this.txtInboundHost.Text = user.pbx_inbound.ToString();
                this.txtOutbondExt.Text = user.outbound_ext.ToString();
                this.txtOutbondExtPwd.Text = user.outbound_ext_pwd.ToString();
                this.txtOutbondHost.Text = user.pbx_outbound.ToString();
                this.rbYes.Checked = user.isActive == "1" ? true : false;
                this.rbNo.Checked = user.isActive == "0" ? true : false;
                this.cmbLevel.Text = user.level;
                this.cmbDepartment.Text = user.department;
            }
            else { this.btnReset.Visible = false; }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
        
            if (user == null)
            {
                var addMode = userDao.Insert(new Entity.User()
                {
                   username=this.txtUsername.Text,
                   fullname=this.txtFullname.Text,
                   email=this.txtEmail.Text,
                   inbound_ext=this.txtInboundExt.Text,
                   inbound_ext_pwd=this.txtInboundExtPwd.Text,
                   pbx_inbound=this.txtInboundHost.Text,
                   outbound_ext=this.txtOutbondExt.Text,
                   outbound_ext_pwd=this.txtOutbondExtPwd.Text,
                   pbx_outbound=this.txtOutbondHost.Text,
                   level=this.cmbLevel.SelectedValue.ToString(),
                   department=this.cmbDepartment.SelectedValue.ToString(),
                   isActive = rbYes.Checked == true ? "1" : "0"
                });

                MessageBox.Show(addMode ? Global.MessageAddSuccess : Global.MessageAddErrorr);
                if(addMode)
                {
                    foreach (var item in this.Controls)
                    {
                        if(item is TextBox)
                        {
                            ((TextBox)item).Clear();
                        }
                    }
                    userForm.LoadDataToGrid();
                }
             
            }
            else
            {
                var editMode = userDao.Update(new Entity.User()
                {
                    id=user.id,
                    username = this.txtUsername.Text,
                    fullname = this.txtFullname.Text,
                    email = this.txtEmail.Text,                  
                    inbound_ext = this.txtInboundExt.Text,
                    inbound_ext_pwd = this.txtInboundExtPwd.Text,
                    pbx_inbound = this.txtInboundHost.Text,
                    outbound_ext = this.txtOutbondExt.Text,
                    outbound_ext_pwd = this.txtOutbondExtPwd.Text,
                    pbx_outbound = this.txtOutbondHost.Text,
                    level = this.cmbLevel.SelectedValue.ToString(),
                    department = this.cmbDepartment.SelectedValue.ToString(),
                    isActive = rbYes.Checked == true ? "1" : "0"
                });

                MessageBox.Show(editMode ? Global.MessageEditSuccess : Global.MessageEditErrorr);
                if (editMode)
                {
                    userForm.LoadDataToGrid();
                    Dispose();
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Reset Password","Reset",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                if(userDao.ResetPassword(user.id))
                {
                    MessageBox.Show("Reset Berhasil");
                }
            }
        }
    }
}
