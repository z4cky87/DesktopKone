using Contact_Center_Kone.Utility;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contact_Center_Kone.Dao
{
    public class CallerTypeDao
    {
        DbMyConnection myConn = new DbMyConnection();

        public Entity.CallerType GetCallerType_ByID(string id)
        {
            lock (Global.ThreadLockDao)
            {
                Entity.CallerType callerType = new Entity.CallerType();

                try
                {
                    string SQL = "SELECT * FROM cc_caller_types where id='" + id + "'";
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
                                    callerType.id = myConn.MyReader["id"].ToString();
                                    callerType.direction = myConn.MyReader["direction_id"].ToString();
                                    callerType.type = myConn.MyReader["type"].ToString();
                                    callerType.isActive = myConn.MyReader["is_active"].ToString();
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

                return callerType;
            }
        }


        /// <summary>
        /// Want to get all caller type? Fill parameter directionId with null or ""
        /// </summary>
        /// <param name="directionId"></param>
        /// <returns></returns>
        public List<Entity.CallerType> GetListCallerType(string directionId)
        {
            lock (Global.ThreadLockDao)
            {
                List<Entity.CallerType> List_callerType = new List<Entity.CallerType>();

                List_callerType.Add(new Entity.CallerType() { id = "0", type = " --- " });

                try
                {
                    string direction = string.IsNullOrEmpty(directionId) ? "" : " where cc_caller_types.direction_id="+directionId+ " and is_active=2 ";
                    string SQL = "SELECT * FROM cc_caller_types "+direction;
                    myConn.MyConn.Open();
                    using (myConn.MyCommand = new MySqlCommand(SQL, myConn.MyConn))
                    {
                        using (myConn.MyReader = myConn.MyCommand.ExecuteReader())
                        {
                            if (myConn.MyReader.HasRows)
                            {
                                Entity.CallerType callerType = new Entity.CallerType();

                                while (myConn.MyReader.Read())
                                {
                                    callerType = new Entity.CallerType();
                                    callerType.id = myConn.MyReader["id"].ToString();
                                    callerType.type = myConn.MyReader["type"].ToString();
                                    callerType.isActive = myConn.MyReader["is_active"].ToString() == "1" ? "No" : "Yes";
                                    List_callerType.Add(callerType);
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

                return List_callerType;
            }
        }
        public List<Entity.CallerType> GetListCallerTypeWithIdBlank(string directionId)
        {
            lock (Global.ThreadLockDao)
            {
                List<Entity.CallerType> List_callerType = new List<Entity.CallerType>();

                 List_callerType.Add(new Entity.CallerType() { id = "0", type = "" });

                try
                {
                    string direction = string.IsNullOrEmpty(directionId) ? "" : " where cc_caller_types.direction_id=" + directionId;
                    string SQL = "SELECT * FROM cc_caller_types " + direction;
                    myConn.MyConn.Open();
                    using (myConn.MyCommand = new MySqlCommand(SQL, myConn.MyConn))
                    {
                        using (myConn.MyReader = myConn.MyCommand.ExecuteReader())
                        {
                            if (myConn.MyReader.HasRows)
                            {
                                Entity.CallerType callerType = new Entity.CallerType();

                                while (myConn.MyReader.Read())
                                {
                                    callerType = new Entity.CallerType();
                                    callerType.id = myConn.MyReader["id"].ToString();
                                    callerType.type = myConn.MyReader["type"].ToString();
                                    callerType.isActive = myConn.MyReader["is_active"].ToString() == "1" ? "No" : "Yes";
                                    List_callerType.Add(callerType);
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

                return List_callerType;
            }
        }
        public List<Entity.CallerType> GetAllCallerType(string directionId)
        {
            lock (Global.ThreadLockDao)
            {
                List<Entity.CallerType> List_callerType = new List<Entity.CallerType>();

               // List_callerType.Add(new Entity.CallerType() { id = "0", type = " --- " });

                try
                {
                    string direction = string.IsNullOrEmpty(directionId) ? "" : " where cc_caller_types.direction_id=" + directionId ;
                    string SQL = "SELECT * FROM cc_caller_types " + direction;
                    myConn.MyConn.Open();
                    using (myConn.MyCommand = new MySqlCommand(SQL, myConn.MyConn))
                    {
                        using (myConn.MyReader = myConn.MyCommand.ExecuteReader())
                        {
                            if (myConn.MyReader.HasRows)
                            {
                                Entity.CallerType callerType = new Entity.CallerType();

                                while (myConn.MyReader.Read())
                                {
                                    callerType = new Entity.CallerType();
                                    callerType.id = myConn.MyReader["id"].ToString();
                                    callerType.type = myConn.MyReader["type"].ToString();
                                    callerType.isActive = myConn.MyReader["is_active"].ToString() == "1" ? "No" : "Yes";
                                    List_callerType.Add(callerType);
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

                return List_callerType;
            }
        }
        public bool Insert(Entity.CallerType callerType)
        {
            lock (Utility.Global.ThreadLockDao)
            {

                var result = false;
                try
                {
                    var queryString = "insert into cc_caller_types set " +
                                        "direction_id=@direction," +
                                        "type=@type," +
                                        "is_active=@isactive";


                    myConn.MyConn.Open();

                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(queryString, myConn.MyConn))
                    {
                        myConn.MyCommand.Parameters.AddWithValue("@type", callerType.type);
                        myConn.MyCommand.Parameters.AddWithValue("@direction", callerType.direction);
                        myConn.MyCommand.Parameters.AddWithValue("@isactive", callerType.isActive);

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
        public bool Update(Entity.CallerType callerType)
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

                        myConn.MyCommand.Parameters.AddWithValue("@type", callerType.type);
                        myConn.MyCommand.Parameters.AddWithValue("@isactive", callerType.isActive);

                        myConn.MyCommand.Parameters.AddWithValue("@id", callerType.id);
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
        public bool Delete(Entity.CallerType callerType)
        {
            lock (Utility.Global.ThreadLockDao)
            {
                var result = false;
                try
                {
                    var queryString = "delete from cc_caller_types where id=@id";

                    myConn.MyConn.Open();

                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(queryString, myConn.MyConn))
                    {
                        myConn.MyCommand.Parameters.AddWithValue("@id", callerType.id);
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
