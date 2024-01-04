using BlazorShop.Api.Context;
using BlazorShop.Api.Entities;
using BlazorShop.Model.DTO_s;
using Microsoft.EntityFrameworkCore;

namespace BlazorShop.Api.Repositories
{
    public class ShopCarRepository : IShopCarRepository
    {
        private readonly AppDbContext _context;

        public ShopCarRepository( AppDbContext context)
        {
            _context = context;
        }

        private async Task<bool> CarAlreadyExist(int shopItemId, int productId)
        {
            return await _context.tb_ShopItems.AnyAsync(c => c.shopCar.carId == shopItemId &&
                                                            c.product.productId == productId);
        }

        public async Task<shopItems> AddShopItems(ShopCarItemsAdd_DTO _shopCarItemsAdd_DTO)
        {
            if (await CarAlreadyExist(_shopCarItemsAdd_DTO.carId, _shopCarItemsAdd_DTO.productId)==false)
            {
                var item = await(from product in _context.tb_Product
                                 where product.productId == _shopCarItemsAdd_DTO.productId
                                 select new shopItems
                                 {
                                     carId = _shopCarItemsAdd_DTO.carId,
                                     productId = product.productId,
                                     qtd = _shopCarItemsAdd_DTO.qtd
                                 }).SingleOrDefaultAsync();
                if(item is not null)
                {
                    var result = await _context.tb_ShopItems.AddAsync(item);
                    await _context.SaveChangesAsync();
                    return result.Entity;
                }
            }

            return null;
        }
        public async Task<shopItems> UpdateShopItems(int id, ShopItemsUpdate_DTO _shopItemsUpdate_DTO)
        {
            var _shopItem = await _context.tb_ShopItems.FindAsync(id);
            if (_shopItem != null)
            {
                _shopItem.qtd = _shopItemsUpdate_DTO.qtdItem;
                await _context.SaveChangesAsync();
                return  _shopItem;
            }
            return null;
        }
        public async Task<shopItems> DeleteShopItems(int id)
        {
            var item = await _context.tb_ShopItems.FindAsync(id);
            if(item is not null)
            {
                _context.tb_ShopItems.Remove(item);
                await _context.SaveChangesAsync();
            }
            return item;
        }

        public async Task<shopItems> GetShopItems(int id)
        {
            return await (from shopCar in _context.tb_ShopCars
                          join shopItem in _context.tb_ShopItems
                          on shopCar.carId equals shopItem.carId
                          where shopCar.carId == id
                          select new shopItems
                          {
                              shopItemsId = shopItem.shopItemsId,
                              productId = shopItem.productId,
                              qtd = shopItem.qtd,
                              carId = shopItem.carId
                          }).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<shopItems>> GetItems(int userId)
        {
            return await (from shopCar in _context.tb_ShopCars
                          join shopItem in _context.tb_ShopItems
                          on shopCar.carId equals shopItem.carId
                          where shopCar.userId == userId
                          select new shopItems
                          {
                              shopItemsId = shopItem.shopItemsId,
                              productId = shopItem.productId,
                              qtd = shopItem.qtd,
                              carId = shopItem.carId
                          }).ToListAsync();
        }

    }
}
