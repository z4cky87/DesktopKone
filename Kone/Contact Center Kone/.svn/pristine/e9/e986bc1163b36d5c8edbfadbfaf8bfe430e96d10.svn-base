using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;
using System.Net;
using Tamir.SharpSsh;

using System.Text.RegularExpressions;
using CryptSharp;
using System.Collections.Specialized;
using System.IO;
using System.Net.Sockets;

namespace Contact_Center_Kone.Utility
{
    public static class Global
    {
        public static object ThreadLockDao = new Object();
        public static View.Main mainForm;
         
        public enum CrudMode
        {
            add,
            edit
        }
        public enum CallState
        {
            RINGING,
            INCALL,
            MUTE,
            HOLD,
            BUSY,
            READY,
            OFFLINE,
            OUTCALL 
        }

        public static CallState callState = new CallState();
        public static Entity.User userAccount = new Entity.User();
        public static string log_login_id = string.Empty;
        public static string defaultPassword = "toshiba1234";
        public static string hashPassword = "";

        public static string MessageAddSuccess = "Save data success.";
        public static string MessageAddErrorr = "Save data error.";
        public static string MessageEditSuccess = "Edit data success.";
        public static string MessageEditErrorr = "Edit data error.";
        public static string MessageDeleteSuccess = "Delete data success.";
        public static string MessageDeleteErrorr = "Delete data error.";

        public static string sftp_host = (ConfigurationSettings.AppSettings["sftp_host"]);
        public static string sftp_user = (ConfigurationSettings.AppSettings["sftp_user"]);
        public static string sftp_pwd = (ConfigurationSettings.AppSettings["sftp_pwd"]);
        public static string atacchment_inbox = (ConfigurationSettings.AppSettings["atacchment_inbox"]);
        public static string atacchment_outbox = (ConfigurationSettings.AppSettings["atacchment_outbox"]);
        public static string location_voicemail = (ConfigurationSettings.AppSettings["location_voicemail"]);
        public static string atacchment_inbox_http = (ConfigurationSettings.AppSettings["attachment_http_inbox"]);
        public static string atacchment_outbox_http = (ConfigurationSettings.AppSettings["attachment_http_outbox"]);
        public static string mailattachment_upload_location = (ConfigurationSettings.AppSettings["attachment_http_outbox_php"]);
       // public static string atacchment_outbox_http_Phph = (ConfigurationSettings.AppSettings["attachment_http_outbox_php"]);
        public static string web_create_ticket = (ConfigurationSettings.AppSettings["web_create_ticket"]);
        public static string web_ticket_managment = (ConfigurationSettings.AppSettings["web_ticket_managment"]);

        public static string unique_id;//15-11
        public static string tempTokenUser = "";
        public static int shiftId = 0;

        public static string[] HoursReport = new string[] { 
            "00:00", "01:00", "02:00", "03:00", "04:00", "05:00", "06:00", "07:00", "08:00", "09:00", "10:00","11:00", 
            "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00", "19:00", "20:00", "21:00","22:00","23:00" };
        public static void WriteLog(string message, bool showToScreen = true)
        {
            lock (ThreadLockDao)
            {
                try
                {
                    string currDate = string.Format("{0:yyyy-MM-dd}", DateTime.Now);
                    string currDateTime = string.Format("{0:yyyy-MM-dd HH:mm:ss.ffff}", DateTime.Now);
                    string fileTitle = "ToshibaLog" + currDate + ".log";

                    System.IO.File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + System.IO.Path.DirectorySeparatorChar + "log" + System.IO.Path.DirectorySeparatorChar + fileTitle
                        , "[" + currDateTime + "]  " + message + Environment.NewLine);

                    if (showToScreen)
                    {
                        Console.WriteLine("[" + currDateTime + "]  " + message);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static string GetCurrentMethod(Exception ex)
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);
            MethodBase site = ex.TargetSite; 
            return sf.GetMethod().Name + " || " + ex.StackTrace + " || " + ex.Message;
        }

        public static void ChangeColorGrid(DataGridView dtgrid)
        {
            for (int i = 0; i < dtgrid.Rows.Count; i++)
            { 
                dtgrid.Rows[i].DefaultCellStyle.BackColor = i % 2 == 0 ? Color.White : Color.GreenYellow;
            }
        }

        public static void ChangeHeaderGrid(DataGridView dtgrid)
        { 
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
            style.ForeColor = Color.White;
            style.BackColor = Color.DeepSkyBlue;

            foreach (DataGridViewColumn column in dtgrid.Columns)
            {
                //column.HeaderCell.Value = column.Index.ToString();
                column.HeaderCell.Style = style;
                column.HeaderCell.Style.Font = new Font("Arial", 9, FontStyle.Bold);
            }
        }

        public static bool Http_File_isExist(string file_location,string url)
        {
            bool RetVal = false;
            try
            {
                HttpWebRequest req = (HttpWebRequest)System.Net.WebRequest.Create(file_location);                
                HttpWebResponse response = (HttpWebResponse)req.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    RetVal = true;
                }
            }
            catch (Exception Ex)
            {
                WriteLog(Global.GetCurrentMethod(Ex));
            }
            return RetVal;
        }

