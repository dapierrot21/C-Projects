using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data
{
    public class Settings
    {
        private static string _connectionString;

        public static string GetConnectionString()
        {
            // If string is null or empty.
            if (string.IsNullOrEmpty(_connectionString))
                // Load the connection string from Web.config file.
                _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            return _connectionString;
        }
    }
}
