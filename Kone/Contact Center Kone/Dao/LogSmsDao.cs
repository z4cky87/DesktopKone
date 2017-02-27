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
    public class LogSmsDao
    {
        DbMyConnection Conn = new DbMyConnection();
        ListTicketDao listticketdao = new ListTicketDao();
        public List<LogSms> GetAllSms(string dtefrom, string dteuntil, int directionid, int statusid, string smsfrom)
        {
            lock (Global.ThreadLockDao)
            {
                List<LogSms> listlogsms = new List<LogSms>();
                string direction = directionid == -2 ? "" : " AND cc_log_sms.direction_id = " + directionid;
                string status = statusid == -2 ? "" : " AND cc_log_sms.sms_status_id = " + statusid;
                string like_smsfrom = smsfrom == "" ? "" : " AND cc_log_sms.sms_from LIKE '%" + smsfrom + "%'";
                try     
                {
                    string SQL = string.Empty;
                    SQL += " SELECT ";
                    SQL += " sms_id,";
                    SQL += " cc_log_sms.user_id AS userid,";
                    SQL += " cc_log_sms.sms_status_id AS statusid,";
                    SQL += " cc_log_sms.direction_id AS directionid,";
                    SQL += " cc_log_sms.ticket_id AS ticketid,";
                    SQL += " DATE_FORMAT(sms_date,'%d-%m-%Y') AS sms_date,";
                    SQL += " sms_time,";
                    SQL += " cc_users.username,";
                    SQL += " cc_sms_statuses.sms_status,";
                    SQL += " cc_directions.direction,";
                    SQL += " sms_read,sms_from,sms_to,sms_text,";
                    SQL += " cc_log_sms.sms_category_id,cc_sms_categories.name AS categoryname";
                    SQL += " FROM cc_log_sms";
                    SQL += " LEFT JOIN cc_users ON cc_users.id = cc_log_sms.user_id";
                    SQL += " LEFT JOIN cc_sms_statuses ON cc_sms_statuses.sms_status_id = cc_log_sms.sms_status_id";
                    SQL += " LEFT JOIN cc_directions ON cc_directions.id = cc_log_sms.direction_id";
                    SQL += " LEFT JOIN cc_sms_categories ON cc_sms_categories.id = cc_log_sms.sms_category_id";
                    SQL += " WHERE sms_date BETWEEN '" + dtefrom + "' AND '" + dteuntil + "' " + direction + status + like_smsfrom;
                    SQL += " ORDER BY sms_id DESC";
                    Conn.MyConn.Open();
                    using (Conn.MyCommand =  new MySqlCommand(SQL,Conn.MyConn))
                    {
                        using (Conn.MyReader = Conn.MyCommand.ExecuteReader())
                        {
                            if (Conn.MyReader.HasRows)
                            {
                                while (Conn.MyReader.Read())
                                {
                                    LogSms logsms = new LogSms();
                                    if (Conn.MyReader["sms_id"] != DBNull.Value)
                                        logsms.sms_id = Convert.ToInt32(Conn.MyReader["sms_id"]); 
                                    if (Conn.MyReader["userid"] != DBNull.Value)
                                        logsms.user_id = Convert.ToInt32(Conn.MyReader["userid"]);                                    
                                    if (Conn.MyReader["statusid"] != DBNull.Value)
                                        logsms.sms_status_id = Convert.ToInt32(Conn.MyReader["statusid"]); 
                                    if (Conn.MyReader["directionid"] != DBNull.Value) 
                                        logsms.direction_id = Convert.ToInt32(Conn.MyReader["directionid"]);  
                                    if (Conn.MyReader["ticketid"] != DBNull.Value)
                                        logsms.ticket_id = Convert.ToInt32(Conn.MyReader["ticketid"]);
                                    if (Conn.MyReader["sms_category_id"] != DBNull.Value)
                                        logsms.category_id = Convert.ToInt32(Conn.MyReader["sms_category_id"]); 
                                    
                                      logsms.sms_date = Conn.MyReader["sms_date"].ToString();
                                    logsms.sms_time = Conn.MyReader["sms_time"].ToString();
                                    logsms.sms_read = Convert.ToInt32(Conn.MyReader["sms_read"]);
                                    logsms.sms_from = Conn.MyReader["sms_from"].ToString();
                                    logsms.sms_to = Conn.MyReader["sms_to"].ToString();
                                    logsms.sms_text = Conn.MyReader["sms_text"].ToString();
                                    logsms.username_agent = Conn.MyReader["username"].ToString();
                                    logsms.sms_status = Conn.MyReader["sms_status"].ToString();
                                    logsms.sms_direction = Conn.MyReader["direction"].ToString();
                                    logsms.category_name = Conn.MyReader["categoryname"].ToString();
                                    
                                    logsms.ticketno = listticketdao.GetTicketNo_ByMediaId_SourceMediaId(Convert.ToInt32(Conn.MyReader["sms_id"]), 2);
                                    listlogsms.Add(logsms);
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

                return listlogsms;
            }
        } 
        public LogSms GetSms_byId(int id)
        {
            lock (Global.ThreadLockDao)
            {
                LogSms logsms = null;

                try
                {
                    string SQL = string.Empty;

                    SQL += " SELECT ";
                    SQL += " sms_id,";
                    SQL += " cc_log_sms.user_id AS userid,";
                    SQL += " cc_log_sms.sms_status_id AS statusid,";
                    SQL += " cc_log_sms.direction_id AS directionid,";
                    SQL += " cc_log_sms.ticket_id AS ticketid,";
                    SQL += " cc_log_sms.sms_category_id,";
                    SQL += " DATE_FORMAT(sms_date,'%d-%m-%Y') AS sms_date,";
                    SQL += " sms_time,";
                    SQL += " cc_users.username,";
                    SQL += " cc_sms_statuses.sms_status,";
                    SQL += " cc_directions.direction,";
                    SQL += " sms_read,sms_from,sms_to,sms_text";
                    SQL += " FROM cc_log_sms";
                    SQL += " LEFT JOIN cc_users ON cc_users.id = cc_log_sms.user_id";
                    SQL += " LEFT JOIN cc_sms_statuses ON cc_sms_statuses.sms_status_id = cc_log_sms.sms_status_id";
                    SQL += " LEFT JOIN cc_directions ON cc_directions.id = cc_log_sms.direction_id";
                    SQL += " WHERE sms_id=" + id;

                    Conn.MyConn.Open();
                    using (Conn.MyCommand = new MySqlCommand(SQL,Conn.MyConn))
                    {
                        using (Conn.MyReader = Conn.MyCommand.ExecuteReader())
                        {
                            if (Conn.MyReader.HasRows)
                            {
                                if (Conn.MyReader.Read())
                                {
                                    logsms = new LogSms();
                                    if (Conn.MyReader["sms_id"] != DBNull.Value)
                                        logsms.sms_id = Convert.ToInt32(Conn.MyReader["sms_id"]);
                                    if (Conn.MyReader["userid"] != DBNull.Value)
                                        logsms.user_id = Convert.ToInt32(Conn.MyReader["userid"]);
                                    if (Conn.MyReader["statusid"] != DBNull.Value)
                                        logsms.sms_status_id = Convert.ToInt32(Conn.MyReader["statusid"]);
                                    if (Conn.MyReader["directionid"] != DBNull.Value)
                                        logsms.direction_id = Convert.ToInt32(Conn.MyReader["directionid"]);
                                    if (Conn.MyReader["ticketid"] != DBNull.Value)
                                        logsms.ticket_id = Convert.ToInt32(Conn.MyReader["ticketid"]);
                                    if (Conn.MyReader["sms_category_id"] != DBNull.Value)
                                        logsms.category_id =  Convert.ToInt32(Conn.MyReader["sms_category_id"]);

                                    logsms.sms_date = Conn.MyReader["sms_date"].ToString();
                                    logsms.sms_time = Conn.MyReader["sms_time"].ToString();
                                    logsms.sms_read = Convert.ToInt32(Conn.MyReader["sms_read"]);
                                    logsms.sms_from = Conn.MyReader["sms_from"].ToString();
                                    logsms.sms_to = Conn.MyReader["sms_to"].ToString();
                                    logsms.sms_text = Conn.MyReader["sms_text"].ToString();
                                    logsms.username_agent = Conn.MyReader["username"].ToString();
                                    logsms.sms_status = Conn.MyReader["sms_status"].ToString();
                                    logsms.sms_direction = Conn.MyReader["direction"].ToString(); 
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

                return logsms;
            }
        } 
        public bool InsertSms(LogSms logsms)
        {
            lock (Global.ThreadLockDao)
            {
                int RetVal = 0;

                try
                {
                    string SQL = string.Empty;
                    SQL += "INSERT cc_log_sms SET ";
                    SQL += "sms_date=CURDATE(),";
                    SQL += "sms_time=CURTIME(),";
                    SQL += logsms.sms_to == null ? "" : "sms_to=@sms_to,";
                    SQL += logsms.sms_from == null ? "" : "sms_from=@sms_from,";
                    SQL += logsms.sms_text == null ? "" : "sms_text=@sms_text,";
                    SQL += logsms.direction_id == 0 ? "" : "direction_id=@direction_id,";
                    SQL += logsms.direction_id == -2 ? "" : "sms_category_id=@sms_category_id,";
                    SQL += logsms.user_id == 0 ? "" : "user_id=@user_id,";
                    SQL += logsms.ticket_id == 0 ? "" : "ticket_id=@ticket_id,"; 
                    SQL += "sms_read=@sms_read,"; 
                    SQL += "sms_status_id=@sms_status_id"; 

                    Conn.MyConn.Open();
                    using (Conn.MyCommand = new MySqlCommand())
                    {
                        using (Conn.MyCommand = Conn.MyConn.CreateCommand())
                        {
                            Conn.MyCommand.CommandText = SQL; 
                            if (logsms.sms_to != null)
                                Conn.MyCommand.Parameters.AddWithValue("@sms_to", logsms.sms_to);
                            if (logsms.sms_to != null)
                                Conn.MyCommand.Parameters.AddWithValue("@sms_from", logsms.sms_from);
                            if (logsms.sms_text != null)
                                Conn.MyCommand.Parameters.AddWithValue("@sms_text", logsms.sms_text);
                            if (logsms.ticket_id != 0)
                                Conn.MyCommand.Parameters.AddWithValue("@ticket_id", logsms.ticket_id); 
                            if (logsms.user_id != 0)
                                Conn.MyCommand.Parameters.AddWithValue("@user_id", logsms.user_id);
                            if (logsms.user_id != -2)
                                Conn.MyCommand.Parameters.AddWithValue("@sms_category_id", logsms.category_id);
                            Conn.MyCommand.Parameters.AddWithValue("@sms_status_id", logsms.sms_status_id);
                            Conn.MyCommand.Parameters.AddWithValue("@direction_id", logsms.direction_id);
                            Conn.MyCommand.Parameters.AddWithValue("@sms_read", logsms.sms_read);
                            RetVal = Conn.MyCommand.ExecuteNonQuery();
                        
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

                return RetVal > 0;
            }
        } 
        public int CountSms()
        {
            lock (Global.ThreadLockDao)
            {
                int RetVal = 0;

                try
                {
                    string SQL = string.Empty;
                    SQL += "SELECT COUNT(sms_id) AS total";
                    SQL += " FROM cc_log_sms";
                    SQL += " WHERE sms_read=1 AND direction_id=1";

                    Conn.MyConn.Open();
                    using (Conn.MyCommand = new MySqlCommand(SQL, Conn.MyConn))
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
        public LogSms GetSms_bySmsRead()
        {
            lock (Global.ThreadLockDao)
            {
                LogSms logsms = null;

                try
                {
                    string SQL = string.Empty;

                    SQL += "  SELECT  ";
                    SQL += " sms_id, ";
                    SQL += " cc_log_sms.user_id AS userid, ";
                    SQL += " cc_log_sms.sms_status_id AS statusid,";
                    SQL += " cc_log_sms.direction_id AS directionid,";
                    SQL += " cc_log_sms.ticket_id AS ticketid, ";
                    SQL += " DATE_FORMAT(sms_date,'%d-%m-%Y') AS sms_date,";
                    SQL += " sms_time, ";
                    SQL += " cc_users.username,";
                    SQL += " cc_sms_statuses.sms_status,";
                    SQL += " cc_directions.direction, ";
                    SQL += " sms_read,sms_from,sms_to,sms_text ";
                    SQL += " FROM cc_log_sms ";
                    SQL += " LEFT JOIN cc_users ON cc_users.id = cc_log_sms.user_id";
                    SQL += " LEFT JOIN cc_sms_statuses ON cc_sms_statuses.sms_status_id = cc_log_sms.sms_status_id ";
                    SQL += " LEFT JOIN cc_directions ON cc_directions.id = cc_log_sms.direction_id ";
                    SQL += " WHERE sms_read= 1 AND cc_log_sms.direction_id=1 ORDER BY sms_id DESC LIMIT 1 ;"; 

                    Conn.MyConn.Open();
                    using (Conn.MyCommand = new MySqlCommand(SQL, Conn.MyConn))
                    {
                        using (Conn.MyReader = Conn.MyCommand.ExecuteReader())
                        {
                            if (Conn.MyReader.HasRows)
                            {
                                if (Conn.MyReader.Read())
                                {
                                    logsms = new LogSms();
                                    if (Conn.MyReader["sms_id"] != DBNull.Value)
                                        logsms.sms_id = Convert.ToInt32(Conn.MyReader["sms_id"]);
                                    if (Conn.MyReader["userid"] != DBNull.Value)
                                        logsms.user_id = Convert.ToInt32(Conn.MyReader["userid"]);
                                    if (Conn.MyReader["statusid"] != DBNull.Value)
                                        logsms.sms_status_id = Convert.ToInt32(Conn.MyReader["statusid"]);
                                    if (Conn.MyReader["directionid"] != DBNull.Value)
                                        logsms.direction_id = Convert.ToInt32(Conn.MyReader["directionid"]);
                                    if (Conn.MyReader["ticketid"] != DBNull.Value)
                                        logsms.ticket_id = Convert.ToInt32(Conn.MyReader["ticketid"]);

                                    logsms.sms_date = Conn.MyReader["sms_date"].ToString();
                                    logsms.sms_time = Conn.MyReader["sms_time"].ToString();
                                    logsms.sms_read = Convert.ToInt32(Conn.MyReader["sms_read"]);
                                    logsms.sms_from = Conn.MyReader["sms_from"].ToString();
                                    logsms.sms_to = Conn.MyReader["sms_to"].ToString();
                                    logsms.sms_text = Conn.MyReader["sms_text"].ToString();
                                    logsms.username_agent = Conn.MyReader["username"].ToString();
                                    logsms.sms_status = Conn.MyReader["sms_status"].ToString();
                                    logsms.sms_direction = Conn.MyReader["direction"].ToString(); 
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

                return logsms;
            }
        } 
        public bool UpdateSmsRead(int smsid)
        {
            lock (Global.ThreadLockDao)
            {
                int RetVal = 0;

                try
                {
                    string SQL = string.Empty;
                    SQL += "UPDATE cc_log_sms SET sms_read=2, sms_status_id=5, user_id='" + Global.userAccount.id + "' WHERE sms_id = " + smsid +  " AND direction_id=1 LIMIT 1 ";

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

        public bool UpdateCategory(int mailid, string categoryId)
        {
            lock (Global.ThreadLockDao)
            {
                int RetVal = 0;

                try
                {
                    string SQL = string.Empty;
                    SQL += "UPDATE cc_log_sms SET sms_category_id=" + categoryId + "  WHERE sms_id = " + mailid + " LIMIT 1";

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
    
    
    }
}
