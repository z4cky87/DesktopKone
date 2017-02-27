using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Contact_Center_Kone.Dao;
using Contact_Center_Kone.Utility;
using Contact_Center_Kone.Entity;

namespace Contact_Center_Kone.View
{
    public partial class MediaPlayer : Form
    {
        private MediaControl.AudioPlayer MyPlayer = new MediaControl.AudioPlayer();
        public string directory_temp = System.IO.Path.GetTempPath();
        public string folder_recording = "filerecording";
        LogVoiceMailDao logvoicemaildao = new LogVoiceMailDao();
        LogVoiceMail logvoicemail = new LogVoiceMail();
        public View.Main main_form;
        public View.FindVoiceMail findvoicemail;

        // API for Move Window
        [DllImportAttribute("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd,
            int Msg, int wParam, int lParam);
        // API for Move Window
        [DllImportAttribute("user32.dll")]
        private static extern bool ReleaseCapture();
        // API for Top Window
        [DllImportAttribute("user32.dll")]
        private static extern int SetWindowPos(IntPtr hWnd,int hWndInsertAfter, int x, int y, int cx, int cy, int wFlags);

        //const for moving form
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;
        //const for set form on top
        private const int HWND_TOPMOST = -1;
        private const int HWND_NOTOPMOST = -2;

        private string MusicFileName;
        private bool FoundIt;
        private int frmHeight;
        private int PanelTop;
        private bool Muted = true;
        private bool frmSmall = false;
        private bool CloseMe = false;
        private bool TopWin = false;

        public View.MediaPlayer mediaplayer;
        private int voice_mail_id = 0;


        public MediaPlayer(int id_voice = 0)
        {
            Application.DoEvents();
            InitializeComponent();
            
            voice_mail_id = id_voice;
            MyPlayer = new MediaControl.AudioPlayer();
            // PositionChanged event defined in MediaControl.dll
            MyPlayer.PositionChanged += new MediaControl.PositionEventHandler(Position_Tick);
        }

        public VoiceMailStatusFrom enumstatus;
        public enum VoiceMailStatusFrom
        {
            Inbox = 1,
            Create = 2,
            View = 3
        }

        private void Position_Tick(object sender, MediaControl.PositionChangedEventArgs e)
        {
            // set position
            this.tbPosition.Value = e.NewPosition;
            this.lblPosition.Text = MyPlayer.TimeCalculation(e.NewPosition);

            if (frmSmall == false && this.WindowState == FormWindowState.Normal)
                this.DrawSomething(); // draw random lines

            if (e.NewPosition == MyPlayer.Duration())
            {
                MyPlayer.Stop();
                // draw string
                this.DrawText();
                btnMute.Image = imageList1.Images[5];
                this.lblPosition.Text = "00:00:00";
                this.tbPosition.Value = 0;
            }
        }

        private void DrawSomething()
        {
            int PageWidth = PicView.Width;
            int PageHeight = PicView.Height;
            int yStart = PageHeight - 20;
            double Pi = Math.PI;

            if (Muted == false)
                MyPlayer.Volume = this.tbVolume.Value;

            MyPlayer.Volume = MyPlayer.Pause == true ? 0 : this.tbVolume.Value;

            /* you can use the following code instead previous line:
            if(MyPlayer.Pause == true)
                MyPlayer.Volume = 0;
            else
                MyPlayer.Volume = this.tbVolume.Value;
            */

            //ratio between PicView.Height and maximum of player volume
            double yRatio = Convert.ToDouble(PageHeight) / 1000;

            Graphics g;
            // Create graphics object
            g = PicView.CreateGraphics();
            System.Threading.Thread.Sleep(150); // waiting a moment before clear drawing
            g.Clear(PicView.BackColor);

            Random randNum = new Random();
            double W = PageWidth / 20;

            Pen NewPen = new Pen(Color.SteelBlue);
            SolidBrush brush = new SolidBrush(Color.SkyBlue);

            for (double X = -3 * Pi; X < 3 * Pi; X += 0.5)
            {
                double Z = Math.Sin(X);
                double Y = Math.Abs(Z);
                double PX = PageWidth / 2 + W * X; // Multiply X * W to enlarge X.
                int maxY = (int)(yRatio * MyPlayer.Volume);
                if (maxY < 40)
                    maxY = 40;
                double H = randNum.Next(5, maxY - 30); // Randome height:
                double PY = yStart - H * Y; // Multiply Y * H to enlarge Y.
                Point p1 = new Point((int)PX, PageHeight - 10);
                Point p2 = new Point((int)PX, (int)PY);
                // draw Line
                g.DrawLine(NewPen, p1, p2);
                Point dPoint = new Point((int)PX, (int)PY);
                dPoint.X = dPoint.X - 1;
                dPoint.Y = dPoint.Y - 10;
                Rectangle rect = new Rectangle(dPoint, new Size(3, 3));
                //using FillRectangle to draw a point
                g.FillRectangle(brush, rect);
            }

            // Release graphics object
            NewPen.Dispose();
            g.Dispose();
        }

        private void DrawText()
        {
            PicView.Image = null;

            int PageWidth = PicView.Width;
            int PageHeight = PicView.Height;

            // Initiate 'ImageToDraw' Object:
            Bitmap ImageToDraw = new Bitmap(PageWidth, PageHeight);
            // Create graphics object:
            Graphics g = Graphics.FromImage(ImageToDraw);
            // Draw "Hello World..." string:
            Font txtFont = new Font("Tahoma", 24, FontStyle.Bold);
            string txt = "Voice Mail...";
            g.DrawString(txt, txtFont, new SolidBrush(Color.SeaGreen), 20, 60);
            // Draw "Audio Player" string:
            txtFont = new Font("Monotype Corsiva", 18, FontStyle.Bold | FontStyle.Italic);
            txt = "Audio Player";
            g.DrawString(txt, txtFont, new SolidBrush(Color.Chocolate), 240, 100);

            // Display the bitmap:
            PicView.Image = ImageToDraw;
            // Release graphics object
            g.Dispose();
            ImageToDraw = null;
        }

        private void SetTopMostWindow(bool Topmost)
        {
            //Make the window topmost
            if (Topmost == true)
            {
                SetWindowPos(Handle, HWND_TOPMOST, 0, 0, 0, 0, 3);
                // you can use: this.TopMost = true;
            }
            else
            {
                SetWindowPos(Handle, HWND_NOTOPMOST, 0, 0, 0, 0, 3);
                // you can use: this.TopMost = false;
            }
        }

        private void SetButtons(bool Enable)
        {
            btnPlay.Enabled = Enable;
            btnPause.Enabled = Enable;
            btnStop.Enabled = Enable;
            btnMute.Enabled = Enable;
            tbPosition.Enabled = Enable;
            tbVolume.Enabled = Enable;
            btn_tagticket.Enabled = Enable;
            btn_outbound.Enabled = Enable;
        }

        public void GetTagNoTicket(string ticketno)
        {
            txt_no_ticket.Clear();
            txt_no_ticket.Text = ticketno;
        }
        private void LoadMusicFile()
        {
            DialogResult ResultDialog;
            FoundIt = false;
            try
            {
                this.OpenDialog.Filter = "Music Formats|" +
                    "*.mp3;*.ram;*.rm;*.wav;*.wma;*.mid|" +
                    "mp3 (*.mp3)|*.mp3|ram (*.ram)|*.ram|rm (*.rm)|*.rm|" +
                    "wav (*.wav)|*.wav|wma (*.wma)|*.wma|mid (*.mid)|*.mid";
                this.OpenDialog.RestoreDirectory = true;
                this.OpenDialog.FileName = "";
                this.OpenDialog.Title = "Choose Music File:";
                this.OpenDialog.CheckFileExists = true;
                this.OpenDialog.CheckPathExists = true;
                this.OpenDialog.Multiselect = false; //choose one file
                ResultDialog = OpenDialog.ShowDialog();
                if (ResultDialog == DialogResult.OK)
                {
                    MusicFileName = this.OpenDialog.FileName;
                    FoundIt = true;
                }
            }
            catch
            {
                string Msg = "Not Sound file, Search for another..!";
                MessageBox.Show(Msg);
                return;
            }
        }

        private void PlayMusicFile()
        {
            if (FoundIt)
            {
                this.SetButtons(true);
                if (MyPlayer.bFileIsOpen)
                {
                    MyPlayer.Close();
                }

                MyPlayer.Open(MusicFileName);

                if (MyPlayer.bFileIsOpen)
                {
                    MyPlayer.Play();
                    Muted = false;
                    btnMute.Image = imageList1.Images[4];
                    this.tbPosition.Maximum = MyPlayer.Duration();
                    this.lblDuration.Text = MyPlayer.TimeCalculation(MyPlayer.Duration());
                    this.tbVolume.Maximum = 1000;
                    this.tbVolume.Value = MyPlayer.Volume;
                }
            }
        }

        private void MediaPlayer_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.SetButtons(false);
                btnPlay.Enabled = true;
                frmHeight = this.Height;
                PanelTop = panel2.Top;
                this.DrawText();

                switch (enumstatus)
                {
                    case VoiceMailStatusFrom.Inbox:
                        load_Inbox();
                        btn_tagticket.Enabled = true;
                        btn_outbound.Enabled = true;
                        //findvoicemail.SearchList();
                        break;
                    case VoiceMailStatusFrom.Create:

                        break;
                    case VoiceMailStatusFrom.View:
                        load_view();
                        btn_tagticket.Enabled = true;
                        btn_outbound.Enabled = true;
                         findvoicemail.SearchList();
                        break;
                    default:
                        break;
                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        

        }

        private void load_Inbox()
        {
            try
            {
                FoundIt = false;
                MusicFileName = string.Empty;
                logvoicemail = logvoicemaildao.GetVoiceMail_ByVoiceRead();
                if (logvoicemail != null)
                {
                    if (Global.is_ExistFolder(directory_temp, folder_recording))
                    {
                        int indexof = logvoicemail.fullpath.IndexOf(".wav");
                        if (indexof > 0)
                        {
                            string filename = logvoicemail.fullpath.Split('/')[2];
                            string currDate = string.Format("{0:yyyy-MM-dd}", DateTime.Now);
                            if (Global.Http_File_isExist(@Global.location_voicemail + "//" + logvoicemail.fullpath, directory_temp + folder_recording + System.IO.Path.DirectorySeparatorChar + filename))
                            {
                                if (Global.is_ExistFolder(directory_temp, folder_recording))
                                {
                                    if (Global.File_isExist(directory_temp + folder_recording + System.IO.Path.DirectorySeparatorChar + filename))
                                    {
                                        if (logvoicemaildao.UpdateVoiceMailRead(logvoicemail.id))
                                        {
                                            MusicFileName = directory_temp + folder_recording + System.IO.Path.DirectorySeparatorChar + filename;
                                            lbl_filename.Text = "File Name :" + filename;
                                            FoundIt = true;
                                            MyPlayer.Close();
                                            this.PlayMusicFile();
                                            //btnPlay_Click(null, null);
                                        }
                                    }
                                    else
                                    {
                                        if (Global.DownloadFile(@Global.location_voicemail + "//" + logvoicemail.fullpath, directory_temp + folder_recording + System.IO.Path.DirectorySeparatorChar + filename))
                                        {
                                            if (logvoicemaildao.UpdateVoiceMailRead(logvoicemail.id))
                                            {
                                                MusicFileName = directory_temp + folder_recording + System.IO.Path.DirectorySeparatorChar + filename;
                                                lbl_filename.Text = "File Name :" + filename;
                                                FoundIt = true;
                                                MyPlayer.Close();
                                                this.PlayMusicFile();
                                                //btnPlay_Click(null, null);
                                            }
                                        }
                                    }

                                }

                            }
                            else
                            {
                                logvoicemaildao.UpdateVoiceMailRead_FileNotExist(logvoicemail.id);
                            }
                        }
                    }
                } 
            }
            catch (Exception ex)
            {
                 Global.WriteLog(Global.GetCurrentMethod(ex));
            }
         
        }

        private void load_view()
        {
            try
            {
                bool fileExist = false;
                FoundIt = false;
                MusicFileName = string.Empty;
                logvoicemail = logvoicemaildao.GetVoiceMail_ById(voice_mail_id);
                if (logvoicemail != null)
                {
                    int indexof = logvoicemail.fullpath.IndexOf(".wav");
                    if (indexof > 0)
                    {
                        string filename = logvoicemail.fullpath.Split('/')[2];
                        if (Global.File_isExist(@directory_temp + folder_recording + System.IO.Path.DirectorySeparatorChar + filename))
                        {
                            fileExist = true;
                            if (logvoicemail.voice_mailread == 1) 
                                if (logvoicemaildao.UpdateVoiceMailRead(logvoicemail.id))
                                { } 
                        }
                        else
                        {   
                            if (Global.Http_File_isExist(@Global.location_voicemail + "//" + logvoicemail.fullpath, directory_temp + folder_recording + System.IO.Path.DirectorySeparatorChar + filename))
                            {
                                fileExist = true;
                                if (Global.is_ExistFolder(directory_temp, folder_recording)) 
                                    if (Global.DownloadFile(@Global.location_voicemail + "//" + logvoicemail.fullpath, directory_temp + folder_recording + System.IO.Path.DirectorySeparatorChar + filename))
                                        if (logvoicemail.voice_mailread == 1) 
                                            if (logvoicemaildao.UpdateVoiceMailRead(logvoicemail.id))
                                            { }  

                            }
                        }

                        if (fileExist)
                        {
                            MusicFileName = directory_temp + folder_recording + System.IO.Path.DirectorySeparatorChar + filename;
                            lbl_filename.Text = "File Name :" + filename;
                            FoundIt = true;
                            MyPlayer.Close();
                            this.PlayMusicFile();
                            //btnPlay_Click(this, new EventArgs());
                        }
                        else
                        {
                            if (logvoicemaildao.UpdateVoiceMailRead_FileNotExist(logvoicemail.id))
                            { }
                        }



                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void lblLeft_MouseDown(object sender, MouseEventArgs e)
        {
            // move window
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            //this.LoadMusicFile();
            btnPlay.Enabled = true;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            this.PlayMusicFile();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (MyPlayer.Pause == false)
            {
                MyPlayer.Pause = true;
                Muted = true;
                btnMute.Image = imageList1.Images[5];
                this.tbPosition.Enabled = false;
                this.tbVolume.Enabled = false;
            }
            else
            {
                MyPlayer.Pause = false;
                Muted = false;
                btnMute.Image = imageList1.Images[4];
                this.tbPosition.Enabled = true;
                this.tbVolume.Enabled = true;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            MyPlayer.Close();
            Muted = true;
            this.lblDuration.Text = "00:00:00";
            this.lblPosition.Text = "00:00:00";
            this.tbPosition.Value = 0;
            this.tbVolume.Value = 0;
            this.tbPosition.Enabled = false;
            this.tbVolume.Enabled = false;
            btnMute.Image = imageList1.Images[5];
            this.DrawText();
        }

        private void tbVolume_Scroll(object sender, EventArgs e)
        {
            MyPlayer.Volume = this.tbVolume.Value;
        }

        private void btnMute_Click(object sender, EventArgs e)
        {
            if (Muted == false)
            {
                MyPlayer.SetAudioOff();
                btnMute.Image = imageList1.Images[5];
                Muted = true;
            }
            else
            {
                MyPlayer.SetAudioOn();
                btnMute.Image = imageList1.Images[4];
                Muted = false;
            }
        }

        private void btnResize_Click(object sender, EventArgs e)
        {
            if (frmSmall == true)
            {
                panel2.Top = PanelTop;
                btnResize.Image = imageList1.Images[6];
                this.FormBorderStyle = FormBorderStyle.Fixed3D;
                this.Height = frmHeight;
                int NewTop = (System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
                int NewLeft = (System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
                this.Location = new System.Drawing.Point(NewLeft, NewTop);
                PicView.Visible = true;
                frmSmall = false;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.Height = panel2.Height;
                panel2.Top = 0;
                int NewTop = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - 3 * this.Height + 16;
                int NewLeft = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - this.Width - 2;
                this.Location = new System.Drawing.Point(NewLeft, NewTop);
                btnResize.Image = imageList1.Images[7];
                PicView.Visible = false;
                frmSmall = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            bool ItPlay = false;
            bool CurrentTopWin = TopWin;

            if (TopWin)
            {
                SetTopMostWindow(false);
                lblRight.Text = "T";
            }

            if (MyPlayer.Status() == "playing")
            {
                ItPlay = true;
                MyPlayer.Pause = true;
                btnMute.Image = imageList1.Images[5];
            }
            this.Close();
            //DialogResult MyChoice;
            //string Msg = "Are you sure to exit AudioPlayer..?";
            //MyChoice = MessageBox.Show(Msg, "Audio Player...",
            //    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation,
            //    MessageBoxDefaultButton.Button2);
            //if (MyChoice == DialogResult.Yes)
            //{
            //    //Application.Exit();  
            //    this.Close();
            //}
            //else
            //{
            //    if (ItPlay)
            //    {
            //        MyPlayer.Pause = false;
            //        btnMute.Image = imageList1.Images[4];
            //    }
            //    CloseMe = true;
            //}

            if (CurrentTopWin)
                lblRight.Text = "N";
            else
                lblRight.Text = "T";
            SetTopMostWindow(CurrentTopWin);
        }

        private void lblRight_Click(object sender, EventArgs e)
        {
            // let window on top
            TopWin = !TopWin;

            if (TopWin)
                lblRight.Text = "N";
            else
                lblRight.Text = "T";

            SetTopMostWindow(TopWin);
        }

        private void tbPosition_Scroll(object sender, EventArgs e)
        {
            MyPlayer.Position = this.tbPosition.Value;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            MyPlayer.Close();
            Muted = true;
            this.lblDuration.Text = "00:00:00";
            this.lblPosition.Text = "00:00:00";
            this.tbPosition.Value = 0;
            this.tbVolume.Value = 0;
            this.tbPosition.Enabled = false;
            this.tbVolume.Enabled = false;
            btnMute.Image = imageList1.Images[5];
            this.DrawText();

            bool ItPlay = false;
            bool CurrentTopWin = TopWin;

            if (TopWin)
            {
                SetTopMostWindow(false);
                lblRight.Text = "T";
            }

            if (MyPlayer.Status() == "playing")
            {
                ItPlay = true;
                MyPlayer.Pause = true;
                btnMute.Image = imageList1.Images[5];
            }
           
            //DialogResult MyChoice;
            //string Msg = "Are you sure to exit AudioPlayer..?";
            //MyChoice = MessageBox.Show(Msg, "Audio Player...",
            //    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation,
            //    MessageBoxDefaultButton.Button2);
            //if (MyChoice == DialogResult.Yes)
            //{
            //    //Application.Exit();  
            //    this.Close();
            //}
            //else
            //{
            //    if (ItPlay)
            //    {
            //        MyPlayer.Pause = false;
            //        btnMute.Image = imageList1.Images[4];
            //    }
            //    CloseMe = true;
            //}

            if (CurrentTopWin)
                lblRight.Text = "N";
            else
                lblRight.Text = "T";
            SetTopMostWindow(CurrentTopWin);
            this.Close();
        }

        private void btn_tagticket_Click(object sender, EventArgs e)
        {
            try
            {
                View.FindTicket findticket = new FindTicket(logvoicemail.id);
                findticket.mediaplayer = this;
                findticket.enumtagticket = FindTicket.TagTicketSourceMedia.VoiceMail;
                findticket.ShowDialog();
            }
            catch (Exception Ex)
            {
                Global.WriteLog(Global.GetCurrentMethod(Ex));
            }
           
        }

        private void btn_outbound_Click(object sender, EventArgs e)
        { 
            if (Global.mainForm.outboundCallForm == null)
            {
                Global.mainForm.outboundCallForm = new View.OutboundCall(logvoicemail.phoneno, "3", voice_mail_id.ToString());
                Global.mainForm.outboundCallForm.ShowDialog();
            }
        }

        private void lblLeft_Click(object sender, EventArgs e)
        {

        }
    }
}
