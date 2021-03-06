﻿using Contact_Center_Kone.Utility;
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
    public partial class CallCenter : Form
    {
        Main mymain;
        public Dao.CallDao callDao = new Dao.CallDao();

        #region Grid Design
        void ChangeColumnHeader()
        {

            dtgrid_CallDetail.Columns[0].Visible = false;

            dtgrid_CallDetail.Columns[1].Width = 200;
            dtgrid_CallDetail.Columns[1].HeaderText = "Call Date";

            //dtgrid_CallDetail.Columns[2].Width = 200;
            //dtgrid_CallDetail.Columns[2].HeaderText = "Ticket No";
            //dtgrid_CallDetail.Columns[2].DefaultCellStyle.ForeColor = Color.Red;
            dtgrid_CallDetail.Columns[2].Visible = false;



            dtgrid_CallDetail.Columns[3].Width = 200;
            dtgrid_CallDetail.Columns[3].HeaderText = "Caller Name";
          

            dtgrid_CallDetail.Columns[4].Width = 200;
            dtgrid_CallDetail.Columns[4].HeaderText = "Username";

            dtgrid_CallDetail.Columns[5].Width = 200;
            dtgrid_CallDetail.Columns[5].HeaderText = "Direction";

            dtgrid_CallDetail.Columns[6].Width = 200;
            dtgrid_CallDetail.Columns[6].HeaderText = "Call Status";

            dtgrid_CallDetail.Columns[7].Width = 200;
            dtgrid_CallDetail.Columns[7].HeaderText = "Caller Type";

            //dtgrid_CallDetail.Columns[8].Visible = false;
            


            dtgrid_CallDetail.Columns[8].Width = 200;
            dtgrid_CallDetail.Columns[8].HeaderText = "Outbound Type";

            //dtgrid_CallDetail.Columns[9].Width = 200;
            //dtgrid_CallDetail.Columns[9].HeaderText = "Outbond Status Detail";

            dtgrid_CallDetail.Columns[9].Visible = false;
            

            dtgrid_CallDetail.Columns[10].Width = 200;
            dtgrid_CallDetail.Columns[10].HeaderText = "Shift";

            dtgrid_CallDetail.Columns[11].Width = 200;
            dtgrid_CallDetail.Columns[11].HeaderText = "Transfer Reason";
           
            dtgrid_CallDetail.Columns[12].Width = 200;
            dtgrid_CallDetail.Columns[12].HeaderText = "Test Call";

            dtgrid_CallDetail.Columns[13].Width = 200;
            dtgrid_CallDetail.Columns[13].HeaderText = "Blank Call";


            dtgrid_CallDetail.Columns[14].Width = 200;
            dtgrid_CallDetail.Columns[14].HeaderText = "Wrong Number";

            dtgrid_CallDetail.Columns[15].Width = 200;
            dtgrid_CallDetail.Columns[15].HeaderText = "Prank Call";

            dtgrid_CallDetail.Columns[16].Width = 200;
            dtgrid_CallDetail.Columns[16].HeaderText = "Inquiry";

            dtgrid_CallDetail.Columns[17].Width = 200;
            dtgrid_CallDetail.Columns[17].HeaderText = "Complaint";

            dtgrid_CallDetail.Columns[18].Width = 200;
            dtgrid_CallDetail.Columns[18].HeaderText = "Follow-Up Complaint";

            //dtgrid_CallDetail.Columns[19].Width = 200;
            //dtgrid_CallDetail.Columns[19].HeaderText = "Prospect Customer";

            dtgrid_CallDetail.Columns[19].Visible = false;

            dtgrid_CallDetail.Columns[20].Width = 200;
            dtgrid_CallDetail.Columns[20].HeaderText = "Others";

            dtgrid_CallDetail.Columns[21].Width = 200;
            dtgrid_CallDetail.Columns[21].HeaderText = "Reference No";

            dtgrid_CallDetail.Columns[22].Width = 200;
            dtgrid_CallDetail.Columns[22].HeaderText = "Host Address";

            dtgrid_CallDetail.Columns[23].Width = 200;
            dtgrid_CallDetail.Columns[23].HeaderText = "Hostname";

            dtgrid_CallDetail.Columns[24].Width = 200;
            dtgrid_CallDetail.Columns[24].HeaderText = "Extension";

            dtgrid_CallDetail.Columns[25].Width = 200;
            dtgrid_CallDetail.Columns[25].HeaderText = "Duration";

            dtgrid_CallDetail.Columns[26].Width = 200;
            dtgrid_CallDetail.Columns[26].HeaderText = "Abandon";

            dtgrid_CallDetail.Columns[27].Width = 200;
            dtgrid_CallDetail.Columns[27].HeaderText = "Speed Of Answer";

            dtgrid_CallDetail.Columns[28].Width = 200;
            dtgrid_CallDetail.Columns[28].HeaderText = "After Call Work";

            dtgrid_CallDetail.Columns[29].Width = 200;
            dtgrid_CallDetail.Columns[29].HeaderText = "Caller Number";

            dtgrid_CallDetail.Columns[30].Width = 200;
            dtgrid_CallDetail.Columns[30].HeaderText = "Note";       

            dtgrid_CallDetail.Columns[31].Width = 200;
            dtgrid_CallDetail.Columns[31].HeaderText = "Voice File";
                 
            dtgrid_CallDetail.Columns[32].Visible = false;
            dtgrid_CallDetail.Columns[33].Visible = false;
            dtgrid_CallDetail.Columns[34].Visible = false;
            dtgrid_CallDetail.Columns[35].Visible = false;
            dtgrid_CallDetail.Columns[36].Visible = false;
            dtgrid_CallDetail.Columns[37].Visible = false;
            dtgrid_CallDetail.Columns[38].Visible = false;
            dtgrid_CallDetail.Columns[39].Visible = false;
            dtgrid_CallDetail.Columns[40].Visible = false;
            dtgrid_CallDetail.Columns[41].Visible = false;

            
            dtgrid_CallDetail.Columns[42].Visible = false;
            dtgrid_CallDetail.Columns[43].Visible = false;
            dtgrid_CallDetail.Columns[44].Visible = false;
            dtgrid_CallDetail.Columns[45].Visible = false;
            dtgrid_CallDetail.Columns[46].Visible = false;
            dtgrid_CallDetail.Columns[47].Visible = false;
            dtgrid_CallDetail.Columns[48].Visible = false;
            dtgrid_CallDetail.Columns[49].Visible = false;
            dtgrid_CallDetail.Columns[50].Visible = false;
            dtgrid_CallDetail.Columns[51].Visible = false;
            dtgrid_CallDetail.Columns[52].Visible = false;
            dtgrid_CallDetail.Columns[53].Visible = false;
            dtgrid_CallDetail.Columns[54].Visible = false;
            dtgrid_CallDetail.Columns[55].Visible = false;
            dtgrid_CallDetail.Columns[56].Visible = false;
            dtgrid_CallDetail.Columns[57].Visible = false;
            dtgrid_CallDetail.Columns[58].Visible = false;
            dtgrid_CallDetail.Columns[59].Visible = false;

        }
        #endregion

        #region LoadData
        void LoadDataCall()
        {
            this.dtgrid_CallDetail.DataSource = callDao.GetAll();
            ChangeColumnHeader();
            Global.ChangeHeaderGrid(dtgrid_CallDetail);
            this.txt_jml_row.Text = callDao.myPaging.AbsolutePage.ToString() + "/" + callDao.myPaging.JumlahPage.ToString();
            this.lbl_rows.Text ="Total data : " + callDao.myPaging.JumlahData.ToString();

            if (callDao.myPaging.JumlahData == 0) { this.lblNoData.Visible = true; } else { this.lblNoData.Visible = false; }
        }
        void LoadUserName()
        {
            //this.cmb_CallDetail_Username.DataSource = new Dao.UserDao().GetAllUserName();
            //this.cmb_CallDetail_Username.DisplayMember = "username";
            //this.cmb_CallDetail_Username.ValueMember = "id";
        }
        #endregion
        public CallCenter(Main mainForm)
        {
            InitializeComponent();
            mymain = mainForm;
        }
        public CallCenter()
        {
            callDao.myPaging.SqlLoaddata = callDao.SqlSelect();
            callDao.myPaging.SqlCountData = callDao.SqlSelectCount();
            InitializeComponent();
           
        }
        private void btn_search_call_detail_Click(object sender, EventArgs e)
        {
           
        }

        private void CallCenter_Load(object sender, EventArgs e)
        {
            LoadDataCall();
            LoadUserName();

        }

        private void btn_fisrt_Click(object sender, EventArgs e)
        {
            callDao.myPaging.FirstPage();
            LoadDataCall();
        }

        private void btn_previous_Click(object sender, EventArgs e)
        {
            callDao.myPaging.PreviousPage();
            LoadDataCall();
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            callDao.myPaging.NextPage();
            LoadDataCall();
        }

        private void btn_last_Click(object sender, EventArgs e)
        {
            callDao.myPaging.LastPage();
            LoadDataCall();
        }

        private void CallCenter_Resize(object sender, EventArgs e)
        {
            lblNoData.Left = (this.dtgrid_CallDetail.Width - lblNoData.Width) / 2;
            lblNoData.Top = (this.dtgrid_CallDetail.Height - lblNoData.Height) / 2;
        }

        private void btn_next_Click_1(object sender, EventArgs e)
        {
            callDao.myPaging.NextPage();
            LoadDataCall();
        }

        private void btn_last_Click_1(object sender, EventArgs e)
        {
            callDao.myPaging.LastPage();
            LoadDataCall();
        }

        private void btn_previous_Click_1(object sender, EventArgs e)
        {
            callDao.myPaging.PreviousPage();
            LoadDataCall();
        }

        private void btn_fisrt_Click_1(object sender, EventArgs e)
        {
            callDao.myPaging.FirstPage();
            LoadDataCall();
        }

        private void dtgrid_CallDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            

            if (Global.callState == Global.CallState.INCALL || Global.callState == Global.CallState.OUTCALL)
                return;

            if (dtgrid_CallDetail.CurrentRow.Cells["directionName"].Value.ToString() == "Outbound")
            {
                if (Global.mainForm.outboundCallForm == null)
                {
                    Global.mainForm.outboundCallForm = new View.OutboundCall(callDao.GetById(dtgrid_CallDetail.CurrentRow.Cells["id"].Value.ToString()));
                    Global.mainForm.outboundCallForm.ShowDialog();
                }
            }
            else if (dtgrid_CallDetail.CurrentRow.Cells["inboundStatusName"].Value.ToString() == "Answered")
            {
                InboundCall inboundCall = new InboundCall(true, new Dao.CallDao().GetById(this.dtgrid_CallDetail.SelectedCells[0].Value.ToString()));
                inboundCall.valueButtonTicket = string.IsNullOrEmpty(this.dtgrid_CallDetail.SelectedCells[2].Value.ToString());
                inboundCall.callCenterForm = this;
                inboundCall.fromRinging = false;
                inboundCall.ShowDialog();
            }
        }

        private void cmbCallStatus_Click(object sender, EventArgs e)
        {
            
        }

        private void cmbUsername_Click(object sender, EventArgs e)
        {
            this.cmbUsername.DataSource = new Dao.UserDao().GetAllUserName();
            this.cmbUsername.DisplayMember = "username";
            this.cmbUsername.ValueMember = "id";
        }

        private void cmbDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbDirection.Text != "")
            {
                this.chkDirection.Checked = true;
                this.chkDirection.Enabled = true;
                this.chkCallType.Checked = false;
                this.chkCallStatus.Checked = false;
                if (this.cmbDirection.Text == "INBOUND")
                {
                    //this.cmbCallType.Items.Clear();
                    //this.cmbCallType.Items.AddRange(new string[] { "INQUIRY", "COMPLAINT", "PROSPECT CUSTOMER", "REQUEST", "BLANK CALL","WRONG NUMBER","TEST CALL" });

                    this.cmbCallType.DataSource = new Dao.InboundTypeDao().GetAllWithBlankId();
                    this.cmbCallType.DisplayMember = "type";
                    this.cmbCallType.ValueMember = "id";

                    this.cmbCallerType.DataSource = new Dao.CallerTypeDao().GetListCallerTypeWithIdBlank("1");
                    this.cmbCallerType.DisplayMember = "type";
                    this.cmbCallerType.ValueMember = "id";

                    

                    //this.cmbCallerType.Items.Clear();
                    //this.cmbCallerType.Items.AddRange(new string[] { "Customer - Pospaid", "Customer - Prepaid", "Customer - Corporate", "Customer - VIP Group", "Customer - VIP Perorangan", "Others", "Dealer" });

                    this.cmbCallStatus.Items.Clear();
                    this.cmbCallStatus.Items.AddRange(new string[] { "ANSWERED", "PHANTOM", "ABANDON" });

                }
                else if (this.cmbDirection.Text == "OUTBOUND")
                {
                    this.cmbCallType.DataSource = null;
                   // this.cmbCallType.Items.AddRange(new string[] { "BUSSYLINE", "NOT ACTIVE", "INVALID NUMBER", "VOICE MAILBOX", "NO ANSWER" });

                    //this.cmbCallerType.Items.Clear();
                    //this.cmbCallerType.Items.AddRange(new string[] { "Customer","Others", "Dealer","Cabang" });

                    this.cmbCallerType.DataSource = new Dao.CallerTypeDao().GetListCallerTypeWithIdBlank("2");
                    this.cmbCallerType.DisplayMember = "type";
                    this.cmbCallerType.ValueMember = "id";

                    this.cmbCallStatus.Items.Clear();
                    this.cmbCallStatus.Items.AddRange(new string[] { "CONNECT", "UNCONNECT", "CONTACT", "UNCONTACT" });
                }
                //else { this.cmbCallerType.Items.Clear(); this.cmbCallType.Items.Clear(); this.cmbCallStatus.Items.Clear(); }
               
            }
            else
            {
                this.cmbCallerTypeDetail.SelectedIndex = 0;
                this.cmbCallerType.SelectedIndex = 0;
                this.cmbCallerType.DataSource = null;
                this.cmbCallerTypeDetail.DataSource = null;
                this.cmbCallType.DataSource = null;
                this.cmbCallStatus.Items.Clear();

                this.chkDirection.Checked = false;
                this.chkDirection.Enabled = false;
            }
        }

        private void cmbCallType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbCallType.Text != "")
            {
                this.chkCallType.Checked = true;
                this.chkCallType.Enabled = true;
            }
            else
            {
                this.chkCallType.Checked = false;
                this.chkCallType.Enabled = false;
            }
        }

        private void cmbCallStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (this.cmbCallStatus.Text != "")
            {
                this.chkCallStatus.Checked = true;
                this.chkCallStatus.Enabled = true;
            }
            else
            {
                this.chkCallStatus.Checked = false;
                this.chkCallStatus.Enabled = false;
            }
        }

        private void cmbUsername_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbUsername.Text != "")
            {
                this.chkUsername.Checked = true;
                this.chkUsername.Enabled = true;
            }
            else
            {
                this.chkUsername.Checked = false;
                this.chkUsername.Enabled = false;
            }
        }

        private void chkDirection_ChangeUICues(object sender, UICuesEventArgs e)
        {

        }

        private void chkDirection_Click(object sender, EventArgs e)
        {
            this.cmbDirection.SelectedIndex = -1;
        }

        private void chkCallType_Click(object sender, EventArgs e)
        {
            this.cmbCallType.SelectedIndex = -1;
        }

        private void chkCallStatus_Click(object sender, EventArgs e)
        {
            this.cmbCallStatus.SelectedIndex = -1;
        }

        private void chkUsername_Click(object sender, EventArgs e)
        {
            this.cmbUsername.SelectedIndex = -1;
        }

        private void chkPhoneNo_Click(object sender, EventArgs e)
        {
            this.txtPhoneNo.Clear();
        }

        private void txtPhoneNo_TextChanged(object sender, EventArgs e)
        {
            if (this.txtPhoneNo.TextLength > 0)
            {
                this.chkPhoneNo.Enabled = true;
                this.chkPhoneNo.Checked = true;
            }
            else
            {
                this.chkPhoneNo.Enabled = false;
                this.chkPhoneNo.Checked = false;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            callDao.myPaging.SqlLoaddata = callDao.SqlSelect();
            callDao.myPaging.SqlCountData = callDao.SqlSelectCount();
            LoadDataCall();

            this.chkCallStatus.Checked = false;
            this.chkDirection.Checked = false;
            this.chkPhoneNo.Checked = false;
            this.chkUsername.Checked = false;
            this.chkCallType.Checked = false;

            this.cmbCallStatus.SelectedIndex = -1;
            this.cmbCallType.SelectedIndex = -1;
            this.cmbDirection.SelectedIndex = -1;
            this.cmbUsername.SelectedIndex = -1;
            this.txtPhoneNo.Clear();
            this.txtCustomerName.Clear();
            this.txtSerialNo.Clear();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            callDao.myPaging.SqlLoaddata = callDao.SqlFilter(
                this.dtFrom.Value.ToString("yyyy-MM-dd"),
                this.dtUntil.Value.ToString("yyyy-MM-dd"),
                this.cmbDirection.Text==""?"":(this.cmbDirection.SelectedIndex+1).ToString(),
                this.cmbCallType.Text,
                this.cmbCallerType.Text,
                   //this.cmbCallerTypeDetail.Text,
                this.cmbCallStatus.Text,
                this.cmbUsername.Text,
                this.txtPhoneNo.Text,
                this.txtCustomerName.Text,
                this.txtSerialNo.Text
                );
            
            callDao.myPaging.SqlCountData = callDao.SqlFilterCount(
                this.dtFrom.Value.ToString("yyyy-MM-dd"),
                this.dtUntil.Value.ToString("yyyy-MM-dd"),
                this.cmbDirection.Text == "" ? "" : (this.cmbDirection.SelectedIndex + 1).ToString(),
                this.cmbCallType.Text,
                  this.cmbCallerType.Text,
                  //this.cmbCallerTypeDetail.Text,
                this.cmbCallStatus.Text,
                this.cmbUsername.Text,
                this.txtPhoneNo.Text,
                 this.txtCustomerName.Text,
                this.txtSerialNo.Text
                );
            LoadDataCall();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            this.cmbCallerType.SelectedIndex = 0;
        }

        private void cmbCallerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbCallerType.Text != "")
            {
                this.chkCallerType.Checked = true;
                this.chkCallerType.Enabled = true;
            }
            else
            {
                this.chkCallerType.Checked = false;
                this.chkCallerType.Enabled = false;
            }
            try
            {
                this.cmbCallerTypeDetail.DataSource = new Dao.CallerTypeDetailDao().GetAllByCallerTypeWithBlankId(this.cmbCallerType.SelectedValue.ToString());
                this.cmbCallerTypeDetail.DisplayMember = "name";
                this.cmbCallerTypeDetail.ValueMember = "id";
            }
            catch { }
        }

        private void dtgrid_CallDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void chkCallerTypeDetail_Click(object sender, EventArgs e)
        {
            this.cmbCallerTypeDetail.SelectedIndex = -1;
        }

        private void cmbCallerTypeDetail_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbCallerTypeDetail.Text != "")
            {
                this.chkCallerTypeDetail.Checked = true;
                this.chkCallerTypeDetail.Enabled = true;
            }
            else
            {
                this.chkCallerTypeDetail.Checked = false;
                this.chkCallerTypeDetail.Enabled = false;
            }
        }

        private void chkCustomerName_Click(object sender, EventArgs e)
        {
            this.txtCustomerName.Clear();
        }

        private void chkSerialNo_Click(object sender, EventArgs e)
        {
            this.txtSerialNo.Clear();
        }

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {
            if (this.txtCustomerName.TextLength > 0)
            {
                this.chkCustomerName.Enabled = true;
                this.chkCustomerName.Checked = true;
            }
            else
            {
                this.chkCustomerName.Enabled = false;
                this.chkCustomerName.Checked = false;
            }
        }

        private void txtSerialNo_TextChanged(object sender, EventArgs e)
        {
            if (this.txtSerialNo.TextLength > 0)
            {
                this.chkSerialNo.Enabled = true;
                this.chkSerialNo.Checked = true;
            }
            else
            {
                this.chkSerialNo.Enabled = false;
                this.chkSerialNo.Checked = false;
            }
        }

       
    }
}
