using Contact_Center_Kone.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Contact_Center_Kone
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        [STAThread]
        static void Main()
        {
            System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("en-GB");
            Application.CurrentCulture = cultureInfo;

            Global.KillApp("Telephony");
            Global.KillApp("VoiceUploader");

            Gecko.Xpcom.Initialize(AppDomain.CurrentDomain.BaseDirectory + "xulrunner-sdk");
           

            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\log"))
            {
                DirectoryInfo di = Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\log");
            }

            //Utility.Websocket websocket = new Websocket();
            System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.BaseDirectory + "Telephony.exe");
            System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.BaseDirectory + "VoiceUploader.exe");

            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fileVersionInfo.ProductVersion;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new View.Login());
        }
    }
}
