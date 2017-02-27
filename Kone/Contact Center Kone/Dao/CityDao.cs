using Contact_Center_Kone.Utility;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contact_Center_Kone.Dao
{
    public class CityDao
    {
        private Utility.DbMyConnection Conn = new Utility.DbMyConnection();

        public List<Entity.City> GetAllCities()
        {
            lock (Utility.Global.ThreadLockDao)
            {
                List<Entity.City> cities = new List<Entity.City>();

                cities.Add(new Entity.City() { id = "0", name = " --- " });

                lock (Global.ThreadLockDao)
                {
                    try
                    {
                        string SQL = "SELECT * FROM kabkot order by kabkot_name asc";

                        Conn.MyConn.Open();
                        using (Conn.MyCommand = new MySqlCommand(SQL, Conn.MyConn))
                        {
                            using (Conn.MyReader = Conn.MyCommand.ExecuteReader())
                            {
                                if (Conn.MyReader.HasRows)
                                {
                                    while (Conn.MyReader.Read())
                                    {
                                        cities.Add(new Entity.City()
                                        {
                                            id = Conn.MyReader["kabkot_id"].ToString(),
                                            name = Conn.MyReader["kabkot_name"].ToString()
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


                    return cities;
                }
            }

        }
    }
}
