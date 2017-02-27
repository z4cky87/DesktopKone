using Contact_Center_Kone.Utility;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contact_Center_Kone.Dao
{
    public class DepartmentDao
    {
        private Utility.DbMyConnection Conn = new Utility.DbMyConnection();

        public List<Entity.Department> GetAllDepartmentName()
        {
            lock (Utility.Global.ThreadLockDao)
            {
                List<Entity.Department> departmentName = new List<Entity.Department>();
                lock (Global.ThreadLockDao)
                {
                    try
                    {
                        string SQL = "SELECT * FROM departments";

                        Conn.MyConn.Open();
                        using (Conn.MyCommand = new MySqlCommand(SQL, Conn.MyConn))
                        {
                            using (Conn.MyReader = Conn.MyCommand.ExecuteReader())
                            {
                                if (Conn.MyReader.HasRows)
                                {
                                    while (Conn.MyReader.Read())
                                    {
                                        departmentName.Add(new Entity.Department   ()
                                        {
                                            id = Conn.MyReader["id"].ToString(),
                                            department = Conn.MyReader["name"].ToString()
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


                    return departmentName;
                }
            }

        }
    }
}
