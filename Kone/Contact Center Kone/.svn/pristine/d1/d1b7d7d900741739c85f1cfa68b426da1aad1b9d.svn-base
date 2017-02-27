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
    public class ReportEmailDao
    {

        DbMyConnection Conn = new DbMyConnection();
        MailStatusDao mailstatusdao = new MailStatusDao();
        DirectionDao directiondao = new DirectionDao();
        UserDao userdao = new UserDao();
        ListTicketDao listticketdao = new ListTicketDao();
        public List<ReportEmail> GetAll_mail(string datefrom, string dateuntil)
        {
            lock (Global.ThreadLockDao)
            {
                List<ReportEmail> listlogmail = new List<ReportEmail>();

                try
                {
                    string SQL = string.Empty;
                    SQL += "SELECT *,DATE_FORMAT(mail_date,'%d-%m-%Y') AS mail_dates,";
                    SQL += " cc_mail_statuses.mail_status AS mail_status_name,cc_directions.direction AS direction_name,cc_users.username AS user_agent";
                    SQL += ",cc_mail_categories.name AS category_name";
                    SQL += " FROM cc_log_mail ";
                    SQL += " LEFT JOIN cc_mail_statuses ON cc_mail_statuses.mail_status_id = cc_log_mail.mail_status_id ";
                    SQL += " LEFT JOIN cc_directions ON cc_directions.id = cc_log_mail.direction_id";
                    SQL += " LEFT JOIN cc_users ON cc_users.id = cc_log_mail.user_id";
                    SQL += " LEFT JOIN cc_mail_categories ON cc_mail_categories.id = cc_log_mail.mail_category_id";
                    //SQL += " LEFT JOIN tickets ON tickets.id = cc_log_mail.ticket_id";
                    SQL += " WHERE mail_date BETWEEN '" + datefrom + "' AND '" + dateuntil + "' ";

                    Conn.MyConn.Open();
                    using (Conn.MyCommand = new MySqlCommand(SQL, Conn.MyConn))
                    {
                        using (Conn.MyReader = Conn.MyCommand.ExecuteReader())
                        {
                            if (Conn.MyReader.HasRows)
                            {
                                while (Conn.MyReader.Read())
                                {
                                    ReportEmail logmail = new ReportEmail();
                                    logmail.mail_date = Conn.MyReader["mail_dates"].ToString();
                                    logmail.mail_time = Conn.MyReader["mail_time"].ToString();
                                    logmail.mail_status_name = Conn.MyReader["mail_status_name"].ToString();
                                    logmail.direction_name = Conn.MyReader["direction_name"].ToString();
                                    logmail.user_name = Conn.MyReader["user_agent"].ToString();
                                    logmail.mail_from = Conn.MyReader["mail_from"].ToString();
                                    logmail.mail_to = Conn.MyReader["mail_to"].ToString();
                                    logmail.mail_cc = Conn.MyReader["mail_cc"].ToString();
                                    logmail.mail_bcc = Conn.MyReader["mail_bcc"].ToString();
                                    logmail.mail_subject = Conn.MyReader["mail_subject"].ToString();
                                    logmail.mail_text = Conn.MyReader["mail_text"].ToString();
                                    logmail.ticket_no = logmail.ticket_no = listticketdao.GetTicketNo_ByMediaId_SourceMediaId(Convert.ToInt32(Conn.MyReader["mail_id"]), 1);
                                    logmail.category_name = Conn.MyReader["category_name"].ToString();
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

    }

}
