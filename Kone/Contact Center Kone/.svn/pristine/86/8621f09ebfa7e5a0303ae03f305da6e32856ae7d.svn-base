using Contact_Center_Kone.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contact_Center_Kone.Dao
{
    public class PromoteDao
    {

        private Utility.DbMyConnection myConn = new Utility.DbMyConnection();

        public List<Entity.Promote> GetAll()
        {
            lock (Global.ThreadLockDao)
            {
                var promotes = new List<Entity.Promote>();
                try
                {
                    var query = "select np.promotion,np.info,np.start_date,np.end_date,np.discount_price,np.discount_percent,cp.name from nuwira_promotions as np left join cc_products as cp on np.product_id=cp.id";
                    myConn.MyConn.Open();
                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(query, myConn.MyConn))
                    using (myConn.MyReader = myConn.MyCommand.ExecuteReader())
                    {
                        if (myConn.MyReader.HasRows)
                        {
                            while (myConn.MyReader.Read())
                            {
                                promotes.Add(new Entity.Promote()
                                {
                                  promotion=myConn.MyReader[0].ToString(),
                                  info = myConn.MyReader[1].ToString(),
                                  startDate = string.IsNullOrEmpty(myConn.MyReader[2].ToString()) ? null : Convert.ToDateTime(myConn.MyReader[2].ToString()).ToString("dd MMMM yyyy"),
                                  endDate = string.IsNullOrEmpty(myConn.MyReader[3].ToString()) ? null : Convert.ToDateTime(myConn.MyReader[3].ToString()).ToString("dd MMMM yyyy"),
                                  discountPrice = myConn.MyReader[4].ToString(),
                                  discountPercent = myConn.MyReader[5].ToString(),
                                  productName = myConn.MyReader[6].ToString(),
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
                return promotes;
            }
        }
    }
}
