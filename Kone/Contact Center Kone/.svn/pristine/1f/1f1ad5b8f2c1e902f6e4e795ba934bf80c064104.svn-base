using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contact_Center_Kone.Entity;
using Contact_Center_Kone.Utility;
using MySql.Data.MySqlClient;

namespace Contact_Center_Kone.Dao
{
    public class PaymentMethodDao
    {
        DbMyConnection DbMyConn = new DbMyConnection();

        public PaymentMethod GetPaymentMethod_ByID(string id)
        {
            lock (Global.ThreadLockDao)
            {
                PaymentMethod paymentmethod = new PaymentMethod();

                try
                {
                    string SQL = "SELECT *  FROM cc_payment_methodes WHERE id='" + id + "'";
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
                                    paymentmethod.id = Convert.ToInt32(DbMyConn.MyReader["id"]);
                                    paymentmethod.methode = DbMyConn.MyReader["methode"].ToString();
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

                return paymentmethod;
            }
        }
    }
}
