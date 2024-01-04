using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShop.Model.DTO_s
{
    public class ShopCar_DTO
    {
        [Key]
        public int carId { get; set; }
        public int userId { get; set; }
    }
}
