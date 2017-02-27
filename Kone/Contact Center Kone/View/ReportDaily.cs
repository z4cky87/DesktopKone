﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Contact_Center_Kone.Entity;
using Contact_Center_Kone.Dao;
using Contact_Center_Kone.Utility;
using Contact_Center_Kone.Report;

namespace Contact_Center_Kone.View
{
    public partial class ReportDaily : Form
    {
        ReportDailyDao reportdailydao = new ReportDailyDao();
        ExportDailyInbound exportdailyinbound = null;
        ExportDailyOutbound exportdailyoutbound = null;

        public ReportDaily()
        {
            InitializeComponent();
        }

        void ChangeHederColumn_in()
        {
            this.dtgrid_inbound.Columns[0].HeaderText = "Date";
            this.dtgrid_inbound.Columns[0].Width = 150;

            this.dtgrid_inbound.Columns[1].HeaderText = "Total Recieve";
            this.dtgrid_inbound.Columns[1].Width = 150;

            this.dtgrid_inbound.Columns[2].HeaderText = "Total Answered";
            this.dtgrid_inbound.Columns[2].Width = 150;

            this.dtgrid_inbound.Columns[3].HeaderText = "Total Abandon";
            this.dtgrid_inbound.Columns[3].Width = 150;

            this.dtgrid_inbound.Columns[4].HeaderText = "Total Phantom";
            this.dtgrid_inbound.Columns[4].Width = 150;

            this.dtgrid_inbound.Columns[5].HeaderText = "Call Duration";
            this.dtgrid_inbound.Columns[5].Width = 150;

            this.dtgrid_inbound.Columns[6].HeaderText = "AVG Call Duration";
            this.dtgrid_inbound.Columns[6].Width = 150;

            this.dtgrid_inbound.Columns[7].HeaderText = "ACW TIME";
            this.dtgrid_inbound.Columns[7].Width = 150;

            this.dtgrid_inbound.Columns[8].HeaderText = "AVG ACW TIME";
            this.dtgrid_inbound.Columns[8].Width = 150;

            this.dtgrid_inbound.Columns[9].HeaderText = "Blank Call";
            this.dtgrid_inbound.Columns[9].Width = 150;

            this.dtgrid_inbound.Columns[10].HeaderText = "Wrong Number";
            this.dtgrid_inbound.Columns[10].Width = 150;

            this.dtgrid_inbound.Columns[11].HeaderText = "Inquiry";
            this.dtgrid_inbound.Columns[11].Width = 150;

            this.dtgrid_inbound.Columns[12].HeaderText = "Complaint";
            this.dtgrid_inbound.Columns[12].Width = 150;

            //this.dtgrid_inbound.Columns[13].HeaderText = "ProspectCust";
            //this.dtgrid_inbound.Columns[13].Width = 150;

            this.dtgrid_inbound.Columns[13].Visible = false;

            this.dtgrid_inbound.Columns[14].HeaderText = "Request";
            this.dtgrid_inbound.Columns[14].Width = 150;

            this.dtgrid_inbound.Columns[15].HeaderText = "Test Call";
            this.dtgrid_inbound.Columns[15].Width = 150;

            this.dtgrid_inbound.Columns[16].HeaderText = "Others";
            this.dtgrid_inbound.Columns[16].Width = 150;
        }

