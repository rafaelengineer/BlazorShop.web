using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShop.Model.DTO_s
{
    public class Product_DTO
    {
        public int productId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string ImagemUrl { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? Manufacturer { get; set; }
        public int qtdInStock { get; set; }
    }
}
