﻿using Microsoft.Extensions.Configuration;
using Polly;
using System;
using System.Data.SqlClient;
using System.IO;

namespace Utilties.DatabaseCheck
{
    class Program
    {
        static int Main(string[] args)
        {
            Console.WriteLine("DatabaseCheck: starting");

            var sqlPolicy = Policy.Handle<SqlException>()
                                  .Retry(3, (exception, retryCount) =>
                                  {
                                      Console.WriteLine("DatabaseCheck: Got SQL exception {0}, retryCount {1}", exception.GetType(), retryCount);
                                  });

            var result = sqlPolicy.ExecuteAndCapture(() => ConnectToSqlServer());
            if (result.Outcome == OutcomeType.Successful)
            {
                Console.WriteLine("DatabaseCheck: OK");
                return 0;
            }
            else
            {
                Console.WriteLine("DatabaseCheck: FAILED");
                return 1;
            }
        }

        private static void ConnectToSqlServer()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile("configs/config.json", optional: true)
                .AddJsonFile("secrets/secret.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var targetDatabase = config["DatabaseCheck:DatabaseName"];
            var timeout = int.Parse(config["DatabaseCheck:ConnectionTimeout"]);

            var connectionString = config.GetConnectionString(targetDatabase);
            var server = connectionString.Split(';')[0].Split('=')[1];
            Console.WriteLine("DEPENDENCY: Connecting to SQL Server: {0}", server);
            connectionString = $"{connectionString};Connect Timeout={timeout};";
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
            }
        }
    }
}
