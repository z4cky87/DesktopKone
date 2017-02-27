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
    public partial class ReportLogin : Form
    {
        ReportLoginDao reportlogindao = new ReportLoginDao();
        ExportLogin exportlogin = null;
        public ReportLogin()
        {
            InitializeComponent();
        }

        void ChangeHederColumn()
        {
            this.dtgrid_reportlogin.Columns[0].HeaderText = "Username";
            this.dtgrid_reportlogin.Columns[0].Width = 90;

            this.dtgrid_reportlogin.Columns[1].HeaderText = "First Login Date";
            this.dtgrid_reportlogin.Columns[1].Width = 150;

            this.dtgrid_reportlogin.Columns[2].HeaderText = "First Login Time";
            this.dtgrid_reportlogin.Columns[2].Width = 150;

            this.dtgrid_reportlogin.Columns[3].HeaderText = "Logout Date";
            this.dtgrid_reportlogin.Columns[3].Width = 150;

            this.dtgrid_reportlogin.Columns[4].HeaderText = "Logout Time";
            this.dtgrid_reportlogin.Columns[4].Width = 150;

            this.dtgrid_reportlogin.Columns[5].HeaderText = "Duration";
            this.dtgrid_reportlogin.Columns[5].Width = 150;

            this.dtgrid_reportlogin.Columns["total_duration"].DisplayIndex = 6;
            this.dtgrid_reportlogin.Columns["total_duration"].Width = 150;
            this.dtgrid_reportlogin.Columns["total_duration"].HeaderText = "Total Duration";

            this.dtgrid_reportlogin.Columns["login_count"].DisplayIndex = 7;
            this.dtgrid_reportlogin.Columns["login_count"].Width = 150;
            this.dtgrid_reportlogin.Columns["login_count"].HeaderText = "Login Count";

            

            

            
        }
        void LoadUserNameIn()
        {
            this.cmb_username_in.DataSource = reportlogindao.GetAllUserName();
            this.cmb_username_in.DisplayMember = "username";
            this.cmb_username_in.ValueMember = "id";
        }
        private void btn_search_Click(object sender, EventArgs e)
        {
            exportlogin = new ExportLogin();
            Cursor.Current = Cursors.WaitCursor;
            string _dte_from = dte_from.Value.ToString("yyyy-MM-dd");
            string _dte_until = dte_until.Value.ToString("yyyy-MM-dd");
            int user_id = cmb_username_in.Text == "" ? 0 : Convert.ToInt32(cmb_username_in.SelectedValue);
            exportlogin.myReport = reportlogindao.GetAllLogin(_dte_from, _dte_until, user_id);
            dtgrid_reportlogin.DataSource = exportlogin.myReport;
            lbl_row.Text = dtgrid_reportlogin.Rows.Count.ToString() + " LIST";
            Global.ChangeColorGrid(dtgrid_reportlogin);
            Global.ChangeHeaderGrid(dtgrid_reportlogin);
            //if (dtgrid_reportcall.Rows.Count > 0)
            ChangeHederColumn();
            btn_search.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            if (dtgrid_reportlogin.Rows.Count != 0)
            {

                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.AddExtension = true;
                saveFile.Title = "Save Report Excel";
                saveFile.OverwritePrompt = true;

                saveFile.Filter = "Excel FIle|*.xlsx";
                saveFile.ValidateNames = true;
                saveFile.FileName = System.DateTime.Now.ToString("dd-MM-yyyy") + "- Report LOGIN";
                if (saveFile.ShowDialog() != DialogResult.Cancel)
                {
                    exportlogin.GenerateReport(Global.ReplaceInvalidFileNameChars(saveFile.FileName.Replace(".xlsx", "")));
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

        private void ReportLogin_Load(object sender, EventArgs e)
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
