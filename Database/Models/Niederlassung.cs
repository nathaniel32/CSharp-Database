namespace csdb.Database.Models {
    public class Niederlassung {
        public virtual int NlNr { get; set; }
        public virtual string Ort { get; set; } = null!;
        public virtual IList<Mitarbeiter> ListeMitarbeiter { get; set; }

        public Niederlassung() {
            ListeMitarbeiter = new List<Mitarbeiter>();
        }
    }
}