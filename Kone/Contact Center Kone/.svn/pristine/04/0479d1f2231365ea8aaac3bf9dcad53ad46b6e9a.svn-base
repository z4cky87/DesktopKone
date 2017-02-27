using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contact_Center_Kone.Utility;
using Contact_Center_Kone.Entity;
using MySql.Data.MySqlClient;
using Contact_Center_Kone.Dao;

namespace Contact_Center_Kone.Dao
{
    public class LogMailDao
    {
        DbMyConnection Conn = new DbMyConnection();
        MailStatusDao mailstatusdao = new MailStatusDao();
        DirectionDao directiondao = new DirectionDao();
        UserDao userdao = new UserDao();
        ListTicketDao listticketdao = new ListTicketDao();





        public string InsertMail(LogMail logmail,bool attachment)
        {
            string RetVal = string.Empty;
            try
            {
                string SQL = string.Empty;
                SQL += "INSERT cc_log_mail SET ";
                SQL += "mail_date=CURDATE(),";
                SQL += "mail_time=CURTIME(),";
                SQL += logmail.mail_from == null ? "" : "mail_from=@mail_from,";
                SQL += logmail.mail_to == null ? "" : "mail_to=@mail_to,";
                SQL += logmail.mail_cc == null ? "" : "mail_cc=@mail_cc,";
                SQL += logmail.mail_bcc == null ? "" : "mail_bcc=@mail_bcc,";
                SQL += logmail.mail_subject == null ? "" : "mail_subject=@mail_subject,";
                SQL += logmail.mail_category_id == -2 ? "0" : "mail_category_id=@mail_category_id,";
                SQL += "mail_text=@mail_text,";
                SQL += "mail_read=@mail_read,";
                SQL += "mail_status_id=@mail_status_id,";
                SQL += "direction_id=@direction_id,";
                SQL += attachment == false ? "is_complete=@iscomplete," : "";  
                SQL += "user_id=@user_id;";

                
                SQL += "SELECT LAST_INSERT_ID() as lastid;";
                

                Conn.MyConn.Open();
                using (Conn.MyCommand = new MySqlCommand())
                {
                    using (Conn.MyCommand = Conn.MyConn.CreateCommand())
                    {
                        Conn.MyCommand.CommandText = SQL;
                        //Conn.MyCommand.Parameters.AddWithValue("@mail_date","CURDATE()");
                        //Conn.MyCommand.Parameters.AddWithValue("@mail_time", "CURTIME()");
                        if (logmail.mail_from != null)
                            Conn.MyCommand.Parameters.AddWithValue("@mail_from", logmail.mail_from);
                        if (logmail.mail_to != null)
                            Conn.MyCommand.Parameters.AddWithValue("@mail_to", logmail.mail_to);
                        if (logmail.mail_cc != null)
                            Conn.MyCommand.Parameters.AddWithValue("@mail_cc", logmail.mail_cc);
                        if (logmail.mail_bcc != null)
                            Conn.MyCommand.Parameters.AddWithValue("@mail_bcc", logmail.mail_bcc);
                        Conn.MyCommand.Parameters.AddWithValue("@mail_subject", logmail.mail_subject);
                        Conn.MyCommand.Parameters.AddWithValue("@mail_text", logmail.mail_text);
                        Conn.MyCommand.Parameters.AddWithValue("@mail_read", logmail.mail_read);
                        Conn.MyCommand.Parameters.AddWithValue("@mail_status_id", logmail.mail_status_id);
                        Conn.MyCommand.Parameters.AddWithValue("@direction_id", logmail.direction_id);
                        Conn.MyCommand.Parameters.AddWithValue("@iscomplete","1");
                        Conn.MyCommand.Parameters.AddWithValue("@user_id", logmail.user_id);
                        Conn.MyCommand.Parameters.AddWithValue("@mail_category_id", logmail.mail_category_id); 

                        using (Conn.MyReader = Conn.MyCommand.ExecuteReader())
                        {
                            if (Conn.MyReader.HasRows)
                            {
                                if (Conn.MyReader.Read())
                                {
                                    RetVal = Conn.MyReader["lastid"].ToString();
                                }
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
        public bool UpdateMail(LogMail logmail)
        {
            int RetVal = 0;

            try
            {

                string SQL = string.Empty;
                SQL += "UPDATE cc_logmail SET ";
                SQL += "mail_date=@mail_date,";
                SQL += "mail_time=@mail_time,";
                SQL += logmail.mail_from == null ? "" : "mail_from=@mail_from,";
                SQL += logmail.mail_to == null ? "" : "mail_to=@mail_to,";
                SQL += logmail.mail_cc == null ? "" : "mail_cc=@mail_cc,";
                SQL += logmail.mail_bcc == null ? "" : "mail_bcc=@mail_bcc,";
                SQL += "mail_subject=@mail_subject,";
                SQL += "mail_text=@mail_text,";
                SQL += "mail_read=@mail_read,";
                SQL += "mail_status_id=@mail_status_id,";
                SQL += "direction_id=@direction_id,";
                SQL += "user_id=@user_id,";
                SQL += "ticket_id=@ticket_id";
                SQL += " WHERE mail_id=@mail_id"
                ;

                using (Conn.MyCommand = Conn.MyConn.CreateCommand())
                {
                    Conn.MyCommand.CommandText = SQL;
                    Conn.MyCommand.Parameters.AddWithValue("@mail_id", logmail.id);
                    Conn.MyCommand.Parameters.AddWithValue("@mail_date",logmail.mail_date);
                    Conn.MyCommand.Parameters.AddWithValue("@mail_time", logmail.mail_time);
                    if (logmail.mail_from != null)
                        Conn.MyCommand.Parameters.AddWithValue("@mail_from", logmail.mail_from);
                    if (logmail.mail_to != null)
                        Conn.MyCommand.Parameters.AddWithValue("@mail_to", logmail.mail_to);
                    if (logmail.mail_cc != null) 
                        Conn.MyCommand.Parameters.AddWithValue("@mail_cc", logmail.mail_cc);
                    if (logmail.mail_bcc != null) 
                        Conn.MyCommand.Parameters.AddWithValue("@mail_bcc", logmail.mail_bcc);
                    Conn.MyCommand.Parameters.AddWithValue("@mail_subject", logmail.mail_subject);
                    Conn.MyCommand.Parameters.AddWithValue("@mail_text", logmail.mail_text);
                    Conn.MyCommand.Parameters.AddWithValue("@mail_read", logmail.mail_read);
                    Conn.MyCommand.Parameters.AddWithValue("@mail_status_id", logmail.mail_status_id);
                    Conn.MyCommand.Parameters.AddWithValue("@direction_id", logmail.direction_id);
                    Conn.MyCommand.Parameters.AddWithValue("@user_id", logmail.user_id); 
                    RetVal = Conn.MyCommand.ExecuteNonQuery();

                }

            }
            catch (Exception Ex)
            {
                Global.WriteLog(Global.GetCurrentMethod(Ex));
                
            }
            return RetVal > 0;
        }

        public List<LogMail> GetAll_mail(string datefrom, string dateuntil, int directionid, int statusid, string mailsubject)
        {
            lock (Global.ThreadLockDao)
            {
                List<LogMail> listlogmail = new List<LogMail>();
                string direction = directionid == -2 ? "" : " AND cc_log_mail.direction_id= " + directionid;
                string status = statusid == -2 ? "" : " AND cc_log_mail.mail_status_id= " + statusid;
                string like_mailsubject = mailsubject == "" ? "" : "  AND cc_log_mail.mail_subject LIKE '%" + mailsubject + "%'";
                try
                {
                    string SQL = string.Empty;
                    SQL += " SELECT ";
                    SQL += " cc_log_mail.mail_id,";
                    SQL += " cc_log_mail.mail_date,";
                    SQL += " cc_log_mail.mail_time,";
                    SQL += " cc_log_mail.mail_from,";
                    SQL += " cc_log_mail.mail_to,";
                    SQL += " cc_log_mail.mail_cc,";
                    SQL += " cc_log_mail.mail_bcc,";
                    SQL += " cc_log_mail.mail_subject,";
                    SQL += " cc_log_mail.mail_text,";
                    SQL += " cc_log_mail.mail_read,";
                    SQL += " cc_log_mail.mail_status_id,";
                    SQL += " cc_log_mail.direction_id,";
                    SQL += " cc_log_mail.mail_category_id,";
                    SQL += " cc_log_mail.user_id,";
                    SQL += " GROUP_CONCAT(tickets.ticket_no)  AS ticket_no,";
                    SQL += " cc_mail_statuses.mail_status,";
                    SQL += " cc_directions.direction,";
                    SQL += " cc_mail_categories.name AS category_name,";
                    SQL += " cc_users.username";
                    SQL += " FROM cc_log_mail ";
                    SQL += " LEFT JOIN cc_ticket_tags ON cc_ticket_tags.media_id = cc_log_mail.mail_id AND cc_ticket_tags.source_media_id = 1 ";
                    SQL += " LEFT JOIN tickets ON tickets.id = cc_ticket_tags.ticket_id ";
                    SQL += " LEFT JOIN cc_mail_statuses ON cc_mail_statuses.mail_status_id = cc_log_mail.mail_status_id";
                    SQL += " LEFT JOIN cc_directions ON cc_directions.id = cc_log_mail.direction_id";
                    SQL += " LEFT JOIN cc_mail_categories ON cc_mail_categories.id = cc_log_mail.mail_category_id";
                    SQL += " LEFT JOIN cc_users ON cc_users.id = cc_log_mail.user_id";
                    SQL += " WHERE mail_date BETWEEN '" + datefrom + "' AND '" + dateuntil + "' " + direction + status + like_mailsubject;
                    SQL +=  " GROUP BY cc_log_mail.mail_id";
                    SQL += " ORDER BY cc_log_mail.mail_id DESC";
                    Conn.MyConn.Open();
                    using (Conn.MyCommand = new MySqlCommand(SQL,Conn.MyConn))
                    {
                        using (Conn.MyReader = Conn.MyCommand.ExecuteReader())
                        {
                            if (Conn.MyReader.HasRows)
                            {
                                while (Conn.MyReader.Read())
                                {
                                    LogMail logmail = new LogMail();
                                    logmail.id = Convert.ToInt32(Conn.MyReader["mail_id"]);
                                    if ((Conn.MyReader["mail_read"]) != DBNull.Value)
                                    {
                                        logmail.mail_read = Convert.ToInt32(Conn.MyReader["mail_read"]);
                                    }
                                    if ((Conn.MyReader["mail_status_id"]) != DBNull.Value)
                                    {
                                        logmail.mail_status_id = Convert.ToInt32(Conn.MyReader["mail_status_id"]);
                                        logmail.mail_status_name = Conn.MyReader["mail_status"].ToString();
                                        //logmail.mail_status_name = mailstatusdao.GetStatus_ById(logmail.mail_status_id).mail_status;
                                    }
                                    if ((Conn.MyReader["direction_id"]) != DBNull.Value)
                                    {
                                        logmail.direction_id = Convert.ToInt32(Conn.MyReader["direction_id"]);
                                        logmail.direction_name = Conn.MyReader["direction"].ToString();
                                        // logmail.direction_name = directiondao.GetDirectionByID(logmail.direction_id).direction;
                                    }
                                    if ((Conn.MyReader["mail_category_id"]) != DBNull.Value)
                                    {
                                        logmail.mail_category_id = Convert.ToInt32(Conn.MyReader["mail_category_id"]);
                                        logmail.category_name = Conn.MyReader["category_name"].ToString(); 
                                    }
                                    if ((Conn.MyReader["user_id"]) != DBNull.Value)
                                    {
                                        logmail.user_id = Convert.ToInt32(Conn.MyReader["user_id"]);
                                        logmail.user_name = Conn.MyReader["username"].ToString(); 
                                    }

                                    logmail.mail_date = Conn.MyReader["mail_date"].ToString();
                                    logmail.mail_time = Conn.MyReader["mail_time"].ToString();
                                    logmail.mail_from = Conn.MyReader["mail_from"].ToString();
                                    logmail.mail_to = Conn.MyReader["mail_to"].ToString();
                                    logmail.mail_cc = Conn.MyReader["mail_cc"].ToString();
                                    logmail.mail_bcc = Conn.MyReader["mail_bcc"].ToString();
                                    logmail.mail_subject = Conn.MyReader["mail_subject"].ToString();
                                    logmail.mail_text = Conn.MyReader["mail_text"].ToString();
                                    logmail.ticket_no = Conn.MyReader["ticket_no"].ToString(); 
                                    // logmail.ticket_no = listticketdao.GetTicketNo_ByMediaId_SourceMediaId(Convert.ToInt32(Conn.MyReader["mail_id"]), 1);
                                    listlogmail.Add(logmail);
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

                return listlogmail;
            }
        }

        public LogMail Get_mail_ById(int id)
        {
            lock (Global.ThreadLockDao)
            {
                LogMail logmail = null;

                try
                {
                    string SQL = "SELECT *,DATE_FORMAT(mail_date,'%d-%m-%Y') AS mail_dates FROM cc_log_mail WHERE mail_id=" + id;

                    Conn.MyConn.Open();
                    using (Conn.MyCommand = new MySqlCommand(SQL, Conn.MyConn))
                    {
                        using (Conn.MyReader = Conn.MyCommand.ExecuteReader())
                        {
                            if (Conn.MyReader.HasRows)
                            {
                                if (Conn.MyReader.Read())
                                {
                                    logmail = new LogMail();
                                    logmail.id = Convert.ToInt32(Conn.MyReader["mail_id"]);
                                    if ((Conn.MyReader["mail_read"]) != null)
                                    {
                                        logmail.mail_read = Convert.ToInt32(Conn.MyReader["mail_read"]);
                                    }
                                    if ((Conn.MyReader["mail_status_id"]) != DBNull.Value)
                                    {
                                        logmail.mail_status_id = Convert.ToInt32(Conn.MyReader["mail_status_id"]);
                                        logmail.mail_status_name = mailstatusdao.GetStatus_ById(logmail.mail_status_id).mail_status;
                                    }
                                    if ((Conn.MyReader["direction_id"]) != DBNull.Value)
                                    {
                                        logmail.direction_id = Convert.ToInt32(Conn.MyReader["direction_id"]);
                                        logmail.direction_name = directiondao.GetDirectionByID(logmail.direction_id).direction;
                                    }
                                    if ((Conn.MyReader["user_id"]) != DBNull.Value)
                                    {
                                        logmail.user_id = Convert.ToInt32(Conn.MyReader["user_id"]);
                                        logmail.user_name = userdao.GetUser_ByID(logmail.user_id).username;
                                    }
                                    if ((Conn.MyReader["mail_category_id"]) != DBNull.Value)
                                    {
                                        logmail.mail_category_id = Convert.ToInt32(Conn.MyReader["mail_category_id"]); 
                                    } 


                                    logmail.mail_date = Conn.MyReader["mail_dates"].ToString();
                                    logmail.mail_time = Conn.MyReader["mail_time"].ToString();
                                    logmail.mail_from = Conn.MyReader["mail_from"].ToString();
                                    logmail.mail_to = Conn.MyReader["mail_to"].ToString();
                                    logmail.mail_cc = Conn.MyReader["mail_cc"].ToString();
                                    logmail.mail_bcc = Conn.MyReader["mail_bcc"].ToString();
                                    logmail.mail_subject = Conn.MyReader["mail_subject"].ToString();
                                    logmail.mail_text = Conn.MyReader["mail_text"].ToString(); 
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

                return logmail;
            }
        }

        public int CountMail()
        {
            lock (Global.ThreadLockDao)
            {
                int RetVal = 0;

                try
                {
                    string SQL = string.Empty;
                    SQL += "SELECT COUNT(mail_id) AS total";
                    SQL += " FROM cc_log_mail";
                    SQL += " WHERE mail_read=1 AND direction_id=1";

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

        public LogMail Get_mail_ByMailRead()
        {
            lock (Global.ThreadLockDao)
            {
                LogMail logmail = null;

                try
                {
                    string SQL = string.Empty;
                    SQL += "SELECT *,DATE_FORMAT(mail_date,'%d-%m-%Y') AS mail_dates ";
                    SQL += " FROM cc_log_mail WHERE mail_read=1 AND direction_id=1";
                    SQL += " ORDER BY mail_id DESC LIMIT 1 ";

                    Conn.MyConn.Open();
                    using (Conn.MyCommand = new MySqlCommand(SQL, Conn.MyConn))
                    {
                        using (Conn.MyReader = Conn.MyCommand.ExecuteReader())
                        {
                            if (Conn.MyReader.HasRows)
                            {
                                if (Conn.MyReader.Read())
                                {
                                    logmail = new LogMail();
                                    logmail.id = Convert.ToInt32(Conn.MyReader["mail_id"]);
                                    if ((Conn.MyReader["mail_read"]) != null)
                                    {
                                        logmail.mail_read = Convert.ToInt32(Conn.MyReader["mail_read"]);
                                    }
                                    if ((Conn.MyReader["mail_status_id"]) != DBNull.Value)
                                    {
                                        logmail.mail_status_id = Convert.ToInt32(Conn.MyReader["mail_status_id"]);
                                        logmail.mail_status_name = mailstatusdao.GetStatus_ById(logmail.mail_status_id).mail_status;
                                    }
                                    if ((Conn.MyReader["direction_id"]) != DBNull.Value)
                                    {
                                        logmail.direction_id = Convert.ToInt32(Conn.MyReader["direction_id"]);
                                        logmail.direction_name = directiondao.GetDirectionByID(logmail.direction_id).direction;
                                    }
                                    if ((Conn.MyReader["user_id"]) != DBNull.Value)
                                    {
                                        logmail.user_id = Convert.ToInt32(Conn.MyReader["user_id"]);
                                        logmail.user_name = userdao.GetUser_ByID(logmail.user_id).username;
                                    } 


                                    logmail.mail_date = Conn.MyReader["mail_dates"].ToString();
                                    logmail.mail_time = Conn.MyReader["mail_time"].ToString();
                                    logmail.mail_from = Conn.MyReader["mail_from"].ToString();
                                    logmail.mail_to = Conn.MyReader["mail_to"].ToString();
                                    logmail.mail_cc = Conn.MyReader["mail_cc"].ToString();
                                    logmail.mail_bcc = Conn.MyReader["mail_bcc"].ToString();
                                    logmail.mail_subject = Conn.MyReader["mail_subject"].ToString();
                                    logmail.mail_text = Conn.MyReader["mail_text"].ToString(); 
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

                return logmail;
            }
        }

        public bool UpdateMailRead(int mailid)
        {
            lock (Global.ThreadLockDao)
            {
                int RetVal = 0;

                try
                {
                    string SQL = string.Empty;
                    SQL += "UPDATE cc_log_mail SET mail_read=2 ,mail_status_id=5, user_id='" + Global.userAccount.id + "' WHERE mail_id = " + mailid +  " AND direction_id=1 LIMIT 1";

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

        public bool UpdateMailAttachmentCommplete(string mailid, string maillattachmentid)
        {
            lock (Global.ThreadLockDao)
            {
                int RetVal = 0;

                try
                {
                    string SQL = string.Empty;
                    SQL += "UPDATE cc_log_mail SET is_complete=1  WHERE mail_id = " + mailid ;

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
         
        public bool UpdateCategory(int mailid,string categoryId )
        {
            lock (Global.ThreadLockDao)
            {
                int RetVal = 0;

                try
                {
                    string SQL = string.Empty;
                    SQL += "UPDATE cc_log_mail SET mail_category_id=" + categoryId + "  WHERE mail_id = " + mailid + " LIMIT 1";

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
