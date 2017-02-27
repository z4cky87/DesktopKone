using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebSocket4Net;
using System.Configuration;
using System.Windows.Forms;

namespace Contact_Center_Kone.Utility
{
    internal class Websocket
    {
        private delegate void InvokeDelegate(Form parent);

        public void ShowDialog(Form parent)
        {
            if (parent.InvokeRequired)
            {
                InvokeDelegate d = new InvokeDelegate(ShowDialog);
                parent.Invoke(new InvokeDelegate(ShowDialog));
            }
            else
            {
                parent.ShowDialog();
                // Do what you need to do, you're in the foreground thread
            }
        }

        internal string message;
        internal enum WebsocketStatus
        {
            Open,
            Errorr,
            Closed
        }
        internal WebSocket webSocketClient;
        internal WebsocketStatus websocketStatus = new WebsocketStatus();

        internal Websocket()
        {
            webSocketClient = new WebSocket(ConfigurationManager.AppSettings["websocketUri"]);
            //webSocketClient = new WebSocket("ws://localhost:5432/");
            webSocketClient.AllowUnstrustedCertificate = true;
            webSocketClient.Opened += new EventHandler(webSocketClient_Opened);
            webSocketClient.Closed += new EventHandler(webSocketClient_Closed);
            webSocketClient.Error += new EventHandler<SuperSocket.ClientEngine.ErrorEventArgs>(webSocketClient_Error);
            webSocketClient.MessageReceived += new EventHandler<MessageReceivedEventArgs>(webSocketClient_MessageReceived);

            webSocketClient.EnableAutoSendPing = true;
            webSocketClient.AutoSendPingInterval = 5;
            webSocketClient.Open();
        }

        internal void webSocketClient_Opened(object sender, EventArgs e)
        {
            Console.WriteLine("Open");
            websocketStatus = WebsocketStatus.Open;
        }

        internal void webSocketClient_Closed(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("Close");
                websocketStatus = WebsocketStatus.Closed;
                webSocketClient.Open();
            }
            catch { }
        }

        internal void webSocketClient_Error(object sender, SuperSocket.ClientEngine.ErrorEventArgs e)
        {
            websocketStatus = WebsocketStatus.Errorr;

            Console.WriteLine(e.Exception.GetType() + ":" + e.Exception.Message + Environment.NewLine + e.Exception.StackTrace);

            if (e.Exception.InnerException != null)
            {
                Console.WriteLine(e.Exception.InnerException.GetType());
            }
        }


        internal void webSocketClient_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            //Globals.MessageServer = e.Message;
            try
            {
                //OUTBOUNDCALL|userid|tikcetid|phonenumer
                Console.WriteLine("RCVD: " + e.Message);
                int erorrCode;
                var splitMessage = e.Message.Split('|');
                if (splitMessage[0] == "OUTBOUNDCALL")
                {

                    if (splitMessage[1] == Global.userAccount.id)
                    {
                        Global.mainForm.BeginInvoke((Action)delegate
                        {
                          //  MessageBox.Show("Invoke In websocket");
                            Global.mainForm.tempTicketIdWebSocket = splitMessage[2];
                            Global.mainForm.tempPhoneNoWebSocket = splitMessage[3];
                            Global.mainForm.btn_outbound.PerformClick();
                        });
                    }


                    //Globals.pbx_inbound = splitMessage[4];
                    //Globals.telephony.RegisterToPabx(Globals.pbx_inbound, Globals.ext_inbound,
                    //    Globals.ext_inbound_pwd);

                    //// Thread.Sleep(4000);

                    //if (Globals.telephony.isRegistered)
                    //{
                    //    webSocketClient.Send("CALL|ACCEPTED|" + splitMessage[2]
                    //        + "|" + splitMessage[3] + "|" + splitMessage[4]);
                    //    Globals.uniqeIdCall = splitMessage[2];

                    //    // wait 5 second until TRANSFERING|SUCCES|2001|1458202554.22|SIP/858585-00000016

                    //    //Globals.telephony.isRegistered = false;
                    //    //return;
                    //}
                    //else
                    //{
                    //    Globals.telephony.UnregisterPabx();
                    //    webSocketClient.Send("CALL|REJECTED|" + splitMessage[2]
                    //        + "|" + splitMessage[3] + "|" + splitMessage[4]);

                    //    //jadi ready in
                    //    Globals.SetUserStatus((int)Globals.UserStatusEnum.IDLE, out erorrCode);
                    //    Globals.StatusEnum = Globals.UserStatusEnum.IDLE;
                    //    Globals.InsertUserActivity((int)Globals.UserActionEnum.IDLE, out erorrCode);
                    //    Globals.SetUserLastActivityTime(out erorrCode);
                    //}
                }



            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

        }


    }
}
