using System.Data.SqlClient;
using csdb.Database;
using System.Diagnostics;

namespace csdb.Utils {
    public static class Helper {
        //static Helper() {}
        
        public static long? ExecuteUserQuery(string query) {
            try {
                using (SqlConnection connection = DbConnector.CreateConnection()) {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection)) {
                        Stopwatch stopwatch = Stopwatch.StartNew();
                        if (query.TrimStart().StartsWith("SELECT", StringComparison.OrdinalIgnoreCase)) {
                            using (SqlDataReader reader = command.ExecuteReader()) {
                                int fieldCount = reader.FieldCount;
                                while (reader.Read()) {
                                    for (int i = 0; i < fieldCount; i++) {
                                        Console.Write(reader.GetName(i) + ": " + reader[i] + "\t");
                                    }
                                    Console.WriteLine();
                                }
                                stopwatch.Stop();
                                return stopwatch.ElapsedMilliseconds;
                            }
                        } else {
                            int affected = command.ExecuteNonQuery();
                            Console.WriteLine($"{affected} row(s) affected.");
                            stopwatch.Stop();
                            return stopwatch.ElapsedMilliseconds;
                        }
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }
    }
}