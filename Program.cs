/* using System; */
using csdb.Database.Repositories;
using csdb.Database;

class Program {    
    static void Main() {
        DbConnector.Initialize();
        Console.WriteLine("== type '/exit' to exit ==");
        while (true) {
            Console.WriteLine(
                "\nMenu"
                + "\n1. Show Niederlassung"
                + "\n2. Show Mitarbeiter"
            );

            Console.Write("Input: ");
            string? userInput = Console.ReadLine();

            if (userInput == null)
                continue;
            else if (userInput.Trim().ToLower() == "/exit")
                break;

            long? executionTime;
            switch (userInput) {
                case "1":
                    executionTime = NiederlassungRepository.QueryAllNiederlassung();
                    break;
                case "2":
                    executionTime = MitarbeiterRepository.QueryAllMitarbeiter();
                    break;
                default:
                    executionTime = null;
                    break;
            }

            Console.WriteLine($"Execution Time: {executionTime} ms");
        }
    }
}