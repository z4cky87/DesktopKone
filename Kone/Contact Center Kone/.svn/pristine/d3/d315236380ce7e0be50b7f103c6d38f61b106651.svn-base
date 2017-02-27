using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contact_Center_Kone.Utility;

namespace Contact_Center_Kone.Dao
{
    public class TicketTypeDao
    {
        private Utility.DbMyConnection myConn = new Utility.DbMyConnection();

        public Entity.TicketType getById(string id)
        {
            lock (Global.ThreadLockDao)
            {
                Entity.TicketType ticketType = null;
                string sql = "select * from nuwira_ticket_types where id = "+id;
                try
                {
                    myConn.MyConn.Open();
                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(sql, myConn.MyConn))
                    {
                        using (myConn.MyReader = myConn.MyCommand.ExecuteReader())
                        {
                            ticketType = new Entity.TicketType();
                            ticketType.id = myConn.MyReader["id"].ToString();
                            ticketType.type = myConn.MyReader["type"].ToString();
                            ticketType.type_code = myConn.MyReader["type_code"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Global.WriteLog(Global.GetCurrentMethod(ex));
                }
                finally
                {
                    myConn.MyConn.Close();
                }
                return ticketType;
            }
        }
    }
}
