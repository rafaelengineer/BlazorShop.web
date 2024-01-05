using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorShop.Api.Entities
{
    public class Product
    {
        [Key]
        public int productId { get; set; }//Id: An integer that represents the unique identifier of the product.
        [MaxLength(100)]
        public string Name { get; set; }//Name: A string that represents the name of the product.
        [MaxLength(200)]
        public string Description { get; set; }//Description: A string that provides a description of the product.
        [MaxLength(200)]
        public string ImagemUrl { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }//Price: A decimal that represents the price of the product.
        public int CategoryId { get; set; }//Category: A string that represents the category to which the product belongs.
        public Category? Category { get; set; }
        [MaxLength(100)]
        public string? Manufacturer { get; set; }//Manufacturer: A string that represents the manufacturer of the product.
        public int qtdInStock { get; set; }//qtdInStock: A integer that indicates how many unities of the product are in stock.
        //[Column(TypeName = "timestamptz")]
        //public DateTimeOffset ManufactureDate { get; set; }//ManufactureDate: A DateTime that represents the date the product was manufactured.

        public ICollection<ShopCar> ShopCars { get; set; }
        = new List<ShopCar>();
    }
}