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
using Contact_Center_Kone.Report;

namespace Contact_Center_Kone.View
{
    public partial class ReportPBX : Form
    {
        ReportPBXDao reportepbxdao = new ReportPBXDao();
        ExportPBX exportpbx = null;
        public ReportPBX()
        {
            InitializeComponent();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            exportpbx = new ExportPBX();
            Cursor.Current = Cursors.WaitCursor;
            string _dte_from = dte_from.Value.ToString("yyyy-MM-dd");
            string _dte_until = dte_until.Value.ToString("yyyy-MM-dd");
            int call_status_id = cmb_call_status.Text == "-1" ? -1 : Convert.ToInt32(cmb_call_status.SelectedIndex);
            exportpbx.myReport = reportepbxdao.GetAllPbx(_dte_from, _dte_until, call_status_id);
            dtgrid_reportpbx.DataSource = exportpbx.myReport;
            lbl_row.Text = dtgrid_reportpbx.Rows.Count.ToString() + " LIST";
            Global.ChangeColorGrid(dtgrid_reportpbx);
            Global.ChangeHeaderGrid(dtgrid_reportpbx);
            ChangeHederColumn();
            btn_search.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        void ChangeHederColumn()
        {
            this.dtgrid_reportpbx.Columns[0].HeaderText = "DATE";
            this.dtgrid_reportpbx.Columns[0].Width = 90;

            this.dtgrid_reportpbx.Columns[1].HeaderText = "TIME";
            this.dtgrid_reportpbx.Columns[1].Width = 90;

            this.dtgrid_reportpbx.Columns[2].HeaderText = "UNIQUE ID";
            this.dtgrid_reportpbx.Columns[2].Width = 90;

            //this.dtgrid_reportpbx.Columns[3].HeaderText = "SOURCE NAME";
            //this.dtgrid_reportpbx.Columns[3].Width = 90;

            this.dtgrid_reportpbx.Columns[3].Visible = false;

            this.dtgrid_reportpbx.Columns[4].HeaderText = "CALLER NUMBER";
            this.dtgrid_reportpbx.Columns[4].Width = 150;

            this.dtgrid_reportpbx.Columns[5].HeaderText = "DNID";
            this.dtgrid_reportpbx.Columns[5].Width = 150;

            this.dtgrid_reportpbx.Columns[6].HeaderText = "CHANNEL";
            this.dtgrid_reportpbx.Columns[6].Width = 150;

            this.dtgrid_reportpbx.Columns[7].HeaderText = "CALL STATUS";
            this.dtgrid_reportpbx.Columns[7].Width = 150;

            this.dtgrid_reportpbx.Columns[8].HeaderText = "ABANDON STATUS";
            this.dtgrid_reportpbx.Columns[8].Width = 150;

            this.dtgrid_reportpbx.Columns[9].HeaderText = "TALK DURATION";
            this.dtgrid_reportpbx.Columns[9].Width = 150;

            this.dtgrid_reportpbx.Columns[10].HeaderText = "USERNAME";
            this.dtgrid_reportpbx.Columns[10].Width = 150;

            this.dtgrid_reportpbx.Columns[11].HeaderText = "HOST ADDRESS";
            this.dtgrid_reportpbx.Columns[11].Width = 150;

            this.dtgrid_reportpbx.Columns[12].HeaderText = "EXTENTION";
            this.dtgrid_reportpbx.Columns[12].Width = 150;

            this.dtgrid_reportpbx.Columns[13].HeaderText = "IVR DURATION";
            this.dtgrid_reportpbx.Columns[13].Width = 150;

            this.dtgrid_reportpbx.Columns[14].HeaderText = "QUEUE DURATION";
            this.dtgrid_reportpbx.Columns[14].Width = 150;

            this.dtgrid_reportpbx.Columns[15].HeaderText = "TOTAL AGENT READY";
            this.dtgrid_reportpbx.Columns[15].Width = 150;

            this.dtgrid_reportpbx.Columns[16].HeaderText = "TOTAL AGENT BREAK";
            this.dtgrid_reportpbx.Columns[16].Width = 150;

            this.dtgrid_reportpbx.Columns[17].HeaderText = "TOTAL AGENT BUSY";
            this.dtgrid_reportpbx.Columns[17].Width = 150;

            this.dtgrid_reportpbx.Columns[18].HeaderText = "TOTAL AGENT ONLINE";
            this.dtgrid_reportpbx.Columns[18].Width = 150;

        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            if (dtgrid_reportpbx.Rows.Count != 0)
            {

                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.AddExtension = true;
                saveFile.Title = "Save Report Excel";
                saveFile.OverwritePrompt = true;

                saveFile.Filter = "Excel FIle|*.xlsx";
                saveFile.ValidateNames = true;
                saveFile.FileName = System.DateTime.Now.ToString("dd-MM-yyyy") + "- Report PBX";
                if (saveFile.ShowDialog() != DialogResult.Cancel)
                {
                    exportpbx.GenerateReport(Global.ReplaceInvalidFileNameChars(saveFile.FileName.Replace(".xlsx", "")));
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

        private void ReportPBX_Load(object sender, EventArgs e)
        {
            cmb_call_status.SelectedIndex = -1;
            cbx_call_status.Checked = true;
            if (cbx_call_status.Checked == true)
            {
                cmb_call_status.SelectedIndex = -1;
                cmb_call_status.Enabled = false;
            }
            else
            {
                cmb_call_status.Enabled = true;
                //LoadCallStatusIn();
            }
        }

        private void cbx_call_status_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx_call_status.Checked == true)
            {
                cmb_call_status.SelectedIndex = -1;
                cmb_call_status.Enabled = false;
            }
            else
            {
                cmb_call_status.Enabled = true;
                //LoadCallStatusIn();
            }
        }
    }
}
