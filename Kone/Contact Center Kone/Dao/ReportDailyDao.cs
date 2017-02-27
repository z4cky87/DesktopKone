using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contact_Center_Kone.Entity;
using Contact_Center_Kone.Utility;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Contact_Center_Kone.Dao
{
    public class ReportDailyDao
    {
        DbMyConnection dbconn = new DbMyConnection();

        public List<ReportDailyInbound> GetListDailyInbound(DateTimePicker datefrom, DateTimePicker dateuntil, int userid)
        {
            lock (Global.ThreadLockDao)
            {
                List<ReportDailyInbound> listdailyinbound = new List<ReportDailyInbound>();

                try
                {
                    ReportDailyInbound dailyinbound = null;
                    DateTime dstart = datefrom.Value.Date;
                    DateTime dend = dateuntil.Value.Date;
                    string _user_id = userid == 0 ? "" : " AND user_id=" + userid;
                    while (dstart <= dend)
                    {
                        Console.WriteLine(dstart.ToString("dd/MM/yyyy"));
                        try
                        {
                            string SQL = string.Empty;
                            SQL += " SELECT ";
                            SQL += " (SELECT COUNT(id) FROM cc_calls WHERE direction_id=1 AND DATE(call_date) = '" + dstart.ToString("yyyy/MM/dd") + "'" + _user_id + ") AS total_recieve,  ";
                            SQL += " (SELECT COUNT(id) FROM cc_calls WHERE direction_id=1 AND call_status_id=1 AND DATE(call_date) = '" + dstart.ToString("yyyy/MM/dd") + "'" + _user_id + ") AS total_answered,";
                            SQL += " (SELECT COUNT(id) FROM cc_calls WHERE direction_id=1 AND call_status_id=2 AND DATE(call_date) = '" + dstart.ToString("yyyy/MM/dd") + "'" + _user_id + ") AS total_abandon,  ";
                            SQL += " (SELECT COUNT(id) FROM cc_calls WHERE direction_id=1 AND call_status_id=3 AND DATE(call_date) = '" + dstart.ToString("yyyy/MM/dd") + "'" + _user_id + ") AS total_phantom,  ";
                            SQL += " (SELECT TIME_FORMAT(SEC_TO_TIME(SUM(TIME_TO_SEC(duration))),'%H:%i:%s') FROM cc_calls WHERE direction_id=1 AND DATE(call_date) = '" + dstart.ToString("yyyy/MM/dd") + "' AND call_status_id=1 " + _user_id + ") AS total_duration,";
                            SQL += " (SELECT TIME_FORMAT(SEC_TO_TIME(AVG(TIME_TO_SEC(duration))),'%H:%i:%s') FROM cc_calls WHERE direction_id=1 AND DATE(call_date) = '" + dstart.ToString("yyyy/MM/dd") + "' AND call_status_id=1 " + _user_id + ") AS total_avg_duration,";
                            SQL += " (SELECT TIME_FORMAT(SEC_TO_TIME(SUM(TIME_TO_SEC(busy))),'%H:%i:%s') FROM cc_calls WHERE direction_id=1 AND DATE(call_date) = '" + dstart.ToString("yyyy/MM/dd") + "' AND call_status_id=1 " + _user_id + ") AS total_acw,  ";
                            SQL += " (SELECT TIME_FORMAT(SEC_TO_TIME(AVG(TIME_TO_SEC(busy))),'%H:%i:%s') FROM cc_calls WHERE direction_id=1 AND DATE(call_date) = '" + dstart.ToString("yyyy/MM/dd") + "' AND call_status_id=1 " + _user_id + ") AS total_avg_acw,";
                            SQL += " (SELECT COUNT(id) FROM cc_calls WHERE direction_id=1 AND is_blankcall=2 AND DATE(call_date) = '" + dstart.ToString("yyyy/MM/dd") + "' " + _user_id + ") AS total_blankcall, ";
                            SQL += " (SELECT COUNT(id) FROM cc_calls WHERE direction_id=1 AND is_wrongno=2 AND DATE(call_date) = '" + dstart.ToString("yyyy/MM/dd") + "' " + _user_id + ") AS total_wrongno,";
                            SQL += " (SELECT COUNT(id) FROM cc_calls WHERE direction_id=1 AND is_inquiry=2 AND DATE(call_date) = '" + dstart.ToString("yyyy/MM/dd") + "' " + _user_id + ") AS total_inquiry,";
                            SQL += " (SELECT COUNT(id) FROM cc_calls WHERE direction_id=1 AND is_complain=2 AND DATE(call_date) = '" + dstart.ToString("yyyy/MM/dd") + "' " + _user_id + ") AS total_complaint,";
                            //SQL += " (SELECT COUNT(id) FROM cc_calls WHERE direction_id=1 AND is_prospectcustomer=2 AND DATE(call_date) = '" + dstart.ToString("yyyy/MM/dd") + "' " + _user_id + ") AS total_prospect,";
                            SQL += " (SELECT COUNT(id) FROM cc_calls WHERE direction_id=1 AND is_request=2 AND DATE(call_date) = '" + dstart.ToString("yyyy/MM/dd") + "' " + _user_id + ") AS total_request,";
                            SQL += " (SELECT COUNT(id) FROM cc_calls WHERE direction_id=1 AND is_testcall=2 AND DATE(call_date) = '" + dstart.ToString("yyyy/MM/dd") + "' " + _user_id + ") AS total_testcall,";
                            SQL += " (SELECT COUNT(id) FROM cc_calls WHERE direction_id=1 AND is_others=2 AND DATE(call_date) = '" + dstart.ToString("yyyy/MM/dd") + "' " + _user_id + ") AS total_others";
                            dbconn.MyConn.Open();

                            using (dbconn.MyCommand = new MySqlCommand(SQL, dbconn.MyConn))
                            {
                                using (dbconn.MyReader = dbconn.MyCommand.ExecuteReader())
                                {
                                    if (dbconn.MyReader.HasRows)
                                    {
                                        if (dbconn.MyReader.Read())
                                        {
                                            dailyinbound = new ReportDailyInbound();
                                            dailyinbound.date = dstart.ToString("dd-MM-yyyy");
                                            dailyinbound.total_recieve = Convert.ToInt32(dbconn.MyReader["total_recieve"]);
                                            dailyinbound.total_answer = Convert.ToInt32(dbconn.MyReader["total_answered"]);
                                            dailyinbound.total_abandon = Convert.ToInt32(dbconn.MyReader["total_abandon"]);
                                            dailyinbound.total_phantom = Convert.ToInt32(dbconn.MyReader["total_phantom"]);
                                            if (dbconn.MyReader["total_duration"].ToString() == "")
                                            { dailyinbound.total_call_duration = "00:00:00"; }
                                            else { dailyinbound.total_call_duration = dbconn.MyReader["total_duration"].ToString(); }
                                            if (dbconn.MyReader["total_avg_duration"].ToString() == "")
                                            { dailyinbound.total_avg_call_duration = "00:00:00"; }
                                            else { dailyinbound.total_avg_call_duration = dbconn.MyReader["total_avg_duration"].ToString(); }
                                            if (dbconn.MyReader["total_acw"].ToString() == "")
                                            { dailyinbound.total_acwtime = "00:00:00"; }
                                            else { dailyinbound.total_acwtime = dbconn.MyReader["total_acw"].ToString(); }
                                            if (dbconn.MyReader["total_avg_acw"].ToString() == "")
                                            { dailyinbound.total_avg_acwtime = "00:00:00"; }
                                            else { dailyinbound.total_avg_acwtime = dbconn.MyReader["total_avg_acw"].ToString(); }
                                            dailyinbound.total_blankcall = Convert.ToInt32(dbconn.MyReader["total_blankcall"]);
                                            dailyinbound.total_wrongno = Convert.ToInt32(dbconn.MyReader["total_wrongno"]);
                                            dailyinbound.total_inquiry= Convert.ToInt32(dbconn.MyReader["total_inquiry"]);
                                            dailyinbound.total_complaint= Convert.ToInt32(dbconn.MyReader["total_complaint"]);
                                            //dailyinbound.total_prospectcust= Convert.ToInt32(dbconn.MyReader["total_prospect"]);
                                            dailyinbound.total_request= Convert.ToInt32(dbconn.MyReader["total_request"]);
                                            dailyinbound.total_testcall= Convert.ToInt32(dbconn.MyReader["total_testcall"]);
                                            dailyinbound.total_others= Convert.ToInt32(dbconn.MyReader["total_others"]);
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

                        listdailyinbound.Add(dailyinbound);
                        dstart = dstart.AddDays(1);
                    }

                }
                catch (Exception Ex)
                {
                    Global.WriteLog(Global.GetCurrentMethod(Ex));
                }
                finally
                { dbconn.MyConn.Close(); }

                return listdailyinbound;
            }

        }

        public List<ReportDailyOutbound> GetListDailyOutbound(DateTimePicker datefrom, DateTimePicker dateuntil, int userid)
        {
            lock (Global.ThreadLockDao)
            {
                List<ReportDailyOutbound> listdailyoutbound = new List<ReportDailyOutbound>();

                try
                {
                    string _datefrom = datefrom.Value.ToString("yyyy-MM-dd");
                    ReportDailyOutbound hourlyoutbound = null;

                    DateTime dstart = datefrom.Value.Date;
                    DateTime dend = dateuntil.Value.Date;
                    string _user_id = userid == 0 ? "" : " AND user_id=" + userid;
                    while (dstart <= dend)
                    {
                        try
                        {
                            string SQL = string.Empty;
                            SQL += " SELECT ";
                            SQL += " (SELECT COUNT(id) FROM cc_calls WHERE direction_id=2 AND DATE(call_date) = '" + dstart.ToString("yyyy/MM/dd") + "' " + _user_id + ") AS total_outgoing,  ";
                            SQL += " (SELECT TIME_FORMAT(SEC_TO_TIME(SUM(TIME_TO_SEC(duration))),'%H:%i:%s') FROM cc_calls WHERE direction_id=2 AND DATE(call_date) = '" + dstart.ToString("yyyy/MM/dd") + "' " + _user_id + ") AS total_duration, ";
                            SQL += " (SELECT TIME_FORMAT(SEC_TO_TIME(AVG(TIME_TO_SEC(duration))),'%H:%i:%s') FROM cc_calls WHERE direction_id=2 AND DATE(call_date) = '" + dstart.ToString("yyyy/MM/dd") + "' " + _user_id + ") AS total_avg_duration"; 
                            dbconn.MyConn.Open();

                            using (dbconn.MyCommand = new MySqlCommand(SQL, dbconn.MyConn))
                            {
                                using (dbconn.MyReader = dbconn.MyCommand.ExecuteReader())
                                {
                                    if (dbconn.MyReader.HasRows)
                                    {
                                        if (dbconn.MyReader.Read())
                                        {
                                            hourlyoutbound = new ReportDailyOutbound();
                                            hourlyoutbound.dates = dstart.ToString("dd/MM/yyyy");
                                            hourlyoutbound.outgoing_call = dbconn.MyReader["total_outgoing"].ToString();
                                            if (dbconn.MyReader["total_duration"].ToString() == "")
                                            { hourlyoutbound.outboundcalltime = "00:00:00"; }
                                            else { hourlyoutbound.outboundcalltime = dbconn.MyReader["total_duration"].ToString(); }
                                            if (dbconn.MyReader["total_avg_duration"].ToString() == "")
                                            { hourlyoutbound.avg_outboundcalltime = "00:00:00"; }
                                            else { hourlyoutbound.avg_outboundcalltime = dbconn.MyReader["total_avg_duration"].ToString(); }
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

                        listdailyoutbound.Add(hourlyoutbound);
                        dstart = dstart.AddDays(1);
                    }

                }
                catch (Exception Ex)
                {
                    Global.WriteLog(Global.GetCurrentMethod(Ex));
                }
                finally
                { dbconn.MyConn.Close(); }

                return listdailyoutbound;
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
