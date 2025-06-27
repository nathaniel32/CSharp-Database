using System.Diagnostics;
using csdb.Database.Models;

namespace csdb.Database.Repositories {
    public static class NiederlassungRepository {
        public static long? QueryAllNiederlassung() {
            try {
                Stopwatch stopwatch = Stopwatch.StartNew();
                using (var session = DbConnector.OpenSession()) {
                    var allNiederlassungen = session.Query<Niederlassung>().Where(n => n.Ort == "Chemnitz").ToList();
                    foreach (var nl in allNiederlassungen) {
                        Console.WriteLine($"   - NlNr: {nl.NlNr}, Ort: {nl.Ort}");
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