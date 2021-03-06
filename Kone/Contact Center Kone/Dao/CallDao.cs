﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contact_Center_Kone.Entity;
using Contact_Center_Kone.Dao;
using Contact_Center_Kone.Utility;
using MySql.Data.MySqlClient;
using System.Collections.Specialized;

namespace Contact_Center_Kone.Dao
{
    public class CallDao
    {
        // instance
        public Paging myPaging = new Paging();
        private Utility.DbMyConnection myConn = new Utility.DbMyConnection();

        //var
        string orderBy = " order by cc.id desc";

        #region query
        //public string SqlFilter(string dateAwal, string dateAkhir, string directionId, string callTypeName, string callerTypeName, string callerTypeDetailName, string callStatus, string username, string phoneNo,string customerName,string serialNo)
        //{
        //    var isHavingInvoke = false;
        //    var result = SqlSelect()+" where date(cc.call_date) between '" + dateAwal +"' and '" +dateAkhir+"'";
        //    NameValueCollection nvc = new NameValueCollection();


        //    if (!string.IsNullOrEmpty(directionId)) { nvc.Add("cc.direction_id", directionId); }
        //    if (!string.IsNullOrEmpty(callerTypeName)) { nvc.Add("callinboundcallertype", callerTypeName); }
        //    if (!string.IsNullOrEmpty(callerTypeDetailName)) { nvc.Add("callertypedetail", callerTypeDetailName); }

        //    if (!string.IsNullOrEmpty(callTypeName))
        //    {
        //        if (callTypeName.ToUpper() == "INQUIRY")
        //        {
        //            nvc.Add("cc.is_inquiry", "2");
        //        }
        //        else if (callTypeName.ToUpper() == "COMPLAINT")
        //        {
        //            nvc.Add("cc.is_complain", "2");
        //        }
        //        else if (callTypeName.ToUpper() == "PROSPECT CUSTOMER")
        //        {
        //            nvc.Add("cc.is_prospectcustomer", "2");
        //        }
        //        else if (callTypeName.ToUpper() == "INFO")
        //        {
        //            nvc.Add("cc.is_request", "2");
        //        }
        //        else if (callTypeName.ToUpper() == "BLANK CALL")
        //        {
        //            nvc.Add("cc.is_blankcall", "2");
        //        }
        //        else if (callTypeName.ToUpper() == "WRONG NUMBER")
        //        {
        //            nvc.Add("cc.is_wrongno", "2");
        //        }
        //        else if (callTypeName.ToUpper() == "TEST CALL")
        //        {
        //            nvc.Add("cc.is_testcall", "2");
        //        }
        //        else if (callTypeName.ToUpper() == "OTHERS")
        //        {
        //            nvc.Add("cc.is_others", "2");
        //        }
        //        else if (callTypeName.ToUpper() == "PRANK CALL")
        //        {
        //            nvc.Add("cc.is_prankcall", "2");
        //        }
        //    }         
        //    if (!string.IsNullOrEmpty(username)) { nvc.Add("cu.username", username); }
        //    if (!string.IsNullOrEmpty(phoneNo)) { nvc.Add("cc.caller_number", phoneNo); }
        //    if (!string.IsNullOrEmpty(callStatus)) { nvc.Add("callstatus", callStatus); }
        //    if (!string.IsNullOrEmpty(serialNo)) { nvc.Add("cc.serial_no", serialNo); }
        //    if (!string.IsNullOrEmpty(customerName)) { nvc.Add("callername", customerName); }

        //    for (int i = 0; i < nvc.Count; i++)
        //    {

        //        if (nvc.GetKey(i) == "callername" || nvc.GetKey(i) == "callstatus" || nvc.GetKey(i) == "callinboundcallertype" || nvc.GetKey(i) == "callertypedetail")
        //        {
        //            if (!isHavingInvoke)
        //            {
        //                if (nvc.GetKey(i) == "callername" )
        //                {
        //                    result += " having " + nvc.GetKey(i) + " like '%" + nvc[i] + "%'";
        //                }
        //                else
        //                {
        //                    result += " having " + nvc.GetKey(i) + "='" + nvc[i] + "'";
        //                }
        //                isHavingInvoke = true;
        //            }
        //            else
        //            {
        //                if (nvc.GetKey(i) == "callername" )
        //                {
        //                    result += " and " + nvc.GetKey(i) + " like '%" + nvc[i] + "%'";
        //                }
        //                else
        //                {
        //                    result += " and " + nvc.GetKey(i) + "='" + nvc[i] + "'";
        //                }
        //            }
        //        }
        //        else if (nvc.GetKey(i) == "cc.caller_number" || nvc.GetKey(i) == "cc.serial_no")
        //        { result += " and " + nvc.GetKey(i) + " like '%" + nvc[i] + "%'"; }               
        //        else
        //        { result += " and " + nvc.GetKey(i) + "='" + nvc[i] + "'"; }
        //    }
        //  // System.Windows.Forms.MessageBox.Show(result);
        //    return result;  
        //}
        //public string SqlFilterCount(string dateAwal, string dateAkhir, string directionId, string callTypeName, string callerTypeName, string callerTypeDetailName, string callStatus, string username, string phoneNo, string customerName, string serialNo)
        //{
        //    var isHavingInvoke = false;
        //    var result = SqlSelectCount() + " where date(cc.call_date) between '" + dateAwal + "' and '" + dateAkhir+"'";
        //    NameValueCollection nvc = new NameValueCollection();

        //    if (!string.IsNullOrEmpty(directionId)) { nvc.Add("cc.direction_id", directionId); }
        //    if (!string.IsNullOrEmpty(callerTypeName)) { nvc.Add("callinboundcallertype", callerTypeName); }
        //    if (!string.IsNullOrEmpty(callerTypeDetailName)) { nvc.Add("callertypedetail", callerTypeDetailName); }

        //    if (!string.IsNullOrEmpty(callTypeName))
        //    {
        //        if (callTypeName.ToUpper() == "INQUIRY")
        //        {
        //            nvc.Add("cc.is_inquiry", "2");
        //        }
        //        else if (callTypeName.ToUpper() == "COMPLAINT")
        //        {
        //            nvc.Add("cc.is_complain", "2");
        //        }
        //        else if (callTypeName.ToUpper() == "PROSPECT CUSTOMER")
        //        {
        //            nvc.Add("cc.is_prospectcustomer", "2");
        //        }
        //        else if (callTypeName.ToUpper() == "INFO")
        //        {
        //            nvc.Add("cc.is_request", "2");
        //        }
        //        else if (callTypeName.ToUpper() == "BLANK CALL")
        //        {
        //            nvc.Add("cc.is_blankcall", "2");
        //        }
        //        else if (callTypeName.ToUpper() == "WRONG NUMBER")
        //        {
        //            nvc.Add("cc.is_wrongno", "2");
        //        }
        //        else if (callTypeName.ToUpper() == "TEST CALL")
        //        {
        //            nvc.Add("cc.is_testcall", "2");
        //        }
        //        else if (callTypeName.ToUpper() == "OTHERS")
        //        {
        //            nvc.Add("cc.is_others", "2");
        //        }
        //        else if (callTypeName.ToUpper() == "PRANK CALL")
        //        {
        //            nvc.Add("cc.is_prankcall", "2");
        //        }
        //    }
        //    if (!string.IsNullOrEmpty(username)) { nvc.Add("cu.username", username); }
        //    if (!string.IsNullOrEmpty(phoneNo)) { nvc.Add("cc.caller_number", phoneNo); }
        //    if (!string.IsNullOrEmpty(callStatus)) { nvc.Add("callstatus", callStatus); }
        //    if (!string.IsNullOrEmpty(serialNo)) { nvc.Add("cc.serial_no", serialNo); }
        //    if (!string.IsNullOrEmpty(customerName)) { nvc.Add("callername", customerName); }

