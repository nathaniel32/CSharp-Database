using NHibernate;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using Microsoft.Extensions.Configuration;
using csdb.Database.Models;

namespace csdb.Database {
    public static class DbConnector {
        //private static readonly ISessionFactory sessionFactory;
        private static ISessionFactory? sessionFactory;

        //static DbConnector()
        public static void Initialize() {
            var config = new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory).AddJsonFile("config.json").Build();
            sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                    .ConnectionString(config.GetConnectionString("DbConnection"))
                    .ShowSql()
                )
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Niederlassung>())
                .BuildSessionFactory();
        }

        public static ISessionFactory? GetSessionFactory() {
            return sessionFactory;
        }

        public static ISession OpenSession() {
            if (sessionFactory == null)
                throw new InvalidOperationException("SessionFactory Error!");
            return sessionFactory.OpenSession();
        }
    }
}