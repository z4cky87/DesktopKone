using Contact_Center_Kone.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contact_Center_Kone.Entity;
using MySql.Data.MySqlClient;

namespace Contact_Center_Kone.Dao
{
    public class SmsStatusDao
    {

        DbMyConnection Conn = new DbMyConnection();
         
        public List<SmsStatus> GetListSmsStatus(int directionid = 0)
        {
            lock (Global.ThreadLockDao)
            {
                List<SmsStatus> ListSmsStatus = new List<SmsStatus>();

                try
                {
                    string filterdirection = directionid == 0 ? "" : " WHERE direction_id=" + directionid;
                    string SQL = "SELECT * FROM cc_sms_statuses " + filterdirection;
                    Conn.MyConn.Open();
                    using (Conn.MyCommand = new MySqlCommand(SQL, Conn.MyConn))
                    {
                        using (Conn.MyReader = Conn.MyCommand.ExecuteReader())
                        {
                            if (Conn.MyReader.HasRows)
                            {
                                SmsStatus smsstatus = new SmsStatus();
                                smsstatus.sms_status_id = -2;
                                smsstatus.sms_status = null;
                                ListSmsStatus.Add(smsstatus);
                                while (Conn.MyReader.Read())
                                {
                                    smsstatus = new SmsStatus();
                                    smsstatus.sms_status_id = Convert.ToInt32(Conn.MyReader["sms_status_id"]);
                                    smsstatus.sms_status = Conn.MyReader["sms_status"].ToString();
                                    ListSmsStatus.Add(smsstatus);
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
                { Conn.MyConn.Close(); }

                return ListSmsStatus;
            }
        }

    }
}
