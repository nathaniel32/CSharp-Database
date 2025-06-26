using System.Data.SqlClient;
using csdb.Database;
using System.Diagnostics;
using csdb.Database.Models;

namespace csdb.Database.Repositories {
    public static class MitarbeiterRepository {
        public static long? QueryAllMitarbeiter() {
            try {
                Stopwatch stopwatch = Stopwatch.StartNew();
                using (var session = DbConnector.OpenSession()) {
                    var allMitarbeiter = session.Query<Mitarbeiter>().ToList();
                    foreach (var m in allMitarbeiter) {
                        Console.WriteLine($"   - ID: {m.MitID}, Name: {m.MitName} {m.MitVorname}, Job: {m.MitJob}, Stundensatz: {m.MitStundensatz}, NlNr: {m.Niederlassung?.NlNr}");
                    }
                }
                stopwatch.Stop();
                return stopwatch.ElapsedMilliseconds;
            } catch (Exception ex) {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }
    }
}