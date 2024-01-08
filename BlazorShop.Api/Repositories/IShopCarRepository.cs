using BlazorShop.Api.Entities;
using BlazorShop.Model.DTO_s;

namespace BlazorShop.Api.Repositories
{
    public interface IShopCarRepository
    {
        Task<shopItems> GetShopItems(int id);
        Task<shopItems> AddShopItems(ShopCarItemsAdd_DTO _shopCarItemsAdd_DTO);
        Task<shopItems> UpdateShopItems(int id, ShopItemsUpdate_DTO _shopItemsUpdate_DTO);
        Task<shopItems> DeleteShopItems(int id);
        Task<IEnumerable<shopItems>> GetItems(int userId);
    }
}
