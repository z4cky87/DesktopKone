using Contact_Center_Kone.Dao;
using Contact_Center_Kone.Entity;
using Contact_Center_Kone.Report;
using Contact_Center_Kone.Utility;
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
    public partial class ReportVoiceMail : Form
    {
        LogVoiceMailDao logvoicemaildao = new LogVoiceMailDao();
        LogVoiceMail logvoicemail = new LogVoiceMail();
        ExportVoiceMail exportvoicemail;
        public ReportVoiceMail()
        {
            InitializeComponent();
        }

        void ChangeHederColumn()
        {
            this.dtgrid_logvoicemail.Columns["datetime"].HeaderText = "Datetime";
            this.dtgrid_logvoicemail.Columns["uniqueid"].HeaderText = "UniqueID";
            this.dtgrid_logvoicemail.Columns["fullpath"].HeaderText = "Fullpath";
            this.dtgrid_logvoicemail.Columns["phoneno"].HeaderText = "Phone No";
            this.dtgrid_logvoicemail.Columns["voice_statusread"].HeaderText = "Voice Read";
            this.dtgrid_logvoicemail.Columns["username"].HeaderText = "Username";
            this.dtgrid_logvoicemail.Columns["ticket_no"].HeaderText = "Ticket No"; 
        }

        public void SearchList()
        {
            exportvoicemail = new ExportVoiceMail();
            btn_search.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;

            string _datefrom = DateFrom.Value.ToString("yyyy-MM-dd");
            string _dateuntil = DateUntill.Value.ToString("yyyy-MM-dd");
            exportvoicemail.myReport = logvoicemaildao.GetVoiceMailReport(_datefrom, _dateuntil);
            this.dtgrid_logvoicemail.DataSource = exportvoicemail.myReport;
            lbl_row.Text = this.dtgrid_logvoicemail.Rows.Count.ToString() + " List";


            Global.ChangeColorGrid(dtgrid_logvoicemail);
            Global.ChangeHeaderGrid(dtgrid_logvoicemail);
            //if (dtgrid_findemail.Rows.Count > 0)
            //ChangeHederColumn();
            btn_search.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchList();
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            if (dtgrid_logvoicemail.Rows.Count != 0)
            {

                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.AddExtension = true;
                saveFile.Title = "Save Report Excel";
                saveFile.OverwritePrompt = true;

                saveFile.Filter = "Excel FIle|*.xlsx";
                saveFile.ValidateNames = true;
                saveFile.FileName = System.DateTime.Now.ToString("dd-MM-yyyy") + "- Report VoiceMail";
                if (saveFile.ShowDialog() != DialogResult.Cancel)
                {
                    exportvoicemail.GenerateReport(Global.ReplaceInvalidFileNameChars(saveFile.FileName.Replace(".xlsx", "")));
                    if (MessageBox.Show("Export data sukses" + System.Environment.NewLine + "Look at folder?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        this.UseWaitCursor = false;
                        //System.Diagnostics.Process.Start("explorer.exe", System.IO.Path.GetDirectoryName(saveFile.FileName));
                        string argument = saveFile.FileName;
                        string args = string.Format(@"/Select," + argument);
                        System.Diagnostics.Process.Start("explorer.exe", args);
                    }

                }
            }
            else { MessageBox.Show("Please Searcing Data"); }
        }
    }
}
