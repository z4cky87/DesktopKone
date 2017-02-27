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
using System.Security;
using System.Text.RegularExpressions;
using System.IO;


namespace Contact_Center_Kone.View
{
    public partial class Email : Form
    {
        public View.FindEmail findemail;
        public View.Main main_form;
        public View.FindTicket findticket;
        
        private LogMailDao logmaildao = new LogMailDao();
        private LogMail _logmail;
        private LogMail logmail;

        private MailAttachmentDao mailattachmentdao = new MailAttachmentDao();
        private MailCategoryDao mailCategoryDao = new MailCategoryDao();

        private string filename;
        private string pathfile; 

        int _mail_id;
        string _ticketNo;
        public MailStatusFrom enumstatus;
        public enum MailStatusFrom
        {
            Inbox = 1,
            Create = 2,
            View = 3
        }

        public Email(int id = 0, string ticketNo = "")
        {
            InitializeComponent();

            _mail_id = id;
            _ticketNo = ticketNo;
        }

        void LoadEmailCategory(string directionId)
        {
            this.cmbCategory.DataSource = mailCategoryDao.GetListCategory(directionId);
            this.cmbCategory.DisplayMember = "category";
            this.cmbCategory.ValueMember = "id";
        }

        void Enable_object(bool active)
        {
            txt_from.Enabled = active;
            txt_to.Enabled = active;
            txt_cc.Enabled = active;
            txt_subject.Enabled = active;
            txt_body.Enabled = active;
            txt_date.Enabled = active;
            txt_time.Enabled = active;
            txt_attachment.Enabled = active;
            txt_no_ticket.Enabled = active;
            btn_send.Enabled = active; 
            btn_tagticket.Enabled = active;
            btn_outbound.Enabled = active;
            btn_Replay.Enabled = active;
        }

        void ReadOnly_Text(bool active)
        {
            txt_from.ReadOnly = active;
            txt_to.ReadOnly = active;
            txt_cc.ReadOnly = active;
            txt_subject.ReadOnly = active;
            txt_body.ReadOnly = active;
            txt_date.ReadOnly = active;
            txt_time.ReadOnly = active;
            txt_attachment.ReadOnly = active;
            txt_no_ticket.ReadOnly = active;
        }
        void Clear_object()
        {
            txt_from.Clear();
            txt_to.Clear();
            txt_cc.Clear();
            txt_subject.Clear();
            txt_body.Clear();
            txt_date.Clear();
            txt_time.Clear();
        }

        void GetDataText()
        {
            _logmail = new LogMail();
            _logmail.mail_from = txt_from.Text;
            _logmail.mail_to = txt_to.Text;
            _logmail.mail_cc = txt_cc.Text;
            _logmail.mail_subject = txt_subject.Text;
            _logmail.mail_text = txt_body.Text; 
            _logmail.direction_id = 2;
            _logmail.mail_status_id = 2; 
            _logmail.user_id = Convert.ToInt32(Global.userAccount.id);
            _logmail.mail_category_id = Convert.ToInt32(cmbCategory.SelectedValue.ToString());
        }

        public void GetTagNoTicket(string ticketno)
        {
            txt_no_ticket.Clear();
            txt_no_ticket.Text = ticketno;
        }

