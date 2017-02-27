using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contact_Center_Kone.Dao
{
    public class OutboundTypeDetailDao
    {
    
        private Utility.DbMyConnection myConn = new Utility.DbMyConnection();
         
        public List<Entity.OutboundType> GetAll(string outboundTypeId)
         {
             lock (Utility.Global.ThreadLockDao)
             {
                 var outboundTypes = new List<Entity.OutboundType>();
                 try
                 {
                     var query = "Select * from cc_outbound_type_details where outbound_type_id='" + outboundTypeId + "'";
                     // System.Windows.Forms.MessageBox.Show(query);
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
                                     type = myConn.MyReader["type_detail"].ToString(),
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

        public Entity.OutboundTypeDetail GetById(string id)
        {
            lock (Utility.Global.ThreadLockDao)
            {
                var outboundType = new Entity.OutboundTypeDetail();
                try
                {
                    var query = "Select * from cc_outbound_type_details where id='" + id + "'";
                    myConn.MyConn.Open();
                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(query, myConn.MyConn))
                    using (myConn.MyReader = myConn.MyCommand.ExecuteReader())
                    {
                        if (myConn.MyReader.HasRows)
                        {
                            while (myConn.MyReader.Read())
                            {

                                outboundType.id = Convert.ToInt32(myConn.MyReader["id"]);
                                outboundType.type_detail = myConn.MyReader["type_detail"].ToString();
                                outboundType.outboundType = new Entity.OutboundType() { id = Convert.ToInt32(myConn.MyReader["outbound_type_id"].ToString()) };
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

        public bool Insert(Entity.OutboundTypeDetail outboundTypeDetail)
        {
            lock (Utility.Global.ThreadLockDao)
            {
                var result = false;
                try
                {
                    var queryString = "insert into cc_outbound_type_details set " +
                                        "type_detail=@typedetail," +
                                        "outbound_type_id=@typeid," +
                                        "is_Active=@isactive";


                    myConn.MyConn.Open();

                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(queryString, myConn.MyConn))
                    {
                        myConn.MyCommand.Parameters.AddWithValue("@typedetail", outboundTypeDetail.type_detail);
                        myConn.MyCommand.Parameters.AddWithValue("@typeid", outboundTypeDetail.outboundType.id);
                        myConn.MyCommand.Parameters.AddWithValue("@isactive", outboundTypeDetail.isActive);
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
        public bool Update(Entity.OutboundTypeDetail outboundTypeDetail)
        {
            lock (Utility.Global.ThreadLockDao)
            {
                var result = false;
                try
                {
                    var queryString = "update cc_outbound_type_details set " +
                                        "type_detail=@typedetail," +
                                        "outbound_type_id=@typeid," +
                                        "is_Active=@isactive" +
                                        " where id=@id";

                    myConn.MyConn.Open();

                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(queryString, myConn.MyConn))
                    {
                        myConn.MyCommand.Parameters.AddWithValue("@typedetail", outboundTypeDetail.type_detail);
                        myConn.MyCommand.Parameters.AddWithValue("@typeid", outboundTypeDetail.outboundType.id);
                        myConn.MyCommand.Parameters.AddWithValue("@isactive", outboundTypeDetail.isActive);
                        myConn.MyCommand.Parameters.AddWithValue("@id", outboundTypeDetail.id);
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
        public bool Delete(Entity.OutboundTypeDetail outboundTypeDetail)
        {
            lock (Utility.Global.ThreadLockDao)
            {
                var result = false;
                try
                {
                    var queryString = "delete from cc_outbound_type_details where id=@id";
                    myConn.MyConn.Open();

                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(queryString, myConn.MyConn))
                    {
                        myConn.MyCommand.Parameters.AddWithValue("@id", outboundTypeDetail.id);
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

        public List<Entity.OutboundCallerType> GetAllCallerType()
        {
            List<Entity.OutboundCallerType> listOutboundCallerType = new List<Entity.OutboundCallerType>();

            lock (Utility.Global.ThreadLockDao)
            {
                try
                {
                    string SQL = string.Empty;

                    SQL += "SELECT * FROM cc_outbound_caller_types";

                    myConn.MyConn.Open();
                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(SQL,myConn.MyConn))
                    {
                        using (myConn.MyReader = myConn.MyCommand.ExecuteReader())
                        {
                            if (myConn.MyReader.HasRows)
                            {
                                while (myConn.MyReader.Read())
                                {
                                    listOutboundCallerType.Add(new Entity.OutboundCallerType()
                                    {
                                        id = myConn.MyReader["id"].ToString(),
                                        type = myConn.MyReader["type"].ToString()
                                    });
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Utility.Global.WriteLog(Utility.Global.GetCurrentMethod(ex));
                }
                finally
                { myConn.MyConn.Close(); }
            }

            return listOutboundCallerType;
        }
    
    }
}
