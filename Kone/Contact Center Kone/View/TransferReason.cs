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
    public partial class TransferReason : Form
    {
        Dao.TransferReasonDao trasnferReason = new Dao.TransferReasonDao();
        int _idCall;
        public int _reasonId;

        public TransferReason(int idCall = 0)
        {
            InitializeComponent();
            _idCall = idCall;
       
        }


        void LoadReason()
        {
            
            cmbReason.DataSource = trasnferReason.GetTrasnferReason();
            this.cmbReason.DisplayMember = "transfer";
            this.cmbReason.ValueMember = "id";
        }

        private void cmbReason_SelectedValueChanged(object sender, EventArgs e)
        {
           // _reasonId = Convert.ToInt32(cmbReason.SelectedValue);
        }

        private void cmbReason_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }

        private void TransferReason_Load(object sender, EventArgs e)
        {
            LoadReason();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbReason.Text))
                _reasonId = Convert.ToInt32(cmbReason.SelectedValue);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

    }
}
