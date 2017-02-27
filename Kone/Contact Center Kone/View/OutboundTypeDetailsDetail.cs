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
    public partial class OutboundTypeDetailsDetail : Form
    {
        Global.CrudMode mode;
        public View.OutbondType outboundTypeForm;
        Entity.OutboundTypeDetail outboundTypeDetail;

        Dao.OutboundTypeDao outboundTypeDao = new Dao.OutboundTypeDao();
        Dao.OutboundTypeDetailDao outboundTypeDetailDao = new Dao.OutboundTypeDetailDao();

        #region LoadData
        void LoadCmbOutboundType()
        {
            this.cmbOutboundType.DataSource = outboundTypeDao.GetAll();
            this.cmbOutboundType.ValueMember = "id";
            this.cmbOutboundType.DisplayMember = "type";
        }
        #endregion

        public OutboundTypeDetailsDetail(Global.CrudMode crudMode, Entity.OutboundTypeDetail paramOutboundType = null)
        {
            InitializeComponent();
            mode = crudMode;
            outboundTypeDetail = paramOutboundType;
        }

        private void OutboundTypeDetailsDetail_Load(object sender, EventArgs e)
        {
            LoadCmbOutboundType();
            if (mode == Global.CrudMode.edit)
            {
                this.cmbOutboundType.SelectedValue = outboundTypeDetail.outboundType.id;
                this.txtOutboundTypeDetail.Text = outboundTypeDetail.type_detail;
                this.rbYes.Checked = outboundTypeDetail.isActive == "Yes" ? true : false;
                this.rbNo.Checked = outboundTypeDetail.isActive == "No" ? true : false;
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (mode == Global.CrudMode.add)
            {
                var addMode = outboundTypeDetailDao.Insert(new Entity.OutboundTypeDetail()
                {
                    outboundType = new Entity.OutboundType() { id = Convert.ToInt32(this.cmbOutboundType.SelectedValue.ToString()) },
                    type_detail = this.txtOutboundTypeDetail.Text,
                    isActive = rbYes.Checked == true ? "1" : "0"
                });

                MessageBox.Show(addMode ? Global.MessageAddSuccess : Global.MessageAddErrorr);
                if (addMode)
                {
                    this.txtOutboundTypeDetail.Clear();
                    this.txtOutboundTypeDetail.Focus();
                    this.rbYes.Checked = true;
                    outboundTypeForm.LoadOutboundType();
                }
            }
            else
            {
                var editMode = outboundTypeDetailDao.Update(new Entity.OutboundTypeDetail()
                {
                    id = outboundTypeDetail.id,
                    outboundType = new Entity.OutboundType() { id = Convert.ToInt32(this.cmbOutboundType.SelectedValue.ToString()) },
                    type_detail = this.txtOutboundTypeDetail.Text,
                    isActive = rbYes.Checked == true ? "1" : "0"
                });

                MessageBox.Show(editMode ? Global.MessageEditSuccess : Global.MessageEditErrorr);
                if (editMode)
                {
                    outboundTypeForm.LoadOutboundType();
                    Dispose();
                }
            }
        }
    }
}
