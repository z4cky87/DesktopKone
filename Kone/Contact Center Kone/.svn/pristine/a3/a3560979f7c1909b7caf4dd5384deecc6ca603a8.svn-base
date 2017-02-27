using Contact_Center_Kone.Utility;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contact_Center_Kone.Dao
{
    public class UserLevelDao
    {
        private Utility.DbMyConnection Conn = new Utility.DbMyConnection();

        public List<Entity.UserLevel> GetAllLevelName()
        {
            lock (Utility.Global.ThreadLockDao)
            {
                List<Entity.UserLevel> userLevlName = new List<Entity.UserLevel>();
                lock (Global.ThreadLockDao)
                {
                    try
                    {
                        string SQL = "SELECT * FROM cc_user_levels";

                        Conn.MyConn.Open();
                        using (Conn.MyCommand = new MySqlCommand(SQL, Conn.MyConn))
                        {
                            using (Conn.MyReader = Conn.MyCommand.ExecuteReader())
                            {
                                if (Conn.MyReader.HasRows)
                                {
                                    while (Conn.MyReader.Read())
                                    {
                                        userLevlName.Add(new Entity.UserLevel()
                                        {
                                             id=Conn.MyReader["level_id"].ToString(),
                                             level = Conn.MyReader["level"].ToString()
                                        });

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
                    {
                        Conn.MyConn.Close();
                    }


                    return userLevlName;
                }
            }

        }
    }
}
