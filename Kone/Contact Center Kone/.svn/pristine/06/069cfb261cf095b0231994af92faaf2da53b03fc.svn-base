using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Configuration;


namespace Contact_Center_Kone.Utility
{
    public class DbMyConnection
    {
        public MySqlConnection MyConn = new MySqlConnection(ConfigurationManager.AppSettings["conString"]);
        public MySqlCommand MyCommand;
        public MySqlDataReader MyReader;
        public MySqlDataAdapter MyAdapter;
    }
}
