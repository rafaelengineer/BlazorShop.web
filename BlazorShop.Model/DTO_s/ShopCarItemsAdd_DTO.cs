using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShop.Model.DTO_s
{
    public class ShopCarItemsAdd_DTO
    {
        [Required]
        public int productId { get; set; }
        [Required]
        public int carId {  get; set; } 
        [Required]
        public int qtd {  get; set; }
    }
}
