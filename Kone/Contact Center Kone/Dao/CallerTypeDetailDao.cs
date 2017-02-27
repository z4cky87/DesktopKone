using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contact_Center_Kone.Dao
{
   public class CallerTypeDetailDao
    {
        private Utility.DbMyConnection myConn = new Utility.DbMyConnection();

   

        public List<Entity.CallerTypeDetail> GetAllByCallerType(string callerTypeId)
        {
            lock (Utility.Global.ThreadLockDao)
            {
                var inboundCategory = new List<Entity.CallerTypeDetail>();

                inboundCategory.Add(new Entity.CallerTypeDetail() { id = "0", name = " --- " });
                try
                {
                    var query = "Select * from cc_caller_type_detail where caller_type_id='" + callerTypeId + "' and is_active=2";
                    myConn.MyConn.Open();
                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(query, myConn.MyConn))
                    using (myConn.MyReader = myConn.MyCommand.ExecuteReader())
                    {
                        if (myConn.MyReader.HasRows)
                        {
                            while (myConn.MyReader.Read())
                            {
                                inboundCategory.Add(new Entity.CallerTypeDetail()
                                {
                                    id =myConn.MyReader["id"].ToString(),
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
                return inboundCategory;
            }
        }
        public List<Entity.CallerTypeDetail> GetAllByCallerTypeWithBlankId(string callerTypeId)
        {
            lock (Utility.Global.ThreadLockDao)
            {
                var inboundCategory = new List<Entity.CallerTypeDetail>();

                inboundCategory.Add(new Entity.CallerTypeDetail() { id = "0", name = "" });
                try
                {
                    var query = "Select * from cc_caller_type_detail where caller_type_id='" + callerTypeId + "' and is_active=2";
                    myConn.MyConn.Open();
                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(query, myConn.MyConn))
                    using (myConn.MyReader = myConn.MyCommand.ExecuteReader())
                    {
                        if (myConn.MyReader.HasRows)
                        {
                            while (myConn.MyReader.Read())
                            {
                                inboundCategory.Add(new Entity.CallerTypeDetail()
                                {
                                    id = myConn.MyReader["id"].ToString(),
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
                return inboundCategory;
            }
        }
        public List<Entity.CallerTypeDetail> GetAll(string callerTypeId)
        {
            lock (Utility.Global.ThreadLockDao)
            {
                var inboundCategory = new List<Entity.CallerTypeDetail>();
                try
                {
                    var query = "Select * from cc_caller_type_detail where caller_type_id='" + callerTypeId + "'";
                    myConn.MyConn.Open();
                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(query, myConn.MyConn))
                    using (myConn.MyReader = myConn.MyCommand.ExecuteReader())
                    {
                        if (myConn.MyReader.HasRows)
                        {
                            while (myConn.MyReader.Read())
                            {
                                inboundCategory.Add(new Entity.CallerTypeDetail()
                                {
                                    id = myConn.MyReader["id"].ToString(),
                                    name = myConn.MyReader["name"].ToString(),
                                    isActive = myConn.MyReader["is_active"].ToString()=="1"?"No":"Yes",
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
                return inboundCategory;
            }
        }
        public Entity.CallerTypeDetail GetById(string id)
        {
            lock (Utility.Global.ThreadLockDao)
            {
                var callerTypeDetail = new Entity.CallerTypeDetail();
                try
                {
                    var query = "Select * from cc_caller_type_detail where id='" + id + "'";
                    myConn.MyConn.Open();
                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(query, myConn.MyConn))
                    using (myConn.MyReader = myConn.MyCommand.ExecuteReader())
                    {
                        if (myConn.MyReader.HasRows)
                        {
                            while (myConn.MyReader.Read())
                            {
                                
                                   callerTypeDetail. id = myConn.MyReader["id"].ToString();
                                   callerTypeDetail.callerType = new Entity.CallerType() { id = myConn.MyReader["caller_type_id"].ToString() };
                                    callerTypeDetail.name = myConn.MyReader["name"].ToString();
                                    callerTypeDetail.isActive = myConn.MyReader["is_active"].ToString();
                                
                            };
                        };
                    }

                }
                catch (Exception ex)
                {
                    Utility.Global.WriteLog(Utility.Global.GetCurrentMethod(ex));
                }
                finally { myConn.MyConn.Close(); }
                return callerTypeDetail;
            }
        }

        public bool Insert(Entity.CallerTypeDetail inboundCategory)
        {
            lock (Utility.Global.ThreadLockDao)
            {

                var result = false;
                try
                {
                    var queryString = " insert into cc_caller_type_detail set " +
                                      " caller_type_id=@inboundcallertype,"+
                                      " name=@inboundcategory," +
                                      " is_active=@isactive";


                    myConn.MyConn.Open();

                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(queryString, myConn.MyConn))
                    {
                        myConn.MyCommand.Parameters.AddWithValue("@inboundcallertype", inboundCategory.callerType.id);
                        myConn.MyCommand.Parameters.AddWithValue("@inboundcategory", inboundCategory.name);
                        myConn.MyCommand.Parameters.AddWithValue("@isactive", inboundCategory.isActive);

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
        public bool Update(Entity.CallerTypeDetail inboundCategory)
        {
            lock (Utility.Global.ThreadLockDao)
            {
                var result = false;
                try
                {
                    var queryString = "update cc_caller_type_detail set " +
                                      "caller_type_id=@inboundcallertype," +
                                      "name=@inboundcategory," +
                                      "is_active=@isactive"+
                                      " where id=@id";

                    myConn.MyConn.Open();

                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(queryString, myConn.MyConn))
                    {

                        myConn.MyCommand.Parameters.AddWithValue("@inboundcallertype", inboundCategory.callerType.id);
                        myConn.MyCommand.Parameters.AddWithValue("@inboundcategory", inboundCategory.name);
                        myConn.MyCommand.Parameters.AddWithValue("@isactive", inboundCategory.isActive);
                        myConn.MyCommand.Parameters.AddWithValue("@id", inboundCategory.id);
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
        public bool Delete(Entity.CallerTypeDetail inboundCategory)
        {
            lock (Utility.Global.ThreadLockDao)
            {
                var result = false;
                try
                {
                    var queryString = "delete from cc_caller_type_detail where id=@id";

                    myConn.MyConn.Open();

                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(queryString, myConn.MyConn))
                    {
                        myConn.MyCommand.Parameters.AddWithValue("@id", inboundCategory.id);
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