        void ChangeHederColumn_out()
        {
            this.dtgrid_outbound.Columns[0].HeaderText = "Date";
            this.dtgrid_outbound.Columns[0].Width = 150;

            this.dtgrid_outbound.Columns[1].HeaderText = "Outgoing Call";
            this.dtgrid_outbound.Columns[1].Width = 150;

            this.dtgrid_outbound.Columns[2].HeaderText = "Call Duration";
            this.dtgrid_outbound.Columns[2].Width = 150;

            this.dtgrid_outbound.Columns[3].HeaderText = "AVG Call Duration";
            this.dtgrid_outbound.Columns[3].Width = 150;
        }
        void LoadUserNameOut()
        {
            this.cmb_username_out.DataSource = reportdailydao.GetAllUserName();
            this.cmb_username_out.DisplayMember = "username";
            this.cmb_username_out.ValueMember = "id";
        }
        void LoadUserNameIn()
        {
            this.cmb_username_in.DataSource = reportdailydao.GetAllUserName();
            this.cmb_username_in.DisplayMember = "username";
            this.cmb_username_in.ValueMember = "id";
        }
        private void btn_search_outbound_Click(object sender, EventArgs e)
        {
            exportdailyoutbound = new ExportDailyOutbound();
            Cursor.Current = Cursors.WaitCursor;
            string _dte_from = dte_from_outbound.Value.ToString("yyyy-MM-dd");
            string _dte_until = dte_until_outbound.Value.ToString("yyyy-MM-dd");
            int user_id = cmb_username_out.Text == "" ? 0 : Convert.ToInt32(cmb_username_out.SelectedValue);
            exportdailyoutbound.myReport = reportdailydao.GetListDailyOutbound(dte_from_outbound, dte_until_outbound, user_id);
            dtgrid_outbound.DataSource = exportdailyoutbound.myReport;
            lbl_row_out.Text = dtgrid_outbound.Rows.Count.ToString() + " LIST";
            Global.ChangeColorGrid(dtgrid_outbound);
            Global.ChangeHeaderGrid(dtgrid_outbound);
            //if (dtgrid_reportcall.Rows.Count > 0)
            ChangeHederColumn_out();
            btn_search_outbound.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            exportdailyinbound = new ExportDailyInbound();
            Cursor.Current = Cursors.WaitCursor;
            string _dte_from = dte_from.Value.ToString("yyyy-MM-dd");
            string _dte_until = dte_until.Value.ToString("yyyy-MM-dd");
            int user_id = cmb_username_in.Text == "" ? 0 : Convert.ToInt32(cmb_username_in.SelectedValue);
            exportdailyinbound.myReport = reportdailydao.GetListDailyInbound(dte_from, dte_until, user_id);
            dtgrid_inbound.DataSource = exportdailyinbound.myReport;
            lbl_row_in.Text = dtgrid_inbound.Rows.Count.ToString() + " LIST";
            Global.ChangeColorGrid(dtgrid_inbound);
            Global.ChangeHeaderGrid(dtgrid_inbound);
            //if (dtgrid_reportcall.Rows.Count > 0)
            ChangeHederColumn_in();
            btn_search_outbound.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            if (dtgrid_inbound.Rows.Count != 0)
            {

                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.AddExtension = true;
                saveFile.Title = "Save Report Excel";
                saveFile.OverwritePrompt = true;

                saveFile.Filter = "Excel FIle|*.xlsx";
                saveFile.ValidateNames = true;
                saveFile.FileName = System.DateTime.Now.ToString("dd-MM-yyyy") + "- Report Daily Inbound";
                if (saveFile.ShowDialog() != DialogResult.Cancel)
                {
                    exportdailyinbound.GenerateReport(Global.ReplaceInvalidFileNameChars(saveFile.FileName.Replace(".xlsx", "")));
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

        private void btn_export_outbound_Click(object sender, EventArgs e)
        {
            if (dtgrid_outbound.Rows.Count != 0)
            {

                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.AddExtension = true;
                saveFile.Title = "Save Report Excel";
                saveFile.OverwritePrompt = true;

                saveFile.Filter = "Excel FIle|*.xlsx";
                saveFile.ValidateNames = true;
                saveFile.FileName = System.DateTime.Now.ToString("dd-MM-yyyy") + "- Report Daily Outbound";
                if (saveFile.ShowDialog() != DialogResult.Cancel)
                {
                    exportdailyoutbound.GenerateReport(Global.ReplaceInvalidFileNameChars(saveFile.FileName.Replace(".xlsx", "")));
                    if (MessageBox.Show("Export data sukses" + System.Environment.NewLine + "Look at folder?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        this.UseWaitCursor = false;
                        System.Diagnostics.Process.Start("explorer.exe", System.IO.Path.GetDirectoryName(saveFile.FileName));
                    }

                }
            }
            else { MessageBox.Show("Please Searcing Data"); }
        }

        private void ReportDaily_Load(object sender, EventArgs e)
        {
            LoadUserNameOut();
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

            cbx_username_out.Checked = true;
            if (cbx_username_out.Checked == true)
            {
                cmb_username_out.SelectedIndex = -1;
                cmb_username_out.Enabled = false;
            }
            else
            {
                cmb_username_out.Enabled = true;
                LoadUserNameOut();
            }
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

        private void cbx_username_out_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx_username_out.Checked == true)
            {
                cmb_username_out.SelectedIndex = -1;
                cmb_username_out.Enabled = false;
            }
            else
            {
                cmb_username_out.Enabled = true;
                LoadUserNameOut();
            }
        }
    }
}
