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
    public partial class Report : Form
    {
        private bool fillcall = false;
        private bool fillhourly = false;
        private bool filldaily = false;
        private bool fillsms = false;
        private bool fillemail = false;
        private bool fillperformance = false;
        private bool fillbrek = false;
        private bool filllogin = false;
        private bool fillvoicemail= false;
        private bool fillpbx = false;
        public Report()
        {
            InitializeComponent();
            TabpageControl();
        }

        private void TabpageControl()
        {
            tabControl_Report.Controls.Remove(tabPage_Call);
            tabControl_Report.Controls.Remove(tabPage_Hourly);
            tabControl_Report.Controls.Remove(tabPage_Daily); 
            tabControl_Report.Controls.Remove(tabPage_Performance);
            tabControl_Report.Controls.Remove(tabPage_Sms);
            tabControl_Report.Controls.Remove(tabPage_Email);
            tabControl_Report.Controls.Remove(tabPage_Break);
            tabControl_Report.Controls.Remove(tabPage_Login);
            tabControl_Report.Controls.Remove(tabPage_VoicMail);
            tabControl_Report.Controls.Remove(tabPage_PBX);
            //tabControl_Master.Controls.Add(tbpage);
        }

        private void callToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            //Change Tabpage
            TabpageControl();
            //Change Button color
            //DefaultColorButton(TL_panel_dsboard);
            //lbl_modul.Text = btn_main_dashboard.Text;

            var reportcall = new View.ReportCall();
            reportcall.TopLevel = false;
            reportcall.Visible = true;
            reportcall.Dock = DockStyle.Fill;
            if (!fillcall)
            { tabPage_Call.Controls.Add(reportcall); fillcall = true; }
            else
            { tabPage_Call.Controls.RemoveAt(0); tabPage_Call.Controls.Add(reportcall); }
            tabControl_Report.Controls.Add(tabPage_Call);
            Cursor.Current = Cursors.Default;
        }

        private void hourlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            //Change Tabpage
            TabpageControl();
            //Change Button color
            //DefaultColorButton(TL_panel_dsboard);
            //lbl_modul.Text = btn_main_dashboard.Text;

            var reporthourly = new View.ReportHourly();
            reporthourly.TopLevel = false;
            reporthourly.Visible = true;
            reporthourly.Dock = DockStyle.Fill;
            if (!fillhourly)
            { tabPage_Hourly.Controls.Add(reporthourly); fillhourly = true; }
            else
            { tabPage_Hourly.Controls.RemoveAt(0); tabPage_Hourly.Controls.Add(reporthourly); }
            tabControl_Report.Controls.Add(tabPage_Hourly);
            Cursor.Current = Cursors.Default;
        }

        private void dailyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            //Change Tabpage
            TabpageControl();
            //Change Button color
            //DefaultColorButton(TL_panel_dsboard);
            //lbl_modul.Text = btn_main_dashboard.Text;

            var reportdaily = new View.ReportDaily();
            reportdaily.TopLevel = false;
            reportdaily.Visible = true;
            reportdaily.Dock = DockStyle.Fill;
            if (!filldaily)
            { tabPage_Daily.Controls.Add(reportdaily); filldaily = true; }
            else
            { tabPage_Daily.Controls.RemoveAt(0); tabPage_Daily.Controls.Add(reportdaily); }
            tabControl_Report.Controls.Add(tabPage_Daily);
            Cursor.Current = Cursors.Default;
        }

        private void performanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            //Change Tabpage
            TabpageControl();
            //Change Button color
            //DefaultColorButton(TL_panel_dsboard);
            //lbl_modul.Text = btn_main_dashboard.Text;

            var reportperformance = new View.ReportPerformance();
            reportperformance.TopLevel = false;
            reportperformance.Visible = true;
            reportperformance.Dock = DockStyle.Fill;
            if (!fillperformance)
            { tabPage_Performance.Controls.Add(reportperformance); fillperformance = true; }
            else
            { tabPage_Performance.Controls.RemoveAt(0); tabPage_Performance.Controls.Add(reportperformance); }
            tabControl_Report.Controls.Add(tabPage_Performance);
            Cursor.Current = Cursors.Default;
        }

        private void smsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            //Change Tabpage
            TabpageControl();
            //Change Button color
            //DefaultColorButton(TL_panel_dsboard);
            //lbl_modul.Text = btn_main_dashboard.Text;

            var reportsms = new View.ReportSms();
            reportsms.TopLevel = false;
            reportsms.Visible = true;
            reportsms.Dock = DockStyle.Fill;
            if (!fillsms)
            { tabPage_Sms.Controls.Add(reportsms); fillsms = true; }
            else
            { tabPage_Sms.Controls.RemoveAt(0); tabPage_Sms.Controls.Add(reportsms); }
            tabControl_Report.Controls.Add(tabPage_Sms);
            Cursor.Current = Cursors.Default;
        }

        private void emailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            //Change Tabpage
            TabpageControl();
            //Change Button color
            //DefaultColorButton(TL_panel_dsboard);
            //lbl_modul.Text = btn_main_dashboard.Text;

            var reportemail = new View.ReportEmail();
            reportemail.TopLevel = false;
            reportemail.Visible = true;
            reportemail.Dock = DockStyle.Fill;
            if (!fillemail)
            { tabPage_Email.Controls.Add(reportemail); fillemail = true; }
            else
            { tabPage_Email.Controls.RemoveAt(0); tabPage_Email.Controls.Add(reportemail); }
            tabControl_Report.Controls.Add(tabPage_Email);
            Cursor.Current = Cursors.Default;
        }

        private void breakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            //Change Tabpage
            TabpageControl();
            //Change Button color
            //DefaultColorButton(TL_panel_dsboard);
            //lbl_modul.Text = btn_main_dashboard.Text;

            var reportbreak = new View.ReportBreak();
            reportbreak.TopLevel = false;
            reportbreak.Visible = true;
            reportbreak.Dock = DockStyle.Fill;
            if (!fillbrek)
            { tabPage_Break.Controls.Add(reportbreak); fillbrek = true; }
            else
            { tabPage_Break.Controls.RemoveAt(0); tabPage_Break.Controls.Add(reportbreak); }
            tabControl_Report.Controls.Add(tabPage_Break);
            Cursor.Current = Cursors.Default;
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            //Change Tabpage
            TabpageControl();
            //Change Button color
            //DefaultColorButton(TL_panel_dsboard);
            //lbl_modul.Text = btn_main_dashboard.Text;

            var reportlogin = new View.ReportLogin();
            reportlogin.TopLevel = false;
            reportlogin.Visible = true;
            reportlogin.Dock = DockStyle.Fill;
            if (!filllogin)
            { tabPage_Login.Controls.Add(reportlogin); filllogin = true; }
            else
            { tabPage_Login.Controls.RemoveAt(0); tabPage_Login.Controls.Add(reportlogin); }
            tabControl_Report.Controls.Add(tabPage_Login);
            Cursor.Current = Cursors.Default;
        }

        private void voiceMailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            //Change Tabpage
            TabpageControl();
            //Change Button color
            //DefaultColorButton(TL_panel_dsboard);
            //lbl_modul.Text = btn_main_dashboard.Text;

            var reportVoicemail = new View.ReportVoiceMail();
            reportVoicemail.TopLevel = false;
            reportVoicemail.Visible = true;
            reportVoicemail.Dock = DockStyle.Fill;
            if (!fillvoicemail)
            { tabPage_VoicMail.Controls.Add(reportVoicemail); fillvoicemail = true; }
            else
            { tabPage_VoicMail.Controls.RemoveAt(0); tabPage_VoicMail.Controls.Add(reportVoicemail); }
            tabControl_Report.Controls.Add(tabPage_VoicMail);
            Cursor.Current = Cursors.Default;
        }

        private void pBXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            TabpageControl();
            var reportpbx = new View.ReportPBX();
            reportpbx.TopLevel = false;
            reportpbx.Visible = true;
            reportpbx.Dock = DockStyle.Fill;
            if (!fillpbx)

            { tabPage_PBX.Controls.Add(reportpbx); fillpbx = true; }
            else
            { tabPage_PBX.Controls.RemoveAt(0); tabPage_PBX.Controls.Add(reportpbx); }
            tabControl_Report.Controls.Add(tabPage_PBX);
            Cursor.Current = Cursors.Default;
        }
    }
}
