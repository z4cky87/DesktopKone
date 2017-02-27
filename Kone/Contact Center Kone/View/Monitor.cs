using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Contact_Center_Kone.Utility;

namespace Contact_Center_Kone.View
{
    public partial class Monitor : Form
    {
        Dao.UserDao daoUsers = new Dao.UserDao();
        Dao.MonitorDao monitordao = new Dao.MonitorDao();
        
        StatusCall statusCall = new StatusCall();
        ActivityCall activityCall = new ActivityCall();
        public MonitoringOpenBy monitoringOpenBy = new MonitoringOpenBy();
        public View.Main mainform;
        //public View.InboundCall inbouncall;
        private bool _statusOpenInbound = false;

        Entity.Monitoring entityUser = null;        
        Thread getdatetimeThread = null;

        static int rowindex = 0;
        int _callid = 0;


        public Monitor(bool _status, int callid = 0)
        {
            InitializeComponent();
            statusCall = StatusCall.NotActive;
            _statusOpenInbound = _status;
            _callid = callid;
        }

        enum StatusCall
        {
            NotActive,
            ActiveListen,
            ActiveWhisper,
            ActiveCall,
            ActiveBlindCall
        }

        enum ActivityCall
        {
            Ready = 2,
            Online = 4
        }

        public enum MonitoringOpenBy
        {
            InboundCall,
            FreeOpen
        }

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

        #region Delegate

        delegate void setGridDtDelegate(DataGridView dtgrid, DataTable dt, int indexrow);
        private void setGridDt(DataGridView dtgrid, DataTable dt, int indexrow)
        {
            if (dtgrid.InvokeRequired)
            {
                setGridDtDelegate d = new setGridDtDelegate(setGridDt);
                this.Invoke(d, new Object[] { dtgrid, dt, indexrow });
            }
            else
            {

                dtgrid.ClearSelection();
                dtgrid.DataSource = dt;
                dtgrid.Columns[0].Visible = false;
                dtgrid.Columns[1].Width = 100;
                dtgrid.Columns[2].Width = 100;
                dtgrid.EnableHeadersVisualStyles = false;
                dtgrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                dtgrid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 224, 192);
                dtgrid.RowHeadersDefaultCellStyle.BackColor = Color.Blue;
                dtgrid.ColumnHeadersHeight = 100;

                if ((dtgrid.Rows.Count) - 1 >= indexrow)
                {
                    dtgrid.Rows[indexrow].Selected = true;
                }
                //
            }
        }

        #endregion

        private void clearText()
        {
            txt_user.Clear();
            txt_exten.Clear();
        }

        private void GetUser()
        {
            while (true)
            {
                DataTable dt = new DataTable();
                dt = daoUsers.getUser((int)activityCall,_statusOpenInbound);
                if (dt.Rows.Count > 0)
                {
                    setGridDt(dtGridUser, dt, rowindex);
                }
                Thread.Sleep(1000);
            } 
        }

        private void Monitor_Load(object sender, EventArgs e)
        {
            if (monitoringOpenBy == MonitoringOpenBy.FreeOpen)
            {
                gb_Whisper.Enabled = true;
                gb_Transfer.Enabled = false;
                rbWhisper.Checked = true;
                rbTransfer.Checked = false;
                rbTransfer.Enabled = false;
                activityCall = ActivityCall.Online;
            }
            else
            {
                gb_Whisper.Enabled = false;
                gb_Transfer.Enabled = true;
                rbWhisper.Checked = false;
                rbTransfer.Checked = true;
                rbWhisper.Enabled = false;
                activityCall = ActivityCall.Ready;
            }
            clearText();
            getdatetimeThread = new Thread(new ThreadStart(GetUser));
            getdatetimeThread.Start();
        }

