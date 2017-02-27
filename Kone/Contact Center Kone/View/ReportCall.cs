using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Contact_Center_Kone.Dao;
using Contact_Center_Kone.Utility;
using Contact_Center_Kone.Entity;
using Contact_Center_Kone.Report;

namespace Contact_Center_Kone.View
{
    public partial class ReportCall : Form
    {
        ReportCallDao reportcalldao = new ReportCallDao();
        ExportCallInbound exportcallinbound = null;
        ExportCallOutbound exportcalloutbound = null;
        public ReportCall()
        {
            InitializeComponent();
        }

        private void ReportCall_Load(object sender, EventArgs e)
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

            cbx_callstatus_in.Checked = true;
            if (cbx_callstatus_in.Checked == true)
            {
                cmb_callstatus_in.SelectedIndex = -1;
                cmb_callstatus_in.Enabled = false;
            }
            else
            {
                cmb_callstatus_in.Enabled = true;
                LoadCallSatatusIn();
            }
        }

        void ChangeHederColumn()
        {
            this.dtgrid_reportcall.Columns[0].HeaderText = "Id";
            this.dtgrid_reportcall.Columns[0].Visible = false;

            this.dtgrid_reportcall.Columns[1].HeaderText = "Call Date";
            this.dtgrid_reportcall.Columns[1].Width = 150;

            this.dtgrid_reportcall.Columns[2].HeaderText = "Customer Name";
            this.dtgrid_reportcall.Columns[2].Width = 150;

            this.dtgrid_reportcall.Columns[3].HeaderText = "Agent Name";
            this.dtgrid_reportcall.Columns[3].Width = 150;

            this.dtgrid_reportcall.Columns[4].HeaderText = "Direction";
            this.dtgrid_reportcall.Columns[4].Width = 90;

            this.dtgrid_reportcall.Columns[5].HeaderText = "Call Status";
            this.dtgrid_reportcall.Columns[5].Width = 150;
             
            this.dtgrid_reportcall.Columns[6].HeaderText = "Shift";
            this.dtgrid_reportcall.Columns[6].Width = 90;

            this.dtgrid_reportcall.Columns[7].HeaderText = "Payment Method";
            this.dtgrid_reportcall.Columns[7].Width = 90;

            this.dtgrid_reportcall.Columns[8].HeaderText = "Blank Call";
            this.dtgrid_reportcall.Columns[8].Width = 90;

            this.dtgrid_reportcall.Columns[9].HeaderText = "Wrong Number";
            this.dtgrid_reportcall.Columns[9].Width = 90;

            this.dtgrid_reportcall.Columns[10].HeaderText = "host Addr";
            this.dtgrid_reportcall.Columns[10].Width = 90;

            this.dtgrid_reportcall.Columns[11].HeaderText = "Host Name";
            this.dtgrid_reportcall.Columns[11].Width = 90;

            this.dtgrid_reportcall.Columns[12].HeaderText = "Extension";
            this.dtgrid_reportcall.Columns[12].Width = 90;

            this.dtgrid_reportcall.Columns[13].HeaderText = "Duration";
            this.dtgrid_reportcall.Columns[13].Width = 90;

            this.dtgrid_reportcall.Columns[14].HeaderText = "Abandon";
            this.dtgrid_reportcall.Columns[14].Width = 90;

            this.dtgrid_reportcall.Columns[15].HeaderText = "Delay";
            this.dtgrid_reportcall.Columns[15].Width = 90;

            this.dtgrid_reportcall.Columns[16].HeaderText = "Busy";
            this.dtgrid_reportcall.Columns[16].Width = 90;

            this.dtgrid_reportcall.Columns[17].HeaderText = "Caller Number";
            this.dtgrid_reportcall.Columns[17].Width = 90;

            this.dtgrid_reportcall.Columns[18].HeaderText = "Note";
            this.dtgrid_reportcall.Columns[18].Width = 200;

            this.dtgrid_reportcall.Columns[19].HeaderText = "Phone Number";
            this.dtgrid_reportcall.Columns[19].Width = 90;

            this.dtgrid_reportcall.Columns[20].HeaderText = "Inbound Caller Type";
            this.dtgrid_reportcall.Columns[20].Width = 150;

            this.dtgrid_reportcall.Columns[21].HeaderText = "Inbound Type";
            this.dtgrid_reportcall.Columns[21].Width = 150;

            this.dtgrid_reportcall.Columns[22].HeaderText = "Inbound Type Detail";
            this.dtgrid_reportcall.Columns[22].Width = 150;
        }

