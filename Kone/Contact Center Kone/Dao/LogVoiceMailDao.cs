using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contact_Center_Kone.Dao;
using Contact_Center_Kone.Entity;
using Contact_Center_Kone.Utility;
using MySql.Data.MySqlClient;

namespace Contact_Center_Kone.Dao
{
    public class LogVoiceMailDao
    {
        DbMyConnection Conn = new DbMyConnection();
        ListTicketDao listticketdao = new ListTicketDao();
        public List<LogVoiceMail> GetVoiceMail(string dtefrom, string dteuntil)
        {
            lock (Global.ThreadLockDao)
            {
                List<LogVoiceMail> list_logmail = new List<LogVoiceMail>();

                try
                {
                    string SQL = string.Empty;
                    SQL += "SELECT * FROM cc_log_voicemail ";
                    SQL += " LEFT JOIN cc_users ON cc_users.id = cc_log_voicemail.read_by";
                    SQL += " LEFT JOIN tickets ON tickets.id = cc_log_voicemail.ticket_id";
                    SQL += " WHERE DATE(datetime) BETWEEN '" + dtefrom + "' AND '" + dteuntil + "' ";
                    SQL += " ORDER BY cc_log_voicemail.id DESC";

                    Conn.MyConn.Open();
                    using (Conn.MyCommand = new MySqlCommand(SQL,Conn.MyConn))
                    {
                        using (Conn.MyReader = Conn.MyCommand.ExecuteReader())
                        {
                            if (Conn.MyReader.HasRows)
                            {
                                while (Conn.MyReader.Read())
                                {
                                    LogVoiceMail logvoicemail = new LogVoiceMail();
                                    logvoicemail.id = Convert.ToInt32(Conn.MyReader["id"]);
                                    logvoicemail.datetime = Conn.MyReader["datetime"].ToString();
                                    logvoicemail.uniqueid = Conn.MyReader["unique_id"].ToString();
                                    logvoicemail.fullpath = Conn.MyReader["fullpath"].ToString();
                                    logvoicemail.phoneno = Conn.MyReader["phone_no"].ToString();
                                    logvoicemail.voice_mailread = Convert.ToInt32(Conn.MyReader["voicemail_read"]);
                                    logvoicemail.voice_statusread = logvoicemail.voice_mailread == 1 ? "UNREAD" : "READ";
                                    logvoicemail.readbyname = Conn.MyReader["username"].ToString();
                                    logvoicemail.ticket_no = listticketdao.GetTicketNo_ByMediaId_SourceMediaId(Convert.ToInt32(Conn.MyReader["id"]), 3);
                                    list_logmail.Add(logvoicemail);
                                }
                            }
                        }
                    }
                }
                catch (Exception Ex)
                {
                    Global.WriteLog(Global.GetCurrentMethod(Ex));
                }finally
                {
                    Conn.MyConn.Close();
                }

                return list_logmail;
            }

        }

        public List<ReportVoiceMail> GetVoiceMailReport(string dtefrom, string dteuntil)
        {
            lock (Global.ThreadLockDao)
            {
                List<ReportVoiceMail> list_logmail = new List<ReportVoiceMail>();

                try
                {
                    string SQL = string.Empty;
                    SQL += "SELECT   cc_log_voicemail.datetime,cc_log_voicemail.unique_id,cc_log_voicemail.fullpath,";
                    SQL += "cc_log_voicemail.phone_no,cc_log_voicemail.voicemail_read,";
                    SQL += "cc_users.username,";
                    SQL += "tickets.ticket_no";
                    SQL += " FROM cc_log_voicemail ";
                    SQL += "LEFT JOIN cc_users ON cc_users.id = cc_log_voicemail.read_by ";
                    SQL += "LEFT JOIN tickets ON tickets.id = cc_log_voicemail.ticket_id";
                    SQL += " WHERE DATE(datetime) BETWEEN '" + dtefrom + "' AND '" + dteuntil + "' ";
                    SQL += " ORDER BY cc_log_voicemail.id DESC";

                    Conn.MyConn.Open();
                    using (Conn.MyCommand = new MySqlCommand(SQL, Conn.MyConn))
                    {
                        using (Conn.MyReader = Conn.MyCommand.ExecuteReader())
                        {
                            if (Conn.MyReader.HasRows)
                            {
                                while (Conn.MyReader.Read())
                                {
                                    ReportVoiceMail logvoicemail = new ReportVoiceMail(); 
                                    logvoicemail.datetime = Conn.MyReader["datetime"].ToString();
                                    logvoicemail.uniqueid = Conn.MyReader["unique_id"].ToString();
                                    logvoicemail.fullpath = Conn.MyReader["fullpath"].ToString();
                                    logvoicemail.phoneno = Conn.MyReader["phone_no"].ToString();
                                    logvoicemail.voice_statusread = Convert.ToInt32(Conn.MyReader["voicemail_read"]) == 1 ? "UNREAD" : "READ";
                                    logvoicemail.username = Conn.MyReader["username"].ToString();
                                    logvoicemail.ticket_no = Conn.MyReader["ticket_no"].ToString();
                                    list_logmail.Add(logvoicemail);
                                }
                            }
                        }
                    }
                }
                catch (Exception Ex)
                {
                    Global.WriteLog(Global.GetCurrentMethod(Ex));
                }
                finally
                {
                    Conn.MyConn.Close();
                }

                return list_logmail;
            }

        }

