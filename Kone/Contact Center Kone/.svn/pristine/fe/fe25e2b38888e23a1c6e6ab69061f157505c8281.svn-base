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
    public partial class CallerTypeDetail : Form
    {
        
        public View.CallerType callerTypeForm;
        Entity.CallerType callerType;

        Dao.CallerTypeDao callerTypeDao = new Dao.CallerTypeDao();

        public CallerTypeDetail(Entity.CallerType paramCallerType = null)
        {
            InitializeComponent();

           
           
            callerType = paramCallerType;
        }

        private void InboundTypeDetail_Load(object sender, EventArgs e)
        {
            this.cmbDirection.SelectedIndex = callerTypeForm.cmbDirection.SelectedIndex;
            if (callerType!=null)
            {

                this.cmbDirection.SelectedIndex =Convert.ToInt32(callerType.direction)-1;
                this.txtCallerType.Text = callerType.type;
                this.rbYes.Checked = callerType.isActive == "2" ? true : false;
                this.rbNo.Checked = callerType.isActive == "1" ? true : false;
                this.cmbDirection.Enabled = false;
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (callerType == null)
            {
                var addMode = callerTypeDao.Insert(new Entity.CallerType()
                {
                    direction=(this.cmbDirection.SelectedIndex+1).ToString(),
                    type=this.txtCallerType.Text,
                    isActive = rbYes.Checked == true ? "2" : "1"
                });

                MessageBox.Show(addMode ? Global.MessageAddSuccess : Global.MessageAddErrorr);
                if (addMode)
                {
                    this.txtCallerType.Clear();
                    this.txtCallerType.Focus();
                    this.rbYes.Checked = true;
                    callerTypeForm.LoadCallerType();
                }
            }
            else
            {
                var editMode = callerTypeDao.Update(new Entity.CallerType()
                {
                    id = callerType.id,
                    type = this.txtCallerType.Text,
                    isActive = rbYes.Checked == true ? "2" : "1"
                });

                MessageBox.Show(editMode ? Global.MessageEditSuccess : Global.MessageEditErrorr);
                if (editMode)
                {
                    callerTypeForm.LoadCallerType();
                    Dispose();
                }
            }
        }
    }
}
