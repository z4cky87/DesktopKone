using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contact_Center_Kone.Dao
{
   public class OutboundTypeDao
    {
        private Utility.DbMyConnection myConn = new Utility.DbMyConnection();

        public List<Entity.OutboundType> GetAll()
        {
            lock (Utility.Global.ThreadLockDao)
            {
                var outboundTypes = new List<Entity.OutboundType>();
                try
                {
                    var query = "Select * from cc_outbound_types";
                    myConn.MyConn.Open();
                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(query, myConn.MyConn))
                    using (myConn.MyReader = myConn.MyCommand.ExecuteReader())
                    {
                        if (myConn.MyReader.HasRows)
                        {
                            while (myConn.MyReader.Read())
                            {
                                outboundTypes.Add(new Entity.OutboundType()
                                {
                                    id = Convert.ToInt32(myConn.MyReader["id"]),
                                    type = myConn.MyReader["type"].ToString(),
                                    isActive = myConn.MyReader["is_active"].ToString() == "1" ? "Yes" : "No"
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
                return outboundTypes;
            }
        }
        public Entity.OutboundType GetById(string id)
        {
            lock (Utility.Global.ThreadLockDao)
            {
                var outboundType = new Entity.OutboundType();
                try
                {
                    var query = "Select * from cc_outbound_types where id='" + id + "'";
                    myConn.MyConn.Open();
                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(query, myConn.MyConn))
                    using (myConn.MyReader = myConn.MyCommand.ExecuteReader())
                    {
                        if (myConn.MyReader.HasRows)
                        {
                            while (myConn.MyReader.Read())
                            {

                                outboundType.id = Convert.ToInt32(myConn.MyReader["id"]);
                                outboundType.type = myConn.MyReader["type"].ToString();
                                outboundType.isActive = myConn.MyReader["is_active"].ToString() == "1" ? "Yes" : "No";

                            };
                        };
                    }

                }
                catch (Exception ex)
                {
                    Utility.Global.WriteLog(Utility.Global.GetCurrentMethod(ex));
                }
                finally { myConn.MyConn.Close(); }
                return outboundType;
            }
        }
        public bool Insert(Entity.OutboundType outboundType)
        {
            lock (Utility.Global.ThreadLockDao)
            {
                var result = false;
                try
                {
                    var queryString = "insert into cc_outbound_types set " +
                                        "type=@type," +
                                        "is_Active=@isactive";


                    myConn.MyConn.Open();

                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(queryString, myConn.MyConn))
                    {
                        myConn.MyCommand.Parameters.AddWithValue("@type", outboundType.type);
                        myConn.MyCommand.Parameters.AddWithValue("@isactive", outboundType.isActive);
                        result = (myConn.MyCommand.ExecuteNonQuery() == 1);
                    };

                }
                catch (Exception ex) { Utility.Global.WriteLog(Utility.Global.GetCurrentMethod(ex)); }
                finally
                {
                    myConn.MyConn.Close();
                }
                return result;
            }
        }
        public bool Update(Entity.OutboundType outboundType)
        {
            lock (Utility.Global.ThreadLockDao)
            {
                var result = false;
                try
                {
                    var queryString = "update cc_outbound_types set " +
                                         "type=@type," +
                                         "is_Active=@isactive" +
                                        " where id=@id";

                    myConn.MyConn.Open();

                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(queryString, myConn.MyConn))
                    {
                        myConn.MyCommand.Parameters.AddWithValue("@type", outboundType.type);
                        myConn.MyCommand.Parameters.AddWithValue("@isactive", outboundType.isActive);
                        myConn.MyCommand.Parameters.AddWithValue("@id", outboundType.id);
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
        public bool Delete(Entity.OutboundType outboundType)
        {
            lock (Utility.Global.ThreadLockDao)
            {
                var result = false;
                try
                {
                    var queryString = "delete from cc_inbound_types where id=@id";

                    myConn.MyConn.Open();

                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(queryString, myConn.MyConn))
                    {
                        myConn.MyCommand.Parameters.AddWithValue("@id", outboundType.id);
                    }
                    result = (myConn.MyCommand.ExecuteNonQuery() == 1);
                }
                catch (Exception ex)
                {
                    Utility.Global.WriteLog(Utility.Global.GetCurrentMethod(ex));
                }
                finally
                {
                    myConn.MyConn.Close();
                }
                return result;
            }
        }
    }
}
