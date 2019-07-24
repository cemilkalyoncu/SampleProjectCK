using System;
using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SampleProjectCK.Northwind.Business.Concrete.Managers;
using SampleProjectCK.Northwind.DataAccess.Abstract;
using SampleProjectCK.Northwind.Entities.Concrete;

namespace SampleProjectCK.Northwind.Business.Tests
{
    /*Validationları test etmek için nugetpack'den moq yukledik
     bu test validation exception fırlatması gerekiyor*/


    [TestClass]
    public class ProductManagerTests
    {
        /*ValidationException için fluentvalidation nugetten ekleniyor*/
        [ExpectedException(typeof(ValidationException))]
        [TestMethod]
        public void Product_validation_check()
        {
            Mock<IProductDal> mock = new Mock<IProductDal>();
            ProductManager productManager = new ProductManager(mock.Object);
            productManager.Add(new Product());
        }
    }
}
