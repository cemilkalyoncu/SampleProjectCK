using SampleProjectCK.Core.DataAccess.EntityFramework;
using SampleProjectCK.Northwind.DataAccess.Abstract;
using SampleProjectCK.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProjectCK.Northwind.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal: EfEntityRepositoryBase<Category, NorthwindContext>, ICategoryDal
    {
    }
}
