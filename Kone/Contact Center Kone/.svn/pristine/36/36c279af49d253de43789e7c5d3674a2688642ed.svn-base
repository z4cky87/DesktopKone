using Contact_Center_Kone.Utility;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contact_Center_Kone.Dao
{
    public class AreaDao
    {
        private Utility.DbMyConnection Conn = new Utility.DbMyConnection();

        public List<Entity.Area> GetAllArea()
        {
            lock (Utility.Global.ThreadLockDao)
            {
                List<Entity.Area> areaName = new List<Entity.Area>();
                lock (Global.ThreadLockDao)
                {
                    try
                    {
                        string SQL = "SELECT * FROM areas";

                        Conn.MyConn.Open();
                        using (Conn.MyCommand = new MySqlCommand(SQL, Conn.MyConn))
                        {
                            using (Conn.MyReader = Conn.MyCommand.ExecuteReader())
                            {
                                if (Conn.MyReader.HasRows)
                                {
                                    while (Conn.MyReader.Read())
                                    {
                                        areaName.Add(new Entity.Area()
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


                    return areaName;
                }
            }

        }
    }
}