        public int GetCount_NotReadVoicemail()
        {
            lock (Global.ThreadLockDao)
            {
                int RetVal = 0;
                try
                {
                    string SQL = string.Empty;

                    SQL += "SELECT COUNT(id) AS total FROM cc_log_voicemail WHERE voicemail_read=1 ";

                    Conn.MyConn.Open();
                    using (Conn.MyCommand = new MySqlCommand(SQL,Conn.MyConn))
                    {
                        using (Conn.MyReader = Conn.MyCommand.ExecuteReader())
                        {
                            if (Conn.MyReader.HasRows)
                            {
                                if (Conn.MyReader.Read())
                                {
                                    RetVal = Convert.ToInt32(Conn.MyReader["total"]);
                                }
                            }
                        }
                    }
                }
                catch (Exception Ex)
                {
                    Global.WriteLog(Global.GetCurrentMethod(Ex));
                }
                finally
                {
                    Conn.MyConn.Close();
                }
                return RetVal;
            }
        }

        public LogVoiceMail GetVoiceMail_ByVoiceRead()
        {
            lock (Global.ThreadLockDao)
            {
                LogVoiceMail logvoicemail = null;


                try
                {
                    string SQL = string.Empty;
                    SQL += "SELECT * FROM cc_log_voicemail ";
                    SQL += " WHERE voicemail_read=1";
                    SQL += " ORDER BY id DESC LIMIT 1";

                    Conn.MyConn.Open();

                    using (Conn.MyCommand = new MySqlCommand(SQL, Conn.MyConn))
                    {
                        using (Conn.MyReader = Conn.MyCommand.ExecuteReader())
                        {
                            if (Conn.MyReader.HasRows)
                            {
                                if (Conn.MyReader.Read())
                                {
                                    logvoicemail = new LogVoiceMail();
                                    logvoicemail.id = Convert.ToInt32(Conn.MyReader["id"]);
                                    logvoicemail.datetime = Conn.MyReader["datetime"].ToString();
                                    logvoicemail.phoneno = Conn.MyReader["phone_no"].ToString();
                                    logvoicemail.fullpath = Conn.MyReader["fullpath"].ToString();
                                    logvoicemail.uniqueid = Conn.MyReader["unique_id"].ToString();
                                    logvoicemail.voice_mailread = Convert.ToInt32(Conn.MyReader["voicemail_read"]);
                                }
                            }
                        }
                    }


                }
                catch (Exception ex)
                {
                    Global.WriteLog(Global.GetCurrentMethod(ex));
                }
                finally
                {
                    Conn.MyConn.Close();
                }

                return logvoicemail;
            }
        }

        public bool UpdateVoiceMailRead(int voicemail_id)
        {
            lock (Global.ThreadLockDao)
            {
                int RetVal = 0;

                try
                {
                    string SQL = string.Empty;
                    SQL += "UPDATE cc_log_voicemail SET voicemail_read=2, read_by=" + Global.userAccount.id + " WHERE id = " + voicemail_id + " LIMIT 1";

                    Conn.MyConn.Open();
                    using (Conn.MyCommand = new MySqlCommand(SQL, Conn.MyConn))
                    {
                        RetVal = Conn.MyCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception Ex)
                {
                    Global.WriteLog(Global.GetCurrentMethod(Ex));
                }
                finally
                {
                    Conn.MyConn.Close();
                }

                return RetVal > 0;
            }
        }

        public bool UpdateVoiceMailRead_FileNotExist(int voicemail_id)
        {
            lock (Global.ThreadLockDao)
            {
                int RetVal = 0;

                try
                {
                    string SQL = string.Empty;
                    SQL += "UPDATE cc_log_voicemail SET voicemail_read=2,record_notexist=2, read_by=" + Global.userAccount.id + " WHERE id = " + voicemail_id + " LIMIT 1";

                    Conn.MyConn.Open();
                    using (Conn.MyCommand = new MySqlCommand(SQL, Conn.MyConn))
                    {
                        RetVal = Conn.MyCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception Ex)
                {
                    Global.WriteLog(Global.GetCurrentMethod(Ex));
                }
                finally
                {
                    Conn.MyConn.Close();
                }

                return RetVal > 0;
            }
        }
        public LogVoiceMail GetVoiceMail_ById(int id)
        {
            lock (Global.ThreadLockDao)
            {
                LogVoiceMail logvoicemail = null;


                try
                {
                    string SQL = string.Empty;
                    SQL += "SELECT * FROM cc_log_voicemail ";
                    SQL += " WHERE id=" + id; 

                    Conn.MyConn.Open();

                    using (Conn.MyCommand = new MySqlCommand(SQL, Conn.MyConn))
                    {
                        using (Conn.MyReader = Conn.MyCommand.ExecuteReader())
                        {
                            if (Conn.MyReader.HasRows)
                            {
                                if (Conn.MyReader.Read())
                                {
                                    logvoicemail = new LogVoiceMail();
                                    logvoicemail.id = Convert.ToInt32(Conn.MyReader["id"]);
                                    logvoicemail.datetime = Conn.MyReader["datetime"].ToString();
                                    logvoicemail.phoneno = Conn.MyReader["phone_no"].ToString();
                                    logvoicemail.fullpath = Conn.MyReader["fullpath"].ToString();
                                    logvoicemail.uniqueid = Conn.MyReader["unique_id"].ToString();
                                    logvoicemail.voice_mailread = Convert.ToInt32(Conn.MyReader["voicemail_read"]);
                                }
                            }
                        }
                    }


                }
                catch (Exception ex)
                {
                    Global.WriteLog(Global.GetCurrentMethod(ex));
                }
                finally
                {
                    Conn.MyConn.Close();
                }

                return logvoicemail;
            }
        }
    }
}
