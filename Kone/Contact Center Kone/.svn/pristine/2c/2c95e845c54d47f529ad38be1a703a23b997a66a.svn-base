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
    public partial class ReportBreak : Form
    {
        ReportBreakDao reportbreakdao = new ReportBreakDao();
        ExportBreak exportbreak = null;
        public ReportBreak()
        {
            InitializeComponent();
        }

        void ChangeHederColumn()
        {
            this.dtgrid_reportbreak.Columns[0].HeaderText = "Username";
            this.dtgrid_reportbreak.Columns[0].Width = 90;

            this.dtgrid_reportbreak.Columns[1].HeaderText = "Break Reason";
            this.dtgrid_reportbreak.Columns[1].Width = 150;

            this.dtgrid_reportbreak.Columns[2].HeaderText = "Note";
            this.dtgrid_reportbreak.Columns[2].Width = 150;

            this.dtgrid_reportbreak.Columns[3].HeaderText = "Break Date";
            this.dtgrid_reportbreak.Columns[3].Width = 150;

            this.dtgrid_reportbreak.Columns[4].HeaderText = "Break TIme";
            this.dtgrid_reportbreak.Columns[4].Width = 150;

            this.dtgrid_reportbreak.Columns[5].HeaderText = "Resume Date";
            this.dtgrid_reportbreak.Columns[5].Width = 150;

            this.dtgrid_reportbreak.Columns[6].HeaderText = "Resume TIme";
            this.dtgrid_reportbreak.Columns[6].Width = 150;

            this.dtgrid_reportbreak.Columns[7].HeaderText = "Duration";
            this.dtgrid_reportbreak.Columns[7].Width = 150;

            this.dtgrid_reportbreak.Columns[8].HeaderText = "Total Duration";
            this.dtgrid_reportbreak.Columns[8].Width = 150; 
        }
        void LoadUserNameIn()
        {
            this.cmb_username_in.DataSource = reportbreakdao.GetAllUserName();
            this.cmb_username_in.DisplayMember = "username";
            this.cmb_username_in.ValueMember = "id";
        }
        private void btn_search_Click(object sender, EventArgs e)
        {
            exportbreak = new ExportBreak();
            Cursor.Current = Cursors.WaitCursor;
            string _dte_from = dte_from.Value.ToString("yyyy-MM-dd");
            string _dte_until = dte_until.Value.ToString("yyyy-MM-dd");
            int user_id = cmb_username_in.Text == "" ? 0 : Convert.ToInt32(cmb_username_in.SelectedValue);
            exportbreak.myReport = reportbreakdao.GetAllbreak(_dte_from, _dte_until, user_id);
            dtgrid_reportbreak.DataSource = exportbreak.myReport;
            lbl_row.Text = dtgrid_reportbreak.Rows.Count.ToString() + " LIST";
            Global.ChangeColorGrid(dtgrid_reportbreak);
            Global.ChangeHeaderGrid(dtgrid_reportbreak);
            //if (dtgrid_reportcall.Rows.Count > 0)
            ChangeHederColumn();
            btn_search.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            if (dtgrid_reportbreak.Rows.Count != 0)
            {

                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.AddExtension = true;
                saveFile.Title = "Save Report Excel";
                saveFile.OverwritePrompt = true;

                saveFile.Filter = "Excel FIle|*.xlsx";
                saveFile.ValidateNames = true;
                saveFile.FileName = System.DateTime.Now.ToString("dd-MM-yyyy") + "- Report BREAK";
                if (saveFile.ShowDialog() != DialogResult.Cancel)
                {
                    exportbreak.GenerateReport(Global.ReplaceInvalidFileNameChars(saveFile.FileName.Replace(".xlsx", "")));
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

        private void cbx_username_in_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx_username_in.Checked == true)
            {
                cmb_username_in.SelectedIndex = -1;
                cmb_username_in.Enabled = false;
            }
            else
            {
                cmb_username_in.Enabled = true;
                LoadUserNameIn();
            }
        }

        private void ReportBreak_Load(object sender, EventArgs e)
        {
            LoadUserNameIn();

            cbx_username_in.Checked = true;
            if (cbx_username_in.Checked == true)
            {
                cmb_username_in.SelectedIndex = -1;
                cmb_username_in.Enabled = false;
            }
            else
            {
                cmb_username_in.Enabled = true;
                LoadUserNameIn();
            }
        }
    }
}
