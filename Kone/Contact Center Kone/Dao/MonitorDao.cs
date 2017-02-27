using Contact_Center_Kone.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contact_Center_Kone.Dao
{
    public class MonitorDao
    {
        DbMyConnection DbMyConn = new DbMyConnection();

        public bool UpdateIsTransfered(int id,int reasonid)
        {
            bool RetVal = false;

            lock (Global.ThreadLockDao)
            { 
                try
                {
                    string SQL = "UPDATE cc_calls SET transfer_reason_id=" + reasonid + " WHERE id=" + id + " LIMIT 1";

                    DbMyConn.MyConn.Open();

                    using (DbMyConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(SQL, DbMyConn.MyConn))
                    {
                        DbMyConn.MyCommand.ExecuteNonQuery();
                        RetVal = true;
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
                return RetVal;
            }
        }

    }
}
