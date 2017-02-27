using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using Contact_Center_Kone.Utility;

namespace Contact_Center_Kone.Dao
{
   
    public class WarrantyStatusDao
    {
        private Utility.DbMyConnection Conn = new Utility.DbMyConnection();

        public List<Entity.WarrantyStatus> GetAllWarrantyStatus()
        {
            lock (Utility.Global.ThreadLockDao)
            {
                List<Entity.WarrantyStatus> warrantyStatuses = new List<Entity.WarrantyStatus>();
                warrantyStatuses.Add(new Entity.WarrantyStatus()
                {
                    id = "0",
                    name = " --- "
                });


                lock (Global.ThreadLockDao)
                {
                    try
                    {
                        string SQL = "SELECT * FROM warranty_statuses";

                        Conn.MyConn.Open();
                        using (Conn.MyCommand = new MySqlCommand(SQL, Conn.MyConn))
                        {
                            using (Conn.MyReader = Conn.MyCommand.ExecuteReader())
                            {
                                if (Conn.MyReader.HasRows)
                                {
                                    while (Conn.MyReader.Read())
                                    {
                                        warrantyStatuses.Add(new Entity.WarrantyStatus()
                                        {
                                            id = Conn.MyReader["id"].ToString(),
                                            name = Conn.MyReader["name"].ToString()
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


                    return warrantyStatuses;
                }
            }

        }
    }
}
