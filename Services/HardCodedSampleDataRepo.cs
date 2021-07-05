using Bogus;
using ProductsWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsWebApp.Services
{
    public class HardCodedSampleDataRepo : IProductDataService
    {
        static List<ProductModel> productList = new List<ProductModel>();

        public int Delete(ProductModel proudct)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> GetAllProducts()
        {
            if (productList.Count == 0)
            {
                for (int i = 0; i < 101; i++)
                {
                    productList.Add(new Faker<ProductModel>()
                            .RuleFor(p => p.Id, i)
                            .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                            .RuleFor(p => p.Price, f => f.Random.Decimal(1000))
                            .RuleFor(p => p.Description, f => f.Rant.Review())
                        );
                }
            }
            return productList;
        }

        public ProductModel GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> SearchProducts(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public int Update(ProductModel product)
        {
            throw new NotImplementedException();
        }
    }
}
