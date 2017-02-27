using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contact_Center_Kone.Dao;
using Contact_Center_Kone.Entity;
using Contact_Center_Kone.Utility;
using MySql.Data.MySqlClient;


namespace Contact_Center_Kone.Dao
{
    public class TagTicketDao
    {
        DbMyConnection myConn = new DbMyConnection();

        public bool Insert(Entity.TagTicket tagTicket)
        {
            lock (Utility.Global.ThreadLockDao)
            {
                var result = false;
                try
                {
                    var queryString = "insert into cc_ticket_tags set " +
                                        "media_id=@mediaid," +
                                        "ticket_id=@ticketid," +
                                        "source_media_id=@sourcemediaid";

                    myConn.MyConn.Open();

                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(queryString, myConn.MyConn))
                    {
                        myConn.MyCommand.Parameters.AddWithValue("@mediaid", tagTicket.media_id);
                        myConn.MyCommand.Parameters.AddWithValue("@ticketid", tagTicket.ticket_id);
                        myConn.MyCommand.Parameters.AddWithValue("@sourcemediaid", tagTicket.source_media_id);
                        result = (myConn.MyCommand.ExecuteNonQuery() == 1);
                    };

                }
                catch (Exception ex) { Utility.Global.WriteLog(Utility.Global.GetCurrentMethod(ex)); }
                finally
                {
                    myConn.MyConn.Close();
                }
                return result;
            }
        }
       
    
    }
}
