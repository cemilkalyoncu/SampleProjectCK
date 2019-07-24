﻿using FluentValidation;
using SampleProjectCK.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace SampleProjectCK.Northwind.Business.ValidationRules.FluentValidation
{
    public class ProductValidatior:AbstractValidator<Product>
    {
        public ProductValidatior()
        {
            RuleFor(p => p.CategoryId).NotEmpty();
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.QuantityPerUnit).NotEmpty();
            RuleFor(p => p.ProductName).Length(2,20);
            RuleFor(p => p.UnitPrice).GreaterThan(20).When(p=>p.CategoryId==1);
            /*kendi methodumuzu yazabiliriz. A ile başlayan ürün ismi gibi
            RuleFor(p => p.ProductName).Must(StartWithA);
            */
        }
        /*
        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
        */
    }
}