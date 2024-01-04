using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Api.Entities
{
    public class User
    {
        [Key]
        public int userId { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }  = string.Empty;
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        public ShopCar? car { get; set; }
    }
}
