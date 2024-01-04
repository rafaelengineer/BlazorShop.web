using Blazored.LocalStorage;
using BlazorShop.Model.DTO_s;

namespace BlazorShop.Web.Services;

public class GerenciaProdutosLocalStorageService : IGerenciaProdutosLocalStorageService
{
    private const string key = "ProdutoCollection";

    private readonly ILocalStorageService localStorageService;
    private readonly IProdutoService produtoService;

    public GerenciaProdutosLocalStorageService(ILocalStorageService localStorageService,
        IProdutoService produtoService)
    {
        this.localStorageService = localStorageService;
        this.produtoService = produtoService;
    }

    public async Task<IEnumerable<Product_DTO>> GetCollection()
    {
        return await this.localStorageService.GetItemAsync<IEnumerable<Product_DTO>>(key) 
                         ?? await AddCollection();
    }

    public async Task RemoveCollection()
    {
        await this.localStorageService.RemoveItemAsync(key);
    }

    private async Task<IEnumerable<Product_DTO>> AddCollection()
    {
        var produtoCollection = await this.produtoService.GetItens();
        if (produtoCollection != null)
        {
            await this.localStorageService.SetItemAsync(key, produtoCollection);
        }
        return produtoCollection;
    }
}
