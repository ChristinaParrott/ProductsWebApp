using Bogus;
using Microsoft.AspNetCore.Mvc;
using ProductsWebApp.Models;
using ProductsWebApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsWebApp.Controllers
{
    public class ProductController : Controller
    {
        ProductsDAO products;
        public ProductController()
        {
            products = new ProductsDAO();
        }
        public IActionResult Index()
        {
            //HardCodedSampleDataRepo sampleData = new HardCodedSampleDataRepo();
            return View(products.GetAllProducts());
        }

        public IActionResult SearchForm()
        {
            return View();
        }

        public IActionResult SearchResults(string searchTerm)
        {
            List<ProductModel> productList = products.SearchProducts(searchTerm);
            return View("index", productList);
        }

        public IActionResult ShowDetails(int id)
        {
            ProductModel foundProduct = products.GetProductById(id);
            return View(foundProduct);
        }
        public IActionResult ShowDetailsJSON(int id)
        {
            ProductModel foundProduct = products.GetProductById(id);
            return Json(foundProduct);
        }
        public IActionResult Edit(int id)
        {
            ProductModel foundProduct = products.GetProductById(id);
            return View("EditForm", foundProduct);
        }

        public IActionResult ProcessEdit(ProductModel product)
        {
            int productId = products.Update(product);
            return View("Index", products.GetAllProducts());
        }
        public IActionResult ProcessEditReturnPartial(ProductModel product)
        {
            int productId = products.Update(product);
            return PartialView("_productCard", product);
        }
        public IActionResult Delete(int Id)
        {
            ProductModel product = products.GetProductById(Id);
            int productId = products.Delete(product);
            return View("Index", products.GetAllProducts());
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult ProcessCreate(ProductModel product)
        {
            int productId = products.Insert(product);
            return View("Index", products.GetAllProducts());
        }
    }
}
