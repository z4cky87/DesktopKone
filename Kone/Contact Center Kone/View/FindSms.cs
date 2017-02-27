using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Contact_Center_Kone.Dao;
using Contact_Center_Kone.Entity;
using Contact_Center_Kone.Utility;


namespace Contact_Center_Kone.View
{
    public partial class FindSms : Form
    {
        LogSmsDao logsmsdao = new LogSmsDao();
        DirectionDao directiondao = new DirectionDao();
        SmsStatusDao smsStatusDao = new SmsStatusDao();

        public FindSms()
        {
            InitializeComponent();
        }
        void ChangeHederColumn()
        { 
            this.dtgrid_logsms.Columns["sms_id"].Visible = false; 
            this.dtgrid_logsms.Columns["user_id"].Visible = false; 
            this.dtgrid_logsms.Columns["sms_status_id"].Visible = false; 
            this.dtgrid_logsms.Columns["direction_id"].Visible = false; 
            this.dtgrid_logsms.Columns["ticket_id"].Visible = false;
            this.dtgrid_logsms.Columns["sms_read"].Visible = false;
            this.dtgrid_logsms.Columns["category_id"].Visible = false;

            this.dtgrid_logsms.Columns["sms_date"].HeaderText = "Sms Date";
            this.dtgrid_logsms.Columns["sms_date"].Width = 90;

            this.dtgrid_logsms.Columns["sms_time"].HeaderText = "Sms Time";
            this.dtgrid_logsms.Columns["sms_time"].Width = 90;  

            this.dtgrid_logsms.Columns["sms_from"].HeaderText = "Sms From";
            this.dtgrid_logsms.Columns["sms_from"].Width = 90;

            this.dtgrid_logsms.Columns["sms_to"].HeaderText = "Sms To";
            this.dtgrid_logsms.Columns["sms_to"].Width = 90;

            this.dtgrid_logsms.Columns["sms_text"].HeaderText = "Sms Text";
            this.dtgrid_logsms.Columns["sms_text"].Width = 200;

            this.dtgrid_logsms.Columns["username_agent"].HeaderText = "Username";
            this.dtgrid_logsms.Columns["username_agent"].Width = 150;

            this.dtgrid_logsms.Columns["sms_status"].HeaderText = "Sms Status";
            this.dtgrid_logsms.Columns["sms_status"].Width = 90;

            this.dtgrid_logsms.Columns["sms_direction"].HeaderText = "Direction";
            this.dtgrid_logsms.Columns["sms_direction"].Width = 90;

            this.dtgrid_logsms.Columns["ticketno"].HeaderText = "Ticket No";
            this.dtgrid_logsms.Columns["ticketno"].Width = 200;

            this.dtgrid_logsms.Columns["category_name"].HeaderText = "Category";
            this.dtgrid_logsms.Columns["category_name"].Width = 200;  

        }

        public void SearchList()
        {
            btn_search.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;

            string _datefrom = dte_from.Value.ToString("yyyy-MM-dd");
            string _dateuntil = dte_until.Value.ToString("yyyy-MM-dd");
            int directionid = Convert.ToInt32(cmb_direction.SelectedValue);
            int statusid = Convert.ToInt32(cmb_status.SelectedValue);
            this.dtgrid_logsms.DataSource = logsmsdao.GetAllSms(_datefrom, _dateuntil, directionid, statusid, txt_smsfrom.Text);
            lbl_CountGrid.Text = this.dtgrid_logsms.Rows.Count.ToString() + " List";
            Global.ChangeColorGrid(dtgrid_logsms);
            Global.ChangeHeaderGrid(dtgrid_logsms);
            //if (dtgrid_findemail.Rows.Count > 0)
            ChangeHederColumn();


            btn_search.Enabled = true;
            Cursor.Current = Cursors.Default;
        }
        private void btn_search_Click(object sender, EventArgs e)
        {
            SearchList();
        }

        private void dtgrid_logsms_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        { 
            int smsid = Convert.ToInt32(dtgrid_logsms.SelectedCells[0].Value);

            View.Sms sms = new Sms(smsid);
            sms.findsms = this;
            sms.enumstatus = Sms.SmsStatusFrom.View;
            sms.ShowDialog();
        }

        private void btn_new_sms_Click(object sender, EventArgs e)
        {
            View.Sms email = new Sms();
            email.enumstatus = Sms.SmsStatusFrom.Create;
            email.ShowDialog();
        }
        void LoadDirection()
        {
            this.cmb_direction.DataSource = directiondao.GetListDirection();
            this.cmb_direction.DisplayMember = "direction";
            this.cmb_direction.ValueMember = "id";
        }

        void LoadStatus()
        {
            this.cmb_status.DataSource = smsStatusDao.GetListSmsStatus();
            this.cmb_status.DisplayMember = "sms_status";
            this.cmb_status.ValueMember = "sms_status_id";
        }

        private void FindSms_Load(object sender, EventArgs e)
        {
            LoadDirection();
            LoadStatus();
        }
    }
}
