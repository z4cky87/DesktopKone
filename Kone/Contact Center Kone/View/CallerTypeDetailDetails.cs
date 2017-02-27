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
    public partial class CallerTypeDetailDetails : Form
    {

        public View.CallerType callerTypeForm;
        Entity.CallerTypeDetail callerTypeDetail;

        Dao.CallerTypeDetailDao callerTypeDetailDao = new Dao.CallerTypeDetailDao();

        #region Load

        void LoadComboCallerType()
        {
            this.cmbCallerType.DataSource = new Dao.CallerTypeDao().GetListCallerType((this.cmbDirection.SelectedIndex + 1).ToString());
            this.cmbCallerType.DisplayMember = "type";
            this.cmbCallerType.ValueMember = "id";
        }

        #endregion
        public CallerTypeDetailDetails(Entity.CallerTypeDetail paramCallerTypeDetail = null)
        {
            InitializeComponent();
            callerTypeDetail = paramCallerTypeDetail;
        }

        private void CallerTypeDetailDetails_Load(object sender, EventArgs e)
        {
            this.cmbDirection.SelectedIndex = 0;
            LoadComboCallerType();


            this.cmbDirection.SelectedIndex = callerTypeForm.cmbDirection.SelectedIndex;
            this.cmbCallerType.SelectedValue = callerTypeForm.gridInboundCallerType.SelectedCells[0].Value.ToString();
            if (callerTypeDetail != null)
            {

                this.txtCallerTypeDetail.Text = callerTypeDetail.name;
                this.cmbCallerType.SelectedValue = callerTypeDetail.callerType.id;
                this.rbYes.Checked = callerTypeDetail.isActive == "2" ? true : false;
                this.rbNo.Checked = callerTypeDetail.isActive == "1" ? true : false;
                this.cmbDirection.Enabled = false;
            }
        }

        private void cmbDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadComboCallerType();
            }
            catch
            {

            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (callerTypeDetail == null)
            {
                var addMode = callerTypeDetailDao.Insert(new Entity.CallerTypeDetail()
                {

                    callerType = new Entity.CallerType() { id = this.cmbCallerType.SelectedValue.ToString() },
                    name = this.txtCallerTypeDetail.Text,
                    isActive = rbYes.Checked == true ? "2" : "1"
                });

                MessageBox.Show(addMode ? Global.MessageAddSuccess : Global.MessageAddErrorr);
                if (addMode)
                {
                    this.txtCallerTypeDetail.Clear();
                    this.txtCallerTypeDetail.Focus();
                    this.rbYes.Checked = true;
                    callerTypeForm.LoadCallerTypeDetail(callerTypeForm.gridInboundCallerType.SelectedCells[0].Value.ToString());

                }
            }
            else
            {
                var editMode = callerTypeDetailDao.Update(new Entity.CallerTypeDetail()
                {
                    id = callerTypeDetail.id,
                    callerType = new Entity.CallerType() { id = this.cmbCallerType.SelectedValue.ToString() },
                    name = this.txtCallerTypeDetail.Text,
                    isActive = rbYes.Checked == true ? "2" : "1"
                });

                MessageBox.Show(editMode ? Global.MessageEditSuccess : Global.MessageEditErrorr);
                if (editMode)
                {
                    callerTypeForm.LoadCallerTypeDetail(callerTypeForm.gridInboundCallerType.SelectedCells[0].Value.ToString());
                    Dispose();
                }
            }
            
        }
    }
}
