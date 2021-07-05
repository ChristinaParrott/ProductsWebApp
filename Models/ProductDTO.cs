using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsWebApp.Models
{
    public class ProductDTO
    {
        [DisplayName("ID Number")]
        public int Id { get; set; }
        [DisplayName("Product Name")]
        public string Name { get; set; }
        [DisplayName("Product Price")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public string PriceString { get; set; }
        [DisplayName("Product Description")]
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public decimal Tax { get; set; }

        public ProductDTO(int id, string name, decimal price, string description)
        {
            Id = id;
            Name = name;
            Price = price;
            Description = description;

            PriceString = string.Format("{0:C}", price);
            ShortDescription = description.Length <= 25 ? description : description.Substring(0, 25);
            Tax = price * 0.08M;
        }

        public ProductDTO(ProductModel p)
        {
            Id = p.Id;
            Name = p.Name;
            Price = p.Price;
            Description = p.Description;

            PriceString = string.Format("{0:C}", p.Price);
            ShortDescription = p.Description.Length <= 25 ? p.Description : p.Description.Substring(0, 25);
            Tax = p.Price * 0.08M;
        }
    }
}
