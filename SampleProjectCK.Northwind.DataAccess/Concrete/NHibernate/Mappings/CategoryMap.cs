using FluentNHibernate.Mapping;
using SampleProjectCK.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProjectCK.Northwind.DataAccess.Concrete.NHibernate.Mappings
{
    public class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Table(@"Products");

            LazyLoad();

            Id(x => x.CategoryId).Column("CategoryID");

            Map(x => x.CategoryName).Column("CategoryName");
        }
    }
}
