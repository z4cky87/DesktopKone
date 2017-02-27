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
using Contact_Center_Kone.Report;

namespace Contact_Center_Kone.View
{
    public partial class ReportEmail : Form
    {
        ReportEmailDao reportemaildao = new ReportEmailDao();
        ExportEmail exportemail = null;

        public ReportEmail()
        {
            InitializeComponent();
        }

        void ChangeHederColumn()
        {
            this.dtgrid_reportemail.Columns[0].HeaderText = "Date";
            this.dtgrid_reportemail.Columns[0].Width = 90;

            this.dtgrid_reportemail.Columns[1].HeaderText = "Time";
            this.dtgrid_reportemail.Columns[1].Width = 150;

            this.dtgrid_reportemail.Columns[2].HeaderText = "Status";
            this.dtgrid_reportemail.Columns[2].Width = 150;

            this.dtgrid_reportemail.Columns[3].HeaderText = "Direction";
            this.dtgrid_reportemail.Columns[3].Width = 150;

            this.dtgrid_reportemail.Columns[4].HeaderText = "Username";
            this.dtgrid_reportemail.Columns[4].Width = 150;

            this.dtgrid_reportemail.Columns[5].HeaderText = "From";
            this.dtgrid_reportemail.Columns[5].Width = 150;

            this.dtgrid_reportemail.Columns[6].HeaderText = "To";
            this.dtgrid_reportemail.Columns[6].Width = 150;

            this.dtgrid_reportemail.Columns[7].HeaderText = "Cc";
            this.dtgrid_reportemail.Columns[7].Width = 150;

            this.dtgrid_reportemail.Columns[8].HeaderText = "Bcc";
            this.dtgrid_reportemail.Columns[8].Width = 150;

            this.dtgrid_reportemail.Columns[9].HeaderText = "Subject";
            this.dtgrid_reportemail.Columns[9].Width = 150;

            this.dtgrid_reportemail.Columns[10].HeaderText = "Body";
            this.dtgrid_reportemail.Columns[10].Width = 150; 
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            exportemail = new ExportEmail();
            Cursor.Current = Cursors.WaitCursor;
            string _dte_from = dte_from.Value.ToString("yyyy-MM-dd");
            string _dte_until = dte_until.Value.ToString("yyyy-MM-dd");
            exportemail.myReport = reportemaildao.GetAll_mail(_dte_from, _dte_until);
            dtgrid_reportemail.DataSource = exportemail.myReport;
            lbl_row.Text = dtgrid_reportemail.Rows.Count.ToString() + " LIST";
            Global.ChangeColorGrid(dtgrid_reportemail);
            Global.ChangeHeaderGrid(dtgrid_reportemail);
            //if (dtgrid_reportcall.Rows.Count > 0)
            ChangeHederColumn();
            btn_search.Enabled = true;
            Cursor.Current = Cursors.Default;
            
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            if (dtgrid_reportemail.Rows.Count != 0)
            {

                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.AddExtension = true;
                saveFile.Title = "Save Report Excel";
                saveFile.OverwritePrompt = true;

                saveFile.Filter = "Excel FIle|*.xlsx";
                saveFile.ValidateNames = true;
                saveFile.FileName = System.DateTime.Now.ToString("dd-MM-yyyy") + "- Report EMAIL";
                if (saveFile.ShowDialog() != DialogResult.Cancel)
                {
                    exportemail.GenerateReport(Global.ReplaceInvalidFileNameChars(saveFile.FileName.Replace(".xlsx", "")));
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
