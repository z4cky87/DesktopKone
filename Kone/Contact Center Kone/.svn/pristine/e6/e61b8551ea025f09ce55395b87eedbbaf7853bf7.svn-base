using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contact_Center_Kone.Utility;
using MySql.Data.MySqlClient;

namespace Contact_Center_Kone.Dao
{
    public class OutboundStatusDetailDao
    {
        DbMyConnection DbMyConn = new DbMyConnection();

        public List<Entity.OutboundStatusDetail> getAll(String outboundStatusId)
        {
            lock (Global.ThreadLockDao)
            {
                var outboundStatusDetails = new List<Entity.OutboundStatusDetail>();
                String sql = "select * from cc_outbound_status_details where outbound_status_id = " + outboundStatusId;

                try
                {
                    DbMyConn.MyConn.Open();
                    using (DbMyConn.MyCommand = new MySqlCommand(sql, DbMyConn.MyConn))
                    {
                        using (DbMyConn.MyReader = DbMyConn.MyCommand.ExecuteReader())
                        {
                            if (DbMyConn.MyReader.HasRows)
                            {
                                while (DbMyConn.MyReader.Read())
                                {
                                    Entity.OutboundStatusDetail osd = new Entity.OutboundStatusDetail();
                                    osd.id = Convert.ToInt32(DbMyConn.MyReader["id"]);
                                    osd.status_detail = DbMyConn.MyReader["status_detail"].ToString();
                                    osd.outbound_status_id = Convert.ToInt32(DbMyConn.MyReader["outbound_status_id"]);

                                    outboundStatusDetails.Add(osd);
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

                return outboundStatusDetails;
            }
        }
    }
}
