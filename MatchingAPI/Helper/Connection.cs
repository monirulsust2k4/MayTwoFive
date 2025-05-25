using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MatchingAPI.Helper
{
    public class Connection
    {

        public static string PeopleDeskARLConnection { get; internal set; }

        private static string GetConnection()
        {
            var config = new ConfigurationBuilder()
           .SetBasePath(Directory.GetDirectoryRoot(@"\"))
           .AddJsonFile("appSettings.json", false)
           .Build();
            var connString = config.GetSection("connectionString").Value;
            return connString;
        }

    }
}
