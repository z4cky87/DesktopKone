﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contact_Center_Kone.Entity;
using Contact_Center_Kone.Utility;
using MySql.Data.MySqlClient;

namespace Contact_Center_Kone.Dao
{
    public class ReportPBXDao
    {
        DbMyConnection Conn = new DbMyConnection();
        string SQL = "";
        void QuerySqlPbxAbandon()
        {
            SQL += " SELECT call_monitors.id,call_monitors.unique_id,";
            SQL += " DATE_FORMAT(call_monitors.ivr_date,'%d-%m-%Y') AS date,";
            SQL += " DATE_FORMAT(call_monitors.ivr_date,'%T') AS time,";
            SQL += " call_monitors.callerid_no,call_monitors.dnid,";
            SQL += " call_monitors.channel,call_monitors.talk_duration,call_monitors.username,call_monitors.talk_duration,";
            SQL += " call_monitors.host_address,call_monitors.extension,call_monitors.total_agent_ready,";
            SQL += " call_monitors.total_agent_break,call_monitors.total_agent_busy,call_monitors.total_agent_online,";
            SQL += " call_monitors.ivr_duration as ivr_duration,";
            SQL += " call_monitors.join_duration as queue_duration";
            SQL += " ,DATE(call_monitors.ivr_date) AS ivrdate";
            SQL += " ,TIME(call_monitors.ivr_date) AS ivrtime";
            SQL += " ,CASE call_monitors.call_status_id";
            SQL += " WHEN 0 THEN 'ABANDON'";
            SQL += " WHEN 1 THEN 'TRANSFERRED'";
            SQL += " ELSE ''";
            SQL += " END AS call_status";
            SQL += " ,CASE call_monitors.abandon_code_id";
            SQL += " WHEN 0 THEN 'IVR'";
            SQL += " WHEN 1 THEN 'QUEUE'";
            SQL += " ELSE ''";
            SQL += " END as abandon_code";
            SQL += " FROM call_monitors";
        }

        void QuerySqlPbxTransfered()
        {
            SQL += " SELECT call_monitors.id,call_monitors.unique_id,";
            SQL += " DATE_FORMAT(call_monitors.ivr_date,'%d-%m-%Y') AS date,";
            SQL += " DATE_FORMAT(call_monitors.ivr_date,'%T') AS time,";
            SQL += " call_monitors.callerid_no,call_monitors.dnid,";
            SQL += " call_monitors.channel,call_monitors.talk_duration,call_monitors.username,call_monitors.talk_duration,";
            SQL += " call_monitors.host_address,call_monitors.extension,call_monitors.total_agent_ready,";
            SQL += " call_monitors.total_agent_break,call_monitors.total_agent_busy,call_monitors.total_agent_online,";
            SQL += " call_monitors.ivr_duration as ivr_duration,";
            SQL += " call_monitors.join_duration as queue_duration";
            SQL += " ,DATE(call_monitors.ivr_date) AS ivrdate";
            SQL += " ,TIME(call_monitors.ivr_date) AS ivrtime";
            SQL += " ,CASE call_monitors.call_status_id";
            SQL += " WHEN 0 THEN 'ABANDON'";
            SQL += " WHEN 1 THEN 'TRANSFERRED'";
            SQL += " ELSE ''";
            SQL += " END AS call_status";
            SQL += " ,CASE call_monitors.abandon_code_id";
            SQL += " WHEN 0 THEN 'IVR'";
            SQL += " WHEN 1 THEN 'QUEUE'";
            SQL += " ELSE ''";
            SQL += " END as abandon_code";
            SQL += " FROM call_monitors";
            SQL += " JOIN cc_calls ON cc_calls.unique_id = call_monitors.unique_id";
        }


