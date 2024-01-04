using BlazorShop.Model.DTO_s;

namespace BlazorShop.Web.Services;

public interface IGerenciaCarrinhoItensLocalStorageService
{
    Task<List<ShopItems_DTO>> GetCollection();
    Task SaveCollection(List<ShopItems_DTO> carrinhoItensDto);
    Task RemoveCollection();
}