        private void Email_Load(object sender, EventArgs e)
        {
            logmail = new LogMail(); 
            switch (enumstatus)
            {
                case MailStatusFrom.Inbox:
                    Console.WriteLine("Inbox");
                    //Enable_object(false);
                    string total_mail_attachment = string.Empty;
                    logmail = logmaildao.Get_mail_ByMailRead();
                    if (logmail != null)
                    {
                        if (Global.userAccount.level == "1")
                            logmaildao.UpdateMailRead(logmail.id);
                        
                        total_mail_attachment = mailattachmentdao.Get_CountMailAttachment(logmail.id);
                        lbl_count_attachment.Text = total_mail_attachment + " Attachment";
                        _mail_id = logmail.id;
                        txt_from.Text = logmail.mail_from;
                        txt_to.Text = logmail.mail_to;
                        txt_cc.Text = logmail.mail_cc;
                        txt_subject.Text = logmail.mail_subject;
                        txt_body.Text = logmail.mail_text;
                        txt_date.Text = logmail.mail_date;
                        txt_time.Text = logmail.mail_time;
                        btn_tagticket.Enabled = true;
                        btn_outbound.Enabled = true;
                        btn_Replay.Enabled = true;
                        btn_send.Enabled = false;
                        btnSave.Enabled = true;
                        ReadOnly_Text(true);
                        LoadEmailCategory("1");
                    }
                 
                    break; 
                case MailStatusFrom.Create:
                    Console.WriteLine("Create");
                    Clear_object();
                    Enable_object(true);
                    btn_tagticket.Enabled = false;
                    txt_from.Enabled = false;
                    txt_attachment.Enabled = false;
                    btn_tagticket.Enabled = false;
                    btn_outbound.Enabled = false;
                    txt_date.Enabled = false;
                    txt_time.Enabled=false;
                    btn_Replay.Enabled = false;
                    btnSave.Enabled = false;
                    ReadOnly_Text(false);
                    LoadEmailCategory("2");
                    break;
                case MailStatusFrom.View:
                    Console.WriteLine("View");
                    //Enable_object(false);
                    if (Global.userAccount.level == "1")
                        logmaildao.UpdateMailRead(_mail_id);

                    logmail = logmaildao.Get_mail_ById(_mail_id);
                    total_mail_attachment = mailattachmentdao.Get_CountMailAttachment(_mail_id);
                    lbl_count_attachment.Text = total_mail_attachment + " Attachment";

                    txt_from.Text = logmail.mail_from;
                    txt_to.Text = logmail.mail_to;
                    txt_cc.Text = logmail.mail_cc;
                    txt_subject.Text = logmail.mail_subject;
                    txt_body.Text = logmail.mail_text;
                    txt_date.Text = logmail.mail_date;
                    txt_time.Text = logmail.mail_time;
                    txt_no_ticket.Text = _ticketNo;
                    if (logmail.direction_id == 1)
                    {
                        LoadEmailCategory("1");
                        btn_Replay.Enabled = true;
                    }
                    else
                    {
                        btn_Replay.Enabled = false;
                        LoadEmailCategory("2");
                    }
                    if(logmail.mail_category_id > 0) cmbCategory.SelectedValue = logmail.mail_category_id;

                    btn_tagticket.Enabled = true;
                    btn_outbound.Enabled = true;
                    btn_send.Enabled = false;
                    btnSave.Enabled = true;
                    ReadOnly_Text(true);
              
                    
                    findemail.Search_list();
                    break;
                default:
                    break;
            } 



        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            SendingEmail();
        }

        private void btn_attachment_Click(object sender, EventArgs e)
        {
            try
            {
                if (_mail_id > 0)
                {
                    View.ListAttachment listattachment = new ListAttachment(_mail_id);
                    listattachment.email = this;
                    listattachment.ShowDialog(); 
                }
                else
                {
                    filename = string.Empty;
                    pathfile = string.Empty;
                    string tes = string.Empty;
                    OpenFileDialog dialog = new OpenFileDialog();
                    
                    dialog.Filter = "All files (*.*)|*.*";
                    dialog.Multiselect = true;
                    dialog.Title = "Please select file";
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        filename = dialog.SafeFileName;
                        pathfile = dialog.FileName;
                        foreach (String file in dialog.FileNames)
                        {
                            txt_attachment.Text += file + ";";
                            tes += file;
                        }
                        txt_attachment.Text = txt_attachment.Text.Remove(txt_attachment.Text.Length - 1);

                    }
                
                }
             
            }
            catch (Exception Ex)
            {
                Global.WriteLog(Global.GetCurrentMethod(Ex));
            } 
        }

        private void btn_tagticket_Click(object sender, EventArgs e)
        {
            try
            {
                findticket = new FindTicket(logmail.id,1);
                findticket.emailform = this;
                findticket.enumtagticket = FindTicket.TagTicketSourceMedia.Email;
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
                Global.mainForm.outboundCallForm = new View.OutboundCall("", "1", _mail_id.ToString());
                Global.mainForm.outboundCallForm.ShowDialog();
            }
        }

