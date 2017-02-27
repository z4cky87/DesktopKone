using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contact_Center_Kone.Entity;
using Contact_Center_Kone.Utility;
using MySql.Data.MySqlClient;


namespace Contact_Center_Kone.Dao
{
    public class DashboardDao
    {
        DbMyConnection Conn = new DbMyConnection();
        DbMyConnection DbMyConn2 = new DbMyConnection();
        DbMyConnection DbMyConn1 = new DbMyConnection();
        public DashboardEntity GetCount_DashboardInbound(string dtefrom, string dteuntil, int directionid)
        {
            lock (Global.ThreadLockDao)
            {
                DashboardEntity dashboard = null;

                try
                {
                    string SQL = string.Empty;
                    if (directionid == 1)
                    {
                        //SQL += " SELECT";
                        //SQL += " (SELECT COUNT(cc_calls.id) FROM cc_calls ";
                        //SQL += " LEFT JOIN cc_call_type_tags ON cc_call_type_tags.call_id = cc_calls.id";
                        //SQL += " WHERE cc_call_type_tags.type_id=1 AND cc_calls.direction_id=" + directionid + " AND DATE(cc_calls.call_date) BETWEEN '" + dtefrom + "' AND '" + dteuntil + "') AS total_complain,";
                        //SQL += " (SELECT COUNT(cc_calls.id) FROM cc_calls ";
                        //SQL += " LEFT JOIN cc_call_type_tags ON cc_call_type_tags.call_id = cc_calls.id";
                        //SQL += " WHERE cc_call_type_tags.type_id=2 AND cc_calls.direction_id=" + directionid + " AND DATE(cc_calls.call_date) BETWEEN '" + dtefrom + "' AND '" + dteuntil + "') AS total_inquiry,";
                        //SQL += " (SELECT COUNT(cc_calls.id) FROM cc_calls ";
                        //SQL += " LEFT JOIN cc_call_type_tags ON cc_call_type_tags.call_id = cc_calls.id";
                        //SQL += " WHERE cc_call_type_tags.type_id=3 AND cc_calls.direction_id=" + directionid + " AND DATE(cc_calls.call_date) BETWEEN '" + dtefrom + "' AND '" + dteuntil + "') AS total_prospectcustomer,";
                        //SQL += " (SELECT COUNT(cc_calls.id) FROM cc_calls ";
                        //SQL += " LEFT JOIN cc_call_type_tags ON cc_call_type_tags.call_id = cc_calls.id";
                        //SQL += " WHERE cc_call_type_tags.type_id=4 AND cc_calls.direction_id=" + directionid + " AND DATE(cc_calls.call_date) BETWEEN '" + dtefrom + "' AND '" + dteuntil + "') AS total_request,";
                        //SQL += " (SELECT COUNT(cc_calls.id) FROM cc_calls ";
                        //SQL += " LEFT JOIN cc_call_type_tags ON cc_call_type_tags.call_id = cc_calls.id";
                        //SQL += " WHERE cc_call_type_tags.type_id=5 AND cc_calls.direction_id=" + directionid + " AND DATE(cc_calls.call_date) BETWEEN '" + dtefrom + "' AND '" + dteuntil + "') AS total_blankcall,";
                        //SQL += " (SELECT COUNT(cc_calls.id) FROM cc_calls ";
                        //SQL += " LEFT JOIN cc_call_type_tags ON cc_call_type_tags.call_id = cc_calls.id";
                        //SQL += " WHERE cc_call_type_tags.type_id=6 AND cc_calls.direction_id=" + directionid + " AND DATE(cc_calls.call_date) BETWEEN '" + dtefrom + "' AND '" + dteuntil + "') AS total_wrongno,";
                        //SQL += " (SELECT COUNT(cc_calls.id) FROM cc_calls ";
                        //SQL += " LEFT JOIN cc_call_type_tags ON cc_call_type_tags.call_id = cc_calls.id";
                        //SQL += " WHERE cc_call_type_tags.type_id=7 AND cc_calls.direction_id=" + directionid + " AND DATE(cc_calls.call_date) BETWEEN '" + dtefrom + "' AND '" + dteuntil + "') AS total_testcall,";
                        //SQL += " (SELECT COUNT(cc_calls.id) FROM cc_calls ";
                        //SQL += " LEFT JOIN cc_call_type_tags ON cc_call_type_tags.call_id = cc_calls.id";
                        //SQL += " WHERE cc_call_type_tags.type_id=8 AND cc_calls.direction_id=" + directionid + " AND DATE(cc_calls.call_date) BETWEEN '" + dtefrom + "' AND '" + dteuntil + "') AS total_others";

                        SQL += " SELECT";
                        SQL += " (SELECT COUNT(id) FROM cc_calls "; 
                        SQL += " WHERE is_complain=2 AND cc_calls.direction_id=" + directionid + " AND DATE(cc_calls.call_date) BETWEEN '" + dtefrom + "' AND '" + dteuntil + "') AS total_complain,";
                        SQL += " (SELECT COUNT(id) FROM cc_calls "; 
                        SQL += " WHERE is_inquiry=2 AND direction_id=" + directionid + " AND DATE(call_date) BETWEEN '" + dtefrom + "' AND '" + dteuntil + "') AS total_inquiry,";
                        SQL += " (SELECT COUNT(id) FROM cc_calls "; 
                        SQL += " WHERE is_prospectcustomer=2 AND direction_id=" + directionid + " AND DATE(call_date) BETWEEN '" + dtefrom + "' AND '" + dteuntil + "') AS total_prospectcustomer,";
                        SQL += " (SELECT COUNT(id) FROM cc_calls "; 
                        SQL += " WHERE is_request=2 AND direction_id=" + directionid + " AND DATE(call_date) BETWEEN '" + dtefrom + "' AND '" + dteuntil + "') AS total_request,";
                        SQL += " (SELECT COUNT(id) FROM cc_calls "; 
                        SQL += " WHERE is_blankcall=2 AND direction_id=" + directionid + " AND DATE(call_date) BETWEEN '" + dtefrom + "' AND '" + dteuntil + "') AS total_blankcall,";
                        SQL += " (SELECT COUNT(id) FROM cc_calls "; 
                        SQL += " WHERE is_wrongno=2 AND direction_id=" + directionid + " AND DATE(call_date) BETWEEN '" + dtefrom + "' AND '" + dteuntil + "') AS total_wrongno,";
                        SQL += " (SELECT COUNT(id) FROM cc_calls "; 
                        SQL += " WHERE is_testcall=2 AND direction_id=" + directionid + " AND DATE(call_date) BETWEEN '" + dtefrom + "' AND '" + dteuntil + "') AS total_testcall,";
                        SQL += " (SELECT COUNT(id) FROM cc_calls "; 
                        SQL += " WHERE is_others=2 AND direction_id=" + directionid + " AND DATE(call_date) BETWEEN '" + dtefrom + "' AND '" + dteuntil + "') AS total_others";


                    }
                    else if (directionid == 2)
                    {
                        SQL += " SELECT ";
                        SQL += " (SELECT COUNT(cc_calls.id) FROM cc_calls ";
                        SQL += " LEFT JOIN cc_outbound_caller_types ON cc_outbound_caller_types.id = cc_calls.id ";
                        SQL += " WHERE cc_calls.caller_type_id=1 AND cc_calls.direction_id=" + directionid + "  AND DATE(cc_calls.call_date) BETWEEN '" + dtefrom + "' AND '" + dteuntil + "') AS total_customer,";
                        SQL += " (SELECT COUNT(cc_calls.id) FROM cc_calls ";
                        SQL += " LEFT JOIN cc_outbound_caller_types ON cc_outbound_caller_types.id = cc_calls.id ";
                        SQL += " WHERE cc_calls.caller_type_id=2 AND cc_calls.direction_id=" + directionid + "  AND DATE(cc_calls.call_date) BETWEEN '" + dtefrom + "' AND '" + dteuntil + "') AS total_others,";
                        SQL += " (SELECT COUNT(cc_calls.id) FROM cc_calls ";
                        SQL += " LEFT JOIN cc_outbound_caller_types ON cc_outbound_caller_types.id = cc_calls.id ";
                        SQL += " WHERE cc_calls.caller_type_id=3 AND cc_calls.direction_id=" + directionid + "  AND DATE(cc_calls.call_date) BETWEEN '" + dtefrom + "' AND '" + dteuntil + "') AS total_dealer";
                    }

                    
                   
                    Conn.MyConn.Open();
                    using (Conn.MyCommand = new MySqlCommand(SQL,Conn.MyConn))
                    {
                        using (Conn.MyReader = Conn.MyCommand.ExecuteReader())
                        {
                            if (Conn.MyReader.HasRows)
                            {
                                if (Conn.MyReader.Read())
                                {   
                                    dashboard = new DashboardEntity();
                                    if (directionid == 1)
                                    {
                                        dashboard.total_complain = Conn.MyReader["total_complain"].ToString();
                                        dashboard.total_inquiry = Conn.MyReader["total_inquiry"].ToString();
                                        dashboard.total_prospect_customer = Conn.MyReader["total_prospectcustomer"].ToString();
                                        dashboard.total_request = Conn.MyReader["total_request"].ToString();
                                        dashboard.total_blankcall = Conn.MyReader["total_blankcall"].ToString();
                                        dashboard.total_wrongnumber = Conn.MyReader["total_wrongno"].ToString();
                                        dashboard.total_testcall = Conn.MyReader["total_testcall"].ToString();
                                        dashboard.total_others = Conn.MyReader["total_others"].ToString();
                                    }
                                    else if(directionid == 2)
                                    {
                                        dashboard.total_customer = Conn.MyReader["total_customer"].ToString();
                                        dashboard.total_others = Conn.MyReader["total_others"].ToString();
                                        dashboard.total_dealer = Conn.MyReader["total_dealer"].ToString();
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
                    Conn.MyConn.Close();
                }

                return dashboard;
            }
        }


        private List<InboundType> GetHeader_ByInboundType()
        {
            lock (Global.ThreadLockDao)
            {
                List<InboundType> listinboundtype = new List<InboundType>();
                try
                {
                    string SQL = "SELECT * FROM cc_inbound_types ORDER BY type ASC";

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
        public List<DynamicDashboard> dynamicDashboardInbound(string dtefrom, string dteuntil)
        {
            lock (Global.ThreadLockDao)
            {
                List<DynamicDashboard> listdasboard = new List<DynamicDashboard>();

                string SQL = string.Empty;


                SQL += " SELECT cc_calls.id FROM cc_calls WHERE direction_id=1 AND  DATE(call_date) BETWEEN '" + dtefrom + "' AND '" + dteuntil + "';";
                try
                {
                    Conn.MyConn.Open();
                    using (Conn.MyCommand = new MySqlCommand(SQL, Conn.MyConn))
                    {
                        using (Conn.MyReader = Conn.MyCommand.ExecuteReader())
                        {
                            if (Conn.MyReader.HasRows)
                            {
                                List<int> listcallid = new List<int>();
                                while (Conn.MyReader.Read())
                                {
                                    var call_id = Conn.MyReader["id"].ToString();
                                    if (string.IsNullOrEmpty(call_id))
                                        call_id = "0";

                                    listcallid.Add(Convert.ToInt32(call_id));
                                }


                                foreach (var itemx in GetHeader_ByInboundType())
                                {
                                    DynamicDashboard dDashboard = new DynamicDashboard();
                                    int result_type = 0;
                                    foreach (var item in listcallid)
                                    {
                                        var result = GetType_GetTypeDetailsInbound(Convert.ToInt32(item), itemx.id);
                                        result_type += result;
                                    }
                                    dDashboard.name = itemx.type;
                                    dDashboard.total = result_type.ToString();
                                    listdasboard.Add(dDashboard);
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


                return listdasboard;
            }
        }

        private List<OutboundCallerType> GetHeader_ByOutboundCallerType()
        {
            lock (Global.ThreadLockDao)
            {
                List<OutboundCallerType> listinboundtype = new List<OutboundCallerType>();
                try
                {
                    string SQL = "SELECT * FROM cc_caller_types WHERE direction_id=2 ORDER BY type ASC";

                    DbMyConn2.MyConn.Open();
                    using (DbMyConn2.MyCommand = new MySqlCommand(SQL, DbMyConn2.MyConn))
                    {
                        using (DbMyConn2.MyReader = DbMyConn2.MyCommand.ExecuteReader())
                        {
                            if (DbMyConn2.MyReader.HasRows)
                            {
                                while (DbMyConn2.MyReader.Read())
                                {
                                    OutboundCallerType inboundtype = new OutboundCallerType();
                                    inboundtype.id = DbMyConn2.MyReader["id"].ToString();
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

        private int GetType_GetCallerTypeOutbound(int callid, int typeid, string dtefrom, string dteuntil)
        {
            lock (Global.ThreadLockDao)
            {
                int retVal = 0;
                try
                {
                    string SQL = string.Empty;

                    SQL += "SELECT COUNT(cc_calls.id) AS total FROM cc_calls WHERE direction_id=2 AND  DATE(call_date) BETWEEN '" + dtefrom + "' AND '" + dteuntil + "' AND caller_type_id=" + typeid;


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

        public List<DynamicDashboard> dynamicDashboardOutbound(string dtefrom, string dteuntil)
        {
            lock (Global.ThreadLockDao)
            {
                List<DynamicDashboard> listdasboard = new List<DynamicDashboard>();

                string SQL = string.Empty;

                SQL += " SELECT cc_calls.id FROM cc_calls WHERE direction_id=2 AND  DATE(call_date) BETWEEN '" + dtefrom + "' AND '" + dteuntil + "';";
                try
                {
                    Conn.MyConn.Open();
                    using (Conn.MyCommand = new MySqlCommand(SQL, Conn.MyConn))
                    {
                        using (Conn.MyReader = Conn.MyCommand.ExecuteReader())
                        {
                            if (Conn.MyReader.HasRows)
                            {
                                List<int> listcallid = new List<int>();
                                while (Conn.MyReader.Read())
                                {
                                    var call_id = Conn.MyReader["id"].ToString();
                                    if (string.IsNullOrEmpty(call_id))
                                        call_id = "0";

                                    listcallid.Add(Convert.ToInt32(call_id));
                                }


                                foreach (var itemx in GetHeader_ByOutboundCallerType())
                                {
                                    DynamicDashboard dDashboard = new DynamicDashboard();
                                    int result_type = 0;
                                    foreach (var item in listcallid)
                                    {
                                        var result = GetType_GetCallerTypeOutbound(Convert.ToInt32(item), Convert.ToInt32(itemx.id), dtefrom,dteuntil);
                                        result_type += result;
                                    }
                                    dDashboard.name = itemx.type;
                                    dDashboard.total = result_type.ToString();
                                    listdasboard.Add(dDashboard);
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


                return listdasboard;
            }
        }

    }
}
