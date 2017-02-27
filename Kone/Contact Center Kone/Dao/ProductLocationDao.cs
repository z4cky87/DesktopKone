using Contact_Center_Kone.Utility;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contact_Center_Kone.Dao
{
    public class ProductLocationDao
    {
        private Utility.DbMyConnection Conn = new Utility.DbMyConnection();

        public List<Entity.ProductLocation> GetAllProductLocation()
        {
            lock (Utility.Global.ThreadLockDao)
            {
                List<Entity.ProductLocation> productLocations = new List<Entity.ProductLocation>();
                productLocations.Add(new Entity.ProductLocation()
                {
                    id = "0",
                    name = " --- "
                });


                lock (Global.ThreadLockDao)
                {
                    try
                    {
                        string SQL = "SELECT * FROM product_locations";

                        Conn.MyConn.Open();
                        using (Conn.MyCommand = new MySqlCommand(SQL, Conn.MyConn))
                        {
                            using (Conn.MyReader = Conn.MyCommand.ExecuteReader())
                            {
                                if (Conn.MyReader.HasRows)
                                {
                                    while (Conn.MyReader.Read())
                                    {
                                        productLocations.Add(new Entity.ProductLocation()
                                        {
                                            id = Conn.MyReader["id"].ToString(),
                                            code = Conn.MyReader["code"].ToString(),
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


                    return productLocations;
                }
            }

        }
    }
}
