using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contact_Center_Kone.Entity;
using Contact_Center_Kone.Utility;
using MySql.Data.MySqlClient;

namespace Contact_Center_Kone.Dao
{
    public class MailStatusDao
    {
        DbMyConnection Conn = new DbMyConnection();

        public MailStatus GetStatus_ById(int id)
        {
            lock (Global.ThreadLockDao)
            {
                MailStatus mailstatus = null;

                try
                {
                    string SQL = "SELECT * FROM cc_mail_statuses WHERE mail_status_id=" + id;

                    Conn.MyConn.Open();

                    using (Conn.MyCommand = new MySqlCommand(SQL,Conn.MyConn))
                    {
                        using (Conn.MyReader = Conn.MyCommand.ExecuteReader())
                        {
                            if (Conn.MyReader.HasRows)
                            {
                                if (Conn.MyReader.Read())
                                {
                                    mailstatus = new MailStatus();
                                    mailstatus.id = Convert.ToInt32(Conn.MyReader["mail_status_id"]);
                                    mailstatus.mail_status = Conn.MyReader["mail_status"].ToString();
                                    mailstatus.direction_id = Convert.ToInt32(Conn.MyReader["direction_id"]);

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

                return mailstatus;
            }
        }

        public List<MailStatus> GetListMailStatus(int directionid = 0)
        {
            lock (Global.ThreadLockDao)
            {
                List<MailStatus> ListMailStatus = new List<MailStatus>();

                try
                {
                    string filterdirection = directionid == 0 ? "" : " WHERE direction_id=" + directionid;
                    string SQL = "SELECT * FROM cc_mail_statuses " + filterdirection;
                    Conn.MyConn.Open();
                    using (Conn.MyCommand = new MySqlCommand(SQL, Conn.MyConn))
                    {
                        using (Conn.MyReader = Conn.MyCommand.ExecuteReader())
                        {
                            if (Conn.MyReader.HasRows)
                            {
                                MailStatus mailstatus = new MailStatus();
                                mailstatus.id = -2;
                                mailstatus.mail_status = null;
                                ListMailStatus.Add(mailstatus);
                                while (Conn.MyReader.Read())
                                {
                                    mailstatus = new MailStatus();
                                    mailstatus.id = Convert.ToInt32(Conn.MyReader["mail_status_id"]);
                                    mailstatus.mail_status = Conn.MyReader["mail_status"].ToString();
                                    ListMailStatus.Add(mailstatus);
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
                { Conn.MyConn.Close(); }

                return ListMailStatus;
            }
        }

    }
}
