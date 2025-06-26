namespace csdb.Database.Models {
    public class Mitarbeiter {
        public virtual string MitID { get; set; } = null!;  // Primary key is CHAR, not int
        public virtual string MitName { get; set; } = null!;
        public virtual string? MitVorname { get; set; }  // Nullable
        public virtual DateTime MitGebDat { get; set; }
        public virtual string MitJob { get; set; } = null!;
        public virtual decimal? MitStundensatz { get; set; }  // Nullable smallmoney
        public virtual Niederlassung Niederlassung { get; set; } = null!;
    }
}