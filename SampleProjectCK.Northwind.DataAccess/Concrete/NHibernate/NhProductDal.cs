using SampleProjectCK.Core.DataAccess.NHihabernate;
using SampleProjectCK.Northwind.DataAccess.Abstract;
using SampleProjectCK.Northwind.Entities.ComplexTypes;
using SampleProjectCK.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProjectCK.Northwind.DataAccess.Concrete.NHibernate
{
    public class NhProductDal : NhEntityRepositoryBase<Product>, IProductDal
    {
        private NHibernateHelper _nhibernateHelper;
        public NhProductDal(NHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {
        }

        public List<ProductDetail> GetProductDetails()
        {
            using (var session = _nhibernateHelper.OpenSession())
            {
                var result = from p in session.Query<Product>()
                             join c in session.Query<Category>() on p.CategoryId equals c.CategoryId
                             select new ProductDetail
                             {
                                 ProductId = p.ProductId,
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName
                             };
                return result.ToList();
            }
        }
    }
}
