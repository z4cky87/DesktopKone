using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contact_Center_Kone.Dao
{
    public class ProductTypeDao
    {
        private Utility.DbMyConnection myConn = new Utility.DbMyConnection();
        public bool Insert(Entity.ProductType myProductType)
        {
            lock (Utility.Global.ThreadLockDao)
            {
                var result = false;
                try
                {
                    var queryString = "insert into product_type set " +
                                        "name=@name," +
                                        "is_active=@isactive";


                    myConn.MyConn.Open();

                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(queryString, myConn.MyConn))
                    {
                        myConn.MyCommand.Parameters.AddWithValue("@name", myProductType.name);
                        myConn.MyCommand.Parameters.AddWithValue("@isactive", myProductType.isActive);
                        result = (myConn.MyCommand.ExecuteNonQuery() == 1);

                    };

                }
                catch (Exception ex)
                {
                    result = false;
                    Utility.Global.WriteLog(Utility.Global.GetCurrentMethod(ex));
                }
                finally
                {
                    myConn.MyConn.Close();
                }
                return result;
            }
        }
        public bool Update(Entity.ProductType myProductType)
        {
            lock (Utility.Global.ThreadLockDao)
            {
                var result = false;
                try
                {
                    var queryString = "update product_type set " +
                                        "name=@name," +
                                        "is_active=@isactive" +
                                        " where id=@id";

                    myConn.MyConn.Open();

                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(queryString, myConn.MyConn))
                    {
                        myConn.MyCommand.Parameters.AddWithValue("@name", myProductType.name);
                        myConn.MyCommand.Parameters.AddWithValue("@isactive", myProductType.isActive);
                        myConn.MyCommand.Parameters.AddWithValue("@id", myProductType.id);
                        result = (myConn.MyCommand.ExecuteNonQuery() == 1);
                    }

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
    
        public List<Entity.ProductType> GetAll(bool isActiveFilter)
        {
            lock (Utility.Global.ThreadLockDao)
            {
                var productTypes = new List<Entity.ProductType>();
                productTypes.Add(new Entity.ProductType() { id = 0,name = " --- " });
                try
                {
                    var query = "Select id,name" +
                                " from product_types";

                    query += isActiveFilter ? " where is_active=1" : "";

                    myConn.MyConn.Open();
                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(query, myConn.MyConn))
                    using (myConn.MyReader = myConn.MyCommand.ExecuteReader())
                    {
                        if (myConn.MyReader.HasRows)
                        {
                            while (myConn.MyReader.Read())
                            {
                                productTypes.Add(new Entity.ProductType()
                                {
                                    id = Convert.ToInt32(myConn.MyReader["id"]),
                                    name = myConn.MyReader["name"].ToString(),
                                  //  isActive = Convert.ToInt32(myConn.MyReader["is_active"]) == 1 ? "Yes" : "No"
                                });
                            };
                        };
                    }

                }
                catch (Exception ex)
                {
                    Utility.Global.WriteLog(Utility.Global.GetCurrentMethod(ex));
                }
                finally { myConn.MyConn.Close(); }
                return productTypes;
            }
        }
        public List<Entity.ProductType> GetAllWhereActive()
        {
            lock (Utility.Global.ThreadLockDao)
            {
                var productTypes = new List<Entity.ProductType>();
                try
                {
                    var query = "Select id,name" +
                                " from product_types where is_active=1";

                    myConn.MyConn.Open();
                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(query, myConn.MyConn))
                    using (myConn.MyReader = myConn.MyCommand.ExecuteReader())
                    {
                        if (myConn.MyReader.HasRows)
                        {
                            while (myConn.MyReader.Read())
                            {
                                productTypes.Add(new Entity.ProductType()
                                {
                                    id = Convert.ToInt32(myConn.MyReader["id"]),
                                    name = myConn.MyReader["name"].ToString(),

                                });
                            };
                        };
                    }

                }
                catch (Exception ex)
                {
                    Utility.Global.WriteLog(Utility.Global.GetCurrentMethod(ex));
                }
                finally { myConn.MyConn.Close(); }
                return productTypes;
            }
        }       
    }
}
