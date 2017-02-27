using Contact_Center_Kone.Utility;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contact_Center_Kone.Dao
{
    public class TransferReasonDao
    {
        private Utility.DbMyConnection Conn = new Utility.DbMyConnection();

        public List<Entity.TransferReason> GetTrasnferReason()
        {
            lock (Utility.Global.ThreadLockDao)
            {
                List<Entity.TransferReason> listTransfer = new List<Entity.TransferReason>();
                lock (Global.ThreadLockDao)
                {
                    try
                    {
                        string SQL = "SELECT * FROM cc_transfer_reasons WHERE is_active=1";

                        Conn.MyConn.Open();
                        using (Conn.MyCommand = new MySqlCommand(SQL, Conn.MyConn))
                        {
                            using (Conn.MyReader = Conn.MyCommand.ExecuteReader())
                            {
                                if (Conn.MyReader.HasRows)
                                {
                                    while (Conn.MyReader.Read())
                                    {
                                        listTransfer.Add(new Entity.TransferReason()
                                        {
                                            id = Convert.ToInt32(Conn.MyReader["id"]),
                                            transfer   = Conn.MyReader["name"].ToString()
                                        });

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


                    return listTransfer;
                }
            }

        }


    }

}