        public static bool File_isExist(string path)
        {
            bool RetVal = false;

            try
            {
                if (File.Exists(path))
                {
                    RetVal = true;
                }
            }
            catch (Exception Ex)
            {
                WriteLog(GetCurrentMethod(Ex));
            } 
            return RetVal;
        }

        public static bool File_Delete(string file_location, string url)
        {
            bool RetVal = false;
            try
            {
                HttpWebRequest req = (HttpWebRequest)System.Net.WebRequest.Create(file_location + url);
                req.Method = "DELETE";
                HttpWebResponse response = (HttpWebResponse)req.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    RetVal = true;
                }
            }
            catch (Exception Ex)
            {
                WriteLog(Global.GetCurrentMethod(Ex));
            }
            return RetVal;
        }

        public static void ChangePermissionFolder(string commandToExecInServer)
        {
            SshExec myExec = new SshExec(sftp_host, sftp_user, sftp_pwd);
            myExec.Connect();
            if (myExec.Connected)
            {
                try
                {
                    myExec.RunCommand("chmod -R 777 " + commandToExecInServer);
                }
                catch (Exception ex)
                {
                    WriteLog(GetCurrentMethod(ex));
                }
                finally { myExec.Close(); }
            }
            //else { MessageBox.Show("error"); }

        }

        public static void UploadingFile(string mailid, string pathfile)
        {
            var sftp = new Sftp(sftp_host, sftp_user, sftp_pwd);
            //sftp.OnTransferStart += new FileTransferEvent(sftp_OnTransferStart);
            //sftp.OnTransferEnd += new FileTransferEvent(sftp_OnTransferEnd);
            //sftp.OnTransferProgress += new FileTransferEvent(sftp_OnTransferProgress);

            try
            {
                string a = string.Empty, b = string.Empty;
                sftp.Connect(22);
                sftp.Put(pathfile, atacchment_outbox + mailid); 
                sftp.Close();
                //Thread.CurrentThread.Join(); 
            }
            catch (Exception ex)
            {
                WriteLog(GetCurrentMethod(ex));
                // Thread.CurrentThread.Join();
                MessageBox.Show("Status : Upload attachment gagal");
            }
            finally { sftp.Close(); }

        }

        //public static void uploadingFilePost_Http(string folderid, string pathfile)
        //{
        //    try
        //    {
        //        System.Net.WebClient Client = new System.Net.WebClient();
        //        Client.Headers.Add("Content-Type", "binary/octet-stream");
                
        //        byte[] result = Client.UploadFile(atacchment_outbox_http_Phph + folderid, "POST", pathfile);
        //        string s = System.Text.Encoding.UTF8.GetString(result, 0, result.Length);

        //        MessageBox.Show(s);
        //    }
        //    catch (Exception Ex)
        //    {
        //        MessageBox.Show(Ex.Message);
        //    }
        //}

        public static void CreateFolder(string mailid)
        {
            var sftp = new Sftp(sftp_host, sftp_user, sftp_pwd);

            try
            {
                string a = string.Empty, b = string.Empty;
                sftp.Connect(22);
                sftp.Mkdir(atacchment_outbox + mailid);
                ChangePermissionFolder(atacchment_outbox + mailid);


                sftp.Close();
                //Thread.CurrentThread.Join(); 
            }
            catch (Exception ex)
            {
                WriteLog(GetCurrentMethod(ex));
                // Thread.CurrentThread.Join(); 
            }
            finally { sftp.Close(); }
        }

        public static bool CheckFolder(string location_folder)
        {
            bool result = false;
            var sftp = new Sftp(sftp_host, sftp_user, sftp_pwd);

            try
            {

                sftp.Connect(22);
                var dataserver = sftp.GetFileList(location_folder);
                result = true;
            }
            catch (Exception ex)
            {
                WriteLog(GetCurrentMethod(ex));
                result = false;

            }
            finally { sftp.Close(); }
            return result;
        }

