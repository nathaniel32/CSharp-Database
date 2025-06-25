using System;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

class Program
{
    static void Main()
    {
        var config = new ConfigurationBuilder().AddJsonFile("config.json").Build();

        string? DbConnectionString = config.GetConnectionString("DbConnection");

        //var dbSection = config.GetSection("DbConnection");
        //string DbConnectionString = $"Server={dbSection["server"]};Database={dbSection["database"]};User Id={dbSection["userId"]};Password={dbSection["password"]};";

        try
        {
            using (SqlConnection conn = new SqlConnection(DbConnectionString))
            {
                conn.Open();
                Console.WriteLine("Connected to the database.");

                string query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("Table:");
                        while (reader.Read())
                        {
                            Console.WriteLine("- " + reader.GetString(0));
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}