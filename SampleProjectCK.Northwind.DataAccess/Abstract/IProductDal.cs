using SampleProjectCK.Core.DataAccess;
using SampleProjectCK.Northwind.Entities.ComplexTypes;
using SampleProjectCK.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProjectCK.Northwind.DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
        List<ProductDetail> GetProductDetails();
    }
}