        public static bool CheckFile(string filelocation, string filename)
        {
            bool result = false;
            var sftp = new Sftp(sftp_host, sftp_user, sftp_pwd);

            try
            {

                sftp.Connect(22);
                var dataserver = sftp.GetFileList(filelocation + "//" + filename);
                result = true;
            }
            catch (Exception ex)
            {
                WriteLog(GetCurrentMethod(ex));
                result = false;

            }
            finally { sftp.Close(); }
            return result;
        }

        public static bool DonwloadFile(string mailid,string filename, string pathdownload)
        {
            bool RetVal = false;
            var sftp = new Sftp(sftp_host, sftp_user, sftp_pwd);
            sftp.Connect(22);
            if (CheckFile(atacchment_inbox + mailid, filename))
            {
                sftp.Get(atacchment_inbox + mailid + "//" + filename, pathdownload);
                //MessageBox.Show("File Exist");
                RetVal = true;
            }
            else
            {
                MessageBox.Show("File Not Exist " + filename);
                RetVal = true;
            }
            return RetVal;
        }

        public static string ReplaceInvalidFileNameChars(this string s, string replacement = "")
        {
            return Regex.Replace(s,
              "[" + Regex.Escape(new String(System.IO.Path.GetInvalidPathChars())) + "]",
              replacement, //can even use a replacement string of any length
              RegexOptions.IgnoreCase);
        }

        public static string EncryptPassword(string password)
        {
            return Crypter.Blowfish.Crypt(password, new CrypterOptions() { { CrypterOption.Variant, BlowfishCrypterVariant.Corrected }, { CrypterOption.Rounds, 10 } });
        }
        public static bool MatchPassword(string password,string encPassword)
        {
            return CryptSharp.Crypter.CheckPassword(password, encPassword);           
        }

        public static bool DownloadFile(string pathdwonload, string pathlocal)
        {
            bool RetVal = false;
            try
            {
                WebClient webClient = new WebClient();
                webClient.DownloadFile(new Uri(pathdwonload), pathlocal);
                RetVal = true;
            }
            catch (Exception Ex)
            {
                WriteLog(GetCurrentMethod(Ex));
            }
            return RetVal;
        }

