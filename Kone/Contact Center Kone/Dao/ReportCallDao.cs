﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contact_Center_Kone.Entity;
using Contact_Center_Kone.Dao;
using Contact_Center_Kone.Utility;
using MySql.Data.MySqlClient;
using System.Data;

namespace Contact_Center_Kone.Dao
{
    public class ReportCallDao
    {
        DbMyConnection DbMyConn = new DbMyConnection();
        DbMyConnection DbMyConn1 = new DbMyConnection();
        DbMyConnection DbMyConn2 = new DbMyConnection();


        DirectionDao directiondao = new DirectionDao();
        OutboundCallMediaDao outboundcallmediadao = new OutboundCallMediaDao();
        ListTicketDao listticketdao = new ListTicketDao();
        private List<InboundType> GetHeader_ByInboundType()
        {
            lock (Global.ThreadLockDao)
            {
                List<InboundType> listinboundtype = new List<InboundType>();
                try
                {
                    string SQL = "SELECT * FROM cc_inbound_types WHERE is_active=1 ORDER BY id ASC ";
                    //string SQL = "SELECT * FROM cc_inbound_types";
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

        private List<OutboundType> GetHeader_ByOutboundType()
        {
            lock (Global.ThreadLockDao)
            {
                List<OutboundType> listoutboundtype = new List<OutboundType>();
                try
                {
                    string SQL = "SELECT * FROM cc_outbound_types ORDER BY id ASC";

                    DbMyConn2.MyConn.Open();
                    using (DbMyConn2.MyCommand = new MySqlCommand(SQL, DbMyConn2.MyConn))
                    {
                        using (DbMyConn2.MyReader = DbMyConn2.MyCommand.ExecuteReader())
                        {
                            if (DbMyConn2.MyReader.HasRows)
                            {
                                while (DbMyConn2.MyReader.Read())
                                {
                                    OutboundType outboundtype = new OutboundType();
                                    outboundtype.id = Convert.ToInt32(DbMyConn2.MyReader["id"]);
                                    outboundtype.type = DbMyConn2.MyReader["type"].ToString();
                                    listoutboundtype.Add(outboundtype);
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

                return listoutboundtype;
            }
        }

        private CallTypeTag GetType_GetTypeDetailsInbound(int callid, int typeid)
        {
            lock (Global.ThreadLockDao)
            {
                CallTypeTag calltypetag = null;
                try
                {
                    string SQL = string.Empty;
                    SQL += " SELECT ";
                    SQL += " cc_inbound_type_tags.id, cc_inbound_type_tags.call_id, cc_inbound_type_tags.inbound_type_id, cc_inbound_types.`type`";
                    SQL += " FROM cc_inbound_type_tags ";
                    SQL += " LEFT JOIN cc_inbound_types ON cc_inbound_types.id = cc_inbound_type_tags.inbound_type_id ";
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
                                    calltypetag = new CallTypeTag();
                                    calltypetag.id = Convert.ToInt32(DbMyConn1.MyReader["id"]);
                                    calltypetag.call_id = Convert.ToInt32(DbMyConn1.MyReader["call_id"]);
                                    calltypetag.type_id = Convert.ToInt32(DbMyConn1.MyReader["inbound_type_id"]);
                                    calltypetag.type_name = DbMyConn1.MyReader["type"].ToString();

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
                return calltypetag;
            }
        }

        private CallTypeTag GetType_GetTypeDetailsOutbound(int callid, int typeid)
        {
            lock (Global.ThreadLockDao)
            {
                CallTypeTag calltypetag = null;
                try
                {
                    string SQL = string.Empty;
                    SQL += " SELECT ";
                    SQL += " cc_call_type_tags.id, cc_call_type_tags.call_id,cc_call_type_tags.type_id,cc_call_type_tags.type_detail_id, ";
                    SQL += " cc_outbound_types.`type`,";
                    SQL += " cc_outbound_type_details.type_detail";
                    SQL += " FROM cc_call_type_tags ";
                    SQL += " LEFT JOIN cc_outbound_types ON cc_outbound_types.id = cc_call_type_tags.type_id";
                    SQL += " LEFT JOIN cc_outbound_type_details ON cc_outbound_type_details.id = cc_call_type_tags.type_detail_id";
                    SQL += " WHERE cc_call_type_tags.call_id =" + callid + " AND cc_call_type_tags.type_id=" + typeid;
                    SQL += " ORDER BY cc_outbound_types.id ASC";


                    DbMyConn1.MyConn.Open();

                    using (DbMyConn1.MyCommand = new MySqlCommand(SQL, DbMyConn1.MyConn))
                    {
                        using (DbMyConn1.MyReader = DbMyConn1.MyCommand.ExecuteReader())
                        {
                            if (DbMyConn1.MyReader.HasRows)
                            {
                                if (DbMyConn1.MyReader.Read())
                                {
                                    calltypetag = new CallTypeTag();
                                    calltypetag.id = Convert.ToInt32(DbMyConn1.MyReader["id"]);
                                    calltypetag.call_id = Convert.ToInt32(DbMyConn1.MyReader["call_id"]);
                                    calltypetag.type_id = Convert.ToInt32(DbMyConn1.MyReader["type_id"]);
                                    calltypetag.type_detail_id = Convert.ToInt32(DbMyConn1.MyReader["type_detail_id"]);
                                    calltypetag.type_name = DbMyConn1.MyReader["type"].ToString();
                                    calltypetag.type_detail_name = DbMyConn1.MyReader["type_detail"].ToString();

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
                return calltypetag;
            }
        }
        public List<string> ListHeaderReportInbound()
        {
            List<string> ListRetval = new List<string>();

            ListRetval.Add("Call Date");
            ListRetval.Add("Call Time");
            ListRetval.Add("Caller Name");
            ListRetval.Add("Caller Type");
            ListRetval.Add("User Login");
            ListRetval.Add("Shift");
            ListRetval.Add("Direction");
            ListRetval.Add("Inbound Status");
            ListRetval.Add("Address");
            ListRetval.Add("Building");
            ListRetval.Add("City"); 
            ListRetval.Add("Telp");
            ListRetval.Add("Hp"); 
            ListRetval.Add("Hostaddr");
            ListRetval.Add("HostName");
            ListRetval.Add("Extension");
            ListRetval.Add("Caller Number");
            ListRetval.Add("Reference No");
            //ListRetval.Add("Model");
            //ListRetval.Add("Tv Size");
            //ListRetval.Add("Sympto Code"); 
            ListRetval.Add("Duration");
            ListRetval.Add("Abandon");
            ListRetval.Add("Speed Of Answer");
            ListRetval.Add("After Call Work");
            //ListRetval.Add("Purchas Date");
            //ListRetval.Add("Problem Date"); 
            ListRetval.Add("Note");  
            //ListRetval.Add("Ticket Number");
            foreach (var item in GetHeader_ByInboundType())
            {
                ListRetval.Add(item.type);
                //ListRetval.Add(item.type + " Details");
                //Console.WriteLine("Jumlah List" + ListRetval.Count.ToString());
            }

            return ListRetval;
        }

        public List<string> ListHeaderReportOutbound()
        {
            List<string> ListRetval = new List<string>();

            ListRetval.Add("Call Date");
            ListRetval.Add("Call Time"); 
            ListRetval.Add("Agent Name");
            ListRetval.Add("Caller Name");
            ListRetval.Add("Direction");
            ListRetval.Add("Caller Type");
            //ListRetval.Add("Caller Type Detail");
            ListRetval.Add("Outbound Type");
            ListRetval.Add("Outbound Status");
            ListRetval.Add("Outbound Status Detail");
            ListRetval.Add("Shift");
            ListRetval.Add("Host Addrs");
            ListRetval.Add("Host Name");
            ListRetval.Add("Extension");
            ListRetval.Add("Duration");
            ListRetval.Add("Caller Number");
            ListRetval.Add("Note"); 
            ListRetval.Add("Ticket No");
            //foreach (var item in GetHeader_ByOutboundType())
            //{
            //    ListRetval.Add(item.type);
            //    ListRetval.Add(item.type + " Details");
            //    Console.WriteLine("Jumlah List" + ListRetval.Count.ToString());
            //}

            return ListRetval;
        }
        public List<ReportCallInbound> GetAll_call_inbound(string dtefrom, string dteuntil, int userid)
        {
            lock (Global.ThreadLockDao)
            {
                List<ReportCallInbound> listcall = new List<ReportCallInbound>();
                try
                {
                    string SQL = string.Empty;
                    SQL += "  SELECT  ";
                    SQL += " cc_calls.id AS call_id, cc_calls.call_date AS call_date, cc_customers.name AS cust_name, cc_users.username AS cust_agent, ";
                    SQL += " cc_directions.direction AS direction, cc_inbound_statuses.`status` AS inbound_status,";
                    SQL += " cc_inbound_caller_types.`type` AS inbound_caller_type, cc_shifts.shift AS shift,";
                    SQL += " cc_payment_methodes.methode AS paymeny_method, ";
                    SQL += " is_blankcall,is_wrongno,hostaddr,hostname,extension,duration,abandon,delay,busy,caller_number,note,phone_number ";
                    SQL += " FROM cc_calls ";
                    SQL += " LEFT JOIN cc_users ON cc_users.id = cc_calls.user_id ";
                    SQL += " LEFT JOIN cc_customers ON cc_customers.id = cc_calls.customer_id ";
                    SQL += " LEFT JOIN cc_directions ON cc_directions.id = cc_calls.id ";
                    SQL += " LEFT JOIN cc_inbound_statuses ON cc_inbound_statuses.id = cc_calls.call_status_id ";
                    SQL += " LEFT JOIN cc_inbound_caller_types ON cc_inbound_caller_types.id = cc_calls.inbound_caller_type_id  ";
                    SQL += " LEFT JOIN cc_shifts ON cc_shifts.id = cc_calls.shift_id ";
                    SQL += " LEFT JOIN cc_payment_methodes ON cc_payment_methodes.id = cc_calls.payment_methode_id ";
                    SQL += " WHERE DATE(call_date) BETWEEN '" + dtefrom + "' AND '" + dteuntil + "'";
                    SQL += " AND direction_id=1";
                    SQL += userid == 0 ? "" : " AND user_id=" + userid;

                    DbMyConn.MyConn.Open();
                    using (DbMyConn.MyCommand = new MySqlCommand(SQL, DbMyConn.MyConn))
                    {
                        using (DbMyConn.MyReader = DbMyConn.MyCommand.ExecuteReader())
                        {
                            if (DbMyConn.MyReader.HasRows)
                            {
                                while (DbMyConn.MyReader.Read())
                                {
                                    ReportCallInbound call = new ReportCallInbound();
                                    call.id = Convert.ToInt32(DbMyConn.MyReader["call_id"]);
                                    call.call_date = DbMyConn.MyReader["call_date"].ToString();
                                    call.customer = DbMyConn.MyReader["cust_name"].ToString();
                                    call.user_agent = DbMyConn.MyReader["cust_agent"].ToString();
                                    call.direction = DbMyConn.MyReader["direction"].ToString();
                                    call.call_status = DbMyConn.MyReader["inbound_status"].ToString();
                                    call.inbound_caller_type = DbMyConn.MyReader["inbound_caller_type"].ToString();
                                    call.shift = DbMyConn.MyReader["shift"].ToString();
                                    call.payment_method = DbMyConn.MyReader["paymeny_method"].ToString();
                                    call.blank_call = DbMyConn.MyReader["is_blankcall"].ToString();
                                    call.wrong_number = DbMyConn.MyReader["is_wrongno"].ToString();
                                    call.host_addr = DbMyConn.MyReader["hostaddr"].ToString();
                                    call.host_name = DbMyConn.MyReader["hostname"].ToString();
                                    call.extension = DbMyConn.MyReader["extension"].ToString();
                                    if (DbMyConn.MyReader["duration"] == DBNull.Value)
                                    { call.duration = "00:00:00"; }
                                    else { call.duration = DbMyConn.MyReader["duration"].ToString(); }
                                    if (DbMyConn.MyReader["abandon"] == DBNull.Value)
                                    { call.abandon = "00:00:00"; }
                                    else { call.abandon = DbMyConn.MyReader["abandon"].ToString(); }
                                    if (DbMyConn.MyReader["delay"] == DBNull.Value)
                                    { call.delay = "00:00:00"; }
                                    else { call.delay = DbMyConn.MyReader["delay"].ToString(); }
                                    if (DbMyConn.MyReader["busy"] == DBNull.Value)
                                    { call.busy = "00:00:00"; }
                                    else { call.busy = DbMyConn.MyReader["busy"].ToString(); }
                                    call.callernumber = DbMyConn.MyReader["caller_number"].ToString();
                                    call.note = DbMyConn.MyReader["note"].ToString();
                                    call.phonenumber = DbMyConn.MyReader["phone_number"].ToString();
                                    //call.inbound_type = DbMyConn.MyReader["inbound_type"].ToString();
                                    //call.inbound_type_detail = DbMyConn.MyReader["inbound_type_detail"].ToString();


                                    listcall.Add(call);
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

                return listcall;
            }
        }

        public List<ReportCallOutbound> GetAll_call_outbound(string dtefrom, string dteuntil, int userid)
        {
            lock (Global.ThreadLockDao)
            {
                List<ReportCallOutbound> listcall = new List<ReportCallOutbound>();
                try
                {
                    string SQL = string.Empty;
                    SQL += " SELECT ";
                    SQL += " cc_calls.id AS call_id,";
                    SQL += " DATE_FORMAT(cc_calls.call_date,'%d-%m-%Y') AS call_date,";
                    SQL += " DATE_FORMAT(cc_calls.call_date,'%T') AS call_time,";
                    SQL += " cc_users.username AS cust_agent,";
                    SQL += " cc_directions.direction AS direction,";
                    SQL += " cc_outbound_caller_types.`type` AS caller_type,";
                    SQL += " cc_outbound_statuses.`status` AS outbound_status,";
                    SQL += " cc_outbound_status_details.status_detail AS outbound_status_detail,";
                    SQL += " cc_shifts.shift AS shift";
                    SQL += " ,hostaddr,hostname,extension,duration,caller_number,note ";
                    SQL += " FROM cc_calls  ";
                    SQL += " LEFT JOIN cc_users ON cc_users.id = cc_calls.user_id ";
                    SQL += " LEFT JOIN cc_directions ON cc_directions.id = cc_calls.direction_id ";
                    SQL += " LEFT JOIN cc_outbound_caller_types ON cc_outbound_caller_types.id = cc_calls.caller_type_id";
                    SQL += " LEFT JOIN cc_outbound_statuses ON cc_outbound_statuses.id = cc_calls.call_status_id  ";
                    SQL += " LEFT JOIN cc_outbound_status_details ON cc_outbound_status_details.id = cc_calls.call_status_detail_id  ";
                    SQL += " LEFT JOIN cc_shifts ON cc_shifts.id = cc_calls.shift_id   ";
                    SQL += " WHERE DATE(call_date) BETWEEN '" + dtefrom + "' AND '" + dteuntil + "'";
                    SQL += " AND direction_id=2";
                    SQL += userid == 0 ? "" : " AND user_id=" + userid;

                    DbMyConn.MyConn.Open();
                    using (DbMyConn.MyCommand = new MySqlCommand(SQL, DbMyConn.MyConn))
                    {
                        using (DbMyConn.MyReader = DbMyConn.MyCommand.ExecuteReader())
                        {
                            if (DbMyConn.MyReader.HasRows)
                            {
                                while (DbMyConn.MyReader.Read())
                                {
                                    ReportCallOutbound call = new ReportCallOutbound();
                                    //call.id = Convert.ToInt32(DbMyConn.MyReader["call_id"]);
                                    call.call_date = DbMyConn.MyReader["call_date"].ToString();
                                    call.call_time = DbMyConn.MyReader["call_time"].ToString();
                                    call.user_agent = DbMyConn.MyReader["cust_agent"].ToString();
                                    call.direction = DbMyConn.MyReader["direction"].ToString();
                                    call.callertype = DbMyConn.MyReader["caller_type"].ToString();
                                    call.call_status = DbMyConn.MyReader["outbound_status"].ToString();
                                    call.call_status_detail = DbMyConn.MyReader["outbound_status_detail"].ToString();
                                    call.shift = DbMyConn.MyReader["shift"].ToString();
                                    call.host_addr = DbMyConn.MyReader["hostaddr"].ToString();
                                    call.host_name = DbMyConn.MyReader["hostname"].ToString();
                                    call.extension = DbMyConn.MyReader["extension"].ToString();
                                    if (DbMyConn.MyReader["duration"] == DBNull.Value)
                                    { call.duration = "00:00:00"; }
                                    else { call.duration = DbMyConn.MyReader["duration"].ToString(); }
                                    call.callernumber = DbMyConn.MyReader["caller_number"].ToString();
                                    call.note = DbMyConn.MyReader["note"].ToString();
                                    listcall.Add(call);
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

                return listcall;
            }
        }

        public DataTable GetAll_Dynamic_inbound(string dtefrom, string dteuntil, int userid, int callstatusid)
        {
            lock (Global.ThreadLockDao)
            {
                string SQL = string.Empty;
                DataTable dt = new DataTable("tblTest");

                try
                {

                    foreach (var item in ListHeaderReportInbound())
                    {
                        dt.Columns.Add(item);
                    }

                    SQL += " SELECT ";
                    SQL += " cc_calls.id AS call_id,";
                    SQL += " DATE_FORMAT(cc_calls.call_date,'%d-%m-%Y') AS call_date,";
                    SQL += " DATE_FORMAT(cc_calls.call_date,'%T') AS call_time,";
                    SQL += " cc_users.username AS cust_agent,";
                    SQL += " cc_calls.customer_name AS callername,";
                    SQL += " cct.type AS callertype,";
                    SQL += " cc_shifts.shift AS shift,";
                    SQL += " cc_directions.direction AS direction,";
                    SQL += " cc_inbound_statuses.`status` AS inbound_status,";
                    SQL += " cc_calls.address,";
                    SQL += " cc_calls.building,";
                    SQL += " cc_calls.city,";
                    SQL += " cc_calls.telp,";
                    SQL += " cc_calls.hp,";
                    SQL += " cc_calls.hostaddr,";
                    SQL += " cc_calls.hostname,";
                    SQL += " cc_calls.extension,";
                    SQL += " cc_calls.caller_number,";
                    SQL += " cc_calls.unique_id,";
                    //SQL += " models.name AS model,";
                    SQL += " tv_sizes.name AS tvsize,";
                    SQL += " symptom_codes.description AS symptomcode,";
                    SQL += " cc_calls.duration,";
                    SQL += " cc_calls.abandon,";
                    SQL += " cc_calls.delay,";
                    SQL += " cc_calls.busy,";
                    SQL += " cc_calls.purchase_date,";
                    SQL += " cc_calls.problem_date,";
                    SQL += " cc_calls.note";
                    SQL += " FROM cc_calls";
                    SQL += " LEFT JOIN cc_users ON cc_users.id = cc_calls.user_id";
                    SQL += " LEFT JOIN cc_directions ON cc_directions.id = cc_calls.direction_id";
                    SQL += " LEFT JOIN cc_inbound_statuses ON cc_inbound_statuses.id = cc_calls.call_status_id";
                    SQL += " LEFT JOIN cc_shifts ON cc_shifts.id = cc_calls.shift_id";
                    SQL += " LEFT JOIN cc_caller_types as cct ON cct.id=cc_calls.caller_type_id";//27-1
                    //SQL += " LEFT JOIN models ON models.id = cc_calls.model_id";
                    SQL += " LEFT JOIN tv_sizes ON tv_sizes.id = cc_calls.tv_size_id";
                    SQL += " LEFT JOIN symptom_codes ON symptom_codes.id = cc_calls.symptom_code_id";
                    SQL += " WHERE DATE(call_date) BETWEEN '" + dtefrom + "' AND '" + dteuntil + "'";
                    SQL += " AND cc_directions.id=1";
                    SQL += userid == 0 ? "" : " AND cc_calls.user_id=" + userid;
                    SQL += callstatusid == 0 ? "" : " AND cc_calls.call_status_id=" + callstatusid;

                    DbMyConn.MyConn.Open();
                    using (DbMyConn.MyCommand = new MySqlCommand(SQL, DbMyConn.MyConn))
                    {
                        using (DbMyConn.MyReader = DbMyConn.MyCommand.ExecuteReader())
                        {
                            if (DbMyConn.MyReader.HasRows)
                            {
                                while (DbMyConn.MyReader.Read())
                                {
                                    DataRow row = dt.NewRow();

                                    //call.id = Convert.ToInt32(DbMyConn.MyReader["call_id"]);
                                    row[0] = DbMyConn.MyReader["call_date"].ToString();
                                    row[1] = DbMyConn.MyReader["call_time"].ToString();
                                    row[2] = DbMyConn.MyReader["callername"].ToString();
                                    row[3] = DbMyConn.MyReader["callertype"].ToString();
                                    row[4] = DbMyConn.MyReader["cust_agent"].ToString();
                                    row[5] = DbMyConn.MyReader["shift"].ToString();
                                    row[6] = DbMyConn.MyReader["direction"].ToString();
                                    row[7] = DbMyConn.MyReader["inbound_status"].ToString();
                                    row[8] = DbMyConn.MyReader["address"].ToString();
                                    row[9] = DbMyConn.MyReader["building"].ToString();
                                    row[10] = DbMyConn.MyReader["city"].ToString();                                  
                                    row[11] = DbMyConn.MyReader["telp"].ToString();
                                    row[12] = DbMyConn.MyReader["hp"].ToString(); 
                                    row[13] = DbMyConn.MyReader["hostaddr"].ToString();
                                    row[14] = DbMyConn.MyReader["hostname"].ToString();
                                    row[15] = DbMyConn.MyReader["extension"].ToString();
                                    row[16] = DbMyConn.MyReader["caller_number"].ToString();
                                    row[17] = DbMyConn.MyReader["unique_id"].ToString();
                                    //row[14] = DbMyConn.MyReader["serial_no"].ToString();
                                    //row[15] = DbMyConn.MyReader["model"].ToString();
                                    // row[16] = DbMyConn.MyReader["tvsize"].ToString();
                                    //row[17] = DbMyConn.MyReader["symptomcode"].ToString(); 
                                    if (DbMyConn.MyReader["duration"] == DBNull.Value)
                                    { row[18] = "00:00:00"; }
                                    else { row[18] = DbMyConn.MyReader["duration"].ToString(); }

                                    if (DbMyConn.MyReader["abandon"] == DBNull.Value)
                                    { row[19] = "00:00:00"; }
                                    else { row[19] = DbMyConn.MyReader["abandon"].ToString(); }

                                    if (DbMyConn.MyReader["delay"] == DBNull.Value)
                                    { row[20] = "00:00:00"; }
                                    else { row[20] = DbMyConn.MyReader["delay"].ToString(); }

                                    if (DbMyConn.MyReader["busy"] == DBNull.Value)
                                    { row[21] = "00:00:00"; }
                                    else { row[21] = DbMyConn.MyReader["busy"].ToString(); }
                                    //row[22] = DbMyConn.MyReader["purchase_date"].ToString();
                                    //row[23] = DbMyConn.MyReader["problem_date"].ToString();
                                    row[22] = DbMyConn.MyReader["note"].ToString(); 
                                    //row[20] = listticketdao.GetTicketNo_ByMediaId_SourceMediaId(Convert.ToInt32(DbMyConn.MyReader["call_id"]), 4);
                                    int rowadd = 22;

                                    foreach (var itemx in GetHeader_ByInboundType())
                                    {
                                        CallTypeTag calltypetag = new CallTypeTag();
                                        calltypetag = GetType_GetTypeDetailsInbound(Convert.ToInt32(DbMyConn.MyReader["call_id"]), itemx.id);

                                        if (calltypetag != null)
                                        {
                                            rowadd++;
                                            row[rowadd] = "YES";

                                        }
                                        else
                                        {
                                            rowadd++;
                                            row[rowadd] = "NO";
                                        }
                                        //if (calltypetag != null)
                                        //{
                                        //    rowadd++;
                                        //    row[rowadd] = calltypetag.type_name;
                                        //    rowadd++;
                                        //    row[rowadd] = calltypetag.type_detail_name;
                                        //}
                                        //else
                                        //{
                                        //    rowadd++;
                                        //    rowadd++;
                                        //}
                                    }

                                    Console.WriteLine(rowadd);


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

                return dt;
            }

        }

        public DataTable GetAll_Dynamic_outbound(string dtefrom, string dteuntil, int userid)
        {
            lock (Global.ThreadLockDao)
            {
                string SQL = string.Empty;
                DataTable dt = new DataTable("tblTest");

                try
                {

                    foreach (var item in ListHeaderReportOutbound())
                    {
                        dt.Columns.Add(item);
                    }

                    SQL += " SELECT ";
                    SQL += " cc_calls.id AS call_id, ";
                    SQL += " DATE_FORMAT(cc_calls.call_date,'%d-%m-%Y') AS call_date, ";
                    SQL += " DATE_FORMAT(cc_calls.call_date,'%T') AS call_time,  ";
                    SQL += " cc_users.username AS cust_agent, ";
                    SQL += " cc_calls.customer_name as 'callername',";
                    SQL += " cc_directions.direction AS direction, ";
                    SQL += " cc_caller_types.`type` AS callertypes, ";
                    SQL += " cc_caller_type_detail.name AS callertypesdetail, ";
                    SQL += " cc_outbound_statuses.`status` AS outbound_status, ";
                    SQL += " cc_outbound_status_details.status_detail AS outbound_status_detail, ";
                    SQL += " cc_shifts.shift AS shift ,hostaddr,hostname,extension,duration,caller_number,note ";
                    SQL += " FROM cc_calls  ";
                    SQL += " LEFT JOIN cc_users ON cc_users.id = cc_calls.user_id   ";
                    SQL += " LEFT JOIN cc_directions ON cc_directions.id = cc_calls.direction_id  ";
                    SQL += " LEFT JOIN cc_outbound_statuses ON cc_outbound_statuses.id = cc_calls.call_status_id  ";
                    SQL += " LEFT JOIN cc_outbound_status_details ON cc_outbound_status_details.id = cc_calls.call_status_detail_id ";
                    SQL += " LEFT JOIN cc_shifts ON cc_shifts.id = cc_calls.shift_id ";
                    SQL += " LEFT JOIN cc_caller_types ON cc_caller_types.id = cc_calls.caller_type_id ";
                    SQL += " LEFT JOIN cc_caller_type_detail ON cc_caller_type_detail.id = cc_calls.caller_type_detail_id ";
                    SQL += " WHERE DATE(call_date) BETWEEN '" + dtefrom + "' AND '" + dteuntil + "'";
                    SQL += " AND cc_calls.direction_id=2";
                    SQL += userid == 0 ? "" : " AND user_id=" + userid;

                    DbMyConn.MyConn.Open();
                    using (DbMyConn.MyCommand = new MySqlCommand(SQL, DbMyConn.MyConn))
                    {
                        using (DbMyConn.MyReader = DbMyConn.MyCommand.ExecuteReader())
                        {
                            if (DbMyConn.MyReader.HasRows)
                            {
                                while (DbMyConn.MyReader.Read())
                                {
                                    DataRow row = dt.NewRow();
                                    OutboundCallMedia outboundcallmedia = new OutboundCallMedia();

                                    //call.id = Convert.ToInt32(DbMyConn.MyReader["call_id"]);
                                    row[0] = DbMyConn.MyReader["call_date"].ToString();
                                    row[1] = DbMyConn.MyReader["call_time"].ToString(); 
                                    row[2] = DbMyConn.MyReader["cust_agent"].ToString();
                                    row[3] = DbMyConn.MyReader["callername"].ToString();
                                    row[4] = DbMyConn.MyReader["direction"].ToString();
                                    row[5] = DbMyConn.MyReader["callertypes"].ToString();
                                    row[6] = DbMyConn.MyReader["callertypesdetail"].ToString();
                                    row[7] = DbMyConn.MyReader["outbound_status"].ToString();
                                    row[8] = DbMyConn.MyReader["outbound_status_detail"].ToString();
                                    row[9] = DbMyConn.MyReader["shift"].ToString();
                                    row[10] = DbMyConn.MyReader["hostaddr"].ToString();
                                    row[11] = DbMyConn.MyReader["hostname"].ToString();
                                    row[12] = DbMyConn.MyReader["extension"].ToString();
                                    if (DbMyConn.MyReader["duration"] == DBNull.Value)
                                    { row[13] = "00:00:00"; }
                                    else { row[13] = DbMyConn.MyReader["duration"].ToString(); }
                                    row[14] = DbMyConn.MyReader["caller_number"].ToString();
                                    row[15] = DbMyConn.MyReader["note"].ToString(); 
                                    row[16] = listticketdao.GetTicketNo_ByMediaId_SourceMediaId(Convert.ToInt32(DbMyConn.MyReader["call_id"]), 4);
                                    //int rowadd = 15;

                                    //foreach (var itemx in GetHeader_ByOutboundType())
                                    //{
                                    //    CallTypeTag calltypetag = new CallTypeTag();
                                    //    calltypetag = GetType_GetTypeDetailsOutbound(Convert.ToInt32(DbMyConn.MyReader["call_id"]), itemx.id);

                                    //    if (calltypetag != null)
                                    //    {
                                    //        rowadd++;
                                    //        row[rowadd] = calltypetag.type_name;
                                    //        rowadd++;
                                    //        row[rowadd] = calltypetag.type_detail_name;
                                    //    }
                                    //    else
                                    //    {
                                    //        rowadd++;
                                    //        rowadd++;
                                    //    }

                                    //    //foreach (var item in GetType_GetTypeDetails(Convert.ToInt32(DbMyConn.MyReader["call_id"]), itemx.id))
                                    //    //{  
                                    //    //}
                                    //    //rowadd++;
                                    //    //rowadd++;
                                    //}

                                    //Console.WriteLine(rowadd);


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

                return dt;
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

        public List<InboundStatus> GetAllCallStatus()
        {
            List<InboundStatus> callstatus = new List<InboundStatus>();
            lock (Global.ThreadLockDao)
            {
                try
                {
                    string SQL = "SELECT id,status FROM cc_inbound_statuses";

                    DbMyConn.MyConn.Open();
                    using (DbMyConn.MyCommand = new MySqlCommand(SQL, DbMyConn.MyConn))
                    {
                        using (DbMyConn.MyReader = DbMyConn.MyCommand.ExecuteReader())
                        {
                            if (DbMyConn.MyReader.HasRows)
                            {
                                while (DbMyConn.MyReader.Read())
                                {
                                    callstatus.Add(new InboundStatus()
                                    {
                                        id = Convert.ToInt16(DbMyConn.MyReader["id"]),
                                        status = DbMyConn.MyReader["status"].ToString()

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


                return callstatus;
            }

        }
    }
}
