using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Framework.Core.Persistence
{
    public static class DbConnectionFactory
    {
        static IConfiguration _configuration;
        static string writeDbConnection;
        static string readDbConnection;
        public static void SetConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
            writeDbConnection = $"Data Source={configuration["DbSettings:Server"]};Initial Catalog={configuration["DbSettings:WriteDbName"]};User ID={configuration["DbSettings:User"]};Password={configuration["DbSettings:Password"]}";
            readDbConnection = $"Data Source={configuration["DbSettings:Server"]};Initial Catalog={configuration["DbSettings:QueryDbName"]};User ID={configuration["DbSettings:User"]};Password={configuration["DbSettings:Password"]}";

        }

        public static IDbConnection GetReadModelDbConnection()
        {
            return new SqlConnection(readDbConnection);
        }

        public static IDbConnection GetWrtieModelDbConnection()
        {
            return GetDbConnection(writeDbConnection);
        }

        private static IDbConnection GetDbConnection(string conection)
        {
            return new SqlConnection(conection);
        }
    }
}
