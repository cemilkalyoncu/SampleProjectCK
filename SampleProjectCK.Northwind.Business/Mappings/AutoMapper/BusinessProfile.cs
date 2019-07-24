using AutoMapper;
using SampleProjectCK.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProjectCK.Northwind.Business.Mappings.AutoMapper
{
    public class BusinessProfile:Profile
    {
        public BusinessProfile()
        {
            CreateMap<Product, Product>();
        }
    }
}
