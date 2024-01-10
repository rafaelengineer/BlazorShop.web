using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShop.Model.DTO_s
{
    public class ShopItems_DTO
    {
        public int shopItemsId { get; set; }
        public int productId { get; set; }
        public int shopCarId { get; set; }
        public int qtd { get; set; }

        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public string? ProductImageURL { get; set; }
        public decimal Price { get; set; }
        public decimal PriceTotal { get; set; }
    }
}
