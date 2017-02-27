using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contact_Center_Kone.Entity;
using Contact_Center_Kone.Utility;
using MySql.Data.MySqlClient;

namespace Contact_Center_Kone.Dao
{
    public class ReportLoginDao
    {

        DbMyConnection Conn = new DbMyConnection();

        public List<ReportLogin> GetAllLogin(string dtefrom, string dteuntil, int _filter_userid)
        {
            lock (Global.ThreadLockDao)
            {
                List<ReportLogin> listlogin = new List<ReportLogin>();
                string _user_id = _filter_userid == 0 ? "" : " AND user_id=" + _filter_userid;
                try
                {
                    string SQL = string.Empty;
                    SQL += " SELECT cc_log_login.id,cc_log_login.user_id,cc_log_login.duration,cc_log_login.total_duration,cc_log_login.login_count,";
                    SQL += " DATE_FORMAT(cc_log_login.login_time,'%d-%m-%Y') AS login_date,";
                    SQL += " DATE_FORMAT(cc_log_login.login_time,'%T') AS login_time,";
                    SQL += " DATE_FORMAT(cc_log_login.logout_time,'%d-%m-%Y') logout_date,";
                    SQL += " DATE_FORMAT(cc_log_login.logout_time,'%T') AS logout_time, cc_users.username ";
                    SQL += " FROM cc_log_login ";
                    SQL += " LEFT JOIN cc_users ON cc_users.id = cc_log_login.user_id";
                    SQL += " WHERE application_id=0 AND DATE(login_time) BETWEEN '" + dtefrom + "' AND '" + dteuntil + "'";
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
                                    ReportLogin reportlogin = new ReportLogin();
                                    reportlogin.username = Conn.MyReader["username"].ToString();
                                    reportlogin.login_date = Conn.MyReader["login_date"].ToString();
                                    reportlogin.login_time = Conn.MyReader["login_time"].ToString();
                                    reportlogin.logout_date = Conn.MyReader["logout_date"].ToString();
                                    reportlogin.logout_time = Conn.MyReader["logout_time"].ToString();
                                    reportlogin.duration = Conn.MyReader["duration"].ToString();
                                    reportlogin.total_duration = Conn.MyReader["total_duration"].ToString();
                                    reportlogin.login_count = Conn.MyReader["login_count"].ToString();
                                    listlogin.Add(reportlogin);
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

                return listlogin;
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