        private void dtGridUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (statusCall == StatusCall.NotActive)
            {
                entityUser = new Entity.Monitoring();
                foreach (DataGridViewRow row in dtGridUser.SelectedRows)
                {

                    entityUser.id = Convert.ToInt16(row.Cells[0].Value);
                    entityUser.username = row.Cells[1].Value.ToString();
                    entityUser.inb_ext = row.Cells[2].Value.ToString();
                    entityUser.activity_name = row.Cells[3].Value.ToString();
                }
                rowindex = dtGridUser.CurrentCell.RowIndex;
                txt_user.Text = entityUser.username;
                txt_exten.Text = entityUser.inb_ext;
                txtActivity.Text = entityUser.activity_name;
            }
        }

        private void rbWhisper_CheckedChanged(object sender, EventArgs e)
        {
            if (statusCall == StatusCall.NotActive)
                if (rbWhisper.Checked == true)
                {
                    gb_Whisper.Enabled = true;
                    activityCall = ActivityCall.Online;
                }
                else
                {
                    gb_Whisper.Enabled = false;
                } 
        }

        private void rbTransfer_CheckedChanged(object sender, EventArgs e)
        {
            if (statusCall == StatusCall.NotActive)
                if (rbTransfer.Checked == true)
                {
                    gb_Transfer.Enabled = true;
                    activityCall = ActivityCall.Ready;
                }
                else
                {
                    gb_Transfer.Enabled = false;
                }
            else
                MessageBox.Show("Please Not Active Activity");
        }

        private void btn_whisper_Click(object sender, EventArgs e)
        {
            if (statusCall == StatusCall.NotActive)
            {

                if (txt_user.Text != "" && txt_exten.Text != "")
                {
                    if (entityUser != null)
                        if (entityUser.id != 0)
                            if (daoUsers.checkIsUser(entityUser.id, 4))
                            {
                                //Whisperring
                                statusCall = StatusCall.ActiveWhisper;
                                btn_whisper.Text = "Stop Whisper";
                                btn_whisper.BackColor = Color.Red;
                                btn_listen.Enabled = false;
                                Global.mainForm.myTelepon.RegisterToPabx(Global.userAccount.pbx_outbound, Global.userAccount.outbound_ext, Global.userAccount.outbound_ext_pwd);
                                Global.mainForm.myTelepon.Whisper(txt_exten.Text);
                                MessageBox.Show("Whisperring");
                            }
                }
                else
                    MessageBox.Show("Selected User For Whisper Or Username And Extension Not Empty");

            }
            else if (statusCall == StatusCall.ActiveWhisper)
            {
                statusCall = StatusCall.NotActive;
                btn_whisper.Text = "Whisper";
                btn_whisper.BackColor = Color.White;
                btn_listen.Enabled = true;

                Global.mainForm.myTelepon.HangupWhisper(txt_user.Text);

                //Stop Whispering
                MessageBox.Show("Stop Whisperring");
            }
            else
            {
                MessageBox.Show("Please Not Active Whisper Or Listening");
            }
        }

        private void btn_listen_Click(object sender, EventArgs e)
        {
            if (statusCall == StatusCall.NotActive)
            {
                if (txt_user.Text != "" && txt_exten.Text != "")
                {
                    if (entityUser != null)
                        if (entityUser.id != 0)
                            if (daoUsers.checkIsUser(entityUser.id, 4))
                            {
                                //Listening
                                statusCall = StatusCall.ActiveListen;
                                btn_listen.Text = "Stop Listening";
                                btn_listen.BackColor = Color.Red;
                                btn_whisper.Enabled = false;
                                MessageBox.Show("Listening");
                                Global.mainForm.myTelepon.RegisterToPabx(Global.userAccount.pbx_outbound, Global.userAccount.outbound_ext, Global.userAccount.outbound_ext_pwd);
                                Global.mainForm.myTelepon.Listen(txt_exten.Text);
                            }
                }
                else
                    MessageBox.Show("Selected User For Whisper Or Username And Extension Not Empty");
            }
            else if (statusCall == StatusCall.ActiveListen)
            {
                statusCall = StatusCall.NotActive;
                btn_listen.Text = "Listening";
                btn_listen.BackColor = Color.White;
                btn_whisper.Enabled = true;
                //Stop Listening
                Global.mainForm.myTelepon.HangupListen(txt_user.Text);
                MessageBox.Show("Stop Listening");
            }
            else
            {
                MessageBox.Show("Please Not Active Whisper Or Listening");
            }
        }

        private void rbBlindTransfer_CheckedChanged(object sender, EventArgs e)
        {
            if (statusCall == StatusCall.NotActive)
                if (rbBlindTransfer.Checked == true)
                {
                    btnBlindTransfer.Enabled = true;
                    btnCall.Enabled = false;
                }
                else
                {
                    btnBlindTransfer.Enabled = false;
                    btnCall.Enabled = true;
                }
            else
                MessageBox.Show("Please Not Active Activity");
        }

        private void rbTransferMakeCall_CheckedChanged(object sender, EventArgs e)
        {
            if (statusCall == StatusCall.NotActive)
            {
                if (rbTransferMakeCall.Checked == true)
                {
                    btnCall.Enabled = true;
                    btnBlindTransfer.Enabled = false;
                }
                else
                {
                    btnCall.Enabled = false;
                    btnBlindTransfer.Enabled = true;
                }
            }
            else
                MessageBox.Show("Please Not Active Activity");
        }

        private void btnBlindTransfer_Click(object sender, EventArgs e)
        {
            if (statusCall == StatusCall.NotActive)
            {
                if (txt_user.Text != "" && txt_exten.Text != "")
                {
                    TransferReason transferReason = new TransferReason(); // 2=Unconnect
                    if (transferReason.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        if (entityUser != null)
                            if (entityUser.id != 0)
                                if (daoUsers.checkIsUser(entityUser.id, 2))
                                {
                                    if (MessageBox.Show("Are You Sure For Blind Transfer To User :" + txt_user.Text, "Blind Transfer", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                    {
                                        //UnHold
                                        //Blind Transfer
                                        //Change Status Activity Detination User
                                        if (_callid > 0)
                                            monitordao.UpdateIsTransfered(_callid,transferReason._reasonId);

                                        Global.mainForm.myTelepon.UnHold();
                                        Global.mainForm.myTelepon.TransferCall(txt_exten.Text);
                                    }
                                }
                                else
                                    MessageBox.Show("Sorry, Destination User is not Ready");
                    }
                 
                }
                else
                {
                    MessageBox.Show("Selected User For Whisper");
                }
            }
        }

        private void btnCall_Click(object sender, EventArgs e)
        {
            if (statusCall == StatusCall.NotActive)
            {
                if (txt_user.Text != "" && txt_exten.Text != "")
                {
                    if (entityUser != null)
                        if (entityUser.id != 0)
                            if (daoUsers.checkIsUser(entityUser.id, 2))
                            {
                                if (MessageBox.Show("Are You Sure For Call To User :" + txt_user.Text, "Call", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    btnCall.Text = "Hangup Call";
                                    btnCall.BackColor = Color.Red;
                                    statusCall = StatusCall.ActiveCall;
                                    //Call
                                    //Change Status Activity Detination User
                                    Global.mainForm.myTelepon.MakeCall(this.txt_exten.Text); 
                                }

                            }
                            else
                                MessageBox.Show("Sorry, Destination User is not Ready");
                }
                else
                {
                    MessageBox.Show("Selected User For Whisper");
                }
            }
            else if (statusCall == StatusCall.ActiveCall)
            {
                btnCall.Text = "Call";
                btnCall.BackColor = Color.Red;
                statusCall = StatusCall.NotActive;
                //Hangup
                Global.mainForm.myTelepon.Hangup(Global.userAccount.username + " makecall" + txt_user.Text + DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss"));
            }
            else
            {
                MessageBox.Show("Please Not Active Activity");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if(statusCall != StatusCall.NotActive)
                MessageBox.Show("Please Not Active Activty");
            else
            {
                getdatetimeThread.Abort();
                this.Close();
            } 
            
        }

      
    }
}
