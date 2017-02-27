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
    public partial class FindVoiceMail : Form
    {
        LogVoiceMailDao logvoicemaildao = new LogVoiceMailDao();
        LogVoiceMail logvoicemail = new LogVoiceMail();


        public FindVoiceMail()
        {
            InitializeComponent();
        }
        void ChangeHederColumn()
        {
            this.dtgrid_logvoicemail.Columns[0].HeaderText = "VoiceMail Id";
            this.dtgrid_logvoicemail.Columns[0].Visible = false;

            this.dtgrid_logvoicemail.Columns[1].HeaderText = "DateTime";
            this.dtgrid_logvoicemail.Columns[1].Width = 150;

            this.dtgrid_logvoicemail.Columns[2].HeaderText = "Unique ID";
            this.dtgrid_logvoicemail.Columns[2].Width = 150;

            this.dtgrid_logvoicemail.Columns[3].HeaderText = "Full Path";
            this.dtgrid_logvoicemail.Columns[3].Width = 250;

            this.dtgrid_logvoicemail.Columns[4].HeaderText = "Phone Number";
            this.dtgrid_logvoicemail.Columns[4].Width = 150;

            this.dtgrid_logvoicemail.Columns[5].HeaderText = "VoiceMail Read";
            this.dtgrid_logvoicemail.Columns[5].Width = 150;
            this.dtgrid_logvoicemail.Columns[5].Visible = false;

            this.dtgrid_logvoicemail.Columns[6].HeaderText = "VoiceMail Read";
            this.dtgrid_logvoicemail.Columns[6].Width = 150;

            this.dtgrid_logvoicemail.Columns[7].HeaderText = "Read By";
            this.dtgrid_logvoicemail.Columns[7].Width = 150;

            this.dtgrid_logvoicemail.Columns[8].HeaderText = "Ticket No";
            this.dtgrid_logvoicemail.Columns[8].Width = 200;  
        }

        public void SearchList()
        {
            btn_search.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;

            string _datefrom = dte_from.Value.ToString("yyyy-MM-dd");
            string _dateuntil = dte_until.Value.ToString("yyyy-MM-dd");

            this.dtgrid_logvoicemail.DataSource = logvoicemaildao.GetVoiceMail(_datefrom, _dateuntil);
            lbl_row.Text = this.dtgrid_logvoicemail.Rows.Count.ToString() + " List";
            Global.ChangeColorGrid(dtgrid_logvoicemail);
            Global.ChangeHeaderGrid(dtgrid_logvoicemail);
            //if (dtgrid_findemail.Rows.Count > 0)
            ChangeHederColumn();
            btn_search.Enabled = true;
            Cursor.Current = Cursors.Default;
        }
        private void btn_search_Click(object sender, EventArgs e)
        {
            SearchList();
        }

        private void dtgrid_logvoicemail_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    // Add this
                    dtgrid_logvoicemail.CurrentCell = dtgrid_logvoicemail.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    // Can leave these here - doesn't hurt
                    dtgrid_logvoicemail.Rows[e.RowIndex].Selected = true;
                    dtgrid_logvoicemail.Focus();
                }
            }
            catch (Exception Ex)
            {
                Global.WriteLog(Global.GetCurrentMethod(Ex));
            }
        }

        private void listenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int voicemail_id = Convert.ToInt32(dtgrid_logvoicemail.SelectedCells[0].Value);
            View.MediaPlayer mediaplayer = new MediaPlayer(voicemail_id);
            mediaplayer.findvoicemail = this;
            mediaplayer.enumstatus = MediaPlayer.VoiceMailStatusFrom.View;
            mediaplayer.ShowDialog();
        }

        private void dtgrid_logvoicemail_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }
    }
}
