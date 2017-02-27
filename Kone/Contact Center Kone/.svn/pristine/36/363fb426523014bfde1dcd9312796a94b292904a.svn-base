using Contact_Center_Kone.Entity;
using Contact_Center_Kone.Utility;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contact_Center_Kone.Dao
{
   public class SmsCategoryDao
    {
        DbMyConnection Conn = new DbMyConnection();

        public List<SmsCategory> GetListCategory(string directionId)
        {
            lock (Global.ThreadLockDao)
            {
                List<SmsCategory> ListCategory = new List<SmsCategory>();

                try
                {
                    string SQL = "SELECT * FROM cc_sms_categories WHERE is_active=1 AND direction_id= " + directionId;
                    Conn.MyConn.Open();
                    using (Conn.MyCommand = new MySqlCommand(SQL, Conn.MyConn))
                    {
                        using (Conn.MyReader = Conn.MyCommand.ExecuteReader())
                        {
                            if (Conn.MyReader.HasRows)
                            {
                                SmsCategory category = new SmsCategory();
                                category.id = -2;
                                category.category = null;
                                ListCategory.Add(category);
                                while (Conn.MyReader.Read())
                                {
                                    category = new SmsCategory();
                                    category.id = Convert.ToInt32(Conn.MyReader["id"]);
                                    category.category = Conn.MyReader["name"].ToString();
                                    ListCategory.Add(category);
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
                { Conn.MyConn.Close(); }

                return ListCategory;
            }
        }
        



    }
}


