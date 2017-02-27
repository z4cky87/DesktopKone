﻿using System;
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
    public partial class ReportHourly : Form
    {

        ReportHourlyDao reporthourly_dao = new ReportHourlyDao();
        ExportHourlyInbound exporthourlyinbound = null;
        ExportHourlyOutbound exporthourluoutbound = null;

        public ReportHourly()
        {
            InitializeComponent();
        }

        void ChangeHederColumn_inbound()
        {
            this.dtgrid_hourly_inbound.Columns[0].HeaderText = "Hour";
            this.dtgrid_hourly_inbound.Columns[0].Width = 90;

            this.dtgrid_hourly_inbound.Columns[1].HeaderText = "Total Recieve";
            this.dtgrid_hourly_inbound.Columns[1].Width = 150;

            this.dtgrid_hourly_inbound.Columns[2].HeaderText = "Total Answered";
            this.dtgrid_hourly_inbound.Columns[2].Width = 150;

            this.dtgrid_hourly_inbound.Columns[3].HeaderText = "Total Abandon";
            this.dtgrid_hourly_inbound.Columns[3].Width = 150;

            this.dtgrid_hourly_inbound.Columns[4].HeaderText = "Total Phantom";
            this.dtgrid_hourly_inbound.Columns[4].Width = 90;

            this.dtgrid_hourly_inbound.Columns[5].HeaderText = "Total Duration";
            this.dtgrid_hourly_inbound.Columns[5].Width = 150;

            this.dtgrid_hourly_inbound.Columns[6].HeaderText = "Total AVG Duration";
            this.dtgrid_hourly_inbound.Columns[6].Width = 150;

            this.dtgrid_hourly_inbound.Columns[7].HeaderText = "Total ACW";
            this.dtgrid_hourly_inbound.Columns[7].Width = 150;

            this.dtgrid_hourly_inbound.Columns[8].HeaderText = "Total AVG ACW";
            this.dtgrid_hourly_inbound.Columns[8].Width = 90;

            this.dtgrid_hourly_inbound.Columns[9].HeaderText = "Total BlankCall";
            this.dtgrid_hourly_inbound.Columns[9].Width = 90;

            this.dtgrid_hourly_inbound.Columns[10].HeaderText = "Total WrongNo";
            this.dtgrid_hourly_inbound.Columns[10].Width = 90;

            this.dtgrid_hourly_inbound.Columns[10].HeaderText = "Total WrongNo";
            this.dtgrid_hourly_inbound.Columns[10].Width = 90;

            this.dtgrid_hourly_inbound.Columns[11].HeaderText = "Total Inquiry";
            this.dtgrid_hourly_inbound.Columns[11].Width = 90;

            this.dtgrid_hourly_inbound.Columns[12].HeaderText = "Total Complain";
            this.dtgrid_hourly_inbound.Columns[12].Width = 90;

            this.dtgrid_hourly_inbound.Columns[13].HeaderText = "Total Prospect Customer";
            this.dtgrid_hourly_inbound.Columns[13].Width = 90;

            this.dtgrid_hourly_inbound.Columns[14].HeaderText = "Total Request";
            this.dtgrid_hourly_inbound.Columns[14].Width = 90;

            this.dtgrid_hourly_inbound.Columns[15].HeaderText = "Total Test Call";
            this.dtgrid_hourly_inbound.Columns[15].Width = 90;

            this.dtgrid_hourly_inbound.Columns[16].HeaderText = "Total Others";
            this.dtgrid_hourly_inbound.Columns[16].Width = 90; 
        }

        void ChangeHederColumn_outbound()
        {
            this.dtgrid_hourly_outbound.Columns[0].HeaderText = "Hour";
            this.dtgrid_hourly_outbound.Columns[0].Width = 90;

            this.dtgrid_hourly_outbound.Columns[1].HeaderText = "Outgoing Call";
            this.dtgrid_hourly_outbound.Columns[1].Width = 90;

            this.dtgrid_hourly_outbound.Columns[2].HeaderText = "Contact";
            this.dtgrid_hourly_outbound.Columns[2].Width = 90;

            this.dtgrid_hourly_outbound.Columns[3].HeaderText = "Unconnect";
            this.dtgrid_hourly_outbound.Columns[3].Width = 90;

            this.dtgrid_hourly_outbound.Columns[4].HeaderText = "Call Time";
            this.dtgrid_hourly_outbound.Columns[4].Width = 90;

            this.dtgrid_hourly_outbound.Columns[5].HeaderText = "AVG Call TIme";
            this.dtgrid_hourly_outbound.Columns[5].Width = 90;

            this.dtgrid_hourly_outbound.Columns[6].HeaderText = "Customer";
            this.dtgrid_hourly_outbound.Columns[6].Width = 90;

            this.dtgrid_hourly_outbound.Columns[7].HeaderText = "Non Customer";
            this.dtgrid_hourly_outbound.Columns[7].Width = 90;

            this.dtgrid_hourly_outbound.Columns[8].HeaderText = "Teknisi";
            this.dtgrid_hourly_outbound.Columns[8].Width = 90;

            this.dtgrid_hourly_outbound.Columns[9].HeaderText = "PIC";
            this.dtgrid_hourly_outbound.Columns[9].Width = 90;
        } 
        void LoadUserNameOut()
        {
            this.cmb_username_out.DataSource = reporthourly_dao.GetAllUserName();
            this.cmb_username_out.DisplayMember = "username";
            this.cmb_username_out.ValueMember = "id";
        }
        void LoadUserNameIn()
        {
            this.cmb_username_in.DataSource = reporthourly_dao.GetAllUserName();
            this.cmb_username_in.DisplayMember = "username";
            this.cmb_username_in.ValueMember = "id";
        }

        void btn_search_outbound_Click(object sender, EventArgs e)
        {
            exporthourluoutbound = new ExportHourlyOutbound();
            btn_search_outbound.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;
            string _dte_from = dte_from_outbound.Value.ToString("yyyy-MM-dd");
            int user_id = cmb_username_out.Text == "" ? 0 : Convert.ToInt32(cmb_username_out.SelectedValue);
            exporthourluoutbound.myReport = reporthourly_dao.GetListHourlyOutbound(_dte_from, user_id);           
            dtgrid_hourly_outbound.DataSource = exporthourluoutbound.myReport;
            lbl_row_outbound.Text = dtgrid_hourly_outbound.Rows.Count.ToString() + " LIST";
            Global.ChangeColorGrid(dtgrid_hourly_outbound);
            Global.ChangeHeaderGrid(dtgrid_hourly_outbound);
            //if (dtgrid_hourly_inbound.Rows.Count > 0)
            ChangeHederColumn_outbound();
            btn_search_outbound.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        private void btn_search_inbound_Click(object sender, EventArgs e)
        {
            exporthourlyinbound = new ExportHourlyInbound();
            btn_search_inbound.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;
            string _dte_from = dte_from_inbound.Value.ToString("yyyy-MM-dd");
            int user_id = cmb_username_in.Text == "" ? 0 : Convert.ToInt32(cmb_username_in.SelectedValue);
            //exporthourlyinbound.myReport = reporthourly_dao.GetListHourlyInbound(_dte_from, user_id);
            exporthourlyinbound.dtreport = reporthourly_dao.DynamicReportHourlyCallInbound(_dte_from, user_id);
            dtgrid_hourly_inbound.DataSource = exporthourlyinbound.dtreport;
            lbl_row_inbound.Text = dtgrid_hourly_inbound.Rows.Count.ToString() + " LIST";
            Global.ChangeColorGrid(dtgrid_hourly_inbound);
            Global.ChangeHeaderGrid(dtgrid_hourly_inbound);
            //if (dtgrid_hourly_inbound.Rows.Count > 0)
            //ChangeHederColumn_inbound();
            btn_search_inbound.Enabled = true;
            Cursor.Current = Cursors.Default;
        
        }

        private void btn_export_inbound_Click(object sender, EventArgs e)
        {
            if (dtgrid_hourly_inbound.Rows.Count != 0)
            {

                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.AddExtension = true;
                saveFile.Title = "Save Report Excel";
                saveFile.OverwritePrompt = true;

                saveFile.Filter = "Excel FIle|*.xlsx";
                saveFile.ValidateNames = true;
                saveFile.FileName = System.DateTime.Now.ToString("dd-MM-yyyy") + "- Report Hourly Inbound";
                if (saveFile.ShowDialog() != DialogResult.Cancel)
                {
                    exporthourlyinbound.GenerateReport(Global.ReplaceInvalidFileNameChars(saveFile.FileName.Replace(".xlsx", "")));
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
            if (dtgrid_hourly_outbound.Rows.Count != 0)
            {

                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.AddExtension = true;
                saveFile.Title = "Save Report Excel";
                saveFile.OverwritePrompt = true;

                saveFile.Filter = "Excel FIle|*.xlsx";
                saveFile.ValidateNames = true;
                saveFile.FileName = System.DateTime.Now.ToString("dd-MM-yyyy") + "- Report Hourly Outbound";
                if (saveFile.ShowDialog() != DialogResult.Cancel)
                {
                    exporthourluoutbound.GenerateReport(Global.ReplaceInvalidFileNameChars(saveFile.FileName.Replace(".xlsx", "")));
                    if (MessageBox.Show("Export data sukses" + System.Environment.NewLine + "Look at folder?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        this.UseWaitCursor = false;
                        System.Diagnostics.Process.Start("explorer.exe", System.IO.Path.GetDirectoryName(saveFile.FileName));
                    }

                }
            }
            else { MessageBox.Show("Please Searcing Data"); }
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

        private void ReportHourly_Load(object sender, EventArgs e)
        {
            LoadUserNameIn();
            LoadUserNameOut();

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


    }
}
