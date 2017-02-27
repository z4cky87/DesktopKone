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
    public partial class OutbondType : Form
    {
        Dao.OutboundTypeDao outboundTypeDao = new Dao.OutboundTypeDao();
        Dao.OutboundTypeDetailDao outboundTypeDetailDao = new Dao.OutboundTypeDetailDao();

        #region ChangeColumnHeader
        void ChangecolumnHeaderOutboundType()
        {
            this.gridOutboundType.Columns[0].Visible = false;

            gridOutboundType.Columns[1].Width = 200;
            gridOutboundType.Columns[1].HeaderText = "Name";

            gridOutboundType.Columns[2].Width = 80;
            gridOutboundType.Columns[2].HeaderText = "Active";
        }
        void ChangecolumnHeaderOutboundTypeDetails()
        {
            this.gridOutboundTypeDetail.Columns[0].Visible = false;

            gridOutboundTypeDetail.Columns[1].Width = 400;
            gridOutboundTypeDetail.Columns[1].HeaderText = "Name";

            gridOutboundTypeDetail.Columns[2].Width = 80;
            gridOutboundTypeDetail.Columns[2].HeaderText = "Active";
        }
        #endregion
        #region Load Data

        public void LoadOutboundType()
        {
            var datasource = outboundTypeDao.GetAll();
            this.gridOutboundType.DataSource = datasource;
            ChangecolumnHeaderOutboundType();
            LoadOutboundTypeDetail(gridOutboundType.SelectedCells[0].Value.ToString());
            if (datasource.Count == 0) { this.lblNoDataOutboundType.Visible = true; } else { this.lblNoDataOutboundType.Visible = false; }

        }
        public void LoadOutboundTypeDetail(string id)
        {
            var datasource = outboundTypeDetailDao.GetAll(id);
            this.gridOutboundTypeDetail.DataSource = datasource;
            ChangecolumnHeaderOutboundTypeDetails();
            if (datasource.Count == 0) { this.lblNoDataOutboundTypeDetail.Visible = true; } else { this.lblNoDataOutboundTypeDetail.Visible = false; }

        }
        #endregion
        public OutbondType()
        {
            InitializeComponent();
        }

        private void OutbondType_Load(object sender, EventArgs e)
        {
            LoadOutboundType();
        }

        private void btnAddOutboundType_Click(object sender, EventArgs e)
        {
            var outboundTypeDetail = new View.OutboundTypeDetail(Contact_Center_Kone.Utility.Global.CrudMode.add);
            outboundTypeDetail.StartPosition = FormStartPosition.CenterScreen;
            outboundTypeDetail.outboundTypeForm = this;
            outboundTypeDetail.ShowDialog();
        }

        private void btnEditOutboundType_Click(object sender, EventArgs e)
        {
            try
            {
                var getOutboundTypeDetail = outboundTypeDao.GetById(this.gridOutboundType.SelectedCells[0].Value.ToString());
                var outboundTypeDetail = new View.OutboundTypeDetail(Contact_Center_Kone.Utility.Global.CrudMode.edit, getOutboundTypeDetail);
                outboundTypeDetail.StartPosition = FormStartPosition.CenterScreen;
                outboundTypeDetail.outboundTypeForm = this;
                outboundTypeDetail.ShowDialog();
            }
            catch { MessageBox.Show("Pilih data di list."); }
        }

        private void btnDeleteOutboundType_Click(object sender, EventArgs e)
        {
            try
            {
                var delete = MessageBox.Show("Delete " +
                                                        this.gridOutboundType.SelectedCells[1].Value.ToString() + " " +
                                                         " ?", "Delete", MessageBoxButtons.YesNo);

                if (delete == DialogResult.Yes)
                {
                    var deleteResult = this.outboundTypeDao.Delete(new Entity.OutboundType()
                    {
                        id = Convert.ToInt32(this.gridOutboundType.SelectedCells[0].Value.ToString())
                    });

                    if (deleteResult)
                    {
                        MessageBox.Show(Global.MessageDeleteSuccess);
                        LoadOutboundType();
                    }
                    else
                    { MessageBox.Show(Global.MessageDeleteErrorr); }
                }
            }
            catch { MessageBox.Show("Pilih data di list."); }
        }

        private void btnAddOutboundTypeDetail_Click(object sender, EventArgs e)
        {
            var outboundTypeDetailDetail = new View.OutboundTypeDetailsDetail(Contact_Center_Kone.Utility.Global.CrudMode.add);
            outboundTypeDetailDetail.StartPosition = FormStartPosition.CenterScreen;
            outboundTypeDetailDetail.outboundTypeForm = this;
            outboundTypeDetailDetail.ShowDialog();
        }

        private void btnUbahOutboundTypeDetail_Click(object sender, EventArgs e)
        {
            try
            {
                var getOuboundTypeDetailDetail = this.outboundTypeDetailDao.GetById(this.gridOutboundTypeDetail.SelectedCells[0].Value.ToString());
                var outboundTypeDetail = new View.OutboundTypeDetailsDetail(Contact_Center_Kone.Utility.Global.CrudMode.edit, getOuboundTypeDetailDetail);
                outboundTypeDetail.StartPosition = FormStartPosition.CenterScreen;
                outboundTypeDetail.outboundTypeForm = this;
                outboundTypeDetail.ShowDialog();
            }
            catch { MessageBox.Show("Pilih data di list."); }
        }

        private void btnDeleteOutboundTypeDetail_Click(object sender, EventArgs e)
        {
            try
            {
                var delete = MessageBox.Show("Delete " +
                                                        this.gridOutboundTypeDetail.SelectedCells[1].Value.ToString() + " " +
                                                         " ?", "Delete", MessageBoxButtons.YesNo);

                if (delete == DialogResult.Yes)
                {
                    var deleteResult = this.outboundTypeDetailDao.Delete(new Entity.OutboundTypeDetail()
                    {
                        id = Convert.ToInt32(this.gridOutboundType.SelectedCells[0].Value.ToString())
                    });

                    if (deleteResult)
                    {
                        MessageBox.Show(Global.MessageDeleteSuccess);
                        LoadOutboundType();
                    }
                    else
                    { MessageBox.Show(Global.MessageDeleteErrorr); }
                }
            }
            catch { MessageBox.Show("Pilih data di list."); }
        }

        private void gridOutboundType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                LoadOutboundTypeDetail(this.gridOutboundType.SelectedCells[0].Value.ToString());
            }
            catch { }
        }

        private void gridOutboundType_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                try
                {
                    LoadOutboundTypeDetail(this.gridOutboundType.SelectedCells[0].Value.ToString());
                }
                catch { }
            }
        }

        private void gridOutboundType_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btnEditOutboundType.PerformClick();
        }

        private void gridOutboundTypeDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btnUbahOutboundTypeDetail.PerformClick();
        }
    }
}
