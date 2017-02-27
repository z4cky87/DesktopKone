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
using System.Threading;

namespace Contact_Center_Kone.View
{
    public partial class Break : Form
    {
        BreakReasonDao breakreasondao = new BreakReasonDao();
        LogBreakDao logbreakdao= new LogBreakDao();
        LogBreak logbreak ;
        CallDao callDao = new CallDao();//15-11
        Thread thread_break = null;
        private string breakid = string.Empty;
        public View.Main mainfrom;
        Dao.UserDao userDao = new Dao.UserDao();

        public Break()
        {
            InitializeComponent();
            load_reason();
            lbl_breaktime.Text = "Break Time";
            lbl_user.Text = Global.userAccount.username;
        }

        void load_reason()
        {
            cmb_break_reason.DataSource = breakreasondao.GetListbreakReason();
            cmb_break_reason.DisplayMember = "reason";
            cmb_break_reason.ValueMember = "id";
        }

        void Enable_object(bool active)
        {
            Gropbx_break_reason.Enabled = active;
            GroupBox_pwd.Enabled = active;
        }

        void Clear_object()
        {
            txt_note_reason.Clear();
            txt_enter_pwd.Clear();
        }

        void GetDataTex()
        {
            logbreak = new LogBreak();
            logbreak.user_id =Convert.ToInt32( Global.userAccount.id);
            logbreak.note = txt_note_reason.Text;
            logbreak.break_reason_id = Convert.ToInt32(cmb_break_reason.SelectedValue);
            
        }

        delegate void setLabelColorDelegate(Label label, Color color, string time);
        private void setLabelDuration(Label label, Color color, string time)
        {
            if (label.InvokeRequired)
            {
                setLabelColorDelegate d = new setLabelColorDelegate(setLabelDuration);
                this.Invoke(d, new Object[] { label, color, time });
            }
            else
            {
                label.ForeColor = color;
                label.Text = time;
            }
        }

        delegate void setLabelBreakDelegate(Label label, Color color, string time);
        private void setLabelBreaktime(Label label, Color color, string reason)
        {
            if (label.InvokeRequired)
            {
                setLabelBreakDelegate d = new setLabelBreakDelegate(setLabelBreaktime);
                this.Invoke(d, new Object[] { label, color, reason });
            }
            else
            {
                label.ForeColor = color;
                label.Text = reason;
            }
        }

        private void btn_break_Click(object sender, EventArgs e)
        {
            if (cmb_break_reason.Text != "")
            {
                callDao.UpdateCurrUniqeID(Global.userAccount.id);//15-11
                breakid = string.Empty;
                GetDataTex(); 
                breakid = logbreakdao.InsertLogBreak(logbreak);
                if (breakid != string.Empty || breakid != "")
                {
                 
                    Gropbx_break_reason.Enabled = false;
                    GroupBox_pwd.Enabled = true;
                    string xx = cmb_break_reason.Text;
                    thread_break = new Thread(() => BreakAction(xx));
                    thread_break.Start();
                  

                   mainfrom.cmb_chnge_sttus.SelectedIndex = 0;
                   mainfrom.btn_active_non_actived.PerformClick();
                    var userDao = new Dao.UserDao().ChangeActivityUser(Global.userAccount.id, "6");
                }
                else
                { MessageBox.Show("Insert Break Error"); }
            }
            else
            {
                MessageBox.Show("Plases Seleted Reason","Reason",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }


        private void BreakAction(string reason)
        {
            Color clor = Color.Yellow;
            Color clor2 = Color.Green;
            int span = 1;
            
            while (true)
            {
                
                if (clor == Color.Yellow)
                { clor = Color.Red; }
                else
                { clor = Color.Yellow; }
                if (clor2 == Color.Green)
                { clor2 = Color.Gold; }
                else
                { clor2 = Color.Green; }

                //TimeSpan span1 = TimeSpan.FromDays(1);
                //TimeSpan span2 = TimeSpan.FromHours(1);
                //TimeSpan span3 = TimeSpan.FromMinutes(1);
                TimeSpan span4 = TimeSpan.FromSeconds(span);
                //TimeSpan span5 = TimeSpan.FromMilliseconds(1);
                setLabelDuration(lbl__duration_breaktime, clor, span4.ToString());
                setLabelBreaktime(lbl_breaktime, clor2, "Break Time " + reason); 
                Thread.Sleep(1000);
                span++;
            }
        }

        private void btn_resume_break_Click(object sender, EventArgs e)
        {
            if (txt_enter_pwd.Text == "") { MessageBox.Show("Please Insert Your Password"); return;}
            
                if (logbreakdao.CheckInPasswordBreak(Global.userAccount.username, txt_enter_pwd.Text))
                {
                    logbreakdao.UpdateLogBreak(breakid);
                    logbreakdao.InsertLogin_TotalDuration(Convert.ToInt32(breakid));
                    if (thread_break != null) { thread_break.Abort(); }
                    userDao.ChangeActivityUser(Global.userAccount.id, "8");
                    this.Dispose();                    
                }
                else{
                    MessageBox.Show("Your Password Is Wrong");
                }
            
           
            
        }

        private void Break_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

    }
}
