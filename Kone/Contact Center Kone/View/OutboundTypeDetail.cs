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
    public partial class OutboundTypeDetail : Form
    {
        Global.CrudMode mode;
        public View.OutbondType outboundTypeForm;
        Entity.OutboundType outboundType;

        Dao.OutboundTypeDao outboundTypeDao = new Dao.OutboundTypeDao();

        public OutboundTypeDetail(Global.CrudMode crudMode, Entity.OutboundType paramOutboundType = null)
        {
            InitializeComponent();
            mode = crudMode;
            outboundType = paramOutboundType;
        }
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (mode == Global.CrudMode.add)
            {
                var addMode = outboundTypeDao.Insert(new Entity.OutboundType()
                {
                    type = this.txtOutboundType.Text,
                    isActive = rbYes.Checked == true ? "1" : "0"
                });

                MessageBox.Show(addMode ? Global.MessageAddSuccess : Global.MessageAddErrorr);
                if (addMode)
                {
                    this.txtOutboundType.Clear();
                    this.txtOutboundType.Focus();
                    this.rbYes.Checked = true;
                    outboundTypeForm.LoadOutboundType();
                }
            }
            else
            {
                var editMode = outboundTypeDao.Update(new Entity.OutboundType()
                {
                    id = outboundType.id,
                    type = this.txtOutboundType.Text,
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
        private void OutboundTypeDetail_Load(object sender, EventArgs e)
        {
            if (mode == Global.CrudMode.edit)
            {
                this.txtOutboundType.Text = outboundType.type;
                this.rbYes.Checked = outboundType.isActive == "Yes" ? true : false;
                this.rbNo.Checked = outboundType.isActive == "No" ? true : false;
            }
        }
    }
}
