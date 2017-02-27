using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contact_Center_Kone.Entity;
using Contact_Center_Kone.Utility;
using MySql.Data.MySqlClient;

namespace Contact_Center_Kone.Dao
{
    public class BreakReasonDao
    {
        DbMyConnection DbMyConn = new DbMyConnection();
        public List<BreakReason> GetListbreakReason()
        {
            lock (Global.ThreadLockDao)
            {
                List<BreakReason> Listbreakreason = new List<BreakReason>();

                try
                {
                    string SQL = "SELECT * FROM cc_breakreason WHERE is_active=1";
                    DbMyConn.MyConn.Open();
                    using (DbMyConn.MyCommand = new MySqlCommand(SQL, DbMyConn.MyConn))
                    {
                        using (DbMyConn.MyReader = DbMyConn.MyCommand.ExecuteReader())
                        {
                            if (DbMyConn.MyReader.HasRows)
                            {
                                BreakReason breakreason = new BreakReason();
                                breakreason.id = -1;
                                breakreason.reason = null;
                                Listbreakreason.Add(breakreason);
                                while (DbMyConn.MyReader.Read())
                                {
                                    breakreason = new BreakReason();
                                    breakreason.id = Convert.ToInt32(DbMyConn.MyReader["id"]);
                                    breakreason.reason = DbMyConn.MyReader["reason"].ToString();
                                    Listbreakreason.Add(breakreason);
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
                { DbMyConn.MyConn.Close(); }

                return Listbreakreason;
            }
        }
    }
}
