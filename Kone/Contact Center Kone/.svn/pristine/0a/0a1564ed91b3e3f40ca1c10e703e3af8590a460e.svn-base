using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using Contact_Center_Kone.Entity;
using Contact_Center_Kone.Utility;
using System.Data;

namespace Contact_Center_Kone.Dao
{
    public class ReportHourlyDao
    {
        DbMyConnection DbMyConn = new DbMyConnection();
        DbMyConnection DbMyConn1 = new DbMyConnection();
        DbMyConnection DbMyConn2 = new DbMyConnection();

        public List<ReportHourlyInbound> GetListHourlyInbound(string _datefrom, int userid)
        {
            lock (Global.ThreadLockDao)
            {
                List<ReportHourlyInbound> listhourlyinbound = new List<ReportHourlyInbound>();
                string _user_id = userid == 0 ? "" : " AND user_id=" + userid;
                try
                { 
                    ReportHourlyInbound hourlyinbound = null;
                    foreach (string hours in Global.HoursReport)
                    {
                        try
                        {
                            string SQL = string.Empty;
                            SQL += " SELECT ";
                            SQL += " (SELECT COUNT(id) FROM cc_calls WHERE direction_id=1 AND DATE(call_date)='" + _datefrom + "' AND TIME(call_date) LIKE '" + hours.Replace(":00", "") + "%' " + _user_id + ") AS total_recieve,";
                            SQL += " (SELECT COUNT(id) FROM cc_calls WHERE direction_id=1 AND call_status_id=1 AND DATE(call_date)='" + _datefrom + "' AND TIME(call_date) LIKE '" + hours.Replace(":00", "") + "%' " + _user_id + ") AS total_answered,";
                            SQL += " (SELECT COUNT(id) FROM cc_calls WHERE direction_id=1 AND call_status_id=2 AND DATE(call_date)='" + _datefrom + "' AND TIME(call_date) LIKE '" + hours.Replace(":00", "") + "%' " + _user_id + ") AS total_abandon,";
                            SQL += " (SELECT COUNT(id) FROM cc_calls WHERE direction_id=1 AND call_status_id=3 AND DATE(call_date)='" + _datefrom + "' AND TIME(call_date) LIKE '" + hours.Replace(":00", "") + "%' " + _user_id + ") AS total_phantom,";
                            SQL += " (SELECT TIME_FORMAT(SEC_TO_TIME(SUM(TIME_TO_SEC(duration))),'%H:%i:%s') FROM cc_calls WHERE direction_id=1 AND DATE(call_date)='" + _datefrom + "' AND call_status_id=1 AND TIME(call_date) LIKE '" + hours.Replace(":00", "") + "%' " + _user_id + ") AS total_duration,";
                            SQL += " (SELECT TIME_FORMAT(SEC_TO_TIME(AVG(TIME_TO_SEC(duration))),'%H:%i:%s') FROM cc_calls WHERE direction_id=1 AND DATE(call_date)='" + _datefrom + "' AND call_status_id=1 AND TIME(call_date) LIKE '" + hours.Replace(":00", "") + "%' " + _user_id + ") AS total_avg_duration,";
                            SQL += " (SELECT TIME_FORMAT(SEC_TO_TIME(SUM(TIME_TO_SEC(busy))),'%H:%i:%s') FROM cc_calls WHERE direction_id=1 AND DATE(call_date)='" + _datefrom + "' AND call_status_id=1 AND TIME(call_date) LIKE '" + hours.Replace(":00", "") + "%' " + _user_id + ") AS total_acw,";
                            SQL += " (SELECT TIME_FORMAT(SEC_TO_TIME(AVG(TIME_TO_SEC(busy))),'%H:%i:%s') FROM cc_calls WHERE direction_id=1 AND DATE(call_date)='" + _datefrom + "' AND call_status_id=1 AND TIME(call_date) LIKE '" + hours.Replace(":00", "") + "%' " + _user_id + ") AS total_avg_acw,";
                            SQL += " (SELECT COUNT(id) FROM cc_calls WHERE direction_id=1 AND is_blankcall=2 AND DATE(call_date)='" + _datefrom + "' AND TIME(call_date) LIKE '" + hours.Replace(":00", "") + "%' " + _user_id + ") AS total_blankcall,";
                            SQL += " (SELECT COUNT(id) FROM cc_calls WHERE direction_id=1 AND is_wrongno=2 AND DATE(call_date)='" + _datefrom + "' AND TIME(call_date) LIKE '" + hours.Replace(":00", "") + "%' " + _user_id + ") AS total_wrongno,";
                            SQL += " (SELECT COUNT(id) FROM cc_calls WHERE direction_id=1 AND is_inquiry=2 AND DATE(call_date)='" + _datefrom + "' AND TIME(call_date) LIKE '" + hours.Replace(":00", "") + "%' " + _user_id + ") AS total_inquiry,";
                            SQL += " (SELECT COUNT(id) FROM cc_calls WHERE direction_id=1 AND is_complain=2 AND DATE(call_date)='" + _datefrom + "' AND TIME(call_date) LIKE '" + hours.Replace(":00", "") + "%' " + _user_id + ") AS total_complaint,";
                            SQL += " (SELECT COUNT(id) FROM cc_calls WHERE direction_id=1 AND is_prospectcustomer=2 AND DATE(call_date)='" + _datefrom + "' AND TIME(call_date) LIKE '" + hours.Replace(":00", "") + "%' " + _user_id + ") AS total_prospect,";
                            SQL += " (SELECT COUNT(id) FROM cc_calls WHERE direction_id=1 AND is_request=2 AND DATE(call_date)='" + _datefrom + "' AND TIME(call_date) LIKE '" + hours.Replace(":00", "") + "%' " + _user_id + ") AS total_request,";
                            SQL += " (SELECT COUNT(id) FROM cc_calls WHERE direction_id=1 AND is_testcall=2 AND DATE(call_date)='" + _datefrom + "' AND TIME(call_date) LIKE '" + hours.Replace(":00", "") + "%' " + _user_id + ") AS total_testcall,";
                            SQL += " (SELECT COUNT(id) FROM cc_calls WHERE direction_id=1 AND is_others=2 AND DATE(call_date)='" + _datefrom + "' AND TIME(call_date) LIKE '" + hours.Replace(":00", "") + "%' " + _user_id + ") AS total_others;"; 
                            DbMyConn.MyConn.Open();

                            using (DbMyConn.MyCommand = new MySqlCommand(SQL, DbMyConn.MyConn))
                            {
                                using (DbMyConn.MyReader = DbMyConn.MyCommand.ExecuteReader())
                                {
                                    if (DbMyConn.MyReader.HasRows)
                                    {
                                        if (DbMyConn.MyReader.Read())
                                        {
                                            hourlyinbound = new ReportHourlyInbound();
                                            hourlyinbound.hour = hours;
                                            hourlyinbound.total_recieve = Convert.ToInt32(DbMyConn.MyReader["total_recieve"]);
                                            hourlyinbound.total_answered = Convert.ToInt32(DbMyConn.MyReader["total_answered"]);
                                            hourlyinbound.total_abandon = Convert.ToInt32(DbMyConn.MyReader["total_abandon"]);
                                            hourlyinbound.total_phantom = Convert.ToInt32(DbMyConn.MyReader["total_phantom"]);
                                            if (DbMyConn.MyReader["total_duration"].ToString() == "")
                                            { hourlyinbound.total_callduration = "00:00:00"; }
                                            else { hourlyinbound.total_callduration = DbMyConn.MyReader["total_duration"].ToString(); }
                                            if (DbMyConn.MyReader["total_avg_duration"].ToString() == "")
                                            { hourlyinbound.total_avgcallduration = "00:00:00"; }
                                            else { hourlyinbound.total_avgcallduration = DbMyConn.MyReader["total_avg_duration"].ToString(); }
                                            if (DbMyConn.MyReader["total_acw"].ToString() == "")
                                            { hourlyinbound.total_acw = "00:00:00"; }
                                            else { hourlyinbound.total_acw = DbMyConn.MyReader["total_acw"].ToString(); }
                                            if (DbMyConn.MyReader["total_avg_acw"].ToString() == "")
                                            { hourlyinbound.total_avgacw = "00:00:00"; }
                                            else { hourlyinbound.total_avgacw = DbMyConn.MyReader["total_avg_acw"].ToString(); }
                                            hourlyinbound.total_blankcall = Convert.ToInt32(DbMyConn.MyReader["total_blankcall"]);
                                            hourlyinbound.total_wrongno = Convert.ToInt32(DbMyConn.MyReader["total_wrongno"]);
                                            hourlyinbound.total_inquiry = Convert.ToInt32(DbMyConn.MyReader["total_inquiry"]);
                                            hourlyinbound.total_complaint = Convert.ToInt32(DbMyConn.MyReader["total_complaint"]);
                                            hourlyinbound.total_prospectcust = Convert.ToInt32(DbMyConn.MyReader["total_prospect"]);
                                            hourlyinbound.total_request = Convert.ToInt32(DbMyConn.MyReader["total_request"]);
                                            hourlyinbound.total_testcall = Convert.ToInt32(DbMyConn.MyReader["total_testcall"]);
                                            hourlyinbound.total_others = Convert.ToInt32(DbMyConn.MyReader["total_others"]);
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
                        { DbMyConn.MyConn.Close(); }

                        listhourlyinbound.Add(hourlyinbound);
                    }

                }
                catch (Exception Ex)
                {
                    Global.WriteLog(Global.GetCurrentMethod(Ex));
                }
                finally
                { DbMyConn.MyConn.Close(); }

                return listhourlyinbound;
            }

        }
        public List<ReportHourlyOutbound> GetListHourlyOutbound(string _datefrom, int userid)
        {
            lock (Global.ThreadLockDao)
            {
                List<ReportHourlyOutbound> listhourlyoutbound = new List<ReportHourlyOutbound>();

                try
                {
                    ReportHourlyOutbound hourlyoutbound = null;
                    string _user_id = userid == 0 ? "" : " AND user_id=" + userid;
                    foreach (string hours in Global.HoursReport)
                    {
                        try
                        {
                            string SQL = string.Empty;
                            SQL += " SELECT ";
                            SQL += " (SELECT COUNT(id) FROM cc_calls WHERE direction_id=2 AND DATE(call_date)='" + _datefrom + "' AND TIME(call_date) LIKE '" + hours.Replace(":00", "") + "%' " + _user_id + ") AS total_outgoing,";
                            SQL += " (SELECT COUNT(id) FROM cc_calls WHERE call_status_id=3 AND DATE(call_date)='" + _datefrom + "' AND TIME(call_date) LIKE '" + hours.Replace(":00", "") + "%' " + _user_id + ") AS total_contact,";
                            SQL += " (SELECT COUNT(id) FROM cc_calls WHERE call_status_id=2 AND DATE(call_date)='" + _datefrom + "' AND TIME(call_date) LIKE '" + hours.Replace(":00", "") + "%' " + _user_id + ") AS total_unconnect,";
                            SQL += " (SELECT TIME_FORMAT(SEC_TO_TIME(SUM(TIME_TO_SEC(duration))),'%H:%i:%s') FROM cc_calls WHERE direction_id=2 AND DATE(call_date)='" + _datefrom + "' AND TIME(call_date) LIKE '" + hours.Replace(":00", "") + "%' " + _user_id + ") AS total_duration,";
                            SQL += " (SELECT TIME_FORMAT(SEC_TO_TIME(AVG(TIME_TO_SEC(duration))),'%H:%i:%s') FROM cc_calls WHERE direction_id=2 AND DATE(call_date)='" + _datefrom + "' AND TIME(call_date) LIKE '" + hours.Replace(":00", "") + "%' " + _user_id + ") AS total_avg_duration,";
                            SQL += " (SELECT COUNT(id) FROM cc_calls WHERE caller_type_id=15 AND DATE(call_date)='" + _datefrom + "' AND TIME(call_date) LIKE '" + hours.Replace(":00", "") + "%' " + _user_id + ") AS total_customer,";
                            SQL += " (SELECT COUNT(id) FROM cc_calls WHERE caller_type_id=16 AND DATE(call_date)='" + _datefrom + "' AND TIME(call_date) LIKE '" + hours.Replace(":00", "") + "%' " + _user_id + ") AS total_non_customer,";
                            SQL += " (SELECT COUNT(id) FROM cc_calls WHERE caller_type_id=17 AND DATE(call_date)='" + _datefrom + "' AND TIME(call_date) LIKE '" + hours.Replace(":00", "") + "%' " + _user_id + ") AS total_teknisi,";
                            SQL += " (SELECT COUNT(id) FROM cc_calls WHERE caller_type_id=18 AND DATE(call_date)='" + _datefrom + "' AND TIME(call_date) LIKE '" + hours.Replace(":00", "") + "%' " + _user_id + ") AS total_pic";

                            DbMyConn.MyConn.Open();

                            using (DbMyConn.MyCommand = new MySqlCommand(SQL, DbMyConn.MyConn))
                            {
                                using (DbMyConn.MyReader = DbMyConn.MyCommand.ExecuteReader())
                                {
                                    if (DbMyConn.MyReader.HasRows)
                                    {
                                        if (DbMyConn.MyReader.Read())
                                        {
                                            hourlyoutbound = new ReportHourlyOutbound();
                                            hourlyoutbound.hour = hours;
                                            hourlyoutbound.outgoing_call = Convert.ToInt32(DbMyConn.MyReader["total_outgoing"].ToString());
                                            hourlyoutbound.contact = Convert.ToInt32(DbMyConn.MyReader["total_contact"].ToString());
                                            hourlyoutbound.unconnect = Convert.ToInt32(DbMyConn.MyReader["total_unconnect"].ToString());
                                            if (DbMyConn.MyReader["total_duration"].ToString() == "")
                                            { hourlyoutbound.outboundcalltime = "00:00:00"; }
                                            else { hourlyoutbound.outboundcalltime = DbMyConn.MyReader["total_duration"].ToString(); }
                                            if (DbMyConn.MyReader["total_avg_duration"].ToString() == "")
                                            { hourlyoutbound.avg_outboundcalltime = "00:00:00"; }
                                            else { hourlyoutbound.avg_outboundcalltime = DbMyConn.MyReader["total_avg_duration"].ToString(); }
                                            hourlyoutbound.customer = Convert.ToInt32(DbMyConn.MyReader["total_customer"].ToString());
                                            hourlyoutbound.noncustomer = Convert.ToInt32(DbMyConn.MyReader["total_non_customer"].ToString());
                                            hourlyoutbound.teknisi = Convert.ToInt32(DbMyConn.MyReader["total_teknisi"].ToString());
                                            hourlyoutbound.pic = Convert.ToInt32(DbMyConn.MyReader["total_pic"].ToString());
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
                        { DbMyConn.MyConn.Close(); }

                        listhourlyoutbound.Add(hourlyoutbound);
                    }

                }
                catch (Exception Ex)
                {
                    Global.WriteLog(Global.GetCurrentMethod(Ex));
                }
                finally
                { DbMyConn.MyConn.Close(); }

                return listhourlyoutbound;
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

                    DbMyConn.MyConn.Open();
                    using (DbMyConn.MyCommand = new MySqlCommand(SQL, DbMyConn.MyConn))
                    {
                        using (DbMyConn.MyReader = DbMyConn.MyCommand.ExecuteReader())
                        {
                            if (DbMyConn.MyReader.HasRows)
                            {
                                while (DbMyConn.MyReader.Read())
                                {
                                    userName.Add(new Users()
                                    {
                                        id = Convert.ToInt16(DbMyConn.MyReader["id"]),
                                        username = DbMyConn.MyReader["username"].ToString()

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
                    DbMyConn.MyConn.Close();
                }


                return userName;
            }

        }
         
        private List<InboundType> GetHeader_ByInboundType()
        {
            lock (Global.ThreadLockDao)
            {
                List<InboundType> listinboundtype = new List<InboundType>();
                try
                {
                    string SQL = "SELECT * FROM cc_inbound_types  where is_active=1 ORDER BY type ASC";

                    DbMyConn2.MyConn.Open();
                    using (DbMyConn2.MyCommand = new MySqlCommand(SQL, DbMyConn2.MyConn))
                    {
                        using (DbMyConn2.MyReader = DbMyConn2.MyCommand.ExecuteReader())
                        {
                            if (DbMyConn2.MyReader.HasRows)
                            {
                                while (DbMyConn2.MyReader.Read())
                                {
                                    InboundType inboundtype = new InboundType();
                                    inboundtype.id = Convert.ToInt32(DbMyConn2.MyReader["id"]);
                                    inboundtype.type = DbMyConn2.MyReader["type"].ToString();
                                    listinboundtype.Add(inboundtype);
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
                    DbMyConn2.MyConn.Close();
                }

                return listinboundtype;
            }
        }

        //13-12
        public string[] ListHeaderReportInboundString = new string[] { "Total Date", "Total Hour" };
        public string[] ListHeaderReportInboundInt = new string[] { "Total Receive", "Total Answered", "Total Abandon", "Total Phantom" };
        public string[] ListHeaderReportInboundTimeSpan = new string[] { "Duration", "Total Avg Duration", "Total ACW", "Total Avg ACW" , "Total Speed Of Answer", "Total Avg Speed Of Answer" };
        public List<string> ListHeaderReportInbound()
        {
            List<string> ListRetval = new List<string>();

            //ListRetval.Add("Total Date");
            //ListRetval.Add("Total Hour");
            //ListRetval.Add("Total Recieve");
            //ListRetval.Add("Total Answered");
            //ListRetval.Add("Total Abandon");
            //ListRetval.Add("Total Phantom");
            //ListRetval.Add("Total Duration");
            //ListRetval.Add("Total Avg Duration");
            //ListRetval.Add("Total ACW");
            //ListRetval.Add("Total Avg ACW");
            //13-12
            ListRetval.AddRange(ListHeaderReportInboundString);
            ListRetval.AddRange(ListHeaderReportInboundInt);
            ListRetval.AddRange(ListHeaderReportInboundTimeSpan);
            foreach (var item in GetHeader_ByInboundType())
            {
                ListRetval.Add(item.type);
            }

            return ListRetval;
        }
        private int GetType_GetTypeDetailsInbound(int callid, int typeid)
        {
            lock (Global.ThreadLockDao)
            {
                int retVal = 0;
                try
                {
                    string SQL = string.Empty;
                    SQL += " SELECT ";
                    SQL += " COUNT(cc_inbound_type_tags.id) AS total";
                    SQL += " FROM cc_inbound_type_tags ";
                    SQL += " LEFT JOIN cc_inbound_types ON cc_inbound_types.id = cc_inbound_type_tags.inbound_type_id";
                    SQL += " WHERE cc_inbound_type_tags.call_id =" + callid + " AND cc_inbound_type_tags.inbound_type_id=" + typeid;
                    SQL += " ORDER BY cc_inbound_types.id ASC";



                    DbMyConn1.MyConn.Open();

                    using (DbMyConn1.MyCommand = new MySqlCommand(SQL, DbMyConn1.MyConn))
                    {
                        using (DbMyConn1.MyReader = DbMyConn1.MyCommand.ExecuteReader())
                        {
                            if (DbMyConn1.MyReader.HasRows)
                            {
                                if (DbMyConn1.MyReader.Read())
                                {
                                    retVal = Convert.ToInt32(DbMyConn1.MyReader["total"]);

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
                    DbMyConn1.MyConn.Close();
                }
                return retVal;
            }
        }
        public DataTable DynamicReportHourlyCallInbound(string _datefrom, int userid)
        {
            lock (Global.ThreadLockDao)
            {

                DataTable dt = new DataTable("tblHourlyInbound");

                try
                {
                    //foreach (var item in ListHeaderReportInbound())
                    //{
                    //    dt.Columns.Add(item);
                    //}

                    //13-12
                    foreach (var item in ListHeaderReportInboundString)
                    {
                        dt.Columns.Add(item);
                    }

                    foreach (var item in ListHeaderReportInboundInt)
                    {
                        dt.Columns.Add(item, typeof(int));
                    }

                    foreach (var item in ListHeaderReportInboundTimeSpan)
                    {
                        dt.Columns.Add(item, typeof(TimeSpan));
                    }

                    foreach (var item in GetHeader_ByInboundType())
                    {
                        dt.Columns.Add(item.type, typeof(int));
                    }

                    string _user_id = userid == 0 ? "" : " AND user_id=" + userid;

                    foreach (string hours in Global.HoursReport)
                    {
                        string SQL = string.Empty;
                        try
                        {
                            SQL += " SELECT ";
                            SQL += " (SELECT COUNT(id) FROM cc_calls WHERE direction_id=1 AND DATE(call_date)='" + _datefrom + "' AND TIME(call_date) LIKE '" + hours.Replace(":00", "") + "%' " + _user_id + ") AS total_recieve,";
                            SQL += " (SELECT COUNT(id) FROM cc_calls WHERE direction_id=1 AND call_status_id=1 AND DATE(call_date)='" + _datefrom + "' AND TIME(call_date) LIKE '" + hours.Replace(":00", "") + "%' " + _user_id + ") AS total_answered,";
                            SQL += " (SELECT COUNT(id) FROM cc_calls WHERE direction_id=1 AND call_status_id=2 AND DATE(call_date)='" + _datefrom + "' AND TIME(call_date) LIKE '" + hours.Replace(":00", "") + "%' " + _user_id + ") AS total_abandon,";
                            SQL += " (SELECT COUNT(id) FROM cc_calls WHERE direction_id=1 AND call_status_id=3 AND DATE(call_date)='" + _datefrom + "' AND TIME(call_date) LIKE '" + hours.Replace(":00", "") + "%' " + _user_id + ") AS total_phantom,";
                            SQL += " (SELECT TIME_FORMAT(SEC_TO_TIME(SUM(TIME_TO_SEC(duration))),'%H:%i:%s') FROM cc_calls WHERE direction_id=1 AND DATE(call_date)='" + _datefrom + "' AND call_status_id=1 AND TIME(call_date) LIKE '" + hours.Replace(":00", "") + "%' " + _user_id + ") AS total_duration,";
                            SQL += " (SELECT TIME_FORMAT(SEC_TO_TIME(AVG(TIME_TO_SEC(duration))),'%H:%i:%s') FROM cc_calls WHERE direction_id=1 AND DATE(call_date)='" + _datefrom + "' AND call_status_id=1 AND TIME(call_date) LIKE '" + hours.Replace(":00", "") + "%' " + _user_id + ") AS total_avg_duration,";
                            SQL += " (SELECT TIME_FORMAT(SEC_TO_TIME(SUM(TIME_TO_SEC(busy))),'%H:%i:%s') FROM cc_calls WHERE direction_id=1 AND DATE(call_date)='" + _datefrom + "' AND call_status_id=1 AND TIME(call_date) LIKE '" + hours.Replace(":00", "") + "%' " + _user_id + ") AS total_acw,";
                            SQL += " (SELECT TIME_FORMAT(SEC_TO_TIME(AVG(TIME_TO_SEC(busy))),'%H:%i:%s') FROM cc_calls WHERE direction_id=1 AND DATE(call_date)='" + _datefrom + "' AND call_status_id=1 AND TIME(call_date) LIKE '" + hours.Replace(":00", "") + "%' " + _user_id + ") AS total_avg_acw,";
                            SQL += " (SELECT TIME_FORMAT(SEC_TO_TIME(SUM(TIME_TO_SEC(delay))),'%H:%i:%s') FROM cc_calls WHERE direction_id=1 AND DATE(call_date)='" + _datefrom + "' AND call_status_id=1 AND TIME(call_date) LIKE '" + hours.Replace(":00", "") + "%' " + _user_id + ") AS total_speed_of_answer,";
                            SQL += " (SELECT TIME_FORMAT(SEC_TO_TIME(AVG(TIME_TO_SEC(delay))),'%H:%i:%s') FROM cc_calls WHERE direction_id=1 AND DATE(call_date)='" + _datefrom + "' AND call_status_id=1 AND TIME(call_date) LIKE '" + hours.Replace(":00", "") + "%' " + _user_id + ") AS total_avg_speed_of_answer;";
                            SQL += " SELECT cc_calls.id FROM cc_calls WHERE direction_id=1 AND DATE(call_date)='" + _datefrom + "' AND TIME(call_date) LIKE '" + hours.Replace(":00", "") + "%' " + _user_id + ";";

                            DbMyConn.MyConn.Open();
                            using (DbMyConn.MyCommand = new MySqlCommand(SQL, DbMyConn.MyConn))
                            {
                                using (DbMyConn.MyReader = DbMyConn.MyCommand.ExecuteReader())
                                {
                                    if (DbMyConn.MyReader.HasRows)
                                    {
                                        DataRow row;
                                        while (DbMyConn.MyReader.Read())
                                        {
                                            row = dt.NewRow();
                                            row[0] = _datefrom;
                                            row[1] = hours;
                                            //call.id = Convert.ToInt32(DbMyConn.MyReader["call_id"]);
                                            row[2] = DbMyConn.MyReader["total_recieve"].ToString();
                                            row[3] = DbMyConn.MyReader["total_answered"].ToString();
                                            row[4] = DbMyConn.MyReader["total_abandon"].ToString();
                                            row[5] = DbMyConn.MyReader["total_phantom"].ToString();

                                            if (DbMyConn.MyReader["total_duration"] == DBNull.Value)
                                            { row[6] = "00:00:00"; }
                                            else { row[6] = DbMyConn.MyReader["total_duration"].ToString(); }

                                            if (DbMyConn.MyReader["total_avg_duration"] == DBNull.Value)
                                            { row[7] = "00:00:00"; }
                                            else { row[7] = DbMyConn.MyReader["total_avg_duration"].ToString(); }

                                            if (DbMyConn.MyReader["total_acw"] == DBNull.Value)
                                            { row[8] = "00:00:00"; }
                                            else { row[8] = DbMyConn.MyReader["total_acw"].ToString(); }

                                            if (DbMyConn.MyReader["total_avg_acw"] == DBNull.Value)
                                            { row[9] = "00:00:00"; }
                                            else { row[9] = DbMyConn.MyReader["total_avg_acw"].ToString(); }

                                            if (DbMyConn.MyReader["total_speed_of_answer"] == DBNull.Value)
                                            { row[10] = "00:00:00"; }
                                            else { row[10] = DbMyConn.MyReader["total_speed_of_answer"].ToString(); }

                                            if (DbMyConn.MyReader["total_avg_speed_of_answer"] == DBNull.Value)
                                            { row[11] = "00:00:00"; }
                                            else { row[11] = DbMyConn.MyReader["total_avg_speed_of_answer"].ToString(); }

                                            int rowadd = 11;
                                            List<int> listcallid = new List<int>();
                                            if (DbMyConn.MyReader.NextResult())
                                            {
                                                while (DbMyConn.MyReader.Read())
                                                {
                                                    var call_id = DbMyConn.MyReader["id"].ToString();
                                                    if (string.IsNullOrEmpty(call_id))
                                                        call_id = "0";

                                                    listcallid.Add(Convert.ToInt32(call_id));
                                                }


                                                foreach (var itemx in GetHeader_ByInboundType())
                                                {
                                                    int result_type = 0;
                                                    foreach (var item in listcallid)
                                                    {
                                                        var result = GetType_GetTypeDetailsInbound(Convert.ToInt32(item), itemx.id);
                                                        result_type += result;
                                                    }

                                                    rowadd++;
                                                    row[rowadd] = result_type;
                                                }

                                                Console.WriteLine(rowadd);


                                            }
                                            dt.Rows.Add(row);
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


                }
                catch (Exception Ex)
                {
                    Global.WriteLog(Global.GetCurrentMethod(Ex));
                }
                finally
                {
                    DbMyConn.MyConn.Close();
                }


                return dt;

            }
        }
    
    
    
    
    }
}
