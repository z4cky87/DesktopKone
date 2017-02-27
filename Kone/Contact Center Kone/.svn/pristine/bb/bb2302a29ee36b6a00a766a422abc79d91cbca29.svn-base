using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using Contact_Center_Kone.Dao;
using Contact_Center_Kone.Entity;
using Contact_Center_Kone.Utility;

namespace Contact_Center_Kone.Dao
{
    public class ReportSmsDao
    {


        DbMyConnection Conn = new DbMyConnection();
        ListTicketDao listticketdao = new ListTicketDao();

        public List<ReportSms> GetAllSms(string dtefrom, string dteuntil)
        {
            lock (Global.ThreadLockDao)
            {
                List<ReportSms> listlogsms = new List<ReportSms>();

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
                    SQL += " sms_read,sms_from,sms_to,sms_text,cc_sms_categories.name AS category_name";
                    SQL += " FROM cc_log_sms";
                    SQL += " LEFT JOIN cc_users ON cc_users.id = cc_log_sms.sms_id";
                    SQL += " LEFT JOIN cc_sms_statuses ON cc_sms_statuses.sms_status_id = cc_log_sms.sms_status_id";
                    SQL += " LEFT JOIN cc_directions ON cc_directions.id = cc_log_sms.direction_id";
                    SQL += " LEFT JOIN cc_sms_categories ON cc_sms_categories.id = cc_log_sms.sms_category_id";
                    SQL += " WHERE sms_date BETWEEN '" + dtefrom + "' AND '" + dteuntil + "' ";

                    Conn.MyConn.Open();
                    using (Conn.MyCommand = new MySqlCommand(SQL, Conn.MyConn))
                    {
                        using (Conn.MyReader = Conn.MyCommand.ExecuteReader())
                        {
                            if (Conn.MyReader.HasRows)
                            {
                                while (Conn.MyReader.Read())
                                {
                                    ReportSms logsms = new ReportSms(); 
                                    logsms.sms_date = Conn.MyReader["sms_date"].ToString();
                                    logsms.sms_time = Conn.MyReader["sms_time"].ToString(); 
                                    logsms.sms_from = Conn.MyReader["sms_from"].ToString();
                                    logsms.sms_to = Conn.MyReader["sms_to"].ToString();
                                    logsms.sms_text = Conn.MyReader["sms_text"].ToString();
                                    logsms.username_agent = Conn.MyReader["username"].ToString();
                                    logsms.sms_status = Conn.MyReader["sms_status"].ToString();
                                    logsms.sms_direction = Conn.MyReader["direction"].ToString();
                                    logsms.category_name = Conn.MyReader["category_name"].ToString();
                                    logsms.ticket_no = listticketdao.GetTicketNo_ByMediaId_SourceMediaId(Convert.ToInt32(Conn.MyReader["sms_id"]), 2);
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


    }

}