        private void btn_Replay_Click(object sender, EventArgs e)
        {
            logmail = new LogMail();
            logmail = logmaildao.Get_mail_ById(_mail_id);
             
            string text = "\r\n\r\n" + "Original Text \r\n " 
                        + "===================================== \r\n"
                        + "FROM : " + logmail.mail_from +"\r\n"
                        + "CC : " + logmail.mail_cc + "\r\n"
                        + "SUBJECT : " + logmail.mail_subject + "\r\n"
                        + "BODY : " + logmail.mail_text;

            txt_to.Text = txt_from.Text;
            txt_from.Clear();
            txt_cc.Enabled = true;
            txt_subject.Enabled = true;
            txt_attachment.Clear();
            txt_body.Enabled = true;
            btn_send.Enabled = true;
            btnSave.Enabled = false;
            ReadOnly_Text(false);
            txt_from.Enabled = false;
            txt_attachment.Enabled = false;

            txt_body.Text = text;
            //txt_body.Text = txt_body.Text.Insert(txt_body.SelectionStart, text);
            txt_body.Focus();
        }

        private void SendingEmail()
        {
            btn_send.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;

            if (txt_to.Text != "" && txt_subject.Text != "" && txt_subject.Text != "" & txt_body.Text != "")
            {
                if (MessageBox.Show("Are You Sure For Send Email ???", "Send Email", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    GetDataText();
                    
                    //MessageBox.Show(lines.Length.ToString());
                    string logmail_id = logmaildao.InsertMail(_logmail,this.txt_attachment.Text.Length>0);

                    if (logmail_id != null && logmail_id != string.Empty && logmail_id != "")
                    {
                        try
                        {
                            if (txt_attachment.Text != "")
                            {
                                //Checking Folder Attachment by logmail_id
                                //if (!Global.CheckFolder(logmail_id))
                                Global.CreateFolder(logmail_id);
                                string mailattachmentid = string.Empty;
                                string[] lines = Regex.Split(txt_attachment.Text, ";");
                                foreach (string line in lines)
                                {
                                    string result;
                                    result = Path.GetFileName(line);
                                    MailAttachment mailattachment = new MailAttachment();
                                    mailattachment.mail_id = Convert.ToInt32(logmail_id);
                                    mailattachment.filename = result;
                                    if (mailattachmentdao.Insert_MailAttachment(mailattachment))
                                    {
                                        //Upload File Attachment
                                        //Global.UploadingFile(logmail_id, line);
                                        Global.uploadAttachmentFile(logmail_id, line);
                                        //Global.uploadingFilePost_Http(logmail_id, line);
                                    }
                                }

                                logmaildao.UpdateMailAttachmentCommplete(logmail_id, mailattachmentid);
                            }
                        }
                        catch (Exception Ex)
                        {
                            Global.WriteLog(Global.GetCurrentMethod(Ex));
                        }


                        btn_tagticket.Enabled = true;
                        MessageBox.Show("Email Proccses Sending Succes");
                        Cursor.Current = Cursors.Default;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Email Failed Save");
                        btn_send.Enabled = true;
                    }

                }
            }
            else
            {
                MessageBox.Show("Please Completed Data Email");
                btn_send.Enabled = true;
                Cursor.Current = Cursors.Default;
            }
        }

        private void btn_clear_attach_Click(object sender, EventArgs e)
        {
            txt_attachment.Clear();
        }

        private void Email_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            
        }

        private void Email_FormClosed(object sender, FormClosedEventArgs e)
        {
            //findemail.Search_list();
        }

        private void btnOpenTicket_Click(object sender, EventArgs e)
        {
            TempTicket tempTicket = new TempTicket(); 
            tempTicket.tempUserId = Global.userAccount.id;
            tempTicket.tempPasswd = Global.hashPassword;
            tempTicket.tempSourceMediaId = "1";
            tempTicket.tempMediaId = _mail_id.ToString() ; 

            var createTicket = new View.CreateTicket(tempTicket);
            createTicket.StartPosition = FormStartPosition.CenterScreen;
            createTicket.WindowState = FormWindowState.Maximized;
            createTicket.mailForm = this;
            createTicket.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(logmaildao.UpdateCategory(_mail_id,cmbCategory.SelectedValue.ToString()))
                MessageBox.Show("Succes Update Category");
            else
                MessageBox.Show("Failed Update Category");
        }
    }
}
