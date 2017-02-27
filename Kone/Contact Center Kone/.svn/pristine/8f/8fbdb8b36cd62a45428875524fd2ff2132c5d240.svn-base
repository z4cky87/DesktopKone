using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using Contact_Center_Kone.Entity;
using Contact_Center_Kone.Utility;

namespace Contact_Center_Kone.Dao
{
    public class InboundTypeDetailDao
    {
        private Utility.DbMyConnection myConn = new Utility.DbMyConnection();

      
        public List<Entity.InboundType> GetAll(string inboundTypeId)
        {
            lock (Utility.Global.ThreadLockDao)
            {
                var inboundTypes = new List<Entity.InboundType>();
                try
                {
                    var query = "Select * from cc_inbound_type_details where inbound_type_id='" + inboundTypeId + "'";
                    // System.Windows.Forms.MessageBox.Show(query);
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
                return inboundTypes;
            }
        }

        public Entity.InboundTypeDetail GetById(string id)
        {
            lock (Utility.Global.ThreadLockDao)
            {
                var inboundType = new Entity.InboundTypeDetail();
                try
                {
                    var query = "Select * from cc_inbound_type_details where id='" + id + "'";
                    myConn.MyConn.Open();
                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(query, myConn.MyConn))
                    using (myConn.MyReader = myConn.MyCommand.ExecuteReader())
                    {
                        if (myConn.MyReader.HasRows)
                        {
                            while (myConn.MyReader.Read())
                            {

                                inboundType.id = Convert.ToInt32(myConn.MyReader["id"]);
                                inboundType.type_detail = myConn.MyReader["type_detail"].ToString();
                                inboundType.inboundType = new InboundType() { id = Convert.ToInt32(myConn.MyReader["inbound_type_id"].ToString()) };
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

        public bool Insert(Entity.InboundTypeDetail inboundTypeDetail)
        {
            lock (Utility.Global.ThreadLockDao)
            {

                var result = false;
                try
                {
                    var queryString = "insert into cc_inbound_type_details set " +
                                        "type_detail=@typedetail," +
                                        "inbound_type_id=@typeid," +
                                        "is_Active=@isactive";


                    myConn.MyConn.Open();

                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(queryString, myConn.MyConn))
                    {
                        myConn.MyCommand.Parameters.AddWithValue("@typedetail", inboundTypeDetail.type_detail);
                        myConn.MyCommand.Parameters.AddWithValue("@typeid", inboundTypeDetail.inboundType.id);
                        myConn.MyCommand.Parameters.AddWithValue("@isactive", inboundTypeDetail.isActive);
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
        public bool Update(Entity.InboundTypeDetail inboundTypeDetail)
        {
            lock (Utility.Global.ThreadLockDao)
            {
                var result = false;
                try
                {
                    var queryString = "update cc_inbound_type_details set " +
                                        "type_detail=@typedetail," +
                                        "inbound_type_id=@typeid," +
                                        "is_Active=@isactive" +
                                        " where id=@id";

                    myConn.MyConn.Open();

                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(queryString, myConn.MyConn))
                    {
                        myConn.MyCommand.Parameters.AddWithValue("@typedetail", inboundTypeDetail.type_detail);
                        myConn.MyCommand.Parameters.AddWithValue("@typeid", inboundTypeDetail.inboundType.id);
                        myConn.MyCommand.Parameters.AddWithValue("@isactive", inboundTypeDetail.isActive);
                        myConn.MyCommand.Parameters.AddWithValue("@id", inboundTypeDetail.id);
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
        public bool Delete(Entity.InboundTypeDetail inboundTypeDetail)
        {
            lock (Utility.Global.ThreadLockDao)
            {
                var result = false;
                try
                {
                    var queryString = "delete from cc_inbound_type_details where id=@id";
                    myConn.MyConn.Open();

                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(queryString, myConn.MyConn))
                    {
                        myConn.MyCommand.Parameters.AddWithValue("@id", inboundTypeDetail.id);
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
