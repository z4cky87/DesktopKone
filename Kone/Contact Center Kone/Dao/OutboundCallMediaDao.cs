using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using Contact_Center_Kone.Utility;

namespace Contact_Center_Kone.Dao
{
    public class OutboundCallMediaDao
    {
        DbMyConnection DbMyConn = new DbMyConnection();
         
        public bool insert(Entity.OutboundCallMedia outboundCallMedia)
        {
            lock (Global.ThreadLockDao)
            {
                int retVal = 0;
                String sql = " insert into cc_outbound_call_media set "
                           + " call_id = @callId"
                           + ",media_id = @mediaId"
                           + ",source_media_id = @sourceMediaId"
                           ;

                try
                {
                    DbMyConn.MyConn.Open();
                    using (DbMyConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(sql, DbMyConn.MyConn))
                    {
                        DbMyConn.MyCommand.Parameters.AddWithValue("@callId", outboundCallMedia.callId);
                        DbMyConn.MyCommand.Parameters.AddWithValue("@mediaId", outboundCallMedia.mediaId);
                        DbMyConn.MyCommand.Parameters.AddWithValue("@sourceMediaId", outboundCallMedia.sourceMediaId);


                        retVal = DbMyConn.MyCommand.ExecuteNonQuery();


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

                return (retVal != 0);
            }
        }

        public bool delete(string callId)
        {
            lock (Global.ThreadLockDao)
            {
                int retVal = 0;
                string sql = "delete from cc_outbound_call_media where call_id = @callId";
                try
                {
                    DbMyConn.MyConn.Open();
                    using (DbMyConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(sql, DbMyConn.MyConn))
                    {
                        DbMyConn.MyCommand.Parameters.AddWithValue("@callId", callId);
                        retVal = DbMyConn.MyCommand.ExecuteNonQuery();
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

                return (retVal != 0);
            }
        }

        public Entity.OutboundCallMedia getCallMedia_ByCallId(int MediaId, string source_media_id)
        {
            lock (Global.ThreadLockDao)
            {
                Entity.OutboundCallMedia outboundCallMedia = null;


                try
                {
                    string SQL = string.Empty;

                    SQL += "SELECT *";
                    SQL += " FROM cc_ticket_tags";
                    SQL += " LEFT JOIN cc_source_media ON cc_source_media.id = cc_outbound_call_media.source_media_id";
                    SQL += " WHERE cc_ticket_tags.source_media_id=" + source_media_id + " AND cc_ticket_tags.media_id=" + MediaId;

                    using (DbMyConn.MyCommand = new MySqlCommand(SQL,DbMyConn.MyConn))
                    {
                        using (DbMyConn.MyReader = DbMyConn.MyCommand.ExecuteReader())
                        {
                            if (DbMyConn.MyReader.HasRows)
                            {
                                if (DbMyConn.MyReader.Read())
                                {
                                    outboundCallMedia = new Entity.OutboundCallMedia();
                                    outboundCallMedia.id =  DbMyConn.MyReader["id"].ToString();
                                    outboundCallMedia.callId = DbMyConn.MyReader["call_id"].ToString();
                                    outboundCallMedia.id = DbMyConn.MyReader["media_id"].ToString();
                                    outboundCallMedia.id = DbMyConn.MyReader["source_media_id"].ToString();
                                    outboundCallMedia.id = DbMyConn.MyReader["media"].ToString();
                                }
                            }
                        }
                    }

                }
                catch (Exception Ex)
                {
                    Global.WriteLog(Global.GetCurrentMethod(Ex));
                }
                finally { DbMyConn.MyConn.Close(); }

                return outboundCallMedia;
            }
        }
    
    }
}
