﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace Contact_Center_Kone.Utility
{
    public  class Telephony
    {
        public string dateTimeCall;
        public string timerStampRinging;
        public string timerStampCall;
        public string timerStampBusy;
        public string durationDelay;

        private List<SocketInfo> socketList = new List<SocketInfo>();      
        public class SocketInfo
        {
            public byte[] buffer = new byte[255];
            public Socket socket = null;
        }
       
        public string MessageFromTelephony { get; set; }
        public string CallerNumber { get; set; }
   
        public Telephony()
        {
            Start();
        }
        private void Start()
        {
                
                IPHostEntry ipHostInfo=Dns.Resolve("localhost");
                IPAddress ipAddress = ipHostInfo.AddressList[0];        
                IPEndPoint clientEndpoint = new IPEndPoint(ipAddress, 6101); //Port Live
                //IPEndPoint clientEndpoint = new IPEndPoint(ipAddress, 6057);

            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            SocketInfo info = new SocketInfo();
            info.socket = clientSocket;
            lock (socketList)
            {
                socketList.Add(info);
            }

            lock (Global.ThreadLockDao)
            try
            {
                info.socket.Connect(clientEndpoint);              
                info.socket.BeginReceive(info.buffer, 0, info.buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), info);
            }
            catch (Exception ex)
            {
                lock (socketList)
                {
                    socketList.Remove(info);
                }
                Global.WriteLog(Global.GetCurrentMethod(ex));
            }
            //Thread.Sleep(500);
        }
        public void Stop()
        {
            try
            {
                lock (socketList)
                {
                    for (int i = socketList.Count - 1; i >= 0; i--)
                    {
                        try
                        {
                            socketList[i].socket.Close();
                        }
                        catch { }
                        socketList.RemoveAt(i);
                    }
                }
            }
            catch { }
        }
        private void ReceiveCallback(IAsyncResult result)
        {
            
            SocketInfo info = (SocketInfo)result.AsyncState;

            lock (Global.ThreadLockDao)
            try
            {
                int bytestoread = info.socket.EndReceive(result);

                if (bytestoread > 0)
                {
                    string response = Encoding.UTF8.GetString(info.buffer, 0, bytestoread);
                    ParseResponseTelephony(response);                 
                    info.socket.BeginReceive(info.buffer, 0, 255, SocketFlags.None, 
                        new AsyncCallback(ReceiveCallback), info);
                }
                //else
                //{
                //    lock (socketList)
                //    {
                //        socketList.Remove(info);
                //    }
                   
                //    info.socket.Close();
                //}
            }
            catch (Exception ex)
            {
                //lock (socketList)
                //{
                //    socketList.Remove(info);
                //}
               // System.Windows.Forms.MessageBox.Show(Global.GetCurrentMethod(ex));
                Global.WriteLog(Global.GetCurrentMethod(ex));
                Start();
            }
        }
        public void SendData(string data)
        {
            lock(Global.ThreadLockDao)
            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(data + "\r\n" + "");
                lock (socketList)
                {
                    foreach (SocketInfo info in socketList)
                    {
                        info.socket.Send(bytes, bytes.Length, SocketFlags.None);
                    }
                }
            }
            catch(Exception ex)
            {
                Global.WriteLog(Global.GetCurrentMethod(ex));
            }
        }
        private void ParseResponseTelephony(string message)
        { 
            string[] lines = Regex.Split(message, "\r\n");
            if (lines[0].Split('|')[0] == "RINGING")
            {
                timerStampRinging = Convert.ToDateTime(System.DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss");
                //dateTimeCall = Convert.ToDateTime(System.DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss");
                dateTimeCall = Convert.ToDateTime(Global.LogDateTimeServer()).ToString("yyyy-MM-dd HH:mm:ss");
                Global.callState = Global.CallState.RINGING;              
                MessageFromTelephony = lines[0].Split('|')[0];
                CallerNumber = lines[0].Split('|')[1];
               var userDao=new Dao.UserDao().ChangeActivityUser(Global.userAccount.id, "3");
            }
            else { MessageFromTelephony = lines[0]; }
        }
        #region Function

        /// <summary>
        /// Unmute the call
        /// </summary>
        public void UnMute() { SendData("UNMUTE"); }
        /// <summary>
        /// Unhold the call
        /// </summary>
        public void UnHold() { SendData("UNHOLD"); }
        /// <summary>
        /// Hold the call
        /// </summary>
        public void Hold() { SendData("HOLD"); }
        /// <summary>
        /// Mute the call
        /// </summary>
        public void Mute() { SendData("MUTE"); }
        /// <summary>
        /// Register to PABX server
        /// </summary>
        public void RegisterToPabx(string host,string ext,string pwd)
        {
            SendData("REGISTER|" + host + "|" + ext + "|" + pwd);
        }
        /// <summary>
        /// Unregister to PABX server
        /// </summary>
        public void UnregisterPabx() { SendData("UNREGISTER"); }
        /// <summary>
        /// Hang UP the Call
        /// </summary>
        public void Hangup(string fileNameWav)
        {
            SendData("HANGUP|" + fileNameWav + "|" + System.DateTime.Now.ToString("yyyy-MM-dd"));
        }
        /// <summary>
        /// Make the call
        /// </summary>
        public void MakeCall(string noTujuan) { SendData("DIAL|" + noTujuan); }
        /// <summary>
        /// Pick UP inbound call
        /// </summary>
        public void Pickup() { SendData("PICKUP"); }        
      
        /// <summary>
        /// Send DTMF Tone
        /// </summary>
        public void DTMF(string digit) { SendData("DTMF|" + digit); }

        /// <summary>
        /// Whisper
        /// </summary>
        /// <returns></returns>
        ///
        public void Whisper(string ext) { SendData("DIAL|557"+ext); }

        /// <summary>
        /// HangupWisper
        /// </summary>
        /// <returns></returns>
        public void HangupWhisper(string userwhisper) { SendData("HANGUP|" + Global.userAccount.username + "whisperto" + userwhisper + DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss")); }

        /// <summary>
        /// Listen
        /// </summary>
        /// <returns></returns>
        ///
        public void Listen(string ext) { SendData("DIAL|556" + ext); }

        /// <summary>
        /// HangupWisper
        /// </summary>
        /// <returns></returns>
        public void HangupListen(string userwhisper) { SendData("HANGUP|" + Global.userAccount.username + "listento" + userwhisper + DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss")); }

        /// <summary>
        /// Transfercallz
        /// </summary>
        /// <returns></returns>
        public void TransferCall(string exten) { SendData("TRANSFER|" + exten); }

        public string LocalCompName() 
        { 
            return Dns.GetHostName(); 
       }
        public string GetDurasi(string oldTime)
        {
            string result = "";
            try
            {
                TimeSpan duration = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")).Subtract(Convert.ToDateTime(oldTime));
                result = duration.ToString();
            }
            catch (Exception ex) { Utility.Global.WriteLog(Utility.Global.GetCurrentMethod(ex)); }
            return result;
        }
        #endregion

    }
}
