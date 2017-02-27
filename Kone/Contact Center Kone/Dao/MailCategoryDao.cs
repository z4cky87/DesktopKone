using Contact_Center_Kone.Entity;
using Contact_Center_Kone.Utility;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contact_Center_Kone.Dao
{
    public class MailCategoryDao
    {
        DbMyConnection Conn = new DbMyConnection();

        public List<MailCategory> GetListCategory(string directionId)
        {
            lock (Global.ThreadLockDao)
            {
                List<MailCategory> ListCategory = new List<MailCategory>();

                try
                {
                    string SQL = "SELECT * FROM cc_mail_categories WHERE is_active=1 AND direction_id= " + directionId;
                    Conn.MyConn.Open();
                    using (Conn.MyCommand = new MySqlCommand(SQL, Conn.MyConn))
                    {
                        using (Conn.MyReader = Conn.MyCommand.ExecuteReader())
                        {
                            if (Conn.MyReader.HasRows)
                            {
                                MailCategory category = new MailCategory();
                                category.id = -2;
                                category.category = null;
                                ListCategory.Add(category);
                                while (Conn.MyReader.Read())
                                {
                                    category = new MailCategory();
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
