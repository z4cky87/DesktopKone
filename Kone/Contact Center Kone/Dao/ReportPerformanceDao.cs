﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using Contact_Center_Kone.Dao;
using Contact_Center_Kone.Entity;
using Contact_Center_Kone.Utility;
using System.Windows.Forms;

namespace Contact_Center_Kone.Dao
{
    public class ReportPerformanceDao
    {

        DbMyConnection dbconn = new DbMyConnection();

        private Dictionary<int,string> GetListusername(string dates, int directionid, int _filter_userid)
        {
            Dictionary<int, string> dict = new Dictionary<int,string>() ;

            string _user_id = _filter_userid == 0 ? "" : " AND user_id=" + _filter_userid;
            try
            {
                //string _departmentid = departmentid == null ? "" : " AND dept_id='" + departmentid + "'";
                string SQL = string.Empty;
                SQL += "  SELECT cc_calls.user_id,cc_users.username  ";
                SQL += "  FROM cc_calls  ";
                SQL += "  JOIN cc_users ON cc_users.id = cc_calls.user_id ";
                SQL += "  WHERE DATE(CALL_DATE)='" + dates + "' AND cc_calls.direction_id=" + directionid;
                SQL += _user_id;
                SQL += " GROUP BY cc_calls.user_id";
              
                dbconn.MyConn.Open();
                using (dbconn.MyCommand = new MySqlCommand(SQL, dbconn.MyConn))
                {
                    using (dbconn.MyReader = dbconn.MyCommand.ExecuteReader())
                    {
                        if (dbconn.MyReader.HasRows)
                        {
                            while (dbconn.MyReader.Read())
                            {
                                int userid =Convert.ToInt32(dbconn.MyReader["user_id"]);
                                string username = dbconn.MyReader["username"].ToString();
                                dict.Add(userid,username);
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
            { dbconn.MyConn.Close(); }
            return dict;
        }

        public List<PerformanceInbound> GetListPerformanceInbound(DateTimePicker datefrom, DateTimePicker dateuntil, int userid)
        {
            lock (Global.ThreadLockDao)
            {
                List<PerformanceInbound> listperfomanceinbound = new List<PerformanceInbound>();
                List<int> listusername = null;
                Dictionary<int, string> dict = null;

                try
                {
                    PerformanceInbound performanceinbound = null;
                    DateTime dstart = datefrom.Value.Date;
                    DateTime dend = dateuntil.Value.Date;
                    while (dstart <= dend)
                    {
                        listusername = new List<int>();
                        //listusername = GetListusername(dstart.ToString("yyyy/MM/dd"), 0, departmentid);
                        dict = GetListusername(dstart.ToString("yyyy/MM/dd"), 1, userid);
                        if (dict != null)
                        {
                            foreach (var pair in dict)
                            {
                                try
                                {
                                    string SQL = string.Empty;
                                    SQL += " SELECT  ";
                                    SQL += " (SELECT COUNT(id) FROM cc_calls WHERE direction_id=1 AND user_id=" + pair.Key + " AND DATE(call_date) = '" + dstart.ToString("yyyy/MM/dd") + "') AS total_recieve,  ";
                                    SQL += " (SELECT COUNT(id) FROM cc_calls WHERE direction_id=1 AND call_status_id=1 AND user_id=" + pair.Key + " AND DATE(call_date) = '" + dstart.ToString("yyyy/MM/dd") + "') AS total_answered,";
                                    SQL += " (SELECT COUNT(id) FROM cc_calls WHERE direction_id=1 AND call_status_id=2 AND user_id=" + pair.Key + " AND DATE(call_date) = '" + dstart.ToString("yyyy/MM/dd") + "') AS total_abandon,  ";
                                    SQL += " (SELECT COUNT(id) FROM cc_calls WHERE direction_id=1 AND call_status_id=3 AND user_id=" + pair.Key + " AND DATE(call_date) = '" + dstart.ToString("yyyy/MM/dd") + "') AS total_phantom,  ";
                                    SQL += " (SELECT TIME_FORMAT(SEC_TO_TIME(SUM(TIME_TO_SEC(duration))),'%H:%i:%s') FROM cc_calls WHERE direction_id=1 AND call_status_id=1 AND user_id=" + pair.Key + " AND DATE(call_date) = '" + dstart.ToString("yyyy/MM/dd") + "') AS total_duration,  ";
                                    SQL += " (SELECT TIME_FORMAT(SEC_TO_TIME(AVG(TIME_TO_SEC(duration))),'%H:%i:%s') FROM cc_calls WHERE direction_id=1 AND call_status_id=1 AND user_id=" + pair.Key + " AND DATE(call_date) = '" + dstart.ToString("yyyy/MM/dd") + "') AS total_avg_duration,";
                                    SQL += " (SELECT TIME_FORMAT(SEC_TO_TIME(SUM(TIME_TO_SEC(busy))),'%H:%i:%s') FROM cc_calls WHERE direction_id=1 AND call_status_id=1 AND user_id=" + pair.Key + " AND DATE(call_date) = '" + dstart.ToString("yyyy/MM/dd") + "') AS total_acw,  ";
                                    SQL += " (SELECT TIME_FORMAT(SEC_TO_TIME(AVG(TIME_TO_SEC(busy))),'%H:%i:%s') FROM cc_calls WHERE direction_id=1 AND call_status_id=1 AND user_id=" + pair.Key + " AND DATE(call_date) = '" + dstart.ToString("yyyy/MM/dd") + "') AS total_avg_acw,";
                                    SQL += " (SELECT COUNT(id) FROM cc_calls WHERE direction_id=1 AND is_blankcall=2 AND user_id=" + pair.Key + " AND DATE(call_date) = '" + dstart.ToString("yyyy/MM/dd") + "') AS total_blankcall, ";
                                    SQL += " (SELECT COUNT(id) FROM cc_calls WHERE direction_id=1 AND is_wrongno=2 AND user_id=" + pair.Key + " AND DATE(call_date) = '" + dstart.ToString("yyyy/MM/dd") + "') AS total_wrongno,";
                                    SQL += " (SELECT COUNT(id) FROM cc_calls WHERE direction_id=1 AND is_inquiry=2 AND user_id=" + pair.Key + " AND DATE(call_date) = '" + dstart.ToString("yyyy/MM/dd") + "') AS total_inquiry,";
                                    SQL += " (SELECT COUNT(id) FROM cc_calls WHERE direction_id=1 AND is_complain=2 AND user_id=" + pair.Key + " AND DATE(call_date) = '" + dstart.ToString("yyyy/MM/dd") + "') AS total_complaint,";
                                    //SQL += " (SELECT COUNT(id) FROM cc_calls WHERE direction_id=1 AND is_prospectcustomer=2 AND user_id=" + pair.Key + " AND DATE(call_date) = '" + dstart.ToString("yyyy/MM/dd") + "') AS total_prospectcust,";
                                    SQL += " (SELECT COUNT(id) FROM cc_calls WHERE direction_id=1 AND is_request=2 AND user_id=" + pair.Key + " AND DATE(call_date) = '" + dstart.ToString("yyyy/MM/dd") + "') AS total_request,";
                                    SQL += " (SELECT COUNT(id) FROM cc_calls WHERE direction_id=1 AND is_testcall=2 AND user_id=" + pair.Key + " AND DATE(call_date) = '" + dstart.ToString("yyyy/MM/dd") + "') AS total_testcall,";
                                    SQL += " (SELECT COUNT(id) FROM cc_calls WHERE direction_id=1 AND is_others=2 AND user_id=" + pair.Key + " AND DATE(call_date) = '" + dstart.ToString("yyyy/MM/dd") + "') AS total_others";


                                         
                                    dbconn.MyConn.Open();

                                    using (dbconn.MyCommand = new MySqlCommand(SQL, dbconn.MyConn))
                                    {
                                        using (dbconn.MyReader = dbconn.MyCommand.ExecuteReader())
                                        {
                                            if (dbconn.MyReader.HasRows)
                                            {
                                                if (dbconn.MyReader.Read())
                                                {
                                                    performanceinbound = new PerformanceInbound();
                                                    performanceinbound.date = dstart.ToString("dd-MM-yyyy");
                                                    performanceinbound.agent = pair.Value;
                                                    performanceinbound.total_recieve = Convert.ToInt32(dbconn.MyReader["total_recieve"]);
                                                    performanceinbound.total_answer = Convert.ToInt32(dbconn.MyReader["total_answered"]);
                                                    performanceinbound.total_abandon = Convert.ToInt32(dbconn.MyReader["total_abandon"]);
                                                    performanceinbound.total_phantom = Convert.ToInt32(dbconn.MyReader["total_phantom"]);
                                                    if (dbconn.MyReader["total_duration"].ToString() == "")
                                                    { performanceinbound.total_call_duration = "00:00:00"; }
                                                    else { performanceinbound.total_call_duration = dbconn.MyReader["total_duration"].ToString(); }
                                                    if (dbconn.MyReader["total_avg_duration"].ToString() == "")
                                                    { performanceinbound.total_avg_call_duration = "00:00:00"; }
                                                    else { performanceinbound.total_avg_call_duration = dbconn.MyReader["total_avg_duration"].ToString(); }
                                                    if (dbconn.MyReader["total_acw"].ToString() == "")
                                                    { performanceinbound.total_acwtime = "00:00:00"; }
                                                    else { performanceinbound.total_acwtime = dbconn.MyReader["total_acw"].ToString(); }
                                                    if (dbconn.MyReader["total_avg_acw"].ToString() == "")
                                                    { performanceinbound.total_avg_acwtime = "00:00:00"; }
                                                    else { performanceinbound.total_avg_acwtime = dbconn.MyReader["total_avg_acw"].ToString(); }
                                                    performanceinbound.total_blankcall = Convert.ToInt32(dbconn.MyReader["total_blankcall"]);
                                                    performanceinbound.total_wongno = Convert.ToInt32(dbconn.MyReader["total_wrongno"]);
                                                    performanceinbound.total_inquiry = Convert.ToInt32(dbconn.MyReader["total_inquiry"]);
                                                    performanceinbound.total_complaint = Convert.ToInt32(dbconn.MyReader["total_complaint"]);
                                                    //performanceinbound.total_prospectcust= Convert.ToInt32(dbconn.MyReader["total_prospectcust"]);
                                                    performanceinbound.total_request= Convert.ToInt32(dbconn.MyReader["total_request"]);
                                                    performanceinbound.total_testcall= Convert.ToInt32(dbconn.MyReader["total_testcall"]);
                                                    performanceinbound.total_others= Convert.ToInt32(dbconn.MyReader["total_others"]);
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
                                { dbconn.MyConn.Close(); }
                                listperfomanceinbound.Add(performanceinbound);

                            }
                        }
                        dstart = dstart.AddDays(1);
                    }

                }
                catch (Exception Ex)
                {
                    Global.WriteLog(Global.GetCurrentMethod(Ex));
                }
                finally
                { dbconn.MyConn.Close(); }

                return listperfomanceinbound;
            }

        }

        public List<PerformanceOutbound> GetListPerformanceOutbound(DateTimePicker datefrom, DateTimePicker dateuntil, int userid)
        {
            lock (Global.ThreadLockDao)
            {
                List<PerformanceOutbound> listperformanceoutbound = new List<PerformanceOutbound>();
                List<string> listagent = null;
                Dictionary<int, string> dict = null;
                try
                {
                    string _datefrom = datefrom.Value.ToString("yyyy-MM-dd");
                    PerformanceOutbound performanceoutbound = null;

                    DateTime dstart = datefrom.Value.Date;
                    DateTime dend = dateuntil.Value.Date; 
                    while (dstart <= dend)
                    {
                        listagent = new List<string>();
                        //listagent = GetListusername(dstart.ToString("yyyy/MM/dd"), 1, departmentid);
                        dict = GetListusername(dstart.ToString("yyyy/MM/dd"), 2, userid);
                        if (listagent != null)
                        {
                            foreach (var pair in dict)
                            {
                                try
                                {
                                    string SQL = "SELECT "
                                               + " (SELECT COUNT(id) FROM cc_calls WHERE direction_id=2 AND user_id='" + pair.Key + "' AND DATE(call_date) = '" + dstart.ToString("yyyy/MM/dd") + "') AS total_outgoing, "
                                               + " (SELECT TIME_FORMAT(SEC_TO_TIME(SUM(TIME_TO_SEC(duration))),'%H:%i:%s') FROM cc_calls WHERE direction_id=2 AND user_id='" + pair.Key + "' AND DATE(call_date) = '" + dstart.ToString("yyyy/MM/dd") + "') AS total_duration,"
                                               + " (SELECT TIME_FORMAT(SEC_TO_TIME(AVG(TIME_TO_SEC(duration))),'%H:%i:%s') FROM cc_calls WHERE direction_id=2 AND user_id='" + pair.Key + "' AND DATE(call_date) = '" + dstart.ToString("yyyy/MM/dd") + "') AS total_avg_duration"
                                               ;
                                    dbconn.MyConn.Open();

                                    using (dbconn.MyCommand = new MySqlCommand(SQL, dbconn.MyConn))
                                    {
                                        using (dbconn.MyReader = dbconn.MyCommand.ExecuteReader())
                                        {
                                            if (dbconn.MyReader.HasRows)
                                            {
                                                if (dbconn.MyReader.Read())
                                                {
                                                    performanceoutbound = new PerformanceOutbound();
                                                    performanceoutbound.dates = dstart.ToString("dd/MM/yyyy");
                                                    performanceoutbound.agent = pair.Value;
                                                    performanceoutbound.outgoing_call = dbconn.MyReader["total_outgoing"].ToString();
                                                    if (dbconn.MyReader["total_duration"].ToString() == "")
                                                    { performanceoutbound.outboundcalltime = "00:00:00"; }
                                                    else { performanceoutbound.outboundcalltime = dbconn.MyReader["total_duration"].ToString(); }
                                                    if (dbconn.MyReader["total_avg_duration"].ToString() == "")
                                                    { performanceoutbound.avg_outboundcalltime = "00:00:00"; }
                                                    else { performanceoutbound.avg_outboundcalltime = dbconn.MyReader["total_avg_duration"].ToString(); }
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
                                { dbconn.MyConn.Close(); }

                                listperformanceoutbound.Add(performanceoutbound);

                            }
                        }
                        dstart = dstart.AddDays(1);

                    }

                }
                catch (Exception Ex)
                {
                    Global.WriteLog(Global.GetCurrentMethod(Ex));
                }
                finally
                { dbconn.MyConn.Close(); }

                return listperformanceoutbound;
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

                    dbconn.MyConn.Open();
                    using (dbconn.MyCommand = new MySqlCommand(SQL, dbconn.MyConn))
                    {
                        using (dbconn.MyReader = dbconn.MyCommand.ExecuteReader())
                        {
                            if (dbconn.MyReader.HasRows)
                            {
                                while (dbconn.MyReader.Read())
                                {
                                    userName.Add(new Users()
                                    {
                                        id = Convert.ToInt16(dbconn.MyReader["id"]),
                                        username = dbconn.MyReader["username"].ToString()

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
                    dbconn.MyConn.Close();
                }


                return userName;
            }

        }

    }
}
