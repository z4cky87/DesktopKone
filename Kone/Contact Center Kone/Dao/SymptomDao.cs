using Contact_Center_Kone.Utility;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contact_Center_Kone.Dao
{
    public class SymptomDao
    {
        private Utility.DbMyConnection Conn = new Utility.DbMyConnection();
        public List<Entity.Symptom> GetAllSymptomCode()
        {
            lock (Utility.Global.ThreadLockDao)
            {
                List<Entity.Symptom> symptomCode = new List<Entity.Symptom>();

                symptomCode.Add(new Entity.Symptom()   {
                                                            Id = "0",
                                                            Code = " --- "
                                                        });
                                                              
                lock (Global.ThreadLockDao)
                {
                    try
                    {
                        string SQL = " select id, concat(code,' - ',description) as codes" +
                                        
                                        " from symptom_codes ";

                        Conn.MyConn.Open();
                        using (Conn.MyCommand = new MySqlCommand(SQL, Conn.MyConn))
                        {
                            using (Conn.MyReader = Conn.MyCommand.ExecuteReader())
                            {
                                if (Conn.MyReader.HasRows)
                                {
                                    while (Conn.MyReader.Read())
                                    {
                                        symptomCode.Add(new Entity.Symptom()
                                        {
                                            Id = Conn.MyReader["id"].ToString(),
                                            Code = Conn.MyReader["codes"].ToString(),                                          
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


                    return symptomCode;
                }
            }

        }
    }
}
