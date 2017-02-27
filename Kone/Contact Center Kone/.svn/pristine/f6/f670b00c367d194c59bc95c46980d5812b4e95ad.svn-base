using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Contact_Center_Kone.Dao;
using Contact_Center_Kone.Utility;
using Contact_Center_Kone.Entity;

namespace Contact_Center_Kone.View
{
    public partial class FindEmail : Form
    {

        LogMailDao logmaildao = new LogMailDao();
        DirectionDao directiondao = new DirectionDao();
        MailStatusDao mailStatusDao = new MailStatusDao();

        public FindEmail()
        {
            InitializeComponent();
        }
        void ChangeHederColumn()
        {
            try
            {
                this.dtgrid_findemail.Columns["id"].Visible = false;
                this.dtgrid_findemail.Columns["mail_status_id"].Visible = false;
                this.dtgrid_findemail.Columns["direction_id"].Visible = false;
                this.dtgrid_findemail.Columns["mail_category_id"].Visible = false;
                this.dtgrid_findemail.Columns["user_id"].Visible = false;
                this.dtgrid_findemail.Columns["mail_read"].Visible = false;

                this.dtgrid_findemail.Columns["mail_date"].HeaderText = "Mail Date";
                this.dtgrid_findemail.Columns["mail_date"].Width = 90; 

                this.dtgrid_findemail.Columns["mail_time"].HeaderText = "Mail Time";
                this.dtgrid_findemail.Columns["mail_time"].Width = 90;

                this.dtgrid_findemail.Columns["mail_from"].HeaderText = "Mail From";
                this.dtgrid_findemail.Columns["mail_from"].Width = 90;

                this.dtgrid_findemail.Columns["mail_to"].HeaderText = "Mail To";
                this.dtgrid_findemail.Columns["mail_to"].Width = 90;

                this.dtgrid_findemail.Columns["mail_cc"].HeaderText = "Mail Cc";
                this.dtgrid_findemail.Columns["mail_cc"].Width = 90;

                this.dtgrid_findemail.Columns["mail_bcc"].HeaderText = "Mail Bcc";
                this.dtgrid_findemail.Columns["mail_bcc"].Width = 90;

                this.dtgrid_findemail.Columns["mail_subject"].HeaderText = "Mail Subject";
                this.dtgrid_findemail.Columns["mail_subject"].Width = 90;

                this.dtgrid_findemail.Columns["mail_text"].HeaderText = "Mail text";
                this.dtgrid_findemail.Columns["mail_text"].Width = 90;

                this.dtgrid_findemail.Columns["ticket_no"].HeaderText = "Ticket No";
                this.dtgrid_findemail.Columns["ticket_no"].Width = 90;

                this.dtgrid_findemail.Columns["mail_status_name"].HeaderText = "Mail Status";
                this.dtgrid_findemail.Columns["mail_status_name"].Width = 90;

                this.dtgrid_findemail.Columns["direction_name"].HeaderText = "Direction";
                this.dtgrid_findemail.Columns["direction_name"].Width = 90;

                this.dtgrid_findemail.Columns["category_name"].HeaderText = "Category";
                this.dtgrid_findemail.Columns["category_name"].Width = 90;

                this.dtgrid_findemail.Columns["username"].HeaderText = "Username";
                this.dtgrid_findemail.Columns["username"].Width = 90;


            }
            catch (Exception ex)
            {
                Global.WriteLog(Global.GetCurrentMethod(ex));
            }
         
        }

        void LoadDirection()
        {
            this.cmb_direction.DataSource = directiondao.GetListDirection();
            this.cmb_direction.DisplayMember = "direction";
            this.cmb_direction.ValueMember = "id";
        }

        void LoadEmailStatus(int directionid = 0 )
        {
            this.cmb_status.DataSource = mailStatusDao.GetListMailStatus(directionid);
            this.cmb_status.DisplayMember = "mail_status";
            this.cmb_status.ValueMember = "id";
        }

        public void Search_list()
        {
            btn_search.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;

            string _datefrom = dte_from.Value.ToString("yyyy-MM-dd");
            string _dateuntil = dte_until.Value.ToString("yyyy-MM-dd");
            int directionid = Convert.ToInt32(cmb_direction.SelectedValue);
            int statusid = Convert.ToInt32(cmb_status.SelectedValue);
            this.dtgrid_findemail.DataSource = logmaildao.GetAll_mail(_datefrom, _dateuntil, directionid, statusid, txt_subject.Text);
            lbl_CountGrid.Text = this.dtgrid_findemail.Rows.Count.ToString() + " List";
            Global.ChangeColorGrid(dtgrid_findemail);
            Global.ChangeHeaderGrid(dtgrid_findemail);
            //if (dtgrid_findemail.Rows.Count > 0)
            ChangeHederColumn();


            btn_search.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            Search_list();
        }

        private void dtgrid_findemail_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            int log_mail_id = Convert.ToInt32(dtgrid_findemail.SelectedCells[0].Value);
            string ticketno = dtgrid_findemail.CurrentRow.Cells["ticket_no"].Value.ToString();

            View.Email email = new Email(log_mail_id, ticketno);
            email.findemail = this;
            email.enumstatus = Email.MailStatusFrom.View;
            email.ShowDialog();
        }

        private void btn_new_email_Click(object sender, EventArgs e)
        {
            View.Email email = new Email(); 
            email.enumstatus = Email.MailStatusFrom.Create;
            email.ShowDialog();
        }

        private void FindEmail_Load(object sender, EventArgs e)
        {
            LoadDirection();
            LoadEmailStatus();
            cmb_direction.SelectedValue = -2;
        }

        private void cmb_direction_SelectedValueChanged(object sender, EventArgs e)
        {
            //if (Convert.ToInt32(cmb_direction.SelectedValue) == -2)
            //    LoadEmailStatus();
            //else
            //    LoadEmailStatus((Convert.ToInt32(cmb_direction.SelectedValue)));
        }
    }
}
