using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using Contact_Center_Kone.Entity;
using Contact_Center_Kone.Utility;

namespace Contact_Center_Kone.Dao
{
    public class InboundStatusDao
    {
        DbMyConnection DbMyConn = new DbMyConnection();

        public InboundStatus GetInboundStatus_ByID(int id)
        {
            lock (Global.ThreadLockDao)
            {
                InboundStatus inboundstatus = new InboundStatus();

                try
                {
                    string SQL = "SELECT *  FROM cc_inbound_statuses WHERE id=" + id;
                    DbMyConn.MyConn.Open();
                    using (DbMyConn.MyCommand = new MySqlCommand(SQL, DbMyConn.MyConn))
                    {
                        using (DbMyConn.MyReader = DbMyConn.MyCommand.ExecuteReader())
                        {
                            if (DbMyConn.MyReader.HasRows)
                            {
                                if (DbMyConn.MyReader.Read())
                                {
                                    //direction = new Direction();
                                    inboundstatus.id = Convert.ToInt32(DbMyConn.MyReader["id"]);
                                    inboundstatus.status = DbMyConn.MyReader["status"].ToString();
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

                return inboundstatus;
            }
        }
    }
}
