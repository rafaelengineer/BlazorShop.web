using Blazored.LocalStorage;
using BlazorShop.Model.DTO_s;

namespace BlazorShop.Web.Services;

public class GerenciaCarrinhoItensLocalStorageService : IGerenciaCarrinhoItensLocalStorageService
{
    const string key = "CarrinhoItemCollection";

    private readonly ILocalStorageService localStorageService;
    private readonly ICarrinhoCompraService carrinhoCompraService;

    public GerenciaCarrinhoItensLocalStorageService(ILocalStorageService localStorageService,
        ICarrinhoCompraService carrinhoCompraService)
    {
        this.localStorageService = localStorageService;
        this.carrinhoCompraService = carrinhoCompraService;
    }

    public async Task<List<ShopItems_DTO>> GetCollection()
    {
        return await this.localStorageService.GetItemAsync<List<ShopItems_DTO>>(key)
               ?? await AddCollection();
    }

    public async Task RemoveCollection()
    {
        await this.localStorageService.RemoveItemAsync(key);
    }

    public async  Task SaveCollection(List<ShopItems_DTO> carrinhoItensDto)
    {
        await this.localStorageService.SetItemAsync(key, carrinhoItensDto);
    }

    //obtem os dados do servidor e armazena no localstorage
    private async Task<List<ShopItems_DTO>> AddCollection()
    {
        var carrinhoCompraCollection = await this.carrinhoCompraService
                                          .GetItens(LogedUser.UserId);

        if (carrinhoCompraCollection != null)
        {
            await this.localStorageService.SetItemAsync(key, carrinhoCompraCollection);
        }
        return null; // carrinhoCompraCollection;
    }
}