        void LoadUserNameOut()
        {
            this.cmb_username_out.DataSource = reportcalldao.GetAllUserName();
            this.cmb_username_out.DisplayMember = "username";
            this.cmb_username_out.ValueMember = "id";
        }
        void LoadUserNameIn()
        {
            this.cmb_username_in.DataSource = reportcalldao.GetAllUserName();
            this.cmb_username_in.DisplayMember = "username";
            this.cmb_username_in.ValueMember = "id";
        }

        void LoadCallSatatusIn()
        {
            this.cmb_callstatus_in.DataSource = reportcalldao.GetAllCallStatus();
            this.cmb_callstatus_in.DisplayMember = "status";
            this.cmb_callstatus_in.ValueMember = "id";
        }
        void ChangeHederColumn_outbound()
        {
            //this.dtgrid_call_outbound.Columns[0].HeaderText = "Id";
            //this.dtgrid_call_outbound.Columns[0].Visible = false;

            //this.dtgrid_call_outbound.Columns[1].HeaderText = "Call Date";
            //this.dtgrid_call_outbound.Columns[1].Width = 150;

            //this.dtgrid_call_outbound.Columns[2].HeaderText = "Call Time";
            //this.dtgrid_call_outbound.Columns[2].Width = 150;

            //this.dtgrid_call_outbound.Columns[3].HeaderText = "User Login";
            //this.dtgrid_call_outbound.Columns[3].Width = 150;

            //this.dtgrid_call_outbound.Columns[4].HeaderText = "Direction";
            //this.dtgrid_call_outbound.Columns[4].Width = 150;

            //this.dtgrid_call_outbound.Columns[5].HeaderText = "Caller Type";
            //this.dtgrid_call_outbound.Columns[5].Width = 120;

            //this.dtgrid_call_outbound.Columns[6].HeaderText = "Call Status";
            //this.dtgrid_call_outbound.Columns[6].Width = 150;

            //this.dtgrid_call_outbound.Columns[7].HeaderText = "Call Status Detail";
            //this.dtgrid_call_outbound.Columns[7].Width = 150;

            //this.dtgrid_call_outbound.Columns[8].HeaderText = "Shift";
            //this.dtgrid_call_outbound.Columns[8].Width = 90;

            //this.dtgrid_call_outbound.Columns[9].HeaderText = "host Addr";
            //this.dtgrid_call_outbound.Columns[9].Width = 90;

            //this.dtgrid_call_outbound.Columns[10].HeaderText = "Host Name";
            //this.dtgrid_call_outbound.Columns[10].Width = 120;

            //this.dtgrid_call_outbound.Columns[11].HeaderText = "Extension";
            //this.dtgrid_call_outbound.Columns[11].Width = 90;

            //this.dtgrid_call_outbound.Columns[12].HeaderText = "Duration";
            //this.dtgrid_call_outbound.Columns[12].Width = 90;

            //this.dtgrid_call_outbound.Columns[13].HeaderText = "Caller Number";
            //this.dtgrid_call_outbound.Columns[13].Width = 120;

            //this.dtgrid_call_outbound.Columns[14].HeaderText = "Note";
            //this.dtgrid_call_outbound.Columns[14].Width = 200; 

        }
        private void btn_search_Click(object sender, EventArgs e)
        {
            exportcallinbound = new ExportCallInbound();
            btn_search.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;
            string _dte_from = dte_from.Value.ToString("yyyy-MM-dd");
            string _dte_until = dte_until.Value.ToString("yyyy-MM-dd");
            int user_id = cmb_username_in.Text == "" ? 0 : Convert.ToInt32(cmb_username_in.SelectedValue);
            int callstatus_id = cmb_callstatus_in.Text == "" ? 0 : Convert.ToInt32(cmb_callstatus_in.SelectedValue);
            Console.WriteLine("CMB username Get Value :" + cmb_username_in.SelectedValue);
            //exportcallinbound.myReport = reportcalldao.GetAll_call_inbound(_dte_from, _dte_until, user_id);
            //lbl_CountGrid_in.Text = dtgrid_reportcall.Rows.Count.ToString();
            //dtgrid_reportcall.DataSource = exportcallinbound.myReport;

            exportcallinbound.dtreport = reportcalldao.GetAll_Dynamic_inbound(_dte_from, _dte_until, user_id, callstatus_id); 
            dtgrid_reportcall.DataSource = exportcallinbound.dtreport;
            lbl_CountGrid_in.Text = dtgrid_reportcall.Rows.Count.ToString() + " LIST";
            Global.ChangeColorGrid(dtgrid_reportcall);
            Global.ChangeHeaderGrid(dtgrid_reportcall);
            //if (dtgrid_reportcall.Rows.Count > 0)
            //    ChangeHederColumn_outbound();
            btn_search.Enabled = true;
            Cursor.Current = Cursors.Default; 
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            if (dtgrid_reportcall.Rows.Count != 0)
            {

                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.AddExtension = true;
                saveFile.Title = "Save Report Excel";
                saveFile.OverwritePrompt = true;

                saveFile.Filter = "Excel FIle|*.xlsx";
                saveFile.ValidateNames = true;
                saveFile.FileName = System.DateTime.Now.ToString("dd-MM-yyyy") + "- Report Call Inbound";
                if (saveFile.ShowDialog() != DialogResult.Cancel)
                {
                    exportcallinbound.GenerateReport(Global.ReplaceInvalidFileNameChars(saveFile.FileName.Replace(".xlsx", "")));
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
         
        private void btn_search_outbound_Click(object sender, EventArgs e)
        {
            exportcalloutbound = new ExportCallOutbound();
            btn_search_outbound.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;
            string _dte_from = dte_from_outbound.Value.ToString("yyyy-MM-dd");
            string _dte_until = dte_until_outbound.Value.ToString("yyyy-MM-dd");
            int user_id = cmb_username_out.Text == "" ? 0 : Convert.ToInt32(cmb_username_out.SelectedValue);
            //exportcalloutbound.myReport = reportcalldao.GetAll_call_outbound(_dte_from, _dte_until, user_id);
            //dtgrid_call_outbound.DataSource = exportcalloutbound.myReport;

            exportcalloutbound.dtreport = reportcalldao.GetAll_Dynamic_outbound(_dte_from, _dte_until, user_id);
            dtgrid_call_outbound.DataSource = exportcalloutbound.dtreport;
            lbl_CountGrid_out.Text = dtgrid_call_outbound.Rows.Count.ToString() + " LIST";
            Global.ChangeColorGrid(dtgrid_call_outbound);
            Global.ChangeHeaderGrid(dtgrid_call_outbound);
            //if (dtgrid_reportcall.Rows.Count > 0)
           // ChangeHederColumn_outbound();
            btn_search_outbound.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        private void btn_export_outbound_Click(object sender, EventArgs e)
        {
            if (dtgrid_call_outbound.Rows.Count != 0)
            {

                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.AddExtension = true;
                saveFile.Title = "Save Report Excel";
                saveFile.OverwritePrompt = true;

                saveFile.Filter = "Excel FIle|*.xlsx";
                saveFile.ValidateNames = true;
                saveFile.FileName = System.DateTime.Now.ToString("dd-MM-yyyy") + "- Report Call Outbound";
                if (saveFile.ShowDialog() != DialogResult.Cancel)
                {
                    exportcalloutbound.GenerateReport(Global.ReplaceInvalidFileNameChars(saveFile.FileName.Replace(".xlsx", "")));
                    if (MessageBox.Show("Export data sukses" + System.Environment.NewLine + "Look at folder?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        this.UseWaitCursor = false;
                        System.Diagnostics.Process.Start("explorer.exe", System.IO.Path.GetDirectoryName(saveFile.FileName));
                    }

                }
            }
            else { MessageBox.Show("Please Searcing Data"); }
        }

        private void cbx_username_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx_username_in.Checked==true)
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

        private void cbx_callstatus_in_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx_callstatus_in.Checked == true)
            {
                cmb_callstatus_in.SelectedIndex = -1;
                cmb_callstatus_in.Enabled = false;
            }
            else
            {
                cmb_callstatus_in.Enabled = true;
                LoadCallSatatusIn();
            }
        }
    }
}
