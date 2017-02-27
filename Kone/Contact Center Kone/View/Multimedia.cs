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
    public partial class Multimedia : Form
    {
        private bool fillemail = false;
        private bool fillsms = false;
        private bool fillvoicemail = false;
        public Multimedia()
        {
            InitializeComponent();
            TabpageControl();
        }
        private void TabpageControl()
        {
            tabControl_Multimedia.Controls.Remove(tabPage_Email);
            tabControl_Multimedia.Controls.Remove(tabPage_Sms);
            tabControl_Multimedia.Controls.Remove(tabPage_VoiceMail); 
            //tabControl_Master.Controls.Add(tbpage);
        }

        private void eMAILToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            Cursor.Current = Cursors.WaitCursor;

            //Change Tabpage
            TabpageControl();
            //Change Button color
            //DefaultColorButton(TL_panel_dsboard);
            //lbl_modul.Text = btn_main_dashboard.Text;

            var findemail = new View.FindEmail();
            findemail.TopLevel = false;
            findemail.Visible = true;
            findemail.Dock = DockStyle.Fill;
            if (!fillemail)
            { tabPage_Email.Controls.Add(findemail); fillemail = true; }
            else
            { tabPage_Email.Controls.RemoveAt(0); tabPage_Email.Controls.Add(findemail); }
            tabControl_Multimedia.Controls.Add(tabPage_Email);
            //findemail.Search_list();
            Cursor.Current = Cursors.Default;
            
        }

        private void sMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            //Change Tabpage
            TabpageControl();
            //Change Button color
            //DefaultColorButton(TL_panel_dsboard);
            //lbl_modul.Text = btn_main_dashboard.Text;

            var findsms = new View.FindSms();
            findsms.TopLevel = false;
            findsms.Visible = true;
            findsms.Dock = DockStyle.Fill;
            if (!fillsms)
            { tabPage_Sms.Controls.Add(findsms); fillsms = true; }
            else
            { tabPage_Sms.Controls.RemoveAt(0); tabPage_Sms.Controls.Add(findsms); }
            tabControl_Multimedia.Controls.Add(tabPage_Sms);
            //findsms.SearchList();
            Cursor.Current = Cursors.Default;
        }

        private void Multimedia_Load(object sender, EventArgs e)
        {

        }

        private void vOICEMAILToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            //Change Tabpage
            TabpageControl();
            //Change Button color
            //DefaultColorButton(TL_panel_dsboard);
            //lbl_modul.Text = btn_main_dashboard.Text;

            var findvoicemail = new View.FindVoiceMail();
            findvoicemail.TopLevel = false;
            findvoicemail.Visible = true;
            findvoicemail.Dock = DockStyle.Fill;
            if (!fillvoicemail)
            { tabPage_VoiceMail.Controls.Add(findvoicemail); fillvoicemail = true; }
            else
            { tabPage_VoiceMail.Controls.RemoveAt(0); tabPage_VoiceMail.Controls.Add(findvoicemail); }
            tabControl_Multimedia.Controls.Add(tabPage_VoiceMail);
            Cursor.Current = Cursors.Default;
        } 
    }
}
