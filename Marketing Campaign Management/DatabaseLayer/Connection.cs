using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DatabaseLayer
{
    public static class Connection
    {
        static string connectionManager = ConfigurationManager.ConnectionStrings["MCMConnection"].ConnectionString;
        public static SqlConnection connection = null;
        static Connection()
        {
            connection = new SqlConnection(connectionManager);
        }
        public static void Open()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
        }
        public static void Close()
        {
            connection.Close();
        }
    }
}
