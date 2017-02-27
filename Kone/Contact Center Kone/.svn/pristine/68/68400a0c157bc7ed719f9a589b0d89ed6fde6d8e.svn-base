using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contact_Center_Kone.Dao
{
    public class OutboundCallerTypeDetailDao
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
    }
}
