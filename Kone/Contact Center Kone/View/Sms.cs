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
using System.Text.RegularExpressions;


namespace Contact_Center_Kone.View
{
    public partial class Sms : Form
    {
        private int _sms_id;
        private string outbound_number = string.Empty;
        
        private LogSms _logsms;
        private LogSms logsms;

        private SmsCategoryDao smsCategoryDao = new SmsCategoryDao();
        private LogSmsDao logsmsdao = new LogSmsDao();

        public View.FindSms findsms;
        public View.Main main_form;

        public SmsStatusFrom enumstatus;
       


        public enum SmsStatusFrom
        {
            Inbox = 1,
            Create = 2,
            View = 3
        }
        public Sms(int sms_id=0)
        {
            InitializeComponent();
            _sms_id = sms_id;
        }

        void Enable_object(bool active)
        {
            txt_from.Enabled = active;
            txt_to.Enabled = active;
            txt_text.Enabled = active;
            txt_ticket_no.Enabled = active;
            btn_send.Enabled = active;
            btn_tagticket.Enabled = active;
            btn_outbound.Enabled = active;
            btn_Reply.Enabled = active;
        }

        void ReadOnly_text(bool active)
        {
            txt_from.ReadOnly = active;
            txt_to.ReadOnly = active;
            txt_text.ReadOnly = active;
            txt_ticket_no.ReadOnly = active;
        }

        void Clear_object()
        {
            txt_from.Clear();
            txt_to.Clear();
            txt_text.Clear();
            txt_ticket_no.Clear(); 
        }

        void GetDataText()
        {
            _logsms = new LogSms();
            _logsms.user_id = Convert.ToInt32(Global.userAccount.id);
            _logsms.sms_status_id = 2;
            _logsms.direction_id = 2;
            _logsms.sms_from = txt_from.Text;
            _logsms.sms_to = txt_to.Text;
            _logsms.sms_text = txt_text.Text; 
            _logsms.sms_read = 2;
        }

        void LoadSmsCategory(string directionId)
        {
            this.cmbCategorySms.DataSource = smsCategoryDao.GetListCategory(directionId);
            this.cmbCategorySms.DisplayMember = "category";
            this.cmbCategorySms.ValueMember = "id";
        }

        public void GetTagNoTicket(string tagticket)
        {
            txt_ticket_no.Clear();
            txt_ticket_no.Text = tagticket;
        }

        private void Sms_Load(object sender, EventArgs e)
        {
            try
            {
                logsms = new LogSms();
                switch (enumstatus)
                {
                    case SmsStatusFrom.Inbox:
                        Console.WriteLine("Inbox"); 
                        logsms = logsmsdao.GetSms_bySmsRead();
                        //if (Global.userAccount.level == "2")
                            logsmsdao.UpdateSmsRead(logsms.sms_id);

                        _sms_id = logsms.sms_id;
                        txt_from.Text = logsms.sms_from;
                        txt_to.Text = logsms.sms_to;
                        txt_text.Text = logsms.sms_text;
                        btn_tagticket.Enabled = true;
                        btn_outbound.Enabled = true;
                        outbound_number = txt_from.Text;
                        btn_send.Enabled = false;
                        btn_Reply.Enabled = true;
                        btnSave.Enabled = true;
                        ReadOnly_text(true);
                        LoadSmsCategory("1");

                        break;
                    case SmsStatusFrom.View:
                        Console.WriteLine("View");
                        //if (Global.userAccount.level == "2")
                            logsmsdao.UpdateSmsRead(_sms_id);
                        
                        logsms = logsmsdao.GetSms_byId(_sms_id);
                        txt_from.Text = logsms.sms_from;
                        txt_to.Text = logsms.sms_to;
                        txt_text.Text = logsms.sms_text;
                        btn_tagticket.Enabled = true;
                        btn_outbound.Enabled = true;
                        outbound_number = txt_to.Text;
                        if (logsms.direction_id == 1)
                        {
                            btn_Reply.Enabled = true;
                            LoadSmsCategory("1"); 
                        }
                        else
                        {
                            btn_Reply.Enabled = false; 
                            LoadSmsCategory("2");
                        }

                        if(logsms.category_id > 0) cmbCategorySms.SelectedValue = logsms.category_id;
                        
                        ReadOnly_text(true);
                        btn_send.Enabled = false;
                        btnSave.Enabled = true;
                      
                           
                        //findsms.SearchList();
                        break;
                    case SmsStatusFrom.Create:
                        Console.WriteLine("Create");
                        Clear_object();
                        Enable_object(true);
                        txt_from.Enabled = false;
                        btn_send.Enabled = true;
                        btn_tagticket.Enabled = false;
                        btn_outbound.Enabled = false;
                        ReadOnly_text(false);
                        btn_Reply.Enabled = false;
                        btnSave.Enabled = false;
                        LoadSmsCategory("2");
                        break;
                    
                    default:
                        break;
                } 
            }
            catch (Exception Ex)
            {
                Global.WriteLog(Global.GetCurrentMethod(Ex));
            }
          
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            SendingSms();
        }

