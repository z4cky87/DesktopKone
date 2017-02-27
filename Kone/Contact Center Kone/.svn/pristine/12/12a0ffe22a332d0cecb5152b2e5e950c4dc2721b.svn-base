using Contact_Center_Kone.Utility;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contact_Center_Kone.Dao
{
    public class TvSizeDao
    {
        private Utility.DbMyConnection Conn = new Utility.DbMyConnection();
        public List<Entity.TvSize> GetAllTvSize()
        {
            lock (Utility.Global.ThreadLockDao)
            {
                List<Entity.TvSize> sizes = new List<Entity.TvSize>();
                sizes.Add(new Entity.TvSize()
                            {
                                id="0",name=" --- "
                            }
                            );
                lock (Global.ThreadLockDao)
                {
                    try
                    {
                        string SQL = " select id," +
                                        " name " +
                                        " from tv_sizes ";

                        Conn.MyConn.Open();
                        using (Conn.MyCommand = new MySqlCommand(SQL, Conn.MyConn))
                        {
                            using (Conn.MyReader = Conn.MyCommand.ExecuteReader())
                            {
                                if (Conn.MyReader.HasRows)
                                {

                                    while (Conn.MyReader.Read())
                                    {
                                        sizes.Add(new Entity.TvSize()
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


                    return sizes;
                }
            }

        }
    }
}
