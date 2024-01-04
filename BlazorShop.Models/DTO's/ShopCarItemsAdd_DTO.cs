using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShop.Model.DTO_s
{
    internal class ShopCarItemsAdd_DTO
    {
        [Required]
        public int shopItemsId { get; set; }
        [Required]
        public string name { get; set; } = string.Empty;
        [Required]
        public string description { get; set; } = string.Empty;
    }
}