        public List<ReportPBX> GetAllPbx(string _dte_from, string _dte_until, int _filter_status_call)
        {
            lock (Global.ThreadLockDao)
            {
                List<ReportPBX> listpbx = new List<ReportPBX>();
                string _call_status_id = _filter_status_call == -1 ? "" : " AND call_status_id=" + _filter_status_call;
                try
                {
                    //string SQL = string.Empty;
                    //SQL += " SELECT call_monitors.id,call_monitors.unique_id,";
                    //SQL += " DATE_FORMAT(call_monitors.ivr_date,'%d-%m-%Y') AS date,";
                    //SQL += " DATE_FORMAT(call_monitors.ivr_date,'%T') AS time,";
                    //SQL += " call_monitors.callerid_no,call_monitors.dnid,";
                    //SQL += " call_monitors.channel,call_monitors.talk_duration,call_monitors.username,call_monitors.talk_duration,";
                    //SQL += " call_monitors.host_address,call_monitors.extension,call_monitors.total_agent_ready,";
                    //SQL += " call_monitors.total_agent_break,call_monitors.total_agent_busy,call_monitors.total_agent_online,";
                    //SQL += " call_monitors.ivr_duration as ivr_duration,";
                    //SQL += " call_monitors.join_duration as queue_duration";
                    //SQL += " ,DATE(call_monitors.ivr_date) AS ivrdate";
                    //SQL += " ,TIME(call_monitors.ivr_date) AS ivrtime";
                    //SQL += " ,CASE call_monitors.call_status_id";
                    //SQL += " WHEN 0 THEN 'ABANDON'";
                    //SQL += " WHEN 1 THEN 'TRANSFERRED'";
                    //SQL += " ELSE ''";
                    //SQL += " END AS call_status";
                    //SQL += " ,CASE call_monitors.abandon_code_id";
                    //SQL += " WHEN 0 THEN 'IVR'";
                    //SQL += " WHEN 1 THEN 'QUEUE'";
                    //SQL += " ELSE ''";
                    //SQL += " END as abandon_code";
                    //SQL += " FROM call_monitors";
                    //SQL += " WHERE DATE(ivr_date) BETWEEN '" + _dte_from + "' AND '" + _dte_until + "'";
                    //SQL += _call_status_id;

                    SQL = string.Empty;
                    if (_filter_status_call == -1)
                    {
                        QuerySqlPbxAbandon();
                        SQL += " WHERE DATE(ivr_date) BETWEEN '" + _dte_from + "' AND '" + _dte_until + "'";
                        SQL += " AND call_monitors.call_status_id =0";
                        SQL += " UNION";
                        QuerySqlPbxTransfered();
                        SQL += " WHERE DATE(ivr_date) BETWEEN '" + _dte_from + "' AND '" + _dte_until + "'";
                        SQL += " AND call_monitors.call_status_id =1";

                    }
                    else if (_filter_status_call == 0)
                    {
                        QuerySqlPbxAbandon();
                        SQL += " WHERE DATE(ivr_date) BETWEEN '" + _dte_from + "' AND '" + _dte_until + "'";
                        SQL += " AND call_monitors.call_status_id =0";
                    }
                    else if (_filter_status_call == 1)
                    {
                        QuerySqlPbxTransfered();
                        SQL += " WHERE DATE(ivr_date) BETWEEN '" + _dte_from + "' AND '" + _dte_until + "'";
                        SQL += " AND call_monitors.call_status_id =1";
                    }
                    Conn.MyConn.Open();
                    using (Conn.MyCommand = new MySqlCommand(SQL, Conn.MyConn))
                    {
                        using (Conn.MyReader = Conn.MyCommand.ExecuteReader())
                        {
                            if (Conn.MyReader.HasRows)
                            {
                                while (Conn.MyReader.Read())
                                {
                                    ReportPBX reportpbx = new ReportPBX();
                                    reportpbx.date = Conn.MyReader["date"].ToString();
                                    reportpbx.time = Conn.MyReader["time"].ToString();
                                    reportpbx.unique_id = Conn.MyReader["unique_id"].ToString();
                                    //reportpbx.source_name = Conn.MyReader["sourcename"].ToString();
                                    reportpbx.callerid_no = Conn.MyReader["callerid_no"].ToString();
                                    reportpbx.dnid = Conn.MyReader["dnid"].ToString();
                                    reportpbx.channel = Conn.MyReader["channel"].ToString();
                                    reportpbx.call_status = Conn.MyReader["call_status"].ToString();
                                    reportpbx.abandon_status = Conn.MyReader["abandon_code"].ToString();
                                    reportpbx.talk_duration = Conn.MyReader["talk_duration"].ToString();
                                    reportpbx.username = Conn.MyReader["username"].ToString();
                                    reportpbx.host_address = Conn.MyReader["host_address"].ToString();
                                    reportpbx.extention = Conn.MyReader["extension"].ToString();
                                    reportpbx.ivr_duration = Conn.MyReader["ivr_duration"].ToString();
                                    reportpbx.queue_duration = Conn.MyReader["queue_duration"].ToString();
                                    reportpbx.total_agent_ready = Conn.MyReader["total_agent_ready"].ToString();
                                    reportpbx.total_agent_break = Conn.MyReader["total_agent_break"].ToString();
                                    reportpbx.total_agent_busy = Conn.MyReader["total_agent_busy"].ToString();
                                    reportpbx.total_agent_online = Conn.MyReader["total_agent_online"].ToString();
                                    listpbx.Add(reportpbx);
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

                return listpbx;
            }
        }
    }
}
