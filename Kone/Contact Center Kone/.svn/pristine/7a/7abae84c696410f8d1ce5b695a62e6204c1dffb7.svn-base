using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contact_Center_Kone.Entity;
using Contact_Center_Kone.Utility;
using MySql.Data.MySqlClient;

namespace Contact_Center_Kone.Dao
{
    public class InboundCallerTypeDao
    {
        DbMyConnection myConn = new DbMyConnection();

        public InboundCallerType GetInboundCallerType_ByID(string id)
        {
            lock (Global.ThreadLockDao)
            {
                InboundCallerType inbouncallertype = new InboundCallerType();

                try
                {
                    string SQL = "SELECT *  FROM cc_inbound_caller_types where cc_caller_types.direction_id=1 WHERE id='" + id + "'";
                    myConn.MyConn.Open();
                    using (myConn.MyCommand = new MySqlCommand(SQL, myConn.MyConn))
                    {
                        using (myConn.MyReader = myConn.MyCommand.ExecuteReader())
                        {
                            if (myConn.MyReader.HasRows)
                            {
                                if (myConn.MyReader.Read())
                                {
                                    //direction = new Direction();
                                    inbouncallertype.id = myConn.MyReader["id"].ToString();
                                    inbouncallertype.type = myConn.MyReader["type"].ToString();
                                    inbouncallertype.isActive = myConn.MyReader["is_active"].ToString();
                                }
                            }
                        }
                    }
                }
                catch (Exception Ex)
                {
                    Global.WriteLog(Global.GetCurrentMethod(Ex));
                }
                finally { myConn.MyConn.Close(); }

                return inbouncallertype;
            }
        }

        public List<InboundCallerType> GetListCallerType()
        {
            lock (Global.ThreadLockDao)
            {
                List<InboundCallerType> List_inbounccallertype = new List<InboundCallerType>();

                List_inbounccallertype.Add(new InboundCallerType() { id = "0", type = " --- " });

                try
                {
                    string SQL = "SELECT * FROM cc_caller_types where cc_caller_types.direction_id=1";
                    myConn.MyConn.Open();
                    using (myConn.MyCommand = new MySqlCommand(SQL, myConn.MyConn))
                    {
                        using (myConn.MyReader = myConn.MyCommand.ExecuteReader())
                        {
                            if (myConn.MyReader.HasRows)
                            {
                                InboundCallerType inboundCallerType = new InboundCallerType();
                               
                                while (myConn.MyReader.Read())
                                {
                                    inboundCallerType = new InboundCallerType();
                                    inboundCallerType.id = myConn.MyReader["id"].ToString();
                                    inboundCallerType.type = myConn.MyReader["type"].ToString();
                                    inboundCallerType.isActive = myConn.MyReader["is_active"].ToString()=="1"?"No":"Yes";
                                    List_inbounccallertype.Add(inboundCallerType);
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

                return List_inbounccallertype;
            }
        }
        public bool Insert(Entity.InboundCallerType inboundCallerType)
        {
            lock (Utility.Global.ThreadLockDao)
            {

                var result = false;
                try
                {
                    var queryString = "insert into cc_caller_types set " +
                                        "direction_id=1," +
                                        "type=@type," +                                      
                                        "is_active=@isactive";


                    myConn.MyConn.Open();

                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(queryString, myConn.MyConn))
                    {
                        myConn.MyCommand.Parameters.AddWithValue("@type", inboundCallerType.type);
                        myConn.MyCommand.Parameters.AddWithValue("@isactive", inboundCallerType.isActive);
                      
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
        public bool Update(Entity.InboundCallerType inboundCallerType)
        {
            lock (Utility.Global.ThreadLockDao)
            {
                var result = false;
                try
                {
                    var queryString = "update cc_caller_types set " +
                                       
                                        "type=@type," +                                        
                                        "is_active=@isactive" +
                                        " where id=@id";

                    myConn.MyConn.Open();

                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(queryString, myConn.MyConn))
                    {
                      
                        myConn.MyCommand.Parameters.AddWithValue("@type", inboundCallerType.type);
                        myConn.MyCommand.Parameters.AddWithValue("@isactive", inboundCallerType.isActive);
                      
                        myConn.MyCommand.Parameters.AddWithValue("@id", inboundCallerType.id);
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
        public bool Delete(Entity.InboundCallerType inboundCallerType)
        {
            lock (Utility.Global.ThreadLockDao)
            {
                var result = false;
                try
                {
                    var queryString = "delete from cc_inbound_caller_types where id=@id";

                    myConn.MyConn.Open();

                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(queryString, myConn.MyConn))
                    {
                        myConn.MyCommand.Parameters.AddWithValue("@id", inboundCallerType.id);
                        result = (myConn.MyCommand.ExecuteNonQuery() == 1);
                    }

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
