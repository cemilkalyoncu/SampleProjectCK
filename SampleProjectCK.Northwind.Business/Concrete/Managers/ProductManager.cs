using SampleProjectCK.Northwind.Business.Abstract;
using SampleProjectCK.Northwind.Business.ValidationRules.FluentValidation;
using SampleProjectCK.Northwind.DataAccess.Abstract;
using SampleProjectCK.Northwind.Entities.Concrete;
using SampleProjectCK.Core.CrossCuttingConcerns.Caching.Microsoft;
using SampleProjectCK.Core.Aspects.Postsharp.TransactionAspects;
using SampleProjectCK.Core.Aspects.Postsharp.ValidationAspects;
using SampleProjectCK.Core.Aspects.Postsharp.CacheAspects;
using SampleProjectCK.Core.Aspects.Postsharp.CacheRemoveAspects;
using SampleProjectCK.Core.Aspects.Postsharp.PerformanceAspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Threading;
using SampleProjectCK.Core.Aspects.Postsharp.LogAspects;
using System.Data.Entity.Infrastructure.Interception;
using SampleProjectCK.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using SampleProjectCK.Core.Aspects.Postsharp.AuthorizationAspects;
using AutoMapper;
using SampleProjectCK.Core.Utilities.Mappings;

namespace SampleProjectCK.Northwind.Business.Concrete.Managers
{
    //[LogAspect(typeof(FileLogger))]//hatalı çalısıyor "controllertype"
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        private IMapper _mapper;


        public ProductManager(IProductDal productDal,IMapper mapper)
        {
            _productDal = productDal;
            _mapper = mapper;
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        [PerformanceCounterAspect(2)]
        [SecuredOperation(Roles = "Admin,Editor,Student")]
        public List<Product> GetAll()
        {
            //manuel mapping yaptık, efde verileri çekerken getlist ile
            //serileştirme problemi oldugundan mapping yapılıyor.
            //Thread.Sleep(3000);
            //return _productDal.GetList().Select(p => new Product
            //{
            //    CategoryId = p.CategoryId,
            //    ProductId = p.ProductId,
            //    ProductName = p.ProductName,
            //    QuantityPerUnit = p.QuantityPerUnit,
            //    UnitPrice = p.UnitPrice
            //}).ToList();

            //Core katmanında proje genelinde kullanılabilen automapper olusturduk.
            // var products = AutoMapperHelper.MapToSameTypeList<Product>(_productDal.GetList());
            //Business katmanından yapılan automapper yöntemi daha gelişmiş hali.
            //ninject ile bi kere configuration gerçekleşecek.
            var products = _mapper.Map<List<Product>>(_productDal.GetList());
            return products;
        }


        public Product GetById(int id)
        {
            return _productDal.Get(p => p.ProductId == id);
        }

        [FluentValidationAspect(typeof(ProductValidatior))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Product Add(Product product)
        {
            return _productDal.Add(product);
        }

        [FluentValidationAspect(typeof(ProductValidatior))]
        public Product Update(Product product)
        {
            return _productDal.Update(product);
        }

        [TransactionScopeAspect]
        [FluentValidationAspect(typeof(ProductValidatior))]
        public void TransactionalOperation(Product product1, Product product2)
        {
            _productDal.Add(product1);
            // Business Codes
            _productDal.Update(product2);
        }
    }
}
