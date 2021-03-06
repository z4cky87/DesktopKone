﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using Contact_Center_Kone.Entity;
using Contact_Center_Kone.Utility;

namespace Contact_Center_Kone.Dao
{
    public class InboundTypeDao
    {
        private Utility.DbMyConnection myConn = new Utility.DbMyConnection();

        //public InboundType GetInboundType_ByID(int id)
        //{
        //    lock (Global.ThreadLockDao)
        //    {
        //        InboundType inboundtype = new InboundType();

        //        try
        //        {
        //            string SQL = "SELECT *  FROM cc_inbound_types WHERE id=" + id;
        //            DbMyConn.MyConn.Open();
        //            using (DbMyConn.MyCommand = new MySqlCommand(SQL, DbMyConn.MyConn))
        //            {
        //                using (DbMyConn.MyReader = DbMyConn.MyCommand.ExecuteReader())
        //                {
        //                    if (DbMyConn.MyReader.HasRows)
        //                    {
        //                        if (DbMyConn.MyReader.Read())
        //                        {
        //                            //direction = new Direction();
        //                            inboundtype.id = Convert.ToInt32(DbMyConn.MyReader["id"]);
        //                            inboundtype.type = DbMyConn.MyReader["type"].ToString();
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        catch (Exception Ex)
        //        {
        //            Global.WriteLog(Global.GetCurrentMethod(Ex));
        //        }
        //        finally { DbMyConn.MyConn.Close(); }

        //        return inboundtype;
        //    }
        //}

        public List<Entity.InboundType> GetAll()
        {
            lock (Utility.Global.ThreadLockDao)
            {
                var inboundTypes = new List<Entity.InboundType>();
                try
                {
                    var query = "Select * from cc_inbound_types";
                    myConn.MyConn.Open();
                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(query, myConn.MyConn))
                    using (myConn.MyReader = myConn.MyCommand.ExecuteReader())
                    {
                        if (myConn.MyReader.HasRows)
                        {
                            while (myConn.MyReader.Read())
                            {
                                inboundTypes.Add(new Entity.InboundType()
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
                return inboundTypes;
            }
        }
        public List<Entity.InboundType> GetAllWithBlankId()
        {
            lock (Utility.Global.ThreadLockDao)
            {
                var inboundTypes = new List<Entity.InboundType>();
                inboundTypes.Add(new Entity.InboundType() { id = 0, type = "" });
                try
                {
                    var query = "Select * from cc_inbound_types where is_active=1";
                    myConn.MyConn.Open();
                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(query, myConn.MyConn))
                    using (myConn.MyReader = myConn.MyCommand.ExecuteReader())
                    {
                        if (myConn.MyReader.HasRows)
                        {
                            while (myConn.MyReader.Read())
                            {
                                inboundTypes.Add(new Entity.InboundType()
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
                return inboundTypes;
            }
        }
        public Entity.InboundType GetById(string id)
        {
            lock (Utility.Global.ThreadLockDao)
            {
                var inboundType = new Entity.InboundType();
                try
                {
                    var query = "Select * from cc_inbound_types where id='" + id + "'";
                    myConn.MyConn.Open();
                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(query, myConn.MyConn))
                    using (myConn.MyReader = myConn.MyCommand.ExecuteReader())
                    {
                        if (myConn.MyReader.HasRows)
                        {
                            while (myConn.MyReader.Read())
                            {

                                inboundType.id = Convert.ToInt32(myConn.MyReader["id"]);
                                inboundType.type = myConn.MyReader["type"].ToString();
                                inboundType.isActive = myConn.MyReader["is_active"].ToString() == "1" ? "Yes" : "No";

                            };
                        };
                    }

                }
                catch (Exception ex)
                {
                    Utility.Global.WriteLog(Utility.Global.GetCurrentMethod(ex));
                }
                finally { myConn.MyConn.Close(); }
                return inboundType;
            }
        }
        public bool Insert(Entity.InboundType inboundType)
        {
            lock (Utility.Global.ThreadLockDao)
            {

                var result = false;
                try
                {
                    var queryString = "insert into cc_inbound_types set " +
                                        "type=@type," +
                                        "is_Active=@isactive";


                    myConn.MyConn.Open();

                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(queryString, myConn.MyConn))
                    {
                        myConn.MyCommand.Parameters.AddWithValue("@type", inboundType.type);
                        myConn.MyCommand.Parameters.AddWithValue("@isactive", inboundType.isActive);
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
        public bool Update(Entity.InboundType inboundType)
        {
            lock (Utility.Global.ThreadLockDao)
            {
                var result = false;
                try
                {
                    var queryString = "update cc_inbound_types set " +
                                         "type=@type," +
                                         "is_Active=@isactive" +
                                        " where id=@id";

                    myConn.MyConn.Open();

                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(queryString, myConn.MyConn))
                    {
                        myConn.MyCommand.Parameters.AddWithValue("@type", inboundType.type);
                        myConn.MyCommand.Parameters.AddWithValue("@isactive", inboundType.isActive);
                        myConn.MyCommand.Parameters.AddWithValue("@id", inboundType.id);
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
        public bool Delete(Entity.InboundType inboundType)
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
                        myConn.MyCommand.Parameters.AddWithValue("@id", inboundType.id);
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

        //public List<Entity.InboundType>GetInquiryType(List<Entity.InboundType> listInboundType)
        //{           
        //    return listInboundType.Where(x => x.parentId == "2").ToList();  
        //}
        //public List<Entity.InboundType> GetComplainType(List<Entity.InboundType> listInboundType)
        //{
        //    return listInboundType.Where(x => x.parentId == "1").ToList();
        //}
        //public List<Entity.InboundType> GetOrderType(List<Entity.InboundType> listInboundType)
        //{
        //    return listInboundType.Where(x => x.parentId == "3").ToList();
        //}
        //public List<Entity.InboundType> GetOthersType(List<Entity.InboundType> listInboundType)
        //{
        //    return listInboundType.Where(x => x.parentId == "5").ToList();
        //}
    }
}
