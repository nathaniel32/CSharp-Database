/* using System; */
using csdb.Utils;

class Program {    
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

            long? executionTime = Helper.ExecuteUserQuery(userInput);
            Console.WriteLine($"Execution Time: {executionTime} ms");
        }
    }
}