using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsWebApp.Models
{
    public class ProductModel
    {
        [DisplayName("ID Number")]
        public int Id { get; set; }
        [DisplayName("Product Name")]
        public string Name { get; set; }
        [DisplayName("Product Price")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [DisplayName("Product Description")]
        public string Description { get; set; }
    }
}
