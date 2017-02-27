using Contact_Center_Kone.Utility;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contact_Center_Kone.Dao
{
    public class ModelDao
    {
        private Utility.DbMyConnection Conn = new Utility.DbMyConnection();
        public List<Entity.Model> GetAllModel()
        {
            lock (Utility.Global.ThreadLockDao)
            {
                List<Entity.Model> models = new List<Entity.Model>();
                lock (Global.ThreadLockDao)
                {
                    try
                    {
                        string SQL = " select m.id,"+
                                        " pt.name as productType,m.name as modelName "+
                                        " from models as m "+
                                        " left join product_types as pt on m.product_type_id=pt.id";

                        Conn.MyConn.Open();
                        using (Conn.MyCommand = new MySqlCommand(SQL, Conn.MyConn))
                        {
                            using (Conn.MyReader = Conn.MyCommand.ExecuteReader())
                            {
                                if (Conn.MyReader.HasRows)
                                {
                                    while (Conn.MyReader.Read())
                                    {
                                        models.Add(new Entity.Model()
                                        {
                                            Id = Conn.MyReader["id"].ToString(),
                                            ProductType = Conn.MyReader["productType"].ToString(),
                                            Name = Conn.MyReader["modelName"].ToString()
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


                    return models;
                }
            }

        }
        public List<Entity.Model> GetAllModel(string productTypeId,string modelName)
        {
            lock (Utility.Global.ThreadLockDao)
            {
                List<Entity.Model> models = new List<Entity.Model>();
                lock (Global.ThreadLockDao)
                {
                    try
                    {
                        string SQL = " select m.id," +
                                        " pt.name as productType,m.name as modelName " +
                                        " from models as m " +
                                        " left join product_types as pt on m.product_type_id=pt.id where "+
                                        " m.name like '%" + modelName + "%'";

                        SQL+=productTypeId=="0"?"":" and m.product_type_id='" + productTypeId + "'";

                        Conn.MyConn.Open();
                        using (Conn.MyCommand = new MySqlCommand(SQL, Conn.MyConn))
                        {
                            using (Conn.MyReader = Conn.MyCommand.ExecuteReader())
                            {
                                if (Conn.MyReader.HasRows)
                                {
                                    while (Conn.MyReader.Read())
                                    {
                                        models.Add(new Entity.Model()
                                        {
                                            Id = Conn.MyReader["id"].ToString(),
                                            ProductType = Conn.MyReader["productType"].ToString(),
                                            Name = Conn.MyReader["modelName"].ToString()
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


                    return models;
                }
            }

        }
        public Entity.Model GetModel(string modelId)
        {
            lock (Utility.Global.ThreadLockDao)
            {
              
               
                    Entity.Model model = new Entity.Model();
                    try
                    {
                        
                        string SQL = " select m.id," +
                                        " pt.name as productType,m.name as modelName " +
                                        " from models as m " +
                                        " left join product_types as pt on m.product_type_id=pt.id where m.id='" + modelId + "'";

                        Conn.MyConn.Open();
                        using (Conn.MyCommand = new MySqlCommand(SQL, Conn.MyConn))
                        {
                            using (Conn.MyReader = Conn.MyCommand.ExecuteReader())
                            {
                                if (Conn.MyReader.HasRows)
                                {
                                    while (Conn.MyReader.Read())
                                    {
                                        model=new Entity.Model()
                                        {
                                            Id = Conn.MyReader["id"].ToString(),
                                            ProductType = Conn.MyReader["productType"].ToString(),
                                            Name = Conn.MyReader["modelName"].ToString()
                                        };

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


                    return model;
                
            }

        }
        public string GetProductTypeId(string modelId)
        {
            lock (Utility.Global.ThreadLockDao)
            {


                var result = "";
                try
                {

                    string SQL = " select models.product_type_id" +

                                    " from models where models.id='" + modelId + "'";
                                  

                    Conn.MyConn.Open();
                    using (Conn.MyCommand = new MySqlCommand(SQL, Conn.MyConn))
                    {
                        using (Conn.MyReader = Conn.MyCommand.ExecuteReader())
                        {
                            if (Conn.MyReader.HasRows)
                            {
                                while (Conn.MyReader.Read())
                                {
                                    result = Conn.MyReader[0].ToString();
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


                return result;

            }

        }
    }
}
