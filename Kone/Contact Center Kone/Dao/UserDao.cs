﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contact_Center_Kone.Entity;
using Contact_Center_Kone.Utility;
using MySql.Data.MySqlClient;
using CryptSharp;
using System.Collections.Specialized;
using Newtonsoft.Json;
using System.Data;


namespace Contact_Center_Kone.Dao
{
    public class UserDao
    {
        DbMyConnection Conn = new DbMyConnection();
        Entity.LogLogin _loglogin = new LogLogin();
        public User GetUser_ByID(int id)
        {
            lock (Global.ThreadLockDao)
            {
                User user = null;

                try
                {
                    string SQL = "SELECT * FROM cc_users WHERE id=" + id;

                    Conn.MyConn.Open();
                    using (Conn.MyCommand = new MySqlCommand(SQL, Conn.MyConn))
                    {
                        using (Conn.MyReader = Conn.MyCommand.ExecuteReader())
                        {
                            if (Conn.MyReader.HasRows)
                            {
                                while (Conn.MyReader.Read())
                                {
                                    user = new User();
                                   // user.id = Convert.ToInt32(Conn.MyReader["id"]);
                                    user.username = Conn.MyReader["username"].ToString();

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
                return user;
            }
        }
        public bool Login(Entity.User user)
        {
            lock (Global.ThreadLockDao)
            {
                var result = false;

                try
                {
                    string SQL = "SELECT * FROM cc_users WHERE username='" + user.username + "' and password=md5('" + user.password + "') and is_active=1";

                    Conn.MyConn.Open();
                    using (Conn.MyCommand = new MySqlCommand(SQL, Conn.MyConn))
                    {
                        using (Conn.MyReader = Conn.MyCommand.ExecuteReader())
                        {
                            if (Conn.MyReader.HasRows)
                            {

                                while (Conn.MyReader.Read())
                                {
                                    Global.userAccount.id = Conn.MyReader["id"].ToString();
                                    Global.userAccount.username = Conn.MyReader["username"].ToString();
                                    Global.userAccount.password = Conn.MyReader["password"].ToString();
                                    Global.userAccount.fullname = Conn.MyReader["fullname"].ToString();
                                    Global.userAccount.level = Conn.MyReader["level_id"].ToString(); 
                                    Global.userAccount.inbound_ext = Conn.MyReader["inbound_ext"].ToString();
                                    Global.userAccount.inbound_ext_pwd = Conn.MyReader["inbound_ext_pwd"].ToString();
                                    Global.userAccount.pbx_inbound = Conn.MyReader["pbx_host"].ToString();
                                    Global.userAccount.outbound_ext = Conn.MyReader["outbound_ext"].ToString();
                                    Global.userAccount.outbound_ext_pwd = Conn.MyReader["outbound_ext_pwd"].ToString();
                                    Global.userAccount.pbx_outbound = Conn.MyReader["pbx_host_outbound"].ToString();
                                    Global.userAccount.host_addr = Conn.MyReader["host_addr"].ToString();
                                    Global.userAccount.host_name = Conn.MyReader["host_name"].ToString();
                                    Global.hashPassword = Global.userAccount.password;
                                }
                                result = true;
                            }
                            else { result = false; }

                        }
                    }
                   
                }
                catch (Exception Ex)
                {
                    result = false;
                    Global.WriteLog(Global.GetCurrentMethod(Ex));
                }
                finally
                {
                    Conn.MyConn.Close();
                }


                return result;
            }
        }

        public bool CheckLoginFirst (Entity.LogLogin _loglogin)
        {
            lock (Global.ThreadLockDao)
            {
                var result = false;
                try
                {
                    string SQL = "SELECT * FROM cc_log_login WHERE date(cc_log_login.login_time)=CURDATE() AND user_id =" + Global.userAccount.id;
                    Conn.MyConn.Open();
                    using (Conn.MyCommand = new MySqlCommand(SQL, Conn.MyConn))
                    {
                        using (Conn.MyReader = Conn.MyCommand.ExecuteReader())
                        {
                            if (Conn.MyReader.HasRows)
                            {
                                while (Conn.MyReader.Read())
                                {
                                    //Global.userAccount.id = Conn.MyReader["id"].ToString();
                                    _loglogin.user_id = Conn.MyReader["user_id"].ToString();
                                    _loglogin.login_temp = Conn.MyReader["login_temp"].ToString();
                                    _loglogin.login_time = Conn.MyReader["login_time"].ToString();
                                    _loglogin.logout_time = Conn.MyReader["logout_time"].ToString();
                                    _loglogin.login_count = Conn.MyReader["login_count"].ToString();
                                }
                                result = true;
                            }
                            else
                            {
                                result = false;
                            }
                        }
                    }
                }
                catch (Exception Ex)
                {
                    result = false;
                    Global.WriteLog(Global.GetCurrentMethod(Ex));
                }
                finally
                {
                    Conn.MyConn.Close();
                }
                return result;
            }
        }
        public string InsertLog_login()
        {
            lock (Global.ThreadLockDao)
            {
                string RetVal = string.Empty;

                try
                {
                    //String SQL = "SELECT * FROM cc_log_login WHERE login_first is not null and CURRENT_DATE() and user_id=" + Global.userAccount.id;
                    //string SQL= "";
                    //if ()
                    //{
                                string SQL = string.Empty; 
                                SQL += "INSERT cc_log_login SET ";
                                SQL += " user_id=" + Global.userAccount.id;
                                SQL += " ,application_id=0";
                                SQL += " ,login_temp=NOW()";
                                SQL += " ,login_time=NOW()";
                                SQL += " ,cc_log_login.login_count= cc_log_login.login_count + 1;";
                                SQL += " SELECT LAST_INSERT_ID() as lastid;";
                                Conn.MyConn.Open();
                                using (Conn.MyCommand = new MySqlCommand(SQL, Conn.MyConn))
                                {
                                    using (Conn.MyReader = Conn.MyCommand.ExecuteReader())
                                    {
                                        if (Conn.MyReader.HasRows)
                                        {
                                            if (Conn.MyReader.Read())
                                            {
                                                RetVal = Conn.MyReader["lastid"].ToString();
                                            }
                                        }
                                    }
                                }
                   // }
                   //     
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

        public bool UpdateLog_login_Next()
        {
            lock (Global.ThreadLockDao)
            {
                int RetVal = 0;

                try
                {
                    //String SQL = "SELECT * FROM cc_log_login WHERE login_first is not null and CURRENT_DATE() and user_id=" + Global.userAccount.id;
                    //string SQL= "";
                    //if ()
                    //{
                    string SQL = string.Empty;
                    SQL += "UPDATE cc_log_login SET";
                    //SQL += " user_id=" + Global.userAccount.id;
                    SQL += " cc_log_login.login_temp=NOW()";
                    //SQL += " ,login_time=NOW()";
                    SQL += " ,cc_log_login.login_count= cc_log_login.login_count + 1";
                    SQL += " WHERE application_id=0 AND date(cc_log_login.login_time)=CURDATE() AND cc_log_login.user_id=" + Global.userAccount.id;
                    Conn.MyConn.Open();
                    using (Conn.MyCommand = new MySqlCommand(SQL, Conn.MyConn))
                    {
                        RetVal = Conn.MyCommand.ExecuteNonQuery();
                    }
                    // }
                    //     
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

        public bool UpdatetLog_logout()
        {
            lock (Global.ThreadLockDao)
            {
                int RetVal = 0;

                try
                {
                    string SQL = string.Empty;
                    SQL += "UPDATE cc_log_login SET ";
                    SQL += " logout_time=NOW(), ";
                    SQL += " total_duration = IFNULL(total_duration,'00:00:00') + TIMEDIFF(NOW(),login_temp)";
                    SQL += " WHERE id=" + Global.log_login_id;
                    Conn.MyConn.Open();
                    using (Conn.MyCommand = new MySqlCommand(SQL, Conn.MyConn))
                    {
                        RetVal = Conn.MyCommand.ExecuteNonQuery();
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

        public List<Entity.User> GetAllUserName()
        { lock (Utility.Global.ThreadLockDao)
           {
            List<Entity.User> userName = new List<Entity.User>();
            lock (Global.ThreadLockDao)
            {
                try
                {
                    string SQL = "SELECT id,username FROM cc_users";

                    Conn.MyConn.Open();
                    using (Conn.MyCommand = new MySqlCommand(SQL, Conn.MyConn))
                    {
                        using (Conn.MyReader = Conn.MyCommand.ExecuteReader())
                        {
                            if (Conn.MyReader.HasRows)
                            {
                                while (Conn.MyReader.Read())
                                {
                                    userName.Add(new User()
                                    {
                                        // id=Convert.ToInt16(Conn.MyReader["id"].ToString()),
                                        username = Conn.MyReader["username"].ToString()

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


                return userName;
            }
            }

        }
        public  string EncryptPassword(string password)
        {
            lock (Utility.Global.ThreadLockDao)
            {
                return Crypter.Blowfish.Crypt(password, new CrypterOptions() { { CrypterOption.Variant, BlowfishCrypterVariant.Corrected }, { CrypterOption.Rounds, 10 } });
            }
        }
        public  bool MatchPassword(string password, string encPassword)
        {
            lock (Utility.Global.ThreadLockDao)
            {
                return CryptSharp.Crypter.CheckPassword(password, encPassword);
            }
        }
        public void LogAppVer(string serial)
        {
            lock (Utility.Global.ThreadLockDao)
            {
                var result = false;
                try
                {
                    var queryString =   "update cc_users set " +
                                     
                                        " app_version=@appver" +
                                        " where id=@id";

                    Conn.MyConn.Open();

                    using (Conn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(queryString, Conn.MyConn))
                    {
                        Conn.MyCommand.Parameters.AddWithValue("@appver", serial);
                        Conn.MyCommand.Parameters.AddWithValue("@id", Global.userAccount.id);
                        result = (Conn.MyCommand.ExecuteNonQuery() == 1);
                    }

                }
                catch (Exception ex)
                { Utility.Global.WriteLog(Utility.Global.GetCurrentMethod(ex)); }
                finally
                {
                    Conn.MyConn.Close();
                }
              //  return result;
            }
        }
        public bool Insert(Entity.User myUser)
        {
            lock (Utility.Global.ThreadLockDao)
            {

                var result = false;
              
                try
                {
                    var queryString =   "insert into cc_users set " +
                                        "username=@username," +
                                        "password=md5('kone1234')," +
                                        "fullname=@name," +
                                        "department_id=@departmentid," +
                                        "level_id=@levelid," +
                                        "email=@email," +                                      
                                        "is_active=@isactive," +
                                        "inbound_ext=@inboundext," +
                                        "inbound_ext_pwd=@inboundpwd," +
                                        "pbx_host=@inboundhost," +
                                        "outbound_ext=@outbondext," +
                                        "outbound_ext_pwd=@outbondpwd," +
                                        "pbx_host_outbound=@outbondhost";

                    Conn.MyConn.Open();

                    using (Conn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(queryString, Conn.MyConn))
                    {
                        Conn.MyCommand.Parameters.AddWithValue("@username", myUser.username);
                        Conn.MyCommand.Parameters.AddWithValue("@password", myUser.password);
                        Conn.MyCommand.Parameters.AddWithValue("@name", myUser.fullname);
                        Conn.MyCommand.Parameters.AddWithValue("@departmentid", myUser.department);
                        Conn.MyCommand.Parameters.AddWithValue("@levelid", myUser.level);
                        Conn.MyCommand.Parameters.AddWithValue("@email", myUser.email);
                        Conn.MyCommand.Parameters.AddWithValue("@inboundext", myUser.inbound_ext);
                        Conn.MyCommand.Parameters.AddWithValue("@inboundpwd", myUser.inbound_ext_pwd);
                        Conn.MyCommand.Parameters.AddWithValue("@inboundhost", myUser.pbx_inbound);
                        Conn.MyCommand.Parameters.AddWithValue("@outbondext", myUser.outbound_ext);
                        Conn.MyCommand.Parameters.AddWithValue("@outbondpwd", myUser.outbound_ext_pwd);
                        Conn.MyCommand.Parameters.AddWithValue("@outbondhost", myUser.pbx_outbound);
                        Conn.MyCommand.Parameters.AddWithValue("@isactive", myUser.isActive);
                     
                        result = (Conn.MyCommand.ExecuteNonQuery() == 1);
                    }
                }
                catch (Exception ex) { Utility.Global.WriteLog(Utility.Global.GetCurrentMethod(ex)); }
                finally
                {
                    Conn.MyConn.Close();
                }
                return result;
            }
        } 
      
        public bool Update(Entity.User myUser)
        {
            lock (Utility.Global.ThreadLockDao)
            {
                var result = false;
                try
                {
                    var queryString = "update cc_users set " +
                                       "username=@username," +
                                        //"password=@password," +
                                        "fullname=@name," +
                                         "department_id=@departmentid," +
                                        "level_id=@levelid," +
                                        "email=@email," +                                       
                                        "is_active=@isactive," +
                                        "inbound_ext=@inboundext," +
                                        "inbound_ext_pwd=@inboundpwd," +
                                        "pbx_host=@inboundhost," +
                                        "outbound_ext=@outbondext," +
                                        "outbound_ext_pwd=@outbondpwd," +
                                        "pbx_host_outbound=@outbondhost" +
                                        " where id=@id";

                    Conn.MyConn.Open();

                    using (Conn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(queryString, Conn.MyConn))
                    {
                        Conn.MyCommand.Parameters.AddWithValue("@username", myUser.username);
                        //Conn.MyCommand.Parameters.AddWithValue("@password", Global.EncryptPassword(Global.defaultPassword));
                        Conn.MyCommand.Parameters.AddWithValue("@name", myUser.fullname);
                        Conn.MyCommand.Parameters.AddWithValue("@departmentid", myUser.department);
                        Conn.MyCommand.Parameters.AddWithValue("@levelid", myUser.level);
                        Conn.MyCommand.Parameters.AddWithValue("@email", myUser.email);
                        Conn.MyCommand.Parameters.AddWithValue("@inboundext", myUser.inbound_ext);
                        Conn.MyCommand.Parameters.AddWithValue("@inboundpwd", myUser.inbound_ext_pwd);
                        Conn.MyCommand.Parameters.AddWithValue("@inboundhost", myUser.pbx_inbound);
                        Conn.MyCommand.Parameters.AddWithValue("@outbondext", myUser.outbound_ext);
                        Conn.MyCommand.Parameters.AddWithValue("@outbondpwd", myUser.outbound_ext_pwd);
                        Conn.MyCommand.Parameters.AddWithValue("@outbondhost", myUser.pbx_outbound);
                        Conn.MyCommand.Parameters.AddWithValue("@isactive", myUser.isActive);
                        Conn.MyCommand.Parameters.AddWithValue("@id", myUser.id);
                        result = (Conn.MyCommand.ExecuteNonQuery() == 1);
                    }

                }
                catch (Exception ex)
                { Utility.Global.WriteLog(Utility.Global.GetCurrentMethod(ex)); }
                finally
                {
                    Conn.MyConn.Close();
                }
                return result;
            }
        }
        public bool Delete(Entity.User myUser)
        {
            lock (Utility.Global.ThreadLockDao)
            {
                var result = false;
                try
                {
                    var queryString = "delete from cc_users where id=@id";

                    Conn.MyConn.Open();

                    using (Conn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(queryString, Conn.MyConn))
                    {
                        Conn.MyCommand.Parameters.AddWithValue("@id", myUser.id);
                    }
                    result = (Conn.MyCommand.ExecuteNonQuery() == 1);
                }
                catch (Exception ex)
                {
                    Utility.Global.WriteLog(Utility.Global.GetCurrentMethod(ex));
                }
                finally
                {
                    Conn.MyConn.Close();
                }
                return result;
            }
        }
        public List<User>GetAll()
        {
            lock (Utility.Global.ThreadLockDao)
            {
                var users = new List<Entity.User>();
                try
                {
                    var query = "select     cc_users.id," +
                                            "username," +
                                            "fullname," +
                                            "email," +
                                            "host_addr," +
                                            "host_name," +
                                            "inbound_ext," +
                                            "inbound_ext_pwd," +
                                            "pbx_host," +
                                            "outbound_ext," +
                                            "outbound_ext_pwd," +
                                            "pbx_host_outbound," +
                                            "departments.name," +
                                            "cc_user_levels.level," +
                                             "cc_users.is_active" +
                                 " from cc_users left join departments on cc_users.department_id=departments.id"+
                                 " left join cc_user_levels on cc_users.level_id=cc_user_levels.level_id";
                    Conn.MyConn.Open();
                    using (Conn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(query, Conn.MyConn))
                    using (Conn.MyReader = Conn.MyCommand.ExecuteReader())
                    {
                        if (Conn.MyReader.HasRows)
                        {
                            while (Conn.MyReader.Read())
                            {
                                users.Add(new Entity.User()
                                {
                                    id = Conn.MyReader["id"].ToString(),
                                    username = Conn.MyReader["username"].ToString(),
                                    fullname = Conn.MyReader["fullname"].ToString(),
                                    email = Conn.MyReader["email"].ToString(),
                                    host_addr = Conn.MyReader["host_addr"].ToString(),
                                    host_name = Conn.MyReader["host_name"].ToString(),
                                    inbound_ext = Conn.MyReader["inbound_ext"].ToString(),
                                    inbound_ext_pwd = Conn.MyReader["inbound_ext_pwd"].ToString(),
                                    pbx_inbound = Conn.MyReader["pbx_host"].ToString(),
                                    outbound_ext = Conn.MyReader["outbound_ext"].ToString(),
                                    outbound_ext_pwd = Conn.MyReader["outbound_ext_pwd"].ToString(),
                                    pbx_outbound = Conn.MyReader["pbx_host_outbound"].ToString(),
                                    department = Conn.MyReader["name"].ToString(),
                                    level = Conn.MyReader["level"].ToString(),
                                    isActive = Conn.MyReader["is_active"].ToString()=="1"?"Yes":"No",
                                });
                            };
                        };
                    }

                }
                catch (Exception ex)
                {
                    Utility.Global.WriteLog(Utility.Global.GetCurrentMethod(ex));
                }
                finally { Conn.MyConn.Close(); }
                return users;
            }
        }
        public Entity.User GetById(string userID)
        {
            lock (Utility.Global.ThreadLockDao)
            {
               
                var user = new Entity.User();
                try
                {
                    var query = "select     cu.id,"+
				                "cu.username,"+
				                "cu.fullname,"+
				                "cu.email,"+
				                "d.name as departmennname,"+
				                "cul.`level`,"+
				                "cu.pbx_host,"+
				                "cu.inbound_ext,"+
				                "cu.inbound_ext_pwd,"+
				                "cu.outbound_ext,"+
				                "cu.outbound_ext_pwd,"+
                                "cu.pbx_host_outbound," +
                               "cu.is_active" +
                                  " from cc_users as cu left join departments as d on cu.department_id=d.id"+
                                  " left join cc_user_levels as cul on cu.level_id=cul.level_id" +                                          
                                  " where cu.id='" + userID + "'";
                    Conn.MyConn.Open();
                    using (Conn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(query, Conn.MyConn))
                    using (Conn.MyReader = Conn.MyCommand.ExecuteReader())
                    {
                        if (Conn.MyReader.HasRows)
                        {
                            while (Conn.MyReader.Read())
                            {
                                user.id = Conn.MyReader["id"].ToString();
                                user.username = Conn.MyReader["username"].ToString();
                                user.fullname = Conn.MyReader["fullname"].ToString();
                                user.email = Conn.MyReader["email"].ToString();
                                user.department = Conn.MyReader["departmennname"].ToString();
                                user.level = Conn.MyReader["level"].ToString();
                                user.inbound_ext = Conn.MyReader["inbound_ext"].ToString();
                                user.inbound_ext_pwd = Conn.MyReader["inbound_ext_pwd"].ToString();
                                user.pbx_inbound = Conn.MyReader["pbx_host"].ToString();
                                user.outbound_ext = Conn.MyReader["outbound_ext"].ToString();
                                user.outbound_ext_pwd = Conn.MyReader["outbound_ext_pwd"].ToString();
                                user.pbx_outbound = Conn.MyReader["pbx_host_outbound"].ToString();
                                user.isActive = Conn.MyReader["is_active"].ToString();
                            };
                        };
                    }

                }
                catch (Exception ex)
                {
                    Utility.Global.WriteLog(Utility.Global.GetCurrentMethod(ex));
                }
                finally { Conn.MyConn.Close(); }
                return user;
            }
        }
  
        public string GetPasswordUser(string username)
        {
            lock (Utility.Global.ThreadLockDao)
            {
                var result = "";
                try
                {
                    var queryString = "select password from cc_users where cc_users.username='" + username + "'";

                    Conn.MyConn.Open();

                    using (Conn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(queryString, Conn.MyConn))
                    using (Conn.MyReader = Conn.MyCommand.ExecuteReader())
                    {
                        if (Conn.MyReader.HasRows)
                        {
                            while (Conn.MyReader.Read())
                            {
                                result = Conn.MyReader[0].ToString();
                            };
                        };
                    }
                }
                catch (Exception ex)
                {
                    Utility.Global.WriteLog(Utility.Global.GetCurrentMethod(ex));
                }
                finally
                {
                    Conn.MyConn.Close();
                }
                return result;
            }
        }

        public string GetLogin_TotalDuration() //--1309
        {
            lock (Global.ThreadLockDao)
            {
                string RetVal = string.Empty;

                try
                {
                    string SQL = string.Empty;
                    //string loginid = Global.userAccount.id;
                    SQL += " UPDATE cc_log_login SET logout_time=NOW(), total_duration = TIMEDIFF(NOW(),login_temp)";
                    SQL += " WHERE DAY(NOW())=DAY(cc_log_login.login_time) AND id=" + Global.userAccount.id;
                    //SQL += " SELECT SEC_TO_TIME(SUM(TIME_TO_SEC(duration))) AS total ";
                    //SQL += " FROM cc_log_login"; 
                    //SQL += " WHERE user_id=" + Global.userAccount.id + " AND DATE(login_time)=CURRENT_DATE()";
                    Conn.MyConn.Open();
                    using (Conn.MyCommand = new MySqlCommand(SQL,Conn.MyConn))
                    {
                        using (Conn.MyReader = Conn.MyCommand.ExecuteReader())
                        {
                            if (Conn.MyReader.HasRows)
                            {
                                if (Conn.MyReader.Read())
                                {
                                    RetVal = Conn.MyReader["total_duration"].ToString();
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Global.WriteLog(Global.GetCurrentMethod(ex));
                }
                finally
                {
                    Conn.MyConn.Close();
                }

                return RetVal;
            }
        }

        public bool InsertLogin_TotalDuration()
        {
            lock (Global.ThreadLockDao)
            {
                int RetVal = 0;
                try
                {
                    //string totallogin = GetLogin_TotalDuration();

                    //string SQL = ""; // ini yang membuat create new total duration
                   // SQL += " UPDATE cc_log_login SET logout_time=NOW(), total_duration = ADDTIME(total_duration,'00:00:00') + TIMEDIFF(NOW(),login_temp)";
                   // SQL += " WHERE DAY(NOW())=DAY(cc_log_login.login_time) AND user_id=" + Global.userAccount.id;
                    string SQL = "UPDATE cc_log_login";
                    SQL += " SET logout_time=NOW()";
                    SQL += ", duration = TIMEDIFF (logout_time,login_temp)";
                    SQL += ", total_duration= IFNULL ((SELECT SEC_TO_TIME(SUM(TIME_TO_SEC(duration + total_duration)))),duration)";
                    SQL += "WHERE application_id=0 AND DAY(NOW())=DAY(cc_log_login.login_time) AND user_id=" + Global.userAccount.id;
                    //if null jika data total durasi null maka hasilnya pada duration, jika tidak null maka diisi SELECT SEC_TO_TIME(SUM(TIME_TO_SEC(duration + total_duration
                    Conn.MyConn.Open();
                    using (Conn.MyCommand = new MySqlCommand(SQL,Conn.MyConn))
                    {
                        RetVal = Conn.MyCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception Ex)
                {
                    Global.WriteLog(Global.GetCurrentMethod(Ex));
                }
                finally{
                    Conn.MyConn.Close();
                }

                return RetVal > 0;
            }
        }

     

        public DataTable getUser(int activityId, bool inbound)
        {
            lock (Global.ThreadLockDao)
            {
                DataTable dt = null;

                try
                {
                    string _level = inbound == false ? " cc_user_activities.activity_id=4" : " cc_user_activities.activity_id=2 AND cc_users.level_id=2";

                    string SQL = string.Empty;
                    SQL += " SELECT id, username AS Username,inbound_ext AS InboundExt, cc_user_activities.activity AS Activity,";
                    SQL += " TIMEDIFF(NOW(),time_activity)AS DurationActivity";
                    SQL += " FROM cc_users ";
                    SQL += " LEFT JOIN cc_user_activities ON cc_user_activities.activity_id = cc_users.activity_id";
                    //SQL += " WHERE " + _level;
                    SQL += " WHERE cc_users.activity_id IN (2,4) AND cc_users.id <> " + Global.userAccount.id;

                    Conn.MyConn.Open();
                    using (Conn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(SQL, Conn.MyConn))
                    {
                        using (Conn.MyAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter(Conn.MyCommand))
                        {
                            dt = new DataTable();
                            Conn.MyAdapter.Fill(dt);
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
                    Conn.MyAdapter.Dispose();

                }

                return dt;
            }
        }

        public bool checkIsUser(int id, int conditionActivity)
        {
            lock (Global.ThreadLockDao)
            {
                int RetVal = 0;

                try
                {
                    string SQL = string.Empty;

                    SQL += "SELECT COUNT(id) AS total FROM cc_users WHERE id=" + id + " AND activity_id=" + conditionActivity;

                    Conn.MyConn.Open();
                    using (Conn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(SQL, Conn.MyConn))
                    {
                        using (Conn.MyReader = Conn.MyCommand.ExecuteReader())
                        {
                            if (Conn.MyReader.HasRows)
                                if (Conn.MyReader.Read())
                                    RetVal = Convert.ToInt32(Conn.MyReader["total"]);
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

        public bool ResetPassword(string userId)
        {
            lock (Utility.Global.ThreadLockDao)
            {
                var result = false;
                try
                {
                    var queryString = " update cc_users set " +                                       
                                      " password=md5('kone1234')" +                                       
                                      " where id=@id";

                    Conn.MyConn.Open();

                    using (Conn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(queryString, Conn.MyConn))
                    {
                              
                        Conn.MyCommand.Parameters.AddWithValue("@id", userId);
                        result = (Conn.MyCommand.ExecuteNonQuery() == 1);
                    }

                }
                catch (Exception ex)
                { Utility.Global.WriteLog(Utility.Global.GetCurrentMethod(ex)); }
                finally
                {
                    Conn.MyConn.Close();
                }
                return result;
            }
        }
        public bool ChangePassword(string userId,string newPass)
        {
            lock (Utility.Global.ThreadLockDao)
            {
                var result = false;
                try
                {
                    var queryString = " update cc_users set " +
                                      " password=md5(@newpass)" +
                                      " where id=@id";

                    Conn.MyConn.Open();

                    using (Conn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(queryString, Conn.MyConn))
                    {

                        Conn.MyCommand.Parameters.AddWithValue("@id", userId);
                        Conn.MyCommand.Parameters.AddWithValue("@newpass", newPass);
                        result = (Conn.MyCommand.ExecuteNonQuery() == 1);
                    }

                }
                catch (Exception ex)
                { Utility.Global.WriteLog(Utility.Global.GetCurrentMethod(ex)); }
                finally
                {
                    Conn.MyConn.Close();
                }
                return result;
            }
        }
        public bool ChangeActivityUser(string userId,string activityId)
        {
            lock (Utility.Global.ThreadLockDao)
            {
                var result = false;
                try
                {
                    var queryString = " update cc_users set " +
                                      " time_activity=now()," +
                                      " activity_id=@activityid" +
                                      " where id=@id";

                    Conn.MyConn.Open();

                    using (Conn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(queryString, Conn.MyConn))
                    {

                        Conn.MyCommand.Parameters.AddWithValue("@id", userId);
                        Conn.MyCommand.Parameters.AddWithValue("@activityid", activityId);                      
                        result = (Conn.MyCommand.ExecuteNonQuery() == 1);
                    }

                }
                catch (Exception ex)
                { Utility.Global.WriteLog(Utility.Global.GetCurrentMethod(ex)); }
                finally
                {
                    Conn.MyConn.Close();
                }
                return result;
            }
        }

        public bool UnbookedUsers()
        {
            lock (Global.ThreadLockDao)
            {
                int RetVal = 0;
                try
                {
                    string SQL = "UPDATE cc_users";
                    SQL += " SET current_unique_id=null";
                    SQL += ", is_booked = 0";
                    SQL += ", activity_id = 2";

                    SQL += " WHERE id=" + Global.userAccount.id;
                    Conn.MyConn.Open();
                    using (Conn.MyCommand = new MySqlCommand(SQL, Conn.MyConn))
                    {
                        RetVal = Conn.MyCommand.ExecuteNonQuery();
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
    }
}
