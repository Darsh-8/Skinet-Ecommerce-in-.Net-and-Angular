﻿using Core.Entities;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public class ProductswithTypesandBrandsSpecification : BaseSpecification<Product>
    {
        public ProductswithTypesandBrandsSpecification()
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }

        public ProductswithTypesandBrandsSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}