using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contact_Center_Kone.Entity;
using Contact_Center_Kone.Utility;
using MySql.Data.MySqlClient;

namespace Contact_Center_Kone.Dao
{
    public class LogBreakDao
    {
        DbMyConnection DbMyConn = new DbMyConnection();


        public string InsertLogBreak(LogBreak logbraeak)
        {
            lock (Global.ThreadLockDao)
            {
                string RetVal = string.Empty;

                try
                {
                    string SQL = string.Empty;

                    SQL += "INSERT cc_log_break SET ";
                    SQL += " break_time=NOW(),"; 
                    SQL += " user_id=@user_id,";
                    SQL += " break_reason_id=@break_reason_id,";
                    SQL += " break_note=@break_note;";
                    SQL += " SELECT LAST_INSERT_ID() as lastid;";

                    DbMyConn.MyConn.Open();

                    using (DbMyConn.MyCommand = new MySqlCommand())
                    {
                        using (DbMyConn.MyCommand = DbMyConn.MyConn.CreateCommand())
                        {
                            DbMyConn.MyCommand.CommandText = SQL;
                            DbMyConn.MyCommand.Parameters.AddWithValue("@break_reason_id", logbraeak.break_reason_id);
                            DbMyConn.MyCommand.Parameters.AddWithValue("@user_id", logbraeak.user_id);
                            DbMyConn.MyCommand.Parameters.AddWithValue("@break_note", logbraeak.note);
                            using (DbMyConn.MyReader = DbMyConn.MyCommand.ExecuteReader())
                            {
                                if (DbMyConn.MyReader.HasRows)
                                {
                                    if (DbMyConn.MyReader.Read())
                                    {
                                        RetVal = DbMyConn.MyReader["lastid"].ToString();
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
                    DbMyConn.MyConn.Close();
                }

                return RetVal;
            }
        }

        public bool UpdateLogBreak(string id)
        {
            lock (Global.ThreadLockDao)
            {
                int RetVal = 0;
                try
                {
                    string SQL = string.Empty;
                    SQL += " UPDATE cc_log_break SET resume_time=NOW(),  duration=TIMEDIFF(resume_time, break_time) ";
                    SQL += " WHERE id='" + id + "'";

                    DbMyConn.MyConn.Open();

                    using (DbMyConn.MyCommand = new MySqlCommand(SQL,DbMyConn.MyConn))
                    {
                        RetVal = DbMyConn.MyCommand.ExecuteNonQuery();
                    }

                }
                catch (Exception Ex)
                {
                    Global.WriteLog(Global.GetCurrentMethod(Ex));
                }finally
                {
                    DbMyConn.MyConn.Close();
                }


                return RetVal > 0;
            }
        }

        public bool CheckInPassword(string username, string pwd)
        {
            lock (Global.ThreadLockDao)
            {
               return Global.MatchPassword(pwd, new UserDao().GetPasswordUser(username));
            }
        }

        public bool CheckInPasswordBreak(string username, string pwd)
        {
            int RetVal = 0;
            lock (Global.ThreadLockDao)
            {
                try
                {
                    string SQL = string.Empty;
                    SQL += "SELECT COUNT(id) AS total FROM cc_users WHERE username='" + username + "' AND password=md5('" + pwd + "')";

                    DbMyConn.MyConn.Open();
                    using (DbMyConn.MyCommand = new MySqlCommand(SQL, DbMyConn.MyConn))
                    {
                        using (DbMyConn.MyReader = DbMyConn.MyCommand.ExecuteReader())
                        {
                            if (DbMyConn.MyReader.HasRows)
                            {
                                if (DbMyConn.MyReader.Read())
                                {
                                    RetVal = Convert.ToInt32(DbMyConn.MyReader["total"]);
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
                    DbMyConn.MyConn.Close();
                }
               

            }

            return RetVal > 0;
        }

        public string GetLogin_TotalDuration()
        {
            lock (Global.ThreadLockDao)
            {
                string RetVal = string.Empty;

                try
                {
                    string SQL = string.Empty;

                    SQL += " SELECT SEC_TO_TIME(SUM(TIME_TO_SEC(duration))) AS total ";
                    SQL += " FROM cc_log_break";
                    SQL += " WHERE user_id=" + Global.userAccount.id + " AND DATE(break_time)=CURRENT_DATE()";
                    DbMyConn.MyConn.Open();
                    using (DbMyConn.MyCommand = new MySqlCommand(SQL, DbMyConn.MyConn))
                    {
                        using (DbMyConn.MyReader = DbMyConn.MyCommand.ExecuteReader())
                        {
                            if (DbMyConn.MyReader.HasRows)
                            {
                                if (DbMyConn.MyReader.Read())
                                {
                                    RetVal = DbMyConn.MyReader["total"].ToString();
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
                    DbMyConn.MyConn.Close();
                }

                return RetVal;
            }
        }

        public bool InsertLogin_TotalDuration(int id)
        {
            lock (Global.ThreadLockDao)
            {
                int RetVal = 0;
                try
                {
                    string totallogin = GetLogin_TotalDuration();
                    string SQL = string.Empty;

                    SQL += "UPDATE cc_log_break SET ";
                    SQL += " total_duration='" + totallogin + "'";
                    SQL += " WHERE id=" + id + " LIMIT 1";

                    DbMyConn.MyConn.Open();
                    using (DbMyConn.MyCommand = new MySqlCommand(SQL, DbMyConn.MyConn))
                    {
                        RetVal = DbMyConn.MyCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception Ex)
                {
                    Global.WriteLog(Global.GetCurrentMethod(Ex));
                }
                finally
                {
                    DbMyConn.MyConn.Close();
                }

                return RetVal > 0;
            }
        }
    }
}
