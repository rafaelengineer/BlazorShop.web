using BlazorShop.Model.DTO_s;

namespace BlazorShop.Web.Services;

public interface IGerenciaProdutosLocalStorageService
{
    Task<IEnumerable<Product_DTO>> GetCollection();
    Task RemoveCollection();
}
