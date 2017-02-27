using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contact_Center_Kone.Utility;

namespace Contact_Center_Kone.Dao
{
    public class CallMonitorsDao
    {
        private Utility.DbMyConnection myConn = new Utility.DbMyConnection();
        public bool UpdateStatusCallMonitors(string unique_id)//15-11
        {
            lock (Global.ThreadLockDao)
            {
                var result = false;
                try
                {
                    var queryString = "UPDATE call_monitors SET call_monitors.call_status_id=1,call_monitors.abandon_code_id=NULL" +
                                        " WHERE unique_id=" + unique_id;

                    myConn.MyConn.Open();
                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(queryString, myConn.MyConn))
                    {
                        myConn.MyCommand.Parameters.AddWithValue("@unique_id", unique_id);
                        result = (myConn.MyCommand.ExecuteNonQuery() == 1);
                        
                    };
                }
                catch (Exception ex)
                { Utility.Global.WriteLog(Utility.Global.GetCurrentMethod(ex)); }
                finally
                {
                    myConn.MyConn.Close();
                }
                return result;
            }

        }
    }
}
