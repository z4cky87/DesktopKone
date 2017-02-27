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
    public partial class InboundCategoryDetail : Form
    {
        private Dao.InboundCallerTypeDao inboundCallerTypeDao = new Dao.InboundCallerTypeDao();
        private Dao.CallerTypeDetailDao inboundCategoryDao = new Dao.CallerTypeDetailDao();
        public View.CallerType inboundCategoryForm;
        Entity.CallerTypeDetail inboundCategory;

        #region LoadData
        void LoadComboCallerType()
        {
            this.cmbCallerType.DataSource = inboundCallerTypeDao.GetListCallerType();
            this.cmbCallerType.ValueMember = "id";
            this.cmbCallerType.DisplayMember = "type";
        }
        #endregion
        public InboundCategoryDetail(Entity.CallerTypeDetail paramInboundCategory = null)
        {
            InitializeComponent();
            inboundCategory = paramInboundCategory;
        }

        private void InboundCategoryDetail_Load(object sender, EventArgs e)
        {
            LoadComboCallerType();
            if (inboundCategory != null)
            {
                this.cmbCallerType.Text = inboundCategoryForm.gridInboundCallerType.SelectedCells[1].Value.ToString();
                this.txtCategory.Text = inboundCategory.name;
                this.rbYes.Checked = inboundCategory.isActive == "2" ? true : false;
                this.rbNo.Checked = inboundCategory.isActive == "1" ? true : false;
            }

        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            //if (inboundCategory == null)
            //{
            //    var addMode = inboundCategoryDao.Insert(new Entity.CallerTypeDetail()
            //    {
            //        name=this.txtCategory.Text,
            //        callerType=new Entity.InboundCallerType(){id=this.cmbCallerType.SelectedValue.ToString()},
            //        isActive = rbYes.Checked == true ? "2" : "1"
            //    });

            //    MessageBox.Show(addMode ? Global.MessageAddSuccess : Global.MessageAddErrorr);
            //    if (addMode)
            //    {
            //        this.txtCategory.Clear();
            //        this.txtCategory.Focus();
            //        this.rbYes.Checked = true;
            //        inboundCategoryForm.LoadCallerTypeDetail(inboundCategoryForm.gridInboundCallerType.SelectedCells[0].Value.ToString());
            //    }
            //}
            //else
            //{
            //    var editMode = inboundCategoryDao.Update(new Entity.CallerTypeDetail()
            //    {
            //        id=inboundCategory.id,
            //        name = this.txtCategory.Text,
            //        callerType = new Entity.InboundCallerType() { id = this.cmbCallerType.SelectedValue.ToString() },
            //        isActive = rbYes.Checked == true ? "2" : "1"
            //    });

            //    MessageBox.Show(editMode ? Global.MessageEditSuccess : Global.MessageEditErrorr);
            //    if (editMode)
            //    {
            //        inboundCategoryForm.LoadCallerTypeDetail(inboundCategoryForm.gridInboundCallerType.SelectedCells[0].Value.ToString());
            //        Dispose();
            //    }
            //}
        }
    }
}
