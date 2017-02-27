using Contact_Center_Kone.Entity;
using Contact_Center_Kone.Utility;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contact_Center_Kone.Dao
{
    
    public class OutboundCallerTypeDao
    {
        DbMyConnection myConn = new DbMyConnection();
        public List<OutboundCallerType> GetListCallerType()
        {
            lock (Global.ThreadLockDao)
            {
                List<OutboundCallerType> List_outbounccallertype = new List<OutboundCallerType>();

                List_outbounccallertype.Add(new OutboundCallerType() { id = "0", type = " --- " });

                try
                {
                    //string SQL = "SELECT * FROM cc_caller_types where direction_id=2 and is_active=2 group by sort_id asc";
                    string SQL = "SELECT * FROM cc_caller_types where direction_id=2 and is_active=2";
                    //string SQL = "SELECT * FROM cc_caller_types where direction_id=2 and is_active=2 group by sort_id asc";
                    myConn.MyConn.Open();
                    using (myConn.MyCommand = new MySqlCommand(SQL, myConn.MyConn))
                    {
                        using (myConn.MyReader = myConn.MyCommand.ExecuteReader())
                        {
                            if (myConn.MyReader.HasRows)
                            {
                              

                                while (myConn.MyReader.Read())
                                {
                                    OutboundCallerType outboundCallerType = new OutboundCallerType();
                                    outboundCallerType.id = myConn.MyReader["id"].ToString();
                                    outboundCallerType.type = myConn.MyReader["type"].ToString();
                                    outboundCallerType.isActive = myConn.MyReader["is_active"].ToString() == "1" ? "No" : "Yes";
                                    List_outbounccallertype.Add(outboundCallerType);
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
                { myConn.MyConn.Close(); }

                return List_outbounccallertype;
            }
        }
    }
}
