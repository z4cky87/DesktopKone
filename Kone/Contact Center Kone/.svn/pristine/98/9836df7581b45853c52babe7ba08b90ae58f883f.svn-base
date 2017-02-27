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
    public class ReportBreakDao
    {

        DbMyConnection Conn = new DbMyConnection();

        public List<ReportBreak> GetAllbreak(string dtefrom, string dteuntil, int _filter_userid)
        {
            lock (Global.ThreadLockDao)
            {
                List<ReportBreak> listbreak = new List<ReportBreak>();
                string _user_id = _filter_userid == 0 ? "" : " AND user_id=" + _filter_userid;
                try
                {
                    string SQL = string.Empty;
                    SQL += " SELECT ";
                    SQL += " cc_log_break.id,cc_log_break.user_id, cc_log_break.break_reason_id,";
                    SQL += " DATE_FORMAT(cc_log_break.break_time,'%d-%m-%Y') AS break_date, ";
                    SQL += " DATE_FORMAT(cc_log_break.break_time,'%T') AS break_time,";
                    SQL += " DATE_FORMAT(cc_log_break.resume_time,'%d-%m-%Y') resume_date,";
                    SQL += " DATE_FORMAT(cc_log_break.resume_time,'%T') AS resume_time,";
                    SQL += " cc_users.username,cc_breakreason.reason,cc_log_break.duration,cc_log_break.total_duration,cc_log_break.break_note ";
                    SQL += " FROM cc_log_break";
                    SQL += " LEFT JOIN cc_users ON cc_users.id = cc_log_break.user_id";
                    SQL += " LEFT JOIN cc_breakreason ON cc_breakreason.id = cc_log_break.break_reason_id";
                    SQL += " WHERE DATE(break_time) BETWEEN '" + dtefrom + "' AND '" + dteuntil + "' ";
                    SQL += _user_id;
                    Conn.MyConn.Open();
                    using (Conn.MyCommand = new MySqlCommand(SQL, Conn.MyConn))
                    {
                        using (Conn.MyReader = Conn.MyCommand.ExecuteReader())
                        {
                            if (Conn.MyReader.HasRows)
                            {
                                while (Conn.MyReader.Read())
                                {
                                    ReportBreak logbreak = new ReportBreak();
                                    logbreak.username = Conn.MyReader["username"].ToString();
                                    logbreak.breakreason = Conn.MyReader["reason"].ToString();
                                    logbreak.note = Conn.MyReader["break_note"].ToString();
                                    logbreak.break_date = Conn.MyReader["break_date"].ToString();
                                    logbreak.break_time = Conn.MyReader["break_time"].ToString();
                                    logbreak.resume_date = Conn.MyReader["resume_date"].ToString();
                                    logbreak.resume_time = Conn.MyReader["resume_time"].ToString();
                                    logbreak.duration = Conn.MyReader["duration"].ToString();
                                    logbreak.total_duration = Conn.MyReader["total_duration"].ToString();
                                    listbreak.Add(logbreak);
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

                return listbreak;
            }
        }

        public class Users
        {
            public int id { get; set; }
            public string username { get; set; }
        }

        public List<Users> GetAllUserName()
        {
            List<Users> userName = new List<Users>();
            lock (Global.ThreadLockDao)
            {
                try
                {
                    string SQL = "SELECT id,username FROM cc_users";

                    Conn.MyConn.Open();
                    using (Conn.MyCommand = new MySqlCommand(SQL, Conn.MyConn))
                    {
                        using (Conn.MyReader = Conn.MyCommand.ExecuteReader())
                        {
                            if (Conn.MyReader.HasRows)
                            {
                                while (Conn.MyReader.Read())
                                {
                                    userName.Add(new Users()
                                    {
                                        id = Convert.ToInt16(Conn.MyReader["id"]),
                                        username = Conn.MyReader["username"].ToString()

                                    });

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


                return userName;
            }

        }

    }
}
