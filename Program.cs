using System;
using System.Data.SqlClient;
using csdb.Database;

class Program {

    static void ExecuteUserQuery(string query) {
        try {
            using (SqlConnection connection = DbConnector.CreateConnection()) {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection)) {
                    if (query.TrimStart().StartsWith("SELECT", StringComparison.OrdinalIgnoreCase)) {
                        using (SqlDataReader reader = command.ExecuteReader()) {
                            int fieldCount = reader.FieldCount;
                            while (reader.Read()) {
                                for (int i = 0; i < fieldCount; i++) {
                                    Console.Write(reader.GetName(i) + ": " + reader[i] + "\t");
                                }
                                Console.WriteLine();
                            }
                        }
                    } else {
                        int affected = command.ExecuteNonQuery();
                        Console.WriteLine($"{affected} row(s) affected.");
                    }
                }
            }
        } catch (Exception ex) {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
    
    static void Main() {
        Console.WriteLine("== type '/exit' to exit ==");
        while (true) {
            Console.Write("\nSQL> ");
            string? userInput = Console.ReadLine();

            if (userInput == null)
                continue;
            else if (userInput.Trim().ToLower() == "/exit")
                break;
            else if (userInput.Trim().ToLower() == "/table")
                userInput = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'";

            ExecuteUserQuery(userInput);
        }
    }
}