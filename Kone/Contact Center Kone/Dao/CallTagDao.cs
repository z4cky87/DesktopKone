using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contact_Center_Kone.Utility;

namespace Contact_Center_Kone.Dao
{
    public class CallTagDao
    {
        private Utility.DbMyConnection myConn = new Utility.DbMyConnection();
        public bool Insert(string callId,string typeId)
        {
            lock (Global.ThreadLockDao)
            {
                var result = false;
                try
                {
                    var queryString = "insert into cc_inbound_type_tags set " +
                                        "call_id=@callid," +
                                        "inbound_type_id=@typeid";

                    myConn.MyConn.Open();

                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(queryString, myConn.MyConn))
                    {
                        myConn.MyCommand.Parameters.AddWithValue("@callid", callId);
                        myConn.MyCommand.Parameters.AddWithValue("@typeid", typeId);
                        
                        result = (myConn.MyCommand.ExecuteNonQuery() == 1);
                    };

                }
                catch (Exception ex) { Utility.Global.WriteLog(Utility.Global.GetCurrentMethod(ex)); }
                finally
                {
                    myConn.MyConn.Close();
                }
                return result;
            }
        }
        public bool Delete(string callId)
        {
            lock (Global.ThreadLockDao)
            {
                var result = false;
                try
                {
                    var queryString = "delete from cc_inbound_type_tags where " +
                                        "call_id=@callid";


                    myConn.MyConn.Open();

                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(queryString, myConn.MyConn))
                    {
                        myConn.MyCommand.Parameters.AddWithValue("@callid", callId);


                        result = (myConn.MyCommand.ExecuteNonQuery() == 1);
                    };

                }
                catch (Exception ex) { Utility.Global.WriteLog(Utility.Global.GetCurrentMethod(ex)); }
                finally
                {
                    myConn.MyConn.Close();
                }
                return result;
            }
        }

        public string GetTypeDetailInboundName(string callId,string typeId)
        {
            lock (Global.ThreadLockDao)
            {
                var typeDetailName = "";
                try
                {
                    var query = "select citd.type_detail from cc_calls as cc " +
                                        " left join cc_call_type_tags as cctt on cc.id=cctt.call_id" +
                                        " left join cc_inbound_type_details as citd on cctt.type_detail_id=citd.id" +
                                        " where cc.id='" + callId + "' and cctt.type_id='" + typeId + "'";

                    myConn.MyConn.Open();
                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(query.ToString(), myConn.MyConn))
                    using (myConn.MyReader = myConn.MyCommand.ExecuteReader())
                    {
                        if (myConn.MyReader.HasRows)
                        {
                            while (myConn.MyReader.Read())
                            {
                                typeDetailName = myConn.MyReader[0].ToString();
                            };
                        };
                    }

                }
                catch (Exception ex)
                {
                    Utility.Global.WriteLog(Utility.Global.GetCurrentMethod(ex));
                }
                finally { myConn.MyConn.Close(); }
                return typeDetailName;
            }
        }
        public string GetTypeDetailOutboundName(string callId, string typeId)
        {
            lock (Global.ThreadLockDao)
            {
                var typeDetailName = "";
                try
                {
                    var query = "select citd.type_detail from cc_calls as cc " +
                                        " left join cc_call_type_tags as cctt on cc.id=cctt.call_id" +
                                        " left join cc_inbound_type_details as citd on cctt.type_detail_id=citd.id" +
                                        " where cc.id='" + callId + "' and cctt.type_id='" + typeId + "'";

                    myConn.MyConn.Open();
                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(query.ToString(), myConn.MyConn))
                    using (myConn.MyReader = myConn.MyCommand.ExecuteReader())
                    {
                        if (myConn.MyReader.HasRows)
                        {
                            while (myConn.MyReader.Read())
                            {
                                typeDetailName = myConn.MyReader[0].ToString();
                            };
                        };
                    }

                }
                catch (Exception ex)
                {
                    Utility.Global.WriteLog(Utility.Global.GetCurrentMethod(ex));
                }
                finally { myConn.MyConn.Close(); }
                return typeDetailName;
            }
        }
        public List<Entity.CallTag> getByCallId(String callId)
        {
            lock (Global.ThreadLockDao)
            {
                var callTags = new List<Entity.CallTag>();
                try
                {
                    var sql = "select * from cc_call_type_tags where call_id = "+callId;
                    myConn.MyConn.Open();
                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(sql.ToString(), myConn.MyConn))
                    {
                        using (myConn.MyReader = myConn.MyCommand.ExecuteReader())
                        {
                            if (myConn.MyReader.HasRows)
                            {
                                while (myConn.MyReader.Read())
                                {
                                    var callTag = new Entity.CallTag();
                                    callTag.id = myConn.MyReader["id"].ToString();
                                    callTag.callId = myConn.MyReader["call_id"].ToString();
                                    callTag.typeId = myConn.MyReader["type_id"].ToString();
                                    callTag.typeDetailId = myConn.MyReader["type_detail_id"].ToString();

                                    callTags.Add(callTag);
                                };
                            };
                        }
                    }


                }
                catch (Exception ex)
                {
                    
                }
                finally
                {

                }

                return callTags;
            }
        }
    }
}
