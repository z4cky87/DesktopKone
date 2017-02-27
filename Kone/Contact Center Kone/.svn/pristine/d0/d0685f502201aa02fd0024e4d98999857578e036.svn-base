using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contact_Center_Kone.Dao
{
    public class TicketDao
    {
        private Utility.DbMyConnection myConn = new Utility.DbMyConnection();
       
        public List<Entity.Ticket> GetByCallId(string callId)
        {
            lock (Utility.Global.ThreadLockDao)
            {
                var tickets = new List<Entity.Ticket>();
                try
                {
                    var query = "select 	t.id, "+
                                            "t.ticket_no, "+
                                            "d.name as departmentname,"+
                                            "ts.`name` as ticketstatus, "+                                       
                                            "t.open_date, "+
                                            "u1.username as openuser,"+
                                            "t.process_date, "+
                                            "u2.username as processuser,"+
                                            "t.submit_date, "+
                                            "u3.username as submituser,"+
                                            "t.done_date, "+
                                            "u4.username as doneuser,"+
                                            "t.close_date ,"+
                                            "u5.username as closeuser"+
                                           
                                 " from tickets as t "+
                                 " left join ticket_statuses as ts on t.ticket_status_id=ts.id"+                     
                                 " left join cc_users as u1 on u1.id=t.open_user_by"+
                                 " left join cc_users as u2 on u1.id=t.process_user_by"+
                                 " left join cc_users as u3 on u1.id=t.submit_user_by"+
                                 " left join cc_users as u4 on u1.id=t.done_user_by"+
                                 " left join cc_users as u5 on u1.id=t.close_user_by"+
                                 " left join cc_ticket_tags as ctt on t.id=ctt.ticket_id "+
                                 " left join cc_calls as cc on cc.id=ctt.media_id "+
                                 " left join departments as d on t.department_id=d.id" +
                                 "  where cc.id='" + callId + "' group by t.id desc";

                    myConn.MyConn.Open();
                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(query, myConn.MyConn))
                    using (myConn.MyReader = myConn.MyCommand.ExecuteReader())
                    {
                        if (myConn.MyReader.HasRows)
                        {
                            while (myConn.MyReader.Read())
                            {
                                tickets.Add(new Entity.Ticket()
                                {
                                    id = Convert.ToInt32(myConn.MyReader["id"]),
                                    ticketNo = myConn.MyReader["ticket_number"].ToString(),
                                    department = myConn.MyReader["departmentname"].ToString(),
                                    status = myConn.MyReader["ticketstatus"].ToString(),
                                    openDate = myConn.MyReader["open_date"].ToString(),
                                    openUser = myConn.MyReader["openuser"].ToString(),
                                    processDate = myConn.MyReader["process_date"].ToString(),
                                    processedUser = myConn.MyReader["processuser"].ToString(),
                                    submitDate = myConn.MyReader["submit_date"].ToString(),
                                    submitUser = myConn.MyReader["submituser"].ToString(),
                                    doneDate = myConn.MyReader["done_date"].ToString(),
                                    doneUser = myConn.MyReader["doneuser"].ToString(),
                                    closeDate = myConn.MyReader["close_date"].ToString(),
                                    closeUser = myConn.MyReader["closeuser"].ToString(),
                                   
                                });
                            };
                        };
                    }

                }
                catch (Exception ex)
                {
                    Utility.Global.WriteLog(Utility.Global.GetCurrentMethod(ex));
                }
                finally { myConn.MyConn.Close(); }
                return tickets;
            }
        }
        public List<Entity.Ticket> GetByCallNumber(string callNumber,string telephone,string mobile)
        {
            lock (Utility.Global.ThreadLockDao)
            {
                var tickets = new List<Entity.Ticket>();
                try
                {
                    var query = "select 	t.id, " +
                                            "t.ticket_no, " +
                                            "d.name as departmentname," +
                                            "ts.`name` as ticketstatus, " +
                                            "t.open_date, " +
                                            "u1.username as openuser," +
                                            "t.process_date, " +
                                            "u2.username as processuser," +
                                            "t.submit_date, " +
                                            "u3.username as submituser," +
                                            "t.done_date, " +
                                            "u4.username as doneuser," +
                                            "t.close_date ," +
                                            "u5.username as closeuser" +

                                 " from tickets as t " +
                                 " left join ticket_statuses as ts on t.ticket_status_id=ts.id" +
                                 " left join cc_users as u1 on u1.id=t.open_user_by" +
                                 " left join cc_users as u2 on u2.id=t.process_user_by" +
                                 " left join cc_users as u3 on u3.id=t.submit_user_by" +
                                 " left join cc_users as u4 on u4.id=t.done_user_by" +
                                 " left join cc_users as u5 on u5.id=t.close_user_by" +
                                 " left join cc_ticket_tags as ctt on t.id=ctt.ticket_id " +
                                 " left join cc_calls as cc on cc.id=ctt.media_id " +
                                 " left join departments as d on t.department_id=d.id" +
                                 "  where cc.caller_number='" + callNumber + "' or cc.telp='" + telephone + "' or cc.hp='" + mobile + "'";

                    myConn.MyConn.Open();
                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(query, myConn.MyConn))
                    using (myConn.MyReader = myConn.MyCommand.ExecuteReader())
                    {
                        if (myConn.MyReader.HasRows)
                        {
                            while (myConn.MyReader.Read())
                            {
                                tickets.Add(new Entity.Ticket()
                                {
                                    id = Convert.ToInt32(myConn.MyReader["id"]),
                                    ticketNo = myConn.MyReader["ticket_no"].ToString(),
                                    department = myConn.MyReader["departmentname"].ToString(),
                                    status = myConn.MyReader["ticketstatus"].ToString(),
                                    openDate = myConn.MyReader["open_date"].ToString(),
                                    openUser = myConn.MyReader["openuser"].ToString(),
                                    processDate = myConn.MyReader["process_date"].ToString(),
                                    processedUser = myConn.MyReader["processuser"].ToString(),
                                    submitDate = myConn.MyReader["submit_date"].ToString(),
                                    submitUser = myConn.MyReader["submituser"].ToString(),
                                    doneDate = myConn.MyReader["done_date"].ToString(),
                                    doneUser = myConn.MyReader["doneuser"].ToString(),
                                    closeDate = myConn.MyReader["close_date"].ToString(),
                                    closeUser = myConn.MyReader["closeuser"].ToString(),
                                });
                            };
                        };
                    }

                }
                catch (Exception ex)
                {
                    Utility.Global.WriteLog(Utility.Global.GetCurrentMethod(ex));
                }
                finally { myConn.MyConn.Close(); }
                return tickets;
            }
        }
      
        public List<string> GetByTicketId(string ticketId)
        {
            lock (Utility.Global.ThreadLockDao)
            {
                var ticket = new List<string>();
                try
                {
                    var query = "select 	nt.ticket_number," +
                                            "nts.`status`," +
                                            "ntp.`type`," +
                                            "nuuser.username," +
                                            "nt.open_at," +
                                            "nuopen.username as open_by," +
                                            "nt.processed_at," +
                                            "nuprocess.username as process_by," +
                                            "nt.assigned_at," +
                                            "nuassigned.username as assigned_by," +
                                            "nt.accepted_at," +
                                            "nuaccepted.username as accepted_by," +
                                            "nt.rejected_at," +
                                            "nureject.username as reject_by," +
                                            "nt.done_at," +
                                            "nudone.username as done_by," +
                                            "nt.closed_at," +
                                            "nuclose.username as close_by," +
                                            "nt.canceled_at," +
                                            "nucancel.username as cancel_by" +

                                 " from nuwira_tickets as nt " +
                                            " left join nuwira_ticket_statuses as nts on nt.status_id=nts.id" +
                                            " left join nuwira_ticket_types as ntp on nt.type_id=ntp.id" +
                                            " left join cc_users as nuuser on nt.user_id=nuuser.id" +
                                            " left join cc_users as nuopen on nt.open_by=nuopen.id" +
                                            " left join cc_users as nuprocess on nt.processed_by=nuprocess.id" +
                                            " left join cc_users as nuassigned on nt.assigned_by=nuassigned.id" +
                                            " left join cc_users as nuaccepted on nt.accepted_by=nuaccepted.id" +
                                            " left join cc_users as nureject on nt.rejected_by=nureject.id" +
                                            " left join cc_users as nudone on nt.done_by=nudone.id" +
                                            " left join cc_users as nuclose on nt.closed_by=nuclose.id" +
                                            " left join cc_users as nucancel on nt.closed_by=nucancel.id" +
                                            " where nt.id='" + ticketId + "'";

                    myConn.MyConn.Open();
                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(query, myConn.MyConn))
                    using (myConn.MyReader = myConn.MyCommand.ExecuteReader())
                    {
                        if (myConn.MyReader.HasRows)
                        {
                            while (myConn.MyReader.Read())
                            {
                                
                                for (int i = 0; i < myConn.MyReader.FieldCount; i++)
                                {
                                    ticket.Add(myConn.MyReader[i].ToString());
                                }
                                
                            };
                        };
                    }

                }
                catch (Exception ex)
                {
                    Utility.Global.WriteLog(Utility.Global.GetCurrentMethod(ex));
                }
                finally { myConn.MyConn.Close(); }
                return ticket;
            }
        }
        public bool Delete(string ticketNo)
        {
            var result = false;
            try
            {
                var queryString = "delete from nuwira_tickets where ticket_number=@ticketno";

                myConn.MyConn.Open();

                using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(queryString, myConn.MyConn))
                {
                    myConn.MyCommand.Parameters.AddWithValue("@ticketno", ticketNo);
                }
                result = (myConn.MyCommand.ExecuteNonQuery() == 1);
            }
            catch (Exception ex)
            {
                Utility.Global.WriteLog(Utility.Global.GetCurrentMethod(ex));
            }
            finally
            {
                myConn.MyConn.Close();
            }
            return result;
        }
       
    }
}
