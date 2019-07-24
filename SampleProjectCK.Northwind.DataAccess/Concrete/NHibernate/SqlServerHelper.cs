using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using SampleProjectCK.Core.DataAccess.NHihabernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace SampleProjectCK.Northwind.DataAccess.Concrete.NHibernate
{
    public class SqlServerHelper : NHibernateHelper
    {
        protected override ISessionFactory InitializeFactory()
        {
            return Fluently.Configure().Database(MsSqlConfiguration.MsSql2012
                .ConnectionString(c=>c.FromConnectionStringWithKey("NorthwindContext")))
                .Mappings(t=>t.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .BuildSessionFactory();
        }
    }
}
