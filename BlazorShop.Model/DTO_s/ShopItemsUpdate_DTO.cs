using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShop.Model.DTO_s
{
    public class ShopItemsUpdate_DTO
    {
        public int shopItemsId { get; set; }
        public int qtdItem { get; set; }
    }
}
