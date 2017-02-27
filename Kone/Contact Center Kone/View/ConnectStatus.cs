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
    public partial class ConnectStatus : Form
    {

        private int reasonType;
        protected override CreateParams CreateParams
        {
            get
            {
                const int CP_NOCLOSE = 0x200;
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE;
                return myCp;
            }
        }

        public ConnectStatus(int reasonType)
        {
            InitializeComponent();
            this.reasonType = reasonType;
            loadReasons(reasonType);
            rbYes.Checked = true;
            cmbReason.Enabled = false;
            switch (reasonType)
            {
                case 2:
                    {
                        this.Text = "Please define connect status";
                        rbYes.Text = "Connected";
                        rbNo.Text = "Unconnected"; 
                        break;
                    }
                case 4:
                    {
                        this.Text = "Please define contact status";
                        rbYes.Text = "Contacted";
                        rbNo.Text = "Uncontacted"; 
                        break;
                    }
            }
        }

        private void loadReasons(int reasonType)
        {
            cmbReason.DataSource = new Dao.OutboundStatusDetailDao().getAll(reasonType.ToString());
            cmbReason.DisplayMember = "status_detail";
            cmbReason.ValueMember = "id";
            cmbReason.SelectedIndex = -1;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (rbYes.Checked)
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            else if (rbNo.Checked)
            {
                if (cmbReason.Text.Trim() != "")
                    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                else
                    return;
            }
            else
                return;
        }

        private void cmbReason_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!rbNo.Checked)
                rbNo.Checked = true;
        }

        private void ConnectStatus_Load(object sender, EventArgs e)
        {

        }

        private void rbYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbYes.Checked)
                cmbReason.Enabled = false;
            else
                cmbReason.Enabled = true;
        }
         
    }
}
