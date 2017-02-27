using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Contact_Center_Kone.Entity;
using Contact_Center_Kone.Utility;
using Contact_Center_Kone.Dao;
using System.IO;
using System.Net;

namespace Contact_Center_Kone.View
{
    public partial class ListAttachment : Form
    {
        public View.Email email;
        MailAttachmentDao mailattachmentdao = new MailAttachmentDao();
        private Queue<string> _downloadUrls = new Queue<string>();
        string pathselect = string.Empty;

        #region Delegates
        delegate void setLabelTextDelegateUser(ListAttachment frm, string text);
        delegate void setButtonDelegateUser(Button btn, bool status);
        private void setLabelText(ListAttachment form, string text)
        {
            if (form.InvokeRequired)
            {
                setLabelTextDelegateUser d = new setLabelTextDelegateUser(setLabelText);
                this.Invoke(d, new Object[] { form, text });
            }
            else
            {
                form.Text = text;
            }
        }

        private void setButton(Button btn, bool _status)
        {
            if (btn.InvokeRequired)
            {
                setButtonDelegateUser d = new setButtonDelegateUser(setButton);
                this.Invoke(d, new Object[] { btn, _status });
            }
            else
            {
                btn.Enabled = _status;
            }
        }
        #endregion

        int _mail_id;
        public ListAttachment(int mail_id = 0)
        {
            InitializeComponent();
            _mail_id = mail_id;
        }

        private void ListAttachment_Load(object sender, EventArgs e)
        {
            this.dtgrid_viewattachment.DataSource = mailattachmentdao.GetAttachment(_mail_id);
            Global.ChangeColorGrid(dtgrid_viewattachment);
            Global.ChangeHeaderGrid(dtgrid_viewattachment);
            dtgrid_viewattachment.ClearSelection();
        }

        private void chekbox_attachment_Click(object sender, EventArgs e)
        {
            if (chekbox_attachment.Checked == true)
            {
                dtgrid_viewattachment.SelectAll();
                chekbox_attachment.Text = "UnSelect ALL";
            }else
            {
                dtgrid_viewattachment.ClearSelection();
                chekbox_attachment.Text = "Select ALL";
            }
        }

        private void btn_download_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgrid_viewattachment.SelectedRows.Count > 0)
                {
                    pathselect = string.Empty;
                    FolderBrowserDialog folderDlg = new FolderBrowserDialog();
                    folderDlg.ShowNewFolderButton = true;
                    DialogResult result = folderDlg.ShowDialog();
                    pathselect = folderDlg.SelectedPath;
                    //MessageBox.Show(folderDlg.SelectedPath);
                    if (result == DialogResult.OK)
                    {
                        progressBar1.Value = 0;
                        Cursor.Current = Cursors.WaitCursor;
                        _downloadUrls = new Queue<string>();

                        for (int i = 0; i < dtgrid_viewattachment.SelectedRows.Count; i++)
                        { 
                            // Show the FolderBrowserDialog.
                            var id = dtgrid_viewattachment.SelectedRows[i].Cells[0].Value.ToString();
                            var mailid = dtgrid_viewattachment.SelectedRows[i].Cells[1].Value.ToString();
                            var filename = dtgrid_viewattachment.SelectedRows[i].Cells[2].Value.ToString();

                            _downloadUrls.Enqueue(Global.atacchment_inbox_http + mailid + @"/" + filename); 

                            //if (File.Exists(pathselect + System.IO.Path.DirectorySeparatorChar + filename))
                            //{
                            //    if (MessageBox.Show("File Is Exist, Do you want to replace ???" + filename, "Replace", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            //        Global.DonwloadFile(mailid, filename, pathselect); 
                            //}
                            //else
                            //{
                            //    if (Global.DonwloadFile(mailid, filename, pathselect)) 
                            //        MessageBox.Show("Download File Is Succes " +  filename); 
                            //    else 
                            //        MessageBox.Show("Download File Is Failed " + filename); 
                            //}
                             
                            //Environment.SpecialFolder root = folderDlg.RootFolder; 
                        }
                        downloadFile_(pathselect); 
                    }
                    Cursor.Current = Cursors.Default;
                }
                else 
                    MessageBox.Show("Please One Selected Attachment"); 

            }
            catch (Exception Ex)
            {
                Global.WriteLog(Global.GetCurrentMethod(Ex));
            }
        }

        void downloadFile_(string pathselect)
        {
            int startfile = 1;
            int count_download = _downloadUrls.Count();
            if (_downloadUrls.Any())
            {
                WebClient client = new WebClient();
                client.DownloadProgressChanged += client_DownloadProgressChanged;
                client.DownloadFileCompleted += client_DownloadFileCompleted;


                var url = _downloadUrls.Dequeue();
                string FileName = url.Substring(url.LastIndexOf("/") + 1,
                            (url.Length - url.LastIndexOf("/") - 1));

                client.DownloadFileAsync(new Uri(url), pathselect + System.IO.Path.DirectorySeparatorChar + FileName);
                //client.DownloadFile(new Uri(url), FileName);
                Console.WriteLine(url);
                this.Text = "Download " + count_download + " File, " + url;
                startfile++;
                return;
            }
        }

        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = bytesIn / totalBytes * 100;
            progressBar1.Value = int.Parse(Math.Truncate(percentage).ToString());
            setLabelText(this, "Proccesing " + Math.Truncate(percentage).ToString() + "  %");
        }

        private void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                // handle error scenario
               // throw e.Error;
                setLabelText(this, e.Error.Message);
            }
            if (e.Cancelled)
            {
                // handle cancelled scenario
                setLabelText(this, e.Error.Message);
            }
            downloadFile_(pathselect);
        }


    }
}
