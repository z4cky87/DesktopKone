using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contact_Center_Kone.Entity;
using Contact_Center_Kone.Utility;
using MySql.Data.MySqlClient;

namespace Contact_Center_Kone.Dao
{
    public class MailAttachmentDao
    {
        DbMyConnection Conn = new DbMyConnection();

        public MailAttachment GetAttachment_ById(int id)
        {
            lock (Global.ThreadLockDao)
            {
                MailAttachment attachment = new MailAttachment();

                try
                {
                    string SQL = "SELECT * FROM cc_mail_attachments WHERE mail_id=" + id;

                    Conn.MyConn.Open();
                    using (Conn.MyCommand = new MySqlCommand(SQL,Conn.MyConn))
                    {
                        using (Conn.MyReader = Conn.MyCommand.ExecuteReader())
                        {
                            if (Conn.MyReader.HasRows)
                            {
                                if (Conn.MyReader.Read())
                                {
                                    MailAttachment mailattachment = new MailAttachment();
                                    mailattachment.id = Convert.ToInt32(Conn.MyReader["id"]);
                                    mailattachment.mail_id = Convert.ToInt32(Conn.MyReader["mail_id"]);
                                    mailattachment.filename = Conn.MyReader["filename"].ToString();
                                    
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

                return attachment;
            }

        }

        public List<MailAttachment> GetAttachment(int mailid)
        {
            lock (Global.ThreadLockDao)
            {
                List<MailAttachment> listattachment = new List<MailAttachment>();

                try
                {
                    string SQL = "SELECT * FROM cc_mail_attachments WHERE mail_id=" + mailid;

                    Conn.MyConn.Open();
                    using (Conn.MyCommand = new MySqlCommand(SQL, Conn.MyConn))
                    {
                        using (Conn.MyReader = Conn.MyCommand.ExecuteReader())
                        {
                            if (Conn.MyReader.HasRows)
                            {
                                while (Conn.MyReader.Read())
                                {
                                    MailAttachment mailattachment = new MailAttachment();
                                    mailattachment.id = Convert.ToInt32(Conn.MyReader["id"]);
                                    mailattachment.mail_id = Convert.ToInt32(Conn.MyReader["mail_id"]);
                                    mailattachment.filename = Conn.MyReader["filename"].ToString();
                                    listattachment.Add(mailattachment);
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

                return listattachment;
            }

        }
        public bool Insert_MailAttachment(MailAttachment mailattachment)
        {
            lock (Global.ThreadLockDao)
            {
                //int RetVal = 0;
                bool RetVal = false;
                int mailattachmentid = 0;
                try
                {
                    string SQL = string.Empty;
                    SQL += "INSERT cc_mail_attachments SET ";
                    SQL += "mail_id=@mail_id,";
                    SQL += "filename=@filename,";
                    SQL += "path=@path;";
                    Conn.MyConn.Open();
                    using (Conn.MyCommand = new MySqlCommand())
                    {
                        using (Conn.MyCommand = Conn.MyConn.CreateCommand())
                        {
                            Conn.MyCommand.CommandText = SQL;
                            Conn.MyCommand.Parameters.AddWithValue("@mail_id", mailattachment.mail_id);
                            Conn.MyCommand.Parameters.AddWithValue("@filename", mailattachment.filename);
                            Conn.MyCommand.Parameters.AddWithValue("@path", Global.atacchment_outbox + mailattachment.mail_id + "/");
                            //mailattachmentid = Conn.MyCommand.ExecuteNonQuery();
                            mailattachmentid = Conn.MyCommand.ExecuteNonQuery();
                            RetVal = true;
                        }
                    }
                }
                catch (Exception Ex)
                {
                    Global.WriteLog(Global.GetCurrentMethod(Ex));
                }finally{
                    Conn.MyConn.Close();
                }
               

                

                return RetVal;
            }
        }
   
        public string Get_CountMailAttachment(int mailid)
        {
            lock (Global.ThreadLockDao)
            {
                string RetVal = string.Empty;

                try
                {
                    string SQL = "SELECT COUNT(id) AS total FROM cc_mail_attachments WHERE mail_id=" + mailid;

                    Conn.MyConn.Open();
                    using (Conn.MyCommand = new MySqlCommand(SQL,Conn.MyConn))
                    {
                        using (Conn.MyReader = Conn.MyCommand.ExecuteReader())
                        {
                            if (Conn.MyReader.HasRows)
                            {
                                if (Conn.MyReader.Read())
                                {
                                    RetVal = Conn.MyReader["total"].ToString();
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

                return RetVal;
            }
        }
        


    }
}
