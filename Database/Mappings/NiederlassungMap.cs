using FluentNHibernate.Mapping;
using csdb.Database.Models;

namespace csdb.Database.Mappings {
    public class NiederlassungMap : ClassMap<Niederlassung> {
        public NiederlassungMap() {
            Table("Niederlassung");
            Id(x => x.NlNr).Column("NLNr").GeneratedBy.Assigned();  // No autoincrement
            Map(x => x.Ort).Length(50);
            HasMany(x => x.ListeMitarbeiter)
                .KeyColumn("NLNr")
                .Inverse()
                .Cascade.All();
        }
    }
}