using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Wu.Framework.Entity;

namespace Wu.Framework.Core
{
    public class PersistenceFacility : AbstractFacility
    {
        private const string MysqlDbFactory = "MysqlDbFactory";
        private const string MssqlDbFactory = "MssqlDbFactory";
        private const string MysqlConnect = "MysqlConnect";
        private const string MssqlConnect = "MssqlConnect";
        protected override void Init()
        {
            Kernel.Register(
             Component.For<ISessionFactory>()
                 .UsingFactoryMethod(CreateMysqlFactory)
                 .LifeStyle
                 .Singleton
                 .Named(MysqlDbFactory)
                 ,
         Component.For<ISessionFactory>()
             .UsingFactoryMethod(CreateMSSQLFactory)
             .LifeStyle
             .Singleton
             .Named(MssqlDbFactory)
         );

            Kernel.Register(
                Component.For<ISession>()
                    .UsingFactoryMethod(kernel => kernel.Resolve<ISessionFactory>(MysqlDbFactory).OpenSession())
                    .LifeStyle
                    .PerWebRequest
                    .Named(MysqlConnect)
                    ,
            Component.For<ISession>()
                .UsingFactoryMethod(kernel => kernel.Resolve<ISessionFactory>(MssqlDbFactory).OpenSession())
                .LifeStyle
                .PerWebRequest
                .Named(MssqlConnect)
            );
        }


        private static ISessionFactory CreateMysqlFactory()
        {

            var cfg = Fluently.Configure().Database(MySQLConfiguration.Standard.ConnectionString(x => x.FromConnectionStringWithKey("DatabaseConnectionString")).Driver<NHibernate.Driver.MySqlDataDriver>()).Mappings(m =>
            {
                m.FluentMappings.AddFromAssemblyOf<User>();
                //  m.FluentMappings.AddFromAssembly(Assembly.Load("Wu.Framework.Entity"));
            });
            try
            {
                return cfg.BuildSessionFactory();
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException($"初始化Isessionfactory 失败:{ex.InnerException?.Message}");
            }
           
        }
        private static ISessionFactory CreateMSSQLFactory()
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(x => x.FromConnectionStringWithKey("DatabaseConnectionString")))
                // .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.Load("Wu.Framework.Entity")))
                .Mappings(m =>
                {
                    m.FluentMappings.AddFromAssemblyOf<User>();
                    //  m.FluentMappings.AddFromAssembly(Assembly.Load("Wu.Framework.Entity"));
                })
                .BuildSessionFactory();
        }
    }
}
