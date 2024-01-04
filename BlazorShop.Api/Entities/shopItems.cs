using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Api.Entities
{
    public class shopItems
    {
        [Key]
        public int shopItemsId { get; set; }
        public int productId { get; set; }
        public int carId {  get; set; }
        public int qtd {  get; set; }

        public ShopCar? shopCar { get; set; }
        public Product? product { get; set; }
    }
}
