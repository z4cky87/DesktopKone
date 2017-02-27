using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using Contact_Center_Kone.Dao;
using Contact_Center_Kone.Entity;
using Contact_Center_Kone.Utility;

namespace Contact_Center_Kone.Dao
{
    public class QueueActivityDao
    {
        //DbConnectionQM MyConn = new DbConnectionQM();
        DbMyConnection MyConn = new DbMyConnection();
        public Entity.QueueActivity GetQueueActivity()
        {
            lock (Global.ThreadLockDao)
            {
                Entity.QueueActivity queueactivity = null;
                string SQL = "SELECT"
                            + " (SELECT COUNT(id) AS totalIvrQueue FROM call_monitors WHERE call_type_id=1 AND is_hangup=0) AS TotalIvrQueue,"
                            + " (SELECT COUNT(id) AS TotalQueue FROM call_monitors WHERE  call_type_id=2 AND is_hangup=0 AND TIMEDIFF(CURRENT_TIMESTAMP(),join_date) < '00:01:00') AS TotalQueue,"
                            + " (SELECT COUNT(id) AS TotalCallSystem FROM call_monitors WHERE DATE(ivr_date)=current_date) AS TotalCallSystem,"
                            + " (SELECT COUNT(id) AS AbandonCallSystem FROM call_monitors WHERE is_join=0 AND is_bridge=0 AND DATE(ivr_date)=current_date) AS AbandonCallSystem";

                try
                {
                    MyConn.MyConn.Open();
                    using (MyConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(SQL, MyConn.MyConn))
                    {
                        using (MyConn.MyReader = MyConn.MyCommand.ExecuteReader())
                        {
                            if (MyConn.MyReader.HasRows)
                            {
                                if (MyConn.MyReader.Read())
                                {
                                    queueactivity = new Entity.QueueActivity();
                                    queueactivity.TotalIvrQueue = MyConn.MyReader["TotalIvrQueue"].ToString();
                                    queueactivity.TotalCallQueue = MyConn.MyReader["TotalQueue"].ToString();
                                    queueactivity.TotalAbandonSystem = MyConn.MyReader["AbandonCallSystem"].ToString();
                                    queueactivity.TotalCallSystem = MyConn.MyReader["TotalCallSystem"].ToString();
                                }
                            }
                        }
                    }
                }
                catch (Exception Ex)
                {
                    Utility.Global.WriteLog(Global.GetCurrentMethod(Ex));
                }
                finally
                {
                    MyConn.MyConn.Close();
                }

                return queueactivity;
            }
        }
    }
}
