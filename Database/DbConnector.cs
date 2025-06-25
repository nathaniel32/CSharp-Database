using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace csdb.Database {
    public static class DbConnector {
        private static readonly IConfiguration config;

        static DbConnector() {
            config = new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory).AddJsonFile("config.json").Build();
        }
        
        public static SqlConnection CreateConnection() {
            return new SqlConnection(config.GetConnectionString("DbConnection"));
        }
    }
}