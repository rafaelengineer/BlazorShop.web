using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Api.Entities
{
    public class ShopCar
    {
        [Key]
        public int carId { get; set; }
        public int userId { get; set; }

        public ICollection<shopItems> Itens { get; set; } =
            new List<shopItems>();

    }
}
