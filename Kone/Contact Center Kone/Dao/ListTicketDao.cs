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
    public class ListTicketDao
    {
        DbMyConnection Conn = new DbMyConnection();

        public List<ListTicket> getListTicket(string dtefrom, string dteuntil, string tcketno)
        {
            lock (Global.ThreadLockDao)
            {
                List<ListTicket> listticket = new List<ListTicket>();

                try
                {
                    string SQL = string.Empty;
                    SQL += " SELECT tickets.id,tickets.product_type_id, tickets.model_id, ";
                    SQL += " tickets.created_date,tickets.ticket_no,product_types.name AS product_type,models.name AS model,tickets.serial_no";
                    SQL += " FROM tickets";
                    SQL += " LEFT JOIN product_types ON product_types.id = tickets.product_type_id";
                    SQL += " LEFT JOIN models ON models.id = tickets.model_id"; 
                    SQL += " WHERE DATE_FORMAT(open_date, '%Y-%m-%d') BETWEEN '" + dtefrom + "' AND '" + dteuntil + "'";
                    SQL += tcketno == "" ? "" : " AND ticket_no LIKE '%" + tcketno + "%'";

                    Conn.MyConn.Open();
                    using (Conn.MyCommand = new MySqlCommand(SQL, Conn.MyConn))
                    {
                        using (Conn.MyReader = Conn.MyCommand.ExecuteReader())
                        {
                            if (Conn.MyReader.HasRows)
                            {
                                while (Conn.MyReader.Read())
                                {
                                    ListTicket ticket = new ListTicket();
                                    ticket.id = Convert.ToInt32(Conn.MyReader["id"]);
                                    ticket.product_type_id = Conn.MyReader["product_type_id"].ToString();
                                    ticket.model_id = Conn.MyReader["model_id"].ToString();
                                    ticket.created_date = Conn.MyReader["created_date"].ToString();
                                    ticket.ticketno = Conn.MyReader["ticket_no"].ToString();
                                    ticket.product_type = Conn.MyReader["product_type"].ToString();
                                    ticket.model = Conn.MyReader["model"].ToString();
                                    ticket.serial_no = Conn.MyReader["serial_no"].ToString();
                                    listticket.Add(ticket);
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

                return listticket;
            }
        }

        public bool CheckTagTicketExist(int mediaid, int sourcemediaid, int ticketid)
        {
            lock (Global.ThreadLockDao)
            {
                int RetVal = 0;

                try
                {
                    string SQL = string.Empty;

                    SQL += "SELECT COUNT(id) AS total FROM cc_ticket_tags ";
                    SQL += " WHERE media_id=" + mediaid + " AND source_media_id=" + sourcemediaid + " AND ticket_id=" + ticketid;


                    Conn.MyConn.Open();

                    using (Conn.MyCommand = new MySqlCommand(SQL,Conn.MyConn))
                    {
                        using (Conn.MyReader = Conn.MyCommand.ExecuteReader())
                        {
                            if (Conn.MyReader.HasRows)
                            {
                                if (Conn.MyReader.Read())
                                {
                                    RetVal = Convert.ToInt32(Conn.MyReader["total"]);
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

                return RetVal > 0;
            }
        }

        public bool InsertTagTicket(TagTicket tagticket)
        {
            lock (Global.ThreadLockDao)
            {
                int Retval = 0;

                try
                {
                    string SQL = string.Empty;
                    SQL += "INSERT cc_ticket_tags ";
                    SQL += " SET";
                    SQL += " media_id=" + tagticket.media_id;
                    SQL += " ,ticket_id=" + tagticket.ticket_id;
                    SQL += " ,source_media_id=" + tagticket.source_media_id;

                    //SQL += " INSERT INTO cc_ticket_tags ";
                    //SQL += " (media_id, ticket_id, source_media_id)";
                    //SQL += " VALUES";
                    //SQL += " (" + tagticket.media_id + "," + tagticket.ticket_id + "," + tagticket.source_media_id + ")";
                    //SQL += " ON DUPLICATE KEY UPDATE";
                    //SQL += " media_id     = VALUES(media_id),";
                    //SQL += " ticket_id = VALUES(ticket_id),";
                    //SQL += " source_media_id = VALUES(source_media_id)";

                    Conn.MyConn.Open();
                    using (Conn.MyCommand = new MySqlCommand(SQL,Conn.MyConn))
                    {
                        Retval = Conn.MyCommand.ExecuteNonQuery();
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

                return Retval > 0;
            }
        }

        public string GetTicketNo_ByMediaId_SourceMediaId(int mediaid, int sourcemediaid)
        {
            lock (Global.ThreadLockDao)
            {
                string RetVal = string.Empty;

                try
                {
                    string SQL = string.Empty;
                    SQL += " SELECT  ";
                    SQL += " cc_ticket_tags.id,";
                    SQL += " cc_ticket_tags.media_id,";
                    SQL += " cc_ticket_tags.ticket_id,";
                    SQL += " cc_ticket_tags.source_media_id,";
                    SQL += " tickets.ticket_no";
                    SQL += " FROM cc_ticket_tags ";
                    SQL += " LEFT JOIN tickets ON tickets.id = cc_ticket_tags.ticket_id";
                    SQL += " WHERE cc_ticket_tags.media_id = " + mediaid + " AND cc_ticket_tags.source_media_id=" + sourcemediaid;

                    Conn.MyConn.Open();
                    using (Conn.MyCommand = new MySqlCommand(SQL,Conn.MyConn))
                    {
                        using (Conn.MyReader = Conn.MyCommand.ExecuteReader())
                        {
                            if (Conn.MyReader.HasRows)
                            {
                                while (Conn.MyReader.Read())
                                {

                                    if (Conn.MyReader["ticket_no"] != DBNull.Value)
                                    {
                                        RetVal += Conn.MyReader["ticket_no"].ToString() + ",";
                                    }
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
                if (RetVal.Length > 0)
                {
                   RetVal = RetVal.Remove(RetVal.Length - 1);
                }

                return RetVal;
            }
        }

        public List<ListTicket> getListTicket(int mediaId, int souremediaid)
        {
            lock (Global.ThreadLockDao)
            {
                List<ListTicket> listticket = new List<ListTicket>();

                try
                {
                    string SQL = string.Empty;
                    SQL += " SELECT tickets.id,tickets.product_type_id, tickets.model_id, ";
                    SQL += " tickets.created_date,tickets.ticket_no,product_types.name AS product_type,models.name AS model,tickets.serial_no";
                    SQL += " FROM cc_ticket_tags";
                    SQL += " LEFT JOIN tickets ON tickets.id = cc_ticket_tags.ticket_id";
                    SQL += " LEFT JOIN product_types ON product_types.id = tickets.product_type_id";
                    SQL += " LEFT JOIN models ON models.id = tickets.model_id";
                    SQL += " WHERE cc_ticket_tags.source_media_id = " + souremediaid + " AND cc_ticket_tags.media_id = " + mediaId;

                    Conn.MyConn.Open();
                    using (Conn.MyCommand = new MySqlCommand(SQL, Conn.MyConn))
                    {
                        using (Conn.MyReader = Conn.MyCommand.ExecuteReader())
                        {
                            if (Conn.MyReader.HasRows)
                            {
                                while (Conn.MyReader.Read())
                                {
                                    ListTicket ticket = new ListTicket();
                                    ticket.id = Convert.ToInt32(Conn.MyReader["id"]);
                                    ticket.product_type_id = Conn.MyReader["product_type_id"].ToString();
                                    ticket.model_id = Conn.MyReader["model_id"].ToString();
                                    ticket.created_date = Conn.MyReader["created_date"].ToString();
                                    ticket.ticketno = Conn.MyReader["ticket_no"].ToString();
                                    ticket.product_type = Conn.MyReader["product_type"].ToString();
                                    ticket.model = Conn.MyReader["model"].ToString();
                                    ticket.serial_no = Conn.MyReader["serial_no"].ToString();
                                    listticket.Add(ticket);
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

                return listticket;
            }
        }

    }
}
