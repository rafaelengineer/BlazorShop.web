using BlazorShop.Model.DTO_s;
using System.Net;
using System.Net.Http.Json;

namespace BlazorShop.Web.Services;

public class ProdutoService : IProdutoService
{
    public HttpClient _httpClient;
    public ILogger<ProdutoService> _logger;

    public ProdutoService(HttpClient httpClient,
        ILogger<ProdutoService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<IEnumerable<Product_DTO>> GetItens()
    {
        try
        {
            var produtosDto = await _httpClient.
                             GetFromJsonAsync<IEnumerable<Product_DTO>>("api/produtos");
            return produtosDto;
        }
        catch (Exception)
        {
            _logger.LogError("Erro ao acessar produtos : api/produtos ");
            throw;
        }
    }

    public async Task<Product_DTO> GetItem(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/produtos/{id}");

            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.NoContent)
                {
                    return default(Product_DTO);
                }
                return await response.Content.ReadFromJsonAsync<Product_DTO>();
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                _logger.LogError($"Erro a obter produto pelo id= {id} - {message}");
                throw new Exception($"Status Code : {response.StatusCode} - {message}");
            }
        }
        catch (Exception)
        {
            _logger.LogError($"Erro a obter produto pelo id={id}");
            throw;
        }
    }

    public async Task<IEnumerable<Category_DTO>> GetCategorias()
    {
        try
        {
            var response = await _httpClient.GetAsync("api/Produtos/GetCategorias");
            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return Enumerable.Empty<Category_DTO>();
                }
                return await response.Content.ReadFromJsonAsync<IEnumerable<Category_DTO>>();
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                throw new Exception($"Http Status Code - {response.StatusCode} Message - {message}");
            }
        }
        catch (Exception)
        {
            //log exception
            throw;
        }
    }

    public async Task<IEnumerable<Product_DTO>> GetItensPorCategoria(int categoriaId)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/Produtos/{categoriaId}/GetItensPorCategoria");
            
            if (response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return Enumerable.Empty<Product_DTO>();
                }
                return await response.Content.ReadFromJsonAsync<IEnumerable<Product_DTO>>();
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                throw new Exception($"Http Status Code - {response.StatusCode} Message - {message}");
            }
        }
        catch (Exception)
        {
            //log exception
            throw;
        }
    }

}
