using Bogus;
using Microsoft.AspNetCore.Mvc;
using ProductsWebApp.Models;
using ProductsWebApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Description;

namespace ProductsWebApp.Controllers
{
    [ApiController]
    [Route("api/")]
    public class ProductControllerAPI : ControllerBase
    {
        ProductsDAO products;

        public ProductControllerAPI()
        {
            products = new ProductsDAO();
        }

        [HttpGet]
        [ResponseType(typeof(List<ProductDTO>))]
        public IEnumerable<ProductDTO> Index()
        {
            //HardCodedSampleDataRepo sampleData = new HardCodedSampleDataRepo();
            List<ProductModel> productList = products.GetAllProducts();
            IEnumerable<ProductDTO> productDTOs = from p in productList select new ProductDTO(p);
            return productDTOs;
        }

        [HttpGet("searchproducts/{searchTerm}")]
        public ActionResult <IEnumerable<ProductDTO>> SearchResults(string searchTerm)
        {
            List<ProductModel> productList = products.SearchProducts(searchTerm);
            List<ProductDTO> productDTOs = new List<ProductDTO>();
            foreach (var p in productList)
            {
                productDTOs.Add(new ProductDTO(p));
            };
            return productDTOs;
        }

        [HttpGet("ShowOneProduct/{id}")]
        public ActionResult<ProductDTO> ShowDetails(int id)
        {
            ProductModel foundProduct = products.GetProductById(id);
            ProductDTO pDTO = new ProductDTO(foundProduct);
            return pDTO;
        }

        [HttpPost("InsertOne")]
        public ActionResult<ProductDTO> InsertOne(ProductModel product)
        {   
            int productId = products.Insert(product);
            ProductModel insertedProduct = products.GetProductById(productId);
            ProductDTO pDTO = new ProductDTO(insertedProduct);
            return pDTO;
        }

        [HttpPut("ProcessEdit")]
        public ActionResult<ProductDTO> ProcessEdit(ProductModel product)
        {
            int productId = products.Update(product);
            ProductModel editedProduct = products.GetProductById(productId);
            ProductDTO pDTO = new ProductDTO(editedProduct);
            return pDTO;
        }

        [HttpDelete("Delete/{Id}")]
        public ActionResult<int> Delete(int Id)
        {
            ProductModel product = products.GetProductById(Id);
            int productId = products.Delete(product);
            return productId;
        }

    }
}