        private void btn_tagticket_Click(object sender, EventArgs e)
        {
            try
            {
                View.FindTicket findticket = new FindTicket(logsms.sms_id,2);
                findticket.smsform = this;
                findticket.enumtagticket = FindTicket.TagTicketSourceMedia.Sms;
                findticket.ShowDialog();
            }
            catch (Exception Ex)
            {
                Global.WriteLog(Global.GetCurrentMethod(Ex));
            }
            
        }

        private void btn_outbound_Click(object sender, EventArgs e)
        { 
            if (Global.mainForm.outboundCallForm == null)
            {
                Global.mainForm.outboundCallForm = new View.OutboundCall(outbound_number, "2", _sms_id.ToString());
                Global.mainForm.outboundCallForm.ShowDialog();
            }
        }

        private void btn_Reply_Click(object sender, EventArgs e)
        {
            logsms = new LogSms(); 
            logsms = logsmsdao.GetSms_byId(_sms_id);
             
            string text = "\r\n\r\n" + "Original Text \r\n" +
                " ===================================== \r\n"
                + "FROM : " + logsms.sms_from + "\r\n"
                + "TEXT : " + logsms.sms_text;
          
            Enable_object(false);
            txt_to.Text = txt_from.Text;
            txt_from.Clear(); 
            btn_Reply.Enabled = false;
            btn_send.Enabled = true;
            txt_to.Enabled = true;
            txt_text.Enabled = true;

            txt_text.Text = text;
            //txt_text.Text = txt_text.Text.Insert(txt_text.SelectionStart, text);
            txt_text.Focus();
            ReadOnly_text(false);
        }

        private void SendingSms()
        {
            btn_send.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;

            if (txt_to.Text != "" && txt_text.Text != "")
            {
                if (MessageBox.Show("Are You Sure For Send SMS ???", "Send SMS", MessageBoxButtons.YesNo) == DialogResult.Yes)
                { 
                    string smsoutput= string.Empty;
                    string smsfrom = txt_to.Text;
                    if (smsfrom.EndsWith(";"))
                        smsoutput = smsfrom.Remove(smsfrom.Length - 1, 1);
                    else
                        smsoutput = smsfrom;
                    Console.WriteLine("SMSFROM :" + smsfrom);
                    string[] lines = Regex.Split(smsoutput, ";");
                    
                    foreach (string line in lines)
                    {
                        LogSms __logsms = new LogSms();
                        __logsms.user_id = Convert.ToInt32(Global.userAccount.id);
                        __logsms.sms_status_id = 2;
                        __logsms.direction_id = 2;
                        __logsms.sms_from = txt_from.Text;
                        __logsms.sms_to = line;
                        __logsms.sms_text = txt_text.Text;
                        __logsms.sms_read = 2;
                        __logsms.category_id = Convert.ToInt32(cmbCategorySms.SelectedValue);

                        if (logsmsdao.InsertSms(__logsms))
                        {
                            MessageBox.Show("Succes Create SMS");
                            
                            Enable_object(false);
                            //this.Close();
                            btn_tagticket.Enabled = true;
                            btn_outbound.Enabled = true;
                            btn_send.Enabled = false;
                            Cursor.Current = Cursors.Default;
                        }
                        else
                        {
                            MessageBox.Show("Something wrong, Create SMS Failed");
                            btn_send.Enabled = true;
                        }
                    }

                }
            }
           
            Cursor.Current = Cursors.Default;
        }

        private void btnTicket_Click(object sender, EventArgs e)
        {
            Entity.TempTicket tmpticket = new TempTicket() 
            { 
                tempUserId = Global.userAccount.id,
                tempPasswd = Global.hashPassword,
                tempSourceMediaId = "2",
                tempMediaId = _sms_id.ToString() 
            };


            //TempTicket tempTicket = new TempTicket(); 
            //tempTicket.tempUserId = Global.userAccount.id;
            //tempTicket.tempPasswd = Global.userAccount.password;
            //tempTicket.tempSourceMediaId = "2";
            //tempTicket.tempMediaId = _sms_id.ToString();

            var createTicket = new View.CreateTicket(tmpticket);
            createTicket.StartPosition = FormStartPosition.CenterScreen;
            createTicket.WindowState = FormWindowState.Maximized;
            createTicket.smsForm = this;
            createTicket.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (logsmsdao.UpdateCategory(_sms_id, cmbCategorySms.SelectedValue.ToString()))
                MessageBox.Show("Succes Update Category");
            else
                MessageBox.Show("Failed Update Category");
        }



    }
}
