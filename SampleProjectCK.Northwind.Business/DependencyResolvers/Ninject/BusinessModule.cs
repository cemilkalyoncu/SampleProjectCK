using Ninject.Modules;
using SampleProjectCK.Core.DataAccess;
using SampleProjectCK.Core.DataAccess.EntityFramework;
using SampleProjectCK.Core.DataAccess.NHihabernate;
using SampleProjectCK.Northwind.Business.Abstract;
using SampleProjectCK.Northwind.Business.Concrete.Managers;
using SampleProjectCK.Northwind.DataAccess.Abstract;
using SampleProjectCK.Northwind.DataAccess.Concrete.EntityFramework;
using SampleProjectCK.Northwind.DataAccess.Concrete.NHibernate;
using SampleProjectCK.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProjectCK.Northwind.Business.DependencyResolvers.Ninject
{
    public class BusinessModule:NinjectModule
    {
        /* ninject injection ile arayuz/dataaccess arası gecisleri yapmak için
         * ctor yapısı olusturduk. Ioc yapısı*/
        public override void Load()
        {
        /*her istekte new'lenmemesi için ınsingletonscope kullanıldı.*/
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IProductDal>().To<EfProductDal>().InSingletonScope();

            Bind<IUserService>().To<UserManager>();
            Bind<IUserDal>().To<EfUserDal>();

            /*projelerde standart olarak kullanılıyorlar*/
            Bind(typeof(IQueryableRepository<>)).To(typeof(EfQueryableRepository<>));
            Bind<DbContext>().To<NorthwindContext>();

            Bind<NHibernateHelper>().To<SqlServerHelper>();
        }
    }
}
