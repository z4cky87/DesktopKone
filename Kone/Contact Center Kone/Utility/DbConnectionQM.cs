using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Contact_Center_Kone.Utility
{
    public class DbConnectionQM
    {
        public MySqlConnection Conn = new MySqlConnection(ConfigurationSettings.AppSettings["dbconnQM"]);
        public MySqlCommand Command;
        public MySqlDataReader Reader;
    }
}