        public static bool is_ExistFolder(string directory, string foldername)
        {
            bool RetVal = true;

            try
            {
                if (!Directory.Exists(directory + foldername))
                {
                    Directory.CreateDirectory(directory + foldername); 
                }

            }
            catch (Exception Ex)
            {
                WriteLog(GetCurrentMethod(Ex));
            }

            return RetVal;

        }
        public static string LocalIPAddress()
        {
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                    break;
                }
            }
            return localIP;
        }
        public static string LocalCompName()
        {
            return Dns.GetHostName();
        }
        public static String HttpPost(string uri, NameValueCollection data)
        {
            var result = "";
            try
            {
                WebClient webclient = new WebClient();             
                webclient.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/42.0.2311.135 Safari/537.36");
                byte[] responBytes = webclient.UploadValues(uri, "POST", data);                
                result = Encoding.UTF8.GetString(responBytes);
                webclient.Dispose();
            }
            catch (Exception ex) { WriteLog(Global.GetCurrentMethod(ex)); }
            return result;
        }
        public static String HttpGet(string uri)
        {
            WebClient webclient = new WebClient();
            byte[] responBytes = webclient.DownloadData(uri);
            string result = Encoding.UTF8.GetString(responBytes);
            webclient.Dispose();
            return result;
        }
        public static int GetStatusCode(WebClient client, out string statusDescription)
        {
            FieldInfo responseField = client.GetType().GetField("m_WebResponse", BindingFlags.Instance | BindingFlags.NonPublic);

            if (responseField != null)
            {
                HttpWebResponse response = responseField.GetValue(client) as HttpWebResponse;

                if (response != null)
                {

                    statusDescription = response.StatusDescription;
                    return (int)response.StatusCode;
                }
            }

            statusDescription = null;
            return 0;
        }
        public static int GetStatusCode(WebClient client)
        {
            FieldInfo responseField = client.GetType().GetField("m_WebResponse", BindingFlags.Instance | BindingFlags.NonPublic);

            if (responseField != null)
            {
                HttpWebResponse response = responseField.GetValue(client) as HttpWebResponse;

                if (response != null)
                {
                    //MessageBox.Show(response.Headers.ToString());
                    return (int)response.StatusCode;
                }
            }


            return 0;
        }

        public static void DisabledLabel(Control myControl)
        {
            foreach (System.Windows.Forms.Control x in myControl.Controls)
            {
                if (x is Label)
                {
                    x.Visible = false;
                }
            }
        }
        public static void EnabledLabel(Control myControl)
        {
            foreach (System.Windows.Forms.Control x in myControl.Controls)
            {
                if (x is Label)
                {
                    x.Visible = true;
                }
            }
        }
        public static void ClearTextbox( Control ctlParent)
        {
            //var tempControl=ctlToEnable;
            foreach (System.Windows.Forms.Control x in ctlParent.Controls)
            {
                if (x is TextBox)
                {
                    ((TextBox)x).Clear();
                }
            }
        }
        public static void KillApp(string fileName)
        {
            try
            {
                System.Diagnostics.Process[] myproc = System.Diagnostics.Process.GetProcessesByName(fileName);
                foreach (System.Diagnostics.Process p in myproc)
                {
                    p.Kill();
                }
            }
            catch (Exception ex) { WriteLog(GetCurrentMethod(ex)); }
        }
        public static string LogDateTimeServer()
        {
            var connection = new Utility.DbMyConnection();
            string waktu = string.Empty;
            try
            {
                string sqlQuery = "select now() as logtime";
                connection.MyConn.Open();
                connection.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(sqlQuery, connection.MyConn);
                connection.MyReader = connection.MyCommand.ExecuteReader();
                connection.MyReader.Read();
                waktu = connection.MyReader[0].ToString();
            }
            catch (Exception ex) { WriteLog(GetCurrentMethod(ex)); }
            finally
            {
                connection.MyConn.Close();
            }
            return waktu;
        }

        public static bool uploadAttachmentFile(string id, string file_name)
        {
            bool retVal = false;

            try
            {
                var nvcParamValue = new NameValueCollection();
                nvcParamValue.Add("dir_name", id);
                var nvcFile = new NameValueCollection();
                nvcFile.Add("file", file_name);

                var result = sendHttpRequest(mailattachment_upload_location, nvcParamValue, nvcFile);
                retVal = result.Contains("success");
                Console.WriteLine("Upload Attachment :" + result);
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Upload Attachment :" + Ex.Message);
            }


            return retVal;

            //return Globals.httpUpload(Globals.faxOutboxUrl, file_name);
        }

        public static string sendHttpRequest(string url, NameValueCollection values, NameValueCollection files = null)
        {

            string boundary = "----------------------------" + DateTime.Now.Ticks.ToString("x");
            // The first boundary
            byte[] boundaryBytes = System.Text.Encoding.UTF8.GetBytes("\r\n--" + boundary + "\r\n");
            // The last boundary
            byte[] trailer = System.Text.Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");
            // The first time it itereates, we need to make sure it doesn't put too many new paragraphs down or it completely messes up poor webbrick
            byte[] boundaryBytesF = System.Text.Encoding.ASCII.GetBytes("--" + boundary + "\r\n");

            // Create the request and set parameters
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "multipart/form-data; boundary=" + boundary;
            request.Method = "POST";
            request.KeepAlive = true;
            request.Credentials = System.Net.CredentialCache.DefaultCredentials;

            // Get request stream
            Stream requestStream = request.GetRequestStream();

            foreach (string key in values.Keys)
            {

                // Write item to stream
                byte[] formItemBytes = System.Text.Encoding.UTF8.GetBytes(string.Format("Content-Disposition: form-data; name=\"{0}\";\r\n\r\n{1}", key, values[key]));
                requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);
                requestStream.Write(formItemBytes, 0, formItemBytes.Length);
            }

            if (files != null)
            {
                foreach (string key in files.Keys)
                {
                    if (File.Exists(files[key]))
                    {
                        int bytesRead = 0;
                        byte[] buffer = new byte[2048];
                        byte[] formItemBytes = System.Text.Encoding.UTF8.GetBytes(string.Format("Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: application/octet-stream\r\n\r\n", key, files[key]));
                        requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);
                        requestStream.Write(formItemBytes, 0, formItemBytes.Length);

                        using (FileStream fileStream = new FileStream(files[key], FileMode.Open, FileAccess.Read))
                        {
                            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                            {
                                // Write file content to stream, byte by byte
                                requestStream.Write(buffer, 0, bytesRead);
                            }

                            fileStream.Close();
                        }
                    }
                }
            }

            // Write trailer and close stream
            requestStream.Write(trailer, 0, trailer.Length);
            requestStream.Close();

            using (StreamReader reader = new StreamReader(request.GetResponse().GetResponseStream()))
            {
                return reader.ReadToEnd();
            };
        }

    }
}
