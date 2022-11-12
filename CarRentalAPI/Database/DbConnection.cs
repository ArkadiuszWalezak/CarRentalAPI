using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalAPI.Database
{
    public class DbConnection
    {
        public static MySqlConnection Connection => GetConnection();

        private static MySqlConnection GetConnection()
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = "127.0.0.1",
                UserID = "root",
                Password = "",
                Database = "carrentaldb",
            };

            return new MySqlConnection(builder.ConnectionString);
        }
    }
}
