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
    public partial class FindTicket : Form
    {
        ListTicketDao listticketdao = new ListTicketDao();
        List<ListTicket> listticket;
        public View.Sms smsform;
        internal View.Email emailform;
        public View.MediaPlayer mediaplayer;
        public View.InboundCall inboundform;
        public View.OutboundCall outboundform; 
        public TagTicketSourceMedia enumtagticket;

        private int media_id = 0;
        private int source_media_id = 0;

        public FindTicket(int mediaid = 0, int sourceMediaId = 0)
        {
            InitializeComponent();
            media_id = mediaid;
            source_media_id = sourceMediaId;
        }

        public enum TagTicketSourceMedia
        {
            Email = 1,
            Sms = 2,
            VoiceMail = 3,
            CallInbound = 4,
            CallOutbound = 5
        }
        void ChangeHederColumn()
        {
            ////Grid Tagging
            this.dtgrid_find_ticket.Columns["id"].Visible = false;
            this.dtgrid_find_ticket.Columns["product_type_id"].Visible = false;
            this.dtgrid_find_ticket.Columns["model_id"].Visible = false;

            this.dtgrid_find_ticket.Columns["created_date"].HeaderText = "Ticket Create";
            this.dtgrid_find_ticket.Columns["created_date"].Width = 120;

            this.dtgrid_find_ticket.Columns["ticketno"].HeaderText = "Ticket No";
            this.dtgrid_find_ticket.Columns["ticketno"].Width = 90;

            this.dtgrid_find_ticket.Columns["product_type"].HeaderText = "Product Type";
            this.dtgrid_find_ticket.Columns["product_type"].Width = 120;

            this.dtgrid_find_ticket.Columns["model"].HeaderText = "Model";
            this.dtgrid_find_ticket.Columns["model"].Width = 90;

            this.dtgrid_find_ticket.Columns["serial_no"].HeaderText = "Serial Number";
            this.dtgrid_find_ticket.Columns["serial_no"].Width = 120;


        }

        void ChangeHeaderListTagg()
        {

            ////Grid Tagging
            this.dtgrid_list_tagging.Columns["id"].Visible = false;
            this.dtgrid_list_tagging.Columns["product_type_id"].Visible = false;
            this.dtgrid_list_tagging.Columns["model_id"].Visible = false;
            this.dtgrid_list_tagging.Columns["model_id"].Visible = false;

            this.dtgrid_list_tagging.Columns["created_date"].HeaderText = "Ticket Create";
            this.dtgrid_list_tagging.Columns["created_date"].Width = 120;

            this.dtgrid_list_tagging.Columns["ticketno"].HeaderText = "Ticket No";
            this.dtgrid_list_tagging.Columns["ticketno"].Width = 90;

            this.dtgrid_list_tagging.Columns["product_type"].HeaderText = "Product Type";
            this.dtgrid_list_tagging.Columns["product_type"].Width = 120;

            this.dtgrid_list_tagging.Columns["model"].HeaderText = "Model";
            this.dtgrid_list_tagging.Columns["model"].Width = 90;

            this.dtgrid_list_tagging.Columns["serial_no"].HeaderText = "Serial Number";
            this.dtgrid_list_tagging.Columns["serial_no"].Width = 120;
        }

        void load_gridTicket()
        {
            Cursor.Current = Cursors.WaitCursor;

            string _datefrom = dte_from.Value.ToString("yyyy-MM-dd");
            string _dateuntil = dte_until.Value.ToString("yyyy-MM-dd");
            string textno = txt_ticketno.Text;

            this.dtgrid_find_ticket.DataSource = listticketdao.getListTicket(_datefrom, _dateuntil, textno);
            lbl_CountGrid.Text = this.dtgrid_find_ticket.Rows.Count.ToString() + " List";

            Global.ChangeColorGrid(dtgrid_find_ticket);
            Global.ChangeHeaderGrid(dtgrid_find_ticket);
            //if (dtgrid_findemail.Rows.Count > 0)

            ChangeHederColumn();

            dtgrid_find_ticket.ClearSelection();
            Cursor.Current = Cursors.Default;
        }

        void load_gridTagging()
        {
            Cursor.Current = Cursors.WaitCursor;

            string _datefrom = dte_from.Value.ToString("yyyy-MM-dd");
            string _dateuntil = dte_until.Value.ToString("yyyy-MM-dd");
            string textno = txt_ticketno.Text;
              
            this.dtgrid_list_tagging.DataSource = listticketdao.getListTicket(media_id,source_media_id);

            Global.ChangeColorGrid(dtgrid_list_tagging);
            Global.ChangeHeaderGrid(dtgrid_list_tagging);
            //if (dtgrid_findemail.Rows.Count > 0)
            ChangeHeaderListTagg();

            dtgrid_list_tagging.ClearSelection();
            Cursor.Current = Cursors.Default;
        }

        private void FindTicket_Load(object sender, EventArgs e)
        {
            load_gridTicket();
            load_gridTagging();
        }

        private void btn_search_Click(object sender, EventArgs e)
        { 
            btn_search.Enabled = false;
            load_gridTicket(); 
            btn_search.Enabled = true;  
        }

        private void btn_tagging_Click(object sender, EventArgs e)
        {
          if (dtgrid_find_ticket.SelectedRows.Count > 0)
          {
              int ticketid;
              string ticketno;
              TagTicket tagticeket = null;
              for (int i = 0; i < dtgrid_find_ticket.SelectedRows.Count; i++)
              {
                  ticketid = Convert.ToInt32(dtgrid_find_ticket.SelectedRows[i].Cells["id"].Value);
                  ticketno = (dtgrid_find_ticket.SelectedRows[i].Cells["ticketno"].Value).ToString(); 
                  tagticeket = new TagTicket();
                  tagticeket.media_id = media_id;
                  tagticeket.ticket_id = ticketid;
                  tagticeket.source_media_id = GetEnum_ByOpen();

                  if (!listticketdao.CheckTagTicketExist(tagticeket.media_id, tagticeket.source_media_id, ticketid))
                  {
                      if (listticketdao.InsertTagTicket(tagticeket)){
                          MessageBox.Show("Tagging Succes Ticket No : " + ticketno);
                          load_gridTagging();
                      }
                      else
                          MessageBox.Show("Tagging Failed Ticket No " + ticketno);
                  }
                  else
                  {
                      MessageBox.Show("Tagging AllReady Ticket No " + ticketno);
                  }

                
              }
              GetTicketNo(tagticeket);
          }
          else
          {
              MessageBox.Show("Please Selected","Select",MessageBoxButtons.OK,MessageBoxIcon.Information);
          }
        }

        private void GetTicketNo(TagTicket tagticket)
        {
            string ticketnotag = listticketdao.GetTicketNo_ByMediaId_SourceMediaId(tagticket.media_id, tagticket.source_media_id);
            Console.WriteLine("Nomer Ticket Tag" + ticketnotag);
            switch (tagticket.source_media_id)
            {
                case 1:
                    emailform.GetTagNoTicket(ticketnotag);
                    break;
                case 2:
                    smsform.GetTagNoTicket(ticketnotag);
                    break;
                case 3:
                    mediaplayer.GetTagNoTicket(ticketnotag);
                    break;
                case 4:
                    break;
                case 5:
                    break;
                default:
                    break;
            }
        }
         
        public int GetEnum_ByOpen()
        {
            int RetVal = 0;

            switch (enumtagticket)
            {
                case TagTicketSourceMedia.Email:
                    RetVal = (int)TagTicketSourceMedia.Email;
                    break;
                case TagTicketSourceMedia.Sms:
                    RetVal = (int)TagTicketSourceMedia.Sms;
                    break;
                case TagTicketSourceMedia.VoiceMail:
                    RetVal = (int)TagTicketSourceMedia.VoiceMail;
                    break;
                case TagTicketSourceMedia.CallInbound:
                    RetVal = (int)TagTicketSourceMedia.CallInbound;
                    break;
                case TagTicketSourceMedia.CallOutbound:
                    RetVal = (int)TagTicketSourceMedia.CallOutbound;
                    break; 
            }

            return RetVal;
        }


    }
}
