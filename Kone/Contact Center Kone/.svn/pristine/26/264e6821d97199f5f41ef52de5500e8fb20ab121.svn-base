using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using Contact_Center_Kone.Entity;
using Contact_Center_Kone.Utility;

namespace Contact_Center_Kone.Dao
{
    public class DirectionDao
    {
        DbMyConnection DbMyConn = new DbMyConnection();

        public Direction GetDirectionByID(int id)
        {
            lock (Global.ThreadLockDao)
            {
                Direction direction = new Direction();

                try
                {
                    string SQL = "SELECT *  FROM cc_directions WHERE id=" + id;
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
                                    direction.id = Convert.ToInt32(DbMyConn.MyReader["id"]);
                                    direction.direction = DbMyConn.MyReader["direction"].ToString();
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

                return direction;
            }
        }
        public List<Direction> GetListDirection()
        {
            lock (Global.ThreadLockDao)
            {
                List<Direction> Listdirection = new List<Direction>();

                try
                {
                    string SQL = "SELECT * FROM cc_directions WHERE is_active=1";
                    DbMyConn.MyConn.Open();
                    using (DbMyConn.MyCommand = new MySqlCommand(SQL, DbMyConn.MyConn))
                    {
                        using (DbMyConn.MyReader = DbMyConn.MyCommand.ExecuteReader())
                        {
                            if (DbMyConn.MyReader.HasRows)
                            {
                                Direction direction = new Direction();
                                direction.id = -2;
                                direction.direction = null;
                                Listdirection.Add(direction);
                                while (DbMyConn.MyReader.Read())
                                {
                                    direction = new Direction();
                                    direction.id = Convert.ToInt32(DbMyConn.MyReader["id"]);
                                    direction.direction = DbMyConn.MyReader["direction"].ToString();
                                    Listdirection.Add(direction);
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

                return Listdirection;
            }
        }

        
    }
}
