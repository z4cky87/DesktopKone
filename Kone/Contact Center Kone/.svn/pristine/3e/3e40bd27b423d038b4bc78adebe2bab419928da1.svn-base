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
    public partial class User : Form
    {
        Dao.UserDao userDao = new Dao.UserDao();
        public User()
        {
            InitializeComponent();
        }

        #region Grid Design
        void ChangeColumnHeader()
        {
           gridUser.Columns[0].Visible = false;
          

            gridUser.Columns[1].Width = 150;
            gridUser.Columns[1].HeaderText = "Username";


            gridUser.Columns[2].Width = 150;
            gridUser.Columns[2].HeaderText = "Fullname";

            gridUser.Columns[3].Width = 150;
            gridUser.Columns[3].HeaderText = "Email";

            gridUser.Columns[4].Width = 150;
            gridUser.Columns[4].HeaderText = "Host Addres";

            gridUser.Columns[5].Width = 150;
            gridUser.Columns[5].HeaderText = "Hostname";

            gridUser.Columns[6].Width = 150;
            gridUser.Columns[6].HeaderText = "Inbound Ext";

            gridUser.Columns[7].Width = 150;
            gridUser.Columns[7].HeaderText = "Inbound Ext Password";

            gridUser.Columns[8].Width = 150;
            gridUser.Columns[8].HeaderText = "Inbound Host";

            gridUser.Columns[9].Width = 150;
            gridUser.Columns[9].HeaderText = "Outbound Ext";

            gridUser.Columns[10].Width = 150;
            gridUser.Columns[10].HeaderText = "Outbond Ext Password";

            gridUser.Columns[11].Width = 150;
            gridUser.Columns[11].HeaderText = "Outbond Host";

            gridUser.Columns[12].Width = 150;
            gridUser.Columns[12].HeaderText = "Department";

            gridUser.Columns[13].Width = 150;
            gridUser.Columns[13].HeaderText = "Level";

            gridUser.Columns[14].Width = 150;
            gridUser.Columns[14].HeaderText = "Is Active";

            gridUser.Columns[15].Visible = false;
        }
        #endregion
        #region Load Data
        public void LoadDataToGrid()
        {
            this.gridUser.DataSource = userDao.GetAll();
            ChangeColumnHeader();
            Global.ChangeHeaderGrid(gridUser);
        }
        #endregion
        private void User_Load(object sender, EventArgs e)
        {
            LoadDataToGrid();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var userDetail = new View.UserDetail();
            userDetail.StartPosition = FormStartPosition.CenterScreen;
            userDetail.userForm = this;
            userDetail.ShowDialog();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
               
                var user = userDao.GetById(this.gridUser.SelectedCells[0].Value.ToString());
                var userDetail = new View.UserDetail(user);
                userDetail.StartPosition = FormStartPosition.CenterScreen;
                userDetail.userForm = this;               
                userDetail.ShowDialog();
            }
            catch { }
        }

        private void btn_previous_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDataToGrid();
        }

        private void gridUser_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEdit.PerformClick();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var delete = MessageBox.Show("Delete " + this.gridUser.SelectedCells[1].Value.ToString() + " ?", "Delete", MessageBoxButtons.YesNo);

                if (delete == DialogResult.Yes)
                {
                    var deleteResult = userDao.Delete(new Entity.User()
                    {
                        id = this.gridUser.SelectedCells[0].Value.ToString()
                    });

                    if (deleteResult)
                    {
                        MessageBox.Show(Global.MessageDeleteSuccess);
                        LoadDataToGrid();
                    }
                    else
                    { MessageBox.Show(Global.MessageDeleteErrorr); }
                }
            }
            catch { MessageBox.Show("Pilih data di list."); }
        }
    }
}
