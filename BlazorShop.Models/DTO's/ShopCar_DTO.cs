using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShop.Model.DTO_s
{
    internal class ShopCar_DTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int shopItemId { get; set; }
        public int carId { get; set; }

        public string? Produto_Name { get; set; }
        public string? Produto_Description { get; set; }
        public string? Produto_Manufacturer { get; set; }
        public decimal Price { get; set; }
        public decimal Total_Price { get; set; }
    }
}