        //    for (int i = 0; i < nvc.Count; i++)
        //    {

        //        if (nvc.GetKey(i) == "callername" || nvc.GetKey(i) == "callstatus" || nvc.GetKey(i) == "callinboundcallertype" || nvc.GetKey(i) == "callertypedetail")
        //        {
        //            if (!isHavingInvoke)
        //            {
        //                if (nvc.GetKey(i) == "callername")
        //                {
        //                    result += " having " + nvc.GetKey(i) + " like '%" + nvc[i] + "%'";
        //                }
        //                else
        //                {
        //                    result += " having " + nvc.GetKey(i) + "='" + nvc[i] + "'";
        //                }
        //                isHavingInvoke = true;
        //            }
        //            else
        //            {
        //                if (nvc.GetKey(i) == "callername")
        //                {
        //                    result += " and " + nvc.GetKey(i) + " like '%" + nvc[i] + "%'";
        //                }
        //                else
        //                {
        //                    result += " and " + nvc.GetKey(i) + "='" + nvc[i] + "'";
        //                }
        //            }
        //        }
        //        else if (nvc.GetKey(i) == "cc.caller_number" || nvc.GetKey(i) == "cc.serial_no")
        //        { result += " and " + nvc.GetKey(i) + " like '%" + nvc[i] + "%'"; }
        //        else
        //        { result += " and " + nvc.GetKey(i) + "='" + nvc[i] + "'"; }
        //    }
        //    // System.Windows.Forms.MessageBox.Show(result);
        //    return result; 
        //}
        public string SqlFilter(string dateAwal, string dateAkhir, string directionId, string callTypeName, string callerTypeName,  string callStatus, string username, string phoneNo, string customerName, string serialNo)
        {
            var isHavingInvoke = false;
            var result = SqlSelect() + " where date(cc.call_date) between '" + dateAwal + "' and '" + dateAkhir + "'";
            NameValueCollection nvc = new NameValueCollection();


            if (!string.IsNullOrEmpty(directionId)) { nvc.Add("cc.direction_id", directionId); }
            if (!string.IsNullOrEmpty(callerTypeName)) { nvc.Add("callinboundcallertype", callerTypeName); }
            //if (!string.IsNullOrEmpty(callerTypeDetailName)) { nvc.Add("callertypedetail", callerTypeDetailName); }

            if (!string.IsNullOrEmpty(callTypeName))
            {
                if (callTypeName.ToUpper() == "INQUIRY")
                {
                    nvc.Add("cc.is_inquiry", "2");
                }
                else if (callTypeName.ToUpper() == "COMPLAINT")
                {
                    nvc.Add("cc.is_complain", "2");
                }
                //else if (callTypeName.ToUpper() == "PROSPECT CUSTOMER")
                //{
                //    nvc.Add("cc.is_prospectcustomer", "2");
                //}
                else if (callTypeName.ToUpper() == "FOLLOW-UP COMPLAINT")
                {
                    nvc.Add("cc.is_request", "2");
                }
                else if (callTypeName.ToUpper() == "BLANK CALL")
                {
                    nvc.Add("cc.is_blankcall", "2");
                }
                else if (callTypeName.ToUpper() == "WRONG NUMBER")
                {
                    nvc.Add("cc.is_wrongno", "2");
                }
                else if (callTypeName.ToUpper() == "TEST CALL")
                {
                    nvc.Add("cc.is_testcall", "2");
                }
                else if (callTypeName.ToUpper() == "OTHERS")
                {
                    nvc.Add("cc.is_others", "2");
                }
                else if (callTypeName.ToUpper() == "PRANK CALL")
                {
                    nvc.Add("cc.is_prankcall", "2");
                }
            }
            if (!string.IsNullOrEmpty(username)) { nvc.Add("cu.username", username); }
            if (!string.IsNullOrEmpty(phoneNo)) { nvc.Add("cc.caller_number", phoneNo); }
            if (!string.IsNullOrEmpty(callStatus)) { nvc.Add("callstatus", callStatus); }
            if (!string.IsNullOrEmpty(serialNo)) { nvc.Add("cc.serial_no", serialNo); }
            if (!string.IsNullOrEmpty(customerName)) { nvc.Add("callername", customerName); }

            for (int i = 0; i < nvc.Count; i++)
            {

                if (nvc.GetKey(i) == "callername" || nvc.GetKey(i) == "callstatus" || nvc.GetKey(i) == "callinboundcallertype" )
                {
                    if (!isHavingInvoke)
                    {
                        if (nvc.GetKey(i) == "callername")
                        {
                            result += " having " + nvc.GetKey(i) + " like '%" + nvc[i] + "%'";
                        }
                        else
                        {
                            result += " having " + nvc.GetKey(i) + "='" + nvc[i] + "'";
                        }
                        isHavingInvoke = true;
                    }
                    else
                    {
                        if (nvc.GetKey(i) == "callername")
                        {
                            result += " and " + nvc.GetKey(i) + " like '%" + nvc[i] + "%'";
                        }
                        else
                        {
                            result += " and " + nvc.GetKey(i) + "='" + nvc[i] + "'";
                        }
                    }
                }
                else if (nvc.GetKey(i) == "cc.caller_number" || nvc.GetKey(i) == "cc.serial_no")
                { result += " and " + nvc.GetKey(i) + " like '%" + nvc[i] + "%'"; }
                else
                { result += " and " + nvc.GetKey(i) + "='" + nvc[i] + "'"; }
            }
            // System.Windows.Forms.MessageBox.Show(result);
            return result;
        }
        public string SqlFilterCount(string dateAwal, string dateAkhir, string directionId, string callTypeName, string callerTypeName,  string callStatus, string username, string phoneNo, string customerName, string serialNo)
        {
            var isHavingInvoke = false;
            var result = SqlSelectCount() + " where date(cc.call_date) between '" + dateAwal + "' and '" + dateAkhir + "'";
            NameValueCollection nvc = new NameValueCollection();

            if (!string.IsNullOrEmpty(directionId)) { nvc.Add("cc.direction_id", directionId); }
            if (!string.IsNullOrEmpty(callerTypeName)) { nvc.Add("callinboundcallertype", callerTypeName); }
        //    if (!string.IsNullOrEmpty(callerTypeDetailName)) { nvc.Add("callertypedetail", callerTypeDetailName); }

            if (!string.IsNullOrEmpty(callTypeName))
            {
                if (callTypeName.ToUpper() == "INQUIRY")
                {
                    nvc.Add("cc.is_inquiry", "2");
                }
                else if (callTypeName.ToUpper() == "COMPLAINT")
                {
                    nvc.Add("cc.is_complain", "2");
                }
                //else if (callTypeName.ToUpper() == "PROSPECT CUSTOMER")
                //{
                //    nvc.Add("cc.is_prospectcustomer", "2");
                //}
                else if (callTypeName.ToUpper() == "FOLLOW-UP COMPLAINT")
                {
                    nvc.Add("cc.is_request", "2");
                }
                else if (callTypeName.ToUpper() == "BLANK CALL")
                {
                    nvc.Add("cc.is_blankcall", "2");
                }
                else if (callTypeName.ToUpper() == "WRONG NUMBER")
                {
                    nvc.Add("cc.is_wrongno", "2");
                }
                else if (callTypeName.ToUpper() == "TEST CALL")
                {
                    nvc.Add("cc.is_testcall", "2");
                }
                else if (callTypeName.ToUpper() == "OTHERS")
                {
                    nvc.Add("cc.is_others", "2");
                }
                else if (callTypeName.ToUpper() == "PRANK CALL")
                {
                    nvc.Add("cc.is_prankcall", "2");
                }
            }
            if (!string.IsNullOrEmpty(username)) { nvc.Add("cu.username", username); }
            if (!string.IsNullOrEmpty(phoneNo)) { nvc.Add("cc.caller_number", phoneNo); }
            if (!string.IsNullOrEmpty(callStatus)) { nvc.Add("callstatus", callStatus); }
            if (!string.IsNullOrEmpty(serialNo)) { nvc.Add("cc.serial_no", serialNo); }
            if (!string.IsNullOrEmpty(customerName)) { nvc.Add("callername", customerName); }

            for (int i = 0; i < nvc.Count; i++)
            {

                if (nvc.GetKey(i) == "callername" || nvc.GetKey(i) == "callstatus" || nvc.GetKey(i) == "callinboundcallertype" )
                {
                    if (!isHavingInvoke)
                    {
                        if (nvc.GetKey(i) == "callername")
                        {
                            result += " having " + nvc.GetKey(i) + " like '%" + nvc[i] + "%'";
                        }
                        else
                        {
                            result += " having " + nvc.GetKey(i) + "='" + nvc[i] + "'";
                        }
                        isHavingInvoke = true;
                    }
                    else
                    {
                        if (nvc.GetKey(i) == "callername")
                        {
                            result += " and " + nvc.GetKey(i) + " like '%" + nvc[i] + "%'";
                        }
                        else
                        {
                            result += " and " + nvc.GetKey(i) + "='" + nvc[i] + "'";
                        }
                    }
                }
                else if (nvc.GetKey(i) == "cc.caller_number" || nvc.GetKey(i) == "cc.serial_no")
                { result += " and " + nvc.GetKey(i) + " like '%" + nvc[i] + "%'"; }
                else
                { result += " and " + nvc.GetKey(i) + "='" + nvc[i] + "'"; }
            }
            // System.Windows.Forms.MessageBox.Show(result);
            return result;
        }
        public string SqlSelect()
        {
            return "select  "+
                                   " cc.id, "+
                                   " (select tickets.ticket_no from tickets left join cc_ticket_tags on cc_ticket_tags.ticket_id=tickets.id where cc_ticket_tags.media_id=cc.id and (cc_ticket_tags.source_media_id=4 or cc_ticket_tags.source_media_id=5)) as ticketNo," +
                                   " cc.call_date,  "+
                                   " cc.customer_name as 'callername'," +                                  
                                   " cu.username,  "+
                                   " cd.direction, "+ 
                                   " if(cd.id=1,cis.`status`,cos.`status`) as 'callstatus', "+ 
                                   " if(cd.id=1, cict.`type`, coct.`type`) as 'callinboundcallertype', "+
                                   " cic.name as 'callertypedetail', " +                                 
                                   " if(cd.id=1,null,cosd.status_detail) as 'outbondstatusdetail', "+                                    	
                                   " cs.shift,  "+
                                   " ctr.name as transferReason,  " +  
                                
                                   " cc.is_testcall, "+  
                                   " cc.is_blankcall, "+
                                   " cc.is_prankcall, " +  
                                   " cc.is_inquiry,  "+
                                   " cc.is_complain,  "+ 
                                   " cc.is_request,  "+ 
                                   " cc.is_wrongno,  "+ 
                                   " cc.is_prospectcustomer,"+
                                   " cc.is_others," +
                                   " cc.unique_id," +  //15-11
                                   " cc.model_id, " +
                                   " cc.tv_size_id, " +
                                   " cc.address, " +
                                   " cc.building, " +
                                   " cc.city_id,  " +
                                   " cc.email,  " +
                                   " cc.telp,  " +
                                   " cc.hp,  " +
                                   " cc.serial_no,  " +
                                   " cc.purchase_date,  " +
                                   " cc.problem_date,  " +
                                   " cc.symptom_code_id,  " +
                                   " cc.warranty_status_id,  " +
                                   " cc.product_location_id,  " +

                                   " cc.hostaddr,  "+
                                   " cc.hostname,  "+
                                   " cc.extension,  "+
                                   " cc.duration,  "+
                                   " cc.abandon,  "+
                                   " cc.delay,  "+
                                   " cc.busy,  "+
                                   " cc.caller_number,  "+
                                   " cc.note,         "+                           
                                   " cc.voice_file   "+
                                    
                     " from cc_calls as cc left join "+
                     " cc_users as cu on cc.user_id=cu.id  "+
                     " left join cc_directions as cd on cc.direction_id=cd.id  "+
                     " left join cc_inbound_statuses as cis on cc.call_status_id=cis.id "+
                     " left join cc_caller_types as cict on cc.caller_type_id=cict.id  "+
                     " left join cc_caller_types as coct on cc.caller_type_id=coct.id " +
                     " left join cc_outbound_statuses as cos on cc.call_status_id=cos.id  "+
                     " left join cc_outbound_status_details as cosd on cc.call_status_detail_id=cosd.id  "+
                     " left join cc_caller_type_detail as cic on cc.caller_type_detail_id=cic.id  " +
                     
                     " left join cc_transfer_reasons as ctr on cc.transfer_reason_id=ctr.id  " + 
                     " left join cc_shifts as cs on cc.shift_id=cs.id";   
        }
        public string SqlSelectCount()
        {
            return "select count(cc.id) " +

                     " from cc_calls as cc left join " +
                     " cc_users as cu on cc.user_id=cu.id  " +
                     " left join cc_directions as cd on cc.direction_id=cd.id  " +
                     " left join cc_inbound_statuses as cis on cc.call_status_id=cis.id " +
                     " left join cc_caller_types as cict on cc.caller_type_id=cict.id  " +
                     " left join cc_caller_types as coct on cc.caller_type_id=coct.id " +
                     " left join cc_caller_type_detail as cic on cc.caller_type_detail_id=cic.id  " +  
                     " left join cc_outbound_statuses as cos on cc.call_status_id=cos.id  " +
                     " left join cc_outbound_status_details as cosd on cc.call_status_detail_id=cosd.id  " +
                     " left join cc_transfer_reasons as ctr on cc.transfer_reason_id=ctr.id  " + 
                //" left join cc_ticket_tags as ctt on cc.id=ctt
                     " left join cc_shifts as cs on cc.shift_id=cs.id";   
        }
        #endregion
        public List<Entity.Call> GetAll()
        {
            lock (Global.ThreadLockDao)
            {
            var calls = new List<Entity.Call>();
            try
            {          	 		 
                myConn.MyConn.Open();
                using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(myPaging.SqlLoaddata + orderBy + " LIMIT " + myPaging.Startindex + "," + myPaging.BatasData, myConn.MyConn))
                   // System.Windows.Forms.MessageBox.Show(myPaging.SqlLoaddata + orderBy + " LIMIT " + myPaging.Startindex + "," + myPaging.BatasData);
                using (myConn.MyReader = myConn.MyCommand.ExecuteReader())
                {
                    if (myConn.MyReader.HasRows)
                    {
                        while (myConn.MyReader.Read())
                        {
                            calls.Add(new Entity.Call()
                            {
                                id = Convert.ToInt32(myConn.MyReader["id"]),
                                callDate = Convert.ToDateTime(myConn.MyReader["call_date"]).ToString("dd/MM/yyyy HH:mm:ss"),
                                callerName = myConn.MyReader["callername"].ToString(),                            
                                username = myConn.MyReader["username"].ToString(),
                                directionName = myConn.MyReader["direction"].ToString(),
                                inboundStatusName = myConn.MyReader["callstatus"].ToString(),
                                CallerTypeName = myConn.MyReader["callinboundcallertype"].ToString(),
                                callerTypeDetailName = myConn.MyReader["callertypedetail"].ToString(),
                                outbondStatusDetailName = myConn.MyReader["outbondstatusdetail"].ToString(),                              
                                shiftName = myConn.MyReader["shift"].ToString(),
                                transferReason = myConn.MyReader["transferReason"].ToString(),
                                isTestCall = myConn.MyReader["is_testcall"].ToString() == "2" ? "Yes" : "No",
                                isBlankCall = myConn.MyReader["is_blankcall"].ToString() == "2" ? "Yes" : "No",
                                isPrankCall = myConn.MyReader["is_prankcall"].ToString() == "2" ? "Yes" : "No",
                                isWrongNumber = myConn.MyReader["is_wrongno"].ToString() == "2" ? "Yes" : "No",
                                isInquiry = myConn.MyReader["is_inquiry"].ToString() == "2" ? "Yes" : "No",
                                isComplaint = myConn.MyReader["is_complain"].ToString() == "2" ? "Yes" : "No",
                                isRequest = myConn.MyReader["is_request"].ToString() == "2" ? "Yes" : "No",
                                //isProspectCustomer = myConn.MyReader["is_prospectcustomer"].ToString() == "2" ? "Yes" : "No",
                                isOthers = myConn.MyReader["is_others"].ToString() == "2" ? "Yes" : "No",
                                unique_id = myConn.MyReader["unique_id"].ToString(),//15-11
                                hostAddress = myConn.MyReader["hostaddr"].ToString(),
                                hostName = myConn.MyReader["hostname"].ToString(),
                                extension = myConn.MyReader["extension"].ToString(),
                                duration = myConn.MyReader["duration"].ToString(),
                                abandon = myConn.MyReader["abandon"].ToString(),
                                delay = myConn.MyReader["delay"].ToString(),
                                busy = myConn.MyReader["busy"].ToString(),
                                callerNumber = myConn.MyReader["caller_number"].ToString(),
                                note = myConn.MyReader["note"].ToString(),                               
                                voiceFile = myConn.MyReader["voice_file"].ToString(),
                                ticketNo = myConn.MyReader["ticketNo"].ToString(), 
                               
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
            return calls;
        }
        }
        public List<Entity.Call> GetAll(string phoneNo1,string phoneNo2,string phoneNo3,string phoneNo4="")
        {
            lock (Global.ThreadLockDao)
            {
            var calls = new List<Entity.Call>();
            try
            {
              
                myConn.MyConn.Open();

                string templateInClause = "(";
                templateInClause += string.IsNullOrEmpty(phoneNo1) ? "null," : "'" + phoneNo1 + "',";
                templateInClause += string.IsNullOrEmpty(phoneNo2) ? "null," : "'" + phoneNo2 + "',";
                templateInClause += string.IsNullOrEmpty(phoneNo3) ? "null" : "'" + phoneNo3 + "'";
                templateInClause += ")";

                var sqlString = SqlSelect() +
                   " where (cc.caller_number in " + templateInClause + ") or (cc.telp in " + templateInClause + ") or (cc.hp in " + templateInClause + ")" + orderBy + " LIMIT " + myPaging.Startindex + "," + myPaging.BatasData;


                using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(sqlString, myConn.MyConn))                 
                using (myConn.MyReader = myConn.MyCommand.ExecuteReader())
                {
                    if (myConn.MyReader.HasRows)
                    {
                        while (myConn.MyReader.Read())
                        {
                            calls.Add(new Entity.Call()
                            {
                                id = Convert.ToInt32(myConn.MyReader["id"]),
                                callDate = Convert.ToDateTime(myConn.MyReader["call_date"]).ToString("dd/MM/yyyy HH:mm:ss"),
                                callerName = myConn.MyReader["callername"].ToString(),
                                username = myConn.MyReader["username"].ToString(),
                                directionName = myConn.MyReader["direction"].ToString(),
                                inboundStatusName = myConn.MyReader["callstatus"].ToString(),
                                CallerTypeName = myConn.MyReader["callinboundcallertype"].ToString(),
                                callerTypeDetailName = myConn.MyReader["callertypedetail"].ToString(),
                                outbondStatusDetailName = myConn.MyReader["outbondstatusdetail"].ToString(),
                                shiftName = myConn.MyReader["shift"].ToString(),
                                transferReason = myConn.MyReader["transferReason"].ToString(),
                                isTestCall = myConn.MyReader["is_testcall"].ToString() == "2" ? "Yes" : "No",
                                isBlankCall = myConn.MyReader["is_blankcall"].ToString() == "2" ? "Yes" : "No",
                                isWrongNumber = myConn.MyReader["is_wrongno"].ToString() == "2" ? "Yes" : "No",
                                isInquiry = myConn.MyReader["is_inquiry"].ToString() == "2" ? "Yes" : "No",
                                isComplaint = myConn.MyReader["is_complain"].ToString() == "2" ? "Yes" : "No",
                                isRequest = myConn.MyReader["is_request"].ToString() == "2" ? "Yes" : "No",
                                isProspectCustomer = myConn.MyReader["is_prospectcustomer"].ToString() == "2" ? "Yes" : "No",
                                isOthers = myConn.MyReader["is_others"].ToString() == "2" ? "Yes" : "No",
                                hostAddress = myConn.MyReader["hostaddr"].ToString(),
                                hostName = myConn.MyReader["hostname"].ToString(),
                                extension = myConn.MyReader["extension"].ToString(),
                                duration = myConn.MyReader["duration"].ToString(),
                                abandon = myConn.MyReader["abandon"].ToString(),
                                delay = myConn.MyReader["delay"].ToString(),
                                busy = myConn.MyReader["busy"].ToString(),
                                callerNumber = myConn.MyReader["caller_number"].ToString(),
                                note = myConn.MyReader["note"].ToString(),
                                voiceFile = myConn.MyReader["voice_file"].ToString(),
                                ticketNo = myConn.MyReader["ticketNo"].ToString(), 
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
            return calls;
        }
        }
        //public List<Entity.Call> GetAll(string phoneNo1,string phoneNo2,string phoneNo3)
        //{
        //    lock (Global.ThreadLockDao)
        //    {
        //        var calls = new List<Entity.Call>();
        //        try
        //        {

        //            myConn.MyConn.Open();
        //            using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(SqlSelect() + " where cc.caller_number='" + phoneNo1 + "' or cc.caller_number='" + phoneNo2 + "' or cc.caller_number='" + phoneNo3 + "' " + orderBy + " LIMIT " + myPaging.Startindex + "," + myPaging.BatasData, myConn.MyConn))
        //            using (myConn.MyReader = myConn.MyCommand.ExecuteReader())
        //            {
        //                if (myConn.MyReader.HasRows)
        //                {
        //                    while (myConn.MyReader.Read())
        //                    {
        //                        calls.Add(new Entity.Call()
        //                        {
        //                            id = Convert.ToInt32(myConn.MyReader["id"]),
        //                            callDate = Convert.ToDateTime(myConn.MyReader["call_date"]).ToString("dd/MM/yyyy HH:mm:ss"),
        //                            callerName = myConn.MyReader["callername"].ToString(),
        //                            username = myConn.MyReader["username"].ToString(),
        //                            directionName = myConn.MyReader["direction"].ToString(),
        //                            inboundStatusName = myConn.MyReader["callstatus"].ToString(),
        //                            CallerTypeName = myConn.MyReader["callinboundcallertype"].ToString(),
        //                            outbondStatusDetailName = myConn.MyReader["outbondstatusdetail"].ToString(),
        //                            shiftName = myConn.MyReader["shift"].ToString(),
        //                            isTestCall = myConn.MyReader["is_testcall"].ToString() == "1" ? "No" : "Yes",
        //                            isBlankCall = myConn.MyReader["is_blankcall"].ToString() == "1" ? "No" : "Yes",
        //                            isWrongNumber = myConn.MyReader["is_wrongno"].ToString() == "1" ? "No" : "Yes",
        //                            isInquiry = myConn.MyReader["is_inquiry"].ToString() == "1" ? "No" : "Yes",
        //                            isComplaint = myConn.MyReader["is_complaint"].ToString() == "1" ? "No" : "Yes",
        //                            isRequest = myConn.MyReader["is_order"].ToString() == "1" ? "No" : "Yes",
        //                            isProspectCustomer = myConn.MyReader["is_service"].ToString() == "1" ? "No" : "Yes",
        //                            isOthers = myConn.MyReader["is_others"].ToString() == "2" ? "Yes" : "No",
        //                            hostAddress = myConn.MyReader["hostaddr"].ToString(),
        //                            hostName = myConn.MyReader["hostname"].ToString(),
        //                            extension = myConn.MyReader["extension"].ToString(),
        //                            duration = myConn.MyReader["duration"].ToString(),
        //                            abandon = myConn.MyReader["abandon"].ToString(),
        //                            delay = myConn.MyReader["delay"].ToString(),
        //                            busy = myConn.MyReader["busy"].ToString(),
        //                            callerNumber = myConn.MyReader["caller_number"].ToString(),
        //                            note = myConn.MyReader["note"].ToString(),
        //                            voiceFile = myConn.MyReader["voice_file"].ToString(), 
        //                        });
        //                    };
        //                };
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            Utility.Global.WriteLog(Utility.Global.GetCurrentMethod(ex));
        //        }
        //        finally { myConn.MyConn.Close(); }
        //        return calls;
        //    }
        //}
        public Entity.Call GetById(string callId)
        {
            lock (Global.ThreadLockDao)
            {
            var call = new Entity.Call();
            try
            {

                myConn.MyConn.Open();
                using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(SqlSelect() + " where cc.id='" + callId + "'" + orderBy, myConn.MyConn))
                using (myConn.MyReader = myConn.MyCommand.ExecuteReader())
                {
                    if (myConn.MyReader.HasRows)
                    {
                        while (myConn.MyReader.Read())
                        {
                            
                                call.id = Convert.ToInt32(myConn.MyReader["id"]);
                                call.callDate = myConn.MyReader["call_date"].ToString();
                                call.callerName = myConn.MyReader["callername"].ToString();                               
                                call.username = myConn.MyReader["username"].ToString();
                                call.directionName = myConn.MyReader["direction"].ToString();
                                call.inboundStatusName = myConn.MyReader["callstatus"].ToString();
                                call.CallerTypeName = myConn.MyReader["callinboundcallertype"].ToString();
                                call.callerTypeDetailName = myConn.MyReader["callertypedetail"].ToString();
                                call.outbondStatusDetailName = myConn.MyReader["outbondstatusdetail"].ToString();
                                call.shiftName = myConn.MyReader["shift"].ToString();                              
                                call.isTestCall = myConn.MyReader["is_testcall"].ToString() == "1" ? "No" : "Yes";
                                call.isBlankCall = myConn.MyReader["is_blankcall"].ToString() == "1" ? "No" : "Yes";
                                call.isWrongNumber = myConn.MyReader["is_wrongno"].ToString() == "1" ? "No" : "Yes";
                                call.isPrankCall = myConn.MyReader["is_prankcall"].ToString() == "1" ? "No" : "Yes";
                                call.isInquiry = myConn.MyReader["is_inquiry"].ToString() == "1" ? "No" : "Yes";
                                call.isComplaint = myConn.MyReader["is_complain"].ToString() == "1" ? "No" : "Yes";
                                call.isRequest = myConn.MyReader["is_request"].ToString() == "1" ? "No" : "Yes";
                                //call.isProspectCustomer = myConn.MyReader["is_prospectcustomer"].ToString() == "1" ? "No" : "Yes";
                                call.isOthers = myConn.MyReader["is_others"].ToString() == "2" ? "Yes" : "No";
                                call.modelId = myConn.MyReader["model_id"].ToString();
                                call.city = myConn.MyReader["city_id"].ToString();
                                call.email = myConn.MyReader["email"].ToString();
                                call.address = myConn.MyReader["address"].ToString();
                                call.building = myConn.MyReader["building"].ToString();
                                //call.tvSizeId = myConn.MyReader["tv_size_id"].ToString();
                                call.telephone = myConn.MyReader["telp"].ToString();
                                call.handphone = myConn.MyReader["hp"].ToString();
                                //call.serialNo = myConn.MyReader["serial_no"].ToString();
                                //call.purchaseDate = myConn.MyReader["purchase_date"].ToString();
                                //call.problemDate = myConn.MyReader["problem_date"].ToString();
                                //call.symptomCodeId = myConn.MyReader["symptom_code_id"].ToString();
                                //call.warrantyStatusId = myConn.MyReader["warranty_status_id"].ToString();
                                //call.productLocationId = myConn.MyReader["product_location_id"].ToString();
                                call.hostAddress = myConn.MyReader["hostaddr"].ToString();
                                call.hostName = myConn.MyReader["hostname"].ToString();
                                call.extension = myConn.MyReader["extension"].ToString();
                                call.duration = myConn.MyReader["duration"].ToString();
                                call.abandon = myConn.MyReader["abandon"].ToString();
                                call.delay = myConn.MyReader["delay"].ToString();
                                call.busy = myConn.MyReader["busy"].ToString();
                                call.callerNumber = myConn.MyReader["caller_number"].ToString();
                                call.note = myConn.MyReader["note"].ToString();                               
                                call.voiceFile = myConn.MyReader["voice_file"].ToString();
                                call.ticketNo = myConn.MyReader["ticketNo"].ToString();
                        };
                    };
                }

            }
            catch (Exception ex)
            {
                Utility.Global.WriteLog(Utility.Global.GetCurrentMethod(ex));
            }
            finally { myConn.MyConn.Close(); }
            return call;
        }
        }

        public bool Insert(Entity.Call myCall,out string lastId)
        {
            lock (Global.ThreadLockDao)
            {

            var result = false;
            lastId = "";
            try
            {
                var queryString = "insert into cc_calls set " +
                                    "call_date=@calldate,"  +                                                                    
                                    "user_id=@userid," +
                                    "direction_id=@directionid," +
                                    "call_status_id=@callstatusid," +
                                    "caller_type_id=@inboundcallertypeid," +
                                    "caller_type_detail_id=@categoryid," +  
                                    "call_status_detail_id=@callstatusdetailid," +
                                    "shift_id=@shiftid," +
                                    "unique_id=@unique_id," +  //15-11
                                    "is_testcall=@istestcall," +
                                    "is_prankcall=@isprankcall," +
                                    "is_blankcall=@isblankcall," +
                                    "is_wrongno=@iswrongno," +
                                    "is_inquiry=@isinquiry," +
                                    "is_complain=@iscomplaint," +
                                    "is_request=@isrequest," +
                                    "is_prospectcustomer=@isprospectcustomer," +
                                    "is_others=@isother," +

                                    "model_id=@modelid,"+
                                    "address=@address,"+
                                    "tv_size_id=@tvsizeid,"+
                                    "telp=@telp,"+
                                    "hp=@handphone,"+
                                    "city_id=@city,"+
                                    "email=@email," +
                                    "serial_no=@serialno," +
                                    "purchase_date=@purchasedate," +
                                    "problem_date=@problemdate," +
                                    "symptom_code_id=@symptomcodeid," +
                                    "warranty_status_id=@warrantystatusid," +
                                    "product_location_id=@productlocationid," +

                                    "hostaddr=@hostaddress," +
                                    "hostname=@hostname," +
                                    "extension=@extension," +
                                    "duration=@duration," +
                                    "abandon=@abandon," +
                                    "delay=@delay," +
                                    "busy=@busy," +
                                    "customer_name=@callername," +
                                    "note=@note," +
                                 
                                    "caller_number=@callernumber," +
                                    "voice_file=@voiceFile;";

                queryString += "Select last_insert_id();";
                //System.Windows.Forms.MessageBox.Show(queryString);
                myConn.MyConn.Open();

                using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(queryString, myConn.MyConn))
                {
                    myConn.MyCommand.Parameters.AddWithValue("@calldate", myCall.callDate);
                      
                    myConn.MyCommand.Parameters.AddWithValue("@userid", myCall.user.id);
                    myConn.MyCommand.Parameters.AddWithValue("@directionid", myCall.direction.id);
                    myConn.MyCommand.Parameters.AddWithValue("@callstatusid", myCall.inboundStatus != null ? myCall.inboundStatus.id : null);
                    myConn.MyCommand.Parameters.AddWithValue("@inboundcallertypeid", myCall.inboundCallerType != null ? myCall.inboundCallerType.id : null);
                    myConn.MyCommand.Parameters.AddWithValue("@categoryid", myCall.callerTypeDetail.id != null ? myCall.callerTypeDetail.id : null);
                    myConn.MyCommand.Parameters.AddWithValue("@callstatusdetailid", myCall.outbondStatusDetailName != null?myCall.outbondStatusDetailName:null);
                                                         
                    myConn.MyCommand.Parameters.AddWithValue("@shiftid", myCall.shift.id);
                    myConn.MyCommand.Parameters.AddWithValue("@unique_id", myCall.unique_id);//15-11

                        //  myConn.MyCommand.Parameters.AddWithValue("@paymentmethodid", myCall.paymentMethod != null ? myCall.paymentMethod.id.ToString() : null);
                    myConn.MyCommand.Parameters.AddWithValue("@istestcall", myCall.isTestCall);
                    myConn.MyCommand.Parameters.AddWithValue("@isprankcall", myCall.isPrankCall);
                    myConn.MyCommand.Parameters.AddWithValue("@isblankcall", myCall.isBlankCall);
                    myConn.MyCommand.Parameters.AddWithValue("@iswrongno", myCall.isWrongNumber);
                    myConn.MyCommand.Parameters.AddWithValue("@isinquiry", myCall.isInquiry);
                    myConn.MyCommand.Parameters.AddWithValue("@iscomplaint", myCall.isComplaint);
                    myConn.MyCommand.Parameters.AddWithValue("@isrequest", myCall.isRequest);
                    myConn.MyCommand.Parameters.AddWithValue("@isprospectcustomer", myCall.isProspectCustomer);
                    myConn.MyCommand.Parameters.AddWithValue("@isother", myCall.isOthers);

                    myConn.MyCommand.Parameters.AddWithValue("@modelid", myCall.modelId);
                    myConn.MyCommand.Parameters.AddWithValue("@address", myCall.address);
                    myConn.MyCommand.Parameters.AddWithValue("@tvsizeid", myCall.tvSizeId);
                    myConn.MyCommand.Parameters.AddWithValue("@telp", myCall.telephone);
                    myConn.MyCommand.Parameters.AddWithValue("@handphone", myCall.handphone);
                    myConn.MyCommand.Parameters.AddWithValue("@city", myCall.city);
                    myConn.MyCommand.Parameters.AddWithValue("@email", myCall.email);
                    myConn.MyCommand.Parameters.AddWithValue("@serialno", myCall.serialNo);
                    myConn.MyCommand.Parameters.AddWithValue("@purchasedate", myCall.purchaseDate);
                    myConn.MyCommand.Parameters.AddWithValue("@problemdate", myCall.problemDate);
                    myConn.MyCommand.Parameters.AddWithValue("@symptomcodeid", myCall.symptomCodeId);
                    myConn.MyCommand.Parameters.AddWithValue("@warrantystatusid", myCall.warrantyStatusId);
                    myConn.MyCommand.Parameters.AddWithValue("@productlocationid", myCall.productLocationId);
                    //myConn.MyCommand.Parameters.AddWithValue("@isothers", myCall.isOthers);
                   
                    myConn.MyCommand.Parameters.AddWithValue("@hostaddress", myCall.hostAddress);
                    myConn.MyCommand.Parameters.AddWithValue("@hostname", myCall.hostName);
                    myConn.MyCommand.Parameters.AddWithValue("@extension", myCall.extension);
                    myConn.MyCommand.Parameters.AddWithValue("@duration", myCall.duration);
                    myConn.MyCommand.Parameters.AddWithValue("@abandon", myCall.abandon);
                    myConn.MyCommand.Parameters.AddWithValue("@delay", myCall.delay);
                    myConn.MyCommand.Parameters.AddWithValue("@busy", myCall.busy);
                    myConn.MyCommand.Parameters.AddWithValue("@callername", myCall.callerName);
                    myConn.MyCommand.Parameters.AddWithValue("@callernumber", myCall.callerNumber);
                    myConn.MyCommand.Parameters.AddWithValue("@note", myCall.note);
                   // myConn.MyCommand.Parameters.AddWithValue("@getinfofrom", myCall.getInfoFrom);
                    myConn.MyCommand.Parameters.AddWithValue("@voiceFile", myCall.voiceFile);
                    //result = (myConn.MyCommand.ExecuteNonQuery() == 1);
                    myConn.MyReader = myConn.MyCommand.ExecuteReader();
                   
                    if (myConn.MyReader.HasRows)
                    {
                        myConn.MyReader.Read();
                        lastId = myConn.MyReader[0].ToString();
                    }
                };
                result = true;

            }
            catch (Exception ex) { Utility.Global.WriteLog(Utility.Global.GetCurrentMethod(ex)); }
            finally
            {
                myConn.MyConn.Close();
            }
            return result;
        }
        }
        public bool Insert(Entity.Call myCall)
        {
            lock (Global.ThreadLockDao)
            {
            var result = false;
            
            try
            {
                var queryString = "insert into cc_calls set " +
                                    "call_date=@calldate," +                                   
                                    
                                    "user_id=@userid," +
                                    "direction_id=@directionid," +
                                    "call_status_id=@callstatusid," +
                                    "caller_type_id=@inboundcallertypeid," +
                                    "call_status_detail_id=@callstatusdetailid," +
                                    "shift_id=@shiftid," +


                                    "is_testcall=@istestcall," +
                                    "is_blankcall=@isblankcall," +
                                    "is_prankcall=@isprankcall," +
                                    "is_wrongno=@iswrongno," +
                                    "is_inquiry=@isinquiry," +
                                    "is_complain=@iscomplaint," +
                                    "is_request=@isrequest," +
                                    "is_prospectcustomer=@isprospectcustomer," +
                                    "is_others=@isother," +

                                     "model_id=@modelid," +
                                    "address=@address," +
                                    "tv_size_id=@tvsizeid," +
                                    "telp=@telp," +
                                    "hp=@handphone," +
                                    "city_id=@city," +
                                    "email=@email," +
                                    "serial_no=@serialno," +
                                    "purchase_date=@purchasedate," +
                                    "problem_date=@problemdate," +
                                    "symptom_code_id=@symptomcodeid," +
                                     "warranty_status_id=@warrantystatusid," +
                                    "product_location_id=@productlocationid," +

                                    "hostaddr=@hostaddress," +
                                    "hostname=@hostname," +
                                    "extension=@extension," +
                                    "duration=@duration," +
                                    "abandon=@abandon," +
                                    "delay=@delay," +
                                    "busy=@busy," +
                                    "customer_name=@callername," +
                                    "note=@note," +
                                  
                                    "voice_file=@voiceFile," +
                                    "caller_number=@callernumber";
                

                myConn.MyConn.Open();

                using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(queryString, myConn.MyConn))
                {
                    myConn.MyCommand.Parameters.AddWithValue("@calldate", myCall.callDate);
                   
                    myConn.MyCommand.Parameters.AddWithValue("@userid", myCall.user.id);
                    myConn.MyCommand.Parameters.AddWithValue("@directionid", myCall.direction.id);
                    myConn.MyCommand.Parameters.AddWithValue("@callstatusid", myCall.inboundStatus.id);
                    myConn.MyCommand.Parameters.AddWithValue("@inboundcallertypeid", myCall.inboundCallerType.id);
                    myConn.MyCommand.Parameters.AddWithValue("@callstatusdetailid", myCall.outbondStatusDetailName);

                    myConn.MyCommand.Parameters.AddWithValue("@shiftid", myCall.shift.id);
                  
                    myConn.MyCommand.Parameters.AddWithValue("@istestcall", myCall.isTestCall);
                    myConn.MyCommand.Parameters.AddWithValue("@isprankcall", myCall.isPrankCall);
                    myConn.MyCommand.Parameters.AddWithValue("@isblankcall", myCall.isBlankCall);
                    myConn.MyCommand.Parameters.AddWithValue("@iswrongno", myCall.isWrongNumber);
                    myConn.MyCommand.Parameters.AddWithValue("@isinquiry", myCall.isInquiry);
                    myConn.MyCommand.Parameters.AddWithValue("@iscomplaint", myCall.isComplaint);
                    myConn.MyCommand.Parameters.AddWithValue("@isrequest", myCall.isRequest);
                    myConn.MyCommand.Parameters.AddWithValue("@isprospectcustomer", myCall.isProspectCustomer);
                    myConn.MyCommand.Parameters.AddWithValue("@isother", myCall.isOthers);

                    myConn.MyCommand.Parameters.AddWithValue("@modelid", myCall.modelId);
                    myConn.MyCommand.Parameters.AddWithValue("@address", myCall.address);
                    myConn.MyCommand.Parameters.AddWithValue("@tvsizeid", myCall.tvSizeId);
                    myConn.MyCommand.Parameters.AddWithValue("@telp", myCall.telephone);
                    myConn.MyCommand.Parameters.AddWithValue("@handphone", myCall.handphone);
                    myConn.MyCommand.Parameters.AddWithValue("@city", myCall.city);
                    myConn.MyCommand.Parameters.AddWithValue("@email", myCall.email);
                    myConn.MyCommand.Parameters.AddWithValue("@serialno", myCall.serialNo);
                    myConn.MyCommand.Parameters.AddWithValue("@purchasedate", myCall.purchaseDate);
                    myConn.MyCommand.Parameters.AddWithValue("@problemdate", myCall.problemDate);
                    myConn.MyCommand.Parameters.AddWithValue("@symptomcodeid", myCall.symptomCodeId);
                    myConn.MyCommand.Parameters.AddWithValue("@warrantystatusid", myCall.warrantyStatusId);
                    myConn.MyCommand.Parameters.AddWithValue("@productlocationid", myCall.productLocationId);


                    myConn.MyCommand.Parameters.AddWithValue("@hostaddress", myCall.hostAddress);
                    myConn.MyCommand.Parameters.AddWithValue("@hostname", myCall.hostName);
                    myConn.MyCommand.Parameters.AddWithValue("@extension", myCall.extension);
                    myConn.MyCommand.Parameters.AddWithValue("@duration", myCall.duration);
                    myConn.MyCommand.Parameters.AddWithValue("@abandon", myCall.abandon);
                    myConn.MyCommand.Parameters.AddWithValue("@delay", myCall.delay);
                    myConn.MyCommand.Parameters.AddWithValue("@busy", myCall.busy);
                    myConn.MyCommand.Parameters.AddWithValue("@callername", myCall.callerName);
                    myConn.MyCommand.Parameters.AddWithValue("@callernumber", myCall.callerNumber);
                    myConn.MyCommand.Parameters.AddWithValue("@note", myCall.note);
                    myConn.MyCommand.Parameters.AddWithValue("@voiceFile", myCall.voiceFile);
                   
                   result = (myConn.MyCommand.ExecuteNonQuery() == 1);
                    //myConn.MyReader = myConn.MyCommand.ExecuteReader();

                  
                };
               // result = true;

            }
            catch (Exception ex) { Utility.Global.WriteLog(Utility.Global.GetCurrentMethod(ex)); }
            finally
            {
                myConn.MyConn.Close();
            }
            return result;
        }
        }

        public bool UpdateDuration(Entity.Call myCall)
        {
            lock (Global.ThreadLockDao)
            {
                var result = false;

                try
                {
                    var durationString = " duration = @duration "; 

                    var queryString = "update cc_calls set " + 
                                        durationString +  

                                        " where id=@id limit 1";



                    myConn.MyConn.Open();

                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(queryString, myConn.MyConn))
                    { 
                        myConn.MyCommand.Parameters.AddWithValue("@duration", myCall.duration); 
                        myConn.MyCommand.Parameters.AddWithValue("@id", myCall.id);
                        result = (myConn.MyCommand.ExecuteNonQuery() == 1);
                        //myConn.MyReader = myConn.MyCommand.ExecuteReader();


                    };
                    // result = true;

                }
                catch (Exception ex) { Utility.Global.WriteLog(Utility.Global.GetCurrentMethod(ex)); }
                finally
                {
                    myConn.MyConn.Close();
                }
                return result;
            }

        }

        public bool Update(Entity.Call myCall)
        {
            lock (Global.ThreadLockDao)
            {
            var result = false;

            try
            {
                var durationString = " duration = @duration, ";
                var voiceFileEmpty = myCall.voiceFile != "" ? " voice_file=@voiceFile, " : ""; 

                var queryString =   "update cc_calls set " +
                                    "caller_type_id=@inboundcallertypeid," +
                                    "caller_type_detail_id=@categoryid," +  

                                    "is_testcall=@istestcall," +
                                    "is_blankcall=@isblankcall," +
                                    "is_prankcall=@isprankcall," +
                                    "is_wrongno=@iswrongno," +
                                    "is_inquiry=@isinquiry," +
                                    "is_complain=@iscomplaint," +
                                    "is_request=@isrequest," +
                                    //"is_prospectcustomer=@isprospectcustomer," +
                                    "is_others=@isother," +

                                    "model_id=@modelid," +
                                    "address=@address," +
                                    "building=@building," +
                                    "tv_size_id=@tvsizeid," +
                                    "telp=@telp," +
                                    "hp=@handphone," +
                                    "city_id=@city," +
                                    "email=@email," +
                                    "serial_no=@serialno," +
                                    "purchase_date=@purchasedate," +
                                    "problem_date=@problemdate," +
                                    "symptom_code_id=@symptomcodeid," +
                                      "warranty_status_id=@warrantystatusid," +
                                    "product_location_id=@productlocationid," +

                                    "customer_name=@callername," +
                                    durationString +
                                    voiceFileEmpty +
                                    
                                    "note=@note" +                     
                                    " where id=@id limit 1";
                                   


                myConn.MyConn.Open();

                using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(queryString, myConn.MyConn))
                {
                    
                    myConn.MyCommand.Parameters.AddWithValue("@inboundcallertypeid", myCall.inboundCallerType.id != null ? myCall.inboundCallerType.id : null);
                    myConn.MyCommand.Parameters.AddWithValue("@categoryid", myCall.callerTypeDetail.id != null ? myCall.callerTypeDetail.id : null); 

                    myConn.MyCommand.Parameters.AddWithValue("@istestcall", myCall.isTestCall);
                    myConn.MyCommand.Parameters.AddWithValue("@isblankcall", myCall.isBlankCall);
                    myConn.MyCommand.Parameters.AddWithValue("@iswrongno", myCall.isWrongNumber);
                    myConn.MyCommand.Parameters.AddWithValue("@isprankcall", myCall.isPrankCall);
                    myConn.MyCommand.Parameters.AddWithValue("@isinquiry", myCall.isInquiry);
                    myConn.MyCommand.Parameters.AddWithValue("@iscomplaint", myCall.isComplaint);
                    myConn.MyCommand.Parameters.AddWithValue("@isrequest", myCall.isRequest);
                    //myConn.MyCommand.Parameters.AddWithValue("@isprospectcustomer", myCall.isProspectCustomer);
                    myConn.MyCommand.Parameters.AddWithValue("@isother", myCall.isOthers);

                    myConn.MyCommand.Parameters.AddWithValue("@modelid", myCall.modelId);
                    myConn.MyCommand.Parameters.AddWithValue("@address", myCall.address);
                    myConn.MyCommand.Parameters.AddWithValue("building", myCall.building);
                    myConn.MyCommand.Parameters.AddWithValue("@tvsizeid", myCall.tvSizeId);
                    myConn.MyCommand.Parameters.AddWithValue("@telp", myCall.telephone);
                    myConn.MyCommand.Parameters.AddWithValue("@handphone", myCall.handphone);
                    myConn.MyCommand.Parameters.AddWithValue("@city", myCall.city);
                    myConn.MyCommand.Parameters.AddWithValue("@email", myCall.email);
                    myConn.MyCommand.Parameters.AddWithValue("@serialno", myCall.serialNo);
                    myConn.MyCommand.Parameters.AddWithValue("@purchasedate", myCall.purchaseDate);
                    myConn.MyCommand.Parameters.AddWithValue("@problemdate", myCall.problemDate);
                    myConn.MyCommand.Parameters.AddWithValue("@symptomcodeid", myCall.symptomCodeId);
                    myConn.MyCommand.Parameters.AddWithValue("@warrantystatusid", myCall.warrantyStatusId);
                    myConn.MyCommand.Parameters.AddWithValue("@productlocationid", myCall.productLocationId);

                    myConn.MyCommand.Parameters.AddWithValue("@callername", myCall.callerName);                   
                    myConn.MyCommand.Parameters.AddWithValue("@note", myCall.note);                 
                    myConn.MyCommand.Parameters.AddWithValue("@duration", myCall.duration);

                    if (!string.IsNullOrEmpty(myCall.voiceFile))
                    {
                        myConn.MyCommand.Parameters.AddWithValue("@voiceFile", myCall.voiceFile);
                    }
                    myConn.MyCommand.Parameters.AddWithValue("@id", myCall.id);
                    result = (myConn.MyCommand.ExecuteNonQuery() == 1);
                    //myConn.MyReader = myConn.MyCommand.ExecuteReader();


                };
                // result = true;

            }
            catch (Exception ex) {  Utility.Global.WriteLog(Utility.Global.GetCurrentMethod(ex)); }
            finally
            {
                myConn.MyConn.Close();
            }
            return result;
        }
        }
        public bool UpdateAcw(string durasi,string callId)
        {
            lock (Global.ThreadLockDao)
            {
            var result = false;
            try
            {
                var queryString = "update cc_calls set " +
                                    "busy=@busy" +                                   
                                    " where id=@id";

                myConn.MyConn.Open();

                using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(queryString, myConn.MyConn))
                {
                        myConn.MyCommand.Parameters.AddWithValue("@busy", durasi);
                    myConn.MyCommand.Parameters.AddWithValue("@id", callId);
                    result = (myConn.MyCommand.ExecuteNonQuery() == 1);
                }
            }
            catch (Exception ex)
            { Utility.Global.WriteLog(Utility.Global.GetCurrentMethod(ex)); }
            finally
            {
                myConn.MyConn.Close();
            }
            return result;
            }

        }       
        public bool setOutboundStatus(Entity.Call call)
        {
            lock (Global.ThreadLockDao)
            {
                var result = false;
                var sql = "update cc_calls set call_status_id = @callStatusId where id = @id limit 1";
                try
                {
                    myConn.MyConn.Open();
                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(sql, myConn.MyConn))
                    {
                        myConn.MyCommand.Parameters.AddWithValue("@callStatusId",call.outboundStatus.id);
                        myConn.MyCommand.Parameters.AddWithValue("@id", call.id);

                        result = (myConn.MyCommand.ExecuteNonQuery() != 0);
                    }
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


        public bool setOutboundStatusDetail(Entity.Call call)
        {
            lock (Global.ThreadLockDao)
            {
                var result = false;
                var sql = "update cc_calls set call_status_detail_id = @callStatusDetailId where id = @id limit 1";
                try
                {
                    myConn.MyConn.Open();
                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(sql, myConn.MyConn))
                    {
                        myConn.MyCommand.Parameters.AddWithValue("@callStatusDetailId", call.outboundStatusDetail.id);
                        myConn.MyCommand.Parameters.AddWithValue("@id", call.id);

                        result = (myConn.MyCommand.ExecuteNonQuery() != 0);
                    }
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
        public bool isThisCallInboundHasTicket(string callId)
        {
            var result = false;
            try
            {
                var queryString = "select * from cc_ticket_tags where cc_ticket_tags.media_id='" + callId + "' and source_media_id=4";

                myConn.MyConn.Open();

                using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(queryString, myConn.MyConn))
                {
                    myConn.MyReader = myConn.MyCommand.ExecuteReader();
                    //myConn.MyReader.Read();
                }
                result = (myConn.MyReader.HasRows);
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

        public string CheckCurrUniqeID(string user_id)//15-11
        {
            lock (Global.ThreadLockDao)
            {
                string RetVal = string.Empty;
                try
                {
                    var queryString = "SELECT current_unique_id " +
                                        "FROM cc_users" +
                                        " WHERE id=" + user_id;

                    myConn.MyConn.Open();
                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(queryString, myConn.MyConn))
                    {
                        using (myConn.MyReader = myConn.MyCommand.ExecuteReader())
                        {
                            if (myConn.MyReader.HasRows)
                            {
                                if (myConn.MyReader.Read())
                                {
                                    RetVal = myConn.MyReader["current_unique_id"].ToString();
                                }
                            }
                        }
                    }

                }
                catch (Exception ex)
                { Utility.Global.WriteLog(Utility.Global.GetCurrentMethod(ex)); }
                finally
                {
                    myConn.MyConn.Close();
                }
                return RetVal;
            }

        }

        public string UpdateCurrUniqeID(string user_id)//15-11
        {
            lock (Global.ThreadLockDao)
            {
                string RetVal = string.Empty;
                try
                {
                    var queryString = "UPDATE cc_users SET cc_users.current_unique_id=NULL, cc_users.is_booked=0" +
                                        " WHERE id=" + user_id;

                    myConn.MyConn.Open();
                    using (myConn.MyCommand = new MySql.Data.MySqlClient.MySqlCommand(queryString, myConn.MyConn))
                    {
                        using (myConn.MyReader = myConn.MyCommand.ExecuteReader())
                        {
                            if (myConn.MyReader.HasRows)
                            {
                                if (myConn.MyReader.Read())
                                {
                                    RetVal = myConn.MyReader["current_unique_id"].ToString();
                                }
                            }
                        }
                    }

                }
                catch (Exception ex)
                { Utility.Global.WriteLog(Utility.Global.GetCurrentMethod(ex)); }
                finally
                {
                    myConn.MyConn.Close();
                }
                return RetVal;
            }

        }
    }
}

