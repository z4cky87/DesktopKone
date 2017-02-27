using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contact_Center_Kone.Entity;
using Contact_Center_Kone.Utility;
using MySql.Data.MySqlClient;

namespace Contact_Center_Kone.Dao
{
    public class ShiftDao
    {
        DbMyConnection DbMyConn = new DbMyConnection();

        public Shift GetInboundCallerType_ByID(string id)
        {
            lock (Global.ThreadLockDao)
            {
                Shift shift = new Shift();

                try
                {
                    string SQL = "SELECT *  FROM cc_shifts WHERE id='" + id + "'";
                    DbMyConn.MyConn.Open();
                    using (DbMyConn.MyCommand = new MySqlCommand(SQL, DbMyConn.MyConn))
                    {
                        using (DbMyConn.MyReader = DbMyConn.MyCommand.ExecuteReader())
                        {
                            if (DbMyConn.MyReader.HasRows)
                            {
                                if (DbMyConn.MyReader.Read())
                                {
                                    //direction = new Direction();
                                    shift.id = Convert.ToInt32(DbMyConn.MyReader["id"]);
                                    shift.shift = DbMyConn.MyReader["shift"].ToString();
                                }
                            }
                        }
                    }
                }
                catch (Exception Ex)
                {
                    Global.WriteLog(Global.GetCurrentMethod(Ex));
                }
                finally { DbMyConn.MyConn.Close(); }

                return shift;
            }
        }
    }
}
