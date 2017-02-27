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
    public partial class CallerType : Form
    {
        private Dao.CallerTypeDao callerTypeDao = new Dao.CallerTypeDao();
        private Dao.CallerTypeDetailDao callerTypeDetailDao = new Dao.CallerTypeDetailDao();
        #region LoadData
        public void LoadCallerType()
        {
            this.gridInboundCallerType.DataSource = callerTypeDao.GetAllCallerType((this.cmbDirection.SelectedIndex+1).ToString());
            ChangeColumnHeaderCallerType();
        }
        public void LoadCallerTypeDetail(string callerTypeId)
        {
            this.gridCategory.DataSource = callerTypeDetailDao.GetAll(callerTypeId);
            ChangeColumnHeaderCategory();
        }

        #endregion

        #region GridDesign

        void ChangeColumnHeaderCallerType()
        {
            gridInboundCallerType.Columns[0].Visible = false;
            gridInboundCallerType.Columns[1].Visible = false;

            gridInboundCallerType.Columns[2].Width = 200;
            gridInboundCallerType.Columns[2].HeaderText = "Type Name";

            gridInboundCallerType.Columns[3].Width = 200;
            gridInboundCallerType.Columns[3].HeaderText = "Active";
        }

        void ChangeColumnHeaderCategory()
        {
            this.gridCategory.Columns[0].Visible = false;

            gridCategory.Columns[1].Width = 400;
            gridCategory.Columns[1].HeaderText = "Type Name";

            gridCategory.Columns[2].Width = 200;
            gridCategory.Columns[2].HeaderText = "Active";

            this.gridCategory.Columns[3].Visible = false;
        }
        #endregion
        public CallerType()
        {
            InitializeComponent();
        }

        private void btnAddInboundCallerType_Click(object sender, EventArgs e)
        {
            View.CallerTypeDetail inboundCallerTypeDetail =
                   new CallerTypeDetail();
            inboundCallerTypeDetail.callerTypeForm = this;
            inboundCallerTypeDetail.StartPosition = FormStartPosition.CenterScreen;
            inboundCallerTypeDetail.ShowDialog();
        }

        private void InboundCategory_Load(object sender, EventArgs e)
        {
            this.cmbDirection.SelectedIndex = 0;
            LoadCallerType();

            try
            {
                LoadCallerTypeDetail(this.gridInboundCallerType.SelectedCells[0].Value.ToString());
            }
            catch { }
        }

        private void btnEditInboundCallerType_Click(object sender, EventArgs e)
        {
            try
            {
                var inboundCallerType = callerTypeDao.GetCallerType_ByID(this.gridInboundCallerType.SelectedCells[0].Value.ToString());

                View.CallerTypeDetail callerTypeDetail =
                    new CallerTypeDetail(inboundCallerType);
                callerTypeDetail.callerTypeForm = this;
                callerTypeDetail.StartPosition = FormStartPosition.CenterScreen;
                callerTypeDetail.ShowDialog();

               
            }
            catch { MessageBox.Show("Pilih data di list."); }
        }

        private void btnDeleteInboundCallerType_Click(object sender, EventArgs e)
        {
            try
            {
                var delete = MessageBox.Show("Delete " + this.gridInboundCallerType.SelectedCells[2].Value.ToString() + " ?", "Delete", MessageBoxButtons.YesNo);

                if (delete == DialogResult.Yes)
                {
                    var deleteResult = callerTypeDao.Delete(new Entity.CallerType()
                    {
                        id = this.gridInboundCallerType.SelectedCells[0].Value.ToString()
                    });

                    if (deleteResult)
                    {
                        MessageBox.Show(Global.MessageDeleteSuccess);
                        LoadCallerType();
                    }
                    else
                    { MessageBox.Show(Global.MessageDeleteErrorr); }
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message+"Pilih data di list."); }
        }

        private void gridInboundCallerType_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                try
                {
                    LoadCallerTypeDetail(this.gridInboundCallerType.SelectedCells[0].Value.ToString());
                }
                catch { }
            }
        }

        private void gridInboundCallerType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                LoadCallerTypeDetail(this.gridInboundCallerType.SelectedCells[0].Value.ToString());
            }
            catch { }
        }

        private void gridInboundCallerType_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btnEditInboundCallerType.PerformClick();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            View.CallerTypeDetailDetails callerTypeDetails =
                  new CallerTypeDetailDetails();
            callerTypeDetails.callerTypeForm = this;
            callerTypeDetails.StartPosition = FormStartPosition.CenterScreen;
            callerTypeDetails.ShowDialog();
        }

        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            try
            {
                var callerTypeDetail = callerTypeDetailDao.GetById(this.gridCategory.SelectedCells[0].Value.ToString());

                View.CallerTypeDetailDetails callerTypeDetails =
                  new CallerTypeDetailDetails(callerTypeDetail);
                callerTypeDetails.callerTypeForm = this;
                callerTypeDetails.StartPosition = FormStartPosition.CenterScreen;
                callerTypeDetails.ShowDialog();
            }
            catch { MessageBox.Show("Pilih data di list."); }
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            try
            {
                var delete = MessageBox.Show("Delete " + this.gridCategory.SelectedCells[1].Value.ToString() + " ?", "Delete", MessageBoxButtons.YesNo);

                if (delete == DialogResult.Yes)
                {
                    var deleteResult = callerTypeDetailDao.Delete(new Entity.CallerTypeDetail()
                    {
                        id = this.gridCategory.SelectedCells[0].Value.ToString()
                    });

                    if (deleteResult)
                    {
                        MessageBox.Show(Global.MessageDeleteSuccess);
                        LoadCallerTypeDetail(this.gridInboundCallerType.SelectedCells[0].Value.ToString());
                    }
                    else
                    { MessageBox.Show(Global.MessageDeleteErrorr); }
                }
            }
            catch { MessageBox.Show("Pilih data di list."); }
        }

        private void cmbDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCallerType();
            try
            {
                LoadCallerTypeDetail(this.gridInboundCallerType.SelectedCells[0].Value.ToString());
            }
            catch { }
        }
    }
}
